using System.Data;
using System.Data.Common;
using Superi.Common;

namespace Superi.Features
{
    public class ArticlePicture
    {
        #region Private fields
        private int id = int.MinValue;
        private string picture = "";
        private int articleId = int.MinValue;
        private string description = "";
        private int descriptionTextId = int.MinValue;
        #endregion

        #region Public properties
        public int Id
        {
            get { return id; }
        }

        public string Picture
        {
            get { return picture; }
            set { picture = value; }
        }

        public int ArticleId
        {
            get { return articleId; }
            set { articleId = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public int DescriptionTextId
        {
            get { return descriptionTextId; }
            set { descriptionTextId = value; }
        }

        public Resource Descriptions
        {
            get { return new Resource(descriptionTextId); }
        }
        #endregion

        
		#region Constructors
		public ArticlePicture()
		{

		}

		public ArticlePicture(DataRow dr)
		{
			if (dr != null) Load(dr);
		}

		public ArticlePicture(DbDataReader dr)
		{
			//if /*(dr.Read())*/ 
			Load(dr);
		}

        public ArticlePicture(int Id)
		{
			ParameterList pList = new ParameterList();
            pList.Add(new AppDbParameter("id", Id));
            DataSet ds = AppData.ExecDataSet("ArticlePictures_Get", pList);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                Load(ds.Tables[0].Rows[0]);
		}
		#endregion

        #region Public methods
		public bool Load(DbDataReader dr)
		{
			return Load(dr, false);
		}

		public bool Load(DbDataReader dr, bool CloseDr)
		{
			id = dr.GetInt32(dr.GetOrdinal("ID"));
			Description = dr["Description"].ToString();
            DescriptionTextId = dr.GetInt32(dr.GetOrdinal("DescriptionTextId"));
			Picture = dr["Picture"].ToString();
            ArticleId = dr.GetInt32(dr.GetOrdinal("ArticleId"));

			if (CloseDr)
				dr.Close();
			return true;
		}

		public bool Load(DataRow dr)
		{
			id = (int)dr["Id"];
			Description = dr["Description"].ToString();
		    DescriptionTextId = (int) dr["DescriptionTextID"];
			Picture = dr["Picture"].ToString();
            ArticleId = (int)dr["ArticleId"];
            return true;
		}

		public bool Save()
		{
			ParameterList pList = new ParameterList();
			pList.Add(new AppDbParameter("id", Id));
			pList.Add(new AppDbParameter("description", Description));
            pList.Add(new AppDbParameter("descriptiontextid", DescriptionTextId));
			pList.Add(new AppDbParameter("picture", Picture));
		    pList.Add(new AppDbParameter("articleit", ArticleId));
			DbDataReader dr = AppData.ExecStoredProcedure("ArticlePictures_AddUpdate", pList);
			if (dr != null && dr.HasRows && dr.Read())
			{
				id = int.Parse(dr[0].ToString());
				dr.Close();
			}
			else
				return false;
			return true;
		}

		public bool Remove()
		{
			bool result = true;
			if (id > 0)
			{
                Descriptions.Remove();
                ParameterList parameterList = new ParameterList();
                parameterList.Add(new AppDbParameter("id", id));
			    AppData.ExecStoredProcedure("ArticlePictures_Delete", parameterList);
			}
			else result = false;
			return result;
		}
		#endregion

    }
}
