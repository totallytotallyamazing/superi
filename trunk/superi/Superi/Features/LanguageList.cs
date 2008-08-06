using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Superi.Common;

namespace Superi.Features
{
    public class LanguageList : List<Language>
    {
        public LanguageList(bool GetAll)
		{
			if (GetAll)
			{
				string SQL = "select * from Languages";
				DbDataReader dr = AppData.ExecQuery(SQL);
				if (dr != null && dr.HasRows)
					Load(dr);
			}
		}

		public LanguageList(DataTable dt)
		{
			Load(dt);
		}

        public LanguageList(DbDataReader dr)
		{
			Load(dr);
		}

		public void Load(DataTable dt)
		{
			if (dt.Rows.Count > 0)
				foreach (DataRow row in dt.Rows)
				{
					Add(new Language(row));
				}
		}

		public void Load(DbDataReader dr)
		{
			if (dr.HasRows)
				while (dr.Read())
				{
					Add(new Language(dr));
				}
			dr.Close();
		}
    }
}
