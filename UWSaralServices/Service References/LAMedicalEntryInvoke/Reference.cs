﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UWSaralServices.LAMedicalEntryInvoke {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://MUMHOIBPMDEV01.FGI.AD:9080/teamworks/webservices/FGLIFE/MedicalDataEntryIn" +
        "voke.tws", ConfigurationName="LAMedicalEntryInvoke.MedicalDataEntryInvokePortType")]
    public interface MedicalDataEntryInvokePortType {
        
        // CODEGEN: Generating message contract since element name applicationNumber from namespace http://MUMHOIBPMDEV01.FGI.AD:9080/teamworks/webservices/FGLIFE/MedicalDataEntryInvoke.tws is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://MUMHOIBPMDEV01.FGI.AD:9080/teamworks/webservices/FGLIFE/MedicalDataEntryIn" +
            "voke.tws/startMedicaldataEntry", ReplyAction="*")]
        UWSaralServices.LAMedicalEntryInvoke.startMedicaldataEntryResponse startMedicaldataEntry(UWSaralServices.LAMedicalEntryInvoke.startMedicaldataEntryRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://MUMHOIBPMDEV01.FGI.AD:9080/teamworks/webservices/FGLIFE/MedicalDataEntryIn" +
            "voke.tws/startMedicaldataEntry", ReplyAction="*")]
        System.Threading.Tasks.Task<UWSaralServices.LAMedicalEntryInvoke.startMedicaldataEntryResponse> startMedicaldataEntryAsync(UWSaralServices.LAMedicalEntryInvoke.startMedicaldataEntryRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class startMedicaldataEntryRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="startMedicaldataEntry", Namespace="http://MUMHOIBPMDEV01.FGI.AD:9080/teamworks/webservices/FGLIFE/MedicalDataEntryIn" +
            "voke.tws", Order=0)]
        public UWSaralServices.LAMedicalEntryInvoke.startMedicaldataEntryRequestBody Body;
        
        public startMedicaldataEntryRequest() {
        }
        
        public startMedicaldataEntryRequest(UWSaralServices.LAMedicalEntryInvoke.startMedicaldataEntryRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://MUMHOIBPMDEV01.FGI.AD:9080/teamworks/webservices/FGLIFE/MedicalDataEntryIn" +
        "voke.tws")]
    public partial class startMedicaldataEntryRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string applicationNumber;
        
        public startMedicaldataEntryRequestBody() {
        }
        
        public startMedicaldataEntryRequestBody(string applicationNumber) {
            this.applicationNumber = applicationNumber;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class startMedicaldataEntryResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="startMedicaldataEntryResponse", Namespace="http://MUMHOIBPMDEV01.FGI.AD:9080/teamworks/webservices/FGLIFE/MedicalDataEntryIn" +
            "voke.tws", Order=0)]
        public UWSaralServices.LAMedicalEntryInvoke.startMedicaldataEntryResponseBody Body;
        
        public startMedicaldataEntryResponse() {
        }
        
        public startMedicaldataEntryResponse(UWSaralServices.LAMedicalEntryInvoke.startMedicaldataEntryResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://MUMHOIBPMDEV01.FGI.AD:9080/teamworks/webservices/FGLIFE/MedicalDataEntryIn" +
        "voke.tws")]
    public partial class startMedicaldataEntryResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string status;
        
        public startMedicaldataEntryResponseBody() {
        }
        
        public startMedicaldataEntryResponseBody(string status) {
            this.status = status;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface MedicalDataEntryInvokePortTypeChannel : UWSaralServices.LAMedicalEntryInvoke.MedicalDataEntryInvokePortType, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MedicalDataEntryInvokePortTypeClient : System.ServiceModel.ClientBase<UWSaralServices.LAMedicalEntryInvoke.MedicalDataEntryInvokePortType>, UWSaralServices.LAMedicalEntryInvoke.MedicalDataEntryInvokePortType {
        
        public MedicalDataEntryInvokePortTypeClient() {
        }
        
        public MedicalDataEntryInvokePortTypeClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MedicalDataEntryInvokePortTypeClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MedicalDataEntryInvokePortTypeClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MedicalDataEntryInvokePortTypeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        UWSaralServices.LAMedicalEntryInvoke.startMedicaldataEntryResponse UWSaralServices.LAMedicalEntryInvoke.MedicalDataEntryInvokePortType.startMedicaldataEntry(UWSaralServices.LAMedicalEntryInvoke.startMedicaldataEntryRequest request) {
            return base.Channel.startMedicaldataEntry(request);
        }
        
        public string startMedicaldataEntry(string applicationNumber) {
            UWSaralServices.LAMedicalEntryInvoke.startMedicaldataEntryRequest inValue = new UWSaralServices.LAMedicalEntryInvoke.startMedicaldataEntryRequest();
            inValue.Body = new UWSaralServices.LAMedicalEntryInvoke.startMedicaldataEntryRequestBody();
            inValue.Body.applicationNumber = applicationNumber;
            UWSaralServices.LAMedicalEntryInvoke.startMedicaldataEntryResponse retVal = ((UWSaralServices.LAMedicalEntryInvoke.MedicalDataEntryInvokePortType)(this)).startMedicaldataEntry(inValue);
            return retVal.Body.status;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<UWSaralServices.LAMedicalEntryInvoke.startMedicaldataEntryResponse> UWSaralServices.LAMedicalEntryInvoke.MedicalDataEntryInvokePortType.startMedicaldataEntryAsync(UWSaralServices.LAMedicalEntryInvoke.startMedicaldataEntryRequest request) {
            return base.Channel.startMedicaldataEntryAsync(request);
        }
        
        public System.Threading.Tasks.Task<UWSaralServices.LAMedicalEntryInvoke.startMedicaldataEntryResponse> startMedicaldataEntryAsync(string applicationNumber) {
            UWSaralServices.LAMedicalEntryInvoke.startMedicaldataEntryRequest inValue = new UWSaralServices.LAMedicalEntryInvoke.startMedicaldataEntryRequest();
            inValue.Body = new UWSaralServices.LAMedicalEntryInvoke.startMedicaldataEntryRequestBody();
            inValue.Body.applicationNumber = applicationNumber;
            return ((UWSaralServices.LAMedicalEntryInvoke.MedicalDataEntryInvokePortType)(this)).startMedicaldataEntryAsync(inValue);
        }
    }
}