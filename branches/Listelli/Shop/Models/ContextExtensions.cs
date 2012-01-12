using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using System.Data.Common;
using System.Data.EntityClient;
using System.Collections;
using System.Data;
using Superi.Web.Mvc.Localization;

namespace Shop.Models
{
    public static class ContextExtension
    {
        public static Content GetContent(this ContentStorage context, string contentUrl)
        {
            
            var result = context.Contents.Where(sc => sc.Name == contentUrl).Localize((c, l) => new { Content = c, Localizations = l }, context.ContentLocalResource, null ).FirstOrDefault();
            result.Content.UpdateValues(result.Localizations);
            return result.Content;
        }

        public static Expression<Func<TElement, bool>> BuildContainsExpression<TElement, TValue>(
            Expression<Func<TElement, TValue>> valueSelector, IEnumerable<TValue> values)
        {
            if (null == valueSelector) { throw new ArgumentNullException("valueSelector"); }
            if (null == values) { throw new ArgumentNullException("values"); }
            ParameterExpression p = valueSelector.Parameters.Single();
            if (!values.Any())
            {
                return e => false;
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
