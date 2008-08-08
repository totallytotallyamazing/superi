using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Superi.Common;

namespace Superi.Features
{
    public class EventList : List<Event>
    {
        public EventList(bool GetAll)
        {
            if (GetAll)
            {
                DbDataReader dr = AppData.ExecStoredProcedure("Events_Get", null);
                if (dr != null && dr.HasRows)
                    Load(dr);
            }
        }

        public EventList(int? TypeId, int? CountryId, int? RegionId, DateTime? StartDateFrom, DateTime? StartDateTo, DateTime? EndDateFrom, DateTime? EndDateTo)
        {
            ParameterList pList = new ParameterList();
            if (TypeId != null)
                pList.Add(new AppDbParameter("type", TypeId));
            if (CountryId != null)
                pList.Add(new AppDbParameter("country", CountryId));
            if (RegionId != null)
                pList.Add(new AppDbParameter("region", RegionId));
            if (StartDateFrom != null)
                pList.Add(new AppDbParameter("startdatefrom", StartDateFrom));
            if (StartDateTo != null)
                pList.Add(new AppDbParameter("startdateto", StartDateTo));
            if (EndDateFrom != null)
                pList.Add(new AppDbParameter("enddatefrom", EndDateFrom));
            if (EndDateTo != null)
                pList.Add(new AppDbParameter("enddateto", EndDateTo));

            DbDataReader dr = AppData.ExecStoredProcedure("Events_Get", null);
            if (dr != null && dr.HasRows)
                Load(dr);
        }

        public EventList(DataTable dt)
        {
            Load(dt);
        }

        public EventList(DbDataReader dr)
        {
            Load(dr);
        }

        public void Load(DataTable dt)
        {
            if (dt.Rows.Count > 0)
                foreach (DataRow row in dt.Rows)
                {
                    Add(new Event(row));
                }
        }

        public void Load(DbDataReader dr)
        {
            if (dr.HasRows)
                while (dr.Read())
                {
                    Add(new Event(dr));
                }
            dr.Close();
        }

    }
}
