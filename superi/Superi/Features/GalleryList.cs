using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Superi.Common;

namespace Superi.Features
{
	public class GalleryList : List<Gallery>
	{
		public GalleryList(bool GetAll)
		{
			if (GetAll)
			{
				string SQL = "select * from GalleryItems order by EntryDate DESC";
				DbDataReader dr = AppData.ExecQuery(SQL);
				if (dr != null && dr.HasRows)
					Load(dr);
			}
		}

		//public GalleryItemList(int Top)
		//{
		//    ParameterList parameterList = new ParameterList();
		//    parameterList.Add(new AppDbParameter("_start",0));
		//    parameterList.Add(new AppDbParameter("_count", Top));
		//    DbDataReader dr = AppData.ExecStoredProcedure("News_GetRange", parameterList);
		//    if (dr != null && dr.HasRows)
		//        Load(dr);
		//}

		//public GalleryItemList(int Start, int Count)
		//{
		//    ParameterList parameterList = new ParameterList();
		//    parameterList.Add(new AppDbParameter("_start", Start));
		//    parameterList.Add(new AppDbParameter("_count", Count));
		//    DbDataReader dr = AppData.ExecStoredProcedure("News_GetRange", parameterList);
		//    if (dr != null && dr.HasRows)
		//        Load(dr);
		//}

		public GalleryList(DataTable dt)
		{
			Load(dt);
		}

		public GalleryList(DbDataReader dr)
		{
			Load(dr);
		}

		public Gallery GetByID(int ID)
		{
			Gallery result = new Gallery();
			foreach (Gallery item in this)
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
					Add(new Gallery(row));
				}
		}

		public void Load(DbDataReader dr)
		{
			if (dr.HasRows)
				while (dr.Read())
				{
					Add(new Gallery(dr));
				}
			dr.Close();
		}

	}
}
