using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Superi.Common;

namespace Superi.Features
{

	public class NavigationList : List<Navigation>
	{
		public NavigationList(bool GetAll)
		{
			if (GetAll)
			{
				const string SQL = "select * from Navigation where ParentID <= 0 order by SortOrder";
				DbDataReader dr = AppData.ExecQuery(SQL);
				if (dr != null && dr.HasRows)
					Load(dr);
			}
		}

		public NavigationList(bool GetAll, bool NotIncluded)
		{
			if (GetAll)
			{
			    string SQL = NotIncluded
			                     ? "select * from Navigation where ParentID <= 0 order by SortOrder"
			                     : "select * from Navigation where ParentID <= 0 and IncludeInMenu = 1 order by SortOrder";
				DbDataReader dr = AppData.ExecQuery(SQL);
				if (dr != null && dr.HasRows)
					Load(dr);
			}
		}
		
		//public NavigationList(bool Get, bool GetSubItems)
		//{
		//    if (Get)
		//    {
		//        string SQL = "";
		//        if (!GetSubItems)
		//            SQL = "select * from Navigation where ParentID <= 0 order by SortOrder";
		//        else
		//            SQL = "select * from Navigation order by SortOrder";
		//        DbDataReader dr = AppData.ExecQuery(SQL);
		//        if (dr != null && dr.HasRows)
		//            Load(dr);
		//    }
		//}

		public NavigationList(int ParentID)
		{
			string SQL = "select * from Navigation where ParentID = " + ParentID + " order by SortOrder";
		    DbDataReader dr = AppData.ExecQuery(SQL);
		    if (dr != null && dr.HasRows)
		        Load(dr);
		}

		public NavigationList(int ParentID, bool NotIncluded)
		{
			string SQL;
			if(NotIncluded)
				SQL = "select * from Navigation where ParentID = " + ParentID + " order by SortOrder";
			else
				SQL = "select * from Navigation where ParentID = " + ParentID + " and IncludeInMenu=1 order by SortOrder";
			DbDataReader dr = AppData.ExecQuery(SQL);
			if (dr != null && dr.HasRows)
				Load(dr);
		}

		public NavigationList(DataTable dt)
		{
			Load(dt);
		}

		public NavigationList(DbDataReader dr)
		{
			Load(dr);
		}

		public void Load(DataTable dt)
		{
			if (dt.Rows.Count > 0)
				foreach (DataRow row in dt.Rows)
				{
					Add(new Navigation(row));
				}
		}

		public void Load(DbDataReader dr)
		{
			if (dr.HasRows)
				while (dr.Read())
				{
					Add(new Navigation(dr));
				}
			dr.Close();
		}

	}
}
