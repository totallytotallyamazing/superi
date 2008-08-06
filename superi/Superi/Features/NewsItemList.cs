using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Superi.Common;

namespace Superi.Features
{
	public class NewsItemList : List<NewsItem>
	{
		public NewsItemList(bool GetAll)
		{
			if (GetAll)
			{
				string SQL = "select * from News order by EntryDate DESC";
				DbDataReader dr = AppData.ExecQuery(SQL);
				if (dr != null && dr.HasRows)
					Load(dr);
			}
		}

		public NewsItemList(int Top)
		{
			ParameterList parameterList = new ParameterList();
			parameterList.Add(new AppDbParameter("_start",0));
			parameterList.Add(new AppDbParameter("_count", Top));
			DbDataReader dr = AppData.ExecStoredProcedure("News_GetRange", parameterList);
			if (dr != null && dr.HasRows)
				Load(dr);
		}

		public NewsItemList(int Start, int Count)
		{
			ParameterList parameterList = new ParameterList();
			parameterList.Add(new AppDbParameter("_start", Start));
			parameterList.Add(new AppDbParameter("_count", Count));
			DbDataReader dr = AppData.ExecStoredProcedure("News_GetRange", parameterList);
			if (dr != null && dr.HasRows)
				Load(dr);
		}

		public NewsItemList(DataTable dt)
		{
			Load(dt);
		}

		public NewsItemList(DbDataReader dr)
		{
			Load(dr);
		}

		public NewsItem GetByID(int ID)
		{
			NewsItem result = new NewsItem();
			foreach (NewsItem item in this)
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
					Add(new NewsItem(row));
				}
		}

		public void Load(DbDataReader dr)
		{
			if (dr.HasRows)
				while (dr.Read())
				{
					Add(new NewsItem(dr));
				}
			dr.Close();
		}
	}
}
