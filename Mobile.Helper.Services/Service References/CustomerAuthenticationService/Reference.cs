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
namespace Mobile.Helper.Services.CustomerAuthenticationService {
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Customer", Namespace="Wpk.Entities")]
    public partial class Customer : object, System.ComponentModel.INotifyPropertyChanged {
        
        private double AccountBalanceField;
        
        private string EmailField;
        
        private string HashPasswordField;
        
        private int IdField;
        
        private bool IsDeletedField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double AccountBalance {
            get {
                return this.AccountBalanceField;
            }
            set {
                if ((this.AccountBalanceField.Equals(value) != true)) {
                    this.AccountBalanceField = value;
                    this.RaisePropertyChanged("AccountBalance");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email {
            get {
                return this.EmailField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailField, value) != true)) {
                    this.EmailField = value;
                    this.RaisePropertyChanged("Email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string HashPassword {
            get {
                return this.HashPasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.HashPasswordField, value) != true)) {
                    this.HashPasswordField = value;
                    this.RaisePropertyChanged("HashPassword");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
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
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CustomerAuthenticationService.ICustomerAuthenticationService")]
    public interface ICustomerAuthenticationService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerAuthenticationService/GetCustomerInfo", ReplyAction="http://tempuri.org/ICustomerAuthenticationService/GetCustomerInfoResponse")]
        System.Threading.Tasks.Task<Mobile.Helper.Services.CustomerAuthenticationService.Customer> GetCustomerInfoAsync(string email, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerAuthenticationService/IsCustomerExists", ReplyAction="http://tempuri.org/ICustomerAuthenticationService/IsCustomerExistsResponse")]
        System.Threading.Tasks.Task<bool> IsCustomerExistsAsync(string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerAuthenticationService/IsCorrectCredentialsCorrect", ReplyAction="http://tempuri.org/ICustomerAuthenticationService/IsCorrectCredentialsCorrectResp" +
            "onse")]
        System.Threading.Tasks.Task<bool> IsCorrectCredentialsCorrectAsync(string email, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerAuthenticationService/Register", ReplyAction="http://tempuri.org/ICustomerAuthenticationService/RegisterResponse")]
        System.Threading.Tasks.Task<bool> RegisterAsync(string email, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerAuthenticationService/SendPasswordReminder", ReplyAction="http://tempuri.org/ICustomerAuthenticationService/SendPasswordReminderResponse")]
        System.Threading.Tasks.Task SendPasswordReminderAsync(string email);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICustomerAuthenticationServiceChannel : Mobile.Helper.Services.CustomerAuthenticationService.ICustomerAuthenticationService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CustomerAuthenticationServiceClient : System.ServiceModel.ClientBase<Mobile.Helper.Services.CustomerAuthenticationService.ICustomerAuthenticationService>, Mobile.Helper.Services.CustomerAuthenticationService.ICustomerAuthenticationService {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public CustomerAuthenticationServiceClient() : 
                base(CustomerAuthenticationServiceClient.GetDefaultBinding(), CustomerAuthenticationServiceClient.GetDefaultEndpointAddress()) {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_ICustomerAuthenticationService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public CustomerAuthenticationServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(CustomerAuthenticationServiceClient.GetBindingForEndpoint(endpointConfiguration), CustomerAuthenticationServiceClient.GetEndpointAddress(endpointConfiguration)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public CustomerAuthenticationServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(CustomerAuthenticationServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public CustomerAuthenticationServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(CustomerAuthenticationServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public CustomerAuthenticationServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Threading.Tasks.Task<Mobile.Helper.Services.CustomerAuthenticationService.Customer> GetCustomerInfoAsync(string email, string password) {
            return base.Channel.GetCustomerInfoAsync(email, password);
        }
        
        public System.Threading.Tasks.Task<bool> IsCustomerExistsAsync(string email) {
            return base.Channel.IsCustomerExistsAsync(email);
        }
        
        public System.Threading.Tasks.Task<bool> IsCorrectCredentialsCorrectAsync(string email, string password) {
            return base.Channel.IsCorrectCredentialsCorrectAsync(email, password);
        }
        
        public System.Threading.Tasks.Task<bool> RegisterAsync(string email, string password) {
            return base.Channel.RegisterAsync(email, password);
        }
        
        public System.Threading.Tasks.Task SendPasswordReminderAsync(string email) {
            return base.Channel.SendPasswordReminderAsync(email);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync() {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync() {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration) {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_ICustomerAuthenticationService)) {
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
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_ICustomerAuthenticationService)) {
                return new System.ServiceModel.EndpointAddress("http://localhost:24462/Services/CustomerAuthenticationService.svc/basicHttp");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding() {
            return CustomerAuthenticationServiceClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_ICustomerAuthenticationService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress() {
            return CustomerAuthenticationServiceClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_ICustomerAuthenticationService);
        }
        
        public enum EndpointConfiguration {
            
            BasicHttpBinding_ICustomerAuthenticationService,
        }
    }
}
