using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Superi.Common;

namespace Superi.Features
{
	public class TextList : List<Text>
	{
		public TextList(bool GetAll)
		{
			if (GetAll)
			{
				string SQL = "select * from Texts";
				DbDataReader dr = AppData.ExecQuery(SQL);
				if (dr != null && dr.HasRows)
					Load(dr);
			}
		}

		public TextList(DataTable dt)
		{
			Load(dt);
		}

		public TextList(DbDataReader dr)
		{
			Load(dr);
		}

		public Text GetByID(int ID)
		{
			Text result = new Text();
			foreach (Text text in this)
			{
				if (text.ID == ID)
				{
					result = text;
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
					Add(new Text(row));
				}
		}

		public void Load(DbDataReader dr)
		{
			if (dr.HasRows)
				while (dr.Read())
				{
					Add(new Text(dr));
				}
			dr.Close();
		}
	}
}
