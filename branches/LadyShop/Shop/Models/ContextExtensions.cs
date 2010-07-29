using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using System.Data.Common;
using System.Data.EntityClient;
using System.Collections;
using System.Data;
using System.Data.Objects.DataClasses;

namespace Shop.Models
{
    public static class ContextExtension
    {
        public static Content GetContent(this ContentStorage context, string contentUrl)
        {
            return context.Contents.Where(sc => sc.Name == contentUrl).Select(sc => sc).FirstOrDefault();
        }

        public static Content GetContent(this ContentStorage context, string contentName, string Culture)
        {
            return context.Contents.Where(sc => sc.Name == contentName && sc.Language == Culture).Select(sc => sc).FirstOrDefault();
        }

        public static void UpdateContent(this ContentStorage context, string contentUrl, string text, string title, string keywords, string description)
        {
            Content content = context.Contents.Where(sc => sc.Name == contentUrl).Select(sc => sc).First();
            content.Text = text;
            content.Title = title;
            content.Keywords = keywords;
            content.Description = description;
            context.SaveChanges();
        }

        public static void UpdateContent(this ContentStorage context, string contentName, string language, string text, string title, string keywords, string description)
        {
            Content content = context.Contents.Where(sc => sc.Name == contentName && sc.Language == language).Select(sc => sc).First();
            content.Text = text;
            content.Title = title;
            content.Keywords = keywords;
            content.Description = description;
            context.SaveChanges();
        }

        public static Expression<Func<TElement, bool>> BuildContainsExpression<TElement, TValue>(
            Expression<Func<TElement, TValue>> valueSelector, IEnumerable<TValue> values) where TElement:EntityObject
        {
            if (null == valueSelector) { throw new ArgumentNullException("valueSelector"); }
            if (null == values) { throw new ArgumentNullException("values"); }
            ParameterExpression p = valueSelector.Parameters.Single();
            if (!values.Any())
            {
                return result => false;
            }
            var equals = values.Select(value => (Expression)Expression.Equal(valueSelector.Body, Expression.Constant(value, typeof(TValue))));
            var body = equals.Aggregate<Expression>((accumulate, equal) => Expression.Or(accumulate, equal));
            return Expression.Lambda<Func<TElement, bool>>(body, p);
        }

        public static int[] GetSearchResults(this ShopStorage context, string searchString)
        {
            int[] result = null;

            EntityCommand command = (EntityCommand)context.Connection.CreateCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "ShopStorage.searchProducts";
            EntityParameter param = new EntityParameter("searchString", System.Data.DbType.String);
            param.Value = searchString;
            command.Parameters.Add(param);

            bool closeConnection = false;
            if (context.Connection.State != System.Data.ConnectionState.Open)
            {
                context.Connection.Open();
                closeConnection = true;
            }
            using (DbDataReader reader = command.ExecuteReader(CommandBehavior.SequentialAccess))
            {
                ArrayList items = new ArrayList();
                while (reader.Read())
                {
                    items.Add(reader[0]);
                }
                result = (int[])items.ToArray(typeof(int));
            }
            if (closeConnection)
                context.Connection.Close();
            return result;
        }
    }
}
