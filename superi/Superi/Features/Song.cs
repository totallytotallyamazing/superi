using System;
using System.Data;
using System.Data.Common;
using Superi.Common;

namespace Superi.Features
{
	public class Song
	{
		#region Private fields
		private int _ID = int.MinValue;
		private string _Title = "";
		private string _Artist = "";
		private TimeSpan _Length = TimeSpan.MinValue;
		private int _TrackNumber = 0;
		private int _AlbumID = int.MinValue;
		private string _Composer = "";
		private string _Poet = "";
		private string _Lyrics = "";
		#endregion

		#region Properties
		public int ID
		{
			get { return _ID; }
		}

		public string Title
		{
			get { return _Title; }
			set { _Title = value; }
		}

		public string Artist
		{
			get { return _Artist; }
			set { _Artist = value; }
		}

		public TimeSpan Length
		{
			get { return _Length; }
			set { _Length = value; }
		}

		public int TrackNumber
		{
			get { return _TrackNumber; }
			set { _TrackNumber = value; }
		}

		public int AlbumID
		{
			get { return _AlbumID; }
			set { _AlbumID = value; }
		}

		public string Composer
		{
			get { return _Composer; }
			set { _Composer = value; }
		}

		public string Poet
		{
			get { return _Poet; }
			set { _Poet = value; }
		}

		public string Lyrics
		{
			get { return _Lyrics; }
			set { _Lyrics = value; }
		}
		#endregion

		#region Constructors
		public Song()
		{

		}

		public Song(DataRow dr)
		{
			if (dr != null) Load(dr);
		}

		public Song(DbDataReader dr)
		{
			//if /*(dr.Read())*/ 
			Load(dr);
		}

		public Song(int ID)
		{
			string sql = "select * from Songs where ID=" + ID;
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
			_ID = dr.GetInt32(dr.GetOrdinal("ID"));
			Title = dr["Title"].ToString();
			Artist = dr["Artist"].ToString();
			Length = (TimeSpan)dr.GetValue(dr.GetOrdinal("Length"));
			TrackNumber = dr.GetInt32(dr.GetOrdinal("TrackNumber"));
			AlbumID = dr.GetInt32(dr.GetOrdinal("AlbumID"));
			Composer = dr["Composer"].ToString();
			Poet = dr["Poet"].ToString();
			Lyrics = dr["Lyrics"].ToString();

			if (CloseDr)
				dr.Close();
			return true;
		}

		public bool Load(DataRow dr)
		{
			_ID = int.Parse(dr["ID"].ToString());
			Title = dr["Title"].ToString();
			Artist = dr["Artist"].ToString();
			Length = TimeSpan.Parse(dr["Length"].ToString());
			TrackNumber = int.Parse(dr["TrackNumber"].ToString());
			AlbumID = int.Parse(dr["AlbumID"].ToString());
			Composer = dr["Composer"].ToString();
			Poet = dr["Poet"].ToString();
			Lyrics = dr["Lyrics"].ToString();
			return true;
		}

		public bool Save()
		{
			ParameterList pList = new ParameterList();
			pList.Add(new AppDbParameter("id", ID));
			pList.Add(new AppDbParameter("title", Title));
			pList.Add(new AppDbParameter("artist", Artist));
			pList.Add(new AppDbParameter("length", Length));
			pList.Add(new AppDbParameter("tracknumber", TrackNumber));
			pList.Add(new AppDbParameter("albumid", AlbumID));
			pList.Add(new AppDbParameter("composer", Composer));
			pList.Add(new AppDbParameter("poet", Poet));
			pList.Add(new AppDbParameter("lyrics", Lyrics));

			DbDataReader dr = AppData.ExecStoredProcedure("Songs_AddUpdate", pList);
			if (dr != null && dr.HasRows && dr.Read())
			{
				_ID = int.Parse(dr[0].ToString());
				dr.Close();
			}
			else
				return false;
			return true;
		}


		public bool Remove()
		{
			bool result;
			if (ID > 0)
			{
				string sql = "delete from Songs where id=" + ID;
				result = AppData.ExecNonQuery(sql);
			}
			else result = false;
			return result;
		}
		#endregion


	}
}
