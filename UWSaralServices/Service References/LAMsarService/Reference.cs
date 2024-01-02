﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UWSaralServices.LAMsarService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="test", Namespace="http://schemas.datacontract.org/2004/07/")]
    [System.SerializableAttribute()]
    public partial class test : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ErrorCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ErrorMessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal FSARField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal MSARField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal PPCField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal TSARField;
        
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
        public string ErrorCode {
            get {
                return this.ErrorCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrorCodeField, value) != true)) {
                    this.ErrorCodeField = value;
                    this.RaisePropertyChanged("ErrorCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ErrorMessage {
            get {
                return this.ErrorMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrorMessageField, value) != true)) {
                    this.ErrorMessageField = value;
                    this.RaisePropertyChanged("ErrorMessage");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal FSAR {
            get {
                return this.FSARField;
            }
            set {
                if ((this.FSARField.Equals(value) != true)) {
                    this.FSARField = value;
                    this.RaisePropertyChanged("FSAR");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal MSAR {
            get {
                return this.MSARField;
            }
            set {
                if ((this.MSARField.Equals(value) != true)) {
                    this.MSARField = value;
                    this.RaisePropertyChanged("MSAR");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal PPC {
            get {
                return this.PPCField;
            }
            set {
                if ((this.PPCField.Equals(value) != true)) {
                    this.PPCField = value;
                    this.RaisePropertyChanged("PPC");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal TSAR {
            get {
                return this.TSARField;
            }
            set {
                if ((this.TSARField.Equals(value) != true)) {
                    this.TSARField = value;
                    this.RaisePropertyChanged("TSAR");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="LAMsarService.IService")]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/CalculateTSAR_FSAR_MSAR", ReplyAction="http://tempuri.org/IService/CalculateTSAR_FSAR_MSARResponse")]
        UWSaralServices.LAMsarService.test CalculateTSAR_FSAR_MSAR(string LAClientId, string ProposerClientID, string PayerClientId, string KeyWord, string RequestDetails, decimal OtherPolicyDetails, string PartnerId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/CalculateTSAR_FSAR_MSAR", ReplyAction="http://tempuri.org/IService/CalculateTSAR_FSAR_MSARResponse")]
        System.Threading.Tasks.Task<UWSaralServices.LAMsarService.test> CalculateTSAR_FSAR_MSARAsync(string LAClientId, string ProposerClientID, string PayerClientId, string KeyWord, string RequestDetails, decimal OtherPolicyDetails, string PartnerId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : UWSaralServices.LAMsarService.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<UWSaralServices.LAMsarService.IService>, UWSaralServices.LAMsarService.IService {
        
        public ServiceClient() {
        }
        
        public ServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public UWSaralServices.LAMsarService.test CalculateTSAR_FSAR_MSAR(string LAClientId, string ProposerClientID, string PayerClientId, string KeyWord, string RequestDetails, decimal OtherPolicyDetails, string PartnerId) {
            return base.Channel.CalculateTSAR_FSAR_MSAR(LAClientId, ProposerClientID, PayerClientId, KeyWord, RequestDetails, OtherPolicyDetails, PartnerId);
        }
        
        public System.Threading.Tasks.Task<UWSaralServices.LAMsarService.test> CalculateTSAR_FSAR_MSARAsync(string LAClientId, string ProposerClientID, string PayerClientId, string KeyWord, string RequestDetails, decimal OtherPolicyDetails, string PartnerId) {
            return base.Channel.CalculateTSAR_FSAR_MSARAsync(LAClientId, ProposerClientID, PayerClientId, KeyWord, RequestDetails, OtherPolicyDetails, PartnerId);
        }
    }
}
