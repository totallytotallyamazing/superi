using System.Data;
using System.Data.Common;
using Superi.Common;
using Superi.Features;

namespace Superi.Shop
{
    public class Product
    {
        #region Private fields
        private int _ID = int.MinValue;
        private string _Name = "";
        private int _NameTextID = int.MinValue;
        private string _Description = "";
        private int _DescriptionTextID = int.MinValue;
        private string _ShortDescription = "";
        private int _ShortDescriptionTextID = int.MinValue;
        private int _GroupID = int.MinValue;
        private decimal _Price = 0M;
        private string _Picture = "";
        private decimal _Weight = 0M;
        private int typeId = int.MinValue;
        #endregion

        #region Public properties
        public int ID
        {
            get { return _ID; }
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public Resource Names
        {
            get { return new Resource(NameTextID); }
        }

        public int NameTextID
        {
            get { return _NameTextID; }
            set { _NameTextID = value; }
        }

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        public Resource Descriptions
        {
            get { return new Resource(DescriptionTextID); }
        }

        public int DescriptionTextID
        {
            get { return _DescriptionTextID; }
            set { _DescriptionTextID = value; }
        }

        public string ShortDescription
        {
            get { return _ShortDescription; }
            set { _ShortDescription = value; }
        }

        public Resource ShortDescriptions
        {
            get { return new Resource(ShortDescriptionTextID); }
        }

        public int ShortDescriptionTextID
        {
            get { return _ShortDescriptionTextID; }
            set { _ShortDescriptionTextID = value; }
        }

        public int GroupID
        {
            get { return _GroupID; }
            set { _GroupID = value; }
        }

        public decimal Price
        {
            get { return _Price; }
            set { _Price = value; }
        }

        public string Picture
        {
            get { return _Picture; }
            set { _Picture = value; }
        }

        public decimal Weight
        {
            get { return _Weight; }
            set { _Weight = value; }
        }

        public int TypeId
        {
            get { return typeId; }
            set { typeId = value; }
        }
        #endregion

        #region Constructors
        public Product()
		{

		}

		public Product(DataRow dr)
		{
			if (dr != null) Load(dr);
		}

		public Product(DbDataReader dr)
		{
			//if /*(dr.Read())*/ 
			Load(dr);
		}

		public Product(int ID)
		{
		    Load(ID);
            //string sql = "select * from Products where ID=" + ID;
            //DbDataReader dr = AppData.ExecQuery(sql);
            //if (dr != null && dr.Read())
            //    Load(dr, true);
		}
        #endregion

        #region Public methods
        public bool Load(int Id)
        {
            string sql = "select * from Products where ID=" + Id;
            DataSet ds = AppData.GetDataSet(sql);
            if (ds != null && ds.Tables.Count>0 && ds.Tables[0].Rows.Count>0)
                return Load(ds.Tables[0].Rows[0]);
            return false;
        }

        public bool Load(DbDataReader dr)
        {
            return Load(dr, false);
        }

        public bool Load(DbDataReader dr, bool CloseDr)
        {
            _ID = dr.GetInt32(dr.GetOrdinal("ID"));
            Name = dr["Name"].ToString();
            NameTextID = dr.GetInt32(dr.GetOrdinal("NameTextID"));
            ShortDescription = dr["ShortDescription"].ToString();
            ShortDescriptionTextID = dr.GetInt32(dr.GetOrdinal("ShortDescriptionTextID"));
            Description = dr["Description"].ToString();
            DescriptionTextID = dr.GetInt32(dr.GetOrdinal("DescriptionTextID"));
            Picture = dr["Picture"].ToString();
            GroupID = dr.GetInt32(dr.GetOrdinal("GroupID"));
            Price = dr.GetDecimal(dr.GetOrdinal("Price"));
            Weight = dr.GetDecimal(dr.GetOrdinal("Weight"));
            TypeId = dr.GetInt32(dr.GetOrdinal("TypeId"));
            if (CloseDr)
                dr.Close();
            return true;
        }

        public virtual bool Load(DataRow dr)
        {
            _ID = (int)dr["ID"];
            Name = dr["Name"].ToString();
            NameTextID = int.Parse(dr["NameTextID"].ToString());
            ShortDescription = dr["ShortDescription"].ToString();
            ShortDescriptionTextID = int.Parse(dr["ShortDescriptionTextID"].ToString());
            Description = dr["Description"].ToString();
            DescriptionTextID = int.Parse(dr["DescriptionTextID"].ToString());
            Picture = dr["Picture"].ToString();
            GroupID = (int) dr["GroupID"];
            Price = (decimal) dr["Price"];
            Weight = (decimal) dr["Weight"];
            TypeId = (int)dr["TypeId"];
            return true;
        }

        public virtual bool Save()
        {
            ParameterList pList = new ParameterList();
            pList.Add(new AppDbParameter("id", ID));
            pList.Add(new AppDbParameter("shortdescription", ShortDescription));
            pList.Add(new AppDbParameter("shortdescriptiontextid", ShortDescriptionTextID));
            pList.Add(new AppDbParameter("description", Description));
            pList.Add(new AppDbParameter("descriptiontextid", DescriptionTextID));
            pList.Add(new AppDbParameter("name", Name));
            pList.Add(new AppDbParameter("nametextid", NameTextID));
            pList.Add(new AppDbParameter("picture", Picture));
            pList.Add(new AppDbParameter("price", Price));
            pList.Add(new AppDbParameter("groupid", GroupID));
            pList.Add(new AppDbParameter("weight", Weight));
            pList.Add(new AppDbParameter("typeid", TypeId));

            DbDataReader dr = AppData.ExecStoredProcedure("Products_AddUpdate", pList);
            if (dr != null && dr.HasRows && dr.Read())
            {
                _ID = int.Parse(dr[0].ToString());
                dr.Close();
            }
            else
                return false;
            return true;
        }

        public virtual bool Remove()
        {
            bool result;
            if (ID > 0)
            {
                ParameterList pList = new ParameterList();
                pList.Add(new AppDbParameter("id", ID));
                AppData.ExecStoredProcedure("Products_Delete", pList);
                result = true;
            }
            else result = false;
            return result;
        }
        #endregion

    }
}
