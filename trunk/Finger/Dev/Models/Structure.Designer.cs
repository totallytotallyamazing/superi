﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3603
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::System.Data.Objects.DataClasses.EdmSchemaAttribute()]
[assembly: global::System.Data.Objects.DataClasses.EdmRelationshipAttribute("gbua_superiModel", "FK_SiteContent_SiteContent", "SiteContent", global::System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, typeof(Dev.Models.SiteContent), "SiteContent1", global::System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(Dev.Models.SiteContent))]

// Original file name:
// Generation date: 16/12/2009 17:55:02
namespace Dev.Models
{
    
    /// <summary>
    /// There are no comments for DataStorage in the schema.
    /// </summary>
    public partial class DataStorage : global::System.Data.Objects.ObjectContext
    {
        /// <summary>
        /// Initializes a new DataStorage object using the connection string found in the 'DataStorage' section of the application configuration file.
        /// </summary>
        public DataStorage() : 
                base("name=DataStorage", "DataStorage")
        {
            this.OnContextCreated();
        }
        /// <summary>
        /// Initialize a new DataStorage object.
        /// </summary>
        public DataStorage(string connectionString) : 
                base(connectionString, "DataStorage")
        {
            this.OnContextCreated();
        }
        /// <summary>
        /// Initialize a new DataStorage object.
        /// </summary>
        public DataStorage(global::System.Data.EntityClient.EntityConnection connection) : 
                base(connection, "DataStorage")
        {
            this.OnContextCreated();
        }
        partial void OnContextCreated();
        /// <summary>
        /// There are no comments for Notes in the schema.
        /// </summary>
        public global::System.Data.Objects.ObjectQuery<Notes> Notes
        {
            get
            {
                if ((this._Notes == null))
                {
                    this._Notes = base.CreateQuery<Notes>("[Notes]");
                }
                return this._Notes;
            }
        }
        private global::System.Data.Objects.ObjectQuery<Notes> _Notes;
        /// <summary>
        /// There are no comments for SiteContent in the schema.
        /// </summary>
        public global::System.Data.Objects.ObjectQuery<SiteContent> SiteContent
        {
            get
            {
                if ((this._SiteContent == null))
                {
                    this._SiteContent = base.CreateQuery<SiteContent>("[SiteContent]");
                }
                return this._SiteContent;
            }
        }
        private global::System.Data.Objects.ObjectQuery<SiteContent> _SiteContent;
        /// <summary>
        /// There are no comments for Notes in the schema.
        /// </summary>
        public void AddToNotes(Notes notes)
        {
            base.AddObject("Notes", notes);
        }
        /// <summary>
        /// There are no comments for SiteContent in the schema.
        /// </summary>
        public void AddToSiteContent(SiteContent siteContent)
        {
            base.AddObject("SiteContent", siteContent);
        }
    }
    /// <summary>
    /// There are no comments for gbua_superiModel.Notes in the schema.
    /// </summary>
    /// <KeyProperties>
    /// Id
    /// </KeyProperties>
    [global::System.Data.Objects.DataClasses.EdmEntityTypeAttribute(NamespaceName="gbua_superiModel", Name="Notes")]
    [global::System.Runtime.Serialization.DataContractAttribute(IsReference=true)]
    [global::System.Serializable()]
    public partial class Notes : global::System.Data.Objects.DataClasses.EntityObject
    {
        /// <summary>
        /// Create a new Notes object.
        /// </summary>
        /// <param name="date">Initial value of Date.</param>
        /// <param name="description">Initial value of Description.</param>
        /// <param name="id">Initial value of Id.</param>
        /// <param name="image">Initial value of Image.</param>
        /// <param name="language">Initial value of Language.</param>
        /// <param name="text">Initial value of Text.</param>
        /// <param name="title">Initial value of Title.</param>
        public static Notes CreateNotes(global::System.DateTime date, string description, long id, string image, string language, string text, string title)
        {
            Notes notes = new Notes();
            notes.Date = date;
            notes.Description = description;
            notes.Id = id;
            notes.Image = image;
            notes.Language = language;
            notes.Text = text;
            notes.Title = title;
            return notes;
        }
        /// <summary>
        /// There are no comments for Property Date in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.DateTime Date
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
        private global::System.DateTime _Date;
        partial void OnDateChanging(global::System.DateTime value);
        partial void OnDateChanged();
        /// <summary>
        /// There are no comments for Property Description in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string Description
        {
            get
            {
                return this._Description;
            }
            set
            {
                this.OnDescriptionChanging(value);
                this.ReportPropertyChanging("Description");
                this._Description = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("Description");
                this.OnDescriptionChanged();
            }
        }
        private string _Description;
        partial void OnDescriptionChanging(string value);
        partial void OnDescriptionChanged();
        /// <summary>
        /// There are no comments for Property Id in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public long Id
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
        private long _Id;
        partial void OnIdChanging(long value);
        partial void OnIdChanged();
        /// <summary>
        /// There are no comments for Property Image in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string Image
        {
            get
            {
                return this._Image;
            }
            set
            {
                this.OnImageChanging(value);
                this.ReportPropertyChanging("Image");
                this._Image = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("Image");
                this.OnImageChanged();
            }
        }
        private string _Image;
        partial void OnImageChanging(string value);
        partial void OnImageChanged();
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
        /// There are no comments for Property Text in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string Text
        {
            get
            {
                return this._Text;
            }
            set
            {
                this.OnTextChanging(value);
                this.ReportPropertyChanging("Text");
                this._Text = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("Text");
                this.OnTextChanged();
            }
        }
        private string _Text;
        partial void OnTextChanging(string value);
        partial void OnTextChanged();
        /// <summary>
        /// There are no comments for Property Title in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string Title
        {
            get
            {
                return this._Title;
            }
            set
            {
                this.OnTitleChanging(value);
                this.ReportPropertyChanging("Title");
                this._Title = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("Title");
                this.OnTitleChanged();
            }
        }
        private string _Title;
        partial void OnTitleChanging(string value);
        partial void OnTitleChanged();
    }
    /// <summary>
    /// There are no comments for gbua_superiModel.SiteContent in the schema.
    /// </summary>
    /// <KeyProperties>
    /// Id
    /// </KeyProperties>
    [global::System.Data.Objects.DataClasses.EdmEntityTypeAttribute(NamespaceName="gbua_superiModel", Name="SiteContent")]
    [global::System.Runtime.Serialization.DataContractAttribute(IsReference=true)]
    [global::System.Serializable()]
    public partial class SiteContent : global::System.Data.Objects.DataClasses.EntityObject
    {
        /// <summary>
        /// Create a new SiteContent object.
        /// </summary>
        /// <param name="id">Initial value of Id.</param>
        /// <param name="language">Initial value of Language.</param>
        /// <param name="name">Initial value of Name.</param>
        /// <param name="title">Initial value of Title.</param>
        /// <param name="url">Initial value of Url.</param>
        public static SiteContent CreateSiteContent(long id, string language, string name, string title, string url)
        {
            SiteContent siteContent = new SiteContent();
            siteContent.Id = id;
            siteContent.Language = language;
            siteContent.Name = name;
            siteContent.Title = title;
            siteContent.Url = url;
            return siteContent;
        }
        /// <summary>
        /// There are no comments for Property Description in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string Description
        {
            get
            {
                return this._Description;
            }
            set
            {
                this.OnDescriptionChanging(value);
                this.ReportPropertyChanging("Description");
                this._Description = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("Description");
                this.OnDescriptionChanged();
            }
        }
        private string _Description;
        partial void OnDescriptionChanging(string value);
        partial void OnDescriptionChanged();
        /// <summary>
        /// There are no comments for Property Id in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public long Id
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
        private long _Id;
        partial void OnIdChanging(long value);
        partial void OnIdChanged();
        /// <summary>
        /// There are no comments for Property Keywords in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string Keywords
        {
            get
            {
                return this._Keywords;
            }
            set
            {
                this.OnKeywordsChanging(value);
                this.ReportPropertyChanging("Keywords");
                this._Keywords = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("Keywords");
                this.OnKeywordsChanged();
            }
        }
        private string _Keywords;
        partial void OnKeywordsChanging(string value);
        partial void OnKeywordsChanged();
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
        /// There are no comments for Property Name in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                this.OnNameChanging(value);
                this.ReportPropertyChanging("Name");
                this._Name = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("Name");
                this.OnNameChanged();
            }
        }
        private string _Name;
        partial void OnNameChanging(string value);
        partial void OnNameChanged();
        /// <summary>
        /// There are no comments for Property SortOrder in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Nullable<long> SortOrder
        {
            get
            {
                return this._SortOrder;
            }
            set
            {
                this.OnSortOrderChanging(value);
                this.ReportPropertyChanging("SortOrder");
                this._SortOrder = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("SortOrder");
                this.OnSortOrderChanged();
            }
        }
        private global::System.Nullable<long> _SortOrder;
        partial void OnSortOrderChanging(global::System.Nullable<long> value);
        partial void OnSortOrderChanged();
        /// <summary>
        /// There are no comments for Property Text in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string Text
        {
            get
            {
                return this._Text;
            }
            set
            {
                this.OnTextChanging(value);
                this.ReportPropertyChanging("Text");
                this._Text = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("Text");
                this.OnTextChanged();
            }
        }
        private string _Text;
        partial void OnTextChanging(string value);
        partial void OnTextChanged();
        /// <summary>
        /// There are no comments for Property Title in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string Title
        {
            get
            {
                return this._Title;
            }
            set
            {
                this.OnTitleChanging(value);
                this.ReportPropertyChanging("Title");
                this._Title = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("Title");
                this.OnTitleChanged();
            }
        }
        private string _Title;
        partial void OnTitleChanging(string value);
        partial void OnTitleChanged();
        /// <summary>
        /// There are no comments for Property Url in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string Url
        {
            get
            {
                return this._Url;
            }
            set
            {
                this.OnUrlChanging(value);
                this.ReportPropertyChanging("Url");
                this._Url = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("Url");
                this.OnUrlChanged();
            }
        }
        private string _Url;
        partial void OnUrlChanging(string value);
        partial void OnUrlChanged();
        /// <summary>
        /// There are no comments for Children in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmRelationshipNavigationPropertyAttribute("gbua_superiModel", "FK_SiteContent_SiteContent", "SiteContent1")]
        [global::System.Xml.Serialization.XmlIgnoreAttribute()]
        [global::System.Xml.Serialization.SoapIgnoreAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Data.Objects.DataClasses.EntityCollection<SiteContent> Children
        {
            get
            {
                return ((global::System.Data.Objects.DataClasses.IEntityWithRelationships)(this)).RelationshipManager.GetRelatedCollection<SiteContent>("gbua_superiModel.FK_SiteContent_SiteContent", "SiteContent1");
            }
            set
            {
                if ((value != null))
                {
                    ((global::System.Data.Objects.DataClasses.IEntityWithRelationships)(this)).RelationshipManager.InitializeRelatedCollection<SiteContent>("gbua_superiModel.FK_SiteContent_SiteContent", "SiteContent1", value);
                }
            }
        }
        /// <summary>
        /// There are no comments for Parent in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmRelationshipNavigationPropertyAttribute("gbua_superiModel", "FK_SiteContent_SiteContent", "SiteContent")]
        [global::System.Xml.Serialization.XmlIgnoreAttribute()]
        [global::System.Xml.Serialization.SoapIgnoreAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public SiteContent Parent
        {
            get
            {
                return ((global::System.Data.Objects.DataClasses.IEntityWithRelationships)(this)).RelationshipManager.GetRelatedReference<SiteContent>("gbua_superiModel.FK_SiteContent_SiteContent", "SiteContent").Value;
            }
            set
            {
                ((global::System.Data.Objects.DataClasses.IEntityWithRelationships)(this)).RelationshipManager.GetRelatedReference<SiteContent>("gbua_superiModel.FK_SiteContent_SiteContent", "SiteContent").Value = value;
            }
        }
        /// <summary>
        /// There are no comments for Parent in the schema.
        /// </summary>
        [global::System.ComponentModel.BrowsableAttribute(false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Data.Objects.DataClasses.EntityReference<SiteContent> ParentReference
        {
            get
            {
                return ((global::System.Data.Objects.DataClasses.IEntityWithRelationships)(this)).RelationshipManager.GetRelatedReference<SiteContent>("gbua_superiModel.FK_SiteContent_SiteContent", "SiteContent");
            }
            set
            {
                if ((value != null))
                {
                    ((global::System.Data.Objects.DataClasses.IEntityWithRelationships)(this)).RelationshipManager.InitializeRelatedReference<SiteContent>("gbua_superiModel.FK_SiteContent_SiteContent", "SiteContent", value);
                }
            }
        }
    }
}
