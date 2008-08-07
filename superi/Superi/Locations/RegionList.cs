using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Superi.Common;

namespace Superi.Locations
{
    public class RegionList : List<Country>
    {
        public RegionList(bool GetAll)
        {
            if (GetAll)
            {
                DbDataReader dr = AppData.ExecStoredProcedure("Regions_Get", null);
                if (dr != null && dr.HasRows)
                    Load(dr);
            }
        }

        public RegionList(int CountryId)
        {
            ParameterList pList = new ParameterList();
            pList.Add(new AppDbParameter("countryid", CountryId));
            DbDataReader dr = AppData.ExecStoredProcedure("Regions_Get", pList);
            if (dr != null && dr.HasRows)
                Load(dr);
        }

        public RegionList(DataTable dt)
        {
            Load(dt);
        }

        public RegionList(DbDataReader dr)
        {
            Load(dr);
        }

        public void Load(DataTable dt)
        {
            if (dt.Rows.Count > 0)
                foreach (DataRow row in dt.Rows)
                {
                    Add(new Country(row));
                }
        }

        public void Load(DbDataReader dr)
        {
            if (dr.HasRows)
                while (dr.Read())
                {
                    Add(new Country(dr));
                }
            dr.Close();
        }
    }
}
