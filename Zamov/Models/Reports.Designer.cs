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

// Original file name:
// Generation date: 08/02/2010 12:11:57
namespace Zamov.Models
{
    
    /// <summary>
    /// There are no comments for Reports in the schema.
    /// </summary>
    public partial class Reports : global::System.Data.Objects.ObjectContext
    {
        /// <summary>
        /// Initializes a new Reports object using the connection string found in the 'Reports' section of the application configuration file.
        /// </summary>
        public Reports() : 
                base("name=Reports", "Reports")
        {
            this.OnContextCreated();
        }
        /// <summary>
        /// Initialize a new Reports object.
        /// </summary>
        public Reports(string connectionString) : 
                base(connectionString, "Reports")
        {
            this.OnContextCreated();
        }
        /// <summary>
        /// Initialize a new Reports object.
        /// </summary>
        public Reports(global::System.Data.EntityClient.EntityConnection connection) : 
                base(connection, "Reports")
        {
            this.OnContextCreated();
        }
        partial void OnContextCreated();
        /// <summary>
        /// There are no comments for SalesReport in the schema.
        /// </summary>
        public global::System.Data.Objects.ObjectQuery<SalesReportItem> SalesReport
        {
            get
            {
                if ((this._SalesReport == null))
                {
                    this._SalesReport = base.CreateQuery<SalesReportItem>("[SalesReport]");
                }
                return this._SalesReport;
            }
        }
        private global::System.Data.Objects.ObjectQuery<SalesReportItem> _SalesReport;
        /// <summary>
        /// There are no comments for SalesReport in the schema.
        /// </summary>
        public void AddToSalesReport(SalesReportItem salesReportItem)
        {
            base.AddObject("SalesReport", salesReportItem);
        }
    }
    /// <summary>
    /// There are no comments for BaseEntities.SalesReportItem in the schema.
    /// </summary>
    /// <KeyProperties>
    /// OrderId
    /// </KeyProperties>
    [global::System.Data.Objects.DataClasses.EdmEntityTypeAttribute(NamespaceName="BaseEntities", Name="SalesReportItem")]
    [global::System.Runtime.Serialization.DataContractAttribute(IsReference=true)]
    [global::System.Serializable()]
    public partial class SalesReportItem : global::System.Data.Objects.DataClasses.EntityObject
    {
        /// <summary>
        /// Create a new SalesReportItem object.
        /// </summary>
        /// <param name="orderId">Initial value of OrderId.</param>
        /// <param name="userName">Initial value of UserName.</param>
        /// <param name="email">Initial value of Email.</param>
        public static SalesReportItem CreateSalesReportItem(int orderId, string userName, string email)
        {
            SalesReportItem salesReportItem = new SalesReportItem();
            salesReportItem.OrderId = orderId;
            salesReportItem.UserName = userName;
            salesReportItem.Email = email;
            return salesReportItem;
        }
        /// <summary>
        /// There are no comments for Property DealerId in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Nullable<int> DealerId
        {
            get
            {
                return this._DealerId;
            }
            set
            {
                this.OnDealerIdChanging(value);
                this.ReportPropertyChanging("DealerId");
                this._DealerId = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("DealerId");
                this.OnDealerIdChanged();
            }
        }
        private global::System.Nullable<int> _DealerId;
        partial void OnDealerIdChanging(global::System.Nullable<int> value);
        partial void OnDealerIdChanged();
        /// <summary>
        /// There are no comments for Property DealerName in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string DealerName
        {
            get
            {
                return this._DealerName;
            }
            set
            {
                this.OnDealerNameChanging(value);
                this.ReportPropertyChanging("DealerName");
                this._DealerName = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("DealerName");
                this.OnDealerNameChanged();
            }
        }
        private string _DealerName;
        partial void OnDealerNameChanging(string value);
        partial void OnDealerNameChanged();
        /// <summary>
        /// There are no comments for Property OrderId in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public int OrderId
        {
            get
            {
                return this._OrderId;
            }
            set
            {
                this.OnOrderIdChanging(value);
                this.ReportPropertyChanging("OrderId");
                this._OrderId = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("OrderId");
                this.OnOrderIdChanged();
            }
        }
        private int _OrderId;
        partial void OnOrderIdChanging(int value);
        partial void OnOrderIdChanged();
        /// <summary>
        /// There are no comments for Property TotalPrice in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Nullable<decimal> TotalPrice
        {
            get
            {
                return this._TotalPrice;
            }
            set
            {
                this.OnTotalPriceChanging(value);
                this.ReportPropertyChanging("TotalPrice");
                this._TotalPrice = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("TotalPrice");
                this.OnTotalPriceChanged();
            }
        }
        private global::System.Nullable<decimal> _TotalPrice;
        partial void OnTotalPriceChanging(global::System.Nullable<decimal> value);
        partial void OnTotalPriceChanged();
        /// <summary>
        /// There are no comments for Property OrderDate in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Nullable<global::System.DateTime> OrderDate
        {
            get
            {
                return this._OrderDate;
            }
            set
            {
                this.OnOrderDateChanging(value);
                this.ReportPropertyChanging("OrderDate");
                this._OrderDate = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("OrderDate");
                this.OnOrderDateChanged();
            }
        }
        private global::System.Nullable<global::System.DateTime> _OrderDate;
        partial void OnOrderDateChanging(global::System.Nullable<global::System.DateTime> value);
        partial void OnOrderDateChanged();
        /// <summary>
        /// There are no comments for Property DeliveryDate in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Nullable<global::System.DateTime> DeliveryDate
        {
            get
            {
                return this._DeliveryDate;
            }
            set
            {
                this.OnDeliveryDateChanging(value);
                this.ReportPropertyChanging("DeliveryDate");
                this._DeliveryDate = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("DeliveryDate");
                this.OnDeliveryDateChanged();
            }
        }
        private global::System.Nullable<global::System.DateTime> _DeliveryDate;
        partial void OnDeliveryDateChanging(global::System.Nullable<global::System.DateTime> value);
        partial void OnDeliveryDateChanged();
        /// <summary>
        /// There are no comments for Property UserName in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string UserName
        {
            get
            {
                return this._UserName;
            }
            set
            {
                this.OnUserNameChanging(value);
                this.ReportPropertyChanging("UserName");
                this._UserName = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("UserName");
                this.OnUserNameChanged();
            }
        }
        private string _UserName;
        partial void OnUserNameChanging(string value);
        partial void OnUserNameChanged();
        /// <summary>
        /// There are no comments for Property ClientName in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string ClientName
        {
            get
            {
                return this._ClientName;
            }
            set
            {
                this.OnClientNameChanging(value);
                this.ReportPropertyChanging("ClientName");
                this._ClientName = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("ClientName");
                this.OnClientNameChanged();
            }
        }
        private string _ClientName;
        partial void OnClientNameChanging(string value);
        partial void OnClientNameChanged();
        /// <summary>
        /// There are no comments for Property City in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string City
        {
            get
            {
                return this._City;
            }
            set
            {
                this.OnCityChanging(value);
                this.ReportPropertyChanging("City");
                this._City = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("City");
                this.OnCityChanged();
            }
        }
        private string _City;
        partial void OnCityChanging(string value);
        partial void OnCityChanged();
        /// <summary>
        /// There are no comments for Property Address in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string Address
        {
            get
            {
                return this._Address;
            }
            set
            {
                this.OnAddressChanging(value);
                this.ReportPropertyChanging("Address");
                this._Address = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("Address");
                this.OnAddressChanged();
            }
        }
        private string _Address;
        partial void OnAddressChanging(string value);
        partial void OnAddressChanged();
        /// <summary>
        /// There are no comments for Property Phone in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string Phone
        {
            get
            {
                return this._Phone;
            }
            set
            {
                this.OnPhoneChanging(value);
                this.ReportPropertyChanging("Phone");
                this._Phone = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("Phone");
                this.OnPhoneChanged();
            }
        }
        private string _Phone;
        partial void OnPhoneChanging(string value);
        partial void OnPhoneChanged();
        /// <summary>
        /// There are no comments for Property Email in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string Email
        {
            get
            {
                return this._Email;
            }
            set
            {
                this.OnEmailChanging(value);
                this.ReportPropertyChanging("Email");
                this._Email = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("Email");
                this.OnEmailChanged();
            }
        }
        private string _Email;
        partial void OnEmailChanging(string value);
        partial void OnEmailChanged();
        /// <summary>
        /// There are no comments for Property Status in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Nullable<int> Status
        {
            get
            {
                return this._Status;
            }
            set
            {
                this.OnStatusChanging(value);
                this.ReportPropertyChanging("Status");
                this._Status = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("Status");
                this.OnStatusChanged();
            }
        }
        private global::System.Nullable<int> _Status;
        partial void OnStatusChanging(global::System.Nullable<int> value);
        partial void OnStatusChanged();
        /// <summary>
        /// There are no comments for Property DiscountCardNumber in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string DiscountCardNumber
        {
            get
            {
                return this._DiscountCardNumber;
            }
            set
            {
                this.OnDiscountCardNumberChanging(value);
                this.ReportPropertyChanging("DiscountCardNumber");
                this._DiscountCardNumber = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("DiscountCardNumber");
                this.OnDiscountCardNumberChanged();
            }
        }
        private string _DiscountCardNumber;
        partial void OnDiscountCardNumberChanging(string value);
        partial void OnDiscountCardNumberChanged();
        /// <summary>
        /// There are no comments for Property Comments in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string Comments
        {
            get
            {
                return this._Comments;
            }
            set
            {
                this.OnCommentsChanging(value);
                this.ReportPropertyChanging("Comments");
                this._Comments = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("Comments");
                this.OnCommentsChanged();
            }
        }
        private string _Comments;
        partial void OnCommentsChanging(string value);
        partial void OnCommentsChanged();
    }
}
