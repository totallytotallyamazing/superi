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

namespace Galleria
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	
	
	[System.Data.Linq.Mapping.DatabaseAttribute(Name="1gb_Tina")]
	public partial class GalleryDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertGallery(GalleryContext.Gallery instance);
    partial void UpdateGallery(GalleryContext.Gallery instance);
    partial void DeleteGallery(GalleryContext.Gallery instance);
    partial void InsertAlbum(GalleryContext.Album instance);
    partial void UpdateAlbum(GalleryContext.Album instance);
    partial void DeleteAlbum(GalleryContext.Album instance);
    #endregion
		
		public GalleryDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["_1gb_TinaConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public GalleryDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public GalleryDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public GalleryDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public GalleryDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<GalleryContext.Gallery> Galleries
		{
			get
			{
				return this.GetTable<GalleryContext.Gallery>();
			}
		}
		
		public System.Data.Linq.Table<GalleryContext.Album> Albums
		{
			get
			{
				return this.GetTable<GalleryContext.Album>();
			}
		}
	}
}
namespace GalleryContext
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.ComponentModel;
	using System;
	
	
	[Table(Name="dbo.Gallery")]
	public partial class Gallery : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private int _AlbumID;
		
		private string _Picture;
		
		private string _Thumbnail;
		
		private string _Title;
		
		private int _SortOrder;
		
		private EntityRef<Album> _Album;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnAlbumIDChanging(int value);
    partial void OnAlbumIDChanged();
    partial void OnPictureChanging(string value);
    partial void OnPictureChanged();
    partial void OnThumbnailChanging(string value);
    partial void OnThumbnailChanged();
    partial void OnTitleChanging(string value);
    partial void OnTitleChanged();
    partial void OnSortOrderChanging(int value);
    partial void OnSortOrderChanged();
    #endregion
		
		public Gallery()
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
		
		[Column(Storage="_AlbumID", DbType="Int NOT NULL")]
		public int AlbumID
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
		
		[Column(Storage="_Picture", DbType="VarChar(255)")]
		public string Picture
		{
			get
			{
				return this._Picture;
			}
			set
			{
				if ((this._Picture != value))
				{
					this.OnPictureChanging(value);
					this.SendPropertyChanging();
					this._Picture = value;
					this.SendPropertyChanged("Picture");
					this.OnPictureChanged();
				}
			}
		}
		
		[Column(Storage="_Thumbnail", DbType="VarChar(255)")]
		public string Thumbnail
		{
			get
			{
				return this._Thumbnail;
			}
			set
			{
				if ((this._Thumbnail != value))
				{
					this.OnThumbnailChanging(value);
					this.SendPropertyChanging();
					this._Thumbnail = value;
					this.SendPropertyChanged("Thumbnail");
					this.OnThumbnailChanged();
				}
			}
		}
		
		[Column(Storage="_Title", DbType="VarChar(500)")]
		public string Title
		{
			get
			{
				return this._Title;
			}
			set
			{
				if ((this._Title != value))
				{
					this.OnTitleChanging(value);
					this.SendPropertyChanging();
					this._Title = value;
					this.SendPropertyChanged("Title");
					this.OnTitleChanged();
				}
			}
		}
		
		[Column(Storage="_SortOrder", DbType="int")]
		public int SortOrder
		{
			get
			{
				return this._SortOrder;
			}
			set
			{
				if ((this._SortOrder != value))
				{
					this.OnSortOrderChanging(value);
					this.SendPropertyChanging();
					this._SortOrder = value;
					this.SendPropertyChanged("SortOrder");
					this.OnSortOrderChanged();
				}
			}
		}
		
		[Association(Name="Album_Gallery", Storage="_Album", ThisKey="AlbumID", OtherKey="ID", IsForeignKey=true)]
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
						previousValue.Galleries.Remove(this);
					}
					this._Album.Entity = value;
					if ((value != null))
					{
						value.Galleries.Add(this);
						this._AlbumID = value.ID;
					}
					else
					{
						this._AlbumID = default(int);
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
		
		private EntitySet<Gallery> _Galleries;
		
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
			this._Galleries = new EntitySet<Gallery>(new Action<Gallery>(this.attach_Galleries), new Action<Gallery>(this.detach_Galleries));
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
		
		[Association(Name="Album_Gallery", Storage="_Galleries", ThisKey="ID", OtherKey="AlbumID")]
		public EntitySet<Gallery> Galleries
		{
			get
			{
				return this._Galleries;
			}
			set
			{
				this._Galleries.Assign(value);
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
		
		private void attach_Galleries(Gallery entity)
		{
			this.SendPropertyChanging();
			entity.Album = this;
		}
		
		private void detach_Galleries(Gallery entity)
		{
			this.SendPropertyChanging();
			entity.Album = null;
		}
	}
}
#pragma warning restore 1591
