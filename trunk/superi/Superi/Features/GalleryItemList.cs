using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Superi.Common;

namespace Superi.Features
{
	public class GalleryItemList : List<GalleryItem>
	{
		public GalleryItemList(bool GetAll)
		{
			if (GetAll)
			{
				string SQL = "select * from GalleryItems";
				DbDataReader dr = AppData.ExecQuery(SQL);
				if (dr != null && dr.HasRows)
					Load(dr);
			}
		}

		public GalleryItemList(int GalleryID)
		{
				string SQL = "select * from GalleryItems where GalleryID = " + GalleryID;
				DbDataReader dr = AppData.ExecQuery(SQL);
				if (dr != null && dr.HasRows)
					Load(dr);
		}

		public GalleryItemList(DataTable dt)
		{
			Load(dt);
		}

		public GalleryItemList(DbDataReader dr)
		{
			Load(dr);
		}

		public GalleryItem GetByID(int ID)
		{
			GalleryItem result = new GalleryItem();
			foreach (GalleryItem item in this)
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
					Add(new GalleryItem(row));
				}
		}

		public void Load(DbDataReader dr)
		{
			if (dr.HasRows)
				while (dr.Read())
				{
					Add(new GalleryItem(dr));
				}
			dr.Close();
		}

	}
}
