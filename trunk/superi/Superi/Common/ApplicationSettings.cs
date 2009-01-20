using System.Collections;
using System.Data;

namespace Superi.Common
{
    public static class ApplicationSettings
    {
        public static ArrayList Get(string Name)
        {
            ArrayList result = new ArrayList();
            ParameterList parameterList = new ParameterList();
            parameterList.Add(new AppDbParameter("Name", Name));
            DataSet ds = AppData.ExecDataSet("Settings_Get", parameterList);
            if (ds.Tables.Count > 0)
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    result.Add(dr["Value"].ToString());
                }
            return result;
        }

        public static string Get(string Name, int Offset)
        {
            string result = "";
            ParameterList parameterList = new ParameterList();
            parameterList.Add(new AppDbParameter("Name", Name));
            DataSet ds = AppData.ExecDataSet("Settings_Get", parameterList);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows.Count >= Offset + 1)
                result = ds.Tables[0].Rows[Offset]["Value"].ToString();
            return result;
        }

        public static void Add(string Name, string Value)
        {
            ParameterList parameterList = new ParameterList();
            parameterList.Add(new AppDbParameter("Name", Name));
            parameterList.Add(new AppDbParameter("Value", Value));
            AppData.ExecStoredProcedure("Settings_Add", parameterList);
        }

        public static void Replace(string Name, string Value)
        {
            Remove(Name);
            Add(Name, Value);
        }

        public static void Remove(string Name)
        {
            ParameterList parameterList = new ParameterList();
            parameterList.Add(new AppDbParameter("Name", Name));
            AppData.ExecStoredProcedure("Settings_Remove", parameterList);        
        }

        public static void Remove(string Name, string Value)
        {
            ParameterList parameterList = new ParameterList();
            parameterList.Add(new AppDbParameter("Name", Name));
            parameterList.Add(new AppDbParameter("Value", Value));
            AppData.ExecStoredProcedure("Settings_Remove", parameterList);
        }
    }
}
