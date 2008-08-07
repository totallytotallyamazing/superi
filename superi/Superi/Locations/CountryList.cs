using System;
using System.Collections.Generic;
using System.Text;
using Superi.Common;

namespace Superi.Features
{
    public class CountryList
    {
        public CountryList(bool GetAll)
		{
			if (GetAll)
			{
                DbDataReader dr = AppData.ExecStoredProcedure("Countries_Get");
				if (dr != null && dr.HasRows)
					Load(dr);
			}
		}

		public CountryList(DataTable dt)
		{
			Load(dt);
		}

        public CountryList(DbDataReader dr)
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
