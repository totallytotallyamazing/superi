﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]
#region EDM Relationship Metadata

[assembly: EdmRelationshipAttribute("gb_listelliModel", "FK_DesignerContent_Designer", "Designer", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(Shop.Models.Designer), "DesignerContent", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(Shop.Models.DesignerContent), true)]
[assembly: EdmRelationshipAttribute("gb_listelliModel", "FK_DesignerContentImages_DesignerContent", "DesignerContent", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(Shop.Models.DesignerContent), "DesignerContentImages", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(Shop.Models.DesignerContentImages), true)]

#endregion

namespace Shop.Models
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class DesignerStorage : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new DesignerStorage object using the connection string found in the 'DesignerStorage' section of the application configuration file.
        /// </summary>
        public DesignerStorage() : base("name=DesignerStorage", "DesignerStorage")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new DesignerStorage object.
        /// </summary>
        public DesignerStorage(string connectionString) : base(connectionString, "DesignerStorage")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new DesignerStorage object.
        /// </summary>
        public DesignerStorage(EntityConnection connection) : base(connection, "DesignerStorage")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Designer> Designer
        {
            get
            {
                if ((_Designer == null))
                {
                    _Designer = base.CreateObjectSet<Designer>("Designer");
                }
                return _Designer;
            }
        }
        private ObjectSet<Designer> _Designer;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<DesignerContent> DesignerContent
        {
            get
            {
                if ((_DesignerContent == null))
                {
                    _DesignerContent = base.CreateObjectSet<DesignerContent>("DesignerContent");
                }
                return _DesignerContent;
            }
        }
        private ObjectSet<DesignerContent> _DesignerContent;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<DesignerContentImages> DesignerContentImages
        {
            get
            {
                if ((_DesignerContentImages == null))
                {
                    _DesignerContentImages = base.CreateObjectSet<DesignerContentImages>("DesignerContentImages");
                }
                return _DesignerContentImages;
            }
        }
        private ObjectSet<DesignerContentImages> _DesignerContentImages;

        #endregion
        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Designer EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToDesigner(Designer designer)
        {
            base.AddObject("Designer", designer);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the DesignerContent EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToDesignerContent(DesignerContent designerContent)
        {
            base.AddObject("DesignerContent", designerContent);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the DesignerContentImages EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToDesignerContentImages(DesignerContentImages designerContentImages)
        {
            base.AddObject("DesignerContentImages", designerContentImages);
        }

        #endregion
    }
    

    #endregion
    
    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="gb_listelliModel", Name="Designer")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Designer : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Designer object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        /// <param name="name">Initial value of the Name property.</param>
        /// <param name="url">Initial value of the Url property.</param>
        /// <param name="nameF">Initial value of the NameF property.</param>
        public static Designer CreateDesigner(global::System.Int32 id, global::System.String name, global::System.String url, global::System.String nameF)
        {
            Designer designer = new Designer();
            designer.Id = id;
            designer.Name = name;
            designer.Url = url;
            designer.NameF = nameF;
            return designer;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                OnNameChanging(value);
                ReportPropertyChanging("Name");
                _Name = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Name");
                OnNameChanged();
            }
        }
        private global::System.String _Name;
        partial void OnNameChanging(global::System.String value);
        partial void OnNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Url
        {
            get
            {
                return _Url;
            }
            set
            {
                OnUrlChanging(value);
                ReportPropertyChanging("Url");
                _Url = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Url");
                OnUrlChanged();
            }
        }
        private global::System.String _Url;
        partial void OnUrlChanging(global::System.String value);
        partial void OnUrlChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Title
        {
            get
            {
                return _Title;
            }
            set
            {
                OnTitleChanging(value);
                ReportPropertyChanging("Title");
                _Title = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Title");
                OnTitleChanged();
            }
        }
        private global::System.String _Title;
        partial void OnTitleChanging(global::System.String value);
        partial void OnTitleChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Summary
        {
            get
            {
                return _Summary;
            }
            set
            {
                OnSummaryChanging(value);
                ReportPropertyChanging("Summary");
                _Summary = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Summary");
                OnSummaryChanged();
            }
        }
        private global::System.String _Summary;
        partial void OnSummaryChanging(global::System.String value);
        partial void OnSummaryChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Logo
        {
            get
            {
                return _Logo;
            }
            set
            {
                OnLogoChanging(value);
                ReportPropertyChanging("Logo");
                _Logo = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Logo");
                OnLogoChanged();
            }
        }
        private global::System.String _Logo;
        partial void OnLogoChanging(global::System.String value);
        partial void OnLogoChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String NameF
        {
            get
            {
                return _NameF;
            }
            set
            {
                OnNameFChanging(value);
                ReportPropertyChanging("NameF");
                _NameF = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("NameF");
                OnNameFChanged();
            }
        }
        private global::System.String _NameF;
        partial void OnNameFChanging(global::System.String value);
        partial void OnNameFChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Room1
        {
            get
            {
                return _Room1;
            }
            set
            {
                OnRoom1Changing(value);
                ReportPropertyChanging("Room1");
                _Room1 = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Room1");
                OnRoom1Changed();
            }
        }
        private global::System.String _Room1;
        partial void OnRoom1Changing(global::System.String value);
        partial void OnRoom1Changed();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Room0
        {
            get
            {
                return _Room0;
            }
            set
            {
                OnRoom0Changing(value);
                ReportPropertyChanging("Room0");
                _Room0 = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Room0");
                OnRoom0Changed();
            }
        }
        private global::System.String _Room0;
        partial void OnRoom0Changing(global::System.String value);
        partial void OnRoom0Changed();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("gb_listelliModel", "FK_DesignerContent_Designer", "DesignerContent")]
        public EntityCollection<DesignerContent> DesignerContent
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<DesignerContent>("gb_listelliModel.FK_DesignerContent_Designer", "DesignerContent");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<DesignerContent>("gb_listelliModel.FK_DesignerContent_Designer", "DesignerContent", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="gb_listelliModel", Name="DesignerContent")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class DesignerContent : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new DesignerContent object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        /// <param name="designerId">Initial value of the DesignerId property.</param>
        public static DesignerContent CreateDesignerContent(global::System.Int32 id, global::System.Int32 designerId)
        {
            DesignerContent designerContent = new DesignerContent();
            designerContent.Id = id;
            designerContent.DesignerId = designerId;
            return designerContent;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 DesignerId
        {
            get
            {
                return _DesignerId;
            }
            set
            {
                OnDesignerIdChanging(value);
                ReportPropertyChanging("DesignerId");
                _DesignerId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("DesignerId");
                OnDesignerIdChanged();
            }
        }
        private global::System.Int32 _DesignerId;
        partial void OnDesignerIdChanging(global::System.Int32 value);
        partial void OnDesignerIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Summary
        {
            get
            {
                return _Summary;
            }
            set
            {
                OnSummaryChanging(value);
                ReportPropertyChanging("Summary");
                _Summary = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Summary");
                OnSummaryChanged();
            }
        }
        private global::System.String _Summary;
        partial void OnSummaryChanging(global::System.String value);
        partial void OnSummaryChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String RoomName
        {
            get
            {
                return _RoomName;
            }
            set
            {
                OnRoomNameChanging(value);
                ReportPropertyChanging("RoomName");
                _RoomName = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("RoomName");
                OnRoomNameChanged();
            }
        }
        private global::System.String _RoomName;
        partial void OnRoomNameChanging(global::System.String value);
        partial void OnRoomNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int16> RoomType
        {
            get
            {
                return _RoomType;
            }
            set
            {
                OnRoomTypeChanging(value);
                ReportPropertyChanging("RoomType");
                _RoomType = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("RoomType");
                OnRoomTypeChanged();
            }
        }
        private Nullable<global::System.Int16> _RoomType;
        partial void OnRoomTypeChanging(Nullable<global::System.Int16> value);
        partial void OnRoomTypeChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("gb_listelliModel", "FK_DesignerContent_Designer", "Designer")]
        public Designer Designer
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Designer>("gb_listelliModel.FK_DesignerContent_Designer", "Designer").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Designer>("gb_listelliModel.FK_DesignerContent_Designer", "Designer").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Designer> DesignerReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Designer>("gb_listelliModel.FK_DesignerContent_Designer", "Designer");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Designer>("gb_listelliModel.FK_DesignerContent_Designer", "Designer", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("gb_listelliModel", "FK_DesignerContentImages_DesignerContent", "DesignerContentImages")]
        public EntityCollection<DesignerContentImages> DesignerContentImages
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<DesignerContentImages>("gb_listelliModel.FK_DesignerContentImages_DesignerContent", "DesignerContentImages");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<DesignerContentImages>("gb_listelliModel.FK_DesignerContentImages_DesignerContent", "DesignerContentImages", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="gb_listelliModel", Name="DesignerContentImages")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class DesignerContentImages : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new DesignerContentImages object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        /// <param name="designerContentId">Initial value of the DesignerContentId property.</param>
        /// <param name="imageSource">Initial value of the ImageSource property.</param>
        /// <param name="sortOrder">Initial value of the SortOrder property.</param>
        public static DesignerContentImages CreateDesignerContentImages(global::System.Int32 id, global::System.Int32 designerContentId, global::System.String imageSource, global::System.Int32 sortOrder)
        {
            DesignerContentImages designerContentImages = new DesignerContentImages();
            designerContentImages.Id = id;
            designerContentImages.DesignerContentId = designerContentId;
            designerContentImages.ImageSource = imageSource;
            designerContentImages.SortOrder = sortOrder;
            return designerContentImages;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 DesignerContentId
        {
            get
            {
                return _DesignerContentId;
            }
            set
            {
                OnDesignerContentIdChanging(value);
                ReportPropertyChanging("DesignerContentId");
                _DesignerContentId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("DesignerContentId");
                OnDesignerContentIdChanged();
            }
        }
        private global::System.Int32 _DesignerContentId;
        partial void OnDesignerContentIdChanging(global::System.Int32 value);
        partial void OnDesignerContentIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String ImageSource
        {
            get
            {
                return _ImageSource;
            }
            set
            {
                OnImageSourceChanging(value);
                ReportPropertyChanging("ImageSource");
                _ImageSource = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("ImageSource");
                OnImageSourceChanged();
            }
        }
        private global::System.String _ImageSource;
        partial void OnImageSourceChanging(global::System.String value);
        partial void OnImageSourceChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Description
        {
            get
            {
                return _Description;
            }
            set
            {
                OnDescriptionChanging(value);
                ReportPropertyChanging("Description");
                _Description = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Description");
                OnDescriptionChanged();
            }
        }
        private global::System.String _Description;
        partial void OnDescriptionChanging(global::System.String value);
        partial void OnDescriptionChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 SortOrder
        {
            get
            {
                return _SortOrder;
            }
            set
            {
                OnSortOrderChanging(value);
                ReportPropertyChanging("SortOrder");
                _SortOrder = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("SortOrder");
                OnSortOrderChanged();
            }
        }
        private global::System.Int32 _SortOrder;
        partial void OnSortOrderChanging(global::System.Int32 value);
        partial void OnSortOrderChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("gb_listelliModel", "FK_DesignerContentImages_DesignerContent", "DesignerContent")]
        public DesignerContent DesignerContent
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<DesignerContent>("gb_listelliModel.FK_DesignerContentImages_DesignerContent", "DesignerContent").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<DesignerContent>("gb_listelliModel.FK_DesignerContentImages_DesignerContent", "DesignerContent").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<DesignerContent> DesignerContentReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<DesignerContent>("gb_listelliModel.FK_DesignerContentImages_DesignerContent", "DesignerContent");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<DesignerContent>("gb_listelliModel.FK_DesignerContentImages_DesignerContent", "DesignerContent", value);
                }
            }
        }

        #endregion
    }

    #endregion
    
}
