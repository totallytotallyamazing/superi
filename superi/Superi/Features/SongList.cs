using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Superi.Common;

namespace Superi.Features
{
	public class SongList : List<Song>
	{
		public SongList(bool GetAll)
		{
			if (GetAll)
			{
				string SQL = "select * from Songs order by TrackNumber";
				DbDataReader dr = AppData.ExecQuery(SQL);
				if (dr != null && dr.HasRows)
					Load(dr);
			}
		}

		public SongList(int AlbumID)
		{
			string SQL = "select * from Songs where AlbumID = " + AlbumID + " order by TrackNumber";
			DbDataReader dr = AppData.ExecQuery(SQL);
			if (dr != null && dr.HasRows)
				Load(dr);
		}

		public SongList(DataTable dt)
		{
			Load(dt);
		}

		public SongList(DbDataReader dr)
		{
			Load(dr);
		}

		public void Load(DataTable dt)
		{
			if (dt.Rows.Count > 0)
				foreach (DataRow row in dt.Rows)
				{
					Add(new Song(row));
				}
		}

		public void Load(DbDataReader dr)
		{
			if (dr.HasRows)
				while (dr.Read())
				{
					Add(new Song(dr));
				}
			dr.Close();
		}

	}
}
