﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.VisualStudio.ServiceReference.Platforms, version 14.0.23107.0
// 
namespace Mobile.Helper.Services.BusStopOnLineService {
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BusStopOnLine", Namespace="Wpk.Entities")]
    public partial class BusStopOnLine : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int BusStopIdField;
        
        private bool DirectionField;
        
        private System.Nullable<int> IdField;
        
        private bool IsDeletedField;
        
        private int LineIdField;
        
        private int NumberStopOnLineField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int BusStopId {
            get {
                return this.BusStopIdField;
            }
            set {
                if ((this.BusStopIdField.Equals(value) != true)) {
                    this.BusStopIdField = value;
                    this.RaisePropertyChanged("BusStopId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Direction {
            get {
                return this.DirectionField;
            }
            set {
                if ((this.DirectionField.Equals(value) != true)) {
                    this.DirectionField = value;
                    this.RaisePropertyChanged("Direction");
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
        public int LineId {
            get {
                return this.LineIdField;
            }
            set {
                if ((this.LineIdField.Equals(value) != true)) {
                    this.LineIdField = value;
                    this.RaisePropertyChanged("LineId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int NumberStopOnLine {
            get {
                return this.NumberStopOnLineField;
            }
            set {
                if ((this.NumberStopOnLineField.Equals(value) != true)) {
                    this.NumberStopOnLineField = value;
                    this.RaisePropertyChanged("NumberStopOnLine");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="BusStopOnLineService.IBusStopOnLineSecureService")]
    public interface IBusStopOnLineSecureService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBusStopOnLineSecureService/GetAllWithDeleted", ReplyAction="http://tempuri.org/IBusStopOnLineSecureService/GetAllWithDeletedResponse")]
        System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Mobile.Helper.Services.BusStopOnLineService.BusStopOnLine>> GetAllWithDeletedAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBusStopOnLineSecureService/Create", ReplyAction="http://tempuri.org/IBusStopOnLineSecureService/CreateResponse")]
        System.Threading.Tasks.Task CreateAsync(Mobile.Helper.Services.BusStopOnLineService.BusStopOnLine busStopOnLine);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBusStopOnLineSecureService/Update", ReplyAction="http://tempuri.org/IBusStopOnLineSecureService/UpdateResponse")]
        System.Threading.Tasks.Task UpdateAsync(Mobile.Helper.Services.BusStopOnLineService.BusStopOnLine busStopOnLine);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBusStopOnLineSecureService/DeleteById", ReplyAction="http://tempuri.org/IBusStopOnLineSecureService/DeleteByIdResponse")]
        System.Threading.Tasks.Task DeleteByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBusStopOnLineSecureService/UndeleteById", ReplyAction="http://tempuri.org/IBusStopOnLineSecureService/UndeleteByIdResponse")]
        System.Threading.Tasks.Task UndeleteByIdAsync(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IBusStopOnLineSecureServiceChannel : Mobile.Helper.Services.BusStopOnLineService.IBusStopOnLineSecureService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class BusStopOnLineSecureServiceClient : System.ServiceModel.ClientBase<Mobile.Helper.Services.BusStopOnLineService.IBusStopOnLineSecureService>, Mobile.Helper.Services.BusStopOnLineService.IBusStopOnLineSecureService {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public BusStopOnLineSecureServiceClient() : 
                base(BusStopOnLineSecureServiceClient.GetDefaultBinding(), BusStopOnLineSecureServiceClient.GetDefaultEndpointAddress()) {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IBusStopOnLineSecureService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public BusStopOnLineSecureServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(BusStopOnLineSecureServiceClient.GetBindingForEndpoint(endpointConfiguration), BusStopOnLineSecureServiceClient.GetEndpointAddress(endpointConfiguration)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public BusStopOnLineSecureServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(BusStopOnLineSecureServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public BusStopOnLineSecureServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(BusStopOnLineSecureServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public BusStopOnLineSecureServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Mobile.Helper.Services.BusStopOnLineService.BusStopOnLine>> GetAllWithDeletedAsync() {
            return base.Channel.GetAllWithDeletedAsync();
        }
        
        public System.Threading.Tasks.Task CreateAsync(Mobile.Helper.Services.BusStopOnLineService.BusStopOnLine busStopOnLine) {
            return base.Channel.CreateAsync(busStopOnLine);
        }
        
        public System.Threading.Tasks.Task UpdateAsync(Mobile.Helper.Services.BusStopOnLineService.BusStopOnLine busStopOnLine) {
            return base.Channel.UpdateAsync(busStopOnLine);
        }
        
        public System.Threading.Tasks.Task DeleteByIdAsync(int id) {
            return base.Channel.DeleteByIdAsync(id);
        }
        
        public System.Threading.Tasks.Task UndeleteByIdAsync(int id) {
            return base.Channel.UndeleteByIdAsync(id);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync() {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync() {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration) {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IBusStopOnLineSecureService)) {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                result.Security.Mode = System.ServiceModel.BasicHttpSecurityMode.TransportWithMessageCredential;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration) {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IBusStopOnLineSecureService)) {
                return new System.ServiceModel.EndpointAddress("https://localhost:44300/Services/BusStopOnLineService.svc/secure");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding() {
            return BusStopOnLineSecureServiceClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IBusStopOnLineSecureService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress() {
            return BusStopOnLineSecureServiceClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IBusStopOnLineSecureService);
        }
        
        public enum EndpointConfiguration {
            
            BasicHttpBinding_IBusStopOnLineSecureService,
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="BusStopOnLineService.IBusStopOnLineService")]
    public interface IBusStopOnLineService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBusStopOnLineService/GetAll", ReplyAction="http://tempuri.org/IBusStopOnLineService/GetAllResponse")]
        System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Mobile.Helper.Services.BusStopOnLineService.BusStopOnLine>> GetAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBusStopOnLineService/GetById", ReplyAction="http://tempuri.org/IBusStopOnLineService/GetByIdResponse")]
        System.Threading.Tasks.Task<Mobile.Helper.Services.BusStopOnLineService.BusStopOnLine> GetByIdAsync(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IBusStopOnLineServiceChannel : Mobile.Helper.Services.BusStopOnLineService.IBusStopOnLineService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class BusStopOnLineServiceClient : System.ServiceModel.ClientBase<Mobile.Helper.Services.BusStopOnLineService.IBusStopOnLineService>, Mobile.Helper.Services.BusStopOnLineService.IBusStopOnLineService {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public BusStopOnLineServiceClient() : 
                base(BusStopOnLineServiceClient.GetDefaultBinding(), BusStopOnLineServiceClient.GetDefaultEndpointAddress()) {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IBusStopOnLineService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public BusStopOnLineServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(BusStopOnLineServiceClient.GetBindingForEndpoint(endpointConfiguration), BusStopOnLineServiceClient.GetEndpointAddress(endpointConfiguration)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public BusStopOnLineServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(BusStopOnLineServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public BusStopOnLineServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(BusStopOnLineServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public BusStopOnLineServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Mobile.Helper.Services.BusStopOnLineService.BusStopOnLine>> GetAllAsync() {
            return base.Channel.GetAllAsync();
        }
        
        public System.Threading.Tasks.Task<Mobile.Helper.Services.BusStopOnLineService.BusStopOnLine> GetByIdAsync(int id) {
            return base.Channel.GetByIdAsync(id);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync() {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync() {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration) {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IBusStopOnLineService)) {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration) {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IBusStopOnLineService)) {
                return new System.ServiceModel.EndpointAddress("http://localhost:24462/Services/BusStopOnLineService.svc/basicHttp");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding() {
            return BusStopOnLineServiceClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IBusStopOnLineService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress() {
            return BusStopOnLineServiceClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IBusStopOnLineService);
        }
        
        public enum EndpointConfiguration {
            
            BasicHttpBinding_IBusStopOnLineService,
        }
    }
}
