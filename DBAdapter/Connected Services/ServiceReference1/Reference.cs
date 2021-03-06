﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DBAdapter.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetUser", ReplyAction="http://tempuri.org/IService1/GetUserResponse")]
        DBModels.User GetUser(string login);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetUser", ReplyAction="http://tempuri.org/IService1/GetUserResponse")]
        System.Threading.Tasks.Task<DBModels.User> GetUserAsync(string login);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CreateUser", ReplyAction="http://tempuri.org/IService1/CreateUserResponse")]
        void CreateUser(DBModels.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CreateUser", ReplyAction="http://tempuri.org/IService1/CreateUserResponse")]
        System.Threading.Tasks.Task CreateUserAsync(DBModels.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/DoesUserExist", ReplyAction="http://tempuri.org/IService1/DoesUserExistResponse")]
        bool DoesUserExist(string login);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/DoesUserExist", ReplyAction="http://tempuri.org/IService1/DoesUserExistResponse")]
        System.Threading.Tasks.Task<bool> DoesUserExistAsync(string login);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CreateEditingInfo", ReplyAction="http://tempuri.org/IService1/CreateEditingInfoResponse")]
        DBModels.EditingInfo CreateEditingInfo(DBModels.User user, string filePath, bool isFileChanged, System.DateTime editingDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CreateEditingInfo", ReplyAction="http://tempuri.org/IService1/CreateEditingInfoResponse")]
        System.Threading.Tasks.Task<DBModels.EditingInfo> CreateEditingInfoAsync(DBModels.User user, string filePath, bool isFileChanged, System.DateTime editingDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetEditingInfoes", ReplyAction="http://tempuri.org/IService1/GetEditingInfoesResponse")]
        DBModels.EditingInfo[] GetEditingInfoes(string filePath);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetEditingInfoes", ReplyAction="http://tempuri.org/IService1/GetEditingInfoesResponse")]
        System.Threading.Tasks.Task<DBModels.EditingInfo[]> GetEditingInfoesAsync(string filePath);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : DBAdapter.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<DBAdapter.ServiceReference1.IService1>, DBAdapter.ServiceReference1.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public DBModels.User GetUser(string login) {
            return base.Channel.GetUser(login);
        }
        
        public System.Threading.Tasks.Task<DBModels.User> GetUserAsync(string login) {
            return base.Channel.GetUserAsync(login);
        }
        
        public void CreateUser(DBModels.User user) {
            base.Channel.CreateUser(user);
        }
        
        public System.Threading.Tasks.Task CreateUserAsync(DBModels.User user) {
            return base.Channel.CreateUserAsync(user);
        }
        
        public bool DoesUserExist(string login) {
            return base.Channel.DoesUserExist(login);
        }
        
        public System.Threading.Tasks.Task<bool> DoesUserExistAsync(string login) {
            return base.Channel.DoesUserExistAsync(login);
        }
        
        public DBModels.EditingInfo CreateEditingInfo(DBModels.User user, string filePath, bool isFileChanged, System.DateTime editingDate) {
            return base.Channel.CreateEditingInfo(user, filePath, isFileChanged, editingDate);
        }
        
        public System.Threading.Tasks.Task<DBModels.EditingInfo> CreateEditingInfoAsync(DBModels.User user, string filePath, bool isFileChanged, System.DateTime editingDate) {
            return base.Channel.CreateEditingInfoAsync(user, filePath, isFileChanged, editingDate);
        }
        
        public DBModels.EditingInfo[] GetEditingInfoes(string filePath) {
            return base.Channel.GetEditingInfoes(filePath);
        }
        
        public System.Threading.Tasks.Task<DBModels.EditingInfo[]> GetEditingInfoesAsync(string filePath) {
            return base.Channel.GetEditingInfoesAsync(filePath);
        }
    }
}
