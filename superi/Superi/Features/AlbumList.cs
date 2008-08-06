using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Superi.Common;

namespace Superi.Features
{
	public class AlbumList:List<Album>
	{
		public AlbumList(bool GetAll)
		{
			if (GetAll)
			{
				string SQL = "select * from Albums";
				DbDataReader dr = AppData.ExecQuery(SQL);
				if (dr != null && dr.HasRows)
					Load(dr);
			}
		}

		public AlbumList(DataTable dt)
		{
			Load(dt);
		}

		public AlbumList(DbDataReader dr)
		{
			Load(dr);
		}

		public void Load(DataTable dt)
		{
			if (dt.Rows.Count > 0)
				foreach (DataRow row in dt.Rows)
				{
					Add(new Album(row));
				}
		}

		public void Load(DbDataReader dr)
		{
			if (dr.HasRows)
				while (dr.Read())
				{
					Add(new Album(dr));
				}
			dr.Close();
		}

	}
}