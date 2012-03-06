using System;
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
using Shop.Models;

namespace Superi.Web.Mvc.Localization
{
    public static class LocalizationExtensions
    {
        public static void SaveLocalizationsTo<T>(this IEnumerable<T> localization, ObjectSet<T> localizations, bool immediateSave = true) where T : class, new()
        {
            var objectQuery = (localizations as ObjectQuery);
            if (objectQuery == null)
                throw new ArgumentException("must be ObjectQuery", "localizations");

            foreach (T item in localization)
            {
                int entityId = (int)((dynamic)item).EntityId;
                string entityName = (string)((dynamic)item).EntityName;
                string language = (string)((dynamic)item).Language;
                string fieldName = (string)((dynamic)item).FieldName;
                var param = Expression.Parameter(typeof(T), "l");
                var condition = Expression.And(Expression.Equal(Expression.Property(param, typeof(T).GetProperty("EntityId")), Expression.Constant(entityId)),
                    Expression.Equal(Expression.Property(param, typeof(T).GetProperty("EntityName")), Expression.Constant(entityName)));
                MethodInfo where = typeof(Queryable).GetMethods().Where(m => m.Name == "Where").First().MakeGenericMethod(typeof(T));
                condition = Expression.And(condition, Expression.Equal(Expression.Property(param, typeof(T).GetProperty("Language")), Expression.Constant(language)));
                condition = Expression.And(condition, Expression.Equal(Expression.Property(param, typeof(T).GetProperty("FieldName")), Expression.Constant(fieldName)));
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
            if (immediateSave)
                objectQuery.Context.SaveChanges();
        }

        public static IQueryable<L> Localizations<T, L>(this T source, IEnumerable<L> localizations, string entityName = null) where T : EntityObject, new()
        {
            if (source == null)
                return Enumerable.Empty<L>().AsQueryable();

            string eName = entityName ?? typeof(T).Name;

            int eId = ((dynamic)source).Id;

            var param = Expression.Parameter(typeof(L), "l");
            var locCondition = Expression.Lambda<Func<L, bool>>(
                Expression.And(
                    Expression.Equal(Expression.MakeMemberAccess(param, typeof(L).GetProperty("EntityId")), Expression.Constant(eId)),
                    Expression.Equal(Expression.MakeMemberAccess(param, typeof(L).GetProperty("EntityName")), Expression.Constant(eName))
                ), param);

            return localizations.AsQueryable().Where(locCondition);
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

        public static T UpdateValues<T, L>(this T item, IEnumerable<L> localizations) where T : EntityObject
        {
            foreach (var localizationItem in localizations)
            {
                if ((int)((dynamic)localizationItem).EntityId == (int)((dynamic)item).Id && typeof(T).Name == ((dynamic)localizationItem).EntityName)
                {
                    string fieldName = (string)((dynamic)localizationItem).FieldName;
                    string text = (string)((dynamic)localizationItem).Text;
                    PropertyInfo info = typeof(T).GetProperty(fieldName);
                    info.SetValue(item, text, null);
                }
            }
            return item;
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
                PropertyInfo pi = objectQuery.Context.GetType().GetProperties().Where(m => m.PropertyType == typeof(ObjectSet<>).MakeGenericType(typeof(L))).Single();
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
            IEnumerable<L> localizations = null,
            string entityName = null
            )
        {
            var param = Expression.Parameter(typeof(T), "e");
            var entityIdSelector = Expression.Lambda<Func<T, int>>((Expression)Expression.MakeMemberAccess(param, typeof(T).GetProperty("Id")), param);

            return source.Localize(resultSelector, localizations, entityIdSelector);
        }

        public static IQueryable<L> GetLocalizations<T, L>(this IQueryable<T> entities, IQueryable<L> localizations)
            where T : EntityObject
            where L : EntityObject
        {
            string entityName = typeof(T).Name;
            IEnumerable<string> fieldNames = typeof(T).GetProperties().Where(pi=>pi.PropertyType == typeof(string)).Select(pi => pi.Name);
            var param = Expression.Parameter(typeof(L));

            string lang = CultureInfo.CurrentUICulture.Name;

            var langEquals = Expression.Lambda<Func<L, bool>>(Expression.Equal(
                Expression.MakeMemberAccess(
                param, 
                typeof(L).GetProperty("Language")), Expression.Constant(lang)), 
                    param);
            var eNameEquals = Expression.Lambda<Func<L, bool>>(Expression.Equal(
                Expression.MakeMemberAccess(param, typeof(L).GetProperty("EntityName")),
                Expression.Constant(entityName)), 
                param);

            var fieldNameAccess = Expression.Lambda<Func<L, string>>(Expression.MakeMemberAccess(param, typeof(L).GetProperty("FieldName")), param);
            var inFieldNames = ContextExtension.BuildContainsExpression<L, string>(fieldNameAccess, fieldNames);

            var localizationIdAccess = Expression.Lambda<Func<L, int>>(Expression.MakeMemberAccess(param, typeof(L).GetProperty("EntityId")), param);

            var entityParam = Expression.Parameter(typeof(T));
            var entityIdAccess = Expression.Lambda<Func<T, int>>(Expression.MakeMemberAccess(entityParam, typeof(T).GetProperty("Id")), entityParam);
            IEnumerable<int> entityIds = entities.Select(entityIdAccess);
            var inId = ContextExtension.BuildContainsExpression(localizationIdAccess, entityIds);

            MethodInfo where = typeof(Queryable).GetMethods().Where(m => m.Name == "Where").First().MakeGenericMethod(typeof(L));
            return localizations.Where(langEquals).Where(eNameEquals).Where(inFieldNames).Where(inId);
        }
    }
}
