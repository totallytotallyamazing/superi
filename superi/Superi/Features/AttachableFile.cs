using System.Data;
using System.Data.Common;
using Superi.Common;

namespace Superi.Features
{
    public enum ItemTypes{Text, Article}

    public class AttachableFile
    {
        #region Private fields
        private int id = int.MinValue;
        private string title = "";
        private string language = "";
        private int itemId = int.MinValue;
        private int itemType = int.MinValue;
        private string fileName = "";
        private int fileId = int.MinValue;
        #endregion

        #region Public properties
        public int Id
        {
            get { return id; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Language
        {
            get { return language; }
            set { language = value; }
        }

        public int ItemId
        {
            get { return itemId; }
            set { itemId = value; }
        }

        public int ItemType
        {
            get { return itemType; }
            set { itemType = value; }
        }

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        public int FileId
        {
            get { return fileId; }
            set { fileId = value; }
        }

        #endregion

        #region Constructors
        public AttachableFile()
		{

		}

		public AttachableFile(DataRow dr)
		{
			if (dr != null) Load(dr);
		}

		public AttachableFile(DbDataReader dr)
		{
			//if /*(dr.Read())*/ 
			Load(dr);
		}

        public AttachableFile(int ID)
		{
			string sql = "select * from AttachableFiles where ID=" + ID;
			DbDataReader dr = AppData.ExecQuery(sql);
			if (dr != null && dr.Read())
				Load(dr, true);
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
            Title = dr["Title"].ToString();
            FileName = dr["FileName"].ToString();
            ItemId = dr.GetInt32(dr.GetOrdinal("ItemId"));
            ItemType = dr.GetInt32(dr.GetOrdinal("ItemType"));
            Language = dr["Language"].ToString();
            FileId = dr.GetInt32(dr.GetOrdinal("FileID"));

            if (CloseDr)
                dr.Close();
            return true;
        }

        public bool Load(DataRow dr)
        {
            id = (int)dr["ID"];
            Title = dr["Title"].ToString();
            FileName = dr["FileName"].ToString();
            ItemId = (int)dr["ItemId"];
            ItemType = (int)dr["ItemType"];
            Language = dr["Language"].ToString();
            FileId = (int) dr["FileID"];

            return true;
        }

        public bool Save()
        {
            ParameterList pList = new ParameterList();
            pList.Add(new AppDbParameter("id", Id));
            pList.Add(new AppDbParameter("title", Title));
            pList.Add(new AppDbParameter("filename",FileName));
            pList.Add(new AppDbParameter("itemid", ItemId));
            pList.Add(new AppDbParameter("language", Language));
            pList.Add(new AppDbParameter("itemtypeid",ItemType));
            pList.Add(new AppDbParameter("fileid", FileId));

            DbDataReader dr = AppData.ExecStoredProcedure("AttachableFiles_AddUpdate", pList);
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
                ParameterList pList = new ParameterList();
                pList.Add(new AppDbParameter("id", Id));
                AppData.ExecStoredProcedure("AttachableFiles_Delete", pList);
            }
            else result = false;
            return result;
        }


        #endregion

    }
}
