using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data.EntityClient;

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

        public static void ClaenupProductImages(this ZamovStorage context, int productId)
        {
            EntityParameter parameter = new EntityParameter();
            parameter.ParameterName = "productId";
            parameter.IsNullable = false;
            parameter.Value = productId;
            parameter.DbType = System.Data.DbType.Int32;
            ExecuteNonQuery(context, "ZamovStorage.ProductImages_Cleanup", parameter);
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
    }
}
