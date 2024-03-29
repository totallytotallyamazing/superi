﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4918
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::System.Data.Objects.DataClasses.EdmSchemaAttribute()]

// Original file name:
// Generation date: 22.08.2009 13:39:05
namespace Zamov.Models
{
    
    /// <summary>
    /// There are no comments for SettingsStorage in the schema.
    /// </summary>
    public partial class SettingsStorage : global::System.Data.Objects.ObjectContext
    {
        /// <summary>
        /// Initializes a new SettingsStorage object using the connection string found in the 'SettingsStorage' section of the application configuration file.
        /// </summary>
        public SettingsStorage() : 
                base("name=SettingsStorage", "SettingsStorage")
        {
            this.OnContextCreated();
        }
        /// <summary>
        /// Initialize a new SettingsStorage object.
        /// </summary>
        public SettingsStorage(string connectionString) : 
                base(connectionString, "SettingsStorage")
        {
            this.OnContextCreated();
        }
        /// <summary>
        /// Initialize a new SettingsStorage object.
        /// </summary>
        public SettingsStorage(global::System.Data.EntityClient.EntityConnection connection) : 
                base(connection, "SettingsStorage")
        {
            this.OnContextCreated();
        }
        partial void OnContextCreated();
        /// <summary>
        /// There are no comments for ApplicationSettings in the schema.
        /// </summary>
        public global::System.Data.Objects.ObjectQuery<ApplicationSettings> ApplicationSettings
        {
            get
            {
                if ((this._ApplicationSettings == null))
                {
                    this._ApplicationSettings = base.CreateQuery<ApplicationSettings>("[ApplicationSettings]");
                }
                return this._ApplicationSettings;
            }
        }
        private global::System.Data.Objects.ObjectQuery<ApplicationSettings> _ApplicationSettings;
        /// <summary>
        /// There are no comments for ApplicationSettings in the schema.
        /// </summary>
        public void AddToApplicationSettings(ApplicationSettings applicationSettings)
        {
            base.AddObject("ApplicationSettings", applicationSettings);
        }
    }
    /// <summary>
    /// There are no comments for Settings.ApplicationSettings in the schema.
    /// </summary>
    /// <KeyProperties>
    /// Id
    /// </KeyProperties>
    [global::System.Data.Objects.DataClasses.EdmEntityTypeAttribute(NamespaceName="Settings", Name="ApplicationSettings")]
    [global::System.Runtime.Serialization.DataContractAttribute(IsReference=true)]
    [global::System.Serializable()]
    public partial class ApplicationSettings : global::System.Data.Objects.DataClasses.EntityObject
    {
        /// <summary>
        /// Create a new ApplicationSettings object.
        /// </summary>
        /// <param name="id">Initial value of Id.</param>
        /// <param name="name">Initial value of Name.</param>
        public static ApplicationSettings CreateApplicationSettings(int id, string name)
        {
            ApplicationSettings applicationSettings = new ApplicationSettings();
            applicationSettings.Id = id;
            applicationSettings.Name = name;
            return applicationSettings;
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
        /// There are no comments for Property Value in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string Value
        {
            get
            {
                return this._Value;
            }
            set
            {
                this.OnValueChanging(value);
                this.ReportPropertyChanging("Value");
                this._Value = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("Value");
                this.OnValueChanged();
            }
        }
        private string _Value;
        partial void OnValueChanging(string value);
        partial void OnValueChanged();
        /// <summary>
        /// There are no comments for Property Language in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
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
                this._Language = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("Language");
                this.OnLanguageChanged();
            }
        }
        private string _Language;
        partial void OnLanguageChanging(string value);
        partial void OnLanguageChanged();
    }
}
