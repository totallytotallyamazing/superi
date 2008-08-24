using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Superi.Common;

namespace Superi.Features
{
    public class ArticleScopeList : List<ArticleScope>
    {
        public ArticleScopeList(bool GetAll)
		{
			if (GetAll)
			{
                string SQL = "select * from ArticleScopes where ParentID<=0";
                DataSet ds = AppData.GetDataSet(SQL);
                if (ds != null && ds.Tables.Count > 0)
                    Load(ds.Tables[0]);
			}
		}

        public ArticleScopeList(int ParentID)
        {
            string SQL = "select * from ArticleScopes where ParentID = " + ParentID;
            DataSet ds = AppData.GetDataSet(SQL);
            if (ds != null && ds.Tables.Count > 0)
                Load(ds.Tables[0]);
        }

		public ArticleScopeList(DataTable dt)
		{
			Load(dt);
		}

        public ArticleScopeList(DbDataReader dr)
		{
			Load(dr);
		}

		public void Load(DataTable dt)
		{
			if (dt.Rows.Count > 0)
				foreach (DataRow row in dt.Rows)
				{
					Add(new ArticleScope(row));
				}
		}

		public void Load(DbDataReader dr)
		{
			if (dr.HasRows)
				while (dr.Read())
				{
                    Add(new ArticleScope(dr));
				}
			dr.Close();
		}

        public void Remove()
        {
            foreach (ArticleScope scope in this)
            {
                scope.Remove();
            }
        }

    }
}
