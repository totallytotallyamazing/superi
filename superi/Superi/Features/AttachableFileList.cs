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
                DataSet ds = AppData.ExecDataSet("AttachableFiles_Get", null);
                if (ds != null && ds.Tables.Count > 0)
                    Load(ds.Tables[0]);
            }
		}

        public AttachableFileList(int ItemId, int ItemType, string Language)
        {
            ParameterList parameterList = new ParameterList();
            if(ItemId>0)
                parameterList.Add(new AppDbParameter("itemid", ItemId));
            if(ItemType>0)
                parameterList.Add(new AppDbParameter("itemtype", ItemType));
            if(!string.IsNullOrEmpty(Language))
                parameterList.Add(new AppDbParameter("language", Language));


            DataSet ds = AppData.ExecDataSet("AttachableFiles_Get", parameterList);
            if (ds != null && ds.Tables.Count>0)
                Load(ds.Tables[0]);
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
