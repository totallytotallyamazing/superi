﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3082
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::System.Data.Objects.DataClasses.EdmSchemaAttribute()]

// Original file name:
// Generation date: 09/10/2009 14:25:15
namespace PolialClean.Models
{
    
    /// <summary>
    /// There are no comments for drozd_polialcleanEntities in the schema.
    /// </summary>
    public partial class drozd_polialcleanEntities : global::System.Data.Objects.ObjectContext
    {
        /// <summary>
        /// Initializes a new drozd_polialcleanEntities object using the connection string found in the 'drozd_polialcleanEntities' section of the application configuration file.
        /// </summary>
        public drozd_polialcleanEntities() : 
                base("name=drozd_polialcleanEntities", "drozd_polialcleanEntities")
        {
            this.OnContextCreated();
        }
        /// <summary>
        /// Initialize a new drozd_polialcleanEntities object.
        /// </summary>
        public drozd_polialcleanEntities(string connectionString) : 
                base(connectionString, "drozd_polialcleanEntities")
        {
            this.OnContextCreated();
        }
        /// <summary>
        /// Initialize a new drozd_polialcleanEntities object.
        /// </summary>
        public drozd_polialcleanEntities(global::System.Data.EntityClient.EntityConnection connection) : 
                base(connection, "drozd_polialcleanEntities")
        {
            this.OnContextCreated();
        }
        partial void OnContextCreated();
        /// <summary>
        /// There are no comments for Clients in the schema.
        /// </summary>
        public global::System.Data.Objects.ObjectQuery<Clients> Clients
        {
            get
            {
                if ((this._Clients == null))
                {
                    this._Clients = base.CreateQuery<Clients>("[Clients]");
                }
                return this._Clients;
            }
        }
        private global::System.Data.Objects.ObjectQuery<Clients> _Clients;
        /// <summary>
        /// There are no comments for Recomendations in the schema.
        /// </summary>
        public global::System.Data.Objects.ObjectQuery<Recomendations> Recomendations
        {
            get
            {
                if ((this._Recomendations == null))
                {
                    this._Recomendations = base.CreateQuery<Recomendations>("[Recomendations]");
                }
                return this._Recomendations;
            }
        }
        private global::System.Data.Objects.ObjectQuery<Recomendations> _Recomendations;
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
        /// There are no comments for Clients in the schema.
        /// </summary>
        public void AddToClients(Clients clients)
        {
            base.AddObject("Clients", clients);
        }
        /// <summary>
        /// There are no comments for Recomendations in the schema.
        /// </summary>
        public void AddToRecomendations(Recomendations recomendations)
        {
            base.AddObject("Recomendations", recomendations);
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
    /// There are no comments for DataStorage.Clients in the schema.
    /// </summary>
    /// <KeyProperties>
    /// Id
    /// </KeyProperties>
    [global::System.Data.Objects.DataClasses.EdmEntityTypeAttribute(NamespaceName="DataStorage", Name="Clients")]
    [global::System.Runtime.Serialization.DataContractAttribute(IsReference=true)]
    [global::System.Serializable()]
    public partial class Clients : global::System.Data.Objects.DataClasses.EntityObject
    {
        /// <summary>
        /// Create a new Clients object.
        /// </summary>
        /// <param name="id">Initial value of Id.</param>
        public static Clients CreateClients(int id)
        {
            Clients clients = new Clients();
            clients.Id = id;
            return clients;
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
        /// There are no comments for Property Name in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
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
                this._Name = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("Name");
                this.OnNameChanged();
            }
        }
        private string _Name;
        partial void OnNameChanging(string value);
        partial void OnNameChanged();
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
        /// There are no comments for Property Logo in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string Logo
        {
            get
            {
                return this._Logo;
            }
            set
            {
                this.OnLogoChanging(value);
                this.ReportPropertyChanging("Logo");
                this._Logo = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("Logo");
                this.OnLogoChanged();
            }
        }
        private string _Logo;
        partial void OnLogoChanging(string value);
        partial void OnLogoChanged();
    }
    /// <summary>
    /// There are no comments for DataStorage.Recomendations in the schema.
    /// </summary>
    /// <KeyProperties>
    /// Id
    /// </KeyProperties>
    [global::System.Data.Objects.DataClasses.EdmEntityTypeAttribute(NamespaceName="DataStorage", Name="Recomendations")]
    [global::System.Runtime.Serialization.DataContractAttribute(IsReference=true)]
    [global::System.Serializable()]
    public partial class Recomendations : global::System.Data.Objects.DataClasses.EntityObject
    {
        /// <summary>
        /// Create a new Recomendations object.
        /// </summary>
        /// <param name="id">Initial value of Id.</param>
        public static Recomendations CreateRecomendations(int id)
        {
            Recomendations recomendations = new Recomendations();
            recomendations.Id = id;
            return recomendations;
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
                this._Image = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("Image");
                this.OnImageChanged();
            }
        }
        private string _Image;
        partial void OnImageChanging(string value);
        partial void OnImageChanged();
        /// <summary>
        /// There are no comments for Property Preview in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string Preview
        {
            get
            {
                return this._Preview;
            }
            set
            {
                this.OnPreviewChanging(value);
                this.ReportPropertyChanging("Preview");
                this._Preview = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("Preview");
                this.OnPreviewChanged();
            }
        }
        private string _Preview;
        partial void OnPreviewChanging(string value);
        partial void OnPreviewChanged();
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
        /// There are no comments for Property Name in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
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
                this._Name = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("Name");
                this.OnNameChanged();
            }
        }
        private string _Name;
        partial void OnNameChanging(string value);
        partial void OnNameChanged();
    }
    /// <summary>
    /// There are no comments for DataStorage.SiteContent in the schema.
    /// </summary>
    /// <KeyProperties>
    /// Id
    /// </KeyProperties>
    [global::System.Data.Objects.DataClasses.EdmEntityTypeAttribute(NamespaceName="DataStorage", Name="SiteContent")]
    [global::System.Runtime.Serialization.DataContractAttribute(IsReference=true)]
    [global::System.Serializable()]
    public partial class SiteContent : global::System.Data.Objects.DataClasses.EntityObject
    {
        /// <summary>
        /// Create a new SiteContent object.
        /// </summary>
        /// <param name="id">Initial value of Id.</param>
        public static SiteContent CreateSiteContent(int id)
        {
            SiteContent siteContent = new SiteContent();
            siteContent.Id = id;
            return siteContent;
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
        /// There are no comments for Property Content in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string Content
        {
            get
            {
                return this._Content;
            }
            set
            {
                this.OnContentChanging(value);
                this.ReportPropertyChanging("Content");
                this._Content = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("Content");
                this.OnContentChanged();
            }
        }
        private string _Content;
        partial void OnContentChanging(string value);
        partial void OnContentChanged();
        /// <summary>
        /// There are no comments for Property ParentId in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Nullable<int> ParentId
        {
            get
            {
                return this._ParentId;
            }
            set
            {
                this.OnParentIdChanging(value);
                this.ReportPropertyChanging("ParentId");
                this._ParentId = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("ParentId");
                this.OnParentIdChanged();
            }
        }
        private global::System.Nullable<int> _ParentId;
        partial void OnParentIdChanging(global::System.Nullable<int> value);
        partial void OnParentIdChanged();
        /// <summary>
        /// There are no comments for Property Name in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
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
                this._Name = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("Name");
                this.OnNameChanged();
            }
        }
        private string _Name;
        partial void OnNameChanging(string value);
        partial void OnNameChanged();
    }
}
