﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ManagingSystem.QuestionnaireService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Questionnaire", Namespace="Wpk.Entities")]
    [System.SerializableAttribute()]
    public partial class Questionnaire : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int EmployeeIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime EndDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsDeletedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string QuestionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime StartDateField;
        
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
        public int EmployeeId {
            get {
                return this.EmployeeIdField;
            }
            set {
                if ((this.EmployeeIdField.Equals(value) != true)) {
                    this.EmployeeIdField = value;
                    this.RaisePropertyChanged("EmployeeId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime EndDate {
            get {
                return this.EndDateField;
            }
            set {
                if ((this.EndDateField.Equals(value) != true)) {
                    this.EndDateField = value;
                    this.RaisePropertyChanged("EndDate");
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
        public string Question {
            get {
                return this.QuestionField;
            }
            set {
                if ((object.ReferenceEquals(this.QuestionField, value) != true)) {
                    this.QuestionField = value;
                    this.RaisePropertyChanged("Question");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime StartDate {
            get {
                return this.StartDateField;
            }
            set {
                if ((this.StartDateField.Equals(value) != true)) {
                    this.StartDateField = value;
                    this.RaisePropertyChanged("StartDate");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="QuestionnaireService.IQuestionnaireSecureService")]
    public interface IQuestionnaireSecureService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IQuestionnaireSecureService/GetAllWithDeleted", ReplyAction="http://tempuri.org/IQuestionnaireSecureService/GetAllWithDeletedResponse")]
        ManagingSystem.QuestionnaireService.Questionnaire[] GetAllWithDeleted();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IQuestionnaireSecureService/GetAllWithDeleted", ReplyAction="http://tempuri.org/IQuestionnaireSecureService/GetAllWithDeletedResponse")]
        System.Threading.Tasks.Task<ManagingSystem.QuestionnaireService.Questionnaire[]> GetAllWithDeletedAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IQuestionnaireSecureService/GetByEmployeeId", ReplyAction="http://tempuri.org/IQuestionnaireSecureService/GetByEmployeeIdResponse")]
        ManagingSystem.QuestionnaireService.Questionnaire[] GetByEmployeeId(int employeeId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IQuestionnaireSecureService/GetByEmployeeId", ReplyAction="http://tempuri.org/IQuestionnaireSecureService/GetByEmployeeIdResponse")]
        System.Threading.Tasks.Task<ManagingSystem.QuestionnaireService.Questionnaire[]> GetByEmployeeIdAsync(int employeeId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IQuestionnaireSecureService/Create", ReplyAction="http://tempuri.org/IQuestionnaireSecureService/CreateResponse")]
        void Create(ManagingSystem.QuestionnaireService.Questionnaire questionnaire);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IQuestionnaireSecureService/Create", ReplyAction="http://tempuri.org/IQuestionnaireSecureService/CreateResponse")]
        System.Threading.Tasks.Task CreateAsync(ManagingSystem.QuestionnaireService.Questionnaire questionnaire);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IQuestionnaireSecureService/Update", ReplyAction="http://tempuri.org/IQuestionnaireSecureService/UpdateResponse")]
        void Update(ManagingSystem.QuestionnaireService.Questionnaire questionnaire);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IQuestionnaireSecureService/Update", ReplyAction="http://tempuri.org/IQuestionnaireSecureService/UpdateResponse")]
        System.Threading.Tasks.Task UpdateAsync(ManagingSystem.QuestionnaireService.Questionnaire questionnaire);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IQuestionnaireSecureService/DelteById", ReplyAction="http://tempuri.org/IQuestionnaireSecureService/DelteByIdResponse")]
        void DelteById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IQuestionnaireSecureService/DelteById", ReplyAction="http://tempuri.org/IQuestionnaireSecureService/DelteByIdResponse")]
        System.Threading.Tasks.Task DelteByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IQuestionnaireSecureService/UndeleteById", ReplyAction="http://tempuri.org/IQuestionnaireSecureService/UndeleteByIdResponse")]
        void UndeleteById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IQuestionnaireSecureService/UndeleteById", ReplyAction="http://tempuri.org/IQuestionnaireSecureService/UndeleteByIdResponse")]
        System.Threading.Tasks.Task UndeleteByIdAsync(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IQuestionnaireSecureServiceChannel : ManagingSystem.QuestionnaireService.IQuestionnaireSecureService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class QuestionnaireSecureServiceClient : System.ServiceModel.ClientBase<ManagingSystem.QuestionnaireService.IQuestionnaireSecureService>, ManagingSystem.QuestionnaireService.IQuestionnaireSecureService {
        
        public QuestionnaireSecureServiceClient() {
        }
        
        public QuestionnaireSecureServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public QuestionnaireSecureServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public QuestionnaireSecureServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public QuestionnaireSecureServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ManagingSystem.QuestionnaireService.Questionnaire[] GetAllWithDeleted() {
            return base.Channel.GetAllWithDeleted();
        }
        
        public System.Threading.Tasks.Task<ManagingSystem.QuestionnaireService.Questionnaire[]> GetAllWithDeletedAsync() {
            return base.Channel.GetAllWithDeletedAsync();
        }
        
        public ManagingSystem.QuestionnaireService.Questionnaire[] GetByEmployeeId(int employeeId) {
            return base.Channel.GetByEmployeeId(employeeId);
        }
        
        public System.Threading.Tasks.Task<ManagingSystem.QuestionnaireService.Questionnaire[]> GetByEmployeeIdAsync(int employeeId) {
            return base.Channel.GetByEmployeeIdAsync(employeeId);
        }
        
        public void Create(ManagingSystem.QuestionnaireService.Questionnaire questionnaire) {
            base.Channel.Create(questionnaire);
        }
        
        public System.Threading.Tasks.Task CreateAsync(ManagingSystem.QuestionnaireService.Questionnaire questionnaire) {
            return base.Channel.CreateAsync(questionnaire);
        }
        
        public void Update(ManagingSystem.QuestionnaireService.Questionnaire questionnaire) {
            base.Channel.Update(questionnaire);
        }
        
        public System.Threading.Tasks.Task UpdateAsync(ManagingSystem.QuestionnaireService.Questionnaire questionnaire) {
            return base.Channel.UpdateAsync(questionnaire);
        }
        
        public void DelteById(int id) {
            base.Channel.DelteById(id);
        }
        
        public System.Threading.Tasks.Task DelteByIdAsync(int id) {
            return base.Channel.DelteByIdAsync(id);
        }
        
        public void UndeleteById(int id) {
            base.Channel.UndeleteById(id);
        }
        
        public System.Threading.Tasks.Task UndeleteByIdAsync(int id) {
            return base.Channel.UndeleteByIdAsync(id);
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="QuestionnaireService.IQuestionnaireService")]
    public interface IQuestionnaireService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IQuestionnaireService/GetAll", ReplyAction="http://tempuri.org/IQuestionnaireService/GetAllResponse")]
        ManagingSystem.QuestionnaireService.Questionnaire[] GetAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IQuestionnaireService/GetAll", ReplyAction="http://tempuri.org/IQuestionnaireService/GetAllResponse")]
        System.Threading.Tasks.Task<ManagingSystem.QuestionnaireService.Questionnaire[]> GetAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IQuestionnaireService/GetById", ReplyAction="http://tempuri.org/IQuestionnaireService/GetByIdResponse")]
        ManagingSystem.QuestionnaireService.Questionnaire GetById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IQuestionnaireService/GetById", ReplyAction="http://tempuri.org/IQuestionnaireService/GetByIdResponse")]
        System.Threading.Tasks.Task<ManagingSystem.QuestionnaireService.Questionnaire> GetByIdAsync(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IQuestionnaireServiceChannel : ManagingSystem.QuestionnaireService.IQuestionnaireService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class QuestionnaireServiceClient : System.ServiceModel.ClientBase<ManagingSystem.QuestionnaireService.IQuestionnaireService>, ManagingSystem.QuestionnaireService.IQuestionnaireService {
        
        public QuestionnaireServiceClient() {
        }
        
        public QuestionnaireServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public QuestionnaireServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public QuestionnaireServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public QuestionnaireServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ManagingSystem.QuestionnaireService.Questionnaire[] GetAll() {
            return base.Channel.GetAll();
        }
        
        public System.Threading.Tasks.Task<ManagingSystem.QuestionnaireService.Questionnaire[]> GetAllAsync() {
            return base.Channel.GetAllAsync();
        }
        
        public ManagingSystem.QuestionnaireService.Questionnaire GetById(int id) {
            return base.Channel.GetById(id);
        }
        
        public System.Threading.Tasks.Task<ManagingSystem.QuestionnaireService.Questionnaire> GetByIdAsync(int id) {
            return base.Channel.GetByIdAsync(id);
        }
    }
}
