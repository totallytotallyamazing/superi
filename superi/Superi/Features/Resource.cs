using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Superi.Common;

namespace Superi.Features
{
    public class Resource
    {
        #region Private fields
        private int _TextID = int.MinValue;
        private Dictionary<string, string> _Items = new Dictionary<string, string>();
        private string _Alias = "";
        #endregion

        #region Public properties
        public int TextID
        {
            get { return _TextID; }
          //  set { _TextID = value; }
        }

        public Dictionary<string, string> Items
        {
            get { return _Items; }
            set { _Items = value; }
        }

        public string this[string index]
        {
            get { return _Items[index]; }
            set { _Items[index] = value; }
        }

        public string Alias
        {
            get { return _Alias; }
            set { _Alias = value; }
        }
        #endregion

        #region Constructors
        public Resource()
        { 
            
        }

        public Resource(int TextID)
        {
            string sql = "select * from Resources where TextID=" + TextID;
            DataSet ds = AppData.GetDataSet(sql);
            if (ds != null && ds.Tables.Count>0)
                Load(ds.Tables[0]);
        }

        public Resource(DbDataReader dr)
        {
            Load(dr);
        }

        public Resource(DataTable dt)
        {
            Load(dt);
        }

        #endregion

        #region Public methods
        public bool Load(DbDataReader dr)
        {
            return Load(dr, false);
        }

        public bool Load(DbDataReader dr, bool CloseDr)
        {
            while (dr.Read())
            {
                Alias = dr["Alias"].ToString();
                _TextID = dr.GetInt32(dr.GetOrdinal("TextID"));
                string lang = dr["Language"].ToString();
                string value = dr["Value"].ToString();
                Items.Add(lang, value);
            }
            if (CloseDr)
                dr.Close();
            return true;
        }

        public bool Load(DataTable dt)
        {
            foreach(DataRow dr in dt.Rows)
            {
                Alias = dr["Alias"].ToString();
                _TextID = (int)dr["TextID"];
                string lang = dr["Language"].ToString();
                string value = dr["Value"].ToString();
                Items.Add(lang, value);
            }
            return true;
        }

        public int Save()
        {
            string valuepaies = ParseString(Items);
            if (!string.IsNullOrEmpty(valuepaies))
            {
                ParameterList pList = new ParameterList();
                pList.Add(new AppDbParameter("textid", TextID));
                pList.Add(new AppDbParameter("valuepairs", valuepaies));
                pList.Add(new AppDbParameter("alias", Alias));

                DbDataReader dr = AppData.ExecStoredProcedure("Resources_AddUpdate", pList);
                if (dr != null && dr.HasRows && dr.Read())
                {
                    _TextID = int.Parse(dr[0].ToString());
                    dr.Close();
                }
                else
                    return int.MinValue;
            }
            return _TextID;
        }

        public bool Remove()
        {
            bool result;
            if (TextID > 0)
            {
                string sql = "delete from Resources where textid=" + TextID;
                result = AppData.ExecNonQuery(sql);
            }
            else result = false;
            return result;
        }
        #endregion

        #region Private methods
        private static string ParseString(IDictionary<string, string> Items)
        {
            string result = "";
            foreach (string key in Items.Keys)
            {
                result += key + "%=%" + Items[key] + "%;%";
            }
            return result;
        }
        #endregion
    }
}
