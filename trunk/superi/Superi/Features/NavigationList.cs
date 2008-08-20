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
			    DbDataReader dr = GetNavigationList(null, null);
				if (dr != null && dr.HasRows)
					Load(dr);
			}
		}

		public NavigationList(bool GetAll, bool NotIncluded)
		{
			if (GetAll)
			{
			    bool? included = null;
                if(!NotIncluded)
                    included = true;
                DbDataReader dr = GetNavigationList(null, included);
                
                if (dr != null && dr.HasRows)
                    Load(dr);
			}
		}

        private DbDataReader GetNavigationList(int? ParentId, bool? Included)
        {
            ParameterList pList = new ParameterList();
            if(ParentId!=null)
                pList.Add(new AppDbParameter("parentID", ParentId));
            if(Included!=null)
                pList.Add(new AppDbParameter("included", Included));
            DbDataReader dr = AppData.ExecStoredProcedure("Navigation_Get", pList);
            return dr;
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
            DbDataReader dr = GetNavigationList(ParentID, null);
            if (dr != null && dr.HasRows)
                Load(dr);
		}

		public NavigationList(int ParentID, bool NotIncluded)
		{
            bool? included = null;
            if (!NotIncluded)
                included = true;
            DbDataReader dr = GetNavigationList(ParentID, included);

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
