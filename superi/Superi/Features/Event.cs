using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using Superi.Common;

namespace Superi.Features
{
    public class Event
    {
        #region Private fields
        private int id = int.MinValue;
        private string name = "";
        private int nameTextId = int.MinValue;
        private int typeId = int.MinValue;
        private int countryId = int.MinValue;
        private int regionId = int.MinValue;
        private string shortDescription = "";
        private int shortDescriptionTextId = int.MinValue;
        private string description = "";
        private int descriptionTextId = int.MinValue;
        private DateTime? startDate = null;
        private DateTime? endDate = null;
        #endregion

        #region Pulblic properties
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

        public int TypeId
        {
            get { return typeId; }
            set { typeId = value; }
        }

        public int CountryId
        {
            get { return countryId; }
            set { countryId = value; }
        }

        public int RegionId
        {
            get { return regionId; }
            set { regionId = value; }
        }

        public string ShortDescription
        {
            get { return shortDescription; }
            set { shortDescription = value; }
        }

        public int ShortDescriptionTextId
        {
            get { return shortDescriptionTextId; }
            set { shortDescriptionTextId = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public int DescriptionTextId
        {
            get { return descriptionTextId; }
            set { descriptionTextId = value; }
        }

        public DateTime? StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        public DateTime? EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }
        #endregion

        #region Constructors
		public Event()
		{

		}

		public Event(DataRow dr)
		{
			if (dr != null) Load(dr);
		}

		public Event(DbDataReader dr)
		{
			//if /*(dr.Read())*/ 
			Load(dr);
		}

		public Event(int ID)
		{
			ParameterList pList = new ParameterList();
            pList.Add(new AppDbParameter("id", ID));
            DbDataReader dr = AppData.ExecStoredProcedure("Events_Get", pList);
			if (dr != null && dr.Read())
				Load(dr, true);
		}

        public Event(string Name)
		{
            ParameterList pList = new ParameterList();
            pList.Add(new AppDbParameter("name", Name));
            DbDataReader dr = AppData.ExecStoredProcedure("Events_Get", pList);
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
            TypeId = dr.GetInt32(dr.GetOrdinal("Type"));
            CountryId = dr.GetInt32(dr.GetOrdinal("Country"));
            RegionId = dr.GetInt32(dr.GetOrdinal("Region"));
            ShortDescription = dr["ShortDescription"].ToString();
            ShortDescriptionTextId = dr.GetInt32(dr.GetOrdinal("ShortDescriptionTextID"));
            Description = dr["Description"].ToString();
            DescriptionTextId = dr.GetInt32(dr.GetOrdinal("DescriptionTextID"));
            if (!dr.IsDBNull(dr.GetOrdinal("StartDate")))
                StartDate = dr.GetDateTime(dr.GetOrdinal("StartDate"));
            if (!dr.IsDBNull(dr.GetOrdinal("EndDate")))
                EndDate = dr.GetDateTime(dr.GetOrdinal("EndDate"));

            if (CloseDr)
                dr.Close();
            return true;
        }

        public bool Load(DataRow dr)
        {
            id = (int)dr["ID"];
            Name = dr["Name"].ToString();
            NameTextId = int.Parse(dr["NameTextId"].ToString());
            TypeId = (int) dr["Type"];
            CountryId = (int)dr["Country"];
            RegionId = (int) dr["Region"];
            ShortDescription = dr["ShortDescription"].ToString();
            ShortDescriptionTextId = int.Parse(dr["ShortDescriptionTextID"].ToString());
            Description = dr["Description"].ToString();
            DescriptionTextId = int.Parse(dr["DescriptionTextID"].ToString());
            if (!dr.IsNull("StartDate"))
                StartDate = DateTime.Parse(dr["StartDate"].ToString());
            if (!dr.IsNull("EndDate"))
                EndDate = DateTime.Parse(dr["EndDate"].ToString());
            return true;
        }

        public bool Save()
        {
            ParameterList pList = new ParameterList();
            pList.Add(new AppDbParameter("id", id));
            pList.Add(new AppDbParameter("shortdescription", ShortDescription));
            pList.Add(new AppDbParameter("shortdescriptiontextid", ShortDescriptionTextId));
            pList.Add(new AppDbParameter("description", Description));
            pList.Add(new AppDbParameter("descriptiontextid", DescriptionTextId));
            pList.Add(new AppDbParameter("name", Name));
            pList.Add(new AppDbParameter("nametextid", NameTextId));
            pList.Add(new AppDbParameter("type", TypeId));
            pList.Add(new AppDbParameter("country", CountryId));
            pList.Add(new AppDbParameter("region",RegionId));
            pList.Add(new AppDbParameter("startdate",StartDate));
            pList.Add(new AppDbParameter("enddate", EndDate));

            DbDataReader dr = AppData.ExecStoredProcedure("Events_AddUpdate", pList);
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
            bool result = true;
            if (id > 0)
            {
                ParameterList pList = new ParameterList();
                pList.Add(new AppDbParameter("id", id));
                AppData.ExecStoredProcedure("Events_Delete", pList);
            }
            else result = false;
            return result;
        }
        #endregion

    }
}
