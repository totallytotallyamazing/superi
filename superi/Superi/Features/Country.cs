using System.Data;
using System.Data.Common;
using Superi.Common;

namespace Superi.Features
{
    public class Country
    {
        #region Private fields
        private int id = int.MinValue;
        private string name = "";
        private int nameTextId = int.MinValue;
        private string isoCode2 = "";
        private string isoCode3 = "";
        #endregion

        #region Public properties
        public int Id
        {
            get { return id; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int NameTextId
        {
            get { return nameTextId; }
            set { nameTextId = value; }
        }

        public string IsoCode2
        {
            get { return isoCode2; }
            set { isoCode2 = value; }
        }

        public string IsoCode3
        {
            get { return isoCode3; }
            set { isoCode3 = value; }
        }
        #endregion

        #region Constructors
		public Country()
		{

		}

		public Country(DataRow dr)
		{
			if (dr != null) Load(dr);
		}

		public Country(DbDataReader dr)
		{
			//if /*(dr.Read())*/ 
			Load(dr);
		}

        public Country(int ID)
		{

            ParameterList pList = new ParameterList();
            pList.Add(new AppDbParameter("id", ID));
			DbDataReader dr = AppData.ExecStoredProcedure("Countries_Get", pList);
			if (dr != null && dr.Read())
				Load(dr, true);
		}
		#endregion

        		#region Public methods
		public bool Load(DbDataReader dr)
		{
			return Load(dr, false);
		}

		public bool Load(DbDataReader dr, bool CloseDr)
		{
			id = dr.GetInt32(dr.GetOrdinal("ID"));
			Name = dr["Name"].ToString();
		    NameTextId = dr.GetInt32(dr.GetOrdinal("NameTextId"));
			IsoCode2 = dr["IsoCode2"].ToString();
            IsoCode3 = dr["IsoCode3"].ToString();

			if (CloseDr)
				dr.Close();
			return true;
		}

		public bool Load(DataRow dr)
		{
			id = (int)dr["ID"];
			Name = dr["Name"].ToString();
		    NameTextId = (int) dr["NameTextId"];
		    IsoCode2 = dr["IsoCode2"].ToString();
            IsoCode3 = dr["IsoCode3"].ToString();

			return true;
		}

		public bool Save()
		{
			ParameterList pList = new ParameterList();
			pList.Add(new AppDbParameter("id", id));
			pList.Add(new AppDbParameter("name", Name));
			pList.Add(new AppDbParameter("nametextid", NameTextId));
			pList.Add(new AppDbParameter("isocode2", IsoCode2));
            pList.Add(new AppDbParameter("isocode3", IsoCode3));

			DbDataReader dr = AppData.ExecStoredProcedure("Countries_AddUpdate", pList);
			if (dr != null && dr.HasRows && dr.Read())
			{
				id = int.Parse(dr[0].ToString());
				dr.Close();
			}
			else
				return false;
			return true;
		}


		public bool Remove()
		{
			bool result;
			if (id > 0)
			{
                ParameterList pList = new ParameterList();
                pList.Add(new AppDbParameter("id", id));
                AppData.ExecStoredProcedure("Countries_Delete", pList);
			    result = true;
            }
			else result = false;
			return result;
		}
		#endregion

    }
}
