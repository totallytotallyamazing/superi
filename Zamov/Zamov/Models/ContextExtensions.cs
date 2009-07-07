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
        public static void ClaenupProductImages(this ZamovStorage context, int productId)
        {
            bool closeConnection = false;
            DbCommand command = context.Connection.CreateCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "ZamovStorage.ProductImages_Cleanup";
            EntityParameter parameter = new EntityParameter();
            parameter.ParameterName = "productId";
            parameter.IsNullable = false;
            parameter.Value = productId;
            parameter.DbType = System.Data.DbType.Int32;
            command.Parameters.Add(parameter);
            if (context.Connection.State != System.Data.ConnectionState.Open)
            {
                context.Connection.Open();
                closeConnection = true;
            }
            command.ExecuteNonQuery();
            if (closeConnection)
                context.Connection.Close();
        }
    }
}
