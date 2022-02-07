﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.Service {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Service.IService", CallbackContract=typeof(Client.Service.IServiceCallback))]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Connect", ReplyAction="http://tempuri.org/IService/ConnectResponse")]
        int Connect(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Connect", ReplyAction="http://tempuri.org/IService/ConnectResponse")]
        System.Threading.Tasks.Task<int> ConnectAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Disconect", ReplyAction="http://tempuri.org/IService/DisconectResponse")]
        void Disconect(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Disconect", ReplyAction="http://tempuri.org/IService/DisconectResponse")]
        System.Threading.Tasks.Task DisconectAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/IsPalindrome", ReplyAction="http://tempuri.org/IService/IsPalindromeResponse")]
        string IsPalindrome(string msg);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/IsPalindrome", ReplyAction="http://tempuri.org/IService/IsPalindromeResponse")]
        System.Threading.Tasks.Task<string> IsPalindromeAsync(string msg);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService/SendMsg")]
        void SendMsg(string msg, int id);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService/SendMsg")]
        System.Threading.Tasks.Task SendMsgAsync(string msg, int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService/CallBackMsg")]
        void CallBackMsg(string msg);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : Client.Service.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.DuplexClientBase<Client.Service.IService>, Client.Service.IService {
        
        public ServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public ServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public ServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public int Connect(string name) {
            return base.Channel.Connect(name);
        }
        
        public System.Threading.Tasks.Task<int> ConnectAsync(string name) {
            return base.Channel.ConnectAsync(name);
        }
        
        public void Disconect(int id) {
            base.Channel.Disconect(id);
        }
        
        public System.Threading.Tasks.Task DisconectAsync(int id) {
            return base.Channel.DisconectAsync(id);
        }
        
        public string IsPalindrome(string msg) {
            return base.Channel.IsPalindrome(msg);
        }
        
        public System.Threading.Tasks.Task<string> IsPalindromeAsync(string msg) {
            return base.Channel.IsPalindromeAsync(msg);
        }
        
        public void SendMsg(string msg, int id) {
            base.Channel.SendMsg(msg, id);
        }
        
        public System.Threading.Tasks.Task SendMsgAsync(string msg, int id) {
            return base.Channel.SendMsgAsync(msg, id);
        }
    }
}
