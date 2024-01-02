/*
*********************************************************************************************************************************
COMMENT ID: 1
COMMENTOR NAME :Akshada N Wagh
METHODE/EVENT:
REMARK: CR 26273 Reinstatment Email and SMS Communications to be triggered.
DateTime :05June2020
Comments:1.Variables declared for Revival.
***********************************************************************************************************************************/

//*********************************************************************    
//*                      FUTURE GENERALI INDIA                        *   
//**********************************************************************/     
//*                  I N F O R M A T I O N                                      
//*********************************************************************
// Sr. No.              : 2 
// Company              : Life           
// Module               : UW Saral       
// Program Author       : Akshada N Wagh         
// BRD/CR/Codesk No/Win : /28153 / /           
// Date Of Creation     : 02-09-2020     
// Description          :1. Variables declared for Consent Letter
//                       2. Consent Letter Invoked if UW Decision is proposal.
//                       3. Email and SMS Communication triggered on Consent Raised.
//*********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Platform.Utilities.LoggerFramework;
using UWSaralObjects;
using System.Diagnostics;
using System.Net;
using System.Configuration;
using System.Text;
using System.IO;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Net.Http;


public partial class Appcode_Bpmuwmodule : System.Web.UI.MasterPage
{
    //This is set to UW default . letter this value come from query string.
    DataSet _ds = new DataSet();
    UWSaralDecision.BussLayer objUWDecision = new UWSaralDecision.BussLayer();
    Commfun objComm = new Commfun();
    BussLayer objBussiness = new BussLayer();
    CommonObject objCommonObj = new CommonObject();
    ChangeValue objChangeObj = new ChangeValue();
    string struserid = string.Empty;
    string strUWmode = string.Empty;
    string strUserGroup = string.Empty;
    string strApplicationno = string.Empty;
    string strOptinselected = string.Empty;
    string strAppstatusKey = string.Empty;
    string strChannelType = string.Empty;
    string strPolicyNo = string.Empty;
    DataSet _dsPrevPol = new DataSet();
    int response = 1;
    //########################## 1.1 Begin of Changes CR 26273;Akshada ###########################################
    string NEWFollowUp = string.Empty;
    WCFGenerateInputOutput.WCFGenerateInputOutputClient clientService = new WCFGenerateInputOutput.WCFGenerateInputOutputClient();
    WCFHitMQ.WCFHitMQClient mqHit = new WCFHitMQ.WCFHitMQClient();
    string returnmsg = string.Empty;
    string msg = string.Empty;
    string Flag = string.Empty;
    string Status = string.Empty;
    #region Email&SMS parameters
    string Flag1 = ConfigurationManager.AppSettings["Flag1"].ToString();
    string Flag2 = ConfigurationManager.AppSettings["Flag2"].ToString();
    string Flag3 = ConfigurationManager.AppSettings["Flag3"].ToString();
    string SMSCommunicationType = ConfigurationManager.AppSettings["SMSCommunication"].ToString();
    string SMSCommunicationKey = ConfigurationManager.AppSettings["SMSCommunicationKey"].ToString();
    string EmailCommunicationType = ConfigurationManager.AppSettings["EmailCommunication"].ToString();
    string EmailCommunicationKey = ConfigurationManager.AppSettings["EmailCommunication"].ToString();
    string DeclinedSMSProcess = ConfigurationManager.AppSettings["DeclinedSMS"].ToString();
    string DeclinedSMSTemplateId = ConfigurationManager.AppSettings["DeclinedSMSTemplate"].ToString();
    string DeclinedEmailProcess = ConfigurationManager.AppSettings["DeclinedEmailProcess"].ToString();
    string DeclinedEmailTemplateId = ConfigurationManager.AppSettings["DeclinedEmailTemplateID"].ToString();
    string ReqRaisedSMSProcess = ConfigurationManager.AppSettings["ReqRaisedSMSProcess"].ToString();
    string ReqRaisedTemplateID = ConfigurationManager.AppSettings["ReqRaisedTemplateID"].ToString();

    string ReqRaisedEmailTemplateID_NonMedical = ConfigurationManager.AppSettings["ReqRaisedEmailTemplateID_NonMedical"].ToString();
    string ReqRaisedEmailProcess = ConfigurationManager.AppSettings["ReqRaisedEmailProcess"].ToString();
    string ReqRaisedEmailTemplateID = ConfigurationManager.AppSettings["ReqRaisedEmailTemplateID"].ToString();

    string PostponedSMSProcess = ConfigurationManager.AppSettings["PostponedSMSProcess"].ToString();
    string PostponedSMSTemplateID = ConfigurationManager.AppSettings["PostponedSMSTemplateID"].ToString();
    string PostponedEmailProcess = ConfigurationManager.AppSettings["PostponedEmailProcess"].ToString();
    string PostponedEmailTemplateID = ConfigurationManager.AppSettings["PostponedEmailTemplateID"].ToString();
    string AcceptedSMSTemplateID = ConfigurationManager.AppSettings["AcceptedSMSTemplateID"].ToString();
    string AcceptedSMSProcess = ConfigurationManager.AppSettings["AcceptedSMSProcess"].ToString();

    string MailTo = string.Empty;
    string MailCC = string.Empty;
    string MobileNo = string.Empty;
    string Mode = ConfigurationManager.AppSettings["Mode"].ToString();
    string CreatedBy = ConfigurationManager.AppSettings["CreatedBy"].ToString();
    string IsAttached = "0";
    string AttachedFiles = null;
    string ApplicationNo = string.Empty;
    string PolicyNumber = string.Empty;
    string ParameterList = string.Empty;
    string FileName = string.Empty;
    string IsExternal = string.Empty;
    string CarrierCode = ConfigurationManager.AppSettings["CarrierCode"].ToString();
    #endregion Email&SMS parameters
    //########################## 1.1 End of Changes CR 26273;Akshada  ###########################################

    //########################## 2.1 Begin of Changes by Akshada; CR-28153 ###########################################
    DataSet dsreqdetails = new DataSet();
    #region Consent Declarations

    ConsentEntity.ConsentParams objconsentparams = new ConsentEntity.ConsentParams();
    ConsentEntity.EmailParams objemailparams = new ConsentEntity.EmailParams();
    UWSaralDecision.CommFun objcommfun = new UWSaralDecision.CommFun();
    UWSaralServices.PremiumCalculationDetails objPremcal = new UWSaralServices.PremiumCalculationDetails();
    bool ConsentRaised = false;
    DataTable dtinsertclientdetials = new DataTable();
    DataTable dtemail = new DataTable();
    DataSet _dsClientInfo = new DataSet();
    DataTable dtclientinfo = new DataTable();
    DataSet _dsProdDtls = new DataSet();
    DataTable dtproductdetails = new DataTable();
    DataTable dt = new DataTable();
    DataTable dtclientdetails;
    DataSet _dsriderdetails = new DataSet();
    DataSet _dsPremcal = new DataSet();
    string BIResponse = string.Empty;
    DataRow dsemailrows;
    DataTable dtrequirements = new DataTable();
    string RequestId_number = string.Empty;
    string strLApushStatus = string.Empty;
    string strConsentRespons = string.Empty;
    int RequestID = new int();
    int SMSRequestID = new int();
    string Consent_Raised = string.Empty;
    #endregion

    //########################## 2.1 End of Changes  by Akshada; CR-28153 ###########################################
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["qsUserGroup"] != null)
        {
            strUserGroup = UWSaralDecision.CommFun.Base64DecodingMethod(Request.QueryString["qsUserGroup"]);
        }
        if (Request.QueryString["qsAppNo"] != null)
        {
            //strApplicationno = UWSaralDecision.CommFun.Base64DecodingMethod(Request.QueryString["qsAppNo"]);
            strApplicationno = Request.QueryString["qsAppNo"];
        }
        if (Request.QueryString["qsChannelName"] != null)
        {
            strChannelType = UWSaralDecision.CommFun.Base64DecodingMethod(Request.QueryString["qsChannelName"]);
        }
        if (Request.QueryString["qsPolicyNo"] != null)
        {
            strPolicyNo = UWSaralDecision.CommFun.Base64DecodingMethod(Request.QueryString["qsPolicyNo"]);
        }
        //########################## 1.2 Begin of Changes CR 26273;Akshada  ###########################################
        try
        {
            Session["RequestType"] = "";
            Logger.Info(strApplicationno + Request.Url.Segments[2].ToString() + " " + "Check Page" + System.Environment.NewLine);

            if (Request.Url.Segments.Length > 2 && Request.Url.Segments[2].ToString() == "RevivalUwdecision.aspx")
            {
                Session["RequestType"] = "Revival";
                Logger.Info(strApplicationno + Request.Url.Segments[2].ToString() + System.Environment.NewLine);
            }

        }
        catch (Exception ex)
        {
            Logger.Info(strApplicationno + Request.Url.Segments[2].ToString() + ex.Message.ToString() + System.Environment.NewLine);

        }

        //########################## 1.2 End of Changes CR 26273;Akshada ###########################################
        if (!IsPostBack)
        {
            // objCommonObj = (CommonObject)Session["objCommonObj"];
            objChangeObj = (ChangeValue)Session["objLoginObj"];
            Logger.Info(strApplicationno + "STAG 2 :PageName :Bpmuwmodule.cs // MethodeName :Page_Load" + System.Environment.NewLine);
            lblCaptionAppNo.Text = "Application Number: " + strApplicationno;
            lblCaptionPolNo.Text = "Policy Number: " + strPolicyNo;
            //BindMenu(objChangeObj.userLoginDetails._UserGroup);

        }
    }


    public void BindMenu(string strGroupName)
    {
        //if (strGroupName == "UW")
        //{
        //    //btnsendToUW.Attributes.Add("class", "HideControl");
        //}
        //if (strGroupName == "DOCQC")
        //{
        //    btnReferToCmo.Attributes.Add("class", "HideControl");
        //}
    }

    public static object DateFormat(object objInput)
    {
        if (object.ReferenceEquals(objInput, DBNull.Value))
        {
            return null;
        }
        else
        {
            if (string.IsNullOrEmpty(Convert.ToString(objInput)))
            {
                return null;
            }
            else
            {
                //DateTime dt = DateTime.ParseExact(Convert.ToString(objInput), "mm-dd-yyyy", CultureInfo.InvariantCulture);
                System.DateTime dt = Convert.ToDateTime(objInput);
                objInput = dt.ToString("dd/MM/yyyy");
                return objInput;
            }
        }
    }
    public event EventHandler contentCallEvent;
    public event EventHandler masterCallEvent;
    protected void btnPost_Click(object sender, EventArgs e)
    {
        try
        {
            Logger.Info(strApplicationno + "master post Event Start" + System.Environment.NewLine);
            DataSet _dscombiflag = new DataSet();
            Repeater rptDecision = (Repeater)ContentPlaceHolder1.FindControl("rptDecision");
            bool IsCombi = false;
            IsCombi = (bool)Session["IsCombi"];
            if (IsCombi)
            {
                foreach (RepeaterItem item in rptDecision.Items)
                {
                    Label lblAppno = (Label)item.FindControl("lblAppno");
                    Session["AppNo_Combi"] = lblAppno.Text;
                    Label lblPolNum = (Label)item.FindControl("lblPolNum");
                    Session["PolNo_Combi"] = lblPolNum.Text;
                    strApplicationno = lblAppno.Text;
                    lblPreIssueVal.Text = string.Empty;
                    MasterPageComparision objNewMasterComparision1 = new MasterPageComparision();
                    MasterPageComparision objNewMasterComparision2 = new MasterPageComparision();
                    ContentClientDetails(objNewMasterComparision1);
                    ContentRiderDetails(objNewMasterComparision1);
                    //ContentProductDetails(objNewMasterComparision1);
                    ContentProductDetails_Combi(objNewMasterComparision1, lblPolNum.Text);

                    System.Web.Script.Serialization.JavaScriptSerializer objJavaScriptSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                    HiddenField hdnOldValue = (HiddenField)ContentPlaceHolder1.FindControl("hdnOldValue");
                    objNewMasterComparision2 = objJavaScriptSerializer.Deserialize<MasterPageComparision>(hdnOldValue.Value);
                    int intRef = -1;
                    string strUserId = string.Empty;
                    if (Session["objCommonObj"] != null)
                    {
                        objCommonObj = (CommonObject)Session["objCommonObj"];
                        strUserId = objCommonObj._Bpmuserdetails._UserID;
                        //objComm.ManageApplicationLifeCycle(strApplicationno, strUserId, "UW_DECISION_POST", false, ref intRef);
                    }
                    /*added by shri on 28 dec 17 to add tracking*/
                    int intTrackingRet = -1;
                    objCommonObj = (CommonObject)Session["objCommonObj"];
                    strUserId = objCommonObj._Bpmuserdetails._UserID;
                    InsertUwDecisionTracking(strApplicationno, strUserId, DateTime.Now, "POST", ref intTrackingRet);
                    /*end here*/
                    /*END HERE*/
                    if (masterCallEvent != null)
                    {
                        masterCallEvent(this, EventArgs.Empty);
                    }
                    int LAPushErrorCode = 0;
                    int UWDecisionResult = 0;
                    string strLAPushErrorMsg = string.Empty;
                    int Result = 0;
                    objCommonObj = (CommonObject)Session["objCommonObj"];
                    // objCommonObj = new CommonObject();
                    objChangeObj = (ChangeValue)Session["objLoginObj"];
                    struserid = objChangeObj.userLoginDetails._UserID;
                    // strUserGroup = objChangeObj.userLoginDetails._UserGroup;
                    //strApplicationno = objCommonObj._ApplicationNo;
                    strUWmode = strChannelType;
                    UWSaralDecision.BussLayer objBuss = new UWSaralDecision.BussLayer();
                    Logger.Info(strApplicationno + "STAG 2 :PageName :Bpmuwmodule.cs // MethodeName :btnPost_Click" + System.Environment.NewLine);
                    DropDownList ddlUWDecesion = (DropDownList)item.FindControl("ddlUWDecesion");
                    DropDownList ddlUWreason = (DropDownList)item.FindControl("ddlUWreason");
                    DropDownList ddlPostpone = (DropDownList)item.FindControl("ddlPeriod");
                    Label lblErrorDecisiondtls = (Label)item.FindControl("lblErrorDecisiondtls");

                    string _strUWDecesion = ddlUWDecesion.SelectedValue;
                    string _strUWPeriod = ddlPostpone.SelectedValue == "0" ? "" : ddlPostpone.SelectedValue;
                    string _strDataValue = string.Empty;
                    //string _strPolicyStatus = string.Empty;
                    int intRetVal = -1;

                    /*ADDED BY SHRI ON 07 NOV 17 TO CALL MANAGE APPLICATION LIFE CYCLE*/
                    UpdateDecisionInLa_Combi(ref response, ddlUWDecesion, ddlUWreason, ddlPostpone, lblErrorDecisiondtls);
                    //objComm.ManageApplicationLifeCycle(strApplicationno, strUserId, "UW_DECISION_POST", true, ref intRef);
                    /*END HERE*/
                    /*added by shri on 28 dec 17 to update tracking*/
                    UpdateUwDecisionTracking(intTrackingRet, DateTime.Now, ref intTrackingRet);
                    /*END HERE*/
                    Logger.Info(strApplicationno + "master post Event End" + System.Environment.NewLine);
                }
            }
            else
            {
                lblPreIssueVal.Text = string.Empty;
                MasterPageComparision objNewMasterComparision1 = new MasterPageComparision();
                MasterPageComparision objNewMasterComparision2 = new MasterPageComparision();
                ContentClientDetails(objNewMasterComparision1);
                ContentRiderDetails(objNewMasterComparision1);
                ContentProductDetails(objNewMasterComparision1);

                System.Web.Script.Serialization.JavaScriptSerializer objJavaScriptSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                HiddenField hdnOldValue = (HiddenField)ContentPlaceHolder1.FindControl("hdnOldValue");
                objNewMasterComparision2 = objJavaScriptSerializer.Deserialize<MasterPageComparision>(hdnOldValue.Value);
                int intRef = -1;
                string strUserId = string.Empty;
                if (Session["objCommonObj"] != null)
                {
                    objCommonObj = (CommonObject)Session["objCommonObj"];
                    strUserId = objCommonObj._Bpmuserdetails._UserID;
                    //objComm.ManageApplicationLifeCycle(strApplicationno, strUserId, "UW_DECISION_POST", false, ref intRef);
                }
                /*added by shri on 28 dec 17 to add tracking*/
                int intTrackingRet = -1;
                objCommonObj = (CommonObject)Session["objCommonObj"];
                strUserId = objCommonObj._Bpmuserdetails._UserID;
                InsertUwDecisionTracking(strApplicationno, strUserId, DateTime.Now, "POST", ref intTrackingRet);
                /*end here*/
                /*END HERE*/
                if (masterCallEvent != null)
                {
                    masterCallEvent(this, EventArgs.Empty);
                }
                int LAPushErrorCode = 0;
                int UWDecisionResult = 0;
                string strLAPushErrorMsg = string.Empty;
                int Result = 0;
                objCommonObj = (CommonObject)Session["objCommonObj"];
                // objCommonObj = new CommonObject();
                objChangeObj = (ChangeValue)Session["objLoginObj"];
                struserid = objChangeObj.userLoginDetails._UserID;
                // strUserGroup = objChangeObj.userLoginDetails._UserGroup;
                //strApplicationno = objCommonObj._ApplicationNo;
                strUWmode = strChannelType;
                UWSaralDecision.BussLayer objBuss = new UWSaralDecision.BussLayer();
                Logger.Info(strApplicationno + "STAG 2 :PageName :Bpmuwmodule.cs // MethodeName :btnPost_Click" + System.Environment.NewLine);
                DropDownList ddlUWDecesion = (DropDownList)ContentPlaceHolder1.FindControl("ddlUWDecesion");
                DropDownList ddlUWreason = (DropDownList)ContentPlaceHolder1.FindControl("ddlUWreason");
                DropDownList ddlPostpone = (DropDownList)ContentPlaceHolder1.FindControl("ddlPeriod");
                Label lblErrorDecisiondtls = (Label)ContentPlaceHolder1.FindControl("lblErrorDecisiondtls");

                string _strUWDecesion = ddlUWDecesion.SelectedValue;
                string _strUWPeriod = ddlPostpone.SelectedValue == "0" ? "" : ddlPostpone.SelectedValue;
                string _strDataValue = string.Empty;
                //string _strPolicyStatus = string.Empty;
                int intRetVal = -1;

                /*ADDED BY SHRI ON 07 NOV 17 TO CALL MANAGE APPLICATION LIFE CYCLE*/
                UpdateDecisionInLa(ref response);
                //objComm.ManageApplicationLifeCycle(strApplicationno, strUserId, "UW_DECISION_POST", true, ref intRef);
                /*END HERE*/
                /*added by shri on 28 dec 17 to update tracking*/
                UpdateUwDecisionTracking(intTrackingRet, DateTime.Now, ref intTrackingRet);
                /*END HERE*/
                Logger.Info(strApplicationno + "master post Event End" + System.Environment.NewLine);
            }
        }
        catch (Exception Error)
        {
            Logger.Info(strApplicationno + "Exception In Post" + Error.Message + System.Environment.NewLine);
            if (Error.Message.Contains("UDE-"))
            {
                ShowPopupMessage(Error.Message.Replace("UDE-", string.Empty), 0);
            }
            else
            {
                ShowPopupMessage("Details Not Post", 0);
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Logger.Info(strApplicationno + "PAGE_NAME:UWSaralDecision/btnSave_Click //EVENT_NAME:OnlineApplicationLAServiceDetails_PUSH//I-INFO:Funcation Execution Begin" + System.Environment.NewLine);
            /*ADDED BY SHRI ON 07 NOV 17 TO CALL MANAGE APPLICATION LIFE CYCLE*/
            int intRef = -1;
            string strUserId = string.Empty;
            if (Session["objCommonObj"] != null)
            {
                objCommonObj = (CommonObject)Session["objCommonObj"];
                strUserId = objCommonObj._Bpmuserdetails._UserID;
            }
            //objComm.ManageApplicationLifeCycle(strApplicationno, strUserId, "UW_DECISION_SAVE", false, ref intRef);
            /*END HERE*/
            Logger.Info("STAG 2 :PageName :Bpmuwmodule.cs // MethodeName :btnSave_Click" + System.Environment.NewLine);
            if (contentCallEvent != null)
                contentCallEvent(this, EventArgs.Empty);
            //objComm.ManageApplicationLifeCycle(strApplicationno, strUserId, "UW_DECISION_SAVE", true, ref intRef);
            Logger.Info(strApplicationno + "PAGE_NAME:UWSaralDecision/btnSave_Click //EVENT_NAME:OnlineApplicationLAServiceDetails_PUSH//I-INFO:Funcation Execution End" + System.Environment.NewLine);
        }
        catch (Exception Error)
        {
            Logger.Info(strApplicationno + "Exception In Save" + Error.Message + System.Environment.NewLine);
            ShowPopupMessage("Erroe While Saving Application Details,Please Contact System Admin", 0);
        }
    }

    public void UpdateUWControlTable(string strProcessStatus, ref int strResult)
    {
        //Change the status of DOCQC to Closed.
        objChangeObj = (ChangeValue)Session["objLoginObj"];
        // objCommonObj = (CommonObject)Session["objCommonObj"];
        Logger.Info(strApplicationno + "STAG 2 :PageName :Bpmuwmodule.cs // MethodeName :UpdateUWControlTable" + System.Environment.NewLine);
        int _SaveResult = 0;
        objComm.ChangeUWSaralStatus(strApplicationno, strPolicyNo, strProcessStatus, "CLOSE", true, true, DateTime.Now, DateTime.Now, objChangeObj.userLoginDetails._UserID, objChangeObj.userLoginDetails._UserName, objChangeObj.userLoginDetails._UserGroup, objCommonObj._bpm_branchCode, Convert.ToDateTime(objCommonObj._bpm_creationDate), Convert.ToDateTime(objCommonObj._bpm_systemDate), objCommonObj._bpm_systemDate, objChangeObj.userLoginDetails._userBranch, objChangeObj.userLoginDetails._ProcessName, objCommonObj._bpm_applicationName, ref _SaveResult);
    }

    public void InsertUWControlTable(string strProcessStatus, ref int strResult)
    {
        //Change the status of DOCQC to Closed.
        //objCommonObj = (CommonObject)Session["objCommonObj"];
        objChangeObj = (ChangeValue)Session["objLoginObj"];
        Logger.Info(strApplicationno + "STAG 2 :PageName :Bpmuwmodule.cs // MethodeName :InsertUWControlTable" + System.Environment.NewLine);
        int _SaveResult = 0;
        objComm.ChangeUWSaralStatus(strApplicationno, strPolicyNo, strProcessStatus, "WIP", true, false, DateTime.Now, DateTime.Now, objChangeObj.userLoginDetails._UserID, objChangeObj.userLoginDetails._UserName, objChangeObj.userLoginDetails._UserGroup, objCommonObj._bpm_branchCode, Convert.ToDateTime(objCommonObj._bpm_creationDate), Convert.ToDateTime(objCommonObj._bpm_systemDate), objCommonObj._bpm_systemDate, objChangeObj.userLoginDetails._userBranch, objChangeObj.userLoginDetails._ProcessName, objCommonObj._bpm_applicationName, ref _SaveResult);
    }

    protected void btnsendToUW_Click(object sender, EventArgs e)
    {
        int _SaveResult = 0;
        // objCommonObj = (CommonObject)Session["objCommonObj"];
        objChangeObj = (ChangeValue)Session["objLoginObj"];
        strUserGroup = objChangeObj.userLoginDetails._UserGroup;
        struserid = objChangeObj.userLoginDetails._UserID;
        strUWmode = strChannelType;
        //UpdateUWControlTable("DOCQC", ref _SaveResult);
        //InsertUWControlTable("UW", ref _SaveResult);
        //objComm.UpdateControlMechanism(objCommonObj._ApplicationNo, struserid, "1119763", "UWAssign", ref _SaveResult);
        strAppstatusKey = (strUserGroup == "UW") ? "UR" : "DR";
        objComm.OnlineApplicationchangeStatus(strApplicationno, struserid, strAppstatusKey, "", ref _SaveResult);
        Logger.Info("STAG 2 :PageName :Bpmuwmodule.cs // MethodeName :btnSave_Click" + System.Environment.NewLine);
        if (_SaveResult != -1)
        {
            Response.Redirect("~/9011042143.aspx");
        }
        else
        {
            Logger.Error("STAG 2 :PageName :Bpmuwmodule.cs // MethodeName :btnSave_Click : Error : UW Saral Status noot change" + System.Environment.NewLine);
        }
    }

    public delegate void DoEvent();
    protected void btnManual_Click(object sender, EventArgs e)
    {
        UpdateDecisionInLa(ref response);
    }

    private void UpdateDecisionInLa(ref int response)
    {
        //declare variable
        int LAPushErrorCode = 0;
        int UWDecisionResult = 0;
        string strLAPushErrorMsg = string.Empty;
        int Result = 0;
        Boolean isConsentReq = false;
        objCommonObj = (CommonObject)Session["objCommonObj"];
        objChangeObj = (ChangeValue)Session["objLoginObj"];
        struserid = objChangeObj.userLoginDetails._UserID;
        strUWmode = strChannelType;
        UWSaralDecision.BussLayer objBuss = new UWSaralDecision.BussLayer();
        Logger.Info(strApplicationno + "STAG 2 :PageName :Bpmuwmodule.cs // MethodeName :btnPost_Click" + System.Environment.NewLine);
        DropDownList ddlUWDecesion = (DropDownList)ContentPlaceHolder1.FindControl("ddlUWDecesion");
        DropDownList ddlUWreason = (DropDownList)ContentPlaceHolder1.FindControl("ddlUWreason");
        DropDownList ddlPostpone = (DropDownList)ContentPlaceHolder1.FindControl("ddlPeriod");
        Label lblErrorDecisiondtls = (Label)ContentPlaceHolder1.FindControl("lblErrorDecisiondtls");
        //########################## 1.3 Begin of Changes CR 26273;Akshada###########################################
        Logger.Info(strApplicationno + "UpdateDecisionInLa_Revival_01chnages starts" + System.Environment.NewLine);
        DropDownList ddlStatusREQ = (DropDownList)ContentPlaceHolder1.FindControl("ddlStatus");
        Logger.Info(strApplicationno + "UpdateDecisionInLa_Revival_01chnages ends" + System.Environment.NewLine);
        //########################## 1.3 End of Changes CR 26273;Akshada ###########################################

        if (objChangeObj.Load_Loadingdetails != null)
        {
            isConsentReq = objChangeObj.Load_Loadingdetails.isConsentRequired;
        }
        else
        {
            isConsentReq = false;
        }
        string _strUWDecesion = ddlUWDecesion.SelectedValue;
        string _strUWPeriod = ddlPostpone.SelectedValue == "0" ? "" : ddlPostpone.SelectedValue;
        string _strDataValue = string.Empty;
        int intRetVal = -1;
        //########################## 1.4 Begin of Changes CR 26273;Akshada ###########################################

        Logger.Info(strApplicationno + "UpdateDecisionInLa_Revival_02chnages starts" + System.Environment.NewLine);
        try
        {
            Session["RequestType"] = "";
            if (Request.Url.Segments.Length > 2 && Request.Url.Segments[2].ToString() == "RevivalUwdecision.aspx")
            {
                Session["RequestType"] = "Revival";
            }
            if (Session["RequestType"].ToString() == "Revival")
                Logger.Info(Session["RequestType"].ToString() + "Revival start" + System.Environment.NewLine);
            {
                objCommonObj._AppType = "Single";
            }
            Logger.Info(strApplicationno + "UpdateDecisionInLa_Revival_02chnages ends" + objCommonObj._AppType + System.Environment.NewLine);
        }
        catch (Exception ex)
        {

            Logger.Info(strApplicationno + ex.Message.ToString() + objCommonObj._AppType + System.Environment.NewLine);
        }


        //##########################1.4 End of Changes CR 26273;Akshada###########################################

        //call servics
        objComm.OnlineUWDecisionDetails_Save(objCommonObj._AppType, strApplicationno, ddlUWDecesion.SelectedItem.Text, ddlUWreason.SelectedItem.Text, ddlUWDecesion.SelectedValue, ddlUWreason.SelectedItem.Value, _strUWPeriod, struserid, objChangeObj.userLoginDetails._UserName, objChangeObj.userLoginDetails._UserGroup, objCommonObj._bpm_branchCode, objCommonObj._bpm_creationDate,
      objCommonObj._bpm_systemDate, objCommonObj._bpm_businessDate, objChangeObj.userLoginDetails._userBranch, objChangeObj.userLoginDetails._ProcessName, strApplicationno, ref UWDecisionResult);
        if (UWDecisionResult != -1)
        {
            string strConsentResponse = string.Empty;
            //lblErrorDecisiondtls.Text = "Decision details save successfully";
            //########################## 1.5 Begin of Changes CR 26273;Akshada ###################################################
            try
            {
                Session["RequestType"] = "";
                Logger.Info(Session["RequestType"].ToString() + "check revival" + System.Environment.NewLine);
                if (Request.Url.Segments.Length > 2 && Request.Url.Segments[2].ToString() == "RevivalUwdecision.aspx")
                {
                    Logger.Info(Session["RequestType"].ToString() + "check revival_1" + System.Environment.NewLine);
                    Session["RequestType"] = "Revival";
                    Logger.Info(Session["RequestType"].ToString() + "check revival_2" + System.Environment.NewLine);
                }

                if (Session["RequestType"].ToString() == "Revival")
                {
                    Logger.Info(Session["RequestType"].ToString() + "check revival_3" + System.Environment.NewLine);
                    Logger.Info(strApplicationno + "master post Event Start_Step21" + System.Environment.NewLine);
                    HiddenField HdnPremPayingStatus1 = (HiddenField)ContentPlaceHolder1.FindControl("hdnPremPayingStatus");
                    HiddenField HdnPolicyStatus1 = (HiddenField)ContentPlaceHolder1.FindControl("hdnPolicyStatus");
                    if (Session["hdnNewFollowup"] != null)
                    {
                        NEWFollowUp = Session["hdnNewFollowup"].ToString();
                        NEWFollowUp.ToString();

                    }

                    if (HdnPremPayingStatus1.Value.Trim() == "Lapsed" ||
                            HdnPremPayingStatus1.Value.Trim() == "HA" || HdnPremPayingStatus1.Value.Trim() == "AC"
                            || HdnPremPayingStatus1.Value.Trim() == "PH" || HdnPremPayingStatus1.Value.Trim() == "UD" || HdnPolicyStatus1.Value.Trim() == "LA" ||
                            HdnPolicyStatus1.Value.Trim() == "PU" || HdnPolicyStatus1.Value.Trim() == "DU" || HdnPolicyStatus1.Value.Trim() == "HP")
                    {
                        Logger.Info(strApplicationno + "master post Event Start_04042020_v1" + System.Environment.NewLine);
                        LAPushErrorCode = 0;
                    }
                    else
                    {
                        objBuss.OnlineApplicationLAServiceDetails_PUSH(strApplicationno, strUWmode, objChangeObj, ref _ds, ref _dsPrevPol, ddlUWDecesion.SelectedValue, ref LAPushErrorCode, ref strLAPushErrorMsg, ref strConsentResponse);
                    }
                }
                else
                {
                    objBuss.OnlineApplicationLAServiceDetails_PUSH(strApplicationno, strUWmode, objChangeObj, ref _ds, ref _dsPrevPol, ddlUWDecesion.SelectedValue, ref LAPushErrorCode, ref strLAPushErrorMsg, ref strConsentResponse);
                }
                Logger.Info(strApplicationno + "master post Event Start_Step22" + System.Environment.NewLine);
            }
            catch (Exception ex)
            {

                Logger.Info(strApplicationno + ex.Message.ToString() + System.Environment.NewLine);
            }

            //########################## 1.5 End of Changes CR 26273;Akshada ###########################################
            // objBuss.OnlineApplicationLAServiceDetails_PUSH(strApplicationno, strUWmode, objChangeObj, ref _ds, ref _dsPrevPol, ddlUWDecesion.SelectedValue, ref LAPushErrorCode, ref strLAPushErrorMsg, ref strConsentResponse);
            if (!string.IsNullOrEmpty(strConsentResponse) && !strConsentResponse.Equals("Failed"))
            {
                Logger.Info("Consent Letter for application No : {0} : {1}" + strApplicationno + strConsentResponse);
                //string filePath = Request.QueryString["FILEPATH"].ToString();
                //Response.ContentType = "application/pdf";
                //Response.WriteFile(strConsentResponse);
                Response.Write("<script>");
                Response.Write(String.Format("window.open('{0}','_blank')", ResolveUrl(strConsentResponse)));
                Response.Write("</script>");
                //WebClient myWebClient = new WebClient();
                // myWebClient.DownloadFile(strConsentResponse, "D:\abc.pdf");
                //Response.Redirect(strConsentResponse);
            }
            if (LAPushErrorCode == 0)
            {
                //########################## 1.6 Begin of Changes CR 26273;Akshada ###########################################

                Session["RequestType"] = "";
                if (Request.Url.Segments.Length > 2 && Request.Url.Segments[2].ToString() == "RevivalUwdecision.aspx")
                {
                    Logger.Info(strApplicationno + "master post Event Start_postponerevival" + System.Environment.NewLine);

                    Session["RequestType"] = "Revival";
                }
                if (Session["RequestType"].ToString() == "Revival")
                {
                    try
                    {
                        HiddenField HdnPolicyStatus = (HiddenField)ContentPlaceHolder1.FindControl("hdnPolicyStatus");
                        HiddenField HdnPremPayingStatus = (HiddenField)ContentPlaceHolder1.FindControl("hdnPremPayingStatus");
                        HiddenField HdnPolicyNumber = (HiddenField)ContentPlaceHolder1.FindControl("hdnPolNo");
                        TextBox txtProposerName = (TextBox)ContentPlaceHolder1.FindControl("LAName");

                        TextBox txtPremAmt = (TextBox)ContentPlaceHolder1.FindControl("txtTotalPrmPay");
                        TextBox txtPlanName = (TextBox)ContentPlaceHolder1.FindControl("txtProname1");
                        HiddenField hdnMobile = (HiddenField)ContentPlaceHolder1.FindControl("hdnModilenumber");
                        HiddenField hdnEmail = (HiddenField)ContentPlaceHolder1.FindControl("hdnEmail");
                        HiddenField HdnAppNumber = (HiddenField)ContentPlaceHolder1.FindControl("HdnApplicationNumber");
                        DropDownList ddlStatusREQ1 = (DropDownList)ContentPlaceHolder1.FindControl("ddlStatus");

                        HiddenField hdnbankname = (HiddenField)ContentPlaceHolder1.FindControl("hdfnBankName");
                        HiddenField hdnbankaccount = (HiddenField)ContentPlaceHolder1.FindControl("hdfnBankAcctNumber");


                        HiddenField hdnLAFullName = (HiddenField)ContentPlaceHolder1.FindControl("hdnLAFullname");

                        if (HdnPremPayingStatus.Value.Trim() == "Lapsed" ||
                            HdnPremPayingStatus.Value.Trim() == "HA" || HdnPremPayingStatus.Value.Trim() == "AC"
                            || HdnPremPayingStatus.Value.Trim() == "PH" || HdnPremPayingStatus.Value.Trim() == "UD" || HdnPolicyStatus.Value.Trim() == "LA" ||
                            HdnPolicyStatus.Value.Trim() == "PU" || HdnPolicyStatus.Value.Trim() == "DU" || HdnPolicyStatus.Value.Trim() == "HP")
                        {


                            if (ddlUWDecesion.SelectedValue == "Declined")
                            {
                                string ReqStatus = string.Empty;
                                GridView GvReq = (GridView)ContentPlaceHolder1.FindControl("gvRequirmentDetails");
                                int counter = 0;
                                foreach (GridViewRow rowfollowup in GvReq.Rows)
                                {
                                    DropDownList ddlStatus = rowfollowup.FindControl("ddlStatus") as DropDownList;
                                    if (ddlStatus.SelectedValue == "O")
                                    {
                                        counter = counter + 1;
                                    }
                                }


                                if (counter > 0 && NEWFollowUp == "TRUE")
                                {
                                    DataTable dtSMS = new DataTable();
                                    string ApplicationNo = HdnAppNumber.Value.Trim();
                                    string PolicyNumber = HdnPolicyNumber.Value.Trim();
                                    MobileNo = hdnMobile.Value.Trim();


                                    dtSMS = objBussiness.EmailParameter(Flag2, SMSCommunicationType, SMSCommunicationKey, DeclinedSMSProcess, DeclinedSMSTemplateId, hdnEmail.Value.Trim(), MailCC, MobileNo, Mode, CreatedBy, IsAttached, AttachedFiles, ApplicationNo, PolicyNumber, ParameterList, FileName, IsExternal);
                                    DataRow drSMS = dtSMS.Rows[0];

                                    string RequestId = drSMS["RequestId"].ToString();

                                    dtSMS = objBussiness.EmailParameter(Flag1, SMSCommunicationType, SMSCommunicationKey, DeclinedSMSProcess, DeclinedSMSTemplateId, hdnEmail.Value.Trim(), MailCC, MobileNo, Mode, CreatedBy, IsAttached, AttachedFiles, ApplicationNo, PolicyNumber, ParameterList, FileName, IsExternal);

                                    for (int i = 0; i < dtSMS.Rows.Count; i++)
                                    {
                                        string parameter = dtSMS.Rows[i][1].ToString();

                                        string col = dtSMS.Rows[i][1].ToString();
                                        switch (parameter)
                                        {

                                            case "<proposer name>":


                                                ParameterList = "'" + RequestId + "'" + "," + "'" + dtSMS.Rows[i][1].ToString() + "'" + "," + "'" + hdnLAFullName.Value.Trim() + "'),";

                                                break;

                                            case "<Plan Name>":
                                                ParameterList += "('" + RequestId + "'" + "," + "'" + dtSMS.Rows[i][1].ToString() + "'" + "," + "'" + txtPlanName.Text.Trim() + "'),";
                                                break;

                                            case "<Policy No.>":
                                                ParameterList += "('" + RequestId + "'" + "," + "'" + dtSMS.Rows[i][1].ToString() + "'" + "," + "'" + HdnPolicyNumber.Value.Trim() + "'";
                                                break;



                                            default:
                                                break;
                                        }
                                    }

                                    dtSMS = objBussiness.EmailParameter(Flag3, SMSCommunicationType, SMSCommunicationKey, DeclinedSMSProcess, DeclinedSMSTemplateId, hdnEmail.Value.Trim(), MailCC, MobileNo, Mode, CreatedBy, IsAttached, AttachedFiles, ApplicationNo, PolicyNumber, ParameterList, FileName, IsExternal);

                                    Session["hdnNewFollowup"] = null;

                                    //RejectedForImage//
                                    try
                                    {
                                        Logger.Info(strApplicationno + "RejectedForImage_email_start" + System.Environment.NewLine);
                                        DataTable dtemail = new DataTable();

                                        string CustomerName = hdnLAFullName.Value;

                                        string PolicyName = txtPlanName.Text.Trim();

                                        string Reason1 = ddlUWDecesion.SelectedValue.ToString();
                                        string Reason2 = ddlUWreason.SelectedValue.ToString();
                                        string BankName = string.Empty;
                                        string BankAccountNumber = string.Empty;
                                        IsAttached = "0";
                                        AttachedFiles = null;
                                        ApplicationNo = HdnAppNumber.Value.Trim();
                                        PolicyNumber = HdnPolicyNumber.Value.Trim();
                                        FileName = "Rejected_For_Image.html";
                                        IsExternal = "YES";


                                        dtemail = objBussiness.EmailParameter(Flag2, EmailCommunicationType, EmailCommunicationKey, DeclinedEmailProcess, DeclinedEmailTemplateId, hdnEmail.Value.Trim(), MailCC, hdnMobile.Value.Trim(), Mode, CreatedBy, IsAttached, AttachedFiles, ApplicationNo, PolicyNumber, ParameterList, FileName, IsExternal);
                                        DataRow dsemailrows = dtSMS.Rows[0];

                                        string RequestId_no = dsemailrows["RequestId"].ToString();

                                        dtemail = objBussiness.EmailParameter(Flag1, EmailCommunicationType, EmailCommunicationKey, DeclinedEmailProcess, DeclinedEmailTemplateId, hdnEmail.Value.Trim(), MailCC, hdnMobile.Value.Trim(), Mode, CreatedBy, IsAttached, AttachedFiles, ApplicationNo, PolicyNumber, ParameterList, FileName, IsExternal);

                                        for (int i = 0; i < dtemail.Rows.Count; i++)
                                        {
                                            string parameter = dtemail.Rows[i][1].ToString();

                                            string col = dtemail.Rows[i][1].ToString();
                                            switch (parameter)
                                            {

                                                case "<Customer_Name>":
                                                    ParameterList = "'" + RequestId_no + "'" + "," + "'" + dtemail.Rows[i][1].ToString() + "'" + "," + "'" + CustomerName + "'),";
                                                    break;

                                                case "<Policy_Name>":
                                                    ParameterList += "('" + RequestId_no + "'" + "," + "'" + dtemail.Rows[i][1].ToString() + "'" + "," + "'" + PolicyName + "'),";
                                                    break;

                                                case "<Policy_Number>":
                                                    ParameterList += "('" + RequestId_no + "'" + "," + "'" + dtemail.Rows[i][1].ToString() + "'" + "," + "'" + PolicyNumber + "'),";
                                                    break;

                                                case "<Reason1>":
                                                    ParameterList += "('" + RequestId_no + "'" + "," + "'" + dtemail.Rows[i][1].ToString() + "'" + "," + "'" + Reason1 + "'),";
                                                    break;

                                                case "<Reason2>":
                                                    ParameterList += "('" + RequestId_no + "'" + "," + "'" + dtemail.Rows[i][1].ToString() + "'" + "," + "'" + Reason2 + "'),";
                                                    break;

                                                case "<Bank_Name>":
                                                    ParameterList += "('" + RequestId_no + "'" + "," + "'" + dtemail.Rows[i][1].ToString() + "'" + "," + "'" + BankName + "'),";
                                                    break;

                                                case "<Bank_Account_Number>":
                                                    ParameterList += "('" + RequestId_no + "'" + "," + "'" + dtemail.Rows[i][1].ToString() + "'" + "," + "'" + BankAccountNumber + "'";
                                                    break;

                                                default:
                                                    break;
                                            }
                                        }

                                        dtemail = objBussiness.EmailParameter(Flag3, EmailCommunicationType, EmailCommunicationKey, DeclinedEmailProcess, DeclinedEmailTemplateId, hdnEmail.Value.Trim(), MailCC, hdnMobile.Value.Trim(), Mode, CreatedBy, IsAttached, AttachedFiles, ApplicationNo, PolicyNumber, ParameterList, FileName, IsExternal);
                                        Logger.Info(strApplicationno + "RejectedForImage_email_success" + System.Environment.NewLine);
                                    }
                                    catch (Exception ex)
                                    {
                                        Logger.Info(strApplicationno + "RejectedForImage_email_fail" + System.Environment.NewLine);

                                    }

                                }
                            }

                            else if (ddlUWDecesion.SelectedValue == "Postponed")
                            {
                                Logger.Info(strApplicationno + "master post Event Start_Step22_postponedstarts" + System.Environment.NewLine);
                                HiddenField HdnMonthCounts = (HiddenField)ContentPlaceHolder1.FindControl("HdnFinalMonthCount");

                                if (Convert.ToInt64(HdnMonthCounts.Value) > 0)
                                {
                                    Logger.Info("poststart" + "master post Event Start_postponedstarts_s" + System.Environment.NewLine);
                                    int Months = Convert.ToInt32(HdnMonthCounts.Value) - 1;
                                    int postponeMonths = Convert.ToInt32(ddlPostpone.SelectedValue);
                                    int ActuallMonths = Convert.ToInt32(HdnMonthCounts.Value);
                                    StringBuilder sb1 = new StringBuilder();
                                    sb1.Append(Months + "," + postponeMonths + "," + ActuallMonths);
                                    string inputmsg = sb1.ToString();
                                    Logger.Info(inputmsg + "master post Event Start_postponedstarts_1" + System.Environment.NewLine);

                                    if (postponeMonths > Months)
                                    {
                                        ShowPopupMessage("The revival can be allowed for this case up to " + ActuallMonths + " period only.Hence you can postpone this policy up to " + Months + " months maximum.Please change postpone period or revise the UW decision accordingly", 0);
                                        return;
                                    }



                                }
                                else
                                {
                                    ShowPopupMessage("You cannot Postpone this case upto provided " + ddlPostpone.SelectedValue + ",since revival after " + ddlPostpone.SelectedValue + " not allowed. Please review UW decision accordingly", 0);
                                    return;
                                }

                                Logger.Info(strApplicationno + "master post Event Start_Step23" + System.Environment.NewLine);

                                string ReqStatus = string.Empty;
                                GridView GvReq = (GridView)ContentPlaceHolder1.FindControl("gvRequirmentDetails");

                                int counter = 0;

                                foreach (GridViewRow rowfollowup in GvReq.Rows)
                                {

                                    DropDownList ddlStatus = rowfollowup.FindControl("ddlStatus") as DropDownList;

                                    if (ddlStatus.SelectedValue == "O")
                                    {
                                        counter = counter + 1;
                                    }
                                }
                                Logger.Info(strApplicationno + "master post Event Start_Step24" + System.Environment.NewLine);

                                if (counter > 0 && NEWFollowUp == "TRUE")
                                {
                                    Logger.Info(strApplicationno + "master post Event Start_Step25" + System.Environment.NewLine);
                                    DataTable dtSMS = new DataTable();




                                    dtSMS = objBussiness.EmailParameter(Flag2, SMSCommunicationType, SMSCommunicationKey, PostponedSMSProcess, PostponedSMSTemplateID, hdnEmail.Value.Trim(), MailCC, hdnMobile.Value.Trim(), Mode, CreatedBy, IsAttached, AttachedFiles, HdnAppNumber.Value.Trim(), HdnPolicyNumber.Value.Trim(), ParameterList, FileName, IsExternal);
                                    DataRow drSMS = dtSMS.Rows[0];
                                    Logger.Info(strApplicationno + "master post Event Start_Step26" + System.Environment.NewLine);
                                    string RequestId = drSMS["RequestId"].ToString();

                                    dtSMS = objBussiness.EmailParameter(Flag1, SMSCommunicationType, SMSCommunicationKey, PostponedSMSProcess, PostponedSMSTemplateID, hdnEmail.Value.Trim(), MailCC, hdnMobile.Value.Trim(), Mode, CreatedBy, IsAttached, AttachedFiles, HdnAppNumber.Value.Trim(), HdnPolicyNumber.Value.Trim(), ParameterList, FileName, IsExternal);
                                    Logger.Info(strApplicationno + "master post Event Start_Step27" + System.Environment.NewLine);
                                    for (int i = 0; i < dtSMS.Rows.Count; i++)
                                    {
                                        string parameter = dtSMS.Rows[i][1].ToString();

                                        string col = dtSMS.Rows[i][1].ToString();
                                        switch (parameter)
                                        {

                                            case "<proposer name>":



                                                ParameterList = "'" + RequestId + "'" + "," + "'" + dtSMS.Rows[i][1].ToString() + "'" + "," + "'" + hdnLAFullName.Value.Trim() + "'),";

                                                break;

                                            case "<Plan Name>":
                                                ParameterList += "('" + RequestId + "'" + "," + "'" + dtSMS.Rows[i][1].ToString() + "'" + "," + "'" + txtPlanName.Text.Trim() + "'),";
                                                break;

                                            case "<Policy No.>":
                                                ParameterList += "('" + RequestId + "'" + "," + "'" + dtSMS.Rows[i][1].ToString() + "'" + "," + "'" + HdnPolicyNumber.Value.Trim() + "'";
                                                break;



                                            default:
                                                break;
                                        }
                                    }
                                    Logger.Info(strApplicationno + "master post Event Start_Step28" + System.Environment.NewLine);

                                    dtSMS = objBussiness.EmailParameter(Flag3, SMSCommunicationType, SMSCommunicationKey, PostponedSMSProcess, PostponedSMSTemplateID, hdnEmail.Value.Trim(), MailCC, hdnMobile.Value.Trim(), Mode, CreatedBy, IsAttached, AttachedFiles, HdnAppNumber.Value.Trim(), HdnPolicyNumber.Value.Trim(), ParameterList, FileName, IsExternal);
                                    Session["hdnNewFollowup"] = null;
                                    Logger.Info(strApplicationno + "master post Event Start_Step29" + System.Environment.NewLine);
                                }
                            }

                            if (ddlUWDecesion.SelectedValue == "Approved" && LAPushErrorCode == 0)
                            {
                                //objComm.OnlineUWMISDecision_Save(strApplicationno, ddlUWDecesion.SelectedValue, objCommonObj._bpm_branchCode, objChangeObj.userLoginDetails._ProcessName, objChangeObj.userLoginDetails._userBranch,
                                //    objCommonObj._AppType, struserid, objChangeObj.userLoginDetails._UserGroup, "", "", ref UWDecisionResult);



                                //DataSet dsREQ = new DataSet();
                                //objBussiness.CheckOpenRequirement(HdnAppNumber.Value.Trim(), "1",ref dsREQ);
                                //if(dsREQ.Tables[0].Rows.Count == 0 )
                                //{


                                //}
                                //else
                                //{

                                //	ShowPopupMessage("Please close all Requirements", 0);
                                //}

                                //Commented Start by kunal 26-03-2020  Reason - Details to be updated only if status changes in LA
                                //string ReqStatus = string.Empty;
                                //GridView GvReq = (GridView)ContentPlaceHolder1.FindControl("gvRequirmentDetails");


                                //foreach (GridViewRow rowfollowup in GvReq.Rows)
                                //{
                                //	DropDownList ddlStatus = rowfollowup.FindControl("ddlStatus") as DropDownList;

                                //	if (ddlStatus.SelectedValue == "O")
                                //	{
                                //		ShowPopupMessage("Please close all Requirements", 0);
                                //		return;
                                //	}
                                //	else
                                //	{
                                //		//objBuss.OnlineApplicationLAServiceDetails_PUSH(strApplicationno, strUWmode, objChangeObj, ref _ds, ref _dsPrevPol, ddlUWDecesion.SelectedValue, ref LAPushErrorCode, ref strLAPushErrorMsg, ref strConsentResponse);

                                //		//Akshay
                                //		UWSaralServices.FollowupDetails objFollowup = new UWSaralServices.FollowupDetails();
                                //		//CommFun objComm = new CommFun();
                                //		DataSet _dsFollowUp = null;

                                //		objComm.OnlineServiceFollowUPDetails_GET(ref _dsFollowUp, HdnAppNumber.Value.Trim(), "Offline");

                                //		objFollowup.FollowuPushService(HdnAppNumber.Value.Trim(), _dsFollowUp, objChangeObj, ref LAPushErrorCode, ref strLAPushErrorMsg);
                                //	}
                                //}

                                //strAppstatusKey = (strUserGroup == "UW") ? "UC" : "DC";
                                //objComm.OnlineApplicationchangeStatus(strApplicationno, struserid, strAppstatusKey, "", ref Result);
                                ////_strPolicyStatus = "IF";
                                //objBussiness.UpdatePolicyStatus(strApplicationno, "UW", struserid, ref intRetVal);

                                ////To Insert Record in LF_applicationstatus table with '091' status 
                                //objBussiness.InsertAppStatus(strApplicationno, struserid, ref intRetVal);
                                //Commented End by kunal 26-03-2020  Reason - Details to be updated only if status changes in LA

                                //UWSARAL STATUS UPDATE.
                                string STPResult = string.Empty;
                                ReinstSTP.Service1Client objREINSTSTP = new ReinstSTP.Service1Client();

                                string UserID = objCommonObj._Bpmuserdetails._UserID;// struserid.ToString().StartsWith("F") ? struserid.ToString() : "F" + struserid.ToString();
                                STPResult = objREINSTSTP.IsSTPRulesPassORFail(HdnPolicyNumber.Value.Trim(), objCommonObj._Bpmuserdetails._userBranch, objCommonObj._Bpmuserdetails._userBranch, Mode, objCommonObj._Bpmuserdetails._UserRole, CarrierCode, UserID);
                                //objCommonObj._bpm_branchCode

                                if (STPResult == "0")
                                {
                                    //Commented code pasted Start by kunal 26-03-2020  Reason - Details to be updated only if status changes in LA
                                    string ReqStatus = string.Empty;
                                    GridView GvReq = (GridView)ContentPlaceHolder1.FindControl("gvRequirmentDetails");
                                    foreach (GridViewRow rowfollowup in GvReq.Rows)
                                    {
                                        DropDownList ddlStatus = rowfollowup.FindControl("ddlStatus") as DropDownList;

                                        if (ddlStatus.SelectedValue == "O")
                                        {
                                            ShowPopupMessage("Please close all Requirements", 0);
                                            return;
                                        }
                                        else
                                        {

                                            UWSaralServices.FollowupDetails objFollowup = new UWSaralServices.FollowupDetails();

                                            DataSet _dsFollowUp = null;

                                            objComm.OnlineServiceFollowUPDetails_GET(ref _dsFollowUp, HdnAppNumber.Value.Trim(), "Offline");

                                            objFollowup.FollowuPushService(HdnAppNumber.Value.Trim(), _dsFollowUp, objChangeObj, ref LAPushErrorCode, ref strLAPushErrorMsg);
                                        }
                                    }
                                    strAppstatusKey = (strUserGroup == "UW") ? "UC" : "DC";
                                    objComm.OnlineApplicationchangeStatus(strApplicationno, struserid, strAppstatusKey, "", ref Result);

                                    objBussiness.UpdatePolicyStatus(strApplicationno, "UW", struserid, ref intRetVal);


                                    objBussiness.InsertAppStatus(strApplicationno, struserid, ref intRetVal);




                                    Flag = "1";
                                    Status = "UW Approved";
                                    objBussiness.UWSaralUpdate(HdnPolicyNumber.Value.Trim(), struserid, Flag, Status);

                                    objBussiness.UpdateReciptAmt(HdnAppNumber.Value.Trim(), "1");

                                    ShowPopupMessage("Details Post Successfully", 0);
                                    STPResult = "";

                                    //UW ACCEPTS
                                    DataTable dtSMS = new DataTable();





                                    dtSMS = objBussiness.EmailParameter(Flag2, SMSCommunicationType, SMSCommunicationKey, AcceptedSMSProcess, AcceptedSMSTemplateID, hdnEmail.Value.Trim(), MailCC, hdnMobile.Value.Trim(), Mode, CreatedBy, IsAttached, AttachedFiles, HdnAppNumber.Value.Trim(), HdnPolicyNumber.Value.Trim(), ParameterList, FileName, IsExternal);
                                    DataRow drSMS = dtSMS.Rows[0];

                                    string RequestId = drSMS["RequestId"].ToString();

                                    dtSMS = objBussiness.EmailParameter(Flag1, SMSCommunicationType, SMSCommunicationKey, AcceptedSMSProcess, AcceptedSMSTemplateID, hdnEmail.Value.Trim(), MailCC, hdnMobile.Value.Trim(), Mode, CreatedBy, IsAttached, AttachedFiles, HdnAppNumber.Value.Trim(), HdnPolicyNumber.Value.Trim(), ParameterList, FileName, IsExternal);

                                    for (int i = 0; i < dtSMS.Rows.Count; i++)
                                    {
                                        string col = dtSMS.Rows[i][1].ToString();
                                        switch (col)
                                        {

                                            case "<plan name>":
                                                ParameterList = "'" + RequestId + "'" + "," + "'" + dtSMS.Rows[i][1].ToString() + "'" + "," + "'" + txtPlanName.Text.Trim() + "'),";
                                                break;

                                            case "<policy no.>":
                                                ParameterList += "('" + RequestId + "'" + "," + "'" + dtSMS.Rows[i][1].ToString() + "'" + "," + "'" + HdnPolicyNumber.Value.Trim() + "'),";
                                                break;


                                            case "<Proposer Name>":

                                                ParameterList += "('" + RequestId + "'" + "," + "'" + dtSMS.Rows[i][1].ToString() + "'" + "," + "'" + hdnLAFullName.Value.Trim() + "'";

                                                break;

                                            default:
                                                break;
                                        }
                                    }

                                    dtSMS = objBussiness.EmailParameter(Flag3, SMSCommunicationType, SMSCommunicationKey, AcceptedSMSProcess, AcceptedSMSTemplateID, hdnEmail.Value.Trim(), MailCC, hdnMobile.Value.Trim(), Mode, CreatedBy, IsAttached, AttachedFiles, HdnAppNumber.Value.Trim(), HdnPolicyNumber.Value.Trim(), ParameterList, FileName, IsExternal);

                                }
                                else
                                {

                                    ShowPopupMessage("Policy can't reinstate.", 0);
                                    STPResult = "";
                                }






                            }
                            else if (ddlUWDecesion.SelectedValue == "Declined" && LAPushErrorCode == 0)
                            {



                                strAppstatusKey = (strUserGroup == "UW") ? "UC" : "DC";
                                objComm.OnlineApplicationchangeStatus(strApplicationno, struserid, strAppstatusKey, "", ref Result);


                                objBussiness.UpdatePolicyStatus(strApplicationno, "DC", struserid, ref intRetVal);


                                Flag = "1";
                                Status = "UW Rejected";
                                objBussiness.UWSaralUpdate(HdnPolicyNumber.Value.Trim(), struserid, Flag, Status);



                                objBussiness.UpdateReciptAmt(HdnAppNumber.Value.Trim(), "1");



                                ShowPopupMessage("Details Post Successfully", 0);





                                try
                                {
                                    Logger.Info(strApplicationno + "RejectedForImage_sms_start" + System.Environment.NewLine);
                                    DataTable dtSMS = new DataTable();
                                    IsAttached = "0";
                                    AttachedFiles = null;
                                    ApplicationNo = HdnAppNumber.Value.Trim();
                                    PolicyNumber = HdnPolicyNumber.Value.Trim();
                                    Logger.Info(strApplicationno + "RejectedForImage_sms_flag_02" + System.Environment.NewLine);
                                    dtSMS = objBussiness.EmailParameter(Flag2, SMSCommunicationType, SMSCommunicationKey, DeclinedSMSProcess, DeclinedSMSTemplateId, hdnEmail.Value.Trim(), MailCC, hdnMobile.Value.Trim(), Mode, CreatedBy, IsAttached, AttachedFiles, ApplicationNo, PolicyNumber, ParameterList, FileName, IsExternal);
                                    DataRow drSMS = dtSMS.Rows[0];

                                    string RequestId = drSMS["RequestId"].ToString();

                                    dtSMS = objBussiness.EmailParameter(Flag1, SMSCommunicationType, SMSCommunicationKey, DeclinedSMSProcess, DeclinedSMSTemplateId, hdnEmail.Value.Trim(), MailCC, hdnMobile.Value.Trim(), Mode, CreatedBy, IsAttached, AttachedFiles, ApplicationNo, PolicyNumber, ParameterList, FileName, IsExternal);
                                    Logger.Info(strApplicationno + "RejectedForImage_sms_flag_01" + System.Environment.NewLine);

                                    for (int i = 0; i < dtSMS.Rows.Count; i++)
                                    {
                                        string parameter = dtSMS.Rows[i][1].ToString();

                                        string col = dtSMS.Rows[i][1].ToString();
                                        switch (parameter)
                                        {

                                            case "<plan name>":
                                                ParameterList = "'" + RequestId + "'" + "," + "'" + dtSMS.Rows[i][1].ToString() + "'" + "," + "'" + txtPlanName.Text.Trim() + "'),";
                                                break;

                                            case "<policy no.>":
                                                ParameterList += "('" + RequestId + "'" + "," + "'" + dtSMS.Rows[i][1].ToString() + "'" + "," + "'" + HdnPolicyNumber.Value.Trim() + "'),";
                                                break;


                                            case "<Proposer Name>":


                                                ParameterList += "('" + RequestId + "'" + "," + "'" + dtSMS.Rows[i][1].ToString() + "'" + "," + "'" + hdnLAFullName.Value.Trim() + "'";

                                                break;



                                            default:
                                                break;
                                        }
                                    }

                                    Logger.Info(strApplicationno + "RejectedForImage_sms_flag3" + System.Environment.NewLine);
                                    dtSMS = objBussiness.EmailParameter(Flag3, SMSCommunicationType, SMSCommunicationKey, DeclinedSMSProcess, DeclinedSMSTemplateId, hdnEmail.Value.Trim(), MailCC, hdnMobile.Value.Trim(), Mode, CreatedBy, IsAttached, AttachedFiles, ApplicationNo, PolicyNumber, ParameterList, FileName, IsExternal);
                                    Logger.Info(strApplicationno + "RejectedForImage_sms_success" + System.Environment.NewLine);

                                }
                                catch (Exception)
                                {

                                    Logger.Info(strApplicationno + "RejectedForImage_sms_success" + System.Environment.NewLine);
                                }


                                try
                                {
                                    Logger.Info(strApplicationno + "RejectedForImage_email_start" + System.Environment.NewLine);
                                    DataTable dtemail = new DataTable();
                                    DataTable dtSMS = new DataTable();
                                    string CustomerName = hdnLAFullName.Value;

                                    string PolicyName = txtPlanName.Text.Trim();

                                    string Reason1 = ddlUWDecesion.SelectedValue.ToString();
                                    string Reason2 = ddlUWreason.SelectedValue.ToString();
                                    string BankName = string.Empty;
                                    string BankAccountNumber = string.Empty;
                                    IsAttached = "0";
                                    AttachedFiles = null;
                                    ApplicationNo = HdnAppNumber.Value.Trim();
                                    PolicyNumber = HdnPolicyNumber.Value.Trim();
                                    FileName = "Rejected_For_Image.html";
                                    IsExternal = "YES";


                                    dtemail = objBussiness.EmailParameter(Flag2, EmailCommunicationType, EmailCommunicationKey, DeclinedEmailProcess, DeclinedEmailTemplateId, hdnEmail.Value.Trim(), MailCC, hdnMobile.Value.Trim(), Mode, CreatedBy, IsAttached, AttachedFiles, ApplicationNo, PolicyNumber, ParameterList, FileName, IsExternal);
                                    DataRow dsemailrows = dtSMS.Rows[0];

                                    string RequestId_no = dsemailrows["RequestId"].ToString();

                                    dtemail = objBussiness.EmailParameter(Flag1, EmailCommunicationType, EmailCommunicationKey, DeclinedEmailProcess, DeclinedEmailTemplateId, hdnEmail.Value.Trim(), MailCC, hdnMobile.Value.Trim(), Mode, CreatedBy, IsAttached, AttachedFiles, ApplicationNo, PolicyNumber, ParameterList, FileName, IsExternal);

                                    for (int i = 0; i < dtemail.Rows.Count; i++)
                                    {
                                        string parameter = dtemail.Rows[i][1].ToString();

                                        string col = dtemail.Rows[i][1].ToString();
                                        switch (parameter)
                                        {

                                            case "<Customer_Name>":
                                                ParameterList = "'" + RequestId_no + "'" + "," + "'" + dtemail.Rows[i][1].ToString() + "'" + "," + "'" + CustomerName + "'),";
                                                break;

                                            case "<Policy_Name>":
                                                ParameterList += "('" + RequestId_no + "'" + "," + "'" + dtemail.Rows[i][1].ToString() + "'" + "," + "'" + PolicyName + "'),";
                                                break;

                                            case "<Policy_Number>":
                                                ParameterList += "('" + RequestId_no + "'" + "," + "'" + dtemail.Rows[i][1].ToString() + "'" + "," + "'" + PolicyNumber + "'),";
                                                break;

                                            case "<Reason1>":
                                                ParameterList += "('" + RequestId_no + "'" + "," + "'" + dtemail.Rows[i][1].ToString() + "'" + "," + "'" + Reason1 + "'),";
                                                break;

                                            case "<Reason2>":
                                                ParameterList += "('" + RequestId_no + "'" + "," + "'" + dtemail.Rows[i][1].ToString() + "'" + "," + "'" + Reason2 + "'),";
                                                break;

                                            case "<Bank_Name>":
                                                ParameterList += "('" + RequestId_no + "'" + "," + "'" + dtemail.Rows[i][1].ToString() + "'" + "," + "'" + BankName + "'),";
                                                break;

                                            case "<Bank_Account_Number>":
                                                ParameterList += "('" + RequestId_no + "'" + "," + "'" + dtemail.Rows[i][1].ToString() + "'" + "," + "'" + BankAccountNumber + "'";
                                                break;

                                            default:
                                                break;
                                        }
                                    }

                                    dtemail = objBussiness.EmailParameter(Flag3, EmailCommunicationType, EmailCommunicationKey, DeclinedEmailProcess, DeclinedEmailTemplateId, hdnEmail.Value.Trim(), MailCC, hdnMobile.Value.Trim(), Mode, CreatedBy, IsAttached, AttachedFiles, ApplicationNo, PolicyNumber, ParameterList, FileName, IsExternal);
                                    Logger.Info(strApplicationno + "RejectedForImage_email_success" + System.Environment.NewLine);
                                }
                                catch (Exception ex)
                                {
                                    Logger.Info(strApplicationno + "RejectedForImage_email_fail" + System.Environment.NewLine);
                                    throw ex;
                                }


                            }
                            else if (ddlUWDecesion.SelectedValue == "Postponed" && LAPushErrorCode == 0)
                            {
                                Logger.Info(strApplicationno + "master post Event Start_Step30" + System.Environment.NewLine);
                                strAppstatusKey = (strUserGroup == "UW") ? "UC" : "DC";
                                objComm.OnlineApplicationchangeStatus(strApplicationno, struserid, strAppstatusKey, "", ref Result);
                                Logger.Info(strApplicationno + "master post Event Start_Step31" + System.Environment.NewLine);
                                //_strPolicyStatus = "PO";
                                objBussiness.UpdatePolicyStatus(strApplicationno, "PO", struserid, ref intRetVal);
                                Logger.Info(strApplicationno + "master post Event Start_Step32" + System.Environment.NewLine);

                                //UWSARAL STATUS UPDATE.
                                Flag = "1";
                                Status = "UW Hold";
                                objBussiness.UWSaralUpdate(HdnPolicyNumber.Value.Trim(), struserid, Flag, Status);
                                Logger.Info(strApplicationno + "master post Event Start_Step33" + System.Environment.NewLine);

                                //Update RefundAmount in Pos 
                                objBussiness.UpdateReciptAmt(HdnAppNumber.Value.Trim(), "1");
                                Logger.Info(strApplicationno + "master post Event Start_Step34" + System.Environment.NewLine);


                                ShowPopupMessage("Details Post Successfully", 0);
                                Logger.Info(strApplicationno + "master post Event Start_Step35" + System.Environment.NewLine);

                                string RevivalCompletiondate;
                                HiddenField HdnRCD_date = (HiddenField)ContentPlaceHolder1.FindControl("hdnRCDdate");
                                DataTable dt_Revival = objBussiness.revivaldate(HdnPolicyNumber.Value);
                                RevivalCompletiondate = dt_Revival.Rows[0]["REVIVAL_END_DT"].ToString();
                                DateTime date = Convert.ToDateTime(RevivalCompletiondate);
                                try
                                {
                                    Logger.Info(strApplicationno + "Postponed_sms_start" + System.Environment.NewLine);
                                    DataTable dtSMS = new DataTable();




                                    dtSMS = objBussiness.EmailParameter(Flag2, SMSCommunicationType, SMSCommunicationKey, PostponedSMSProcess, PostponedSMSTemplateID, hdnEmail.Value.Trim(), MailCC, hdnMobile.Value.Trim(), Mode, CreatedBy, IsAttached, AttachedFiles, HdnAppNumber.Value.Trim(), HdnPolicyNumber.Value.Trim(), ParameterList, FileName, IsExternal);
                                    DataRow drSMS = dtSMS.Rows[0];
                                    Logger.Info(strApplicationno + "master post Event Start_Step36" + System.Environment.NewLine);
                                    string RequestId = drSMS["RequestId"].ToString();

                                    dtSMS = objBussiness.EmailParameter(Flag1, SMSCommunicationType, SMSCommunicationKey, PostponedSMSProcess, PostponedSMSTemplateID, hdnEmail.Value.Trim(), MailCC, hdnMobile.Value.Trim(), Mode, CreatedBy, IsAttached, AttachedFiles, HdnAppNumber.Value.Trim(), HdnPolicyNumber.Value.Trim(), ParameterList, FileName, IsExternal);
                                    Logger.Info(strApplicationno + "master post Event Start_Step37" + System.Environment.NewLine);
                                    for (int i = 0; i < dtSMS.Rows.Count; i++)
                                    {
                                        string col = dtSMS.Rows[i][1].ToString();
                                        switch (col)
                                        {

                                            case "<plan name>":
                                                ParameterList = "'" + RequestId + "'" + "," + "'" + dtSMS.Rows[i][1].ToString() + "'" + "," + "'" + txtPlanName.Text.Trim() + "'),";
                                                break;

                                            case "<policy no.>":
                                                ParameterList += "('" + RequestId + "'" + "," + "'" + dtSMS.Rows[i][1].ToString() + "'" + "," + "'" + HdnPolicyNumber.Value.Trim() + "'),";
                                                break;


                                            case "<Postpone>":
                                                ParameterList += "('" + RequestId + "'" + "," + "'" + dtSMS.Rows[i][1].ToString() + "'" + "," + "'" + ddlPostpone.SelectedValue + "'),";
                                                break;


                                            case "<Proposer Name>":


                                                ParameterList += "('" + RequestId + "'" + "," + "'" + dtSMS.Rows[i][1].ToString() + "'" + "," + "'" + hdnLAFullName.Value.Trim() + "'),";

                                                break;

                                            case "<date of completion of revival period>":
                                                ParameterList += "('" + RequestId + "'" + "," + "'" + dtSMS.Rows[i][1].ToString() + "'" + "," + "'" + RevivalCompletiondate.ToString().Trim() + "'";
                                                break;


                                            default:
                                                break;
                                        }
                                    }
                                    Logger.Info(strApplicationno + "master post Event Start_Step38" + System.Environment.NewLine);

                                    dtSMS = objBussiness.EmailParameter(Flag3, SMSCommunicationType, SMSCommunicationKey, PostponedSMSProcess, PostponedSMSTemplateID, hdnEmail.Value.Trim(), MailCC, hdnMobile.Value.Trim(), Mode, CreatedBy, IsAttached, AttachedFiles, HdnAppNumber.Value.Trim(), HdnPolicyNumber.Value.Trim(), ParameterList, FileName, IsExternal);
                                    Logger.Info(strApplicationno + "Postponed_sms_success" + System.Environment.NewLine);

                                }
                                catch (Exception ex)
                                {

                                    Logger.Info(strApplicationno + "Postponed_sms_Fail" + ex.Message.ToString() + System.Environment.NewLine);

                                }



                                try
                                {
                                    Logger.Info(strApplicationno + "master post Event Start_Step39" + System.Environment.NewLine);
                                    string RevivalDate = string.Empty;
                                    Logger.Info(strApplicationno + "Postponed_email_start" + System.Environment.NewLine);
                                    DataTable dtemail_PostPone = new DataTable();
                                    HiddenField HdnRCDdate = (HiddenField)ContentPlaceHolder1.FindControl("hdnRCDdate");

                                    DataTable dtdate = objBussiness.revivaldate(HdnPolicyNumber.Value);
                                    RevivalDate = dtdate.Rows[0]["REVIVAL_END_DT"].ToString();
                                    Logger.Info(strApplicationno + "master post Event Start_Step40" + System.Environment.NewLine);

                                    string CustomerName = hdnLAFullName.Value;

                                    string Reason1 = ddlUWDecesion.SelectedValue;
                                    string Reason2 = ddlUWreason.SelectedItem.Text.ToString();
                                    string BankName = hdnbankname.Value;
                                    string BankAccountNumber = hdnbankaccount.Value;
                                    string PostPonedMonth = ddlPostpone.SelectedValue.ToString(); //string.Empty;
                                    string PlanName = txtPlanName.Text.Trim();
                                    string Policy_Number = HdnPolicyNumber.Value;
                                    Logger.Info(strApplicationno + "master post Event Start_Step41" + System.Environment.NewLine);


                                    var last4 = "****" + BankAccountNumber.Substring(BankAccountNumber.Trim().Length - 4, 4) + "";
                                    Logger.Info(strApplicationno + "Postponed_email_data_assigned" + System.Environment.NewLine);





                                    ParameterList = "";
                                    FileName = "PostPoned_Template.html";
                                    IsExternal = "Yes";

                                    Logger.Info(strApplicationno + "master post Event Start_Step41" + System.Environment.NewLine);
                                    dtemail_PostPone = objBussiness.EmailParameter(Flag2, EmailCommunicationType, EmailCommunicationKey, PostponedEmailProcess, PostponedEmailTemplateID, hdnEmail.Value.Trim(), MailCC, hdnMobile.Value.Trim(), Mode, CreatedBy, IsAttached, AttachedFiles, HdnAppNumber.Value.Trim(), HdnPolicyNumber.Value.Trim(), ParameterList, FileName, IsExternal);
                                    DataRow dsemail_Postpone_Rows = dtemail_PostPone.Rows[0];
                                    Logger.Info(strApplicationno + "master post Event Start_Step42" + System.Environment.NewLine);
                                    string RequestId_no = dsemail_Postpone_Rows["RequestId"].ToString();

                                    dtemail_PostPone = objBussiness.EmailParameter(Flag1, EmailCommunicationType, EmailCommunicationKey, PostponedEmailProcess, PostponedEmailTemplateID, hdnEmail.Value.Trim(), MailCC, hdnMobile.Value.Trim(), Mode, CreatedBy, IsAttached, AttachedFiles, HdnAppNumber.Value.Trim(), HdnPolicyNumber.Value.Trim(), ParameterList, FileName, IsExternal);
                                    Logger.Info(strApplicationno + "master post Event Start_Step43" + System.Environment.NewLine);
                                    for (int i = 0; i < dtemail_PostPone.Rows.Count; i++)
                                    {
                                        string parameter = dtemail_PostPone.Rows[i][1].ToString();

                                        string col = dtemail_PostPone.Rows[i][1].ToString();
                                        switch (parameter)
                                        {
                                            case "<Plan_name>":
                                                ParameterList = "'" + RequestId_no + "'" + "," + "'" + dtemail_PostPone.Rows[i][1].ToString() + "'" + "," + "'" + PlanName + "'),";
                                                break;

                                            case "<Policy_Number>":
                                                ParameterList += "('" + RequestId_no + "'" + "," + "'" + dtemail_PostPone.Rows[i][1].ToString() + "'" + "," + "'" + Policy_Number + "'),";
                                                break;

                                            case "<Customer_Name>":
                                                ParameterList += "('" + RequestId_no + "'" + "," + "'" + dtemail_PostPone.Rows[i][1].ToString() + "'" + "," + "'" + CustomerName + "'),";
                                                break;

                                            case "<Reason_1>":
                                                ParameterList += "('" + RequestId_no + "'" + "," + "'" + dtemail_PostPone.Rows[i][1].ToString() + "'" + "," + "'" + Reason1 + "'),";
                                                break;

                                            case "<Reason_2>":
                                                ParameterList += "('" + RequestId_no + "'" + "," + "'" + dtemail_PostPone.Rows[i][1].ToString() + "'" + "," + "'" + Reason2 + "'),";
                                                break;

                                            case "<Bank_Name>":
                                                ParameterList += "('" + RequestId_no + "'" + "," + "'" + dtemail_PostPone.Rows[i][1].ToString() + "'" + "," + "'" + BankName + "'),";
                                                break;

                                            case "<Bank_Account_Number>":
                                                ParameterList += "('" + RequestId_no + "'" + "," + "'" + dtemail_PostPone.Rows[i][1].ToString() + "'" + "," + "'" + last4 + "'),";
                                                break;

                                            case "<Postponed_Month>":
                                                ParameterList += "('" + RequestId_no + "'" + "," + "'" + dtemail_PostPone.Rows[i][1].ToString() + "'" + "," + "'" + PostPonedMonth + "'),";
                                                break;

                                            case "<Revival_Date>":
                                                ParameterList += "('" + RequestId_no + "'" + "," + "'" + dtemail_PostPone.Rows[i][1].ToString() + "'" + "," + "'" + RevivalDate + "'";
                                                break;



                                            default:
                                                break;

                                        }
                                    }
                                    Logger.Info(strApplicationno + "master post Event Start_Step44" + System.Environment.NewLine);

                                    dtemail_PostPone = objBussiness.EmailParameter(Flag3, EmailCommunicationType, EmailCommunicationKey, PostponedEmailProcess, PostponedEmailTemplateID, hdnEmail.Value.Trim(), MailCC, hdnMobile.Value.Trim(), Mode, CreatedBy, IsAttached, AttachedFiles, HdnAppNumber.Value.Trim(), HdnPolicyNumber.Value.Trim(), ParameterList, FileName, IsExternal);
                                    Logger.Info(strApplicationno + "Remark:" + "Email_PostPone_Template_success" + "UW PostPone Mail-Success" + System.Environment.NewLine);
                                }
                                catch (Exception ex)
                                {

                                    Logger.Info(strApplicationno + "Remark:" + "Email_PostPone_Template_fail" + ex.Message.ToString() + "UW PostPone Mail-Failure" + System.Environment.NewLine);
                                }
                            }

                            else if (ddlUWDecesion.SelectedValue == "Withdrawn" && LAPushErrorCode == 0)
                            {
                                strAppstatusKey = (strUserGroup == "UW") ? "UC" : "DC";
                                objComm.OnlineApplicationchangeStatus(strApplicationno, struserid, strAppstatusKey, "", ref Result);
                                //_strPolicyStatus = "WD";
                                objBussiness.UpdatePolicyStatus(strApplicationno, "WD", struserid, ref intRetVal);


                                //UWSARAL STATUS UPDATE.
                                Flag = "1";
                                Status = "UW Withdrawn";
                                objBussiness.UWSaralUpdate(HdnPolicyNumber.Value.Trim(), struserid, Flag, Status);



                                //Update RefundAmount in Pos 
                                objBussiness.UpdateReciptAmt(HdnAppNumber.Value.Trim(), "1");


                                ShowPopupMessage("Details Post Successfully", 0);

                                DataTable dtSMS = new DataTable();
                                string ApplicationNo = HdnAppNumber.Value.Trim();
                                string PolicyNumber = HdnPolicyNumber.Value.Trim();
                                MobileNo = hdnMobile.Value.Trim();


                                dtSMS = objBussiness.EmailParameter(Flag2, SMSCommunicationType, SMSCommunicationKey, DeclinedSMSProcess, DeclinedSMSTemplateId, hdnEmail.Value.Trim(), MailCC, MobileNo, Mode, CreatedBy, IsAttached, AttachedFiles, ApplicationNo, PolicyNumber, ParameterList, FileName, IsExternal);
                                DataRow drSMS = dtSMS.Rows[0];

                                string RequestId = drSMS["RequestId"].ToString();

                                dtSMS = objBussiness.EmailParameter(Flag1, SMSCommunicationType, SMSCommunicationKey, DeclinedSMSProcess, DeclinedSMSTemplateId, hdnEmail.Value.Trim(), MailCC, MobileNo, Mode, CreatedBy, IsAttached, AttachedFiles, ApplicationNo, PolicyNumber, ParameterList, FileName, IsExternal);

                                for (int i = 0; i < dtSMS.Rows.Count; i++)
                                {
                                    string parameter = dtSMS.Rows[i][1].ToString();

                                    string col = dtSMS.Rows[i][1].ToString();
                                    switch (parameter)
                                    {

                                        case "<proposer name>":


                                            ParameterList = "'" + RequestId + "'" + "," + "'" + dtSMS.Rows[i][1].ToString() + "'" + "," + "'" + hdnLAFullName.Value.Trim() + "'),";

                                            break;

                                        case "<Plan Name>":
                                            ParameterList += "('" + RequestId + "'" + "," + "'" + dtSMS.Rows[i][1].ToString() + "'" + "," + "'" + txtPlanName.Text.Trim() + "'),";
                                            break;

                                        case "<Policy No.>":
                                            ParameterList += "('" + RequestId + "'" + "," + "'" + dtSMS.Rows[i][1].ToString() + "'" + "," + "'" + HdnPolicyNumber.Value.Trim() + "'";
                                            break;



                                        default:
                                            break;
                                    }
                                }

                                dtSMS = objBussiness.EmailParameter(Flag3, SMSCommunicationType, SMSCommunicationKey, DeclinedSMSProcess, DeclinedSMSTemplateId, hdnEmail.Value.Trim(), MailCC, MobileNo, Mode, CreatedBy, IsAttached, AttachedFiles, ApplicationNo, PolicyNumber, ParameterList, FileName, IsExternal);

                            }
                            else if (ddlUWDecesion.SelectedValue == "Pending" && LAPushErrorCode == 0)
                            {
                                strAppstatusKey = (strUserGroup == "UW") ? "UC" : "DC";
                                objComm.OnlineApplicationchangeStatus(strApplicationno, struserid, strAppstatusKey, "", ref Result);

                                objBussiness.UpdatePolicyStatus(strApplicationno, "PS", struserid, ref intRetVal);

                                objBuss.OnlineApplicationLAServiceDetails_PUSH(strApplicationno, strUWmode, objChangeObj, ref _ds, ref _dsPrevPol, ddlUWDecesion.SelectedValue, ref LAPushErrorCode, ref strLAPushErrorMsg, ref strConsentResponse);

                                Flag = "1";
                                Status = "UW Pending";
                                objBussiness.UWSaralUpdate(HdnPolicyNumber.Value.Trim(), struserid, Flag, Status);



                                objBussiness.UpdateReciptAmt(HdnAppNumber.Value.Trim(), "1");

                                ShowPopupMessage("Details Post Successfully", 0);

                                DataTable dtSMS = new DataTable();








                                dtSMS = objBussiness.EmailParameter(Flag2, SMSCommunicationType, SMSCommunicationKey, ReqRaisedSMSProcess, ReqRaisedTemplateID, hdnEmail.Value.Trim(), MailCC, hdnMobile.Value.Trim(), Mode, CreatedBy, IsAttached, AttachedFiles, HdnAppNumber.Value.Trim(), HdnPolicyNumber.Value.Trim(), ParameterList, FileName, IsExternal);
                                DataRow drSMS = dtSMS.Rows[0];

                                string RequestId = drSMS["RequestId"].ToString();

                                dtSMS = objBussiness.EmailParameter(Flag1, SMSCommunicationType, SMSCommunicationKey, ReqRaisedSMSProcess, ReqRaisedTemplateID, hdnEmail.Value.Trim(), MailCC, hdnMobile.Value.Trim(), Mode, CreatedBy, IsAttached, AttachedFiles, HdnAppNumber.Value.Trim(), HdnPolicyNumber.Value.Trim(), ParameterList, FileName, IsExternal);

                                for (int i = 0; i < dtSMS.Rows.Count; i++)
                                {
                                    string col = dtSMS.Rows[i][1].ToString();
                                    switch (col)
                                    {

                                        case "<Plan Name>":
                                            ParameterList += "('" + RequestId + "'" + "," + "'" + dtSMS.Rows[i][1].ToString() + "'" + "," + "'" + txtPlanName.Text.Trim() + "'),";
                                            break;

                                        case "<Policy No.>":
                                            ParameterList += "('" + RequestId + "'" + "," + "'" + dtSMS.Rows[i][1].ToString() + "'" + "," + "'" + HdnPolicyNumber.Value.Trim() + "'";
                                            break;


                                        case "<proposer name>":

                                            ParameterList += "'" + RequestId + "'" + "," + "'" + dtSMS.Rows[i][1].ToString() + "'" + "," + "'" + hdnLAFullName.Value.Trim() + "'),";

                                            break;




                                        default:
                                            break;
                                    }
                                }

                                dtSMS = objBussiness.EmailParameter(Flag3, SMSCommunicationType, SMSCommunicationKey, ReqRaisedSMSProcess, ReqRaisedTemplateID, hdnEmail.Value.Trim(), MailCC, hdnMobile.Value.Trim(), Mode, CreatedBy, IsAttached, AttachedFiles, HdnAppNumber.Value.Trim(), HdnPolicyNumber.Value.Trim(), ParameterList, FileName, IsExternal);


                                string CustomerName = hdnLAFullName.Value;

                                string PolicyName = txtPlanName.Text.Trim();

                                //Pending Required 
                                DataTable dtemail = new DataTable();
                                string ReqStatus = string.Empty;
                                GridView GvReq = (GridView)ContentPlaceHolder1.FindControl("gvRequirmentDetails");

                                int counter = 0;
                                string strdesc = string.Empty;

                                bool isMedical = false;
                                StringBuilder strMedical = new StringBuilder();

                                List<string> obj = new List<string>();

                                List<string> obj1 = new List<string>();

                                int counter1 = 0;
                                string MedicalRequiremt = string.Empty;
                                StringBuilder medrequirementraised = new StringBuilder();
                                int medicalcounter = 1;

                                foreach (GridViewRow rowfollowup in GvReq.Rows)
                                {

                                    DropDownList ddlStatus = rowfollowup.FindControl("ddlStatus") as DropDownList;
                                    TextBox ddlDesc = rowfollowup.FindControl("lblfollowupDiscp") as TextBox;
                                    DropDownList ddlCat = rowfollowup.FindControl("ddlCategory") as DropDownList;

                                    if (ddlStatus.SelectedValue == "L")
                                    {

                                        if (ddlCat.SelectedValue == "Non Medical")
                                        {
                                            obj1.Add(ddlDesc.Text.ToString());


                                        }
                                        else
                                        {

                                            isMedical = true;
                                            MedicalRequiremt = ddlDesc.Text.ToString();

                                            medrequirementraised.Append("<br/>" + medicalcounter + ". " + MedicalRequiremt);
                                            medicalcounter++;
                                        }


                                    }


                                }

                                int Count = obj.Count;
                                int MedicalCount = 0;

                                for (int i = 0; i < obj.Count; i++)
                                {
                                    strdesc += string.Join("<br/>", obj[i]);

                                }

                                for (int i = 0; i < obj1.Count; i++)
                                {
                                    MedicalCount++;
                                    strMedical.Append("<br/>" + MedicalCount + ". " + obj1[i]);

                                    ViewState["Records"] = strMedical.ToString();

                                }


                                if (MedicalRequiremt == "")
                                {
                                    MedicalRequiremt = "N/A";
                                }

                                DataTable dtemail_ = new DataTable();

                                string TemplateId = string.Empty;



                                ApplicationNo = HdnAppNumber.Value.Trim();
                                PolicyNumber = HdnPolicyNumber.Value.Trim();
                                ParameterList = "";
                                FileName = "Requirement_Raised_template.html";
                                IsExternal = "YES";

                                if (isMedical == false)
                                {


                                    TemplateId = ReqRaisedEmailTemplateID_NonMedical;
                                    FileName = "RequirementRaised_NonMedical.html";


                                    dtemail = objBussiness.EmailParameter(Flag1, EmailCommunicationType, EmailCommunicationKey, ReqRaisedEmailProcess, TemplateId, hdnEmail.Value.Trim(), MailCC, MobileNo, Mode, CreatedBy, IsAttached, AttachedFiles, ApplicationNo, PolicyNumber, ParameterList, FileName, IsExternal);
                                    DataRow dsemailrows = dtemail.Rows[0];

                                    string RequestId_no = dsemailrows["RequestId"].ToString();
                                    Flag1 = "01";
                                    dtemail = objBussiness.EmailParameter(Flag1, EmailCommunicationType, EmailCommunicationKey, ReqRaisedEmailProcess, TemplateId, hdnEmail.Value.Trim(), MailCC, hdnMobile.Value.Trim(), Mode, CreatedBy, IsAttached, AttachedFiles, ApplicationNo, PolicyNumber, ParameterList, FileName, IsExternal);

                                    for (int i = 0; i < dtemail.Rows.Count; i++)
                                    {

                                        string col = dtemail.Rows[i][1].ToString();
                                        switch (col)
                                        {
                                            case "<Customer_Name>":
                                                ParameterList = "'" + RequestId_no + "'" + "," + "'" + dtemail.Rows[i][1].ToString() + "'" + "," + "'" + CustomerName + "'),";
                                                break;

                                            case "<Policy_Name>":
                                                ParameterList += "('" + RequestId_no + "'" + "," + "'" + dtemail.Rows[i][1].ToString() + "'" + "," + "'" + PolicyName + "'),";
                                                break;

                                            case "<Policy_Number>":
                                                ParameterList += "('" + RequestId_no + "'" + "," + "'" + dtemail.Rows[i][1].ToString() + "'" + "," + "'" + PolicyNumber + "'),";
                                                break;

                                            case "<REQTable>":


                                                ParameterList += "('" + RequestId_no + "'" + "," + "'" + dtemail.Rows[i][1].ToString() + "'" + "," + "'" + strMedical.ToString() + "'";
                                                break;


                                            default:
                                                break;
                                        }
                                    }
                                }
                                else
                                {

                                    TemplateId = ReqRaisedEmailTemplateID;
                                    FileName = "Requirement_Raised_template.html";

                                    dtemail = objBussiness.EmailParameter(Flag1, EmailCommunicationType, EmailCommunicationKey, ReqRaisedEmailProcess, TemplateId, hdnEmail.Value.Trim(), MailCC, hdnMobile.Value.Trim(), Mode, CreatedBy, IsAttached, AttachedFiles, ApplicationNo, PolicyNumber, ParameterList, FileName, IsExternal);
                                    DataRow dsemailrows = dtemail.Rows[0];

                                    string RequestId_no = dsemailrows["RequestId"].ToString();
                                    Flag1 = "01";
                                    dtemail = objBussiness.EmailParameter(Flag1, EmailCommunicationType, EmailCommunicationKey, ReqRaisedEmailProcess, TemplateId, hdnEmail.Value.Trim(), MailCC, hdnMobile.Value.Trim(), Mode, CreatedBy, IsAttached, AttachedFiles, ApplicationNo, PolicyNumber, ParameterList, FileName, IsExternal);

                                    for (int i = 0; i < dtemail.Rows.Count; i++)
                                    {

                                        string col = dtemail.Rows[i][1].ToString();
                                        switch (col)
                                        {
                                            case "<Customer_Name>":
                                                ParameterList = "'" + RequestId_no + "'" + "," + "'" + dtemail.Rows[i][1].ToString() + "'" + "," + "'" + CustomerName + "'),";
                                                break;

                                            case "<Policy_Name>":
                                                ParameterList += "('" + RequestId_no + "'" + "," + "'" + dtemail.Rows[i][1].ToString() + "'" + "," + "'" + PolicyName + "'),";
                                                break;

                                            case "<Policy_Number>":
                                                ParameterList += "('" + RequestId_no + "'" + "," + "'" + dtemail.Rows[i][1].ToString() + "'" + "," + "'" + PolicyNumber + "'),";
                                                break;

                                            case "<REQTable>":


                                                ParameterList += "('" + RequestId_no + "'" + "," + "'" + dtemail.Rows[i][1].ToString() + "'" + "," + "'" + strMedical.ToString() + "'),";
                                                break;

                                            case "<REQMedical>":

                                                ParameterList += "('" + RequestId_no + "'" + "," + "'" + dtemail.Rows[i][1].ToString() + "'" + "," + "'" + medrequirementraised.ToString() + "'";

                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                }


                                dtemail = objBussiness.EmailParameter(Flag3, EmailCommunicationType, EmailCommunicationKey, ReqRaisedEmailProcess, TemplateId, hdnEmail.Value.Trim(), MailCC, hdnMobile.Value.Trim(), Mode, CreatedBy, IsAttached, AttachedFiles, ApplicationNo, PolicyNumber, ParameterList, FileName, IsExternal);

                            }
                            //############################################# 1.6 End of Changes CR 26273;Akshada ######################################################################################    
                        }
                        else
                        {
                            if (ddlUWDecesion.SelectedValue == "Approved" && LAPushErrorCode == 0)
                            {


                                strAppstatusKey = (strUserGroup == "UW") ? "UC" : "DC";
                                objComm.OnlineApplicationchangeStatus(strApplicationno, struserid, strAppstatusKey, "", ref Result);

                                objBussiness.UpdatePolicyStatus(strApplicationno, "UW", struserid, ref intRetVal);


                                objBussiness.InsertAppStatus(strApplicationno, struserid, ref intRetVal);




                            }
                            else if (ddlUWDecesion.SelectedValue == "Declined" && LAPushErrorCode == 0)
                            {

                                //objComm.OnlineUWMISDecision_Save(strApplicationno, ddlUWDecesion.SelectedValue, objCommonObj._bpm_branchCode, objChangeObj.userLoginDetails._ProcessName, objChangeObj.userLoginDetails._userBranch,
                                //    objCommonObj._AppType, struserid, objChangeObj.userLoginDetails._UserGroup, ddlUWreason.SelectedValue, ddlUWreason.SelectedItem.Text, ref UWDecisionResult);
                                strAppstatusKey = (strUserGroup == "UW") ? "UC" : "DC";
                                objComm.OnlineApplicationchangeStatus(strApplicationno, struserid, strAppstatusKey, "", ref Result);

                                //_strPolicyStatus = "DC";
                                objBussiness.UpdatePolicyStatus(strApplicationno, "DC", struserid, ref intRetVal);

                            }
                            else if (ddlUWDecesion.SelectedValue == "Postponed" && LAPushErrorCode == 0)
                            {
                                strAppstatusKey = (strUserGroup == "UW") ? "UC" : "DC";
                                objComm.OnlineApplicationchangeStatus(strApplicationno, struserid, strAppstatusKey, "", ref Result);
                                //_strPolicyStatus = "PO";
                                objBussiness.UpdatePolicyStatus(strApplicationno, "PO", struserid, ref intRetVal);
                            }
                            else if (ddlUWDecesion.SelectedValue == "Withdrawn" && LAPushErrorCode == 0)
                            {
                                strAppstatusKey = (strUserGroup == "UW") ? "UC" : "DC";
                                objComm.OnlineApplicationchangeStatus(strApplicationno, struserid, strAppstatusKey, "", ref Result);
                                //_strPolicyStatus = "WD";
                                objBussiness.UpdatePolicyStatus(strApplicationno, "WD", struserid, ref intRetVal);
                            }
                            else if (ddlUWDecesion.SelectedValue == "proposal" && LAPushErrorCode == 0)
                            {
                                strAppstatusKey = (strUserGroup == "UW") ? "UC" : "DC";
                                //objComm.OnlineApplicationchangeStatus(strApplicationno, struserid, strAppstatusKey, "", ref Result);
                                //_strPolicyStatus = "WD";
                                /************************2.2 Begin of Changes by Akshada; CR-28153****************************************/
                                /***Comments: Used to Check Consent FollowUpCode Raised or not ****/
                                if (isConsentReq)
                                {
                                    try
                                    {
                                        objComm.OnlineRequirmentDisplayDetails_GET(ref dsreqdetails, strApplicationno, strChannelType);
                                        if (dsreqdetails.Tables[0].Rows.Count > 0)
                                        {

                                            int ConsentReqtRaisedCount = dsreqdetails.Tables[0].AsEnumerable()
                                                         .Where(r => r.Field<string>("REQ_followUpCode") == ConfigurationManager.AppSettings["ConsentFollowUpSIS"].ToString() && r.Field<string>("REQ_status") != ConfigurationManager.AppSettings["ConsentFollowUpStatus"].ToString()
                                                               || r.Field<string>("REQ_followUpCode") == ConfigurationManager.AppSettings["ConsentFollowUpCNE"].ToString() && r.Field<string>("REQ_status") != ConfigurationManager.AppSettings["ConsentFollowUpStatus"].ToString()
                                                               || r.Field<string>("REQ_followUpCode") == ConfigurationManager.AppSettings["ConsentFollowUpCME"].ToString() && r.Field<string>("REQ_status") != ConfigurationManager.AppSettings["ConsentFollowUpStatus"].ToString()
                                                               || r.Field<string>("REQ_followUpCode") == ConfigurationManager.AppSettings["ConsentFollowUpCOP"].ToString() && r.Field<string>("REQ_status") != ConfigurationManager.AppSettings["ConsentFollowUpStatus"].ToString()
                                                               || r.Field<string>("REQ_followUpCode") == ConfigurationManager.AppSettings["ConsentFollowUpCOL"].ToString() && r.Field<string>("REQ_status") != ConfigurationManager.AppSettings["ConsentFollowUpStatus"].ToString()
                                                               ).Count();
                                            ViewState["dtrequirements"] = dsreqdetails.Tables[0];
                                            if (ConsentReqtRaisedCount > 0)
                                            {
                                                ConsentLetter(strApplicationno, strChannelType);
                                            }
                                            else
                                            {
                                                Logger.Info(strApplicationno + "Consent FollowUpCode Not Raised" + System.Environment.NewLine);
                                            }

                                        }

                                    }
                                    catch (Exception ex)
                                    {

                                        Logger.Info(strApplicationno + "ConsentLetterFailure" + " " + ex.Message.ToString() + System.Environment.NewLine);
                                    }


                                }
                                else
                                {
                                    Logger.Info(strApplicationno + "ConsentFollowUpNotRaised" + " " + isConsentReq + System.Environment.NewLine);
                                }

                                /************************2.2 End of Changes by Akshada; CR-28153****************************************/
                                objBussiness.UpdatePolicyStatus(strApplicationno, "PS", struserid, ref intRetVal);
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                        Logger.Info(strApplicationno + ex.Message.ToString() + System.Environment.NewLine);
                    }
                }
                else
                {
                    ShowPopupMessage("Details Post Successfully", 1);

                    //lblErrorDecisiondtls.Text = "Decision Details Updated in Life Asia successfully";
                    if (ddlUWDecesion.SelectedValue == "Approved" && LAPushErrorCode == 0)
                    {
                        //objComm.OnlineUWMISDecision_Save(strApplicationno, ddlUWDecesion.SelectedValue, objCommonObj._bpm_branchCode, objChangeObj.userLoginDetails._ProcessName, objChangeObj.userLoginDetails._userBranch,
                        //    objCommonObj._AppType, struserid, objChangeObj.userLoginDetails._UserGroup, "", "", ref UWDecisionResult);
                        strAppstatusKey = (strUserGroup == "UW") ? "UC" : "DC";
                        objComm.OnlineApplicationchangeStatus(strApplicationno, struserid, strAppstatusKey, "", ref Result);
                        //_strPolicyStatus = "IF";
                        objBussiness.UpdatePolicyStatus(strApplicationno, "UW", struserid, ref intRetVal);

                        //To Insert Record in LF_applicationstatus table with '091' status 
                        objBussiness.InsertAppStatus(strApplicationno, struserid, ref intRetVal);
                    }
                    else if (ddlUWDecesion.SelectedValue == "Declined" && LAPushErrorCode == 0)
                    {

                        //objComm.OnlineUWMISDecision_Save(strApplicationno, ddlUWDecesion.SelectedValue, objCommonObj._bpm_branchCode, objChangeObj.userLoginDetails._ProcessName, objChangeObj.userLoginDetails._userBranch,
                        //    objCommonObj._AppType, struserid, objChangeObj.userLoginDetails._UserGroup, ddlUWreason.SelectedValue, ddlUWreason.SelectedItem.Text, ref UWDecisionResult);
                        strAppstatusKey = (strUserGroup == "UW") ? "UC" : "DC";
                        objComm.OnlineApplicationchangeStatus(strApplicationno, struserid, strAppstatusKey, "", ref Result);

                        //_strPolicyStatus = "DC";
                        objBussiness.UpdatePolicyStatus(strApplicationno, "DC", struserid, ref intRetVal);


                    }
                    else if (ddlUWDecesion.SelectedValue == "Postponed" && LAPushErrorCode == 0)
                    {
                        strAppstatusKey = (strUserGroup == "UW") ? "UC" : "DC";
                        objComm.OnlineApplicationchangeStatus(strApplicationno, struserid, strAppstatusKey, "", ref Result);
                        //_strPolicyStatus = "PO";
                        objBussiness.UpdatePolicyStatus(strApplicationno, "PO", struserid, ref intRetVal);
                    }
                    else if (ddlUWDecesion.SelectedValue == "Withdrawn" && LAPushErrorCode == 0)
                    {
                        strAppstatusKey = (strUserGroup == "UW") ? "UC" : "DC";
                        objComm.OnlineApplicationchangeStatus(strApplicationno, struserid, strAppstatusKey, "", ref Result);
                        //_strPolicyStatus = "WD";
                        objBussiness.UpdatePolicyStatus(strApplicationno, "WD", struserid, ref intRetVal);
                    }
                    else if (ddlUWDecesion.SelectedValue == "proposal" && LAPushErrorCode == 0)
                    {
                        strAppstatusKey = (strUserGroup == "UW") ? "UC" : "DC";
                        /************************2.2 Begin of Changes by Akshada; CR-28153****************************************/
                        /***Comments: Used to Check Consent FollowUpCode Raised or not ****/
                        try
                        {
                            objComm.OnlineRequirmentDisplayDetails_GET(ref dsreqdetails, strApplicationno, strChannelType);
                            if (dsreqdetails.Tables[0].Rows.Count > 0)
                            {
                                DataTable dtrequirements = dsreqdetails.Tables[0].AsEnumerable()
                                             .Where(r => r.Field<string>("REQ_followUpCode") == ConfigurationManager.AppSettings["ConsentFollowUpSIS"].ToString() && r.Field<string>("REQ_status") != ConfigurationManager.AppSettings["ConsentFollowUpStatus"].ToString()
                                                               || r.Field<string>("REQ_followUpCode") == ConfigurationManager.AppSettings["ConsentFollowUpCNE"].ToString() && r.Field<string>("REQ_status") != ConfigurationManager.AppSettings["ConsentFollowUpStatus"].ToString()
                                                               || r.Field<string>("REQ_followUpCode") == ConfigurationManager.AppSettings["ConsentFollowUpCME"].ToString() && r.Field<string>("REQ_status") != ConfigurationManager.AppSettings["ConsentFollowUpStatus"].ToString()
                                                               || r.Field<string>("REQ_followUpCode") == ConfigurationManager.AppSettings["ConsentFollowUpCOP"].ToString() && r.Field<string>("REQ_status") != ConfigurationManager.AppSettings["ConsentFollowUpStatus"].ToString()
                                                               || r.Field<string>("REQ_followUpCode") == ConfigurationManager.AppSettings["ConsentFollowUpCOL"].ToString() && r.Field<string>("REQ_status") != ConfigurationManager.AppSettings["ConsentFollowUpStatus"].ToString()
                                                               ).CopyToDataTable();

                                ViewState["dtrequirements"] = dtrequirements;
                                TextBox txtSumassure = (TextBox)ContentPlaceHolder1.FindControl("txtSumassure");
                                HiddenField hdfSumassure = (HiddenField)ContentPlaceHolder1.FindControl("hdfSumassure");
                                HiddenField hfdCalPremSA = (HiddenField)ContentPlaceHolder1.FindControl("hfdCalPremSA");
                                HiddenField hfdCalPremFlag = (HiddenField)ContentPlaceHolder1.FindControl("hfdCalPremFlag");


                                if (txtSumassure.Text.Trim() != hdfSumassure.Value.Trim() && txtSumassure.Text.Trim() == hfdCalPremSA.Value.Trim() && hfdCalPremFlag.Value == "0")
                                {
                                    ShowPopupMessage("Please Click on Calculate Premium", 0);
                                    Logger.Info(strApplicationno + "Not Clicked on Premium calculation" + System.Environment.NewLine);
                                    return;
                                }
                                else
                                {
                                    Logger.Info(strApplicationno + "ConsentLetter_Invoked" + System.Environment.NewLine);
                                    ConsentLetter(strApplicationno, strChannelType);

                                }
                            }
                            else
                            {
                                Logger.Info(strApplicationno + "Consent FollowUpCode Not Raised" + System.Environment.NewLine);
                            }
                        }
                        catch (Exception ex)
                        {

                            Logger.Info(strApplicationno + "ConsentLetter_failure" + " " + ex.Message.ToString() + System.Environment.NewLine);
                        }

                        /************************2.2 End of Changes by Akshada; CR-28153****************************************/

                        //objComm.OnlineApplicationchangeStatus(strApplicationno, struserid, strAppstatusKey, "", ref Result);
                        //_strPolicyStatus = "WD";
                        objBussiness.UpdatePolicyStatus(strApplicationno, "PS", struserid, ref intRetVal);
                    }
                }
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Details Post Successfully')", true);

                //Session.Abandon();
                /*added by shri on 06-07-17 to close page on success*/
                //Page.ClientScript.RegisterStartupScript(Page.GetType(), "show success message", "alert('Decision details save successfully');window.close();", true);
                /*end here*/
            }
            else
            {
                ShowPopupMessage(strLAPushErrorMsg, 0);
                /*commented and added by shri on 06-07-17 to close page on success*/
                //lblErrorDecisiondtls.Text = "Decision Details Not Updated in Life Asia,Please Contact system admin";
                //lblErrorDecisiondtls.Focus();
                //Page.ClientScript.RegisterStartupScript(Page.GetType(), "show failure message", "alert("+strLAPushErrorMsg+");", true);
                //Page.ClientScript.RegisterStartupScript(Page.GetType(), "show failure message", "alert('Decision Details Not Updated in Life Asia due to " + strLAPushErrorMsg+ ");", true);
                /*end here*/
            }
        }
        else
        {
            /*commented and added by shri on 06-07-17 to close page on success*/
            //lblErrorDecisiondtls.Text = "Decision details Not Save ,Please Contact system admin";
            //lblErrorDecisiondtls.Focus();
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "show failure message", "alert('Decision details Not Save ,Please Contact system admin');", true);
            /*end here*/
        }
    }

    protected void btnSystem_Click(object sender, EventArgs e)
    {
        //int intRetVal = -1;
        //string struserid = string.Empty;
        //if (Session["objCommonObj"] != null)
        //{
        //    objCommonObj = (CommonObject)Session["objCommonObj"];
        //    struserid = objCommonObj._Bpmuserdetails._UserID;
        //    objComm.ManageApplicationLifeCycle(strApplicationno, struserid, "UW_DECISION_SYSTEM", false, ref intRetVal);
        //}
        //objBussiness.UpdatePolicyStatus(strApplicationno, "UW", struserid, ref intRetVal);
        //objComm.ManageApplicationLifeCycle(strApplicationno, struserid, "UW_DECISION_SYSTEM", true, ref intRetVal);
        ////Page.ClientScript.RegisterStartupScript(Page.GetType(), "show failure message", "alert('Added to queue');window.close();", true);
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "show failure message", "alert('Decision details Not Save ,Please Contact system admin');", true);
    }

    private void ContentClientDetails(MasterPageComparision objMasterPageComparision)
    {
        GridView gvClientDetails = (GridView)ContentPlaceHolder1.FindControl("gvClientDetails");
        List<ClientSection> lstClientDetails = new List<ClientSection>();
        foreach (GridViewRow rowfollowup in gvClientDetails.Rows)
        {
            ClientSection objClientDetails = new ClientSection();
            //define variable                            
            //Label lblClientId = (Label)rowfollowup.FindControl("ClientId");
            //Label lblRole = (Label)rowfollowup.FindControl("Role");
            string lblClientId = rowfollowup.Cells[0].Text;
            string lblRole = rowfollowup.Cells[5].Text;

            objClientDetails.ClientId = lblClientId;
            objClientDetails.ClientRole = lblRole;
            lstClientDetails.Add(objClientDetails);
        }
        objMasterPageComparision.LstClientDetails = lstClientDetails;
    }

    private void ContentRiderDetails(MasterPageComparision objMasterPageComparision)
    {
        GridView gvRiderDtls = (GridView)ContentPlaceHolder1.FindControl("gvRiderDtls");
        List<RiderSection> lstRiderSection = new List<RiderSection>();
        foreach (GridViewRow rowfollowup in gvRiderDtls.Rows)
        {
            //define variable
            CheckBox cbIsRider = (CheckBox)rowfollowup.FindControl("chkremoveRider");

            if (cbIsRider.Checked)
            {
                Label lblRiderName = (Label)rowfollowup.FindControl("lblRiderName");
                RiderSection objRiderSection = new RiderSection();
                TextBox txtRiderSumAssured = (TextBox)rowfollowup.FindControl("txtRiderSumAssure");
                Label lblRiderCode = (Label)rowfollowup.FindControl("lblRiderCode");
                string[] strRiderSumAssured = txtRiderSumAssured.Text.Split(',');
                if (strRiderSumAssured.Length > 0)
                {
                    txtRiderSumAssured.Text = strRiderSumAssured[strRiderSumAssured.Length - 1];
                }
                objRiderSection.RiderCode = lblRiderCode.Text;
                objRiderSection.RiderSumAssured = txtRiderSumAssured.Text;
                lstRiderSection.Add(objRiderSection);
            }
        }
        objMasterPageComparision.LstRiderSection = lstRiderSection;
    }

    private void ContentProductDetails(MasterPageComparision objMasterPageComparision)
    {
        List<ProductSection> lstProductSection = new List<ProductSection>();
        string strComboMonthlyPayout = string.Empty;
        string strProdMonthlyPayout = string.Empty;
        ProductSection objProductSectionBase = new ProductSection();
        ProductSection objProductSectionCombo = new ProductSection();
        TextBox txtPolterm = (TextBox)ContentPlaceHolder1.FindControl("txtPolterm");
        TextBox txtSumassure = (TextBox)ContentPlaceHolder1.FindControl("txtSumassure");
        TextBox txtProdcode = (TextBox)ContentPlaceHolder1.FindControl("txtProdcode");
        TextBox txtPrepayterm = (TextBox)ContentPlaceHolder1.FindControl("txtPrepayterm");
        DropDownList ddlFrequency = (DropDownList)ContentPlaceHolder1.FindControl("ddlFrequency");


        TextBox txtCombProdCode = (TextBox)ContentPlaceHolder1.FindControl("txtCombProdCode");
        TextBox txtCombPolTerm = (TextBox)ContentPlaceHolder1.FindControl("txtCombPolTerm");
        TextBox txtCombSumAssured = (TextBox)ContentPlaceHolder1.FindControl("txtCombSumAssured");
        TextBox txtCombPayTerm = (TextBox)ContentPlaceHolder1.FindControl("txtCombPayTerm");

        objProductSectionBase.PolicyTerm = Request.Form[txtPolterm.UniqueID];
        objProductSectionBase.PremiumFreq = ddlFrequency.SelectedValue;
        objProductSectionBase.SumAssured = Request.Form[txtSumassure.UniqueID];
        objProductSectionBase.ProductCode = txtProdcode.Text;
        objProductSectionBase.PremiumTerm = Request.Form[txtPrepayterm.UniqueID];
        lstProductSection.Add(objProductSectionBase);

        if (!string.IsNullOrEmpty(txtCombProdCode.Text))
        {
            objProductSectionCombo.PolicyTerm = Request.Form[txtCombPolTerm.UniqueID];
            objProductSectionCombo.PremiumFreq = ddlFrequency.SelectedValue;
            objProductSectionCombo.SumAssured = Request.Form[txtCombSumAssured.UniqueID];
            objProductSectionCombo.ProductCode = Request.Form[txtCombProdCode.UniqueID];
            objProductSectionCombo.PremiumTerm = Request.Form[txtCombPayTerm.UniqueID];
            lstProductSection.Add(objProductSectionCombo);
        }
        objMasterPageComparision.LstProductSection = lstProductSection;
    }


    private void ShowPopupMessage(string alertMessage, int strErrorCode)
    {
        if (strErrorCode == 0)
        {

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "ShowModalPopup('" + alertMessage + "');", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "ShowModalPopup('" + alertMessage + "');", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('" + alertMessage + "');window.close();", true);
            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "show failure message", "ShowModalPopupClose('" + alertMessage + "');", true);
        }
    }

    /*added by shri on 28 dec 17 to add tracking*/
    private void InsertUwDecisionTracking(string strApplicationNo, string strUserId, DateTime dtCurrentDateTime, string strEventName, ref int intRet)
    {
        objComm = new Commfun();
        objComm.InsertUwDecisionTracking(strApplicationNo, strUserId, dtCurrentDateTime.ToString("yyyy-MM-dd HH:mm:ss:fff"), strEventName, ref intRet);
    }

    /*added by shri on 28 dec 17 to update tracking*/
    private void UpdateUwDecisionTracking(int intSrNo, DateTime dtEndDate, ref int intRet)
    {
        objComm = new Commfun();
        objComm.UpdateUwDecisionTracking(intSrNo, dtEndDate.ToString("yyyy-MM-dd HH:mm:ss:fff"), ref intRet);
    }
    /*end here*/

    protected void btnOpenExcel_Click(object sender, EventArgs e)
    {
        Response.Write("<script>");
        Response.Write("window.open('../AppCode/UW Guidelines for IT -March 2019.pdf', '_newtab');");
        Response.Write("</script>");
    }



    /***********2.3 Begin of Changes by Akshada; CR-28153************/

    string ConsentAPI = ConfigurationManager.AppSettings["ConsentAPI"].ToString().Trim();
    private bool ConsentLetter(string strApplicationno, string ChannelType)
    {

        try
        {

            int strLApushErrorCode = 0;

            //Existing Method Used To Fetch Requirement Details
            objComm.OnlineRequirmentDisplayDetails_GET(ref dsreqdetails, strApplicationno, ChannelType);

            try
            {

                objComm.ClientBasicInfo_GET(ref _dsClientInfo, strApplicationno);//Existing Method Used to fetch Client And Proposer name
                objUWDecision.OnlineApplicationLAServiceDetails_PUSH(strApplicationno, strChannelType, objChangeObj, ref _ds, ref _dsPrevPol, "PREMIUMCAL", ref strLApushErrorCode, ref strLApushStatus, ref strConsentRespons);//Existing Method
                dtclientdetails = objComm.GetClientData(strPolicyNo);//EzytekMethod Used to get Client Email Id and MobileNo
                objComm.OnlineProductDisplayDetails_GET(ref _dsProdDtls, strApplicationno, ChannelType);//Existing Method Used to Get Plan details

                dtclientinfo = _dsClientInfo.Tables[0].Select("Role = 'Proposer'").CopyToDataTable();
                dtproductdetails = _dsProdDtls.Tables[0];
                TextBox txtAmtinSuspense = (TextBox)ContentPlaceHolder1.FindControl("txtAmountinsuspense");
                dt = _ds.Tables[0];

                if (dtclientinfo.Rows.Count > 0 && dtproductdetails.Rows.Count > 0 && dt.Rows.Count > 0)
                {
                    #region BasePlan Details
                    objconsentparams.CustomerName = dtclientinfo.Rows[0]["ClientFullName"].ToString().Trim();
                    objconsentparams.ProductName = dtproductdetails.Rows[0]["ProdcutName"].ToString().Trim();
                    objconsentparams.B_SumAssured = !string.IsNullOrEmpty(dtproductdetails.Rows[0]["SumAssured"].ToString().Trim()) ? Convert.ToDecimal(dtproductdetails.Rows[0]["SumAssured"]) : 0;
                    objconsentparams.B_PolicyTerm = !string.IsNullOrEmpty(dtproductdetails.Rows[0]["PolicyTerm"].ToString().Trim()) ? Convert.ToInt32(dtproductdetails.Rows[0]["PolicyTerm"]) : 0;
                    objconsentparams.B_PremiumPaymentTerm = !string.IsNullOrEmpty(dtproductdetails.Rows[0]["PremiumTerm"].ToString().Trim()) ? Convert.ToInt32(dtproductdetails.Rows[0]["PremiumTerm"]) : 0;
                    objconsentparams.B_PlanId = dtproductdetails.Rows[0]["ProductCode"].ToString().Trim();
                    objconsentparams.Proposer = objconsentparams.CustomerName;
                    objconsentparams.B_BasePremium = !string.IsNullOrEmpty(dtproductdetails.Rows[0]["BasePremium"].ToString().Trim()) ? Convert.ToDecimal(dtproductdetails.Rows[0]["BasePremium"]) : 0;
                    objconsentparams.b_LoadedPremium = !string.IsNullOrEmpty(dt.Rows[0]["ExtraPremiumAmt"].ToString().Trim()) ? Convert.ToDecimal(dt.Rows[0]["ExtraPremiumAmt"]) : 0;
                    objconsentparams.B_Tax = !string.IsNullOrEmpty(dtproductdetails.Rows[0]["ServiceTax"].ToString().Trim()) ? Convert.ToDecimal(dtproductdetails.Rows[0]["ServiceTax"]) : 0;
                    objconsentparams.B_TotalPayableAmount = objconsentparams.B_BasePremium + objconsentparams.b_LoadedPremium + objconsentparams.B_Tax;
                    objconsentparams.ConsentCreatedBy = objCommonObj._Bpmuserdetails._UserID;
                    objconsentparams.Consentupdatedby = objCommonObj._Bpmuserdetails._UserID;
                    objconsentparams.B_TotalAmountPaidTillNow = !string.IsNullOrEmpty(txtAmtinSuspense.Text) ? Convert.ToDecimal(txtAmtinSuspense.Text) : 0;
                    objconsentparams.B_BalanceAmountPayable = objconsentparams.B_TotalPayableAmount - objconsentparams.B_TotalAmountPaidTillNow;
                    objconsentparams.EmaiILD = dtclientdetails.Rows[0]["Email"].ToString();
                    objconsentparams.MobileNo = dtclientdetails.Rows[0]["MobileNumber"].ToString();
                    string IsExternal = ConfigurationManager.AppSettings["IsExternal"].ToString().Trim();
                    objconsentparams.ConsentStatus = ConfigurationManager.AppSettings["ConsentRaised"].ToString().Trim();
                    #endregion BasePlan

                    #region BasePlan Insertion Start 


                    //Ezytek Method to insert in Consent Tables
                    try
                    {
                        dtinsertclientdetials = objComm.InsertConsentDetails(strPolicyNo, "02", strApplicationno, objconsentparams.ProductName, objconsentparams.Proposer, objconsentparams.CustomerName, objconsentparams.B_SumAssured, objconsentparams.B_PolicyTerm, objconsentparams.B_BasePremium, objconsentparams.b_LoadedPremium, objconsentparams.B_Tax, objconsentparams.B_TotalPayableAmount, objconsentparams.B_TotalAmountPaidTillNow, objconsentparams.B_BalanceAmountPayable, objconsentparams.B_PlanId, objconsentparams.ConsentStatus, objconsentparams.B_PremiumPaymentTerm, objconsentparams.ConsentCreatedBy, objconsentparams.Consentupdatedby, true, objconsentparams.Guid, "", "");
                        objconsentparams.Guid = dtinsertclientdetials.Rows[0]["UniqueID"].ToString().Trim();
                        dtinsertclientdetials = objComm.InsertConsentDetails(strPolicyNo, "05", strApplicationno, objconsentparams.ProductName, objconsentparams.Proposer, objconsentparams.CustomerName, objconsentparams.B_SumAssured, objconsentparams.B_PolicyTerm, objconsentparams.B_BasePremium, objconsentparams.b_LoadedPremium, objconsentparams.B_Tax, objconsentparams.B_TotalPayableAmount, objconsentparams.B_TotalAmountPaidTillNow, objconsentparams.B_BalanceAmountPayable, objconsentparams.B_PlanId, objconsentparams.ConsentStatus, objconsentparams.B_PremiumPaymentTerm, objconsentparams.ConsentCreatedBy, objconsentparams.Consentupdatedby, true, objconsentparams.Guid, objconsentparams.EmaiILD, objconsentparams.MobileNo);
                        Logger.Info(strApplicationno + "BasePlan Insertion Sucess For Consent Letter" + System.Environment.NewLine);
                    }
                    catch (Exception ex)
                    {
                        Logger.Info(strApplicationno + "BasePlan Insertion Failure For Consent Letter" + " " + ex.Message.ToString() + System.Environment.NewLine);
                        throw ex;
                    }

                    //Condition used to insert revised sum assured value in CommHistory table only if Reduction of Sum assured followup is raised else pass 0
                    dtrequirements = (DataTable)ViewState["dtrequirements"];

                    objconsentparams.B_SumAssured = 0;

                    dtinsertclientdetials = objComm.InsertConsentDetails(strPolicyNo, "03", strApplicationno, objconsentparams.ProductName, objconsentparams.Proposer, objconsentparams.CustomerName, objconsentparams.B_SumAssured, objconsentparams.B_PolicyTerm, objconsentparams.B_BasePremium, objconsentparams.b_LoadedPremium, objconsentparams.B_Tax, objconsentparams.B_TotalPayableAmount, objconsentparams.B_TotalAmountPaidTillNow, objconsentparams.B_BalanceAmountPayable, objconsentparams.B_PlanId, objconsentparams.ConsentStatus, objconsentparams.B_PremiumPaymentTerm, objconsentparams.ConsentCreatedBy, objconsentparams.Consentupdatedby, true, objconsentparams.Guid, "", "");
                    Logger.Info(strApplicationno + "ConsentLetter_Success" + System.Environment.NewLine);
                    #endregion BasePlan Insertion End

                    #region Rider Section

                    //Ezytek method to insert rider details in consent table
                    _dsriderdetails = objComm.FetchRiderDetailsConsentLetter(strApplicationno, ChannelType);
                    try
                    {
                        foreach (DataTable dtttt in _dsriderdetails.Tables)
                        {
                            foreach (DataRow drrr in dtttt.Rows)
                            {
                                objconsentparams.Ridername = drrr["RIDERNAME"].ToString();
                                objconsentparams.RiderId = drrr["RIDERCODE"].ToString();

                                objconsentparams.R_SumAssured = !string.IsNullOrEmpty(drrr["RIDERSUMASSURED"].ToString()) ? Convert.ToDecimal(drrr["RIDERSUMASSURED"]) : 0;
                                objconsentparams.R_PolicyTerm = !string.IsNullOrEmpty(drrr["RiderPT"].ToString()) ? Convert.ToInt32(drrr["RiderPT"]) : 0;
                                objconsentparams.R_PremiumPaymentTerm = !string.IsNullOrEmpty(drrr["RiderPPT"].ToString()) ? Convert.ToInt32(drrr["RiderPPT"]) : 0;
                                objconsentparams.R_TotalTax = !string.IsNullOrEmpty(drrr["SERVICETAX"].ToString()) ? Convert.ToInt32(drrr["SERVICETAX"]) : 0;
                                dtinsertclientdetials = objComm.InsertConsentDetails(strPolicyNo, "05", strApplicationno, objconsentparams.Ridername, objconsentparams.Proposer, objconsentparams.CustomerName, objconsentparams.R_SumAssured, objconsentparams.R_PolicyTerm, objconsentparams.R_BasePremium, objconsentparams.R_LoadedPremium, objconsentparams.R_TotalTax, 0, 0, 0, objconsentparams.RiderId, objconsentparams.ConsentStatus, objconsentparams.R_PremiumPaymentTerm, objconsentparams.ConsentCreatedBy, objconsentparams.Consentupdatedby, false, objconsentparams.Guid, "", "");
                                dtinsertclientdetials = objComm.InsertConsentDetails(strPolicyNo, "03", strApplicationno, objconsentparams.Ridername, objconsentparams.Proposer, objconsentparams.CustomerName, 0, objconsentparams.R_PolicyTerm, objconsentparams.R_BasePremium, objconsentparams.R_LoadedPremium, objconsentparams.R_TotalTax, 0, 0, 0, objconsentparams.RiderId, objconsentparams.ConsentStatus, objconsentparams.R_PremiumPaymentTerm, objconsentparams.ConsentCreatedBy, objconsentparams.Consentupdatedby, false, objconsentparams.Guid, "", "");
                            }
                            Logger.Info(strApplicationno + "Rider Details Insertion Success" + System.Environment.NewLine);
                        }
                    }
                    catch (Exception ex)
                    {

                        Logger.Info(strApplicationno + "Rider Details Insertion Failure" + "" + ex.Message.ToString() + System.Environment.NewLine);
                        throw ex;
                    }


                    #endregion Rider Section
                    try
                    {
                        RequestID = API_FetchRequestID(ConfigurationManager.AppSettings["CounterOfferGenerated"].ToString().Trim(), objconsentparams.Guid);
                        SMSRequestID = API_FetchRequestID(ConfigurationManager.AppSettings["ConsentSMS"].ToString().Trim(), objconsentparams.Guid);
                        Logger.Info(strApplicationno + "CounterOffer communication Response" + "Email RequestID :" + RequestID + "SMS RequestID: " + SMSRequestID + System.Environment.NewLine);
                        if (RequestID <= 0 && SMSRequestID <= 0)
                        {
                            ConsentRaised = false;
                        }
                        else
                        {
                            ConsentRaised = true;
                        }

                    }
                    catch (Exception ex)
                    {
                        Logger.Info(strApplicationno + "CounterOffer Communication Failure" + " " + ex.Message.ToString() + System.Environment.NewLine);
                    }

                }
                else
                {
                    ConsentRaised = false;
                    Logger.Info(strApplicationno + "MethodName:ConsentLetter|Data Not Found" + System.Environment.NewLine);

                }
            }
            catch (Exception ex)
            {
                ConsentRaised = false;
                Logger.Info(strApplicationno + "MethodName:ConsentLetter|Exception Details: " + ex.Message.ToString() + System.Environment.NewLine);

            }


            Logger.Info(strApplicationno + "ConsentFollowUpRaised" + System.Environment.NewLine);

        }
        catch (Exception ex)
        {
            Logger.Info(strApplicationno + "ConsentLetter_Failure-2" + ex.Message.ToString() + System.Environment.NewLine);
            ConsentRaised = false;

        }

        return ConsentRaised;
    }

    #region API Methods


    public int API_FetchRequestID(string Process, string Guid)
    {

        int RequestID = new int();
        try
        {
            var input = new
            {
                ProcessName = Process,
                GUID = Guid


            };
            string inputJson = (new JavaScriptSerializer()).Serialize(input);
            HttpClient client = new HttpClient();
            HttpContent inputContent = new StringContent(inputJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(ConsentAPI + "/SendCommunication", inputContent).Result;
            if (response.IsSuccessStatusCode)
            {
                RequestID = JsonConvert.DeserializeObject<int>(response.Content.ReadAsStringAsync().Result);
            }
        }
        catch (Exception ex)
        {

            Logger.Info(strApplicationno + "API_FetchRequestID Failure" + ex.Message.ToString() + System.Environment.NewLine);
            throw ex;
        }
        return RequestID;
    }

    #endregion

    /************2.3 End of Changes by Akshada; CR-28153***********/
    //added by suraj for combi
    private void UpdateDecisionInLa_Combi(ref int response, DropDownList ddlUWDecesion, DropDownList ddlUWreason, DropDownList ddlPostpone, Label lblErrorDecisiondtls)
    {
        //declare variable
        int LAPushErrorCode = 0;
        int UWDecisionResult = 0;
        string strLAPushErrorMsg = string.Empty;
        int Result = 0;
        Boolean isConsentReq = false;
        objCommonObj = (CommonObject)Session["objCommonObj"];
        objChangeObj = (ChangeValue)Session["objLoginObj"];
        struserid = objChangeObj.userLoginDetails._UserID;
        strUWmode = strChannelType;
        UWSaralDecision.BussLayer objBuss = new UWSaralDecision.BussLayer();
        Logger.Info(strApplicationno + "STAG 2 :PageName :Bpmuwmodule.cs // MethodeName :btnPost_Click" + System.Environment.NewLine);
        //DropDownList ddlUWDecesion = (DropDownList)ContentPlaceHolder1.FindControl("ddlUWDecesion");
        //DropDownList ddlUWreason = (DropDownList)ContentPlaceHolder1.FindControl("ddlUWreason");
        //DropDownList ddlPostpone = (DropDownList)ContentPlaceHolder1.FindControl("ddlPeriod");
        //Label lblErrorDecisiondtls = (Label)ContentPlaceHolder1.FindControl("lblErrorDecisiondtls");
        //########################## 1.3 Begin of Changes CR 26273;Akshada###########################################
        Logger.Info(strApplicationno + "UpdateDecisionInLa_Revival_01chnages starts" + System.Environment.NewLine);
        DropDownList ddlStatusREQ = (DropDownList)ContentPlaceHolder1.FindControl("ddlStatus");
        Logger.Info(strApplicationno + "UpdateDecisionInLa_Revival_01chnages ends" + System.Environment.NewLine);
        //########################## 1.3 End of Changes CR 26273;Akshada ###########################################

        if (objChangeObj.Load_Loadingdetails != null)
        {
            isConsentReq = objChangeObj.Load_Loadingdetails.isConsentRequired;
        }
        else
        {
            isConsentReq = false;
        }
        string _strUWDecesion = ddlUWDecesion.SelectedValue;
        string _strUWPeriod = ddlPostpone.SelectedValue == "0" ? "" : ddlPostpone.SelectedValue;
        string _strDataValue = string.Empty;
        int intRetVal = -1;
        //########################## 1.4 Begin of Changes CR 26273;Akshada ###########################################

        Logger.Info(strApplicationno + "UpdateDecisionInLa_Revival_02chnages starts" + System.Environment.NewLine);
        try
        {
            Session["RequestType"] = "";
            if (Request.Url.Segments.Length > 2 && Request.Url.Segments[2].ToString() == "RevivalUwdecision.aspx")
            {
                Session["RequestType"] = "Revival";
            }
            if (Session["RequestType"].ToString() == "Revival")
                Logger.Info(Session["RequestType"].ToString() + "Revival start" + System.Environment.NewLine);
            {
                objCommonObj._AppType = "Single";
            }
            Logger.Info(strApplicationno + "UpdateDecisionInLa_Revival_02chnages ends" + objCommonObj._AppType + System.Environment.NewLine);
        }
        catch (Exception ex)
        {

            Logger.Info(strApplicationno + ex.Message.ToString() + objCommonObj._AppType + System.Environment.NewLine);
        }


        //##########################1.4 End of Changes CR 26273;Akshada###########################################

        //call servics
        objComm.OnlineUWDecisionDetails_Save(objCommonObj._AppType, strApplicationno, ddlUWDecesion.SelectedItem.Text, ddlUWreason.SelectedItem.Text, ddlUWDecesion.SelectedValue, ddlUWreason.SelectedItem.Value, _strUWPeriod, struserid, objChangeObj.userLoginDetails._UserName, objChangeObj.userLoginDetails._UserGroup, objCommonObj._bpm_branchCode, objCommonObj._bpm_creationDate,
      objCommonObj._bpm_systemDate, objCommonObj._bpm_businessDate, objChangeObj.userLoginDetails._userBranch, objChangeObj.userLoginDetails._ProcessName, strApplicationno, ref UWDecisionResult);
        if (UWDecisionResult != -1)
        {
            string strConsentResponse = string.Empty;
            //lblErrorDecisiondtls.Text = "Decision details save successfully";
            //########################## 1.5 Begin of Changes CR 26273;Akshada ###################################################
            try
            {
                Session["RequestType"] = "";
                Logger.Info(Session["RequestType"].ToString() + "check revival" + System.Environment.NewLine);
                if (Request.Url.Segments.Length > 2 && Request.Url.Segments[2].ToString() == "RevivalUwdecision.aspx")
                {
                    Logger.Info(Session["RequestType"].ToString() + "check revival_1" + System.Environment.NewLine);
                    Session["RequestType"] = "Revival";
                    Logger.Info(Session["RequestType"].ToString() + "check revival_2" + System.Environment.NewLine);
                }

                if (Session["RequestType"].ToString() == "Revival")
                {
                    Logger.Info(Session["RequestType"].ToString() + "check revival_3" + System.Environment.NewLine);
                    Logger.Info(strApplicationno + "master post Event Start_Step21" + System.Environment.NewLine);
                    HiddenField HdnPremPayingStatus1 = (HiddenField)ContentPlaceHolder1.FindControl("hdnPremPayingStatus");
                    HiddenField HdnPolicyStatus1 = (HiddenField)ContentPlaceHolder1.FindControl("hdnPolicyStatus");
                    if (Session["hdnNewFollowup"] != null)
                    {
                        NEWFollowUp = Session["hdnNewFollowup"].ToString();
                        NEWFollowUp.ToString();

                    }

                    if (HdnPremPayingStatus1.Value.Trim() == "Lapsed" ||
                            HdnPremPayingStatus1.Value.Trim() == "HA" || HdnPremPayingStatus1.Value.Trim() == "AC"
                            || HdnPremPayingStatus1.Value.Trim() == "PH" || HdnPremPayingStatus1.Value.Trim() == "UD" || HdnPolicyStatus1.Value.Trim() == "LA" ||
                            HdnPolicyStatus1.Value.Trim() == "PU" || HdnPolicyStatus1.Value.Trim() == "DU" || HdnPolicyStatus1.Value.Trim() == "HP")
                    {
                        Logger.Info(strApplicationno + "master post Event Start_04042020_v1" + System.Environment.NewLine);
                        LAPushErrorCode = 0;
                    }
                    else
                    {
                        objBuss.OnlineApplicationLAServiceDetails_PUSH(strApplicationno, strUWmode, objChangeObj, ref _ds, ref _dsPrevPol, ddlUWDecesion.SelectedValue, ref LAPushErrorCode, ref strLAPushErrorMsg, ref strConsentResponse);
                    }
                }
                else
                {
                    objBuss.OnlineApplicationLAServiceDetails_PUSH(strApplicationno, strUWmode, objChangeObj, ref _ds, ref _dsPrevPol, ddlUWDecesion.SelectedValue, ref LAPushErrorCode, ref strLAPushErrorMsg, ref strConsentResponse);
                }
                Logger.Info(strApplicationno + "master post Event Start_Step22" + System.Environment.NewLine);
            }
            catch (Exception ex)
            {

                Logger.Info(strApplicationno + ex.Message.ToString() + System.Environment.NewLine);
            }

            //########################## 1.5 End of Changes CR 26273;Akshada ###########################################
            // objBuss.OnlineApplicationLAServiceDetails_PUSH(strApplicationno, strUWmode, objChangeObj, ref _ds, ref _dsPrevPol, ddlUWDecesion.SelectedValue, ref LAPushErrorCode, ref strLAPushErrorMsg, ref strConsentResponse);
            if (!string.IsNullOrEmpty(strConsentResponse) && !strConsentResponse.Equals("Failed"))
            {
                Logger.Info("Consent Letter for application No : {0} : {1}" + strApplicationno + strConsentResponse);
                //string filePath = Request.QueryString["FILEPATH"].ToString();
                //Response.ContentType = "application/pdf";
                //Response.WriteFile(strConsentResponse);
                Response.Write("<script>");
                Response.Write(String.Format("window.open('{0}','_blank')", ResolveUrl(strConsentResponse)));
                Response.Write("</script>");
                //WebClient myWebClient = new WebClient();
                // myWebClient.DownloadFile(strConsentResponse, "D:\abc.pdf");
                //Response.Redirect(strConsentResponse);
            }
            if (LAPushErrorCode == 0)
            {
                //########################## 1.6 Begin of Changes CR 26273;Akshada ###########################################

                Session["RequestType"] = "";
                if (Request.Url.Segments.Length > 2 && Request.Url.Segments[2].ToString() == "RevivalUwdecision.aspx")
                {
                    Logger.Info(strApplicationno + "master post Event Start_postponerevival" + System.Environment.NewLine);

                    Session["RequestType"] = "Revival";
                }
                if (Session["RequestType"].ToString() == "Revival")
                {
                    try
                    {
                        HiddenField HdnPolicyStatus = (HiddenField)ContentPlaceHolder1.FindControl("hdnPolicyStatus");
                        HiddenField HdnPremPayingStatus = (HiddenField)ContentPlaceHolder1.FindControl("hdnPremPayingStatus");
                        HiddenField HdnPolicyNumber = (HiddenField)ContentPlaceHolder1.FindControl("hdnPolNo");
                        TextBox txtProposerName = (TextBox)ContentPlaceHolder1.FindControl("LAName");

                        TextBox txtPremAmt = (TextBox)ContentPlaceHolder1.FindControl("txtTotalPrmPay");
                        TextBox txtPlanName = (TextBox)ContentPlaceHolder1.FindControl("txtProname1");
                        HiddenField hdnMobile = (HiddenField)ContentPlaceHolder1.FindControl("hdnModilenumber");
                        HiddenField hdnEmail = (HiddenField)ContentPlaceHolder1.FindControl("hdnEmail");
                        HiddenField HdnAppNumber = (HiddenField)ContentPlaceHolder1.FindControl("HdnApplicationNumber");
                        DropDownList ddlStatusREQ1 = (DropDownList)ContentPlaceHolder1.FindControl("ddlStatus");

                        HiddenField hdnbankname = (HiddenField)ContentPlaceHolder1.FindControl("hdfnBankName");
                        HiddenField hdnbankaccount = (HiddenField)ContentPlaceHolder1.FindControl("hdfnBankAcctNumber");


                        HiddenField hdnLAFullName = (HiddenField)ContentPlaceHolder1.FindControl("hdnLAFullname");

                        if (HdnPremPayingStatus.Value.Trim() == "Lapsed" ||
                            HdnPremPayingStatus.Value.Trim() == "HA" || HdnPremPayingStatus.Value.Trim() == "AC"
                            || HdnPremPayingStatus.Value.Trim() == "PH" || HdnPremPayingStatus.Value.Trim() == "UD" || HdnPolicyStatus.Value.Trim() == "LA" ||
                            HdnPolicyStatus.Value.Trim() == "PU" || HdnPolicyStatus.Value.Trim() == "DU" || HdnPolicyStatus.Value.Trim() == "HP")
                        {


                            if (ddlUWDecesion.SelectedValue == "Declined")
                            {
                                string ReqStatus = string.Empty;
                                GridView GvReq = (GridView)ContentPlaceHolder1.FindControl("gvRequirmentDetails");
                                int counter = 0;
                                foreach (GridViewRow rowfollowup in GvReq.Rows)
                                {
                                    DropDownList ddlStatus = rowfollowup.FindControl("ddlStatus") as DropDownList;
                                    if (ddlStatus.SelectedValue == "O")
                                    {
                                        counter = counter + 1;
                                    }
                                }


                                if (counter > 0 && NEWFollowUp == "TRUE")
                                {
                                    DataTable dtSMS = new DataTable();
                                    string ApplicationNo = HdnAppNumber.Value.Trim();
                                    string PolicyNumber = HdnPolicyNumber.Value.Trim();
                                    MobileNo = hdnMobile.Value.Trim();


                                    dtSMS = objBussiness.EmailParameter(Flag2, SMSCommunicationType, SMSCommunicationKey, DeclinedSMSProcess, DeclinedSMSTemplateId, hdnEmail.Value.Trim(), MailCC, MobileNo, Mode, CreatedBy, IsAttached, AttachedFiles, ApplicationNo, PolicyNumber, ParameterList, FileName, IsExternal);
                                    DataRow drSMS = dtSMS.Rows[0];

                                    string RequestId = drSMS["RequestId"].ToString();

                                    dtSMS = objBussiness.EmailParameter(Flag1, SMSCommunicationType, SMSCommunicationKey, DeclinedSMSProcess, DeclinedSMSTemplateId, hdnEmail.Value.Trim(), MailCC, MobileNo, Mode, CreatedBy, IsAttached, AttachedFiles, ApplicationNo, PolicyNumber, ParameterList, FileName, IsExternal);

                                    for (int i = 0; i < dtSMS.Rows.Count; i++)
                                    {
                                        string parameter = dtSMS.Rows[i][1].ToString();

                                        string col = dtSMS.Rows[i][1].ToString();
                                        switch (parameter)
                                        {

                                            case "<proposer name>":


                                                ParameterList = "'" + RequestId + "'" + "," + "'" + dtSMS.Rows[i][1].ToString() + "'" + "," + "'" + hdnLAFullName.Value.Trim() + "'),";

                                                break;

                                            case "<Plan Name>":
                                                ParameterList += "('" + RequestId + "'" + "," + "'" + dtSMS.Rows[i][1].ToString() + "'" + "," + "'" + txtPlanName.Text.Trim() + "'),";
                                                break;

                                            case "<Policy No.>":
                                                ParameterList += "('" + RequestId + "'" + "," + "'" + dtSMS.Rows[i][1].ToString() + "'" + "," + "'" + HdnPolicyNumber.Value.Trim() + "'";
                                                break;



                                            default:
                                                break;
                                        }
                                    }

                                    dtSMS = objBussiness.EmailParameter(Flag3, SMSCommunicationType, SMSCommunicationKey, DeclinedSMSProcess, DeclinedSMSTemplateId, hdnEmail.Value.Trim(), MailCC, MobileNo, Mode, CreatedBy, IsAttached, AttachedFiles, ApplicationNo, PolicyNumber, ParameterList, FileName, IsExternal);

                                    Session["hdnNewFollowup"] = null;

                                    //RejectedForImage//
                                    try
                                    {
                                        Logger.Info(strApplicationno + "RejectedForImage_email_start" + System.Environment.NewLine);
                                        DataTable dtemail = new DataTable();

                                        string CustomerName = hdnLAFullName.Value;

                                        string PolicyName = txtPlanName.Text.Trim();

                                        string Reason1 = ddlUWDecesion.SelectedValue.ToString();
                                        string Reason2 = ddlUWreason.SelectedValue.ToString();
                                        string BankName = string.Empty;
                                        string BankAccountNumber = string.Empty;
                                        IsAttached = "0";
                                        AttachedFiles = null;
                                        ApplicationNo = HdnAppNumber.Value.Trim();
                                        PolicyNumber = HdnPolicyNumber.Value.Trim();
                                        FileName = "Rejected_For_Image.html";
                                        IsExternal = "YES";


                                        dtemail = objBussiness.EmailParameter(Flag2, EmailCommunicationType, EmailCommunicationKey, DeclinedEmailProcess, DeclinedEmailTemplateId, hdnEmail.Value.Trim(), MailCC, hdnMobile.Value.Trim(), Mode, CreatedBy, IsAttached, AttachedFiles, ApplicationNo, PolicyNumber, ParameterList, FileName, IsExternal);
                                        DataRow dsemailrows = dtSMS.Rows[0];

                                        string RequestId_no = dsemailrows["RequestId"].ToString();

                                        dtemail = objBussiness.EmailParameter(Flag1, EmailCommunicationType, EmailCommunicationKey, DeclinedEmailProcess, DeclinedEmailTemplateId, hdnEmail.Value.Trim(), MailCC, hdnMobile.Value.Trim(), Mode, CreatedBy, IsAttached, AttachedFiles, ApplicationNo, PolicyNumber, ParameterList, FileName, IsExternal);

                                        for (int i = 0; i < dtemail.Rows.Count; i++)
                                        {
                                            string parameter = dtemail.Rows[i][1].ToString();

                                            string col = dtemail.Rows[i][1].ToString();
                                            switch (parameter)
                                            {

                                                case "<Customer_Name>":
                                                    ParameterList = "'" + RequestId_no + "'" + "," + "'" + dtemail.Rows[i][1].ToString() + "'" + "," + "'" + CustomerName + "'),";
                                                    break;

                                                case "<Policy_Name>":
                                                    ParameterList += "('" + RequestId_no + "'" + "," + "'" + dtemail.Rows[i][1].ToString() + "'" + "," + "'" + PolicyName + "'),";
                                                    break;

                                                case "<Policy_Number>":
                                                    ParameterList += "('" + RequestId_no + "'" + "," + "'" + dtemail.Rows[i][1].ToString() + "'" + "," + "'" + PolicyNumber + "'),";
                                                    break;

                                                case "<Reason1>":
                                                    ParameterList += "('" + RequestId_no + "'" + "," + "'" + dtemail.Rows[i][1].ToString() + "'" + "," + "'" + Reason1 + "'),";
                                                    break;

                                                case "<Reason2>":
                                                    ParameterList += "('" + RequestId_no + "'" + "," + "'" + dtemail.Rows[i][1].ToString() + "'" + "," + "'" + Reason2 + "'),";
                                                    break;

                                                case "<Bank_Name>":
                                                    ParameterList += "('" + RequestId_no + "'" + "," + "'" + dtemail.Rows[i][1].ToString() + "'" + "," + "'" + BankName + "'),";
                                                    break;

                                                case "<Bank_Account_Number>":
                                                    ParameterList += "('" + RequestId_no + "'" + "," + "'" + dtemail.Rows[i][1].ToString() + "'" + "," + "'" + BankAccountNumber + "'";
                                                    break;

                                                default:
                                                    break;
                                            }
                                        }

                                        dtemail = objBussiness.EmailParameter(Flag3, EmailCommunicationType, EmailCommunicationKey, DeclinedEmailProcess, DeclinedEmailTemplateId, hdnEmail.Value.Trim(), MailCC, hdnMobile.Value.Trim(), Mode, CreatedBy, IsAttached, AttachedFiles, ApplicationNo, PolicyNumber, ParameterList, FileName, IsExternal);
                                        Logger.Info(strApplicationno + "RejectedForImage_email_success" + System.Environment.NewLine);
                                    }
                                    catch (Exception ex)
                                    {
                                        Logger.Info(strApplicationno + "RejectedForImage_email_fail" + System.Environment.NewLine);

                                    }

                                }
                            }

                            else if (ddlUWDecesion.SelectedValue == "Postponed")
                            {
                                Logger.Info(strApplicationno + "master post Event Start_Step22_postponedstarts" + System.Environment.NewLine);
                                HiddenField HdnMonthCounts = (HiddenField)ContentPlaceHolder1.FindControl("HdnFinalMonthCount");

                                if (Convert.ToInt64(HdnMonthCounts.Value) > 0)
                                {
                                    Logger.Info("poststart" + "master post Event Start_postponedstarts_s" + System.Environment.NewLine);
                                    int Months = Convert.ToInt32(HdnMonthCounts.Value) - 1;
                                    int postponeMonths = Convert.ToInt32(ddlPostpone.SelectedValue);
                                    int ActuallMonths = Convert.ToInt32(HdnMonthCounts.Value);
                                    StringBuilder sb1 = new StringBuilder();
                                    sb1.Append(Months + "," + postponeMonths + "," + ActuallMonths);
                                    string inputmsg = sb1.ToString();
                                    Logger.Info(inputmsg + "master post Event Start_postponedstarts_1" + System.Environment.NewLine);

                                    if (postponeMonths > Months)
                                    {
                                        ShowPopupMessage("The revival can be allowed for this case up to " + ActuallMonths + " period only.Hence you can postpone this policy up to " + Months + " months maximum.Please change postpone period or revise the UW decision accordingly", 0);
                                        return;
                                    }



                                }
                                else
                                {
                                    ShowPopupMessage("You cannot Postpone this case upto provided " + ddlPostpone.SelectedValue + ",since revival after " + ddlPostpone.SelectedValue + " not allowed. Please review UW decision accordingly", 0);
                                    return;
                                }

                                Logger.Info(strApplicationno + "master post Event Start_Step23" + System.Environment.NewLine);

                                string ReqStatus = string.Empty;
                                GridView GvReq = (GridView)ContentPlaceHolder1.FindControl("gvRequirmentDetails");

                                int counter = 0;

                                foreach (GridViewRow rowfollowup in GvReq.Rows)
                                {

                                    DropDownList ddlStatus = rowfollowup.FindControl("ddlStatus") as DropDownList;

                                    if (ddlStatus.SelectedValue == "O")
                                    {
                                        counter = counter + 1;
                                    }
                                }
                                Logger.Info(strApplicationno + "master post Event Start_Step24" + System.Environment.NewLine);

                                if (counter > 0 && NEWFollowUp == "TRUE")
                                {
                                    Logger.Info(strApplicationno + "master post Event Start_Step25" + System.Environment.NewLine);
                                    DataTable dtSMS = new DataTable();




                                    dtSMS = objBussiness.EmailParameter(Flag2, SMSCommunicationType, SMSCommunicationKey, PostponedSMSProcess, PostponedSMSTemplateID, hdnEmail.Value.Trim(), MailCC, hdnMobile.Value.Trim(), Mode, CreatedBy, IsAttached, AttachedFiles, HdnAppNumber.Value.Trim(), HdnPolicyNumber.Value.Trim(), ParameterList, FileName, IsExternal);
                                    DataRow drSMS = dtSMS.Rows[0];
                                    Logger.Info(strApplicationno + "master post Event Start_Step26" + System.Environment.NewLine);
                                    string RequestId = drSMS["RequestId"].ToString();

                                    dtSMS = objBussiness.EmailParameter(Flag1, SMSCommunicationType, SMSCommunicationKey, PostponedSMSProcess, PostponedSMSTemplateID, hdnEmail.Value.Trim(), MailCC, hdnMobile.Value.Trim(), Mode, CreatedBy, IsAttached, AttachedFiles, HdnAppNumber.Value.Trim(), HdnPolicyNumber.Value.Trim(), ParameterList, FileName, IsExternal);
                                    Logger.Info(strApplicationno + "master post Event Start_Step27" + System.Environment.NewLine);
                                    for (int i = 0; i < dtSMS.Rows.Count; i++)
                                    {
                                        string parameter = dtSMS.Rows[i][1].ToString();

                                        string col = dtSMS.Rows[i][1].ToString();
                                        switch (parameter)
                                        {

                                            case "<proposer name>":



                                                ParameterList = "'" + RequestId + "'" + "," + "'" + dtSMS.Rows[i][1].ToString() + "'" + "," + "'" + hdnLAFullName.Value.Trim() + "'),";

                                                break;

                                            case "<Plan Name>":
                                                ParameterList += "('" + RequestId + "'" + "," + "'" + dtSMS.Rows[i][1].ToString() + "'" + "," + "'" + txtPlanName.Text.Trim() + "'),";
                                                break;

                                            case "<Policy No.>":
                                                ParameterList += "('" + RequestId + "'" + "," + "'" + dtSMS.Rows[i][1].ToString() + "'" + "," + "'" + HdnPolicyNumber.Value.Trim() + "'";
                                                break;



                                            default:
                                                break;
                                        }
                                    }
                                    Logger.Info(strApplicationno + "master post Event Start_Step28" + System.Environment.NewLine);

                                    dtSMS = objBussiness.EmailParameter(Flag3, SMSCommunicationType, SMSCommunicationKey, PostponedSMSProcess, PostponedSMSTemplateID, hdnEmail.Value.Trim(), MailCC, hdnMobile.Value.Trim(), Mode, CreatedBy, IsAttached, AttachedFiles, HdnAppNumber.Value.Trim(), HdnPolicyNumber.Value.Trim(), ParameterList, FileName, IsExternal);
                                    Session["hdnNewFollowup"] = null;
                                    Logger.Info(strApplicationno + "master post Event Start_Step29" + System.Environment.NewLine);
                                }
                            }

                            if (ddlUWDecesion.SelectedValue == "Approved" && LAPushErrorCode == 0)
                            {
                                //objComm.OnlineUWMISDecision_Save(strApplicationno, ddlUWDecesion.SelectedValue, objCommonObj._bpm_branchCode, objChangeObj.userLoginDetails._ProcessName, objChangeObj.userLoginDetails._userBranch,
                                //    objCommonObj._AppType, struserid, objChangeObj.userLoginDetails._UserGroup, "", "", ref UWDecisionResult);



                                //DataSet dsREQ = new DataSet();
                                //objBussiness.CheckOpenRequirement(HdnAppNumber.Value.Trim(), "1",ref dsREQ);
                                //if(dsREQ.Tables[0].Rows.Count == 0 )
                                //{


                                //}
                                //else
                                //{

                                //	ShowPopupMessage("Please close all Requirements", 0);
                                //}

                                //Commented Start by kunal 26-03-2020  Reason - Details to be updated only if status changes in LA
                                //string ReqStatus = string.Empty;
                                //GridView GvReq = (GridView)ContentPlaceHolder1.FindControl("gvRequirmentDetails");


                                //foreach (GridViewRow rowfollowup in GvReq.Rows)
                                //{
                                //	DropDownList ddlStatus = rowfollowup.FindControl("ddlStatus") as DropDownList;

                                //	if (ddlStatus.SelectedValue == "O")
                                //	{
                                //		ShowPopupMessage("Please close all Requirements", 0);
                                //		return;
                                //	}
                                //	else
                                //	{
                                //		//objBuss.OnlineApplicationLAServiceDetails_PUSH(strApplicationno, strUWmode, objChangeObj, ref _ds, ref _dsPrevPol, ddlUWDecesion.SelectedValue, ref LAPushErrorCode, ref strLAPushErrorMsg, ref strConsentResponse);

                                //		//Akshay
                                //		UWSaralServices.FollowupDetails objFollowup = new UWSaralServices.FollowupDetails();
                                //		//CommFun objComm = new CommFun();
                                //		DataSet _dsFollowUp = null;

                                //		objComm.OnlineServiceFollowUPDetails_GET(ref _dsFollowUp, HdnAppNumber.Value.Trim(), "Offline");

                                //		objFollowup.FollowuPushService(HdnAppNumber.Value.Trim(), _dsFollowUp, objChangeObj, ref LAPushErrorCode, ref strLAPushErrorMsg);
                                //	}
                                //}

                                //strAppstatusKey = (strUserGroup == "UW") ? "UC" : "DC";
                                //objComm.OnlineApplicationchangeStatus(strApplicationno, struserid, strAppstatusKey, "", ref Result);
                                ////_strPolicyStatus = "IF";
                                //objBussiness.UpdatePolicyStatus(strApplicationno, "UW", struserid, ref intRetVal);

                                ////To Insert Record in LF_applicationstatus table with '091' status 
                                //objBussiness.InsertAppStatus(strApplicationno, struserid, ref intRetVal);
                                //Commented End by kunal 26-03-2020  Reason - Details to be updated only if status changes in LA

                                //UWSARAL STATUS UPDATE.
                                string STPResult = string.Empty;
                                ReinstSTP.Service1Client objREINSTSTP = new ReinstSTP.Service1Client();

                                string UserID = objCommonObj._Bpmuserdetails._UserID;// struserid.ToString().StartsWith("F") ? struserid.ToString() : "F" + struserid.ToString();
                                STPResult = objREINSTSTP.IsSTPRulesPassORFail(HdnPolicyNumber.Value.Trim(), objCommonObj._Bpmuserdetails._userBranch, objCommonObj._Bpmuserdetails._userBranch, Mode, objCommonObj._Bpmuserdetails._UserRole, CarrierCode, UserID);
                                //objCommonObj._bpm_branchCode

                                if (STPResult == "0")
                                {
                                    //Commented code pasted Start by kunal 26-03-2020  Reason - Details to be updated only if status changes in LA
                                    string ReqStatus = string.Empty;
                                    GridView GvReq = (GridView)ContentPlaceHolder1.FindControl("gvRequirmentDetails");
                                    foreach (GridViewRow rowfollowup in GvReq.Rows)
                                    {
                                        DropDownList ddlStatus = rowfollowup.FindControl("ddlStatus") as DropDownList;

                                        if (ddlStatus.SelectedValue == "O")
                                        {
                                            ShowPopupMessage("Please close all Requirements", 0);
                                            return;
                                        }
                                        else
                                        {

                                            UWSaralServices.FollowupDetails objFollowup = new UWSaralServices.FollowupDetails();

                                            DataSet _dsFollowUp = null;

                                            objComm.OnlineServiceFollowUPDetails_GET(ref _dsFollowUp, HdnAppNumber.Value.Trim(), "Offline");

                                            objFollowup.FollowuPushService(HdnAppNumber.Value.Trim(), _dsFollowUp, objChangeObj, ref LAPushErrorCode, ref strLAPushErrorMsg);
                                        }
                                    }
                                    strAppstatusKey = (strUserGroup == "UW") ? "UC" : "DC";
                                    objComm.OnlineApplicationchangeStatus(strApplicationno, struserid, strAppstatusKey, "", ref Result);

                                    objBussiness.UpdatePolicyStatus(strApplicationno, "UW", struserid, ref intRetVal);


                                    objBussiness.InsertAppStatus(strApplicationno, struserid, ref intRetVal);




                                    Flag = "1";
                                    Status = "UW Approved";
                                    objBussiness.UWSaralUpdate(HdnPolicyNumber.Value.Trim(), struserid, Flag, Status);

                                    objBussiness.UpdateReciptAmt(HdnAppNumber.Value.Trim(), "1");

                                    ShowPopupMessage("Details Post Successfully", 0);
                                    STPResult = "";

                                    //UW ACCEPTS
                                    DataTable dtSMS = new DataTable();





                                    dtSMS = objBussiness.EmailParameter(Flag2, SMSCommunicationType, SMSCommunicationKey, AcceptedSMSProcess, AcceptedSMSTemplateID, hdnEmail.Value.Trim(), MailCC, hdnMobile.Value.Trim(), Mode, CreatedBy, IsAttached, AttachedFiles, HdnAppNumber.Value.Trim(), HdnPolicyNumber.Value.Trim(), ParameterList, FileName, IsExternal);
                                    DataRow drSMS = dtSMS.Rows[0];

                                    string RequestId = drSMS["RequestId"].ToString();

                                    dtSMS = objBussiness.EmailParameter(Flag1, SMSCommunicationType, SMSCommunicationKey, AcceptedSMSProcess, AcceptedSMSTemplateID, hdnEmail.Value.Trim(), MailCC, hdnMobile.Value.Trim(), Mode, CreatedBy, IsAttached, AttachedFiles, HdnAppNumber.Value.Trim(), HdnPolicyNumber.Value.Trim(), ParameterList, FileName, IsExternal);

                                    for (int i = 0; i < dtSMS.Rows.Count; i++)
                                    {
                                        string col = dtSMS.Rows[i][1].ToString();
                                        switch (col)
                                        {

                                            case "<plan name>":
                                                ParameterList = "'" + RequestId + "'" + "," + "'" + dtSMS.Rows[i][1].ToString() + "'" + "," + "'" + txtPlanName.Text.Trim() + "'),";
                                                break;

                                            case "<policy no.>":
                                                ParameterList += "('" + RequestId + "'" + "," + "'" + dtSMS.Rows[i][1].ToString() + "'" + "," + "'" + HdnPolicyNumber.Value.Trim() + "'),";
                                                break;


                                            case "<Proposer Name>":

                                                ParameterList += "('" + RequestId + "'" + "," + "'" + dtSMS.Rows[i][1].ToString() + "'" + "," + "'" + hdnLAFullName.Value.Trim() + "'";

                                                break;

                                            default:
                                                break;
                                        }
                                    }

                                    dtSMS = objBussiness.EmailParameter(Flag3, SMSCommunicationType, SMSCommunicationKey, AcceptedSMSProcess, AcceptedSMSTemplateID, hdnEmail.Value.Trim(), MailCC, hdnMobile.Value.Trim(), Mode, CreatedBy, IsAttached, AttachedFiles, HdnAppNumber.Value.Trim(), HdnPolicyNumber.Value.Trim(), ParameterList, FileName, IsExternal);

                                }
                                else
                                {

                                    ShowPopupMessage("Policy can't reinstate.", 0);
                                    STPResult = "";
                                }






                            }
                            else if (ddlUWDecesion.SelectedValue == "Declined" && LAPushErrorCode == 0)
                            {



                                strAppstatusKey = (strUserGroup == "UW") ? "UC" : "DC";
                                objComm.OnlineApplicationchangeStatus(strApplicationno, struserid, strAppstatusKey, "", ref Result);


                                objBussiness.UpdatePolicyStatus(strApplicationno, "DC", struserid, ref intRetVal);


                                Flag = "1";
                                Status = "UW Rejected";
                                objBussiness.UWSaralUpdate(HdnPolicyNumber.Value.Trim(), struserid, Flag, Status);



                                objBussiness.UpdateReciptAmt(HdnAppNumber.Value.Trim(), "1");



                                ShowPopupMessage("Details Post Successfully", 0);





                                try
                                {
                                    Logger.Info(strApplicationno + "RejectedForImage_sms_start" + System.Environment.NewLine);
                                    DataTable dtSMS = new DataTable();
                                    IsAttached = "0";
                                    AttachedFiles = null;
                                    ApplicationNo = HdnAppNumber.Value.Trim();
                                    PolicyNumber = HdnPolicyNumber.Value.Trim();
                                    Logger.Info(strApplicationno + "RejectedForImage_sms_flag_02" + System.Environment.NewLine);
                                    dtSMS = objBussiness.EmailParameter(Flag2, SMSCommunicationType, SMSCommunicationKey, DeclinedSMSProcess, DeclinedSMSTemplateId, hdnEmail.Value.Trim(), MailCC, hdnMobile.Value.Trim(), Mode, CreatedBy, IsAttached, AttachedFiles, ApplicationNo, PolicyNumber, ParameterList, FileName, IsExternal);
                                    DataRow drSMS = dtSMS.Rows[0];

                                    string RequestId = drSMS["RequestId"].ToString();

                                    dtSMS = objBussiness.EmailParameter(Flag1, SMSCommunicationType, SMSCommunicationKey, DeclinedSMSProcess, DeclinedSMSTemplateId, hdnEmail.Value.Trim(), MailCC, hdnMobile.Value.Trim(), Mode, CreatedBy, IsAttached, AttachedFiles, ApplicationNo, PolicyNumber, ParameterList, FileName, IsExternal);
                                    Logger.Info(strApplicationno + "RejectedForImage_sms_flag_01" + System.Environment.NewLine);

                                    for (int i = 0; i < dtSMS.Rows.Count; i++)
                                    {
                                        string parameter = dtSMS.Rows[i][1].ToString();

                                        string col = dtSMS.Rows[i][1].ToString();
                                        switch (parameter)
                                        {

                                            case "<plan name>":
                                                ParameterList = "'" + RequestId + "'" + "," + "'" + dtSMS.Rows[i][1].ToString() + "'" + "," + "'" + txtPlanName.Text.Trim() + "'),";
                                                break;

                                            case "<policy no.>":
                                                ParameterList += "('" + RequestId + "'" + "," + "'" + dtSMS.Rows[i][1].ToString() + "'" + "," + "'" + HdnPolicyNumber.Value.Trim() + "'),";
                                                break;


                                            case "<Proposer Name>":


                                                ParameterList += "('" + RequestId + "'" + "," + "'" + dtSMS.Rows[i][1].ToString() + "'" + "," + "'" + hdnLAFullName.Value.Trim() + "'";

                                                break;



                                            default:
                                                break;
                                        }
                                    }

                                    Logger.Info(strApplicationno + "RejectedForImage_sms_flag3" + System.Environment.NewLine);
                                    dtSMS = objBussiness.EmailParameter(Flag3, SMSCommunicationType, SMSCommunicationKey, DeclinedSMSProcess, DeclinedSMSTemplateId, hdnEmail.Value.Trim(), MailCC, hdnMobile.Value.Trim(), Mode, CreatedBy, IsAttached, AttachedFiles, ApplicationNo, PolicyNumber, ParameterList, FileName, IsExternal);
                                    Logger.Info(strApplicationno + "RejectedForImage_sms_success" + System.Environment.NewLine);

                                }
                                catch (Exception)
                                {

                                    Logger.Info(strApplicationno + "RejectedForImage_sms_success" + System.Environment.NewLine);
                                }


                                try
                                {
                                    Logger.Info(strApplicationno + "RejectedForImage_email_start" + System.Environment.NewLine);
                                    DataTable dtemail = new DataTable();
                                    DataTable dtSMS = new DataTable();
                                    string CustomerName = hdnLAFullName.Value;

                                    string PolicyName = txtPlanName.Text.Trim();

                                    string Reason1 = ddlUWDecesion.SelectedValue.ToString();
                                    string Reason2 = ddlUWreason.SelectedValue.ToString();
                                    string BankName = string.Empty;
                                    string BankAccountNumber = string.Empty;
                                    IsAttached = "0";
                                    AttachedFiles = null;
                                    ApplicationNo = HdnAppNumber.Value.Trim();
                                    PolicyNumber = HdnPolicyNumber.Value.Trim();
                                    FileName = "Rejected_For_Image.html";
                                    IsExternal = "YES";


                                    dtemail = objBussiness.EmailParameter(Flag2, EmailCommunicationType, EmailCommunicationKey, DeclinedEmailProcess, DeclinedEmailTemplateId, hdnEmail.Value.Trim(), MailCC, hdnMobile.Value.Trim(), Mode, CreatedBy, IsAttached, AttachedFiles, ApplicationNo, PolicyNumber, ParameterList, FileName, IsExternal);
                                    DataRow dsemailrows = dtSMS.Rows[0];

                                    string RequestId_no = dsemailrows["RequestId"].ToString();

                                    dtemail = objBussiness.EmailParameter(Flag1, EmailCommunicationType, EmailCommunicationKey, DeclinedEmailProcess, DeclinedEmailTemplateId, hdnEmail.Value.Trim(), MailCC, hdnMobile.Value.Trim(), Mode, CreatedBy, IsAttached, AttachedFiles, ApplicationNo, PolicyNumber, ParameterList, FileName, IsExternal);

                                    for (int i = 0; i < dtemail.Rows.Count; i++)
                                    {
                                        string parameter = dtemail.Rows[i][1].ToString();

                                        string col = dtemail.Rows[i][1].ToString();
                                        switch (parameter)
                                        {

                                            case "<Customer_Name>":
                                                ParameterList = "'" + RequestId_no + "'" + "," + "'" + dtemail.Rows[i][1].ToString() + "'" + "," + "'" + CustomerName + "'),";
                                                break;

                                            case "<Policy_Name>":
                                                ParameterList += "('" + RequestId_no + "'" + "," + "'" + dtemail.Rows[i][1].ToString() + "'" + "," + "'" + PolicyName + "'),";
                                                break;

                                            case "<Policy_Number>":
                                                ParameterList += "('" + RequestId_no + "'" + "," + "'" + dtemail.Rows[i][1].ToString() + "'" + "," + "'" + PolicyNumber + "'),";
                                                break;

                                            case "<Reason1>":
                                                ParameterList += "('" + RequestId_no + "'" + "," + "'" + dtemail.Rows[i][1].ToString() + "'" + "," + "'" + Reason1 + "'),";
                                                break;

                                            case "<Reason2>":
                                                ParameterList += "('" + RequestId_no + "'" + "," + "'" + dtemail.Rows[i][1].ToString() + "'" + "," + "'" + Reason2 + "'),";
                                                break;

                                            case "<Bank_Name>":
                                                ParameterList += "('" + RequestId_no + "'" + "," + "'" + dtemail.Rows[i][1].ToString() + "'" + "," + "'" + BankName + "'),";
                                                break;

                                            case "<Bank_Account_Number>":
                                                ParameterList += "('" + RequestId_no + "'" + "," + "'" + dtemail.Rows[i][1].ToString() + "'" + "," + "'" + BankAccountNumber + "'";
                                                break;

                                            default:
                                                break;
                                        }
                                    }

                                    dtemail = objBussiness.EmailParameter(Flag3, EmailCommunicationType, EmailCommunicationKey, DeclinedEmailProcess, DeclinedEmailTemplateId, hdnEmail.Value.Trim(), MailCC, hdnMobile.Value.Trim(), Mode, CreatedBy, IsAttached, AttachedFiles, ApplicationNo, PolicyNumber, ParameterList, FileName, IsExternal);
                                    Logger.Info(strApplicationno + "RejectedForImage_email_success" + System.Environment.NewLine);
                                }
                                catch (Exception ex)
                                {
                                    Logger.Info(strApplicationno + "RejectedForImage_email_fail" + System.Environment.NewLine);
                                    throw ex;
                                }


                            }
                            else if (ddlUWDecesion.SelectedValue == "Postponed" && LAPushErrorCode == 0)
                            {
                                Logger.Info(strApplicationno + "master post Event Start_Step30" + System.Environment.NewLine);
                                strAppstatusKey = (strUserGroup == "UW") ? "UC" : "DC";
                                objComm.OnlineApplicationchangeStatus(strApplicationno, struserid, strAppstatusKey, "", ref Result);
                                Logger.Info(strApplicationno + "master post Event Start_Step31" + System.Environment.NewLine);
                                //_strPolicyStatus = "PO";
                                objBussiness.UpdatePolicyStatus(strApplicationno, "PO", struserid, ref intRetVal);
                                Logger.Info(strApplicationno + "master post Event Start_Step32" + System.Environment.NewLine);

                                //UWSARAL STATUS UPDATE.
                                Flag = "1";
                                Status = "UW Hold";
                                objBussiness.UWSaralUpdate(HdnPolicyNumber.Value.Trim(), struserid, Flag, Status);
                                Logger.Info(strApplicationno + "master post Event Start_Step33" + System.Environment.NewLine);

                                //Update RefundAmount in Pos 
                                objBussiness.UpdateReciptAmt(HdnAppNumber.Value.Trim(), "1");
                                Logger.Info(strApplicationno + "master post Event Start_Step34" + System.Environment.NewLine);


                                ShowPopupMessage("Details Post Successfully", 0);
                                Logger.Info(strApplicationno + "master post Event Start_Step35" + System.Environment.NewLine);

                                string RevivalCompletiondate;
                                HiddenField HdnRCD_date = (HiddenField)ContentPlaceHolder1.FindControl("hdnRCDdate");
                                DataTable dt_Revival = objBussiness.revivaldate(HdnPolicyNumber.Value);
                                RevivalCompletiondate = dt_Revival.Rows[0]["REVIVAL_END_DT"].ToString();
                                DateTime date = Convert.ToDateTime(RevivalCompletiondate);
                                try
                                {
                                    Logger.Info(strApplicationno + "Postponed_sms_start" + System.Environment.NewLine);
                                    DataTable dtSMS = new DataTable();




                                    dtSMS = objBussiness.EmailParameter(Flag2, SMSCommunicationType, SMSCommunicationKey, PostponedSMSProcess, PostponedSMSTemplateID, hdnEmail.Value.Trim(), MailCC, hdnMobile.Value.Trim(), Mode, CreatedBy, IsAttached, AttachedFiles, HdnAppNumber.Value.Trim(), HdnPolicyNumber.Value.Trim(), ParameterList, FileName, IsExternal);
                                    DataRow drSMS = dtSMS.Rows[0];
                                    Logger.Info(strApplicationno + "master post Event Start_Step36" + System.Environment.NewLine);
                                    string RequestId = drSMS["RequestId"].ToString();

                                    dtSMS = objBussiness.EmailParameter(Flag1, SMSCommunicationType, SMSCommunicationKey, PostponedSMSProcess, PostponedSMSTemplateID, hdnEmail.Value.Trim(), MailCC, hdnMobile.Value.Trim(), Mode, CreatedBy, IsAttached, AttachedFiles, HdnAppNumber.Value.Trim(), HdnPolicyNumber.Value.Trim(), ParameterList, FileName, IsExternal);
                                    Logger.Info(strApplicationno + "master post Event Start_Step37" + System.Environment.NewLine);
                                    for (int i = 0; i < dtSMS.Rows.Count; i++)
                                    {
                                        string col = dtSMS.Rows[i][1].ToString();
                                        switch (col)
                                        {

                                            case "<plan name>":
                                                ParameterList = "'" + RequestId + "'" + "," + "'" + dtSMS.Rows[i][1].ToString() + "'" + "," + "'" + txtPlanName.Text.Trim() + "'),";
                                                break;

                                            case "<policy no.>":
                                                ParameterList += "('" + RequestId + "'" + "," + "'" + dtSMS.Rows[i][1].ToString() + "'" + "," + "'" + HdnPolicyNumber.Value.Trim() + "'),";
                                                break;


                                            case "<Postpone>":
                                                ParameterList += "('" + RequestId + "'" + "," + "'" + dtSMS.Rows[i][1].ToString() + "'" + "," + "'" + ddlPostpone.SelectedValue + "'),";
                                                break;


                                            case "<Proposer Name>":


                                                ParameterList += "('" + RequestId + "'" + "," + "'" + dtSMS.Rows[i][1].ToString() + "'" + "," + "'" + hdnLAFullName.Value.Trim() + "'),";

                                                break;

                                            case "<date of completion of revival period>":
                                                ParameterList += "('" + RequestId + "'" + "," + "'" + dtSMS.Rows[i][1].ToString() + "'" + "," + "'" + RevivalCompletiondate.ToString().Trim() + "'";
                                                break;


                                            default:
                                                break;
                                        }
                                    }
                                    Logger.Info(strApplicationno + "master post Event Start_Step38" + System.Environment.NewLine);

                                    dtSMS = objBussiness.EmailParameter(Flag3, SMSCommunicationType, SMSCommunicationKey, PostponedSMSProcess, PostponedSMSTemplateID, hdnEmail.Value.Trim(), MailCC, hdnMobile.Value.Trim(), Mode, CreatedBy, IsAttached, AttachedFiles, HdnAppNumber.Value.Trim(), HdnPolicyNumber.Value.Trim(), ParameterList, FileName, IsExternal);
                                    Logger.Info(strApplicationno + "Postponed_sms_success" + System.Environment.NewLine);

                                }
                                catch (Exception ex)
                                {

                                    Logger.Info(strApplicationno + "Postponed_sms_Fail" + ex.Message.ToString() + System.Environment.NewLine);

                                }



                                try
                                {
                                    Logger.Info(strApplicationno + "master post Event Start_Step39" + System.Environment.NewLine);
                                    string RevivalDate = string.Empty;
                                    Logger.Info(strApplicationno + "Postponed_email_start" + System.Environment.NewLine);
                                    DataTable dtemail_PostPone = new DataTable();
                                    HiddenField HdnRCDdate = (HiddenField)ContentPlaceHolder1.FindControl("hdnRCDdate");

                                    DataTable dtdate = objBussiness.revivaldate(HdnPolicyNumber.Value);
                                    RevivalDate = dtdate.Rows[0]["REVIVAL_END_DT"].ToString();
                                    Logger.Info(strApplicationno + "master post Event Start_Step40" + System.Environment.NewLine);

                                    string CustomerName = hdnLAFullName.Value;

                                    string Reason1 = ddlUWDecesion.SelectedValue;
                                    string Reason2 = ddlUWreason.SelectedItem.Text.ToString();
                                    string BankName = hdnbankname.Value;
                                    string BankAccountNumber = hdnbankaccount.Value;
                                    string PostPonedMonth = ddlPostpone.SelectedValue.ToString(); //string.Empty;
                                    string PlanName = txtPlanName.Text.Trim();
                                    string Policy_Number = HdnPolicyNumber.Value;
                                    Logger.Info(strApplicationno + "master post Event Start_Step41" + System.Environment.NewLine);


                                    var last4 = "****" + BankAccountNumber.Substring(BankAccountNumber.Trim().Length - 4, 4) + "";
                                    Logger.Info(strApplicationno + "Postponed_email_data_assigned" + System.Environment.NewLine);





                                    ParameterList = "";
                                    FileName = "PostPoned_Template.html";
                                    IsExternal = "Yes";

                                    Logger.Info(strApplicationno + "master post Event Start_Step41" + System.Environment.NewLine);
                                    dtemail_PostPone = objBussiness.EmailParameter(Flag2, EmailCommunicationType, EmailCommunicationKey, PostponedEmailProcess, PostponedEmailTemplateID, hdnEmail.Value.Trim(), MailCC, hdnMobile.Value.Trim(), Mode, CreatedBy, IsAttached, AttachedFiles, HdnAppNumber.Value.Trim(), HdnPolicyNumber.Value.Trim(), ParameterList, FileName, IsExternal);
                                    DataRow dsemail_Postpone_Rows = dtemail_PostPone.Rows[0];
                                    Logger.Info(strApplicationno + "master post Event Start_Step42" + System.Environment.NewLine);
                                    string RequestId_no = dsemail_Postpone_Rows["RequestId"].ToString();

                                    dtemail_PostPone = objBussiness.EmailParameter(Flag1, EmailCommunicationType, EmailCommunicationKey, PostponedEmailProcess, PostponedEmailTemplateID, hdnEmail.Value.Trim(), MailCC, hdnMobile.Value.Trim(), Mode, CreatedBy, IsAttached, AttachedFiles, HdnAppNumber.Value.Trim(), HdnPolicyNumber.Value.Trim(), ParameterList, FileName, IsExternal);
                                    Logger.Info(strApplicationno + "master post Event Start_Step43" + System.Environment.NewLine);
                                    for (int i = 0; i < dtemail_PostPone.Rows.Count; i++)
                                    {
                                        string parameter = dtemail_PostPone.Rows[i][1].ToString();

                                        string col = dtemail_PostPone.Rows[i][1].ToString();
                                        switch (parameter)
                                        {
                                            case "<Plan_name>":
                                                ParameterList = "'" + RequestId_no + "'" + "," + "'" + dtemail_PostPone.Rows[i][1].ToString() + "'" + "," + "'" + PlanName + "'),";
                                                break;

                                            case "<Policy_Number>":
                                                ParameterList += "('" + RequestId_no + "'" + "," + "'" + dtemail_PostPone.Rows[i][1].ToString() + "'" + "," + "'" + Policy_Number + "'),";
                                                break;

                                            case "<Customer_Name>":
                                                ParameterList += "('" + RequestId_no + "'" + "," + "'" + dtemail_PostPone.Rows[i][1].ToString() + "'" + "," + "'" + CustomerName + "'),";
                                                break;

                                            case "<Reason_1>":
                                                ParameterList += "('" + RequestId_no + "'" + "," + "'" + dtemail_PostPone.Rows[i][1].ToString() + "'" + "," + "'" + Reason1 + "'),";
                                                break;

                                            case "<Reason_2>":
                                                ParameterList += "('" + RequestId_no + "'" + "," + "'" + dtemail_PostPone.Rows[i][1].ToString() + "'" + "," + "'" + Reason2 + "'),";
                                                break;

                                            case "<Bank_Name>":
                                                ParameterList += "('" + RequestId_no + "'" + "," + "'" + dtemail_PostPone.Rows[i][1].ToString() + "'" + "," + "'" + BankName + "'),";
                                                break;

                                            case "<Bank_Account_Number>":
                                                ParameterList += "('" + RequestId_no + "'" + "," + "'" + dtemail_PostPone.Rows[i][1].ToString() + "'" + "," + "'" + last4 + "'),";
                                                break;

                                            case "<Postponed_Month>":
                                                ParameterList += "('" + RequestId_no + "'" + "," + "'" + dtemail_PostPone.Rows[i][1].ToString() + "'" + "," + "'" + PostPonedMonth + "'),";
                                                break;

                                            case "<Revival_Date>":
                                                ParameterList += "('" + RequestId_no + "'" + "," + "'" + dtemail_PostPone.Rows[i][1].ToString() + "'" + "," + "'" + RevivalDate + "'";
                                                break;



                                            default:
                                                break;

                                        }
                                    }
                                    Logger.Info(strApplicationno + "master post Event Start_Step44" + System.Environment.NewLine);

                                    dtemail_PostPone = objBussiness.EmailParameter(Flag3, EmailCommunicationType, EmailCommunicationKey, PostponedEmailProcess, PostponedEmailTemplateID, hdnEmail.Value.Trim(), MailCC, hdnMobile.Value.Trim(), Mode, CreatedBy, IsAttached, AttachedFiles, HdnAppNumber.Value.Trim(), HdnPolicyNumber.Value.Trim(), ParameterList, FileName, IsExternal);
                                    Logger.Info(strApplicationno + "Remark:" + "Email_PostPone_Template_success" + "UW PostPone Mail-Success" + System.Environment.NewLine);
                                }
                                catch (Exception ex)
                                {

                                    Logger.Info(strApplicationno + "Remark:" + "Email_PostPone_Template_fail" + ex.Message.ToString() + "UW PostPone Mail-Failure" + System.Environment.NewLine);
                                }
                            }

                            else if (ddlUWDecesion.SelectedValue == "Withdrawn" && LAPushErrorCode == 0)
                            {
                                strAppstatusKey = (strUserGroup == "UW") ? "UC" : "DC";
                                objComm.OnlineApplicationchangeStatus(strApplicationno, struserid, strAppstatusKey, "", ref Result);
                                //_strPolicyStatus = "WD";
                                objBussiness.UpdatePolicyStatus(strApplicationno, "WD", struserid, ref intRetVal);


                                //UWSARAL STATUS UPDATE.
                                Flag = "1";
                                Status = "UW Withdrawn";
                                objBussiness.UWSaralUpdate(HdnPolicyNumber.Value.Trim(), struserid, Flag, Status);



                                //Update RefundAmount in Pos 
                                objBussiness.UpdateReciptAmt(HdnAppNumber.Value.Trim(), "1");


                                ShowPopupMessage("Details Post Successfully", 0);

                                DataTable dtSMS = new DataTable();
                                string ApplicationNo = HdnAppNumber.Value.Trim();
                                string PolicyNumber = HdnPolicyNumber.Value.Trim();
                                MobileNo = hdnMobile.Value.Trim();


                                dtSMS = objBussiness.EmailParameter(Flag2, SMSCommunicationType, SMSCommunicationKey, DeclinedSMSProcess, DeclinedSMSTemplateId, hdnEmail.Value.Trim(), MailCC, MobileNo, Mode, CreatedBy, IsAttached, AttachedFiles, ApplicationNo, PolicyNumber, ParameterList, FileName, IsExternal);
                                DataRow drSMS = dtSMS.Rows[0];

                                string RequestId = drSMS["RequestId"].ToString();

                                dtSMS = objBussiness.EmailParameter(Flag1, SMSCommunicationType, SMSCommunicationKey, DeclinedSMSProcess, DeclinedSMSTemplateId, hdnEmail.Value.Trim(), MailCC, MobileNo, Mode, CreatedBy, IsAttached, AttachedFiles, ApplicationNo, PolicyNumber, ParameterList, FileName, IsExternal);

                                for (int i = 0; i < dtSMS.Rows.Count; i++)
                                {
                                    string parameter = dtSMS.Rows[i][1].ToString();

                                    string col = dtSMS.Rows[i][1].ToString();
                                    switch (parameter)
                                    {

                                        case "<proposer name>":


                                            ParameterList = "'" + RequestId + "'" + "," + "'" + dtSMS.Rows[i][1].ToString() + "'" + "," + "'" + hdnLAFullName.Value.Trim() + "'),";

                                            break;

                                        case "<Plan Name>":
                                            ParameterList += "('" + RequestId + "'" + "," + "'" + dtSMS.Rows[i][1].ToString() + "'" + "," + "'" + txtPlanName.Text.Trim() + "'),";
                                            break;

                                        case "<Policy No.>":
                                            ParameterList += "('" + RequestId + "'" + "," + "'" + dtSMS.Rows[i][1].ToString() + "'" + "," + "'" + HdnPolicyNumber.Value.Trim() + "'";
                                            break;



                                        default:
                                            break;
                                    }
                                }

                                dtSMS = objBussiness.EmailParameter(Flag3, SMSCommunicationType, SMSCommunicationKey, DeclinedSMSProcess, DeclinedSMSTemplateId, hdnEmail.Value.Trim(), MailCC, MobileNo, Mode, CreatedBy, IsAttached, AttachedFiles, ApplicationNo, PolicyNumber, ParameterList, FileName, IsExternal);

                            }
                            else if (ddlUWDecesion.SelectedValue == "Pending" && LAPushErrorCode == 0)
                            {
                                strAppstatusKey = (strUserGroup == "UW") ? "UC" : "DC";
                                objComm.OnlineApplicationchangeStatus(strApplicationno, struserid, strAppstatusKey, "", ref Result);

                                objBussiness.UpdatePolicyStatus(strApplicationno, "PS", struserid, ref intRetVal);

                                objBuss.OnlineApplicationLAServiceDetails_PUSH(strApplicationno, strUWmode, objChangeObj, ref _ds, ref _dsPrevPol, ddlUWDecesion.SelectedValue, ref LAPushErrorCode, ref strLAPushErrorMsg, ref strConsentResponse);

                                Flag = "1";
                                Status = "UW Pending";
                                objBussiness.UWSaralUpdate(HdnPolicyNumber.Value.Trim(), struserid, Flag, Status);



                                objBussiness.UpdateReciptAmt(HdnAppNumber.Value.Trim(), "1");

                                ShowPopupMessage("Details Post Successfully", 0);

                                DataTable dtSMS = new DataTable();








                                dtSMS = objBussiness.EmailParameter(Flag2, SMSCommunicationType, SMSCommunicationKey, ReqRaisedSMSProcess, ReqRaisedTemplateID, hdnEmail.Value.Trim(), MailCC, hdnMobile.Value.Trim(), Mode, CreatedBy, IsAttached, AttachedFiles, HdnAppNumber.Value.Trim(), HdnPolicyNumber.Value.Trim(), ParameterList, FileName, IsExternal);
                                DataRow drSMS = dtSMS.Rows[0];

                                string RequestId = drSMS["RequestId"].ToString();

                                dtSMS = objBussiness.EmailParameter(Flag1, SMSCommunicationType, SMSCommunicationKey, ReqRaisedSMSProcess, ReqRaisedTemplateID, hdnEmail.Value.Trim(), MailCC, hdnMobile.Value.Trim(), Mode, CreatedBy, IsAttached, AttachedFiles, HdnAppNumber.Value.Trim(), HdnPolicyNumber.Value.Trim(), ParameterList, FileName, IsExternal);

                                for (int i = 0; i < dtSMS.Rows.Count; i++)
                                {
                                    string col = dtSMS.Rows[i][1].ToString();
                                    switch (col)
                                    {

                                        case "<Plan Name>":
                                            ParameterList += "('" + RequestId + "'" + "," + "'" + dtSMS.Rows[i][1].ToString() + "'" + "," + "'" + txtPlanName.Text.Trim() + "'),";
                                            break;

                                        case "<Policy No.>":
                                            ParameterList += "('" + RequestId + "'" + "," + "'" + dtSMS.Rows[i][1].ToString() + "'" + "," + "'" + HdnPolicyNumber.Value.Trim() + "'";
                                            break;


                                        case "<proposer name>":

                                            ParameterList += "'" + RequestId + "'" + "," + "'" + dtSMS.Rows[i][1].ToString() + "'" + "," + "'" + hdnLAFullName.Value.Trim() + "'),";

                                            break;




                                        default:
                                            break;
                                    }
                                }

                                dtSMS = objBussiness.EmailParameter(Flag3, SMSCommunicationType, SMSCommunicationKey, ReqRaisedSMSProcess, ReqRaisedTemplateID, hdnEmail.Value.Trim(), MailCC, hdnMobile.Value.Trim(), Mode, CreatedBy, IsAttached, AttachedFiles, HdnAppNumber.Value.Trim(), HdnPolicyNumber.Value.Trim(), ParameterList, FileName, IsExternal);


                                string CustomerName = hdnLAFullName.Value;

                                string PolicyName = txtPlanName.Text.Trim();

                                //Pending Required 
                                DataTable dtemail = new DataTable();
                                string ReqStatus = string.Empty;
                                GridView GvReq = (GridView)ContentPlaceHolder1.FindControl("gvRequirmentDetails");

                                int counter = 0;
                                string strdesc = string.Empty;

                                bool isMedical = false;
                                StringBuilder strMedical = new StringBuilder();

                                List<string> obj = new List<string>();

                                List<string> obj1 = new List<string>();

                                int counter1 = 0;
                                string MedicalRequiremt = string.Empty;
                                StringBuilder medrequirementraised = new StringBuilder();
                                int medicalcounter = 1;

                                foreach (GridViewRow rowfollowup in GvReq.Rows)
                                {

                                    DropDownList ddlStatus = rowfollowup.FindControl("ddlStatus") as DropDownList;
                                    TextBox ddlDesc = rowfollowup.FindControl("lblfollowupDiscp") as TextBox;
                                    DropDownList ddlCat = rowfollowup.FindControl("ddlCategory") as DropDownList;

                                    if (ddlStatus.SelectedValue == "L")
                                    {

                                        if (ddlCat.SelectedValue == "Non Medical")
                                        {
                                            obj1.Add(ddlDesc.Text.ToString());


                                        }
                                        else
                                        {

                                            isMedical = true;
                                            MedicalRequiremt = ddlDesc.Text.ToString();

                                            medrequirementraised.Append("<br/>" + medicalcounter + ". " + MedicalRequiremt);
                                            medicalcounter++;
                                        }


                                    }


                                }

                                int Count = obj.Count;
                                int MedicalCount = 0;

                                for (int i = 0; i < obj.Count; i++)
                                {
                                    strdesc += string.Join("<br/>", obj[i]);

                                }

                                for (int i = 0; i < obj1.Count; i++)
                                {
                                    MedicalCount++;
                                    strMedical.Append("<br/>" + MedicalCount + ". " + obj1[i]);

                                    ViewState["Records"] = strMedical.ToString();

                                }


                                if (MedicalRequiremt == "")
                                {
                                    MedicalRequiremt = "N/A";
                                }

                                DataTable dtemail_ = new DataTable();

                                string TemplateId = string.Empty;



                                ApplicationNo = HdnAppNumber.Value.Trim();
                                PolicyNumber = HdnPolicyNumber.Value.Trim();
                                ParameterList = "";
                                FileName = "Requirement_Raised_template.html";
                                IsExternal = "YES";

                                if (isMedical == false)
                                {


                                    TemplateId = ReqRaisedEmailTemplateID_NonMedical;
                                    FileName = "RequirementRaised_NonMedical.html";


                                    dtemail = objBussiness.EmailParameter(Flag1, EmailCommunicationType, EmailCommunicationKey, ReqRaisedEmailProcess, TemplateId, hdnEmail.Value.Trim(), MailCC, MobileNo, Mode, CreatedBy, IsAttached, AttachedFiles, ApplicationNo, PolicyNumber, ParameterList, FileName, IsExternal);
                                    DataRow dsemailrows = dtemail.Rows[0];

                                    string RequestId_no = dsemailrows["RequestId"].ToString();
                                    Flag1 = "01";
                                    dtemail = objBussiness.EmailParameter(Flag1, EmailCommunicationType, EmailCommunicationKey, ReqRaisedEmailProcess, TemplateId, hdnEmail.Value.Trim(), MailCC, hdnMobile.Value.Trim(), Mode, CreatedBy, IsAttached, AttachedFiles, ApplicationNo, PolicyNumber, ParameterList, FileName, IsExternal);

                                    for (int i = 0; i < dtemail.Rows.Count; i++)
                                    {

                                        string col = dtemail.Rows[i][1].ToString();
                                        switch (col)
                                        {
                                            case "<Customer_Name>":
                                                ParameterList = "'" + RequestId_no + "'" + "," + "'" + dtemail.Rows[i][1].ToString() + "'" + "," + "'" + CustomerName + "'),";
                                                break;

                                            case "<Policy_Name>":
                                                ParameterList += "('" + RequestId_no + "'" + "," + "'" + dtemail.Rows[i][1].ToString() + "'" + "," + "'" + PolicyName + "'),";
                                                break;

                                            case "<Policy_Number>":
                                                ParameterList += "('" + RequestId_no + "'" + "," + "'" + dtemail.Rows[i][1].ToString() + "'" + "," + "'" + PolicyNumber + "'),";
                                                break;

                                            case "<REQTable>":


                                                ParameterList += "('" + RequestId_no + "'" + "," + "'" + dtemail.Rows[i][1].ToString() + "'" + "," + "'" + strMedical.ToString() + "'";
                                                break;


                                            default:
                                                break;
                                        }
                                    }
                                }
                                else
                                {

                                    TemplateId = ReqRaisedEmailTemplateID;
                                    FileName = "Requirement_Raised_template.html";

                                    dtemail = objBussiness.EmailParameter(Flag1, EmailCommunicationType, EmailCommunicationKey, ReqRaisedEmailProcess, TemplateId, hdnEmail.Value.Trim(), MailCC, hdnMobile.Value.Trim(), Mode, CreatedBy, IsAttached, AttachedFiles, ApplicationNo, PolicyNumber, ParameterList, FileName, IsExternal);
                                    DataRow dsemailrows = dtemail.Rows[0];

                                    string RequestId_no = dsemailrows["RequestId"].ToString();
                                    Flag1 = "01";
                                    dtemail = objBussiness.EmailParameter(Flag1, EmailCommunicationType, EmailCommunicationKey, ReqRaisedEmailProcess, TemplateId, hdnEmail.Value.Trim(), MailCC, hdnMobile.Value.Trim(), Mode, CreatedBy, IsAttached, AttachedFiles, ApplicationNo, PolicyNumber, ParameterList, FileName, IsExternal);

                                    for (int i = 0; i < dtemail.Rows.Count; i++)
                                    {

                                        string col = dtemail.Rows[i][1].ToString();
                                        switch (col)
                                        {
                                            case "<Customer_Name>":
                                                ParameterList = "'" + RequestId_no + "'" + "," + "'" + dtemail.Rows[i][1].ToString() + "'" + "," + "'" + CustomerName + "'),";
                                                break;

                                            case "<Policy_Name>":
                                                ParameterList += "('" + RequestId_no + "'" + "," + "'" + dtemail.Rows[i][1].ToString() + "'" + "," + "'" + PolicyName + "'),";
                                                break;

                                            case "<Policy_Number>":
                                                ParameterList += "('" + RequestId_no + "'" + "," + "'" + dtemail.Rows[i][1].ToString() + "'" + "," + "'" + PolicyNumber + "'),";
                                                break;

                                            case "<REQTable>":


                                                ParameterList += "('" + RequestId_no + "'" + "," + "'" + dtemail.Rows[i][1].ToString() + "'" + "," + "'" + strMedical.ToString() + "'),";
                                                break;

                                            case "<REQMedical>":

                                                ParameterList += "('" + RequestId_no + "'" + "," + "'" + dtemail.Rows[i][1].ToString() + "'" + "," + "'" + medrequirementraised.ToString() + "'";

                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                }


                                dtemail = objBussiness.EmailParameter(Flag3, EmailCommunicationType, EmailCommunicationKey, ReqRaisedEmailProcess, TemplateId, hdnEmail.Value.Trim(), MailCC, hdnMobile.Value.Trim(), Mode, CreatedBy, IsAttached, AttachedFiles, ApplicationNo, PolicyNumber, ParameterList, FileName, IsExternal);

                            }
                            //############################################# 1.6 End of Changes CR 26273;Akshada ######################################################################################    
                        }
                        else
                        {
                            if (ddlUWDecesion.SelectedValue == "Approved" && LAPushErrorCode == 0)
                            {


                                strAppstatusKey = (strUserGroup == "UW") ? "UC" : "DC";
                                objComm.OnlineApplicationchangeStatus(strApplicationno, struserid, strAppstatusKey, "", ref Result);

                                objBussiness.UpdatePolicyStatus(strApplicationno, "UW", struserid, ref intRetVal);


                                objBussiness.InsertAppStatus(strApplicationno, struserid, ref intRetVal);




                            }
                            else if (ddlUWDecesion.SelectedValue == "Declined" && LAPushErrorCode == 0)
                            {

                                //objComm.OnlineUWMISDecision_Save(strApplicationno, ddlUWDecesion.SelectedValue, objCommonObj._bpm_branchCode, objChangeObj.userLoginDetails._ProcessName, objChangeObj.userLoginDetails._userBranch,
                                //    objCommonObj._AppType, struserid, objChangeObj.userLoginDetails._UserGroup, ddlUWreason.SelectedValue, ddlUWreason.SelectedItem.Text, ref UWDecisionResult);
                                strAppstatusKey = (strUserGroup == "UW") ? "UC" : "DC";
                                objComm.OnlineApplicationchangeStatus(strApplicationno, struserid, strAppstatusKey, "", ref Result);

                                //_strPolicyStatus = "DC";
                                objBussiness.UpdatePolicyStatus(strApplicationno, "DC", struserid, ref intRetVal);

                            }
                            else if (ddlUWDecesion.SelectedValue == "Postponed" && LAPushErrorCode == 0)
                            {
                                strAppstatusKey = (strUserGroup == "UW") ? "UC" : "DC";
                                objComm.OnlineApplicationchangeStatus(strApplicationno, struserid, strAppstatusKey, "", ref Result);
                                //_strPolicyStatus = "PO";
                                objBussiness.UpdatePolicyStatus(strApplicationno, "PO", struserid, ref intRetVal);
                            }
                            else if (ddlUWDecesion.SelectedValue == "Withdrawn" && LAPushErrorCode == 0)
                            {
                                strAppstatusKey = (strUserGroup == "UW") ? "UC" : "DC";
                                objComm.OnlineApplicationchangeStatus(strApplicationno, struserid, strAppstatusKey, "", ref Result);
                                //_strPolicyStatus = "WD";
                                objBussiness.UpdatePolicyStatus(strApplicationno, "WD", struserid, ref intRetVal);
                            }
                            else if (ddlUWDecesion.SelectedValue == "proposal" && LAPushErrorCode == 0)
                            {
                                strAppstatusKey = (strUserGroup == "UW") ? "UC" : "DC";
                                //objComm.OnlineApplicationchangeStatus(strApplicationno, struserid, strAppstatusKey, "", ref Result);
                                //_strPolicyStatus = "WD";
                                /************************2.2 Begin of Changes by Akshada; CR-28153****************************************/
                                /***Comments: Used to Check Consent FollowUpCode Raised or not ****/
                                if (isConsentReq)
                                {
                                    try
                                    {
                                        objComm.OnlineRequirmentDisplayDetails_GET(ref dsreqdetails, strApplicationno, strChannelType);
                                        if (dsreqdetails.Tables[0].Rows.Count > 0)
                                        {

                                            int ConsentReqtRaisedCount = dsreqdetails.Tables[0].AsEnumerable()
                                                         .Where(r => r.Field<string>("REQ_followUpCode") == ConfigurationManager.AppSettings["ConsentFollowUpSIS"].ToString() && r.Field<string>("REQ_status") != ConfigurationManager.AppSettings["ConsentFollowUpStatus"].ToString()
                                                               || r.Field<string>("REQ_followUpCode") == ConfigurationManager.AppSettings["ConsentFollowUpCNE"].ToString() && r.Field<string>("REQ_status") != ConfigurationManager.AppSettings["ConsentFollowUpStatus"].ToString()
                                                               || r.Field<string>("REQ_followUpCode") == ConfigurationManager.AppSettings["ConsentFollowUpCME"].ToString() && r.Field<string>("REQ_status") != ConfigurationManager.AppSettings["ConsentFollowUpStatus"].ToString()
                                                               || r.Field<string>("REQ_followUpCode") == ConfigurationManager.AppSettings["ConsentFollowUpCOP"].ToString() && r.Field<string>("REQ_status") != ConfigurationManager.AppSettings["ConsentFollowUpStatus"].ToString()
                                                               || r.Field<string>("REQ_followUpCode") == ConfigurationManager.AppSettings["ConsentFollowUpCOL"].ToString() && r.Field<string>("REQ_status") != ConfigurationManager.AppSettings["ConsentFollowUpStatus"].ToString()
                                                               ).Count();
                                            ViewState["dtrequirements"] = dsreqdetails.Tables[0];
                                            if (ConsentReqtRaisedCount > 0)
                                            {
                                                ConsentLetter(strApplicationno, strChannelType);
                                            }
                                            else
                                            {
                                                Logger.Info(strApplicationno + "Consent FollowUpCode Not Raised" + System.Environment.NewLine);
                                            }

                                        }

                                    }
                                    catch (Exception ex)
                                    {

                                        Logger.Info(strApplicationno + "ConsentLetterFailure" + " " + ex.Message.ToString() + System.Environment.NewLine);
                                    }


                                }
                                else
                                {
                                    Logger.Info(strApplicationno + "ConsentFollowUpNotRaised" + " " + isConsentReq + System.Environment.NewLine);
                                }

                                /************************2.2 End of Changes by Akshada; CR-28153****************************************/
                                objBussiness.UpdatePolicyStatus(strApplicationno, "PS", struserid, ref intRetVal);
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                        Logger.Info(strApplicationno + ex.Message.ToString() + System.Environment.NewLine);
                    }
                }
                else
                {
                    ShowPopupMessage("Details Post Successfully", 1);

                    //lblErrorDecisiondtls.Text = "Decision Details Updated in Life Asia successfully";
                    if (ddlUWDecesion.SelectedValue == "Approved" && LAPushErrorCode == 0)
                    {
                        //objComm.OnlineUWMISDecision_Save(strApplicationno, ddlUWDecesion.SelectedValue, objCommonObj._bpm_branchCode, objChangeObj.userLoginDetails._ProcessName, objChangeObj.userLoginDetails._userBranch,
                        //    objCommonObj._AppType, struserid, objChangeObj.userLoginDetails._UserGroup, "", "", ref UWDecisionResult);
                        strAppstatusKey = (strUserGroup == "UW") ? "UC" : "DC";
                        objComm.OnlineApplicationchangeStatus(strApplicationno, struserid, strAppstatusKey, "", ref Result);
                        //_strPolicyStatus = "IF";
                        objBussiness.UpdatePolicyStatus(strApplicationno, "UW", struserid, ref intRetVal);

                        //To Insert Record in LF_applicationstatus table with '091' status 
                        objBussiness.InsertAppStatus(strApplicationno, struserid, ref intRetVal);
                    }
                    else if (ddlUWDecesion.SelectedValue == "Declined" && LAPushErrorCode == 0)
                    {

                        //objComm.OnlineUWMISDecision_Save(strApplicationno, ddlUWDecesion.SelectedValue, objCommonObj._bpm_branchCode, objChangeObj.userLoginDetails._ProcessName, objChangeObj.userLoginDetails._userBranch,
                        //    objCommonObj._AppType, struserid, objChangeObj.userLoginDetails._UserGroup, ddlUWreason.SelectedValue, ddlUWreason.SelectedItem.Text, ref UWDecisionResult);
                        strAppstatusKey = (strUserGroup == "UW") ? "UC" : "DC";
                        objComm.OnlineApplicationchangeStatus(strApplicationno, struserid, strAppstatusKey, "", ref Result);

                        //_strPolicyStatus = "DC";
                        objBussiness.UpdatePolicyStatus(strApplicationno, "DC", struserid, ref intRetVal);


                    }
                    else if (ddlUWDecesion.SelectedValue == "Postponed" && LAPushErrorCode == 0)
                    {
                        strAppstatusKey = (strUserGroup == "UW") ? "UC" : "DC";
                        objComm.OnlineApplicationchangeStatus(strApplicationno, struserid, strAppstatusKey, "", ref Result);
                        //_strPolicyStatus = "PO";
                        objBussiness.UpdatePolicyStatus(strApplicationno, "PO", struserid, ref intRetVal);
                    }
                    else if (ddlUWDecesion.SelectedValue == "Withdrawn" && LAPushErrorCode == 0)
                    {
                        strAppstatusKey = (strUserGroup == "UW") ? "UC" : "DC";
                        objComm.OnlineApplicationchangeStatus(strApplicationno, struserid, strAppstatusKey, "", ref Result);
                        //_strPolicyStatus = "WD";
                        objBussiness.UpdatePolicyStatus(strApplicationno, "WD", struserid, ref intRetVal);
                    }
                    else if (ddlUWDecesion.SelectedValue == "proposal" && LAPushErrorCode == 0)
                    {
                        strAppstatusKey = (strUserGroup == "UW") ? "UC" : "DC";
                        /************************2.2 Begin of Changes by Akshada; CR-28153****************************************/
                        /***Comments: Used to Check Consent FollowUpCode Raised or not ****/
                        try
                        {
                            objComm.OnlineRequirmentDisplayDetails_GET(ref dsreqdetails, strApplicationno, strChannelType);
                            if (dsreqdetails.Tables[0].Rows.Count > 0)
                            {
                                DataTable dtrequirements = dsreqdetails.Tables[0].AsEnumerable()
                                             .Where(r => r.Field<string>("REQ_followUpCode") == ConfigurationManager.AppSettings["ConsentFollowUpSIS"].ToString() && r.Field<string>("REQ_status") != ConfigurationManager.AppSettings["ConsentFollowUpStatus"].ToString()
                                                               || r.Field<string>("REQ_followUpCode") == ConfigurationManager.AppSettings["ConsentFollowUpCNE"].ToString() && r.Field<string>("REQ_status") != ConfigurationManager.AppSettings["ConsentFollowUpStatus"].ToString()
                                                               || r.Field<string>("REQ_followUpCode") == ConfigurationManager.AppSettings["ConsentFollowUpCME"].ToString() && r.Field<string>("REQ_status") != ConfigurationManager.AppSettings["ConsentFollowUpStatus"].ToString()
                                                               || r.Field<string>("REQ_followUpCode") == ConfigurationManager.AppSettings["ConsentFollowUpCOP"].ToString() && r.Field<string>("REQ_status") != ConfigurationManager.AppSettings["ConsentFollowUpStatus"].ToString()
                                                               || r.Field<string>("REQ_followUpCode") == ConfigurationManager.AppSettings["ConsentFollowUpCOL"].ToString() && r.Field<string>("REQ_status") != ConfigurationManager.AppSettings["ConsentFollowUpStatus"].ToString()
                                                               ).CopyToDataTable();

                                ViewState["dtrequirements"] = dtrequirements;
                                TextBox txtSumassure = (TextBox)ContentPlaceHolder1.FindControl("txtSumassure");
                                HiddenField hdfSumassure = (HiddenField)ContentPlaceHolder1.FindControl("hdfSumassure");
                                HiddenField hfdCalPremSA = (HiddenField)ContentPlaceHolder1.FindControl("hfdCalPremSA");
                                HiddenField hfdCalPremFlag = (HiddenField)ContentPlaceHolder1.FindControl("hfdCalPremFlag");


                                if (txtSumassure.Text.Trim() != hdfSumassure.Value.Trim() && txtSumassure.Text.Trim() == hfdCalPremSA.Value.Trim() && hfdCalPremFlag.Value == "0")
                                {
                                    ShowPopupMessage("Please Click on Calculate Premium", 0);
                                    Logger.Info(strApplicationno + "Not Clicked on Premium calculation" + System.Environment.NewLine);
                                    return;
                                }
                                else
                                {
                                    Logger.Info(strApplicationno + "ConsentLetter_Invoked" + System.Environment.NewLine);
                                    ConsentLetter(strApplicationno, strChannelType);

                                }
                            }
                            else
                            {
                                Logger.Info(strApplicationno + "Consent FollowUpCode Not Raised" + System.Environment.NewLine);
                            }
                        }
                        catch (Exception ex)
                        {

                            Logger.Info(strApplicationno + "ConsentLetter_failure" + " " + ex.Message.ToString() + System.Environment.NewLine);
                        }

                        /************************2.2 End of Changes by Akshada; CR-28153****************************************/

                        //objComm.OnlineApplicationchangeStatus(strApplicationno, struserid, strAppstatusKey, "", ref Result);
                        //_strPolicyStatus = "WD";
                        objBussiness.UpdatePolicyStatus(strApplicationno, "PS", struserid, ref intRetVal);
                    }
                }
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Details Post Successfully')", true);

                //Session.Abandon();
                /*added by shri on 06-07-17 to close page on success*/
                //Page.ClientScript.RegisterStartupScript(Page.GetType(), "show success message", "alert('Decision details save successfully');window.close();", true);
                /*end here*/
            }
            else
            {
                ShowPopupMessage(strLAPushErrorMsg, 0);
                /*commented and added by shri on 06-07-17 to close page on success*/
                //lblErrorDecisiondtls.Text = "Decision Details Not Updated in Life Asia,Please Contact system admin";
                //lblErrorDecisiondtls.Focus();
                //Page.ClientScript.RegisterStartupScript(Page.GetType(), "show failure message", "alert("+strLAPushErrorMsg+");", true);
                //Page.ClientScript.RegisterStartupScript(Page.GetType(), "show failure message", "alert('Decision Details Not Updated in Life Asia due to " + strLAPushErrorMsg+ ");", true);
                /*end here*/
            }
        }
        else
        {
            /*commented and added by shri on 06-07-17 to close page on success*/
            //lblErrorDecisiondtls.Text = "Decision details Not Save ,Please Contact system admin";
            //lblErrorDecisiondtls.Focus();
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "show failure message", "alert('Decision details Not Save ,Please Contact system admin');", true);
            /*end here*/
        }
    }
    //end
    //added by suraj for combi product
    private void ContentProductDetails_Combi(MasterPageComparision objMasterPageComparision, string PolNum)
    {
        List<ProductSection> lstProductSection = new List<ProductSection>();
        string strComboMonthlyPayout = string.Empty;
        string strProdMonthlyPayout = string.Empty;
        ProductSection objProductSectionBase = new ProductSection();
        ProductSection objProductSectionCombo = new ProductSection();
        Repeater rptproductlist = (Repeater)ContentPlaceHolder1.FindControl("rptproductlist");
        foreach (RepeaterItem item in rptproductlist.Items)
        {
            TextBox txtBasepolno = (TextBox)item.FindControl("txtBasepolno");
            if (txtBasepolno.Text == PolNum)
            {


                TextBox txtPolterm = (TextBox)item.FindControl("txtPolterm");
                TextBox txtSumassure = (TextBox)item.FindControl("txtSumassure");
                TextBox txtProdcode = (TextBox)item.FindControl("txtProdcode");
                TextBox txtPrepayterm = (TextBox)item.FindControl("txtPrepayterm");
                DropDownList ddlFrequency = (DropDownList)item.FindControl("ddlFrequency");

                objProductSectionBase.PolicyTerm = txtPolterm.Text;
                objProductSectionBase.PremiumFreq = ddlFrequency.SelectedValue;
                objProductSectionBase.SumAssured = txtSumassure.Text;
                objProductSectionBase.ProductCode = txtProdcode.Text;
                objProductSectionBase.PremiumTerm = txtPrepayterm.Text;
                lstProductSection.Add(objProductSectionBase);
            }
        }


        objMasterPageComparision.LstProductSection = lstProductSection;
    }
}