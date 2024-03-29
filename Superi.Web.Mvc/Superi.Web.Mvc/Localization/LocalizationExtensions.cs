﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Reflection;
using System.Data.Objects;
using System.Globalization;
using System.Threading;
using System.Data.Objects.DataClasses;
using System.Collections;

namespace Superi.Web.Mvc.Localization
{
    public static class LocalizationExtensions
    {
        public static void SeveLocalization<T>(IEnumerable<T> localization, ObjectSet<T> localizations) where T : class, new()
        {
            var objectQuery = (localizations as ObjectQuery);
            if (objectQuery == null)
                throw new ArgumentException("localizations must be ObjectQuery", "localizations");
            
            foreach (T item in localization)
            {
                int entityId = (int)((dynamic)item).EntityId;
                string entityName = (string)((dynamic)item).EntityName;
                string language = (string)((dynamic)item).Language;
                var param = Expression.Parameter(typeof(T), "l");
                var condition = Expression.And(Expression.Equal(Expression.Property(param, typeof(T).GetProperty("EntityId")), Expression.Constant(entityId)),
                    Expression.Equal(Expression.Property(param, typeof(T).GetProperty("EntityName")), Expression.Constant(entityName)));
                MethodInfo where = typeof(Queryable).GetMethods().Where(m => m.Name == "Where").First().MakeGenericMethod(typeof(T));
                condition = Expression.And(condition, Expression.Equal(Expression.Property(param, typeof(T).GetProperty("Language")), Expression.Constant(language)));

                var conditionLambda = Expression.Lambda<Func<T, bool>>(condition, param);

                var whereCall = Expression.Call(where, localizations.AsQueryable().Expression, conditionLambda);

                IQueryable<T> query = (IQueryable<T>)whereCall.Method.Invoke(null, new object[] { localizations, conditionLambda });
                var resource = query.FirstOrDefault();
                if (resource == null)
                    localizations.AddObject(item);
                else
                {
                    ((dynamic)item).Id = ((dynamic)resource).Id;
                    objectQuery.Context.ApplyCurrentValues(localizations.EntitySet.Name, item);
                }
            }
            objectQuery.Context.SaveChanges();
        }

        public static IDictionary<string, T> Localizations<T, L>(this T source, IEnumerable<L> localizations, string entityName = null) where T:EntityObject, new()
        {
            string eName = entityName ?? typeof(T).Name;

            int eId = ((dynamic)source).Id;


            //locCindition = (l=>l.EntityId == <eId> && l.EntityName == <eName>)
            var param = Expression.Parameter(typeof(L), "l");
            var locCondition = Expression.Lambda<Func<L, bool>>(
                Expression.And(
                    Expression.Equal(Expression.MakeMemberAccess(param, typeof(L).GetProperty("EntityId")), Expression.Constant(eId)),
                    Expression.Equal(Expression.MakeMemberAccess(param, typeof(L).GetProperty("EntityName")), Expression.Constant(eName))
                ), param);

            MethodInfo where = typeof(Queryable).GetMethods().Where(m => m.Name == "Where").First().MakeGenericMethod(typeof(L));
            
            var whereCall = Expression.Call(where, localizations.AsQueryable().Expression, locCondition);

            var keySelector = Expression.Lambda<Func<L, string>>((Expression)Expression.MakeMemberAccess(param, typeof(L).GetProperty("Language")), param);

            var typeStub = new { FieldName = "", Text = "" };

            var constructorArgs = new Expression[]{Expression.MakeMemberAccess(param, typeof(L).GetProperty("FieldName")), 
                        Expression.MakeMemberAccess(param, typeof(L).GetProperty("Text"))};

            var members = typeStub.GetType().GetMember("FieldName").Concat(typeStub.GetType().GetMember("Text"));
            
            var elementSelector = Expression.Lambda(
                    Expression.New(typeStub.GetType().GetConstructor(new Type[] { typeof(string), typeof(string) }),
                        constructorArgs, members
                        )
                , param);
            
            MethodInfo groupBy = typeof(Queryable).GetMethods().Where(m => m.Name == "GroupBy" && m.GetParameters().Length == 3).First()
                .MakeGenericMethod(typeof(L), typeof(string), typeStub.GetType());

            var groupByCall = Expression.Call(groupBy, whereCall, keySelector, elementSelector);

            IQueryable groupByResult = (IQueryable)groupByCall.Method.Invoke(null, new object[] { localizations, keySelector, elementSelector });

            Dictionary<string, T> result = new Dictionary<string, T>();
            foreach (object item in groupByResult)
            {
                string key = (string)item.GetType().GetProperty("Key").GetValue(item, null);
                result.Add(key, Materialize<T>((IEnumerable)item.GetType().GetProperty("Group").GetValue(item, null)));
            }

            return result;
        }

        private static T Materialize<T>(IEnumerable presentations) where T : new()
        {
            T result = new T();
            foreach (dynamic item in presentations)
            {
                PropertyInfo prop = typeof(T).GetProperty((string)item.FieldName);
                prop.SetValue(result, item.Text, null);
            }
            return result;
        }

        public static IQueryable<TResult> Localize<T, L, TKey, TResult>(
            this IQueryable<T> source,
            Expression<Func<T, TKey>> entityIdSelector,
            string lang,
            Expression<Func<T, IEnumerable<L>, TResult>> resultSelector,
            IEnumerable<L> localizations,
            string entityName = null,
            Expression<Func<L, TKey>> localizationIdSelector = null
            )
        {
            ObjectQuery objectQuery = (source as ObjectQuery);
            if (objectQuery == null)
                throw new ArgumentException("source must be ObjectQuery", "source");
            string eName = entityName ?? typeof(T).Name;

            if (localizations == null)
            {
                PropertyInfo pi = objectQuery.Context.GetType().GetProperties().Where(m => m.ReflectedType == typeof(ObjectSet<>).MakeGenericType(typeof(L))).Single();
                localizations = (IEnumerable<L>)pi.GetValue(objectQuery.Context, null);
            }

            var param = Expression.Parameter(typeof(L));
            var langEquals = Expression.Lambda<Func<L, bool>>(Expression.Equal(Expression.MakeMemberAccess(param, typeof(L).GetProperty("Language")), Expression.Constant(lang)), param);
            var eNameEquals = Expression.Lambda<Func<L, bool>>(Expression.Equal(Expression.MakeMemberAccess(param, typeof(L).GetProperty("EntityName")), Expression.Constant(eName)), param);

            MethodInfo where = typeof(Queryable).GetMethods().Where(m => m.Name == "Where").First().MakeGenericMethod(typeof(L));

            var langCall = Expression.Call(where, Expression.Convert(resultSelector.Parameters[1], typeof(IQueryable<L>)), langEquals);
            var eNameCall = Expression.Call(where, langCall, eNameEquals);
            var resNew = (resultSelector.Body as NewExpression);
            if (resNew == null)
                throw new ArgumentException("resultSelector must be NewExpression", "resultSelector");
            Expression[] args = resNew.Arguments.Select(a =>
            {
                if (a.NodeType == ExpressionType.Parameter && ((ParameterExpression)a).Type == typeof(IEnumerable<L>))
                    return eNameCall;
                else
                    return a;
            }).ToArray();
            var body = Expression.New(resNew.Constructor, args, resNew.Members);
            var updatedResultSelector = Expression.Lambda<Func<T, IEnumerable<L>, TResult>>((Expression)body, resultSelector.Parameters[0], resultSelector.Parameters[1]);//resultSelector.Update(langLambda.Body,new ParameterExpression[]{resultSelector.Parameters[0], resultSelector.Parameters[1]});
            return source.GroupJoin(localizations, entityIdSelector, localizationIdSelector, updatedResultSelector);
        }

        public static IQueryable<TResult> Localize<T, L, TKey, TResult>(
            this IQueryable<T> source,
            Expression<Func<T, IEnumerable<L>, TResult>> resultSelector,
            IEnumerable<L> localizations,
            Expression<Func<T, TKey>> entityIdSelector,
            string entityName = null,
            Expression<Func<L, TKey>> localizationIdSelector = null
            )
        {
            if (localizationIdSelector == null)
            {
                var param = Expression.Parameter(typeof(L), "l");
                localizationIdSelector = Expression.Lambda<Func<L, TKey>>((Expression)Expression.MakeMemberAccess(param, typeof(L).GetProperty("EntityId")), param);
            }

            return source.Localize(entityIdSelector, CultureInfo.CurrentUICulture.Name, resultSelector, localizations, entityName, localizationIdSelector);
        }

        public static IQueryable<TResult> Localize<T, L, TResult>(
            this IQueryable<T> source,
            Expression<Func<T, IEnumerable<L>, TResult>> resultSelector,
            IEnumerable<L> localizations,
            string entityName = null
            )
        {
            var param = Expression.Parameter(typeof(T), "e");
            var entityIdSelector = Expression.Lambda<Func<T, int>>((Expression)Expression.MakeMemberAccess(param, typeof(T).GetProperty("Id")), param);

            return source.Localize(resultSelector, localizations, entityIdSelector);
        }

    }
}
