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

[assembly: EdmRelationshipAttribute("shop_contentModel", "ContentContent", "Content", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(Shop.Models.Content), "Content1", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(Shop.Models.Content))]

#endregion

namespace Shop.Models
{
    #region Контексты
    
    /// <summary>
    /// Нет доступной документации по метаданным.
    /// </summary>
    public partial class ContentStorage : ObjectContext
    {
        #region Конструкторы
    
        /// <summary>
        /// Инициализирует новый объект ContentStorage, используя строку соединения из раздела "ContentStorage" файла конфигурации приложения.
        /// </summary>
        public ContentStorage() : base("name=ContentStorage", "ContentStorage")
        {
            OnContextCreated();
        }
    
        /// <summary>
        /// Инициализация нового объекта ContentStorage.
        /// </summary>
        public ContentStorage(string connectionString) : base(connectionString, "ContentStorage")
        {
            OnContextCreated();
        }
    
        /// <summary>
        /// Инициализация нового объекта ContentStorage.
        /// </summary>
        public ContentStorage(EntityConnection connection) : base(connection, "ContentStorage")
        {
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
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        public ObjectSet<Article> Articles
        {
            get
            {
                if ((_Articles == null))
                {
                    _Articles = base.CreateObjectSet<Article>("Articles");
                }
                return _Articles;
            }
        }
        private ObjectSet<Article> _Articles;

        #endregion
        #region Методы AddTo
    
        /// <summary>
        /// Устаревший метод для добавления новых объектов в набор EntitySet Contents. Взамен можно использовать метод .Add связанного свойства ObjectSet&lt;T&gt;.
        /// </summary>
        public void AddToContents(Content content)
        {
            base.AddObject("Contents", content);
        }
    
        /// <summary>
        /// Устаревший метод для добавления новых объектов в набор EntitySet Articles. Взамен можно использовать метод .Add связанного свойства ObjectSet&lt;T&gt;.
        /// </summary>
        public void AddToArticles(Article article)
        {
            base.AddObject("Articles", article);
        }

        #endregion
    }
    

    #endregion
    
    #region Сущности
    
    /// <summary>
    /// Нет доступной документации по метаданным.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="shop_contentModel", Name="Article")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Article : EntityObject
    {
        #region Фабричный метод
    
        /// <summary>
        /// Создание нового объекта Article.
        /// </summary>
        /// <param name="id">Исходное значение свойства Id.</param>
        /// <param name="date">Исходное значение свойства Date.</param>
        /// <param name="name">Исходное значение свойства Name.</param>
        /// <param name="title">Исходное значение свойства Title.</param>
        /// <param name="type">Исходное значение свойства Type.</param>
        public static Article CreateArticle(global::System.Int32 id, global::System.DateTime date, global::System.String name, global::System.String title, global::System.Int32 type)
        {
            Article article = new Article();
            article.Id = id;
            article.Date = date;
            article.Name = name;
            article.Title = title;
            article.Type = type;
            return article;
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
        public global::System.DateTime Date
        {
            get
            {
                return _Date;
            }
            set
            {
                OnDateChanging(value);
                ReportPropertyChanging("Date");
                _Date = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Date");
                OnDateChanged();
            }
        }
        private global::System.DateTime _Date;
        partial void OnDateChanging(global::System.DateTime value);
        partial void OnDateChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Keywords
        {
            get
            {
                return _Keywords;
            }
            set
            {
                OnKeywordsChanging(value);
                ReportPropertyChanging("Keywords");
                _Keywords = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Keywords");
                OnKeywordsChanged();
            }
        }
        private global::System.String _Keywords;
        partial void OnKeywordsChanging(global::System.String value);
        partial void OnKeywordsChanged();
    
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
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Language
        {
            get
            {
                return _Language;
            }
            set
            {
                OnLanguageChanging(value);
                ReportPropertyChanging("Language");
                _Language = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Language");
                OnLanguageChanged();
            }
        }
        private global::System.String _Language;
        partial void OnLanguageChanging(global::System.String value);
        partial void OnLanguageChanged();
    
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
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Preview
        {
            get
            {
                return _Preview;
            }
            set
            {
                OnPreviewChanging(value);
                ReportPropertyChanging("Preview");
                _Preview = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Preview");
                OnPreviewChanged();
            }
        }
        private global::System.String _Preview;
        partial void OnPreviewChanging(global::System.String value);
        partial void OnPreviewChanged();
    
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
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Type
        {
            get
            {
                return _Type;
            }
            set
            {
                OnTypeChanging(value);
                ReportPropertyChanging("Type");
                _Type = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Type");
                OnTypeChanged();
            }
        }
        private global::System.Int32 _Type;
        partial void OnTypeChanging(global::System.Int32 value);
        partial void OnTypeChanged();

        #endregion
    
    }
    
    /// <summary>
    /// Нет доступной документации по метаданным.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="shop_contentModel", Name="Content")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Content : EntityObject
    {
        #region Фабричный метод
    
        /// <summary>
        /// Создание нового объекта Content.
        /// </summary>
        /// <param name="id">Исходное значение свойства Id.</param>
        /// <param name="name">Исходное значение свойства Name.</param>
        public static Content CreateContent(global::System.Int32 id, global::System.String name)
        {
            Content content = new Content();
            content.Id = id;
            content.Name = name;
            return content;
        }

        #endregion
        #region Свойства-примитивы
    
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
        public global::System.String Keywords
        {
            get
            {
                return _Keywords;
            }
            set
            {
                OnKeywordsChanging(value);
                ReportPropertyChanging("Keywords");
                _Keywords = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Keywords");
                OnKeywordsChanged();
            }
        }
        private global::System.String _Keywords;
        partial void OnKeywordsChanging(global::System.String value);
        partial void OnKeywordsChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Language
        {
            get
            {
                return _Language;
            }
            set
            {
                OnLanguageChanging(value);
                ReportPropertyChanging("Language");
                _Language = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Language");
                OnLanguageChanged();
            }
        }
        private global::System.String _Language;
        partial void OnLanguageChanging(global::System.String value);
        partial void OnLanguageChanged();
    
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

        #endregion
    
        #region Свойства навигации
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("shop_contentModel", "ContentContent", "Content1")]
        public EntityCollection<Content> Parent
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Content>("shop_contentModel.ContentContent", "Content1");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Content>("shop_contentModel.ContentContent", "Content1", value);
                }
            }
        }
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("shop_contentModel", "ContentContent", "Content")]
        public Content Children
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Content>("shop_contentModel.ContentContent", "Content").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Content>("shop_contentModel.ContentContent", "Content").Value = value;
            }
        }
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Content> ChildrenReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Content>("shop_contentModel.ContentContent", "Content");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Content>("shop_contentModel.ContentContent", "Content", value);
                }
            }
        }

        #endregion
    }

    #endregion
    
}
