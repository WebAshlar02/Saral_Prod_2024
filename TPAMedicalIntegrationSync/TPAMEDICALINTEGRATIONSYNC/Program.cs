//**********************************************************************
//*                      FUTURE GENERALI INDIA                        *    
//**********************************************************************/      
//*                  I N F O R M A T I O N                                       
//********************************************************************* 
// Sr. No.              : 1  
// Company              : Life            
// Module               : TPAMEDICALINTEGRATIONSYNC 
// Program Author       : Jayendra Patankar [WebAshlar01]            
// BRD/CR/Codesk No/Win : CR-7660        
// Date Of Creation     : 30-09-2023   
// Description          : CR-7660 New TPA Integration with assignment logic
//**********************************************************************//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWSaralDecision;
using System.Data;
using UWSaralObjects;
using UWSaralServices;
using Platform.Utilities.LoggerFramework;
using System.Diagnostics;
using System.Configuration;

namespace TPAMEDICALINTEGRATIONSYNC
{
    class Program
    {
        UWSaralDecision.CommFun objCommFun;
        DataSet _dsApplicationList;
        //1.0 Begin of Changes; Jayendra - [Webashlar01]
        DataSet _dsTPAMasters;
        //1.0 End of Changes; Jayendra - [Webashlar01]
        DataSet _dsApplicationDetails;
        static void Main(string[] args)
        {
            Program objProgram = new Program();
            objProgram.RevisedLogic();
            /*
            //check whether application is already running or not
            if (true)
            {
                TPARegisterationSummary objTPARegisterationSummary = new TPARegisterationSummary();
                Program objprogram = new Program();
                DataSet _ds = new DataSet();
                List<UWSaralObjects.TPARegisteration> LstTpaRegisteration = new List<UWSaralObjects.TPARegisteration>();

                //save service called 
                Logger.Error("PageName :TPAMEDICALINTEGRATIONSYNC.CS // MethodeName :Main" + System.Environment.NewLine);
                objprogram.SaveMedicalTest();

                //fetch medical report
                Logger.Error("PageName :TPAMEDICALINTEGRATIONSYNC.CS // MethodeName :Main" + System.Environment.NewLine);
                objprogram.GetServiceDataMedicalTest(ref _ds);

                if (_ds != null && _ds.Tables.Count > 0 && _ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < _ds.Tables[0].Rows.Count; i++)
                    {
                        //fill object
                        Program objProgram = new Program();
                        UWSaralObjects.TPARegisteration objTPARegisteration = new UWSaralObjects.TPARegisteration();
                        Logger.Error("PageName :TPAMEDICALINTEGRATIONSYNC.CS // MethodeName :Main" + System.Environment.NewLine);
                        objprogram.FillTPARegisteration(objTPARegisteration, _ds.Tables[0].Rows[i]);
                        //call service 
                        TPARegis objTpaRegis = new TPARegis();
                        Logger.Error("PageName :TPAMEDICALINTEGRATIONSYNC.CS // MethodeName :Main " + objTPARegisteration.ProposalNo + System.Environment.NewLine);
                        objTpaRegis.PushDataIntoTPARegisteration(objTPARegisteration);
                        LstTpaRegisteration.Add(objTPARegisteration);
                    }
                    objTPARegisterationSummary.LstTPARegisteration = LstTpaRegisteration;
                }
                Logger.Error("PageName :TPAMEDICALINTEGRATIONSYNC.CS // MethodeName :Main" + System.Environment.NewLine);
                objprogram.UpdateTPARegisterRefNo(objTPARegisterationSummary.DtTPARegisteration);
            }
            */
        }
        private void SaveMedicalTest()
        {
            Logger.Error("STAG 3 :PageName :TPAMEDICALINTEGRATIONSYNC.CS // MethodeName :SaveMedicalTest Start" + System.Environment.NewLine);
            UWSaralDecision.CommFun objComm = new UWSaralDecision.CommFun();
            DataSet _ds = new DataSet();
            objComm.PostTpaMedicalTest(ref _ds);
            Logger.Error("STAG 3 :PageName :TPAMEDICALINTEGRATIONSYNC.CS // MethodeName :SaveMedicalTest End" + System.Environment.NewLine);
        }

        private void GetServiceDataMedicalTest(ref DataSet _ds)
        {
            Logger.Error("STAG 4 :PageName :TPAMEDICALINTEGRATIONSYNC.CS // MethodeName :GetServiceDataMedicalTest Start" + System.Environment.NewLine);
            UWSaralDecision.CommFun objComm = new UWSaralDecision.CommFun();
            objComm.GetTpaMedicalTest(ref _ds);
            Logger.Error("STAG 4 :PageName :TPAMEDICALINTEGRATIONSYNC.CS // MethodeName :GetServiceDataMedicalTest End" + System.Environment.NewLine);

        }
        private void FillTPARegisteration(UWSaralObjects.TPARegisteration objRegisteration, DataRow dr)
        {
            try
            {
                Logger.Error("STAG 5 :PageName :TPAMEDICALINTEGRATIONSYNC.CS // MethodeName :FillTPARegisteration Start" + System.Environment.NewLine);
                objRegisteration.ProposalNo = Convert.ToString(dr["ProposalNo"]);
                objRegisteration.UserName = Convert.ToString(dr["UserName"]);
                objRegisteration.Password = Convert.ToString(dr["Password"]);
                objRegisteration.ProposalDate = Convert.ToString(dr["ProposalDate"]);
                objRegisteration.ProposerName = Convert.ToString(dr["CLIENTNAME"]);
                objRegisteration.Gender = Convert.ToString(dr["GENDER"]);
                objRegisteration.Address1 = Convert.ToString(dr["ADDRESS1"]);
                objRegisteration.City = Convert.ToString(dr["CITY"]);
                objRegisteration.State = Convert.ToString(dr["STATE"]);
                objRegisteration.Pincode = Convert.ToString(dr["PINCODE"]);
                objRegisteration.MobileNo = Convert.ToString(dr["MBLPHONE"]);
                objRegisteration.HNIFlag = Convert.ToString(dr["HNIFlag"]);
                objRegisteration.HomeVisitFlag = Convert.ToString(dr["HomeVisitFlag"]);
                objRegisteration.BranchName = Convert.ToString(dr["BranchName"]);
                objRegisteration.MemberDOB = Convert.ToString(dr["MemberDOB"]);
                objRegisteration.CustomerEmail = Convert.ToString(dr["CustomerEmail"]);
                objRegisteration.TestConducted = Convert.ToString(dr["FOLLOW_DESC"]);
                objRegisteration.Address2 = Convert.ToString(dr["Address2"]);
                objRegisteration.District = Convert.ToString(dr["District"]);
                objRegisteration.MasterPolicyNo = Convert.ToString(dr["MasterPolicyNo"]);
                objRegisteration.ProposerInitial = Convert.ToString(dr["ProposerInitial"]);
                objRegisteration.Taluka = Convert.ToString(dr["Taluka"]);
                objRegisteration.LandMark = Convert.ToString(dr["LandMark"]);
                objRegisteration.Telephone = Convert.ToString(dr["Telephone"]);
                objRegisteration.Telephone = Convert.ToString(dr["PHONE1"]);
                objRegisteration.AgentCode = Convert.ToString(dr["AgentCode"]);
                objRegisteration.AgentName = Convert.ToString(dr["AgentName"]);
                objRegisteration.AgentContactDetails = Convert.ToString(dr["AgentContactDetails"]);
                objRegisteration.Channel = Convert.ToString(dr["Channel"]);
                objRegisteration.PlanType = Convert.ToString(dr["PlanType"]);
                objRegisteration.ProductName = Convert.ToString(dr["ProductName"]);
                objRegisteration.Remark = Convert.ToString(dr["Remark"]);
                objRegisteration.PreferredDate = Convert.ToString(dr["PreferredDate"]);
                objRegisteration.PreferredTime = Convert.ToString(dr["PreferredTime"]);
                objRegisteration.PreferredProviderNo = Convert.ToString(dr["PreferredProviderNo"]);
                objRegisteration.Age = Convert.ToString(dr["Age"]);
                objRegisteration.RMContactNumber = Convert.ToString(dr["RMContactNumber"]);
                objRegisteration.RMEmailId = Convert.ToString(dr["RMEmailId"]);
                objRegisteration.IMDEmailId = Convert.ToString(dr["IMDEmailId"]);
                objRegisteration.PaymentType = Convert.ToString(dr["PaymentType"]);
                objRegisteration.Status = Convert.ToString(dr["Status"]);
                objRegisteration.AppilcantOfficeNumber = Convert.ToString(dr["AppilcantOfficeNumber"]);
                objRegisteration.DCName = Convert.ToString(dr["DCName"]);
                objRegisteration.ProposalStatus = Convert.ToString(dr["ProposalStatus"]);
                objRegisteration.CashieringDate = Convert.ToString(dr["CashieringDate"]);
                objRegisteration.CashieredAmount = Convert.ToString(dr["CashieredAmount"]);
                objRegisteration.PCName = Convert.ToString(dr["PCName"]);
                objRegisteration.Region = Convert.ToString(dr["Region"]);
                objRegisteration.RepeatCase = Convert.ToString(dr["RepeatCase"]);
                objRegisteration.TPACost = Convert.ToString(dr["TPACost"]);
                objRegisteration.PreferredDCDetails = Convert.ToString(dr["PreferredDCDetails"]);
                objRegisteration.RegisterKey = Convert.ToInt32(dr["RegisterKey"]);
                Logger.Error("STAG 5 :PageName :TPAMEDICALINTEGRATIONSYNC.CS // MethodeName :FillTPARegisteration End" + System.Environment.NewLine);
            }
            catch (Exception Error)
            {
                UWSaralServices.CommFun objComm = new UWSaralServices.CommFun();
                Logger.Error("STAG 5 :PageName :TpaMedicalIntegraionSync.CS // MethodeName :FillTPARegisteration Error :" + System.Environment.NewLine + Error.ToString());
                objComm.SaveErrorLogs("", "Failed", "TpaMedicalIntegraionSync", "Main.cs", "FillTPARegisteration ", "E-Error", "", "", Error.ToString());
            }
        }

        private void UpdateTPARegisterRefNo(DataTable dt)
        {
            Logger.Error("STAG 3 :PageName :TPAMEDICALINTEGRATIONSYNC.CS // MethodeName :UpdateTPARegisterRefNo Start" + System.Environment.NewLine);
            int intResponse = -1;
            UWSaralDecision.CommFun objComm = new UWSaralDecision.CommFun();
            objComm.UpdateTPARegistertaionRerNo(dt, ref intResponse);
            Logger.Error("STAG 3 :PageName :TPAMEDICALINTEGRATIONSYNC.CS // MethodeName :UpdateTPARegisterRefNo End" + System.Environment.NewLine);
        }

        //check whether application is running or not 
        private static bool AlreadyRunning()
        {
            Process[] processes = Process.GetProcesses();
            Process currentProc = Process.GetCurrentProcess();

            foreach (Process process in processes)
            {
                try
                {
                    if (process.Modules[0].FileName == System.Reflection.Assembly.GetExecutingAssembly().Location
                                && currentProc.Id != process.Id)
                        return true;
                }
                catch (Exception ex)
                {
                    UWSaralServices.CommFun objComm = new UWSaralServices.CommFun();
                    objComm.SaveErrorLogs(string.Empty, "Failed", "TPA_DMS_Service", "Commfun.cs", "Main", "E-Error", "", "", ex.ToString());
                }
            }

            return false;
        }

        private bool RevisedLogic()
        {
            //fetch application with partner to register
            objCommFun = new UWSaralDecision.CommFun();
            _dsApplicationList = new DataSet();
            //1.0 Begin of Changes; Jayendra - [Webashlar01]
            _dsTPAMasters = new DataSet();
            //1.0 End of Changes; Jayendra - [Webashlar01]
            TPARegis objTpaRegis = new TPARegis();
            objCommFun.FetchApplicationPartnerToRegister(ref _dsApplicationList);

            if (_dsApplicationList != null && _dsApplicationList.Tables.Count > 0 && _dsApplicationList.Tables[0].Rows.Count > 0)
            {
                //1.0 Begin of Changes; Jayendra - [Webashlar01]
                objCommFun.GetTPAMASTERPARTNERS(ref _dsTPAMasters);
                //1.0 End of Changes; Jayendra - [Webashlar01]
                UWSaralObjects.TPARegisteration objTPARegisteration;
                for (int i = 0; i < _dsApplicationList.Tables[0].Rows.Count; i++)
                {
                    //if (_dsApplicationList.Tables[0].Rows[i]["FgiRefNo"].ToString().Contains("PD0007491"))
                    //{
                    objTPARegisteration = new UWSaralObjects.TPARegisteration();
                    int intRet = -1;
                    //1.0 Begin of Changes; Jayendra - [Webashlar01]
                    int partnerRefKey = Convert.ToInt32(_dsApplicationList.Tables[0].Rows[i]["PartnerRefKey"]);
                    if (_dsTPAMasters != null && _dsTPAMasters.Tables.Count > 0 && _dsTPAMasters.Tables[0].Rows.Count > 0)
                    {
                        DataRow rowFiltered = _dsTPAMasters.Tables[0].AsEnumerable()
                                              .Where(row => row.Field<int>("SrNo") == partnerRefKey).FirstOrDefault();

                        if (rowFiltered != null && rowFiltered["IsRESTAPI"].ToString().ToLower() == "true" && !string.IsNullOrEmpty(rowFiltered["APIUrl"].ToString()))
                        {
                            //fetch application details 
                            FetchApplicationDetailsForHealthIndia(Convert.ToString(_dsApplicationList.Tables[0].Rows[i]["FgiRefNo"]), Convert.ToString(_dsApplicationList.Tables[0].Rows[i]["APPSOURCE"]), Convert.ToString(_dsApplicationList.Tables[0].Rows[i]["CHANNEL"]), ref _dsApplicationDetails);
                            //fill object 
                            FillTPARegisteration(objTPARegisteration, _dsApplicationDetails);
                            //register case 
                            if (objTPARegisteration != null && !string.IsNullOrEmpty(objTPARegisteration.MasterPolicyNo))
                            {
                                TPARegisterationByRestAPI(objTPARegisteration, rowFiltered["APIUrl"].ToString());
                                //update its status                                
                                UpdateStatusFlag(objTPARegisteration, ref intRet);
                            }
                        }
                        //1.0 End of Changes; Jayendra - [Webashlar01]
                        else
                        {
                            //fetch application data to register 
                            switch (partnerRefKey)
                            {
                                case 1:
                                    {
                                        //fetch application details 
                                        FetchApplicationDetailsForHealthIndia(Convert.ToString(_dsApplicationList.Tables[0].Rows[i]["FgiRefNo"]), Convert.ToString(_dsApplicationList.Tables[0].Rows[i]["APPSOURCE"]), Convert.ToString(_dsApplicationList.Tables[0].Rows[i]["CHANNEL"]), ref _dsApplicationDetails);
                                        //fill object 
                                        FillTPARegisteration(objTPARegisteration, _dsApplicationDetails);
                                        //register case 
                                        if (objTPARegisteration != null && !string.IsNullOrEmpty(objTPARegisteration.MasterPolicyNo))
                                        {
                                            objTpaRegis.PushDataIntoTPARegisteration(objTPARegisteration);
                                            //update its status                                
                                            UpdateStatusFlag(objTPARegisteration, ref intRet);
                                        }
                                        break;
                                    }
                                //}
                                case 3: // for Docs App
                                    {
                                        UWSaralObjects.DocsAppRegisteration objDocsAppRegisteration = new UWSaralObjects.DocsAppRegisteration();
                                        //fetch application details 
                                        FetchApplicationDetailsForDocsApp(Convert.ToString(_dsApplicationList.Tables[0].Rows[i]["FgiRefNo"]), Convert.ToString(_dsApplicationList.Tables[0].Rows[i]["APPSOURCE"]), Convert.ToString(_dsApplicationList.Tables[0].Rows[i]["CHANNEL"]), ref _dsApplicationDetails);
                                        //fill object 
                                        FillDocsAppRegisteration(objDocsAppRegisteration, _dsApplicationDetails);
                                        //register case 
                                        if (objDocsAppRegisteration != null && !string.IsNullOrEmpty(objDocsAppRegisteration.ProposalNo))
                                        {
                                            DocsAppRegisterationandUpdateStatusFlag(objDocsAppRegisteration);
                                        }
                                        break;
                                    }
                            }
                        }
                    }
                }
            }
            return true;
        }

        private void FetchApplicationDetailsForHealthIndia(string strFgiRefNo, string strApplicationSource, string strApplicationChannel, ref DataSet _ds)
        {
            objCommFun = new UWSaralDecision.CommFun();
            objCommFun.FetchApplicationDetailsForHealthIndia(strFgiRefNo, strApplicationSource, strApplicationChannel, ref _ds);
        }

        private void FillTPARegisteration(UWSaralObjects.TPARegisteration objRegisteration, DataSet _ds)
        {
            try
            {

                Logger.Error("STAG 5 :PageName :TPAMEDICALINTEGRATIONSYNC.CS // MethodeName :FillTPARegisteration Start" + System.Environment.NewLine);
                if (_ds != null && _ds.Tables.Count > 0 && _ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = _ds.Tables[0].Rows[0];
                    objRegisteration.ProposalNo = Convert.ToString(dr["ProposalNo"]);
                    objRegisteration.UserName = Convert.ToString(dr["UserName"]);
                    objRegisteration.Password = Convert.ToString(dr["Password"]);
                    objRegisteration.ProposalDate = Convert.ToString(dr["ProposalDate"]);
                    objRegisteration.ProposerName = Convert.ToString(dr["CLIENTNAME"]);
                    objRegisteration.Gender = Convert.ToString(dr["GENDER"]);
                    objRegisteration.Address1 = Convert.ToString(dr["ADDRESS1"]);
                    objRegisteration.City = Convert.ToString(dr["CITY"]);
                    objRegisteration.State = Convert.ToString(dr["STATE"]);
                    objRegisteration.Pincode = Convert.ToString(dr["PINCODE"]);
                    objRegisteration.MobileNo = Convert.ToString(dr["MBLPHONE"]);
                    objRegisteration.HNIFlag = Convert.ToString(dr["HNIFlag"]);
                    objRegisteration.HomeVisitFlag = Convert.ToString(dr["HomeVisitFlag"]);
                    objRegisteration.BranchName = Convert.ToString(dr["BranchName"]);
                    objRegisteration.MemberDOB = Convert.ToString(dr["MemberDOB"]);
                    objRegisteration.CustomerEmail = Convert.ToString(dr["CustomerEmail"]);
                    objRegisteration.TestConducted = Convert.ToString(dr["FOLLOW_DESC"]);
                    objRegisteration.Address2 = Convert.ToString(dr["Address2"]);
                    objRegisteration.District = Convert.ToString(dr["District"]);
                    objRegisteration.MasterPolicyNo = Convert.ToString(dr["MasterPolicyNo"]);
                    objRegisteration.ProposerInitial = Convert.ToString(dr["ProposerInitial"]);
                    objRegisteration.Taluka = Convert.ToString(dr["Taluka"]);
                    objRegisteration.LandMark = Convert.ToString(dr["LandMark"]);
                    objRegisteration.Telephone = Convert.ToString(dr["Telephone"]);
                    objRegisteration.Telephone = Convert.ToString(dr["PHONE1"]);
                    objRegisteration.AgentCode = Convert.ToString(dr["AgentCode"]);
                    objRegisteration.AgentName = Convert.ToString(dr["AgentName"]);
                    objRegisteration.AgentContactDetails = Convert.ToString(dr["AgentContactDetails"]);
                    objRegisteration.Channel = Convert.ToString(dr["Channel"]);
                    objRegisteration.PlanType = Convert.ToString(dr["PlanType"]);
                    objRegisteration.ProductName = Convert.ToString(dr["ProductName"]);
                    objRegisteration.Remark = Convert.ToString(dr["Remark"]);
                    objRegisteration.PreferredDate = Convert.ToString(dr["PreferredDate"]);
                    objRegisteration.PreferredTime = Convert.ToString(dr["PreferredTime"]);
                    objRegisteration.PreferredProviderNo = Convert.ToString(dr["PreferredProviderNo"]);
                    objRegisteration.Age = Convert.ToString(dr["Age"]);
                    objRegisteration.RMContactNumber = Convert.ToString(dr["RMContactNumber"]);
                    objRegisteration.RMEmailId = Convert.ToString(dr["RMEmailId"]);
                    objRegisteration.IMDEmailId = Convert.ToString(dr["IMDEmailId"]);
                    objRegisteration.PaymentType = Convert.ToString(dr["PaymentType"]);
                    objRegisteration.Status = Convert.ToString(dr["Status"]);
                    objRegisteration.AppilcantOfficeNumber = Convert.ToString(dr["AppilcantOfficeNumber"]);
                    objRegisteration.DCName = Convert.ToString(dr["DCName"]);
                    objRegisteration.ProposalStatus = Convert.ToString(dr["ProposalStatus"]);
                    objRegisteration.CashieringDate = Convert.ToString(dr["CashieringDate"]);
                    objRegisteration.CashieredAmount = Convert.ToString(dr["CashieredAmount"]);
                    objRegisteration.PCName = Convert.ToString(dr["PCName"]);
                    objRegisteration.Region = Convert.ToString(dr["Region"]);
                    objRegisteration.RepeatCase = Convert.ToString(dr["RepeatCase"]);
                    objRegisteration.TPACost = Convert.ToString(dr["TPACost"]);
                    objRegisteration.PreferredDCDetails = Convert.ToString(dr["PreferredDCDetails"]);
                    objRegisteration.RegisterKey = Convert.ToInt32(dr["RegisterKey"]);
                }
                Logger.Error("STAG 5 :PageName :TPAMEDICALINTEGRATIONSYNC.CS // MethodeName :FillTPARegisteration End" + System.Environment.NewLine);
            }
            catch (Exception Error)
            {
                UWSaralServices.CommFun objComm = new UWSaralServices.CommFun();
                Logger.Error("STAG 5 :PageName :TpaMedicalIntegraionSync.CS // MethodeName :FillTPARegisteration Error :" + System.Environment.NewLine + Error.ToString());
                objComm.SaveErrorLogs("", "Failed", "TpaMedicalIntegraionSync", "Main.cs", "FillTPARegisteration ", "E-Error", "", "", Error.ToString());
            }
        }

        private void UpdateStatusFlag(UWSaralObjects.TPARegisteration objTpaRegisteration, ref int intRet)
        {
            objCommFun = new UWSaralDecision.CommFun();
            objCommFun.UpdateApplicationStatusForHealthIndia(objTpaRegisteration.ProposalNo, objTpaRegisteration.ControlNumber, objTpaRegisteration.IsRequestSuccess, objTpaRegisteration.Response, objTpaRegisteration.Request, ref intRet);
        }

        // DOCS APP Integration BY BRIJESH PANDEY START
        private void FetchApplicationDetailsForDocsApp(string strFgiRefNo, string strApplicationSource, string strApplicationChannel, ref DataSet _ds)
        {
            objCommFun = new UWSaralDecision.CommFun();
            objCommFun.FetchApplicationDetailsForDocsApp(strFgiRefNo, strApplicationSource, strApplicationChannel, ref _ds);
        }
        private void FillDocsAppRegisteration(UWSaralObjects.DocsAppRegisteration objRegisteration, DataSet _ds)
        {
            try
            {

                Logger.Error("STAG 5 :PageName :DOCSAPPMEDICALINTEGRATIONSYNC.CS // MethodeName :FillDocsAppRegisteration Start" + System.Environment.NewLine);
                if (_ds != null && _ds.Tables.Count > 0 && _ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = _ds.Tables[0].Rows[0];
                    objRegisteration.Source = Convert.ToString(dr["Source"]);
                    objRegisteration.Process = Convert.ToString(dr["Process"]);
                    objRegisteration.PriorityStatus = Convert.ToString(dr["PriorityStatus"]);
                    objRegisteration.CallDate = Convert.ToString(dr["CallDate"]);
                    objRegisteration.CallTime = Convert.ToString(dr["CallTime"]);
                    objRegisteration.MerType = Convert.ToString(dr["MerType"]);

                    objRegisteration.ProposalNo = Convert.ToString(dr["ProposalNo"]);
                    objRegisteration.LAName = Convert.ToString(dr["LAName"]);
                    objRegisteration.Gender = Convert.ToString(dr["Gender"]);
                    objRegisteration.DOB = Convert.ToString(dr["DOB"]);
                    objRegisteration.MobileNo = Convert.ToString(dr["MobileNo"]);
                    objRegisteration.PhoneNo = Convert.ToString(dr["PhoneNo"]);
                }
                Logger.Error("STAG 5 :PageName :DOCSAPPMEDICALINTEGRATIONSYNC.CS // MethodeName :FillDocsAppRegisteration End" + System.Environment.NewLine);
            }
            catch (Exception Error)
            {
                UWSaralServices.CommFun objComm = new UWSaralServices.CommFun();
                Logger.Error("STAG 5 :PageName :DOCSAPPMEDICALINTEGRATIONSYNC.CS // MethodeName :FillDocsAppRegisteration Error :" + System.Environment.NewLine + Error.ToString());
                objComm.SaveErrorLogs("", "Failed", "DOCSAPPMEDICALINTEGRATIONSYNC", "Main.cs", "FillDocsAppRegisteration ", "E-Error", "", "", Error.ToString());
            }
        }
        private void DocsAppRegisterationandUpdateStatusFlag(UWSaralObjects.DocsAppRegisteration objDocsAppRegisteration)
        {
            DocsAppResponseDO docsAppResponseDO = new DocsAppResponseDO();
            DocsAppRequestDO docsAppRequest = new DocsAppRequestDO();

            docsAppRequest.source = objDocsAppRegisteration.Source;
            docsAppRequest.process = objDocsAppRegisteration.Process;
            docsAppRequest.priorityStatus = objDocsAppRegisteration.PriorityStatus;
            docsAppRequest.callDate = objDocsAppRegisteration.CallDate;
            docsAppRequest.callTime = objDocsAppRegisteration.CallTime;
            docsAppRequest.merType = objDocsAppRegisteration.MerType;

            docsAppRequest.applicationId = objDocsAppRegisteration.ProposalNo;
            docsAppRequest.name = objDocsAppRegisteration.LAName;
            docsAppRequest.dateOfBirth = objDocsAppRegisteration.DOB;
            docsAppRequest.gender = objDocsAppRegisteration.Gender == "M" ? "MALE" : "FEMALE";
            docsAppRequest.phonenumber = objDocsAppRegisteration.MobileNo;
            docsAppRequest.altphonenumber = objDocsAppRegisteration.PhoneNo;
            docsAppRequest.panCard = "";
            docsAppRequest.nomineeName = "";
            docsAppRequest.nomineeDOB = "";
            docsAppRequest.planDetails = "";

            int intRet = -1;
            string inputJson = Newtonsoft.Json.JsonConvert.SerializeObject(docsAppRequest);
            string outputJson = "";
            string ErrorMsg = "";
            bool IsSuccess = false;
            string ControlNumber = "";

            try
            {
                string DocsAppPostUrl = ConfigurationSettings.AppSettings["DocsAppPostUrl"].ToString();
                System.Net.ServicePointManager.SecurityProtocol = (System.Net.SecurityProtocolType)3072;
                System.Net.WebClient objWebClient = new System.Net.WebClient();
                objWebClient.Headers["Content-type"] = "application/json";
                objWebClient.Headers["x-api-key"] = ConfigurationSettings.AppSettings["DocsAppKey"].ToString();
                objWebClient.Encoding = Encoding.UTF8;
                outputJson = objWebClient.UploadString(DocsAppPostUrl, inputJson);
                docsAppResponseDO = Newtonsoft.Json.JsonConvert.DeserializeObject<DocsAppResponseDO>(outputJson);
                IsSuccess = docsAppResponseDO.success == "1" ? true : false;
                ControlNumber = Convert.ToString(docsAppResponseDO.data.id);
            }
            catch (Exception ex)
            {
                ErrorMsg = " - ErrorMsg " + ex.ToString();
            }

            //update status  
            objCommFun = new UWSaralDecision.CommFun();
            objCommFun.UpdateApplicationStatusForDocsApp(objDocsAppRegisteration.ProposalNo, ControlNumber, IsSuccess, outputJson + ErrorMsg, inputJson, ref intRet);
        }
        // BY BRIJESH PANDEY END

        //1.0 Begin of Changes; Jayendra - [Webashlar01]
        private void TPARegisterationByRestAPI(UWSaralObjects.TPARegisteration objTPARegisteration, string apiURL)
        {
            APIResponseDO responseDO = new APIResponseDO();
            string inputJson = Newtonsoft.Json.JsonConvert.SerializeObject(objTPARegisteration);
            string outputJson = "";
            string ErrorMsg = "";
            bool IsSuccess = false;
            try
            {
                System.Net.ServicePointManager.SecurityProtocol = (System.Net.SecurityProtocolType)3072;
                System.Net.WebClient objWebClient = new System.Net.WebClient();
                objWebClient.Headers["Content-type"] = "application/json";
                objWebClient.Encoding = Encoding.UTF8;
                outputJson = objWebClient.UploadString(apiURL, inputJson);
                responseDO = Newtonsoft.Json.JsonConvert.DeserializeObject<APIResponseDO>(outputJson);
                IsSuccess = responseDO.ResponseMessage == "Success" ? true : false;
            }
            catch (Exception ex)
            {
                ErrorMsg = " - ErrorMsg " + ex.ToString();
            }
        }
        //1.0 End of Changes; Jayendra - [Webashlar01]
    }
}
