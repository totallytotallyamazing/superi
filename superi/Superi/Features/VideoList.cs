using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Superi.Common;

namespace Superi.Features
{
	public class VideoList : List<Video>
	{
		public VideoList(bool GetAll)
		{
			if (GetAll)
			{
				string SQL = "select * from Videos";
				DbDataReader dr = AppData.ExecQuery(SQL);
				if (dr != null && dr.HasRows)
					Load(dr);
			}
		}

		//public VideoList(int AlbumID)
		//{
		//    string SQL = "select * from Songs where AlbumID = " + AlbumID + " order by TrackNumber";
		//    DbDataReader dr = AppData.ExecQuery(SQL);
		//    if (dr != null && dr.HasRows)
		//        Load(dr);
		//}

		public VideoList(DataTable dt)
		{
			Load(dt);
		}

		public VideoList(DbDataReader dr)
		{
			Load(dr);
		}

		public void Load(DataTable dt)
		{
			if (dt.Rows.Count > 0)
				foreach (DataRow row in dt.Rows)
				{
					Add(new Video(row));
				}
		}

		public void Load(DbDataReader dr)
		{
			if (dr.HasRows)
				while (dr.Read())
				{
					Add(new Video(dr));
				}
			dr.Close();
		}

	}
}
