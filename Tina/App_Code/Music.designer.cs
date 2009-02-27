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

namespace Musics
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	
	
	[System.Data.Linq.Mapping.DatabaseAttribute(Name="1gb_Tina")]
	public partial class MusicDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertSong(MusicContext.Song instance);
    partial void UpdateSong(MusicContext.Song instance);
    partial void DeleteSong(MusicContext.Song instance);
    partial void InsertAlbum(MusicContext.Album instance);
    partial void UpdateAlbum(MusicContext.Album instance);
    partial void DeleteAlbum(MusicContext.Album instance);
    #endregion
		
		public MusicDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["ContentConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public MusicDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MusicDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MusicDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MusicDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<MusicContext.Song> Songs
		{
			get
			{
				return this.GetTable<MusicContext.Song>();
			}
		}
		
		public System.Data.Linq.Table<MusicContext.Album> Albums
		{
			get
			{
				return this.GetTable<MusicContext.Album>();
			}
		}
	}
}
namespace MusicContext
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.ComponentModel;
	using System;
	
	
	[Table(Name="dbo.Songs")]
	public partial class Song : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _Name;
		
		private string _Source;
		
		private System.Nullable<System.DateTime> _Length;
		
		private System.Nullable<int> _AlbumId;
		
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
    partial void OnLengthChanging(System.Nullable<System.DateTime> value);
    partial void OnLengthChanged();
    partial void OnAlbumIdChanging(System.Nullable<int> value);
    partial void OnAlbumIdChanged();
    #endregion
		
		public Song()
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
		
		[Column(Storage="_Length", DbType="DateTime")]
		public System.Nullable<System.DateTime> Length
		{
			get
			{
				return this._Length;
			}
			set
			{
				if ((this._Length != value))
				{
					this.OnLengthChanging(value);
					this.SendPropertyChanging();
					this._Length = value;
					this.SendPropertyChanged("Length");
					this.OnLengthChanged();
				}
			}
		}
		
		[Column(Storage="_AlbumId", DbType="Int")]
		public System.Nullable<int> AlbumId
		{
			get
			{
				return this._AlbumId;
			}
			set
			{
				if ((this._AlbumId != value))
				{
					if (this._Album.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnAlbumIdChanging(value);
					this.SendPropertyChanging();
					this._AlbumId = value;
					this.SendPropertyChanged("AlbumId");
					this.OnAlbumIdChanged();
				}
			}
		}
		
		[Association(Name="Album_Song", Storage="_Album", ThisKey="AlbumId", OtherKey="ID", IsForeignKey=true)]
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
						previousValue.Songs.Remove(this);
					}
					this._Album.Entity = value;
					if ((value != null))
					{
						value.Songs.Add(this);
						this._AlbumId = value.ID;
					}
					else
					{
						this._AlbumId = default(Nullable<int>);
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
		
		private string _PhotoImage;
		
		private System.Nullable<bool> _InvertColors;
		
		private EntitySet<Song> _Songs;
		
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
    partial void OnPhotoImageChanging(string value);
    partial void OnPhotoImageChanged();
    partial void OnInvertColorsChanging(System.Nullable<bool> value);
    partial void OnInvertColorsChanged();
    #endregion
		
		public Album()
		{
			this._Songs = new EntitySet<Song>(new Action<Song>(this.attach_Songs), new Action<Song>(this.detach_Songs));
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
		
		[Column(Storage="_PhotoImage", DbType="VarChar(255)")]
		public string PhotoImage
		{
			get
			{
				return this._PhotoImage;
			}
			set
			{
				if ((this._PhotoImage != value))
				{
					this.OnPhotoImageChanging(value);
					this.SendPropertyChanging();
					this._PhotoImage = value;
					this.SendPropertyChanged("PhotoImage");
					this.OnPhotoImageChanged();
				}
			}
		}
		
		[Column(Storage="_InvertColors", DbType="Bit")]
		public System.Nullable<bool> InvertColors
		{
			get
			{
				return this._InvertColors;
			}
			set
			{
				if ((this._InvertColors != value))
				{
					this.OnInvertColorsChanging(value);
					this.SendPropertyChanging();
					this._InvertColors = value;
					this.SendPropertyChanged("InvertColors");
					this.OnInvertColorsChanged();
				}
			}
		}
		
		[Association(Name="Album_Song", Storage="_Songs", ThisKey="ID", OtherKey="AlbumId")]
		public EntitySet<Song> Songs
		{
			get
			{
				return this._Songs;
			}
			set
			{
				this._Songs.Assign(value);
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
		
		private void attach_Songs(Song entity)
		{
			this.SendPropertyChanging();
			entity.Album = this;
		}
		
		private void detach_Songs(Song entity)
		{
			this.SendPropertyChanging();
			entity.Album = null;
		}
	}
}
#pragma warning restore 1591
