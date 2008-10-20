using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Superi.Common;

namespace Superi.Features
{
    public class ArticlePictureList : List<ArticlePicture>
    {
        public ArticlePictureList(bool GetAll)
		{
			if (GetAll)
			{

			    DataSet ds = AppData.ExecDataSet("ArticlePictures_Get", null);
                if (ds != null && ds.Tables.Count > 0)
                    Load(ds.Tables[0]);
			}
		}

        public ArticlePictureList(int ArticleId)
        {
            ParameterList parameterList = new ParameterList();
            parameterList.Add(new AppDbParameter("articleid", ArticleId));
            DataSet ds = AppData.ExecDataSet("ArticlePictures_Get", parameterList);
            if (ds != null && ds.Tables.Count > 0)
                Load(ds.Tables[0]);
        }

		public ArticlePictureList(DataTable dt)
		{
			Load(dt);
		}

        public ArticlePictureList(DbDataReader dr)
		{
			Load(dr);
		}

		public void Load(DataTable dt)
		{
			if (dt.Rows.Count > 0)
				foreach (DataRow row in dt.Rows)
				{
					Add(new ArticlePicture(row));
				}
		}

		public void Load(DbDataReader dr)
		{
			if (dr.HasRows)
				while (dr.Read())
				{
                    Add(new ArticlePicture(dr));
				}
			dr.Close();
		}

        public void Remove()
        {
            foreach (ArticlePicture scope in this)
            {
                scope.Remove();
            }
        }

    }
}
