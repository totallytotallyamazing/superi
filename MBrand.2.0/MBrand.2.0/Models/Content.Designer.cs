﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
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
#region Метаданные связи EDM

[assembly: EdmRelationshipAttribute("Content", "WorkGroupWork", "WorkGroup", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(MBrand.Models.WorkGroup), "Work", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(MBrand.Models.Work))]

#endregion

namespace MBrand.Models
{
    #region Контексты
    
    /// <summary>
    /// Нет доступной документации по метаданным.
    /// </summary>
    public partial class ContentContainer : ObjectContext
    {
        #region Конструкторы
    
        /// <summary>
        /// Инициализирует новый объект ContentContainer, используя строку соединения из раздела "ContentContainer" файла конфигурации приложения.
        /// </summary>
        public ContentContainer() : base("name=ContentContainer", "ContentContainer")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Инициализация нового объекта ContentContainer.
        /// </summary>
        public ContentContainer(string connectionString) : base(connectionString, "ContentContainer")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Инициализация нового объекта ContentContainer.
        /// </summary>
        public ContentContainer(EntityConnection connection) : base(connection, "ContentContainer")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Разделяемые методы
    
        partial void OnContextCreated();
    
        #endregion
    
        #region Свойства ObjectSet
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        public ObjectSet<Statement> Statements
        {
            get
            {
                if ((_Statements == null))
                {
                    _Statements = base.CreateObjectSet<Statement>("Statements");
                }
                return _Statements;
            }
        }
        private ObjectSet<Statement> _Statements;
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        public ObjectSet<Content> Contents
        {
            get
            {
                if ((_Contents == null))
                {
                    _Contents = base.CreateObjectSet<Content>("Contents");
                }
                return _Contents;
            }
        }
        private ObjectSet<Content> _Contents;

        #endregion
        #region Методы AddTo
    
        /// <summary>
        /// Устаревший метод для добавления новых объектов в набор EntitySet Statements. Взамен можно использовать метод .Add связанного свойства ObjectSet&lt;T&gt;.
        /// </summary>
        public void AddToStatements(Statement statement)
        {
            base.AddObject("Statements", statement);
        }
    
        /// <summary>
        /// Устаревший метод для добавления новых объектов в набор EntitySet Contents. Взамен можно использовать метод .Add связанного свойства ObjectSet&lt;T&gt;.
        /// </summary>
        public void AddToContents(Content content)
        {
            base.AddObject("Contents", content);
        }

        #endregion
    }
    

    #endregion
    
    #region Сущности
    
    /// <summary>
    /// Нет доступной документации по метаданным.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="Content", Name="Content")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    [KnownTypeAttribute(typeof(WorkGroup))]
    [KnownTypeAttribute(typeof(Work))]
    [KnownTypeAttribute(typeof(TextContent))]
    public partial class Content : EntityObject
    {
        #region Фабричный метод
    
        /// <summary>
        /// Создание нового объекта Content.
        /// </summary>
        /// <param name="id">Исходное значение свойства Id.</param>
        /// <param name="name">Исходное значение свойства Name.</param>
        /// <param name="title">Исходное значение свойства Title.</param>
        public static Content CreateContent(global::System.Int32 id, global::System.String name, global::System.String title)
        {
            Content content = new Content();
            content.Id = id;
            content.Name = name;
            content.Title = title;
            return content;
        }

        #endregion
        #region Свойства-примитивы
    
        /// <summary>
        /// Нет доступной документации по метаданным.
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
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Text
        {
            get
            {
                return _Text;
            }
            set
            {
                OnTextChanging(value);
                ReportPropertyChanging("Text");
                _Text = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Text");
                OnTextChanged();
            }
        }
        private global::System.String _Text;
        partial void OnTextChanging(global::System.String value);
        partial void OnTextChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
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
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
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
                _Title = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Title");
                OnTitleChanged();
            }
        }
        private global::System.String _Title;
        partial void OnTitleChanging(global::System.String value);
        partial void OnTitleChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String SeoDescription
        {
            get
            {
                return _SeoDescription;
            }
            set
            {
                OnSeoDescriptionChanging(value);
                ReportPropertyChanging("SeoDescription");
                _SeoDescription = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("SeoDescription");
                OnSeoDescriptionChanged();
            }
        }
        private global::System.String _SeoDescription;
        partial void OnSeoDescriptionChanging(global::System.String value);
        partial void OnSeoDescriptionChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String SeoKeywords
        {
            get
            {
                return _SeoKeywords;
            }
            set
            {
                OnSeoKeywordsChanging(value);
                ReportPropertyChanging("SeoKeywords");
                _SeoKeywords = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("SeoKeywords");
                OnSeoKeywordsChanged();
            }
        }
        private global::System.String _SeoKeywords;
        partial void OnSeoKeywordsChanging(global::System.String value);
        partial void OnSeoKeywordsChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
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

        #endregion
    
    }
    
    /// <summary>
    /// Нет доступной документации по метаданным.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="Content", Name="Statement")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Statement : EntityObject
    {
        #region Фабричный метод
    
        /// <summary>
        /// Создание нового объекта Statement.
        /// </summary>
        /// <param name="id">Исходное значение свойства Id.</param>
        /// <param name="text">Исходное значение свойства Text.</param>
        public static Statement CreateStatement(global::System.Int32 id, global::System.String text)
        {
            Statement statement = new Statement();
            statement.Id = id;
            statement.Text = text;
            return statement;
        }

        #endregion
        #region Свойства-примитивы
    
        /// <summary>
        /// Нет доступной документации по метаданным.
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
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Text
        {
            get
            {
                return _Text;
            }
            set
            {
                OnTextChanging(value);
                ReportPropertyChanging("Text");
                _Text = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Text");
                OnTextChanged();
            }
        }
        private global::System.String _Text;
        partial void OnTextChanging(global::System.String value);
        partial void OnTextChanged();

        #endregion
    
    }
    
    /// <summary>
    /// Нет доступной документации по метаданным.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="Content", Name="TextContent")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class TextContent : Content
    {
        #region Фабричный метод
    
        /// <summary>
        /// Создание нового объекта TextContent.
        /// </summary>
        /// <param name="id">Исходное значение свойства Id.</param>
        /// <param name="name">Исходное значение свойства Name.</param>
        /// <param name="title">Исходное значение свойства Title.</param>
        public static TextContent CreateTextContent(global::System.Int32 id, global::System.String name, global::System.String title)
        {
            TextContent textContent = new TextContent();
            textContent.Id = id;
            textContent.Name = name;
            textContent.Title = title;
            return textContent;
        }

        #endregion
    
    }
    
    /// <summary>
    /// Нет доступной документации по метаданным.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="Content", Name="Work")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Work : Content
    {
        #region Фабричный метод
    
        /// <summary>
        /// Создание нового объекта Work.
        /// </summary>
        /// <param name="id">Исходное значение свойства Id.</param>
        /// <param name="name">Исходное значение свойства Name.</param>
        /// <param name="title">Исходное значение свойства Title.</param>
        public static Work CreateWork(global::System.Int32 id, global::System.String name, global::System.String title)
        {
            Work work = new Work();
            work.Id = id;
            work.Name = name;
            work.Title = title;
            return work;
        }

        #endregion
        #region Свойства-примитивы
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Image
        {
            get
            {
                return _Image;
            }
            set
            {
                OnImageChanging(value);
                ReportPropertyChanging("Image");
                _Image = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Image");
                OnImageChanged();
            }
        }
        private global::System.String _Image;
        partial void OnImageChanging(global::System.String value);
        partial void OnImageChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String BottomImage
        {
            get
            {
                return _BottomImage;
            }
            set
            {
                OnBottomImageChanging(value);
                ReportPropertyChanging("BottomImage");
                _BottomImage = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("BottomImage");
                OnBottomImageChanged();
            }
        }
        private global::System.String _BottomImage;
        partial void OnBottomImageChanging(global::System.String value);
        partial void OnBottomImageChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String SideBarText
        {
            get
            {
                return _SideBarText;
            }
            set
            {
                OnSideBarTextChanging(value);
                ReportPropertyChanging("SideBarText");
                _SideBarText = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("SideBarText");
                OnSideBarTextChanged();
            }
        }
        private global::System.String _SideBarText;
        partial void OnSideBarTextChanging(global::System.String value);
        partial void OnSideBarTextChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> SortOrder
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
        private Nullable<global::System.Int32> _SortOrder;
        partial void OnSortOrderChanging(Nullable<global::System.Int32> value);
        partial void OnSortOrderChanged();

        #endregion
    
        #region Свойства навигации
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("Content", "WorkGroupWork", "WorkGroup")]
        public WorkGroup WorkGroup
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<WorkGroup>("Content.WorkGroupWork", "WorkGroup").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<WorkGroup>("Content.WorkGroupWork", "WorkGroup").Value = value;
            }
        }
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<WorkGroup> WorkGroupReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<WorkGroup>("Content.WorkGroupWork", "WorkGroup");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<WorkGroup>("Content.WorkGroupWork", "WorkGroup", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// Нет доступной документации по метаданным.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="Content", Name="WorkGroup")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class WorkGroup : Content
    {
        #region Фабричный метод
    
        /// <summary>
        /// Создание нового объекта WorkGroup.
        /// </summary>
        /// <param name="id">Исходное значение свойства Id.</param>
        /// <param name="name">Исходное значение свойства Name.</param>
        /// <param name="title">Исходное значение свойства Title.</param>
        public static WorkGroup CreateWorkGroup(global::System.Int32 id, global::System.String name, global::System.String title)
        {
            WorkGroup workGroup = new WorkGroup();
            workGroup.Id = id;
            workGroup.Name = name;
            workGroup.Title = title;
            return workGroup;
        }

        #endregion
        #region Свойства-примитивы
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> SortOrder
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
        private Nullable<global::System.Int32> _SortOrder;
        partial void OnSortOrderChanging(Nullable<global::System.Int32> value);
        partial void OnSortOrderChanged();

        #endregion
    
        #region Свойства навигации
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("Content", "WorkGroupWork", "Work")]
        public EntityCollection<Work> Works
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Work>("Content.WorkGroupWork", "Work");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Work>("Content.WorkGroupWork", "Work", value);
                }
            }
        }

        #endregion
    }

    #endregion
    
}