using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Superi.Common;

namespace Superi.Features
{
    public class FAQList:List<FAQ>
    {
		public FAQList(bool GetAll)
		{
			if (GetAll)
			{
				DbDataReader dr = AppData.ExecStoredProcedure("FAQ_Get", null);
				if (dr != null && dr.HasRows)
					Load(dr);
			}
		}

		public FAQList(int GroupId)
		{
            ParameterList pList = new ParameterList();
		    pList.Add(new AppDbParameter("groupid", GroupId));
            DbDataReader dr = AppData.ExecStoredProcedure("FAQ_Get", pList);
            if (dr != null && dr.HasRows)
                Load(dr);
        }

		public FAQList(DataTable dt)
		{
			Load(dt);
		}

        public FAQList(DbDataReader dr)
		{
			Load(dr);
		}

		public void Load(DataTable dt)
		{
			if (dt.Rows.Count > 0)
				foreach (DataRow row in dt.Rows)
				{
					Add(new FAQ(row));
				}
		}

		public void Load(DbDataReader dr)
		{
			if (dr.HasRows)
				while (dr.Read())
				{
					Add(new FAQ(dr));
				}
			dr.Close();
		}
    }
}
