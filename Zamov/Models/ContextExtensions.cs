using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data.EntityClient;
using System.Data;
using System.Data.Objects;

namespace Zamov.Models
{
    public static class ContextExtensions
    {
        private static void ExecuteNonQuery(ZamovStorage context, string storedProcedureName, params EntityParameter[] parameters)
        {
            bool closeConnection = false;
            DbCommand command = context.Connection.CreateCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = storedProcedureName;
            command.Parameters.AddRange(parameters);
            if (context.Connection.State != System.Data.ConnectionState.Open)
            {
                context.Connection.Open();
                closeConnection = true;
            }
            command.ExecuteNonQuery();
            if (closeConnection)
                context.Connection.Close();
        }

        private static DbDataReader ExecuteReader(ZamovStorage context, string storedProcedureName, params EntityParameter[] parameters)
        {
            DbCommand command = context.Connection.CreateCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = storedProcedureName;
            command.Parameters.AddRange(parameters);
            if (context.Connection.State != System.Data.ConnectionState.Open)
                context.Connection.Open();
            return command.ExecuteReader(CommandBehavior.SequentialAccess);
        }

        public static IQueryable<CategoryPresentation> GetLocalizedCategories(this ZamovStorage context, string language)
        {
            IQueryable<CategoryPresentation> result = (from category in context.Categories.Include("Parent").Include("Dealers").Include("Categories")
                                                        join name in context.Translations on category.Id equals name.ItemId
                                                        where category.Enabled
                                                        && name.Language == language
                                                        && name.TranslationItemTypeId == (int)ItemTypes.Category
                                                        select new CategoryPresentation
                                                        {
                                                            Id = category.Id,
                                                            Name = name.Text
                                                        });
            return result;
        }

        public static void RemoveDealer(this ZamovStorage context, int id)
        {
            EntityParameter parameter = new EntityParameter();
            parameter.ParameterName = "dealerId";
            parameter.IsNullable = false;
            parameter.Value = id;
            parameter.DbType = System.Data.DbType.Int32;
            ExecuteNonQuery(context, "ZamovStorage.deleteDealer", parameter);
        }

        public static void CleanupProductImages(this ZamovStorage context, int productId)
        {
            EntityParameter parameter = new EntityParameter();
            parameter.ParameterName = "productId";
            parameter.IsNullable = false;
            parameter.Value = productId;
            parameter.DbType = System.Data.DbType.Int32;
            ExecuteNonQuery(context, "ZamovStorage.ProductImages_Cleanup", parameter);
        }
        
        public static void CleanupCategoryImages(this ZamovStorage context, int categoryId)
        {
            EntityParameter parameter = new EntityParameter();
            parameter.ParameterName = "categoryId";
            parameter.IsNullable = false;
            parameter.Value = categoryId;
            parameter.DbType = System.Data.DbType.Int32;
            ExecuteNonQuery(context, "ZamovStorage.CategoryImages_Cleanup", parameter);
        }

        public static void UpdateProducts(this ZamovStorage context, string updatesXml)
        {
            EntityParameter parameter = new EntityParameter();
            parameter.ParameterName = "updatesXml";
            parameter.IsNullable = false;
            parameter.Value = updatesXml;
            parameter.DbType = System.Data.DbType.String;
            ExecuteNonQuery(context, "ZamovStorage.UpdateProducts", parameter);
        }

        public static void InsertImportedProducts(this ZamovStorage context, string updatesXml, int dealerId)
        {
            EntityParameter dealerIdParameter = new EntityParameter();
            dealerIdParameter.ParameterName = "dealerId";
            dealerIdParameter.IsNullable = false;
            dealerIdParameter.Value = dealerId;
            dealerIdParameter.DbType = System.Data.DbType.Int32;

            EntityParameter updatesXmlParameter = new EntityParameter();
            updatesXmlParameter.ParameterName = "updatesXml";
            updatesXmlParameter.IsNullable = false;
            updatesXmlParameter.Value = updatesXml;
            updatesXmlParameter.DbType = System.Data.DbType.String;

            ExecuteNonQuery(context, "ZamovStorage.InsertImportedProducts", dealerIdParameter, updatesXmlParameter);
        }

        public static void UpdateImportedProducts(this ZamovStorage context, string updatesXml)
        {
            EntityParameter updatesXmlParameter = new EntityParameter();
            updatesXmlParameter.ParameterName = "updatesXml";
            updatesXmlParameter.IsNullable = false;
            updatesXmlParameter.Value = updatesXml;
            updatesXmlParameter.DbType = System.Data.DbType.String;

            ExecuteNonQuery(context, "ZamovStorage.UpdateImportedProducts", updatesXmlParameter);
        }

        public static void ExpireOrders(this ZamovStorage context)
        {
            ExecuteNonQuery(context, "ZamovStorage.ExpireOrders");
        }

        public static bool MatchesPath(this Group g, string[] path)
        {
            bool result = false;
            if (path != null && path.Length == 1 && g.Name == path[0])
                result = true;
            else
            {
                g.ParentReference.Load();
                if (path != null && path.Length > 1 && g.Parent != null)
                    result = g.Parent.MatchesPath(path.Take(path.Length - 1).ToArray());
            }
            return result;
        }

        public static IOrderedEnumerable<TSource> OrderByWithDirection<TSource, TKey>
            (this IEnumerable<TSource> source, 
            Func<TSource, TKey> keySelector, 
            bool descending) 
        { 
            return descending ? source.OrderByDescending(keySelector) 
                              : source.OrderBy(keySelector); 
        }
        /*
        public static IOrderedQueryable<TSource> OrderByWithDirection<TSource, TKey>
            (this IQueryable<TSource> source, 
            Expression<Func<TSource, TKey>> 
            keySelector, bool descending) 
        { 
            return descending ? source.OrderByDescending(keySelector) 
                              : source.OrderBy(keySelector); 
        }*/
    }
}
