﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

[assembly: EdmSchemaAttribute()]
namespace Shop.Models
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class Clients : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new Clients object using the connection string found in the 'Clients' section of the application configuration file.
        /// </summary>
        public Clients() : base("name=Clients", "Clients")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new Clients object.
        /// </summary>
        public Clients(string connectionString) : base(connectionString, "Clients")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new Clients object.
        /// </summary>
        public Clients(EntityConnection connection) : base(connection, "Clients")
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
        public ObjectSet<Subscriber> Subscribers
        {
            get
            {
                if ((_Subscribers == null))
                {
                    _Subscribers = base.CreateObjectSet<Subscriber>("Subscribers");
                }
                return _Subscribers;
            }
        }
        private ObjectSet<Subscriber> _Subscribers;

        #endregion

        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Subscribers EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToSubscribers(Subscriber subscriber)
        {
            base.AddObject("Subscribers", subscriber);
        }

        #endregion

    }

    #endregion

    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="shop_subscribersModel", Name="Subscriber")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Subscriber : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Subscriber object.
        /// </summary>
        /// <param name="email">Initial value of the Email property.</param>
        /// <param name="uniqueId">Initial value of the UniqueId property.</param>
        /// <param name="isActive">Initial value of the IsActive property.</param>
        public static Subscriber CreateSubscriber(global::System.String email, global::System.Guid uniqueId, global::System.Boolean isActive)
        {
            Subscriber subscriber = new Subscriber();
            subscriber.Email = email;
            subscriber.UniqueId = uniqueId;
            subscriber.IsActive = isActive;
            return subscriber;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
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
        /// No Metadata Documentation available.
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
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Boolean IsActive
        {
            get
            {
                return _IsActive;
            }
            set
            {
                OnIsActiveChanging(value);
                ReportPropertyChanging("IsActive");
                _IsActive = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("IsActive");
                OnIsActiveChanged();
            }
        }
        private global::System.Boolean _IsActive;
        partial void OnIsActiveChanging(global::System.Boolean value);
        partial void OnIsActiveChanged();

        #endregion

    
    }

    #endregion

    
}
