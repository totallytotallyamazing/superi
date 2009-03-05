using System.Data;
using System.Data.Common;
using Superi.Common;

namespace Superi.Features
{
    public class FAQ
    {
        #region Private fields
        private int id = int.MinValue;
        private string question = "";
        private string answer = "";
        private bool display;
        private int groupId = int.MinValue;
        private string name = "";
        private string email = "";
        private string language = "";
        #endregion

        #region Public properties
        public int Id
        {
            get { return id; }
        }

        public string Question
        {
            get { return question; }
            set { question = value; }
        }

        public string Answer
        {
            get { return answer; }
            set { answer = value; }
        }

        public bool Display
        {
            get { return display; }
            set { display = value; }
        }

        public int GroupId
        {
            get { return groupId; }
            set { groupId = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Language
        {
            get { return language; }
            set { language = value; }
        }
        #endregion

        #region Constructors
		public FAQ()
		{

		}

		public FAQ(DataRow dr)
		{
			if (dr != null) Load(dr);
		}

		public FAQ(DbDataReader dr)
		{
			//if /*(dr.Read())*/ 
			Load(dr);
		}

		public FAQ(int ID)
		{
            ParameterList pList = new ParameterList();
            pList.Add(new AppDbParameter("id", ID));

			DbDataReader dr = AppData.ExecStoredProcedure("FAQ_Get", pList);
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
            Question = dr["Question"].ToString();
            Answer = dr["Answer"].ToString();
		    Display = dr.GetBoolean(dr.GetOrdinal("Display"));
		    GroupId = dr.GetInt32(dr.GetOrdinal("GroupId"));
		    Name = dr["Name"].ToString();
		    Email = dr["Email"].ToString();

			if (CloseDr)
				dr.Close();
			return true;
		}

		public bool Load(DataRow dr)
		{
		    id = (int) dr["ID"];
            Question = dr["Question"].ToString();
		    Answer = dr["Answer"].ToString();
		    Display = (bool) dr["Display"];
		    GroupId = (int) dr["GroupId"];
            Name = dr["Name"].ToString();
            Email = dr["Email"].ToString();
            return true;
		}

		public bool Save()
		{
			ParameterList pList = new ParameterList();
			pList.Add(new AppDbParameter("id", id));
            pList.Add(new AppDbParameter("question", Question));
            pList.Add(new AppDbParameter("answer", Answer));
            pList.Add(new AppDbParameter("display", Display));
            pList.Add(new AppDbParameter("groupid", GroupId));
            pList.Add(new AppDbParameter("name", Name));
            pList.Add(new AppDbParameter("email", Email));
            pList.Add(new AppDbParameter("language", Language));

			DbDataReader dr = AppData.ExecStoredProcedure("FAQ_AddUpdate", pList);
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
                pList.Add(new AppDbParameter("id", id));
			    AppData.ExecStoredProcedure("FAQ_Delete", pList);
			}
			else result = false;
			return result;
		}
		#endregion
    }
}
