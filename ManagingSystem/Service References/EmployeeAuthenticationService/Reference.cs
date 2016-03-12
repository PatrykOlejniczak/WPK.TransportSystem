﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ManagingSystem.EmployeeAuthenticationService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="EmployeeAuthenticationService.IEmployeeAuthentication")]
    public interface IEmployeeAuthentication {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeAuthentication/IsAccountExists", ReplyAction="http://tempuri.org/IEmployeeAuthentication/IsAccountExistsResponse")]
        bool IsAccountExists(string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeAuthentication/IsAccountExists", ReplyAction="http://tempuri.org/IEmployeeAuthentication/IsAccountExistsResponse")]
        System.Threading.Tasks.Task<bool> IsAccountExistsAsync(string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeAuthentication/IsEmployeeHaveAccount", ReplyAction="http://tempuri.org/IEmployeeAuthentication/IsEmployeeHaveAccountResponse")]
        bool IsEmployeeHaveAccount(int employeeId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeAuthentication/IsEmployeeHaveAccount", ReplyAction="http://tempuri.org/IEmployeeAuthentication/IsEmployeeHaveAccountResponse")]
        System.Threading.Tasks.Task<bool> IsEmployeeHaveAccountAsync(int employeeId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeAuthentication/IsCorrectCredentialsCorrect", ReplyAction="http://tempuri.org/IEmployeeAuthentication/IsCorrectCredentialsCorrectResponse")]
        bool IsCorrectCredentialsCorrect(string email, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeAuthentication/IsCorrectCredentialsCorrect", ReplyAction="http://tempuri.org/IEmployeeAuthentication/IsCorrectCredentialsCorrectResponse")]
        System.Threading.Tasks.Task<bool> IsCorrectCredentialsCorrectAsync(string email, string password);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IEmployeeAuthenticationChannel : ManagingSystem.EmployeeAuthenticationService.IEmployeeAuthentication, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class EmployeeAuthenticationClient : System.ServiceModel.ClientBase<ManagingSystem.EmployeeAuthenticationService.IEmployeeAuthentication>, ManagingSystem.EmployeeAuthenticationService.IEmployeeAuthentication {
        
        public EmployeeAuthenticationClient() {
        }
        
        public EmployeeAuthenticationClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public EmployeeAuthenticationClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EmployeeAuthenticationClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EmployeeAuthenticationClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool IsAccountExists(string email) {
            return base.Channel.IsAccountExists(email);
        }
        
        public System.Threading.Tasks.Task<bool> IsAccountExistsAsync(string email) {
            return base.Channel.IsAccountExistsAsync(email);
        }
        
        public bool IsEmployeeHaveAccount(int employeeId) {
            return base.Channel.IsEmployeeHaveAccount(employeeId);
        }
        
        public System.Threading.Tasks.Task<bool> IsEmployeeHaveAccountAsync(int employeeId) {
            return base.Channel.IsEmployeeHaveAccountAsync(employeeId);
        }
        
        public bool IsCorrectCredentialsCorrect(string email, string password) {
            return base.Channel.IsCorrectCredentialsCorrect(email, password);
        }
        
        public System.Threading.Tasks.Task<bool> IsCorrectCredentialsCorrectAsync(string email, string password) {
            return base.Channel.IsCorrectCredentialsCorrectAsync(email, password);
        }
    }
}
