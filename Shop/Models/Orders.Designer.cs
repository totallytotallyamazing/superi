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

[assembly: EdmRelationshipAttribute("shop_Orders", "OrderOrderItem", "Order", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(Shop.Models.Order), "OrderItem", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(Shop.Models.OrderItem))]

#endregion

namespace Shop.Models
{
    #region Контексты
    
    /// <summary>
    /// Нет доступной документации по метаданным.
    /// </summary>
    public partial class OrdersStorage : ObjectContext
    {
        #region Конструкторы
    
        /// <summary>
        /// Инициализирует новый объект OrdersStorage, используя строку соединения из раздела "OrdersStorage" файла конфигурации приложения.
        /// </summary>
        public OrdersStorage() : base("name=OrdersStorage", "OrdersStorage")
        {
            OnContextCreated();
        }
    
        /// <summary>
        /// Инициализация нового объекта OrdersStorage.
        /// </summary>
        public OrdersStorage(string connectionString) : base(connectionString, "OrdersStorage")
        {
            OnContextCreated();
        }
    
        /// <summary>
        /// Инициализация нового объекта OrdersStorage.
        /// </summary>
        public OrdersStorage(EntityConnection connection) : base(connection, "OrdersStorage")
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
        public ObjectSet<Order> Orders
        {
            get
            {
                if ((_Orders == null))
                {
                    _Orders = base.CreateObjectSet<Order>("Orders");
                }
                return _Orders;
            }
        }
        private ObjectSet<Order> _Orders;
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        public ObjectSet<OrderItem> OrderItems
        {
            get
            {
                if ((_OrderItems == null))
                {
                    _OrderItems = base.CreateObjectSet<OrderItem>("OrderItems");
                }
                return _OrderItems;
            }
        }
        private ObjectSet<OrderItem> _OrderItems;

        #endregion
        #region Методы AddTo
    
        /// <summary>
        /// Устаревший метод для добавления новых объектов в набор EntitySet Orders. Взамен можно использовать метод .Add связанного свойства ObjectSet&lt;T&gt;.
        /// </summary>
        public void AddToOrders(Order order)
        {
            base.AddObject("Orders", order);
        }
    
        /// <summary>
        /// Устаревший метод для добавления новых объектов в набор EntitySet OrderItems. Взамен можно использовать метод .Add связанного свойства ObjectSet&lt;T&gt;.
        /// </summary>
        public void AddToOrderItems(OrderItem orderItem)
        {
            base.AddObject("OrderItems", orderItem);
        }

        #endregion
    }
    

    #endregion
    
    #region Сущности
    
    /// <summary>
    /// Нет доступной документации по метаданным.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="shop_Orders", Name="Order")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Order : EntityObject
    {
        #region Фабричный метод
    
        /// <summary>
        /// Создание нового объекта Order.
        /// </summary>
        /// <param name="id">Исходное значение свойства Id.</param>
        public static Order CreateOrder(global::System.Int32 id)
        {
            Order order = new Order();
            order.Id = id;
            return order;
        }

        #endregion
        #region Свойства-примитивы
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String AdditionalDeliveryInfo
        {
            get
            {
                return _AdditionalDeliveryInfo;
            }
            set
            {
                OnAdditionalDeliveryInfoChanging(value);
                ReportPropertyChanging("AdditionalDeliveryInfo");
                _AdditionalDeliveryInfo = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("AdditionalDeliveryInfo");
                OnAdditionalDeliveryInfoChanged();
            }
        }
        private global::System.String _AdditionalDeliveryInfo;
        partial void OnAdditionalDeliveryInfoChanging(global::System.String value);
        partial void OnAdditionalDeliveryInfoChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String AdditionalProperties
        {
            get
            {
                return _AdditionalProperties;
            }
            set
            {
                OnAdditionalPropertiesChanging(value);
                ReportPropertyChanging("AdditionalProperties");
                _AdditionalProperties = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("AdditionalProperties");
                OnAdditionalPropertiesChanged();
            }
        }
        private global::System.String _AdditionalProperties;
        partial void OnAdditionalPropertiesChanging(global::System.String value);
        partial void OnAdditionalPropertiesChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String BillingEmail
        {
            get
            {
                return _BillingEmail;
            }
            set
            {
                OnBillingEmailChanging(value);
                ReportPropertyChanging("BillingEmail");
                _BillingEmail = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("BillingEmail");
                OnBillingEmailChanged();
            }
        }
        private global::System.String _BillingEmail;
        partial void OnBillingEmailChanging(global::System.String value);
        partial void OnBillingEmailChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String BillingName
        {
            get
            {
                return _BillingName;
            }
            set
            {
                OnBillingNameChanging(value);
                ReportPropertyChanging("BillingName");
                _BillingName = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("BillingName");
                OnBillingNameChanged();
            }
        }
        private global::System.String _BillingName;
        partial void OnBillingNameChanging(global::System.String value);
        partial void OnBillingNameChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String BillingPhone
        {
            get
            {
                return _BillingPhone;
            }
            set
            {
                OnBillingPhoneChanging(value);
                ReportPropertyChanging("BillingPhone");
                _BillingPhone = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("BillingPhone");
                OnBillingPhoneChanged();
            }
        }
        private global::System.String _BillingPhone;
        partial void OnBillingPhoneChanging(global::System.String value);
        partial void OnBillingPhoneChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String DeliveryAddress
        {
            get
            {
                return _DeliveryAddress;
            }
            set
            {
                OnDeliveryAddressChanging(value);
                ReportPropertyChanging("DeliveryAddress");
                _DeliveryAddress = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("DeliveryAddress");
                OnDeliveryAddressChanged();
            }
        }
        private global::System.String _DeliveryAddress;
        partial void OnDeliveryAddressChanging(global::System.String value);
        partial void OnDeliveryAddressChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String DeliveryName
        {
            get
            {
                return _DeliveryName;
            }
            set
            {
                OnDeliveryNameChanging(value);
                ReportPropertyChanging("DeliveryName");
                _DeliveryName = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("DeliveryName");
                OnDeliveryNameChanged();
            }
        }
        private global::System.String _DeliveryName;
        partial void OnDeliveryNameChanging(global::System.String value);
        partial void OnDeliveryNameChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String DeliveryPhone
        {
            get
            {
                return _DeliveryPhone;
            }
            set
            {
                OnDeliveryPhoneChanging(value);
                ReportPropertyChanging("DeliveryPhone");
                _DeliveryPhone = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("DeliveryPhone");
                OnDeliveryPhoneChanged();
            }
        }
        private global::System.String _DeliveryPhone;
        partial void OnDeliveryPhoneChanging(global::System.String value);
        partial void OnDeliveryPhoneChanged();
    
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

        #endregion
    
        #region Свойства навигации
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("shop_Orders", "OrderOrderItem", "OrderItem")]
        public EntityCollection<OrderItem> OrderItems
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<OrderItem>("shop_Orders.OrderOrderItem", "OrderItem");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<OrderItem>("shop_Orders.OrderOrderItem", "OrderItem", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// Нет доступной документации по метаданным.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="shop_Orders", Name="OrderItem")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class OrderItem : EntityObject
    {
        #region Фабричный метод
    
        /// <summary>
        /// Создание нового объекта OrderItem.
        /// </summary>
        /// <param name="id">Исходное значение свойства Id.</param>
        /// <param name="price">Исходное значение свойства Price.</param>
        /// <param name="productId">Исходное значение свойства ProductId.</param>
        /// <param name="quantity">Исходное значение свойства Quantity.</param>
        public static OrderItem CreateOrderItem(global::System.Int32 id, global::System.Single price, global::System.Int32 productId, global::System.Int32 quantity)
        {
            OrderItem orderItem = new OrderItem();
            orderItem.Id = id;
            orderItem.Price = price;
            orderItem.ProductId = productId;
            orderItem.Quantity = quantity;
            return orderItem;
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
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Single Price
        {
            get
            {
                return _Price;
            }
            set
            {
                OnPriceChanging(value);
                ReportPropertyChanging("Price");
                _Price = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Price");
                OnPriceChanged();
            }
        }
        private global::System.Single _Price;
        partial void OnPriceChanging(global::System.Single value);
        partial void OnPriceChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String ProductAttributes
        {
            get
            {
                return _ProductAttributes;
            }
            set
            {
                OnProductAttributesChanging(value);
                ReportPropertyChanging("ProductAttributes");
                _ProductAttributes = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("ProductAttributes");
                OnProductAttributesChanged();
            }
        }
        private global::System.String _ProductAttributes;
        partial void OnProductAttributesChanging(global::System.String value);
        partial void OnProductAttributesChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 ProductId
        {
            get
            {
                return _ProductId;
            }
            set
            {
                OnProductIdChanging(value);
                ReportPropertyChanging("ProductId");
                _ProductId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ProductId");
                OnProductIdChanged();
            }
        }
        private global::System.Int32 _ProductId;
        partial void OnProductIdChanging(global::System.Int32 value);
        partial void OnProductIdChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Quantity
        {
            get
            {
                return _Quantity;
            }
            set
            {
                OnQuantityChanging(value);
                ReportPropertyChanging("Quantity");
                _Quantity = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Quantity");
                OnQuantityChanged();
            }
        }
        private global::System.Int32 _Quantity;
        partial void OnQuantityChanging(global::System.Int32 value);
        partial void OnQuantityChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
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
                _Name = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Name");
                OnNameChanged();
            }
        }
        private global::System.String _Name;
        partial void OnNameChanging(global::System.String value);
        partial void OnNameChanged();

        #endregion
    
        #region Свойства навигации
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("shop_Orders", "OrderOrderItem", "Order")]
        public Order Order
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Order>("shop_Orders.OrderOrderItem", "Order").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Order>("shop_Orders.OrderOrderItem", "Order").Value = value;
            }
        }
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Order> OrderReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Order>("shop_Orders.OrderOrderItem", "Order");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Order>("shop_Orders.OrderOrderItem", "Order", value);
                }
            }
        }

        #endregion
    }

    #endregion
    
}