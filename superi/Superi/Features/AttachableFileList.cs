using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Superi.Common;

namespace Superi.Features
{
    public class AttachableFileList : List<AttachableFile>
    {
        public AttachableFileList(bool GetAll)
		{
			if (GetAll)
			{
				string SQL = "select * from AttachableFiles";
				DbDataReader dr = AppData.ExecQuery(SQL);
				if (dr != null && dr.HasRows)
					Load(dr);
			}
		}

        public AttachableFileList(int ItemId, int ItemType, string Language)
        {
            string SQL = "select * from AttachableFiles where ItemType=" + ItemType + " and ItemId=" + ItemId + " and Language='"+Language+"'";
            DbDataReader dr = AppData.ExecQuery(SQL);
            if (dr != null && dr.HasRows)
                Load(dr);
        }

		public AttachableFileList(DataTable dt)
		{
			Load(dt);
		}

        public AttachableFileList(DbDataReader dr)
		{
			Load(dr);
		}

		public void Load(DataTable dt)
		{
			if (dt.Rows.Count > 0)
				foreach (DataRow row in dt.Rows)
				{
					Add(new AttachableFile(row));
				}
		}

		public void Load(DbDataReader dr)
		{
			if (dr.HasRows)
				while (dr.Read())
				{
                    Add(new AttachableFile(dr));
				}
			dr.Close();
		}

    }
}
