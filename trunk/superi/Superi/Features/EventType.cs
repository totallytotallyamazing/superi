using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using Superi.Common;

namespace Superi.Features
{
    public class EventType
    {
        #region Private fields
        private int id = int.MinValue;
        private string name = "";
        private string nameTextId = int.MinValue;
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

        public string NameTextId
        {
            get { return nameTextId; }
            set { nameTextId = value; }
        }
        #endregion

        #region Constructors
        public EventType()
        {

        }

        public EventType(DataRow dr)
        {
            if (dr != null) Load(dr);
        }

        public EventType(DbDataReader dr)
        {
            //if /*(dr.Read())*/ 
            Load(dr);
        }

        public EventType(int ID)
        {

            ParameterList pList = new ParameterList();
            pList.Add(new AppDbParameter("id", ID));
            DbDataReader dr = AppData.ExecStoredProcedure("EventTypes_Get", pList);
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

            if (CloseDr)
                dr.Close();
            return true;
        }

        public bool Load(DataRow dr)
        {
            id = (int)dr["ID"];
            Name = dr["Name"].ToString();
            NameTextId = (int) dr["NameTextId"];

            return true;
        }

        public bool Save()
        {
            ParameterList pList = new ParameterList();
            pList.Add(new AppDbParameter("id", id));
            pList.Add(new AppDbParameter("name", Name));
            pList.Add(new AppDbParameter("nametextid", NameTextId));

            DbDataReader dr = AppData.ExecStoredProcedure("EventTypes_AddUpdate", pList);
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
                AppData.ExecStoredProcedure("EventTypes_Delete", pList);
                result = true;
            }
            else result = false;
            return result;
        }
        #endregion

    }
}
