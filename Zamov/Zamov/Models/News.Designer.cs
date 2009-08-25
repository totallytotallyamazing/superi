﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3074
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::System.Data.Objects.DataClasses.EdmSchemaAttribute()]

// Original file name:
// Generation date: 25.08.2009 22:40:48
namespace Zamov.Models
{
    
    /// <summary>
    /// There are no comments for NewsStorage in the schema.
    /// </summary>
    public partial class NewsStorage : global::System.Data.Objects.ObjectContext
    {
        /// <summary>
        /// Initializes a new NewsStorage object using the connection string found in the 'NewsStorage' section of the application configuration file.
        /// </summary>
        public NewsStorage() : 
                base("name=NewsStorage", "NewsStorage")
        {
            this.OnContextCreated();
        }
        /// <summary>
        /// Initialize a new NewsStorage object.
        /// </summary>
        public NewsStorage(string connectionString) : 
                base(connectionString, "NewsStorage")
        {
            this.OnContextCreated();
        }
        /// <summary>
        /// Initialize a new NewsStorage object.
        /// </summary>
        public NewsStorage(global::System.Data.EntityClient.EntityConnection connection) : 
                base(connection, "NewsStorage")
        {
            this.OnContextCreated();
        }
        partial void OnContextCreated();
        /// <summary>
        /// There are no comments for News in the schema.
        /// </summary>
        public global::System.Data.Objects.ObjectQuery<News> News
        {
            get
            {
                if ((this._News == null))
                {
                    this._News = base.CreateQuery<News>("[News]");
                }
                return this._News;
            }
        }
        private global::System.Data.Objects.ObjectQuery<News> _News;
        /// <summary>
        /// There are no comments for Translations in the schema.
        /// </summary>
        public global::System.Data.Objects.ObjectQuery<Translations> Translations
        {
            get
            {
                if ((this._Translations == null))
                {
                    this._Translations = base.CreateQuery<Translations>("[Translations]");
                }
                return this._Translations;
            }
        }
        private global::System.Data.Objects.ObjectQuery<Translations> _Translations;
        /// <summary>
        /// There are no comments for News in the schema.
        /// </summary>
        public void AddToNews(News news)
        {
            base.AddObject("News", news);
        }
        /// <summary>
        /// There are no comments for Translations in the schema.
        /// </summary>
        public void AddToTranslations(Translations translations)
        {
            base.AddObject("Translations", translations);
        }
    }
    /// <summary>
    /// There are no comments for News.News in the schema.
    /// </summary>
    /// <KeyProperties>
    /// Id
    /// </KeyProperties>
    [global::System.Data.Objects.DataClasses.EdmEntityTypeAttribute(NamespaceName="News", Name="News")]
    [global::System.Runtime.Serialization.DataContractAttribute(IsReference=true)]
    [global::System.Serializable()]
    public partial class News : global::System.Data.Objects.DataClasses.EntityObject
    {
        /// <summary>
        /// Create a new News object.
        /// </summary>
        /// <param name="id">Initial value of Id.</param>
        public static News CreateNews(int id)
        {
            News news = new News();
            news.Id = id;
            return news;
        }
        /// <summary>
        /// There are no comments for Property Id in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public int Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                this.OnIdChanging(value);
                this.ReportPropertyChanging("Id");
                this._Id = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("Id");
                this.OnIdChanged();
            }
        }
        private int _Id;
        partial void OnIdChanging(int value);
        partial void OnIdChanged();
        /// <summary>
        /// There are no comments for Property Image in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public byte[] Image
        {
            get
            {
                return global::System.Data.Objects.DataClasses.StructuralObject.GetValidValue(this._Image);
            }
            set
            {
                this.OnImageChanging(value);
                this.ReportPropertyChanging("Image");
                this._Image = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("Image");
                this.OnImageChanged();
            }
        }
        private byte[] _Image;
        partial void OnImageChanging(byte[] value);
        partial void OnImageChanged();
        /// <summary>
        /// There are no comments for Property Date in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Nullable<global::System.DateTime> Date
        {
            get
            {
                return this._Date;
            }
            set
            {
                this.OnDateChanging(value);
                this.ReportPropertyChanging("Date");
                this._Date = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("Date");
                this.OnDateChanged();
            }
        }
        private global::System.Nullable<global::System.DateTime> _Date;
        partial void OnDateChanging(global::System.Nullable<global::System.DateTime> value);
        partial void OnDateChanged();
    }
    /// <summary>
    /// There are no comments for News.Translations in the schema.
    /// </summary>
    /// <KeyProperties>
    /// Id
    /// </KeyProperties>
    [global::System.Data.Objects.DataClasses.EdmEntityTypeAttribute(NamespaceName="News", Name="Translations")]
    [global::System.Runtime.Serialization.DataContractAttribute(IsReference=true)]
    [global::System.Serializable()]
    public partial class Translations : global::System.Data.Objects.DataClasses.EntityObject
    {
        /// <summary>
        /// Create a new Translations object.
        /// </summary>
        /// <param name="id">Initial value of Id.</param>
        /// <param name="language">Initial value of Language.</param>
        /// <param name="itemId">Initial value of ItemId.</param>
        /// <param name="translationItemTypeId">Initial value of TranslationItemTypeId.</param>
        public static Translations CreateTranslations(int id, string language, int itemId, int translationItemTypeId)
        {
            Translations translations = new Translations();
            translations.Id = id;
            translations.Language = language;
            translations.ItemId = itemId;
            translations.TranslationItemTypeId = translationItemTypeId;
            return translations;
        }
        /// <summary>
        /// There are no comments for Property Id in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public int Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                this.OnIdChanging(value);
                this.ReportPropertyChanging("Id");
                this._Id = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("Id");
                this.OnIdChanged();
            }
        }
        private int _Id;
        partial void OnIdChanging(int value);
        partial void OnIdChanged();
        /// <summary>
        /// There are no comments for Property Language in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string Language
        {
            get
            {
                return this._Language;
            }
            set
            {
                this.OnLanguageChanging(value);
                this.ReportPropertyChanging("Language");
                this._Language = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("Language");
                this.OnLanguageChanged();
            }
        }
        private string _Language;
        partial void OnLanguageChanging(string value);
        partial void OnLanguageChanged();
        /// <summary>
        /// There are no comments for Property ItemId in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public int ItemId
        {
            get
            {
                return this._ItemId;
            }
            set
            {
                this.OnItemIdChanging(value);
                this.ReportPropertyChanging("ItemId");
                this._ItemId = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("ItemId");
                this.OnItemIdChanged();
            }
        }
        private int _ItemId;
        partial void OnItemIdChanging(int value);
        partial void OnItemIdChanged();
        /// <summary>
        /// There are no comments for Property TranslationItemTypeId in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public int TranslationItemTypeId
        {
            get
            {
                return this._TranslationItemTypeId;
            }
            set
            {
                this.OnTranslationItemTypeIdChanging(value);
                this.ReportPropertyChanging("TranslationItemTypeId");
                this._TranslationItemTypeId = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("TranslationItemTypeId");
                this.OnTranslationItemTypeIdChanged();
            }
        }
        private int _TranslationItemTypeId;
        partial void OnTranslationItemTypeIdChanging(int value);
        partial void OnTranslationItemTypeIdChanged();
        /// <summary>
        /// There are no comments for Property Translation in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string Translation
        {
            get
            {
                return this._Translation;
            }
            set
            {
                this.OnTranslationChanging(value);
                this.ReportPropertyChanging("Translation");
                this._Translation = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("Translation");
                this.OnTranslationChanged();
            }
        }
        private string _Translation;
        partial void OnTranslationChanging(string value);
        partial void OnTranslationChanged();
    }
}
