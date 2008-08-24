using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Superi.Common;

namespace Superi.Features
{
    public class ArticleList:List<Article>
    {
        public ArticleList(bool GetAll)
		{
			if (GetAll)
			{
				string SQL = "select * from Articles order by EntryDate DESC";
                DataSet ds = AppData.GetDataSet(SQL);
                if (ds != null && ds.Tables.Count > 0)
                    Load(ds.Tables[0]);
			}
		}

        public ArticleList(int ScopeID)
        {
            string SQL = "select * from Articles where ScopeID = " + ScopeID + " order by EntryDate DESC";
            DataSet ds = AppData.GetDataSet(SQL);
            if (ds != null && ds.Tables.Count > 0)
                Load(ds.Tables[0]);
        }

		public ArticleList(DataTable dt)
		{
			Load(dt);
		}

        public ArticleList(DbDataReader dr)
		{
			Load(dr);
		}

        public Article GetByID(int ID)
		{
            Article result = new Article();
            foreach (Article item in this)
			{
				if (item.ID == ID)
				{
					result = item;
					break;
				}
			}
			return result;

		}

		public void Load(DataTable dt)
		{
			if (dt.Rows.Count > 0)
				foreach (DataRow row in dt.Rows)
				{
					Add(new Article(row));
				}
		}

		public void Load(DbDataReader dr)
		{
			if (dr.HasRows)
				while (dr.Read())
				{
                    Add(new Article(dr));
				}
			dr.Close();
		}

    }
}
