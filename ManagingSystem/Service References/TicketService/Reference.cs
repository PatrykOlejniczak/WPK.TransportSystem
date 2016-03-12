﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ManagingSystem.TicketService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Ticket", Namespace="Wpk.Entities")]
    [System.SerializableAttribute()]
    public partial class Ticket : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.TimeSpan DurationField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsDeletedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double PriceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int TicketTypeIdField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.TimeSpan Duration {
            get {
                return this.DurationField;
            }
            set {
                if ((this.DurationField.Equals(value) != true)) {
                    this.DurationField = value;
                    this.RaisePropertyChanged("Duration");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsDeleted {
            get {
                return this.IsDeletedField;
            }
            set {
                if ((this.IsDeletedField.Equals(value) != true)) {
                    this.IsDeletedField = value;
                    this.RaisePropertyChanged("IsDeleted");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Price {
            get {
                return this.PriceField;
            }
            set {
                if ((this.PriceField.Equals(value) != true)) {
                    this.PriceField = value;
                    this.RaisePropertyChanged("Price");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int TicketTypeId {
            get {
                return this.TicketTypeIdField;
            }
            set {
                if ((this.TicketTypeIdField.Equals(value) != true)) {
                    this.TicketTypeIdField = value;
                    this.RaisePropertyChanged("TicketTypeId");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="TicketService.ITicketSecureService")]
    public interface ITicketSecureService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITicketSecureService/Create", ReplyAction="http://tempuri.org/ITicketSecureService/CreateResponse")]
        void Create(ManagingSystem.TicketService.Ticket ticket);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITicketSecureService/Create", ReplyAction="http://tempuri.org/ITicketSecureService/CreateResponse")]
        System.Threading.Tasks.Task CreateAsync(ManagingSystem.TicketService.Ticket ticket);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITicketSecureService/Update", ReplyAction="http://tempuri.org/ITicketSecureService/UpdateResponse")]
        void Update(ManagingSystem.TicketService.Ticket ticket);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITicketSecureService/Update", ReplyAction="http://tempuri.org/ITicketSecureService/UpdateResponse")]
        System.Threading.Tasks.Task UpdateAsync(ManagingSystem.TicketService.Ticket ticket);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITicketSecureService/DeleteById", ReplyAction="http://tempuri.org/ITicketSecureService/DeleteByIdResponse")]
        void DeleteById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITicketSecureService/DeleteById", ReplyAction="http://tempuri.org/ITicketSecureService/DeleteByIdResponse")]
        System.Threading.Tasks.Task DeleteByIdAsync(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITicketSecureServiceChannel : ManagingSystem.TicketService.ITicketSecureService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TicketSecureServiceClient : System.ServiceModel.ClientBase<ManagingSystem.TicketService.ITicketSecureService>, ManagingSystem.TicketService.ITicketSecureService {
        
        public TicketSecureServiceClient() {
        }
        
        public TicketSecureServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TicketSecureServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TicketSecureServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TicketSecureServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void Create(ManagingSystem.TicketService.Ticket ticket) {
            base.Channel.Create(ticket);
        }
        
        public System.Threading.Tasks.Task CreateAsync(ManagingSystem.TicketService.Ticket ticket) {
            return base.Channel.CreateAsync(ticket);
        }
        
        public void Update(ManagingSystem.TicketService.Ticket ticket) {
            base.Channel.Update(ticket);
        }
        
        public System.Threading.Tasks.Task UpdateAsync(ManagingSystem.TicketService.Ticket ticket) {
            return base.Channel.UpdateAsync(ticket);
        }
        
        public void DeleteById(int id) {
            base.Channel.DeleteById(id);
        }
        
        public System.Threading.Tasks.Task DeleteByIdAsync(int id) {
            return base.Channel.DeleteByIdAsync(id);
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="TicketService.ITicketService")]
    public interface ITicketService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITicketService/GetAll", ReplyAction="http://tempuri.org/ITicketService/GetAllResponse")]
        ManagingSystem.TicketService.Ticket[] GetAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITicketService/GetAll", ReplyAction="http://tempuri.org/ITicketService/GetAllResponse")]
        System.Threading.Tasks.Task<ManagingSystem.TicketService.Ticket[]> GetAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITicketService/GetWherePriceMoreThan", ReplyAction="http://tempuri.org/ITicketService/GetWherePriceMoreThanResponse")]
        ManagingSystem.TicketService.Ticket[] GetWherePriceMoreThan(double price);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITicketService/GetWherePriceMoreThan", ReplyAction="http://tempuri.org/ITicketService/GetWherePriceMoreThanResponse")]
        System.Threading.Tasks.Task<ManagingSystem.TicketService.Ticket[]> GetWherePriceMoreThanAsync(double price);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITicketService/GetWherePriceLessThan", ReplyAction="http://tempuri.org/ITicketService/GetWherePriceLessThanResponse")]
        ManagingSystem.TicketService.Ticket[] GetWherePriceLessThan(double price);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITicketService/GetWherePriceLessThan", ReplyAction="http://tempuri.org/ITicketService/GetWherePriceLessThanResponse")]
        System.Threading.Tasks.Task<ManagingSystem.TicketService.Ticket[]> GetWherePriceLessThanAsync(double price);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITicketService/GetWhereTicketTypeId", ReplyAction="http://tempuri.org/ITicketService/GetWhereTicketTypeIdResponse")]
        ManagingSystem.TicketService.Ticket[] GetWhereTicketTypeId(int ticketTypeId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITicketService/GetWhereTicketTypeId", ReplyAction="http://tempuri.org/ITicketService/GetWhereTicketTypeIdResponse")]
        System.Threading.Tasks.Task<ManagingSystem.TicketService.Ticket[]> GetWhereTicketTypeIdAsync(int ticketTypeId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITicketService/GetById", ReplyAction="http://tempuri.org/ITicketService/GetByIdResponse")]
        ManagingSystem.TicketService.Ticket GetById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITicketService/GetById", ReplyAction="http://tempuri.org/ITicketService/GetByIdResponse")]
        System.Threading.Tasks.Task<ManagingSystem.TicketService.Ticket> GetByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITicketService/GetByName", ReplyAction="http://tempuri.org/ITicketService/GetByNameResponse")]
        ManagingSystem.TicketService.Ticket GetByName(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITicketService/GetByName", ReplyAction="http://tempuri.org/ITicketService/GetByNameResponse")]
        System.Threading.Tasks.Task<ManagingSystem.TicketService.Ticket> GetByNameAsync(string name);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITicketServiceChannel : ManagingSystem.TicketService.ITicketService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TicketServiceClient : System.ServiceModel.ClientBase<ManagingSystem.TicketService.ITicketService>, ManagingSystem.TicketService.ITicketService {
        
        public TicketServiceClient() {
        }
        
        public TicketServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TicketServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TicketServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TicketServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ManagingSystem.TicketService.Ticket[] GetAll() {
            return base.Channel.GetAll();
        }
        
        public System.Threading.Tasks.Task<ManagingSystem.TicketService.Ticket[]> GetAllAsync() {
            return base.Channel.GetAllAsync();
        }
        
        public ManagingSystem.TicketService.Ticket[] GetWherePriceMoreThan(double price) {
            return base.Channel.GetWherePriceMoreThan(price);
        }
        
        public System.Threading.Tasks.Task<ManagingSystem.TicketService.Ticket[]> GetWherePriceMoreThanAsync(double price) {
            return base.Channel.GetWherePriceMoreThanAsync(price);
        }
        
        public ManagingSystem.TicketService.Ticket[] GetWherePriceLessThan(double price) {
            return base.Channel.GetWherePriceLessThan(price);
        }
        
        public System.Threading.Tasks.Task<ManagingSystem.TicketService.Ticket[]> GetWherePriceLessThanAsync(double price) {
            return base.Channel.GetWherePriceLessThanAsync(price);
        }
        
        public ManagingSystem.TicketService.Ticket[] GetWhereTicketTypeId(int ticketTypeId) {
            return base.Channel.GetWhereTicketTypeId(ticketTypeId);
        }
        
        public System.Threading.Tasks.Task<ManagingSystem.TicketService.Ticket[]> GetWhereTicketTypeIdAsync(int ticketTypeId) {
            return base.Channel.GetWhereTicketTypeIdAsync(ticketTypeId);
        }
        
        public ManagingSystem.TicketService.Ticket GetById(int id) {
            return base.Channel.GetById(id);
        }
        
        public System.Threading.Tasks.Task<ManagingSystem.TicketService.Ticket> GetByIdAsync(int id) {
            return base.Channel.GetByIdAsync(id);
        }
        
        public ManagingSystem.TicketService.Ticket GetByName(string name) {
            return base.Channel.GetByName(name);
        }
        
        public System.Threading.Tasks.Task<ManagingSystem.TicketService.Ticket> GetByNameAsync(string name) {
            return base.Channel.GetByNameAsync(name);
        }
    }
}
