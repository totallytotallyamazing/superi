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

namespace Shop.Models
{
    #region Контексты
    
    /// <summary>
    /// Нет доступной документации по метаданным.
    /// </summary>
    public partial class Clients : ObjectContext
    {
        #region Конструкторы
    
        /// <summary>
        /// Инициализирует новый объект Clients, используя строку соединения из раздела "Clients" файла конфигурации приложения.
        /// </summary>
        public Clients() : base("name=Clients", "Clients")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Инициализация нового объекта Clients.
        /// </summary>
        public Clients(string connectionString) : base(connectionString, "Clients")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Инициализация нового объекта Clients.
        /// </summary>
        public Clients(EntityConnection connection) : base(connection, "Clients")
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
        public ObjectSet<Subscribers> Subscribers
        {
            get
            {
                if ((_Subscribers == null))
                {
                    _Subscribers = base.CreateObjectSet<Subscribers>("Subscribers");
                }
                return _Subscribers;
            }
        }
        private ObjectSet<Subscribers> _Subscribers;

        #endregion
        #region Методы AddTo
    
        /// <summary>
        /// Устаревший метод для добавления новых объектов в набор EntitySet Subscribers. Взамен можно использовать метод .Add связанного свойства ObjectSet&lt;T&gt;.
        /// </summary>
        public void AddToSubscribers(Subscribers subscribers)
        {
            base.AddObject("Subscribers", subscribers);
        }

        #endregion
    }
    

    #endregion
    
    #region Сущности
    
    /// <summary>
    /// Нет доступной документации по метаданным.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="shop_subscribersModel", Name="Subscribers")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Subscribers : EntityObject
    {
        #region Фабричный метод
    
        /// <summary>
        /// Создание нового объекта Subscribers.
        /// </summary>
        /// <param name="email">Исходное значение свойства Email.</param>
        /// <param name="uniqueId">Исходное значение свойства UniqueId.</param>
        public static Subscribers CreateSubscribers(global::System.String email, global::System.Guid uniqueId)
        {
            Subscribers subscribers = new Subscribers();
            subscribers.Email = email;
            subscribers.UniqueId = uniqueId;
            return subscribers;
        }

        #endregion
        #region Свойства-примитивы
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Email
        {
            get
            {
                return _Email;
            }
            set
            {
                if (_Email != value)
                {
                    OnEmailChanging(value);
                    ReportPropertyChanging("Email");
                    _Email = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("Email");
                    OnEmailChanged();
                }
            }
        }
        private global::System.String _Email;
        partial void OnEmailChanging(global::System.String value);
        partial void OnEmailChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid UniqueId
        {
            get
            {
                return _UniqueId;
            }
            set
            {
                OnUniqueIdChanging(value);
                ReportPropertyChanging("UniqueId");
                _UniqueId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("UniqueId");
                OnUniqueIdChanged();
            }
        }
        private global::System.Guid _UniqueId;
        partial void OnUniqueIdChanging(global::System.Guid value);
        partial void OnUniqueIdChanged();

        #endregion
    
    }

    #endregion
    
}
