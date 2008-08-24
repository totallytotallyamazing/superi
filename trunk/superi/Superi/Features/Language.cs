using System.Data;
using System.Data.Common;
using Superi.Common;

namespace Superi.Features
{
    public class Language
    {

        #region Private fields
        private int _ID = int.MinValue;
        private string _Name = "";
        private string _Code = "";
        private string _ShortName = "";
        #endregion

        #region Public properties
        public string ShortName
        {
            get { return _ShortName; }
            set { _ShortName = value; }
        }

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public string Code
        {
            get { return _Code; }
            set { _Code = value; }
        }
        #endregion

        #region Constructors
		public Language()
		{

		}

		public Language(DataRow dr)
		{
			if (dr != null) Load(dr);
		}

		public Language(DbDataReader dr)
		{
			//if /*(dr.Read())*/ 
			Load(dr);
		}

        public Language(int ID)
		{
			string sql = "select * from Languages where ID=" + ID;
			DataSet ds = AppData.GetDataSet(sql);
			if (ds != null && ds.Tables.Count>0 && ds.Tables[0].Rows.Count>0)
				Load(ds.Tables[0].Rows[0]);
		}
		#endregion

        #region Public methods
        public bool Load(DbDataReader dr)
        {
            return Load(dr, false);
        }

        public bool Load(DbDataReader dr, bool CloseDr)
        {
            _ID = dr.GetInt32(dr.GetOrdinal("ID"));
            Name = dr["Name"].ToString();
            Code = dr["Code"].ToString();
            ShortName = dr["ShortName"].ToString();
            if (CloseDr)
                dr.Close();
            return true;
        }

        public bool Load(DataRow dr)
        {
            _ID = (int) dr["ID"];
            Name = dr["Name"].ToString();
            Code = dr["Code"].ToString();
            ShortName = dr["ShortName"].ToString();
            return true;
        }

        public bool Save()
        {
            ParameterList pList = new ParameterList();
            pList.Add(new AppDbParameter("id", ID));
            pList.Add(new AppDbParameter("code", Code));
            pList.Add(new AppDbParameter("name", Name));
            pList.Add(new AppDbParameter("shortname", ShortName));

            DbDataReader dr = AppData.ExecStoredProcedure("Languages_AddUpdate", pList);
            if (dr != null && dr.HasRows && dr.Read())
            {
                _ID = int.Parse(dr[0].ToString());
                dr.Close();
            }
            else
                return false;
            return true;
        }


        public bool Remove()
        {
            bool result;
            if (ID > 0)
            {
                string sql = "delete from Languages where id=" + ID;
                result = AppData.ExecNonQuery(sql);
            }
            else result = false;
            return result;
        }
        #endregion
    }
}
