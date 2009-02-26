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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;



[System.Data.Linq.Mapping.DatabaseAttribute(Name="1gb_Tina")]
public partial class NewsDataContext : System.Data.Linq.DataContext
{
	
	private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
	
  #region Extensibility Method Definitions
  partial void OnCreated();
  partial void InsertNewsItem(NewsItem instance);
  partial void UpdateNewsItem(NewsItem instance);
  partial void DeleteNewsItem(NewsItem instance);
  #endregion
	
	public NewsDataContext() : 
			base(global::System.Configuration.ConfigurationManager.ConnectionStrings["_1gb_TinaConnectionString"].ConnectionString, mappingSource)
	{
		OnCreated();
	}
	
	public NewsDataContext(string connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public NewsDataContext(System.Data.IDbConnection connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public NewsDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public NewsDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public System.Data.Linq.Table<NewsItem> NewsItems
	{
		get
		{
			return this.GetTable<NewsItem>();
		}
	}
}

[Table(Name="dbo.News")]
public partial class NewsItem : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _ID;
	
	private string _Title;
	
	private string _ShortText;
	
	private string _Text;
	
	private System.Nullable<bool> _Archive;
	
	private string _Picture;
	
	private string _DetailPicture;
	
	private System.Nullable<bool> _Award = false;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnTitleChanging(string value);
    partial void OnTitleChanged();
    partial void OnShortTextChanging(string value);
    partial void OnShortTextChanged();
    partial void OnTextChanging(string value);
    partial void OnTextChanged();
    partial void OnArchiveChanging(System.Nullable<bool> value);
    partial void OnArchiveChanged();
    partial void OnPictureChanging(string value);
    partial void OnPictureChanged();
    partial void OnDetailPictureChanging(string value);
    partial void OnDetailPictureChanged();
    partial void OnAwardChanging(System.Nullable<bool> value);
    partial void OnAwardChanged();
    #endregion
	
	public NewsItem()
	{
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
	
	[Column(Storage="_Title", DbType="VarChar(500) NOT NULL", CanBeNull=false)]
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
	
	[Column(Storage="_ShortText", DbType="VarChar(2000)")]
	public string ShortText
	{
		get
		{
			return this._ShortText;
		}
		set
		{
			if ((this._ShortText != value))
			{
				this.OnShortTextChanging(value);
				this.SendPropertyChanging();
				this._ShortText = value;
				this.SendPropertyChanged("ShortText");
				this.OnShortTextChanged();
			}
		}
	}
	
	[Column(Storage="_Text", DbType="VarChar(MAX)")]
	public string Text
	{
		get
		{
			return this._Text;
		}
		set
		{
			if ((this._Text != value))
			{
				this.OnTextChanging(value);
				this.SendPropertyChanging();
				this._Text = value;
				this.SendPropertyChanged("Text");
				this.OnTextChanged();
			}
		}
	}
	
	[Column(Storage="_Archive", DbType="Bit")]
	public System.Nullable<bool> Archive
	{
		get
		{
			return this._Archive;
		}
		set
		{
			if ((this._Archive != value))
			{
				this.OnArchiveChanging(value);
				this.SendPropertyChanging();
				this._Archive = value;
				this.SendPropertyChanged("Archive");
				this.OnArchiveChanged();
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
	
	[Column(Storage="_DetailPicture", DbType="VarChar(255)")]
	public string DetailPicture
	{
		get
		{
			return this._DetailPicture;
		}
		set
		{
			if ((this._DetailPicture != value))
			{
				this.OnDetailPictureChanging(value);
				this.SendPropertyChanging();
				this._DetailPicture = value;
				this.SendPropertyChanged("DetailPicture");
				this.OnDetailPictureChanged();
			}
		}
	}
	
	[Column(Storage="_Award", DbType="Bit")]
	public System.Nullable<bool> Award
	{
		get
		{
			return this._Award;
		}
		set
		{
			if ((this._Award != value))
			{
				this.OnAwardChanging(value);
				this.SendPropertyChanging();
				this._Award = value;
				this.SendPropertyChanged("Award");
				this.OnAwardChanged();
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
#pragma warning restore 1591
