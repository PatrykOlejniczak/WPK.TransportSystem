﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ManagingSystem.DistanceBetweenStopsSerice {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DistanceBetweenStops", Namespace="Wpk.Entities")]
    [System.SerializableAttribute()]
    public partial class DistanceBetweenStops : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double DistanceInKilometersField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int FirstBusStopIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int SecondBusStopIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.TimeSpan TravelTimeField;
        
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
        public double DistanceInKilometers {
            get {
                return this.DistanceInKilometersField;
            }
            set {
                if ((this.DistanceInKilometersField.Equals(value) != true)) {
                    this.DistanceInKilometersField = value;
                    this.RaisePropertyChanged("DistanceInKilometers");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int FirstBusStopId {
            get {
                return this.FirstBusStopIdField;
            }
            set {
                if ((this.FirstBusStopIdField.Equals(value) != true)) {
                    this.FirstBusStopIdField = value;
                    this.RaisePropertyChanged("FirstBusStopId");
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
        public int SecondBusStopId {
            get {
                return this.SecondBusStopIdField;
            }
            set {
                if ((this.SecondBusStopIdField.Equals(value) != true)) {
                    this.SecondBusStopIdField = value;
                    this.RaisePropertyChanged("SecondBusStopId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.TimeSpan TravelTime {
            get {
                return this.TravelTimeField;
            }
            set {
                if ((this.TravelTimeField.Equals(value) != true)) {
                    this.TravelTimeField = value;
                    this.RaisePropertyChanged("TravelTime");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DistanceBetweenStopsSerice.IDistanceBetweenStopsSecureService")]
    public interface IDistanceBetweenStopsSecureService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDistanceBetweenStopsSecureService/GetAllWithDeleted", ReplyAction="http://tempuri.org/IDistanceBetweenStopsSecureService/GetAllWithDeletedResponse")]
        ManagingSystem.DistanceBetweenStopsSerice.DistanceBetweenStops[] GetAllWithDeleted();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDistanceBetweenStopsSecureService/GetAllWithDeleted", ReplyAction="http://tempuri.org/IDistanceBetweenStopsSecureService/GetAllWithDeletedResponse")]
        System.Threading.Tasks.Task<ManagingSystem.DistanceBetweenStopsSerice.DistanceBetweenStops[]> GetAllWithDeletedAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDistanceBetweenStopsSecureService/Create", ReplyAction="http://tempuri.org/IDistanceBetweenStopsSecureService/CreateResponse")]
        void Create(ManagingSystem.DistanceBetweenStopsSerice.DistanceBetweenStops distanceBetweenStops);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDistanceBetweenStopsSecureService/Create", ReplyAction="http://tempuri.org/IDistanceBetweenStopsSecureService/CreateResponse")]
        System.Threading.Tasks.Task CreateAsync(ManagingSystem.DistanceBetweenStopsSerice.DistanceBetweenStops distanceBetweenStops);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDistanceBetweenStopsSecureService/Update", ReplyAction="http://tempuri.org/IDistanceBetweenStopsSecureService/UpdateResponse")]
        void Update(ManagingSystem.DistanceBetweenStopsSerice.DistanceBetweenStops distanceBetweenStops);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDistanceBetweenStopsSecureService/Update", ReplyAction="http://tempuri.org/IDistanceBetweenStopsSecureService/UpdateResponse")]
        System.Threading.Tasks.Task UpdateAsync(ManagingSystem.DistanceBetweenStopsSerice.DistanceBetweenStops distanceBetweenStops);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDistanceBetweenStopsSecureService/DeleteById", ReplyAction="http://tempuri.org/IDistanceBetweenStopsSecureService/DeleteByIdResponse")]
        void DeleteById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDistanceBetweenStopsSecureService/DeleteById", ReplyAction="http://tempuri.org/IDistanceBetweenStopsSecureService/DeleteByIdResponse")]
        System.Threading.Tasks.Task DeleteByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDistanceBetweenStopsSecureService/UndeleteById", ReplyAction="http://tempuri.org/IDistanceBetweenStopsSecureService/UndeleteByIdResponse")]
        void UndeleteById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDistanceBetweenStopsSecureService/UndeleteById", ReplyAction="http://tempuri.org/IDistanceBetweenStopsSecureService/UndeleteByIdResponse")]
        System.Threading.Tasks.Task UndeleteByIdAsync(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDistanceBetweenStopsSecureServiceChannel : ManagingSystem.DistanceBetweenStopsSerice.IDistanceBetweenStopsSecureService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DistanceBetweenStopsSecureServiceClient : System.ServiceModel.ClientBase<ManagingSystem.DistanceBetweenStopsSerice.IDistanceBetweenStopsSecureService>, ManagingSystem.DistanceBetweenStopsSerice.IDistanceBetweenStopsSecureService {
        
        public DistanceBetweenStopsSecureServiceClient() {
        }
        
        public DistanceBetweenStopsSecureServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DistanceBetweenStopsSecureServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DistanceBetweenStopsSecureServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DistanceBetweenStopsSecureServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ManagingSystem.DistanceBetweenStopsSerice.DistanceBetweenStops[] GetAllWithDeleted() {
            return base.Channel.GetAllWithDeleted();
        }
        
        public System.Threading.Tasks.Task<ManagingSystem.DistanceBetweenStopsSerice.DistanceBetweenStops[]> GetAllWithDeletedAsync() {
            return base.Channel.GetAllWithDeletedAsync();
        }
        
        public void Create(ManagingSystem.DistanceBetweenStopsSerice.DistanceBetweenStops distanceBetweenStops) {
            base.Channel.Create(distanceBetweenStops);
        }
        
        public System.Threading.Tasks.Task CreateAsync(ManagingSystem.DistanceBetweenStopsSerice.DistanceBetweenStops distanceBetweenStops) {
            return base.Channel.CreateAsync(distanceBetweenStops);
        }
        
        public void Update(ManagingSystem.DistanceBetweenStopsSerice.DistanceBetweenStops distanceBetweenStops) {
            base.Channel.Update(distanceBetweenStops);
        }
        
        public System.Threading.Tasks.Task UpdateAsync(ManagingSystem.DistanceBetweenStopsSerice.DistanceBetweenStops distanceBetweenStops) {
            return base.Channel.UpdateAsync(distanceBetweenStops);
        }
        
        public void DeleteById(int id) {
            base.Channel.DeleteById(id);
        }
        
        public System.Threading.Tasks.Task DeleteByIdAsync(int id) {
            return base.Channel.DeleteByIdAsync(id);
        }
        
        public void UndeleteById(int id) {
            base.Channel.UndeleteById(id);
        }
        
        public System.Threading.Tasks.Task UndeleteByIdAsync(int id) {
            return base.Channel.UndeleteByIdAsync(id);
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DistanceBetweenStopsSerice.IDistanceBetweenStopsService")]
    public interface IDistanceBetweenStopsService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDistanceBetweenStopsService/GetAll", ReplyAction="http://tempuri.org/IDistanceBetweenStopsService/GetAllResponse")]
        ManagingSystem.DistanceBetweenStopsSerice.DistanceBetweenStops[] GetAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDistanceBetweenStopsService/GetAll", ReplyAction="http://tempuri.org/IDistanceBetweenStopsService/GetAllResponse")]
        System.Threading.Tasks.Task<ManagingSystem.DistanceBetweenStopsSerice.DistanceBetweenStops[]> GetAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDistanceBetweenStopsService/GetById", ReplyAction="http://tempuri.org/IDistanceBetweenStopsService/GetByIdResponse")]
        ManagingSystem.DistanceBetweenStopsSerice.DistanceBetweenStops GetById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDistanceBetweenStopsService/GetById", ReplyAction="http://tempuri.org/IDistanceBetweenStopsService/GetByIdResponse")]
        System.Threading.Tasks.Task<ManagingSystem.DistanceBetweenStopsSerice.DistanceBetweenStops> GetByIdAsync(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDistanceBetweenStopsServiceChannel : ManagingSystem.DistanceBetweenStopsSerice.IDistanceBetweenStopsService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DistanceBetweenStopsServiceClient : System.ServiceModel.ClientBase<ManagingSystem.DistanceBetweenStopsSerice.IDistanceBetweenStopsService>, ManagingSystem.DistanceBetweenStopsSerice.IDistanceBetweenStopsService {
        
        public DistanceBetweenStopsServiceClient() {
        }
        
        public DistanceBetweenStopsServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DistanceBetweenStopsServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DistanceBetweenStopsServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DistanceBetweenStopsServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ManagingSystem.DistanceBetweenStopsSerice.DistanceBetweenStops[] GetAll() {
            return base.Channel.GetAll();
        }
        
        public System.Threading.Tasks.Task<ManagingSystem.DistanceBetweenStopsSerice.DistanceBetweenStops[]> GetAllAsync() {
            return base.Channel.GetAllAsync();
        }
        
        public ManagingSystem.DistanceBetweenStopsSerice.DistanceBetweenStops GetById(int id) {
            return base.Channel.GetById(id);
        }
        
        public System.Threading.Tasks.Task<ManagingSystem.DistanceBetweenStopsSerice.DistanceBetweenStops> GetByIdAsync(int id) {
            return base.Channel.GetByIdAsync(id);
        }
    }
}
