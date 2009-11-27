﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3053
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Videos
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	
	
	[System.Data.Linq.Mapping.DatabaseAttribute(Name="1gb_Tina")]
	public partial class VideoDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertVideo(VideoContext.Video instance);
    partial void UpdateVideo(VideoContext.Video instance);
    partial void DeleteVideo(VideoContext.Video instance);
    partial void InsertAlbum(VideoContext.Album instance);
    partial void UpdateAlbum(VideoContext.Album instance);
    partial void DeleteAlbum(VideoContext.Album instance);
    #endregion
		
		public VideoDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["_1gb_TinaConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public VideoDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public VideoDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public VideoDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public VideoDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<VideoContext.Video> Videos
		{
			get
			{
				return this.GetTable<VideoContext.Video>();
			}
		}
		
		public System.Data.Linq.Table<VideoContext.Album> Albums
		{
			get
			{
				return this.GetTable<VideoContext.Album>();
			}
		}
	}
}
namespace VideoContext
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.ComponentModel;
	using System;
	
	
	[Table(Name="dbo.Videos")]
	public partial class Video : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _Name;
		
		private string _Source;
		
		private string _Image;
		
		private System.Nullable<int> _AlbumID;
		
		private EntityRef<Album> _Album;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnSourceChanging(string value);
    partial void OnSourceChanged();
    partial void OnImageChanging(string value);
    partial void OnImageChanged();
    partial void OnAlbumIDChanging(System.Nullable<int> value);
    partial void OnAlbumIDChanged();
    #endregion
		
		public Video()
		{
			this._Album = default(EntityRef<Album>);
			OnCreated();
		}
		
		[Column(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_Name", DbType="VarChar(1000)")]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[Column(Storage="_Source", DbType="VarChar(255)")]
		public string Source
		{
			get
			{
				return this._Source;
			}
			set
			{
				if ((this._Source != value))
				{
					this.OnSourceChanging(value);
					this.SendPropertyChanging();
					this._Source = value;
					this.SendPropertyChanged("Source");
					this.OnSourceChanged();
				}
			}
		}
		
		[Column(Storage="_Image", DbType="VarChar(255)")]
		public string Image
		{
			get
			{
				return this._Image;
			}
			set
			{
				if ((this._Image != value))
				{
					this.OnImageChanging(value);
					this.SendPropertyChanging();
					this._Image = value;
					this.SendPropertyChanged("Image");
					this.OnImageChanged();
				}
			}
		}
		
		[Column(Storage="_AlbumID", DbType="int")]
		public System.Nullable<int> AlbumID
		{
			get
			{
				return this._AlbumID;
			}
			set
			{
				if ((this._AlbumID != value))
				{
					if (this._Album.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnAlbumIDChanging(value);
					this.SendPropertyChanging();
					this._AlbumID = value;
					this.SendPropertyChanged("AlbumID");
					this.OnAlbumIDChanged();
				}
			}
		}
		
		[Association(Name="Album_Video", Storage="_Album", ThisKey="AlbumID", OtherKey="ID", IsForeignKey=true)]
		public Album Album
		{
			get
			{
				return this._Album.Entity;
			}
			set
			{
				Album previousValue = this._Album.Entity;
				if (((previousValue != value) 
							|| (this._Album.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Album.Entity = null;
						previousValue.Videos.Remove(this);
					}
					this._Album.Entity = value;
					if ((value != null))
					{
						value.Videos.Add(this);
						this._AlbumID = value.ID;
					}
					else
					{
						this._AlbumID = default(Nullable<int>);
					}
					this.SendPropertyChanged("Album");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbo.Albums")]
	public partial class Album : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _Name;
		
		private System.Nullable<int> _Year;
		
		private string _Image;
		
		private EntitySet<Video> _Videos;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnYearChanging(System.Nullable<int> value);
    partial void OnYearChanged();
    partial void OnImageChanging(string value);
    partial void OnImageChanged();
    #endregion
		
		public Album()
		{
			this._Videos = new EntitySet<Video>(new Action<Video>(this.attach_Videos), new Action<Video>(this.detach_Videos));
			OnCreated();
		}
		
		[Column(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_Name", DbType="NVarChar(1000)")]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[Column(Storage="_Year", DbType="Int")]
		public System.Nullable<int> Year
		{
			get
			{
				return this._Year;
			}
			set
			{
				if ((this._Year != value))
				{
					this.OnYearChanging(value);
					this.SendPropertyChanging();
					this._Year = value;
					this.SendPropertyChanged("Year");
					this.OnYearChanged();
				}
			}
		}
		
		[Column(Storage="_Image", DbType="VarChar(255)")]
		public string Image
		{
			get
			{
				return this._Image;
			}
			set
			{
				if ((this._Image != value))
				{
					this.OnImageChanging(value);
					this.SendPropertyChanging();
					this._Image = value;
					this.SendPropertyChanged("Image");
					this.OnImageChanged();
				}
			}
		}
		
		[Association(Name="Album_Video", Storage="_Videos", ThisKey="ID", OtherKey="AlbumID")]
		public EntitySet<Video> Videos
		{
			get
			{
				return this._Videos;
			}
			set
			{
				this._Videos.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Videos(Video entity)
		{
			this.SendPropertyChanging();
			entity.Album = this;
		}
		
		private void detach_Videos(Video entity)
		{
			this.SendPropertyChanging();
			entity.Album = null;
		}
	}
}
#pragma warning restore 1591