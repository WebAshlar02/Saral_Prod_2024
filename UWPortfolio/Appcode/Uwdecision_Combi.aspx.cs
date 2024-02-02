using Platform.Utilities.LoggerFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Text;
using System.Web;
using System.Web.Caching;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Serialization;
using UWSaralObjects;
using System.IO.Compression;
using System.Globalization;
using System.Web.UI.HtmlControls;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

/*
*********************************************************************************************************************************
COMMENT ID: 1
COMMENTOR NAME :AMIT CHAUDHARY
METHODE/EVENT:PAGE LOAD
REMARK: COMMENTED AML PART FROM PAGE LOAD AS THERE IS NO NEED TO POPULATE THE SAME AS WE ARE DISPALY ON PENDING COUNT AND SAME 
WAS FETCH AND POPULATED ON PENDING CLICKS.
DateTime :03NOV2017
**********************************************************************************************************************************
*********************************************************************************************************************************
COMMENT ID: 2
COMMENTOR NAME :AMIT CHAUDHARY
METHODE/EVENT:PAGE LOAD
REMARK: COMMENTED NSAP LOADING ON PAGE LOAD . SAME ARE NEED TO BE INSERT IN LIFE ASIA AT THE TIME OF DOCQC.AND SAME WAS INSERTED IN 
LF_LOADINGDETAILS.
DateTime :03NOV2017       
*********************************************************************************************************************************
**********************************************************************************************************************************
COMMENT ID: 3
COMMENTOR NAME :SHRIJEET SHANIL
METHODE/EVENT:PAGE LOAD
REMARK: ADDED AUTO COMMENT FEATURE IN EXISTING SARAL
DateTime :09JAN17
*********************************************************************************************************************************
***********************************************************************************************************************************
COMMENT ID: 4
COMMENTOR NAME :SHRIJEET SHANIL
METHODE/EVENT:
REMARK: MANAGE CONTROLS FOR ONLINE / OFFLINE
DateTime :12JAN17
*********************************************************************************************************************************
***********************************************************************************************************************************
COMMENT ID: 5
COMMENTOR NAME :SHRIJEET SHANIL
METHODE/EVENT:
REMARK: IS PAN AND AADHAR VERIFIED
DateTime :12JAN17
*********************************************************************************************************************************
 ************************************************************************************************************************************
COMMENT ID: 6
COMMENTOR NAME :SHRIJEET SHANIL
METHODE/EVENT:
REMARK: TO CHECH AND SAVE COMMENT BEFORE POSTING SAVE IS SMOKER FLAG AND FORCEFUL AADHAR VERIFICATION
DateTime :22JAN17
*********************************************************************************************************************************
*************************************************************************************************************************************
COMMENT ID: 7
COMMENTOR NAME :SHRIJEET SHANIL
METHODE/EVENT:
REMARK: TO ADD ISNSAP EVENT CODE INTO A METHOD AND CALL IT IN CALL BACK and do same for user refernce
DateTime :22FEB18
*********************************************************************************************************************************
*************************************************************************************************************************************
COMMENT ID: 8
COMMENTOR NAME :SHRIJEET SHANIL
METHODE/EVENT:
REMARK: TO ADD BRANCH BASE PREMIUM IN PRODUCT CODE AND SHOW ALERT MESSAGE
DateTime :28FEB18
*********************************************************************************************************************************
**************************************************************************************************************************************
COMMENT ID: 9
COMMENTOR NAME :SHRIJEET SHANIL
METHODE/EVENT:
REMARK: TO ADD AND SHOW TPA STATUS IN SARAL 
DateTime :14MAR18
*********************************************************************************************************************************
**************************************************************************************************************************************
COMMENT ID: 10
COMMENTOR NAME :SHRIJEET SHANIL
METHODE/EVENT:
REMARK: TO ADD AND SHOW RISK DECISION TYPE PROPOSER TYPE 
DateTime :26MAR18
*********************************************************************************************************************************
**************************************************************************************************************************************
COMMENT ID: 11
COMMENTOR NAME :SHRIJEET SHANIL
METHODE/EVENT:
REMARK: TO ADD AND UW INSTRUCTIONS
DateTime :30MAR18
*********************************************************************************************************************************
 ***********************************************************************************************************************************
COMMENT ID: 12
COMMENTOR NAME :Suraj Bhamre
METHODE/EVENT:btnSaveAnswer_Click
REMARK: Save answer for close file review
DateTime :24 APRIL 2018
*********************************************************************************************************************************
**********************************************************************************************************************************
COMMENT ID: 13
COMMENTOR NAME :Suraj Bhamre
METHODE/EVENT:BindQuestion_CloseFile
REMARK: Bind questions for close file review
DateTime :24 APRIL 2018
*********************************************************************************************************************************
**********************************************************************************************************************************
COMMENT ID: 14
COMMENTOR NAME :Suraj Bhamre
METHODE/EVENT:grdclosefilerw_RowDataBound
REMARK: bind values to answer dropdown in question gridview for close file review 
DateTime :24 APRIL 2018
*********************************************************************************************************************************
**********************************************************************************************************************************
COMMENT ID: 15
COMMENTOR NAME :Suraj Bhamre
METHODE/EVENT:DisableControl_CloseFileReview()
REMARK: disabled all control except Closefile review section for close file review
DateTime :24 APRIL 2018
*********************************************************************************************************************************
*********************************************************************************************************************************
COMMENT ID: 16
COMMENTOR NAME :SHRIJEET SHANIL
METHODE/EVENT:
REMARK: TO ADD HOLD POLICY PRINTING FLAG
DateTime :07May18
*********************************************************************************************************************************
*********************************************************************************************************************************
COMMENT ID: 17
COMMENTOR NAME :SURAJ BHAMRE
METHODE/EVENT:ddlApplicationDetailsProposalType_SelectedIndexChanged
REMARK: WHEN PROPOSAL DROPDOWN SELECTED TO EMPLOYER THEN ONLY ASSIGNMENT DROPDOWN WILL SHOW
        WHEN PROPOSAL DROPDOWN SELECTED TO NRI THEN ONLY COUNTRY DROPDOWN WILL SHOW 
DateTime :30MAR18
*********************************************************************************************************************************
**********************************************************************************************************************************
COMMENT ID: 18
COMMENTOR NAME : AJAY SAHU
METHODE/EVENT:ddlApplicationDetailsProposalType_SelectedIndexChanged
REMARK: Unchecked edit 
DateTime :15MAY18
*********************************************************************************************************************************
***********************************************************************************************************************************
COMMENT ID: 19
COMMENTOR NAME : SURAJ BHAMRE
METHODE/EVENT:
REMARK: SHOW WARNING MESSAGE FOR RISPECTIVE CONDITIONS
DateTime :16MAY18
*********************************************************************************************************************************
************************************************************************************************************************************
COMMENT ID: 20
COMMENTOR NAME : SHREEJIT
METHODE/EVENT:
REMARK: 
DateTime :24MAY18
*********************************************************************************************************************************
************************************************************************************************************************************
COMMENT ID: 21
COMMENTOR NAME : SHREEJIT
METHODE/EVENT:
REMARK: DEVELOPMEMT OF E&Y SHOWING 
DateTime :28MAY18
*********************************************************************************************************************************
 **********************************************************************************************************************************
COMMENT ID:22
COMMENTOR NAME : AJAY SAHU
METHODE/EVENT:
REMARK: CHECK RIDER
DateTime :11JUNE18
*********************************************************************************************************************************
 **********************************************************************************************************************************
COMMENT ID:23
COMMENTOR NAME : SHRIJEET SHANIL
METHODE/EVENT:
REMARK: CALL CONTRACT MODIFICATION ON POST BACK REFER 
DateTime :5JULY18
*********************************************************************************************************************************
* ***********************************************************************************************************************************
COMMENT ID:24
COMMENTOR NAME : AJAY SAHU
METHODE/EVENT:
REMARK: PLVC Video
DateTime :14Feb19
*********************************************************************************************************************************
* ***********************************************************************************************************************************
COMMENT ID:25
COMMENTOR NAME : shrijeet shanil
METHODE/EVENT:
REMARK: change E&Y value 
DateTime :30Mar19
*********************************************************************************************************************************
************************************************************************************************************************************
COMMENT ID:26
COMMENTOR NAME : SURAJ BHAMRE
METHODE/EVENT:
REMARK: DISPLAY APPLICATION WISE WARNING MESSAGE
DateTime :14May19
*********************************************************************************************************************************
************************************************************************************************************************************
COMMENT ID:27
COMMENTOR NAME : SURAJ BHAMRE
METHODE/EVENT:
REMARK: Display Medical Data Entry Button
DateTime :02June19
*********************************************************************************************************************************
************************************************************************************************************************************
COMMENT ID:27
COMMENTOR NAME : Shweta Mamilwar  
METHODE/EVENT:
REMARK: CR- 27039 - IIB Query  data extraction from QUEST Portal
DateTime :29May2020
*********************************************************************************************************************************
//*********************************************************************    	
//*                      FUTURE GENERALI INDIA                        *   	
//**********************************************************************/
//*                  I N F O R M A T I O N                                      	
//*********************************************************************	
// Sr. No.              : 29	
// Company              : Life           	
// Module               : UW Saral       	
// Program Author       : Akshada N Wagh         	
// BRD/CR/Codesk No/Win : /28153 / /           	
// Date Of Creation     : 02-09-2020     	
// Description          : 1.Hidden Fields hdfSumassure,hfdCalPremFlag and  hfdCalPremSA  are added For Consent Letter.	
//*********************************************************************
//*************************************************************************************************************************************
//COMMENT ID:32
//COMMENTOR NAME : Brijesh Pandey[MFL00464]
//REMARK: CR - 30461- NB Data for risk scoring Model
//DateTime :07/07/2021
//*********************************************************************************************************************************
//******************************************************************************************************************************* 
// Sr. No.              : 33
// Company              : Life            
// Module               : UW Saral         
// Program Author       : Suraj Bhamre           
// BRD/CR/Codesk No/Win : ///30450    
// Date Of Creation     : 29-06-2021            
// Description          : Add business exception readio button and agent vintage logic
//*********************************************************************************************************************************/
//*******************************************************************************************************************************
//*                      FUTURE GENERALI INDIA                        *    
//*******************************************************************************************************************************      
//*                  I N F O R M A T I O N                                       
//******************************************************************************************************************************* 
// Sr. No.              : 28
// Company              : Life            
// Module               : UW Saral         
// Program Author       : Brijesh Pandey              
// BRD/CR/Codesk No/Win : ///29084    
// Date Of Creation     : 08-06-2021.03.2020            
// Description          : Add Relation with Staff field against Is Staff flag 
//*********************************************************************************************************************************
//******************************************************************************************************************************* 
// Sr. No.              : 34
// Company              : Life            
// Module               : UW Saral         
// Program Author       : Pooja Shetye          
// BRD/CR/Codesk No/Win : CR - 29431    
// Date Of Creation     : 27-08-2021            
// Description          : PAN and FORM 60 Flagging validation 
//*********************************************************************************************************************************/
//******************************************************************************************************************************* 
// Sr. No.              : 35
// Company              : Life            
// Module               : UW Saral         
// Program Author       : Sushant Devkate        
// BRD/CR/Codesk No/Win : CR -2639    
// Date Of Creation     : 20-06-2022            
// Description          : Checked the FSAR limit with UW user limit
//*********************************************************************************************************************************/
//******************************************************************************************************************************* 
// Sr. No.              : 36
// Company              : Life            
// Module               : UW Saral         
// Program Author       : Suraj Bhamre
// BRD/CR/Codesk No/Win : New product Launch LTIP E97,E98     
// Date Of Creation     : 08-07-2022            
// Description          : New product Launch LTIP E97,E98     
//*********************************************************************************************************************************/
//******************************************************************************************************************************* 
// Sr. No.              : 37
// Company              : Life            
// Module               : UW Saral         
// Program Author       : Sagar Thorave       
// BRD/CR/Codesk No/Win : CR -2593   
// Date Of Creation     : 20-07-2022            
// Description          : FC_Video Mer V1 3
//*********************************************************************************************************************************/
///*********************************************************************************************************************************/
// Sr. No.              : 38
// Company              : Life            
// Module               : UW Saral         
// Program Author       : Sushant Devkate - MFL00905
// BRD/CR/Codesk No/Win :  CR-2809
// Date Of Creation     : 03/08/2022
// Description          : Seperate IIB Query for LA ,Proposal and Payer
//*********************************************************************************************************************************/
//******************************************************************************************************************************* 
// Sr. No.              : 39
// Company              : Life            
// Module               : UW Saral         
// Program Author       : Sagar Thorave            
// BRD/CR/Codesk No/Win : CR-3387  
// Date Of Creation     : 16-08-2022            
// Description          : AML risk categorisation in Life Asia
//******************************************************************************************************************************* 
//******************************************************************************************************************************* 
// Sr. No.              : 40
// Company              : Life            
// Module               : UW Saral         
// Program Author       : Sagar Thorave            
// BRD/CR/Codesk No/Win : CR-30554  
// Date Of Creation     : 15-09-2022            
// Description          : Integrate SmartApiEnyRiskScore and Add EnyScore value and Risk Score value
//******************************************************************************************************************************* 
//******************************************************************************************************************************* 
// Sr. No.              : 41
// Company              : Life            
// Module               : UW Saral         
// Program Author       : Sushant Devkate          
// BRD/CR/Codesk No/Win : CR-2304  
// Date Of Creation     : 22/09/2022           
// Description          : Audit Point  Customer contact details validation with Agent database
//*******************************************************************************************************************************
//*******************************************************************************************************************************
// Sr. No.              : 42
// Company              : Life            
// Module               : UW Saral   
//METHODE/EVENT:BUSSINESS LAYER
// Program Author       : Sushant Devkate - MFL00905
// BRD/CR/Codesk No/Win :  CR-30543 
// Date Of Creation     :  12/10/2022
// Description          : Added functinality on IsSmokar 
//*******************************************************************************************************************************
//******************************************************************************************************************************* 
// Sr. No.              : 43
// Company              : Life            
// Module               : UW Saral         
// Program Author       : Bhaumik Patel WebAshlar02         
// BRD/CR/Codesk No/Win : CR-4134  
// Date Of Creation     : 25-08-2022            
// Description          :Add Box For RedFlagging of Clients ID
//*******************************************************************************************************************************
//******************************************************************************************************************************* 
// Sr. No.              : 44
// Company              : Life            
// Module               : UW Saral         
// Program Author       : Royson Pinto      
// BRD/CR/Codesk No/Win : CR-4783  
// Date Of Creation     : 21-12-2022            
// Description          : Create a Restrict Further Cover Option
//*******************************************************************************************************************************
//******************************************************************************************************************************* 
// Sr. No.              : 45
// Company              : Life            
// Module               : UW Saral         
// Program Author       : Jayendra Patankar [WebAshlar01]      
// BRD/CR/Codesk No/Win :  
// Date Of Creation     : 25-11-2022            
// Description          : Create a Restrict for UINNO
//*******************************************************************************************************************************

//**********************************************************************
// Sr. No.              : 46
// Company              : Life            
// Module               : UW Saral         
// Program Author       : Jayendra [WebAshlar01]
// BRD/CR/Codesk No/Win : STP Changes 
// Date Of Creation     : 05-03-2023
// Description          :  1. Schedular for the STP Integration
//**********************************************************************
//**********************************************************************
// Sr. No.              : 47
// Company              : Life            
// Module               : UW Saral         
// Program Author       : Bhaumik Patel [WebAshlar02]
// BRD/CR/Codesk No/Win : CR-5855  
// Date Of Creation     : 12-06-2023
// Description          :  Grid based Loading access for Counter offer in Saral.
//**********************************************************************
//**********************************************************************
// Sr. No.              : 48
// Company              : Life            
// Module               : UW Saral         
// Program Author       : Bhaumik Patel - WebAshlar02
// BRD/CR/Codesk No/Win : CR-5307 
// Date Of Creation     : 21/06/2023
// Description          : UnderWriting Assignment Details (User Access)
//**********************************************************************
//**********************************************************************
// Sr. No.              : 49
// Company              : Life            
// Module               : UW Saral         
// Program Author       : Sagar  Thorave [MFL00886]
// BRD/CR/Codesk No/Win : CR-7049  
// Date Of Creation     : 10-07-2023
// Description          : Add new dropdown
//**********************************************************************
//******************************************************************
// Sr. No.              : 50
// Company              : Life            
// Module               : UW Saral         
// Program Author       : Jayendra Patnakar [Webashlar01]
// BRD/CR/Codesk No/Win : 
// Date Of Creation     : 18-08-2023
// Description          : Add Input filed for Acceptance Reason value Other selected
//********************************************************************** 
//**********************************************************************
// Sr. No.              : 51
// Company              : Life            
// Module               : UW Saral         
// Program Author       : Bhaumik Patel - WebAshlar02
// BRD/CR/Codesk No/Win : CR-3334 
// Date Of Creation     : 08/09/2023
// Description          :Retup Multiple Reason Option
//**********************************************************************
public partial class Appcode_Default : System.Web.UI.Page
{
    string strApplicationno = string.Empty;
    string strChannelType = string.Empty;
    string strUserId = string.Empty;
    string strUWmode = string.Empty;
    string strUserGroup = string.Empty;
    string strOptinselected = string.Empty;
    string strAppstatusKey = string.Empty;
    string strPolicyNo = string.Empty;
    string strConsentRespons = string.Empty;
    string strClickBucketLink = string.Empty;//Added by Suraj on 24 APRIL 2018 for Close file review
    Commfun objComm = new Commfun();
    BussLayer objBuss = new BussLayer();
    //47.1 Begin of Changes; Bhaumik Patel - [CR-5855]
    CommanAssignmentDetails commobj = new CommanAssignmentDetails();
    //47.1 End of Changes; Bhaumik Patel - [CR-5855]

    //48.1 Begin of Changes; Bhaumik Patel - [CR-5307]
    string UserLimit = string.Empty;
    string struserName = string.Empty;
    //48.1 End of Changes; Bhaumik Patel - [CR-5307]

    DataSet _ds = new DataSet();
    DataSet dsMSAR = new DataSet();
    DataTable _Dt = new DataTable();
    DataSet _dsAppNo = new DataSet();
    DataSet _dsAgentdetails = new DataSet();
    DataSet _dsBank = new DataSet();
    DataSet _dsPrevPol = new DataSet();
    DataSet _dsJournal = new DataSet();
    DataSet _dsFollowuo = new DataSet();
    DataSet _dsProdontrol = new DataSet();
    DataSet _dsUWDisplayOption = new DataSet();
    DataSet _dsAppdtls = new DataSet();
    DataSet _dsPandtls = new DataSet();
    DataSet _dsTsarMsarDtls = new DataSet();
    DataSet _dsProdDtls = new DataSet();
    DataTable _dsRiderDtls = new DataTable();
    DataSet _dsFundsDtls = new DataSet();
    DataSet _dscommentDtls = new DataSet();
    DataSet _dsPymentsDtls = new DataSet();
    DataSet _dsRequrmentDtls = new DataSet();
    // 46.1 Start of Changes; Jayendra  - [Webashlar01]
    DataSet _dsRequrmentDtls_STP = new DataSet();
    // 46.1 End of Changes; Jayendra  - [Webashlar01]
    DataSet _dsReceiptDtls = new DataSet();
    DataSet _dsLoadingDtls = new DataSet();
    DataSet _dsReportDtls = new DataSet();
    DataSet _dsUWMaster = new DataSet();
    DataSet _dsPageData = new DataSet();
    DataSet _dsDashcount = null;
    DataSet _dsQuestion = new DataSet();
    DataSet _dsWarning = new DataSet();
    string response = "";
    UWSaralDecision.BussLayer objUWDecision = new UWSaralDecision.BussLayer();
    UWSaralServices.CommFun objUSSComm = new UWSaralServices.CommFun();
    CommonObject objCommonObj = new CommonObject();
    ChangeValue objChangeObj = new ChangeValue();
    Commfun objcomm = new Commfun();
    int strLApushErrorCode;
    string strLApushStatus;
    string clsName = "";
    decimal ServiceTax;
    bool HighRisk;
    bool IsCommentSave;
    int IsCommentStore;
    bool IsMedicalDE;
    /*added by shri on 23 june 17*/
    public string strAppno = string.Empty;
    /*end here*/
    //40.1 Begin of Changes; Sagar Thorave-[mfl00886]
    string IsENY = ConfigurationManager.AppSettings["IsENY"].ToString();
    string IsRiskScore = ConfigurationManager.AppSettings["IsRiskScore"].ToString();
    //40.1 End of Changes; Sagar Thorave-[mfl00886]
    string strCIBILScore = string.Empty;
    bool IsCombi = true;//added by suraj for combi product
    int rptprodctlistcount = 0;//added by suraj for combi product
    int reqcounter = 0;//added by suraj for combi product
    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Session["objLoginObj"] == null)
        {
            Response.Redirect("~/9011042143.aspx");
        }
        else
        {
            Bindeventhandler();
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Logger.Info(strApplicationno + " STAG2:-page load start" + System.Environment.NewLine);
        Logger.Info(strApplicationno + " STAG2:-A" + System.Environment.NewLine);
        ScriptManager.RegisterStartupScript(Page, GetType(), "disp_confirm", "<script>hideloading()</script>", false);
        //Added by Suraj on 01-Nov-2018 -wanted to restrict copy and paste of URL to open the page
        //43.1 Begin of Changes; Bhaumik Patel - [CR-4134]
        objCommonObj = (CommonObject)Session["objCommonObj"];
        strUserId = objCommonObj._Bpmuserdetails._UserID;
        //43.1 End of Changes; Bhaumik Patel - [CR-4134]
        try
        {

            Logger.Info(strApplicationno + " STAG2:-B" + System.Environment.NewLine);
            //IsCommentStore = 0;
            Session["IsCombi"] = IsCombi;


            #region  VAPT Point
            /*
            string qsUserLimit = string.Empty;
            string qsClickBucketLink = string.Empty;
            if (Request.QueryString["TokenNumber"] != null)
            {
                GetUWREDIRECTDECISION(ref strUserGroup, ref strApplicationno, ref strChannelType, ref strPolicyNo, ref qsUserLimit, ref qsClickBucketLink, Request.QueryString["TokenNumber"].ToString());
                strAppno = strApplicationno;
                hdnUserLimit.Value = qsUserLimit;
                Session["qsUserGroup"] = strUserGroup;
                Session["qsAppNo"] = strApplicationno;
                Session["qsPolicyNo"] = strPolicyNo;
                Session["qsChannelName"] = strChannelType;
            }
            */
            #endregion

            /*ID:20 START*/
            if (Request.QueryString["qsUserGroup"] != null)
            {
                strUserGroup = UWSaralDecision.CommFun.Base64DecodingMethod(Request.QueryString["qsUserGroup"]);
                Logger.Info(strApplicationno + " STAG2:-C" + System.Environment.NewLine);
            }
            if (Request.QueryString["qsAppNo"] != null)
            {
                //strApplicationno = UWSaralDecision.CommFun.Base64DecodingMethod(Request.QueryString["qsAppNo"]);
                strApplicationno = Request.QueryString["qsAppNo"];
                strAppno = strApplicationno;
                Logger.Info(strApplicationno + "STAG1:-Retrive Querystring Value");
                Logger.Info(strApplicationno + " STAG2:-D" + System.Environment.NewLine);
            }
            if (Request.QueryString["qsChannelName"] != null)
            {
                strChannelType = UWSaralDecision.CommFun.Base64DecodingMethod(Request.QueryString["qsChannelName"]);
                Logger.Info(strApplicationno + " STAG2:-E" + System.Environment.NewLine);
            }
            if (Request.QueryString["qsPolicyNo"] != null)
            {
                strPolicyNo = UWSaralDecision.CommFun.Base64DecodingMethod(Request.QueryString["qsPolicyNo"]);
                Logger.Info(strApplicationno + " STAG2:-F" + System.Environment.NewLine);
            }
            /*ID:20 END*/
            MasterPageComparision objOldMasterComparision = new MasterPageComparision();
            //strUserGroup = UWSaralDecision.CommFun.Base64DecodingMethod(Request.QueryString["qsUserGroup"]);
            //strApplicationno = UWSaralDecision.CommFun.Base64DecodingMethod(Request.QueryString["qsAppNo"]);
            //strChannelType = UWSaralDecision.CommFun.Base64DecodingMethod(Request.QueryString["qsChannelName"]);
            //strPolicyNo = UWSaralDecision.CommFun.Base64DecodingMethod(Request.QueryString["qsPolicyNo"]);


            if (Request.QueryString["qsClickBucketLink"] != null)
            {
                strClickBucketLink = UWSaralDecision.CommFun.Base64DecodingMethod(Request.QueryString["qsClickBucketLink"]);
            }
            //end
            if (Request.QueryString["qsUserLimit"] != null)
            {
                hdnUserLimit.Value = UWSaralDecision.CommFun.Base64DecodingMethod(Request.QueryString["qsUserLimit"]);

                //48.1 Begin of Changes; Bhaumik Patel - [CR-5307]
                UserLimit = hdnUserLimit.Value.ToString();
                //48.1 Begin of Changes; Bhaumik Patel - [CR-5307]
                Logger.Info(strApplicationno + " STAG2:-F" + System.Environment.NewLine);
            }
            if (objCommonObj != null)
            {
                Logger.Info(strApplicationno + " STAG2:-H" + System.Environment.NewLine);
                string strOfflineClass = string.Empty;
                string strOnlineClass = string.Empty;
                /*added by shri on 29 aug 17 to hide client DEQC for online */
                if (strChannelType.Equals("ONLINE"))
                {
                    divOfflineAml.Attributes["class"] = divOfflineAml.Attributes["class"] + " HideControl";
                    divOnlineAml.Attributes["class"] = divOnlineAml.Attributes["class"].Replace(" HideControl", string.Empty);
                    Logger.Info(strApplicationno + " STAG2:-H" + System.Environment.NewLine);
                }
                else
                {

                    divOnlineAml.Attributes["class"] = divOnlineAml.Attributes["class"] + " HideControl";
                    divOfflineAml.Attributes["class"] = divOfflineAml.Attributes["class"].Replace(" HideControl", string.Empty);
                    Logger.Info(strApplicationno + " STAG2:-J" + System.Environment.NewLine);
                }
                /*end here*/
            }

            if (!IsPostBack)
            {
                //Kavita 26/02/2020 ----CR-26885
                //ddlInvestigationReport.Enabled = false;
                //btnInvestReport.Disabled = true;
                ddlInvestigationReport.Visible = false;
                btnInvestReport.Visible = false;
                ddlRiskInvestDecision.Visible = false; //CR-27523 Kavita

                Context.Items["AgentCode"] = "";
                Context.Items["AgentChannel"] = "";
                //Start changes by Shweta Mamilwar
                getFGData();
                //End changes by Shweta Mamilwar
                //string strPreviousPage = "";
                //if (Request.UrlReferrer != null)
                //{
                //    strPreviousPage = Request.UrlReferrer.Segments[Request.UrlReferrer.Segments.Length - 1];
                //}
                //if (strPreviousPage == "")
                //{
                //    Response.Redirect("~/9011042143.aspx");
                //}
                /*
                if (ViewState["CommonViewState"] == null)
                {
                    CommonViewState viewstst = new CommonViewState();
                    viewstst.IsCommentSave = false;
                    ViewState["CommonViewState"] = viewstst;
                }
                else
                {
                    CommonViewState viewstst = (CommonViewState)ViewState["CommonViewState"];
                    viewstst.IsCommentSave = false;
                    ViewState["CommonViewState"] = viewstst;
                }
                */
                Logger.Info(strApplicationno + " STAG2:-K" + System.Environment.NewLine);
                if (Session["objCommonObj"] != null)
                {
                    Logger.Info(strApplicationno + " STAG2:-L" + System.Environment.NewLine);
                    int intTrackingRet = -1;
                    objCommonObj = (CommonObject)Session["objCommonObj"];
                    strUserId = objCommonObj._Bpmuserdetails._UserID;
                    hdnUserId.Value = strUserId;
                    string jsVariable = string.Empty;
                    //string mySting = "Mario Gamito";

                    jsVariable = strUserId;

                    //32.1 Begin of Changes; Brijesh Pandey - [MFL00464]
                    objComm.GetIIBRiskScore(strApplicationno, "UW", "Uwdecision_Combi.aspx - Page_Load", strUserId);
                    //32.1 End of Changes; Brijesh Pandey - [MFL00464]

                    this.Page.ClientScript.RegisterClientScriptBlock(
                                        this.GetType(), strUserId, jsVariable, true);

                    Session["UserID"] = strUserId;
                    /*ADDED BY SHRI ON 07 NOV 17 TO CALL MANAGE APPLICATION LIFE CYCLE*/
                    int intRef = -1;
                    objComm.ManageApplicationLifeCycle(strApplicationno, strUserId, "UW_DECISION_WINDOW", false, ref intRef);
                    objComm.ManageApplicationLifeCycle(strApplicationno, strUserId, "UW_DECISION_LOAD", false, ref intRef);
                    /*END HERE*/
                    Logger.Info("***********************UW Journey Start****************************" + System.Environment.NewLine);
                    Logger.Info(strApplicationno + " STAG1:-Retrive Application Number " + strApplicationno + " and ChannelType as " + strChannelType + "and user group is" + strUserGroup + System.Environment.NewLine);
                    /*added by shri on 28 dec 17 to add tracking*/
                    InsertUwDecisionTracking(strApplicationno, strUserId, DateTime.Now, "LOAD", ref intTrackingRet);
                    /*end here*/
                    //Added by Suraj on 24 APRIL 2018 for close file review set text for click bucket link
                    DataSet ds = new DataSet();
                    objComm.CheckCloseFileReview(strUserId, strApplicationno, ref ds);
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        strClickBucketLink = "Close_File_Review";
                        if (strApplicationno.Contains("F"))
                        {
                            strChannelType = "ONLINE";
                        }
                        else
                        {
                            strChannelType = "OFFLINE";
                        }
                        //hdncolsefilerw.Value = "";
                    }
                    else
                    {
                        strClickBucketLink = "";
                    }
                    Logger.Info(strApplicationno + " STAG2:-M" + System.Environment.NewLine);
                    DisableControl_CloseFileReview();
                    /*end here*/

                    if (!string.IsNullOrEmpty(strApplicationno))
                    {
                        #region Fill master Details Begins.
                        Logger.Info(strApplicationno + " STAG2:-N" + System.Environment.NewLine);
                        Logger.Info(strApplicationno + " STAG2:-Fill master Details Region" + System.Environment.NewLine);
                        FillMasterDetails(ref _dsUWMaster);
                        //43.1 Begin of Changes; Bhaumik Patel - [CR - 3334]
                        FillloadingReason("");
                        lblErrorDecisiondtls.Text = "";
                        //43.1 End of Changes; Bhaumik Patel - [CR - 3334]
                        Logger.Info(strApplicationno + " STAG2:-O" + System.Environment.NewLine);
                        //FillProductControlDetails(strApplicationno, strChannelType);
                        Logger.Info(strApplicationno + " STAG2:-P" + System.Environment.NewLine);
                        objcomm.OnlineLoadingMasterDetails_GET(ref _dsFollowuo, strApplicationno, strChannelType);
                        Logger.Info(strApplicationno + " STAG2:-Q" + System.Environment.NewLine);
                        if (_dsFollowuo != null && _dsFollowuo.Tables.Count > 0)
                        {
                            Logger.Info(strApplicationno + " STAG2:-R" + System.Environment.NewLine);
                            /*
                            ViewState["LoadMaster"] = _dsFollowuo.Tables[0];
                            ddlLoadRiderCode.DataSource = _dsFollowuo.Tables[0];
                            ddlLoadRiderCode.DataTextField = "NAME";
                            ddlLoadRiderCode.DataValueField = "VALUE";
                            //ddlLoadRiderCode.DataMember = "Code";
                            ddlLoadRiderCode.DataBind();
                            ddlLoadRiderCode.Items.Insert(0, new ListItem("--Select--", "0"));
                            */
                            //added by Suraj for bind app nos of combi product--start
                            if (_dsFollowuo.Tables[1].Rows.Count > 0)
                            {
                                Logger.Info(strApplicationno + " STAG2:-R" + System.Environment.NewLine);
                                Session["AppNos"] = _dsFollowuo.Tables[1];
                                ddlAppNo.DataSource = _dsFollowuo.Tables[1];
                                ddlAppNo.DataTextField = "NAME";
                                ddlAppNo.DataValueField = "VALUE";
                                //ddlLoadRiderCode.DataMember = "Code";
                                ddlAppNo.DataBind();
                                ddlAppNo.Items.Insert(0, new ListItem("--Select--", "0"));
                                Logger.Info(strApplicationno + " STAG2:-S" + System.Environment.NewLine);
                            }
                            //end
                            Logger.Info(strApplicationno + " STAG2:-S" + System.Environment.NewLine);
                        }

                        #endregion Fill master details end.

                        #region Fill Individual Section Details Begins.
                        /*ADDED BY SHRI ON 08 NOV TO FETCH DATA FROM OBJECT TABLE*/
                        //objcomm.FetchApplicationObject(strApplicationno, strChannelType, strUserId, ref _ds);
                        //if (_ds != null && _ds.Tables.Count > 0 && _ds.Tables[0].Rows.Count > 0)
                        //{
                        //    string strCommonObjectXml = Convert.ToString(_ds.Tables[0].Rows[0]["OBJECTDATA"]);
                        //    hdnSrNo.Value = Convert.ToString(_ds.Tables[0].Rows[0]["SRNO"]);
                        //    DataSet _dsCommonObject = new DataSet();
                        //    Commfun.ConvertXmlToDataSet(strCommonObjectXml, ref _dscommentDtls);
                        //    if (_dscommentDtls != null && _dscommentDtls.Tables.Count > 0 && _dscommentDtls.Tables[0].Rows.Count > 0)
                        //    {
                        //        FillUwDecision(_dscommentDtls);
                        //    }
                        //    _ds.Tables.RemoveAt(0);
                        //    FillUwDecision(_ds);
                        //}
                        //else
                        //{
                        Logger.Info(strApplicationno + "STAG3:-Fill Individual section Details Region" + System.Environment.NewLine);
                        objcomm.LoadUWsaralPageDetails(ref _dsPageData, strApplicationno, strChannelType, strUserId);
                        Logger.Info(strApplicationno + " STAG2:-T" + System.Environment.NewLine);
                        if (_dsPageData != null && _dsPageData.Tables.Count > 0)
                        {
                            Logger.Info(strApplicationno + " STAG2:-U" + System.Environment.NewLine);
                            FillUwDecision(_dsPageData);
                            Logger.Info(strApplicationno + " STAG2:-W" + System.Environment.NewLine);

                        }
                        //FillProductControlDetails(strApplicationno, strChannelType);
                        //}
                        /*added by shri on 08 for temp data pull*/
                        //objcomm.FetchApplicationObject(strApplicationno, ref _ds);
                        //string strCommonObjectXml = Convert.ToString(_ds.Tables[0].Rows[0]["OBJECTDATA"]);
                        //hdnSrNo.Value = Convert.ToString(_ds.Tables[0].Rows[0]["SRNO"]);
                        //DataSet _dsCommonObject = new DataSet();
                        //Commfun.ConvertXmlToDataSet(strCommonObjectXml, ref _dscommentDtls);
                        //if (_dscommentDtls != null && _dscommentDtls.Tables.Count > 0 && _dscommentDtls.Tables[0].Rows.Count > 0)
                        //{
                        //    FillUwDecision(_dscommentDtls);
                        //}
                        /*end here*/
                        //}
                        //ID:2 BEGINS
                        //
                        //ID:2 END.
                        /*added by shri on 21 june 17*/

                        #region NSAP Loading.
                        FillNsaploadingDetails(strApplicationno, strChannelType);
                        Logger.Info(strApplicationno + " STAG2:-X" + System.Environment.NewLine);
                        #endregion NSAP Loading.

                        #region fetch client basic details
                        FetchClientBasicDetails(ref _ds, strApplicationno);
                        Logger.Info(strApplicationno + " STAG2:-Y" + System.Environment.NewLine);
                        if (_ds != null && _ds.Tables.Count > 0 && _ds.Tables[0].Rows.Count > 0)
                        {
                            gvClientDetails.DataSource = _ds;
                            gvClientDetails.DataBind();
                            _ds.Clear();
                            Logger.Info(strApplicationno + " STAG2:-Z" + System.Environment.NewLine);
                        }
                        #endregion

                        #region AML
                        //ID:1 BEGINS
                        //UserControl_PopupDoc objUserControl = (UserControl_PopupDoc)PendingDocs;
                        //int response = 0;
                        //objUserControl.FillPendingDoc(strApplicationno, "", ref response);
                        //ID:1 END
                        #endregion
                        /*end here*/

                        #endregion Fill Individual Section Details Begins.
                        //divUWReason.Visible = false;
                        Logger.Info(strApplicationno + " STAG2:-A1" + System.Environment.NewLine);
                    }


                    objComm.FetchMasterRequiredData(strApplicationno, strChannelType, ref _ds);
                    Logger.Info(strApplicationno + " STAG2:-A2" + System.Environment.NewLine);
                    foreach (DataTable dt in _ds.Tables)
                    {
                        if (_ds != null && _ds.Tables.Count > 0 && _ds.Tables[0].Rows.Count > 0)
                        {
                            if (dt.Rows.Count > 0)
                            {
                                Logger.Info(strApplicationno + " STAG2:-A3" + System.Environment.NewLine);
                                switch (dt.Rows[0][0].ToString())
                                {
                                    case "PRODUCT":
                                        {
                                            Logger.Info(strApplicationno + " STAG2:-A4" + System.Environment.NewLine);
                                            FillProductDetails(dt, objOldMasterComparision);
                                            break;
                                        }

                                    case "CLIENT":
                                        {
                                            Logger.Info(strApplicationno + " STAG2:-A5" + System.Environment.NewLine);
                                            FillClientDetails(dt, objOldMasterComparision);
                                            break;
                                        }
                                    case "RIDERDETAILS":
                                        {
                                            Logger.Info(strApplicationno + " STAG2:-6" + System.Environment.NewLine);
                                            FillRiderDetails(dt, objOldMasterComparision);
                                            break;
                                        }
                                }
                            }
                        }
                    }
                    Logger.Info(strApplicationno + " STAG2:-A7" + System.Environment.NewLine);
                    BindQuestion_CloseFile();//Added by Suraj on 24 APRIL 2018 for close file review bind questions
                    Logger.Info(strApplicationno + " STAG2:-A8" + System.Environment.NewLine);
                    Logger.Info(strApplicationno + "STAG3:-Fill Event Handler For Master Page" + System.Environment.NewLine);
                    //Bindeventhandler();
                    /*ADDED BY SHRI ON 07 NOV 17 TO CALL MANAGE APPLICATION LIFE CYCLE*/
                    objComm.ManageApplicationLifeCycle(strApplicationno, strUserId, "UW_DECISION_LOAD", true, ref intRef);
                    Logger.Info(strApplicationno + " STAG2:-A9" + System.Environment.NewLine);
                    //objComm.MaintainApplicationLog(strApplicationno, "OPEN", string.Empty, strUserId, "", ref intRef);
                    /*added by shri on 28 dec 17 to update tracking*/
                    UpdateUwDecisionTracking(intTrackingRet, DateTime.Now, ref intTrackingRet);
                    /*END HERE*/
                    /*Added by Suraj on 22 March 2019 for Video MER link*/
                    //BindVideoMER();
                    /*End*/
                    AppWiseWarning();

                    /*Added by Suraj on 02 June 2019 for Medical Data entry mandatory if medical follow up code present and it is in resolved status*/
                    MedicalDE_Mandatory();
                    /*End*/

                    OfacService();

                    //--------------CR-26885 Kavita 26/02/2020
                    BindInvestigationReportstatus(FetchCategory(188));
                    //---------------CR-26885 Kavita 26/02/2020

                    //CR-27523 Kavita 26/02/2020
                    BindRiskInvestigationdescddl(FetchCategory(229));

                    //Added by Suraj for AU bank relation with LA		
                    GetAUCaes();
                    //end
                    //intTrackingRet 

                    /*commented by suraj on 30/07/2021 as suggested byju sir/saumya to remove from page load and give button to select mandatory
                    //call iib query on page load --suggested by pawan mahajan on 23 feb 2021 
                    DataSet dsIIB = new DataSet();
                    objcomm.GetIIB_ButtonFLAG(ref dsIIB);
                    if (dsIIB != null)
                    {
                        if (dsIIB.Tables.Count > 0 && dsIIB.Tables[0].Rows.Count > 0)
                        {
                            if (Convert.ToBoolean(dsIIB.Tables[0].Rows[0]["ButtonFlag"]) == true)
                                btnFetchIIBQuery_Click(sender, e);
                        }
                    }
                    //end
                    */
                }
                else
                {
                    Response.Redirect("../9011042143.aspx");
                }
                System.Web.Script.Serialization.JavaScriptSerializer objSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                objSerializer.Serialize(objOldMasterComparision);
                hdnOldValue.Value = objSerializer.Serialize(objOldMasterComparision); //Commfun.GetXMLFromObject(objOldMasterComparision);
                /*added by shri on 05 dec 17 to add application log*/
                int intRet = -1;
                //Added parameter "SARAL" to change status SP for enrty in mis report  table from which application
                objcomm.ManageApplicationStatus_Combi(strApplicationno, "OPEN", string.Empty, strUserId, string.Empty, "SARALUW", ref intRet);
                /*end here*/
                //39.1 Begin of Changes; Sagar Thorave-[mfl00886]
                GetAmlRiskValue();
                //39.1 End of Changes; Sagar Thorave-[mfl00886]
                //46.1 Begin of Changes; Sagar Thorave -MFL00886
                SetSpecialInsurance();
                //46.1 End of Changes; Sagar Thorave -MFL00886

                // 46.1 Begin of Changes; Jayendra  - [Webashlar01]
                FillRUW_STP_Message(strApplicationno);
                // 46.1 End of Changes; Jayendra  - [Webashlar01]
            }
            /*ID:7 START*/
            else
            {

                if (this.Request["__EVENTARGUMENT"] != null && this.Request["__EVENTARGUMENT"].Equals("aml"))
                {
                    objcomm.OnlineNsapProductDetails_GET(ref _dsProdontrol, strApplicationno, strChannelType);
                    if (_dsProdontrol != null && _dsProdontrol.Tables.Count > 0 && _dsProdontrol.Tables[0].Rows.Count > 0)
                    {
                        if (!cbIsNsap.Checked)
                        {
                            cbIsNsap.Checked = true;
                            ChangeNsapValue();
                        }
                    }
                    else
                    {
                        if (cbIsNsap.Checked)
                        {
                            cbIsNsap.Checked = false;
                            ChangeNsapValue();
                        }
                    }
                }
                else if (this.Request["__EVENTARGUMENT"] != null && this.Request["__EVENTARGUMENT"].Equals("refer"))
                {
                    btnSaveToDatabase(new object(), new EventArgs());
                    /*ID:23 START*/
                    objUWDecision.OnlineApplicationLAServiceDetails_PUSH(strApplicationno, strChannelType, objChangeObj, ref _ds, ref _dsPrevPol, "CONTRACTMODIFICATION", ref strLApushErrorCode, ref strLApushStatus, ref strConsentRespons);
                    if (strChannelType.ToUpper().Equals("ONLINE"))
                    {
                        int intRet = -1;
                        objBuss = new BussLayer();
                        objBuss.UpdatePolicyStatus(strApplicationno, "PS", strUserId, ref intRet);

                    }
                    /*ID:23 END*/
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "SHOW SUCCESS MESSAGE AND CLOSE PAGE", "window.close();alert('application is assigned to user successfully');", true);
                }
            }
            /*ID:7 END*/
            //else
            //{
            //    if (Session["objCommonObj"] != null)
            //    {
            //        objCommonObj = (CommonObject)Session["objCommonObj"];
            //        /*added by shri on 29 aug 17 to hide client DEQC for online */
            //        if (objCommonObj._ChannelType.ToLower() == "online")
            //        {
            //            //HIDE HEALTH
            //            divOfflineAml.Visible = divHealth.Visible = false;
            //            divOnlineAml.Visible = true;
            //        }
            //        else
            //        {
            //            //SHOW HEALTH
            //            divOfflineAml.Visible = divHealth.Visible = true;
            //            divOnlineAml.Visible = false;
            //        }
            //    }
            //    else
            //    {
            //        Response.Redirect("../9011042143.aspx");
            //    }

            //}            
            /*ID:4 START*/
            //ManageContent();
            /*ID:4 END*/
            //40.1 Begin of Changes; Sagar Thorave-[mfl00886]
            if (IsRiskScore == "true")
            {
                Get_RiskScore_Data();
            }
            //40.1 End of Changes; Sagar Thorave-[mfl00886]
            Logger.Info(strApplicationno + " STAG2:-page load end" + System.Environment.NewLine);
        }

        catch (Exception ex)
        {
            throw ex;//Logger.Info(strApplicationno + "STAG3:-Function Call PageLoad"+ " : "+ex + System.Environment.NewLine);

        }


    }
    //40.1 Begin of Changes; Sagar Thorave-[mfl00886]
    public void Get_RiskScore_Data()
    {
        try
        {
            EnyScoreRequest enyRequest = new EnyScoreRequest();
            DataSet ds2 = new Commfun().Featch_SMARTAPIRISK_Score_Details(txtAppno.Text);
            if (ds2.Tables[0].Rows.Count != 0 && ds2.Tables[0].Rows.Count > 0)
            {
                enyRequest.DataKeyName = "ApplicationNo";
                enyRequest.Source = "UWSaral";
                enyRequest.DataKeyValue = (txtAppno.Text);
                enyRequest.Laname = (ds2.Tables[0].Rows[0]["LANAME"].ToString());
                enyRequest.La_Pcode = (ds2.Tables[0].Rows[0]["LA_PCODE"].ToString());
                enyRequest.La_Occupation = (ds2.Tables[0].Rows[0]["LA_OCCUPATION"].ToString());
                enyRequest.La_Education = (ds2.Tables[0].Rows[0]["LA_EDUCATION"].ToString());
                enyRequest.La_Education_Desc = (ds2.Tables[0].Rows[0]["LA_EDUCATION_DESC"].ToString());
                Label txtProname = null;
                Label txtPrepayterm = null;
                Label txtPolterm = null;
                foreach (RepeaterItem a in rptproductlist.Items)
                {
                    txtProname = a.FindControl("txtProname") as Label;//txtProname.Text;
                    txtPrepayterm = a.FindControl("txtPrepayterm") as Label;
                    txtPolterm = a.FindControl("txtPolterm") as Label;
                }
                enyRequest.Product_Name = txtProname.Text;
                enyRequest.La_Dob = (ds2.Tables[0].Rows[0]["LA_DOB"].ToString());
                enyRequest.APIDetails = "RiskScoreDetails";
                enyRequest.Agntnum = txtAgentcode.Text;
                enyRequest.Agentname = txtAgentName.Text;
                enyRequest.La_Gender = (ds2.Tables[0].Rows[0]["LA_GENDER"].ToString());
                enyRequest.La_Annual_Income = (ds2.Tables[0].Rows[0]["LA_ANNUAL_INCOME"].ToString());
                enyRequest.Ppt = txtPrepayterm.Text;
                enyRequest.Pt = txtPolterm.Text;
                enyRequest.La_Age_Proof = (ds2.Tables[0].Rows[0]["LA_AGE_PROOF"].ToString());
                enyRequest.Register = (ds2.Tables[0].Rows[0]["REGISTER"].ToString());
                enyRequest.Sumassured = (ds2.Tables[0].Rows[0]["sumAssured"].ToString());
                enyRequest.La_Code = (ds2.Tables[0].Rows[0]["LA_CODE"].ToString());
                enyRequest.Product_Code = (ds2.Tables[0].Rows[0]["PRODUCT_CODE"].ToString());
                enyRequest.La_Age_At_Entry = (ds2.Tables[0].Rows[0]["LA_AGE_AT_ENTRY"].ToString());
                enyRequest.Channel = (ds2.Tables[0].Rows[0]["Channel"].ToString());
                enyRequest.Premium_Amt = (ds2.Tables[0].Rows[0]["PREMIUM_AMT"].ToString());
                enyRequest.Branch_Name = (ds2.Tables[0].Rows[0]["BRANCH_NAME"].ToString());
                enyRequest.Billfreq = (ds2.Tables[0].Rows[0]["BILLFREQ"].ToString());
                enyRequest.Statcode = (ds2.Tables[0].Rows[0]["STATCODE"].ToString());
                enyRequest.Ape = (ds2.Tables[0].Rows[0]["APE"].ToString());
                enyRequest.La_Incomeprf = (ds2.Tables[0].Rows[0]["LA_INCOMEPRF"].ToString());
                enyRequest.Nominee_Dob = (ds2.Tables[0].Rows[0]["NOMINEE_DOB"].ToString());
                enyRequest.Nomineerelation = (ds2.Tables[0].Rows[0]["NOMINEERELATION"].ToString());
                enyRequest.Owner_Pancard = (ds2.Tables[0].Rows[0]["OWNER_PANCARD"].ToString());
                enyRequest.La_State = (ds2.Tables[0].Rows[0]["LA_STATE"].ToString());
                string errorCode = CallRiskScore(enyRequest);
                if (!string.IsNullOrEmpty(errorCode))
                {
                    if (errorCode == "0")
                    {
                        new Commfun().Insert_Logs_RiskAndEY(txtAppno.Text, "Api called successfully", "UWSaral", "RiskScoreDetails", "Success");

                    }
                    else
                    {
                        new Commfun().Insert_Logs_RiskAndEY(txtAppno.Text, "Api call successfully-error", "UWSaral", "RiskScoreDetails", "Success");

                    }
                }
            }
            else
            {
                new Commfun().Insert_Logs_RiskAndEY(txtAppno.Text, "Api Data not found in database ", "UWSaral", "RiskScoreDetails", "Error");
            }
        }
        catch (Exception ex)
        {
            new Commfun().Insert_Logs_RiskAndEY(txtAppno.Text, ex.Message, "UWSaral", "RiskScoreDetails", "Error");
        }

    }



    private string CallRiskScore(EnyScoreRequest riskeny)
    {
        try
        {
            string rs = string.Empty;
            string inputJson = string.Empty;
            string result = string.Empty;
            string Authorization = string.Empty;
            string apiUrl = ConfigurationManager.AppSettings["RiskScoreApiURL"].ToString();
            generateToken1(ref Authorization);

            if (!String.IsNullOrEmpty(Authorization))
            {
                inputJson = (new JavaScriptSerializer()).Serialize(riskeny);
                result = SmartApi(apiUrl, "GetRiskScore", inputJson, Authorization, riskeny.DataKeyValue);
                EnyScoreResponse objResponseClass = JsonConvert.DeserializeObject<EnyScoreResponse>(result);

                if (objResponseClass.responseResult.responseCode == "0")
                {
                    string score = objResponseClass.responseBody.risk_Score;
                    if (!string.IsNullOrEmpty(score))
                    {
                        InsertRiskVal(objResponseClass.responseBody.policyNo, objResponseClass.responseBody.underwriting_Due_Diligence_Required, "",
                            objResponseClass.responseBody.risk_Score, objResponseClass.responseBody.suggestive_Requirment, objResponseClass.responseBody.remarks, objResponseClass.responseBody.dataKeyValue, objResponseClass.responseBody.sumAssured, objResponseClass.responseBody.agntNum, objResponseClass.responseBody.channel_Code, objResponseClass.responseBody.channel_Name);
                        //set risk score
                        txtSaralRiskScore.Text = score;
                        return objResponseClass.responseResult.responseCode;
                    }
                    else
                    {
                        new Commfun().Insert_Logs_RiskAndEY(riskeny.DataKeyValue, "RiskScore is null ", "UWSaral", "CallRiskScore", "Fail to update");
                        return objResponseClass.responseResult.responseCode;
                    }

                }
                else
                {
                    return objResponseClass.responseResult.responseCode;
                }


            }
            else
            {
                new Commfun().Insert_Logs_RiskAndEY(riskeny.DataKeyValue, "Token not found ", "UWSaral", "CallRiskScore", "Fail");

            }
        }

        catch (Exception ex)
        {
            new Commfun().Insert_Logs_RiskAndEY(riskeny.DataKeyValue, ex.Message, "UWSaral", "CallRiskScore", "Fail");

        }
        return "";
    }
    public void InsertRiskVal(string policyNo, string underwriting_Due_Diligence_Required, string Parameter_Combinations,
           string risk_Score, string suggestive_Requirment, string remarks, string AppNo, string sumAssured, string AgentNum, string channelCode, string ChannelName)
    {
        new Commfun().Insert_RiskScore_Details(policyNo, underwriting_Due_Diligence_Required, Parameter_Combinations,
        risk_Score, suggestive_Requirment, remarks, AppNo, sumAssured, AgentNum, channelCode, ChannelName);
    }

    private void Get_EnyScore_Data()
    {
        try
        {
            string relation_nominee_la = "";
            EYRiskScoreRequest eny_Score = new EYRiskScoreRequest();
            RequestSource resSoc = new RequestSource();
            Requestbody1 resBody = new Requestbody1();
            DataSet ds2 = new Commfun().Featch_SMARTAPIENYFLAG_Details(txtAppno.Text);
            if (ds2.Tables[0].Rows.Count != 0 && ds2.Tables[0].Rows.Count > 0)
            {
                resSoc.DataKeyName = "ApplicationNo";
                resSoc.DataKeyValue = txtAppno.Text;
                resSoc.Source = "UWSaral";
                resSoc.APIDetails = "EYScoreDetails";
                resBody.relation_nominee_la = relation_nominee_la;
                resBody.PolicyID = txtPolno.Text;
                resBody.AppNo2 = txtAppno.Text;
                Label txtPolterm = null;
                foreach (RepeaterItem a in rptproductlist.Items)
                {

                    txtPolterm = a.FindControl("txtPolterm") as Label;
                }
                resBody.PolicyTerm = txtPolterm.Text;
                resBody.Agntnum = txtAgentcode.Text;
                resBody.LA_name = (ds2.Tables[0].Rows[0]["LANAME"].ToString());
                string date_of_birth = (ds2.Tables[0].Rows[0]["LA_DOB"].ToString());
                string Dob = Convert.ToDateTime(date_of_birth).ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
                resBody.LA_DOB = Dob;
                resBody.LA_Annual_Income = (ds2.Tables[0].Rows[0]["LA_ANNUAL_INCOME"].ToString());
                resBody.LA_Education = (ds2.Tables[0].Rows[0]["LA_EDUCATION_DESC"].ToString());
                resBody.LA_Occupation = (ds2.Tables[0].Rows[0]["LA_OCCUPATION"].ToString());
                resBody.LA_Occupation_Desc = (ds2.Tables[0].Rows[0]["LA_OCCUPATION"].ToString());
                resBody.LA_State = (ds2.Tables[0].Rows[0]["LA_State"].ToString());
                resBody.LA_PCODE = (ds2.Tables[0].Rows[0]["LA_PCODE"].ToString());
                resBody.APE = (ds2.Tables[0].Rows[0]["APE"].ToString());
                resBody.flag_la_not_equal_proposer = ds2.Tables[0].Rows[0]["flag_la_not_equal_proposer"].ToString();
                resBody.SumAssured = (ds2.Tables[0].Rows[0]["sumAssured"].ToString());
                resBody.PolicyID = (ds2.Tables[0].Rows[0]["PolicyID"].ToString());
                string issue = ds2.Tables[0].Rows[0]["Issue_date"].ToString();
                string issue_Date = Convert.ToDateTime(issue).ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
                string Login_Date = ds2.Tables[0].Rows[0]["Login_Date"].ToString();
                string myDate = Convert.ToDateTime(Login_Date).ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
                resBody.Login_Date = myDate;
                resBody.issue_date = issue_Date;
                resBody.Address_proof = ds2.Tables[0].Rows[0]["Address_proof"].ToString();
                resBody.Product_Code = ds2.Tables[0].Rows[0]["ProductCode"].ToString();
                resBody.Channel = ds2.Tables[0].Rows[0]["Channel"].ToString();
                resBody.Sales_manager_id = ds2.Tables[0].Rows[0]["Sales_manager_id"].ToString();
                resBody.covid_check = ds2.Tables[0].Rows[0]["covid_check"].ToString();
                resBody.policy_decline_or_postponsed = ds2.Tables[0].Rows[0]["policy_decline_or_postponsed"].ToString();
                resBody.distance_between_insurer_and_branch = ds2.Tables[0].Rows[0]["distance_between_insurer_and_branch"].ToString();
                eny_Score.RequestSource = resSoc;
                eny_Score.Requestbody = resBody;
                string Eyscore = CallENYScore(eny_Score);
                if (!string.IsNullOrEmpty(Eyscore))
                {
                    if (Eyscore == "0")
                    {
                        new Commfun().Insert_Logs_RiskAndEY(txtAppno.Text, "Api called successfully", "UWSaral", "EnyScoreDetails", "Success");
                    }
                    else
                    {
                        new Commfun().Insert_Logs_RiskAndEY(txtAppno.Text, "Api call successfully-error", "UWSaral", "EnyScoreDetails", "Success");

                    }
                }
                else
                {
                    new Commfun().Insert_Logs_RiskAndEY(txtAppno.Text, "Api call fail", "UWSaral", "EnyScoreDetails", "Fail");
                }

            }
            else
            {
                new Commfun().Insert_Logs_RiskAndEY(txtAppno.Text, "Api data not found in database ", "UWSaral", "EnyScoreDetails", "Error");

            }
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
            new Commfun().Insert_Logs_RiskAndEY(txtAppno.Text, ex.Message, "UWSaral", "EnyScoreDetails", "Error");
        }
    }
    private string CallENYScore(EYRiskScoreRequest ey)
    {
        try
        {
            string rs = string.Empty;
            string inputJson = string.Empty;
            string result = string.Empty;
            string Authorization = string.Empty;
            string apiUrl = ConfigurationManager.AppSettings["ENYScoreApiURL"].ToString();
            generateToken1(ref Authorization);

            if (!String.IsNullOrEmpty(Authorization))
            {
                inputJson = (new JavaScriptSerializer()).Serialize(ey);
                result = SmartApi(apiUrl, "GetEYRiskScore", inputJson, Authorization, ey.Requestbody.AppNo2);
                EnyScoreResponse1 objResponseClass = JsonConvert.DeserializeObject<EnyScoreResponse1>(result);
                if (objResponseClass.ResponseResult.responseCode == "0")
                {

                    String score = objResponseClass.ResponseBody[0].score;
                    if (!string.IsNullOrEmpty(score))
                    {
                        InsertEnyVal(objResponseClass.ResponseBody[0].appno2, objResponseClass.ResponseBody[0].score, objResponseClass.ResponseBody[0].Early_claim_risk_level);
                        txtENYScore.Text = score;
                        return objResponseClass.ResponseResult.responseCode;
                    }
                    else
                    {
                        new Commfun().Insert_Logs_RiskAndEY(ey.RequestSource.DataKeyValue, "EnyRiskScore is null", "UWSaral", "CallENYScore", "Fail");
                        return objResponseClass.ResponseResult.responseCode;
                    }
                }
                else
                {
                    return objResponseClass.ResponseResult.responseCode;
                }
            }
            else
            {
                new Commfun().Insert_Logs_RiskAndEY(ey.RequestSource.DataKeyValue, "Token Not found", "UWSaral", "CallENYScore", "Fail");
            }
        }
        catch (Exception ex)
        {
            new Commfun().Insert_Logs_RiskAndEY(ey.RequestSource.DataKeyValue, ex.Message, "UWSaral", "CallENYScore", "Fail");

        }
        return "";
    }
    public void InsertEnyVal(string appno, string score, string early_claim_risk_level)
    {
        new Commfun().Insert_EnyFlag_Details(appno, score, early_claim_risk_level);
    }
    private void generateToken1(ref string token)
    {
        token = string.Empty;
        try
        {
            using (var client1 = new HttpClient())
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                var postData = new List<KeyValuePair<string, string>>();

                postData.Add(new KeyValuePair<string, string>("ClientID", ConfigurationManager.AppSettings["ClientID"].ToString()));
                postData.Add(new KeyValuePair<string, string>("ClientSecret", ConfigurationManager.AppSettings["ClientSecret"].ToString()));
                postData.Add(new KeyValuePair<string, string>("Source", ConfigurationManager.AppSettings["Source"].ToString()));
                postData.Add(new KeyValuePair<string, string>("PartnerID", ConfigurationManager.AppSettings["PartnerID"].ToString()));

                client1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client1.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", ConfigurationManager.AppSettings["TOKENSubscriptionKey"].ToString());

                HttpContent content = new FormUrlEncodedContent(postData);

                var responseResult = client1.PostAsync(ConfigurationManager.AppSettings["TOKENURL"].ToString(), content).Result;


                string Result = string.Empty;
                if (responseResult.IsSuccessStatusCode)
                {
                    Result = responseResult.Content.ReadAsStringAsync().Result;
                    JObject json = JObject.Parse(Result);

                    token = json["access_token"].ToString();
                    //token = json["token_type"].ToString() + " " + json["access_token"].ToString();
                }
            }
        }
        catch (Exception)
        {
        }

    }
    public string SmartApi(string apiUrl, string Method, string inputJson, string Authorization, string Appno)
    {

        try
        {
            System.Net.WebClient client = new System.Net.WebClient();
            System.Net.ServicePointManager.SecurityProtocol = (System.Net.SecurityProtocolType)3072;
            System.Net.ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, errors) => true;
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            client.Headers["Content-type"] = "application/json";
            client.Headers["Ocp-Apim-Subscription-Key"] = ConfigurationManager.AppSettings["Ocp-Apim-Subscription-Key"].ToString();
            client.Headers["Authorization"] = Authorization;
            client.Encoding = Encoding.UTF8;
            string Response = client.UploadString(apiUrl + Method, inputJson);

            return Response;
        }
        catch (Exception ex)
        {
            new Commfun().Insert_Logs_RiskAndEY(Appno, ex.Message, "UWSaral", "CallENYScore", "Fail");
            return null;
        }
    }
    //40.1 End of Changes; Sagar Thorave-[mfl00886]
    public void DashbordUWResultDynamic_Get(string strApplicationNumber, string strUserid, string strUserGroup, string strUWmode)
    {
        Logger.Info(strApplicationno + "STAG3:-Function Call DashbordUWResultDynamic_Get" + System.Environment.NewLine);
        objBuss.OnlineApplicationUWResultDynamicAppChecker_Get(strApplicationNumber, ref response, strUWmode, strUserid, strUserGroup);
        if (response != null)
        {
            divAppChecklist.InnerHtml = response;
        }
    }


    protected void Bindeventhandler()
    {
        Logger.Info(strApplicationno + "STAG 4 :PageName :Uwdecision.aspx.CS // MethodeName :Bindeventhandler" + System.Environment.NewLine);

        //if (chkReqDtls.Checked)
        //Master.masterCallEvent += new EventHandler(btnRequirmentDtlsSave_Click);

        ////if (chkAppDtls.Checked)
        //Master.masterCallEvent += new EventHandler(btnAppDtlsSave_Click);

        ////if (chkPanDtls.Checked)
        //Master.masterCallEvent += new EventHandler(btnPandtlsSave_Click);

        ////if (chkProductDtls.Checked)
        //Master.masterCallEvent += new EventHandler(btnProddtlsSave_Click);

        ////if (chkFunddtlsSave.Checked)
        //Master.masterCallEvent += new EventHandler(btnFundDtlsSave_Click);

        ////if (chkLoadingDtls.Checked)
        //Master.masterCallEvent += new EventHandler(btnLoadingDtlsSave_Click);


        //Master.masterCallEvent += new EventHandler(btnRiderDtlsSave_Click);

        //Master.masterCallEvent += new EventHandler(btnMandateDtlsSave_Click);

        ////if (chkBankDtls.Checked)
        //Master.masterCallEvent += new EventHandler(btnBankDtlsSave_Click);

        //if (txtUWComments.Value != "")
        // += new EventHandler(btnUWCommSave_Click);

        //on post        
        Master.masterCallEvent += new EventHandler(btnServerValidation);
        Master.masterCallEvent += new EventHandler(btnSaveToDatabase);
        //ucPrompt.checkIfExist += new uc_prompt.customHandler(MyParentMethod);
        //on save
        Master.contentCallEvent += new EventHandler(btnSaveToXml);
    }

    public void UWPreIssueServiceCall(string strApplicationNo, string strAppType)
    {
        Logger.Info(strApplicationno + "STAG3:-Function Call UWPreIssueServiceCall" + System.Environment.NewLine);
        Logger.Info(strApplicationNo + "STAG 3 :PageName :Uwdecision.aspx.CS // MethodeName :UWPreIssueServiceCall");
        DataSet _dsPreissue = new DataSet();
        DataSet _dsPreissueCombi = new DataSet();
        #region PreIssue Begin.
        strLApushErrorCode = 0;
        objChangeObj = (ChangeValue)Session["objLoginObj"];
        objUWDecision.OnlineApplicationLAServiceDetails_PUSH(strApplicationNo, strAppType, objChangeObj, ref _dsPreissueCombi, ref _dsPrevPol, "PREISSUEVAL_COMBI", ref strLApushErrorCode, ref strLApushStatus, ref strConsentRespons);
        if (strLApushErrorCode == 1)
        {
            objUWDecision.OnlineApplicationLAServiceDetails_PUSH(strApplicationNo, strAppType, objChangeObj, ref _dsPreissue, ref _dsPrevPol, "PREISSUEVAL", ref strLApushErrorCode, ref strLApushStatus, ref strConsentRespons);
        }
        if (_dsPreissue != null && _dsPreissue.Tables.Count > 0 && _dsPreissue.Tables[0].Rows.Count > 0)
        {
            decimal _TotalPremium = 0;
            decimal _AmountInsuspense = 0;
            decimal _AmountDue = 0;

            //added by suraj for combi
            DataTable _dsPreissueCombi_Merge = new DataTable();
            _dsPreissueCombi_Merge = _dsPreissueCombi.Tables[0].Copy();
            _dsPreissueCombi_Merge.Merge(_dsPreissue.Tables[0], true);

            _TotalPremium = Convert.ToDecimal(_dsPreissue.Tables[0].Rows[0]["TOATALAMOUNT"].ToString());
            _AmountInsuspense = Convert.ToDecimal(_dsPreissue.Tables[0].Rows[0]["AMOUNTINSUSPENCE"].ToString());



            var newDt = _dsPreissue.Tables[0].AsEnumerable()
               .GroupBy(x => x.Field<string>("Applicationno"))
               .Select(y => y.First())
               .CopyToDataTable();
            rptpreissue.DataSource = newDt;//_dsPreissue.Tables[0];
            rptpreissue.DataBind();
            //end

            divpreissueval.Visible = true;
            //txtTotalPremDue.Text = Convert.ToString(_TotalPremium);
            //txtAmountinsuspense.Text = Convert.ToString(_AmountInsuspense);
            //txtPremServiceTax.Text = _dsPreissue.Tables[0].Rows[0]["SERVICETAX"].ToString();
            //txtAmountdue.Text = Convert.ToString(_AmountInsuspense - _TotalPremium);
            //txtPrebackdateintrest.Text = _dsPreissue.Tables[0].Rows[0]["BACKDATINGINTEREST"].ToString();

            //DataTable dt = _dsPreissue.Tables[0];
            //DataView view = new DataView(dt);
            //DataTable resultTable = view.ToTable(false, "PRE ISSUE DESCRIPTION");
            //_dsPreissue.Tables[0].Columns.RemoveAt(1);
            //_dsPreissue.Tables[0].Columns.RemoveAt(1);
            //_dsPreissue.Tables[0].Columns.RemoveAt(1);
            //_dsPreissue.Tables[0].Columns.RemoveAt(1);

            DataTable dt = _dsPreissueCombi_Merge;
            DataView view = new DataView(dt);
            string[] strclmname = { "Applicationno", "PRE ISSUE DESCRIPTION" };
            DataTable resultTable = view.ToTable(false, strclmname);

            gvPreissueDtls.DataSource = resultTable;
            gvPreissueDtls.DataBind();
        }
        else
        {
            divpreissueval.Visible = false;
            gvPreissueDtls.DataSource = null;
            gvPreissueDtls.DataBind();
        }

        if (strLApushErrorCode == 0)
        {
            lblPreIssueRslt.Text = "PreIssue Validation Success for Application No " + strApplicationNo;
            lblPreIssueRslt.CssClass = "LableSuccess";
        }
        if (strLApushErrorCode == 1)
        {
            lblPreIssueRslt.Text = "PreIssue Validation Failed for Application No " + strApplicationNo;
            lblPreIssueRslt.CssClass = "Lablefailure";
        }
        else if (strLApushErrorCode == -1)
        {
            lblPreIssueRslt.Text = "No Details Found For Application No " + strApplicationNo;
            lblPreIssueRslt.CssClass = "LableInfo";
        }
        foreach (RepeaterItem item in rptpreissue.Items)
        {
            TextBox txtAmountdue = (TextBox)item.FindControl("txtAmountdue");
            if (!string.IsNullOrEmpty(txtAmountdue.Text) && Convert.ToDouble(txtAmountdue.Text) > 0)
            {
                lblPreIssueRslt.Text += "<br/>" + "Suspense amount is greater than Total Premium Due!";
            }
        }

        //ClientScript.RegisterStartupScript(this.GetType(), "Pop", "$('#divShowMessage').modal('show');", true);
        #endregion PreIssue End.
    }

    public void UWSTPServiceCall(string strApplicationNo, string strAppType)
    {
        Logger.Info(strApplicationno + "STAG3:-Function Call UWSTPServiceCall" + System.Environment.NewLine);
        Logger.Info(strApplicationNo + "STAG 3 :PageName :Uwdecision.aspx.CS // MethodeName :UWSTPServiceCall" + System.Environment.NewLine);
        strLApushErrorCode = 0;
        strLApushStatus = string.Empty;
        DataSet _dsSTPResult = new DataSet();
        #region STP Begins.
        objChangeObj = (ChangeValue)Session["objLoginObj"];
        objUWDecision.OnlineApplicationLAServiceDetails_PUSH(strApplicationNo, strAppType, objChangeObj, ref _dsSTPResult, ref _dsPrevPol, "STP", ref strLApushErrorCode, ref strLApushStatus, ref strConsentRespons);
        if (_dsSTPResult.Tables.Count > 0 && _dsSTPResult.Tables[0].Rows.Count > 0)
        {
            gvStpDetails.DataSource = _dsSTPResult;
            gvStpDetails.DataBind();
        }

        if (strLApushErrorCode == 1)
        {
            lblStpResult.Text = "STP Validation Failed for Application No " + strApplicationNo;
            lblStpResult.CssClass = "Lablefailure";
        }
        else if (strLApushErrorCode == 0)
        {
            lblStpResult.Text = "STP Validation Success for Application No " + strApplicationNo;
            lblStpResult.CssClass = "LableSuccess";
        }
        else if (strLApushErrorCode == -1 || _dsSTPResult.Tables[0].Rows.Count == 0)
        {
            lblStpResult.Text = "No Details Found For Application No " + strApplicationNo;
            lblStpResult.CssClass = "LableInfo";
        }
        //else
        //{
        //    lblStpResult.Text = "STP Validation Success for Application No " + strApplicationNo;
        //    lblStpResult.CssClass = "LableSuccess";
        //}
        #endregion STP End.
    }


    public void FillcommonObjectDetails(string strApplicationNo, string strAppType)
    {
        Logger.Info(strApplicationno + "STAG 3 :PageName :Uwdecision.aspx.CS // MethodeName :FillcommonObjectDetails" + System.Environment.NewLine);
        objComm.OnlineCommonObjectDetails_GET(ref _ds, strApplicationno, strAppType);
        BindCommonObjectDetails(_ds.Tables[0], strAppType);

    }


    public void BindCommonObjectDetails(DataTable _ds, string strAppType)
    {
        if (_ds.Rows.Count > 0)
        {
            Logger.Info(strApplicationno + "STAG3:-Function Call BindCommonObjectDetails" + System.Environment.NewLine);
            objCommonObj._ApplicationNo = _ds.Rows[0]["APPLICATIONNO"].ToString();
            objCommonObj._AppType = _ds.Rows[0]["APPTYPE"].ToString();
            objCommonObj._PolicyNo = _ds.Rows[0]["POLICYNO"].ToString();
            objCommonObj._bpm_branchCode = _ds.Rows[0]["BPMBRANCHCODE"].ToString();
            objCommonObj._bpm_businessDate = _ds.Rows[0]["BUSSDATE"].ToString();
            objCommonObj._bpm_creationDate = _ds.Rows[0]["CREATIONDATE"].ToString();
            objCommonObj._bpm_systemDate = _ds.Rows[0]["SYSTEMDATE"].ToString();
            objCommonObj._bpm_userBranch = _ds.Rows[0]["BPMUSERBRANCH"].ToString();
            objCommonObj._bpm_userID = _ds.Rows[0]["BPMUSERID"].ToString();
            objCommonObj._bpm_userName = _ds.Rows[0]["BPMUSERNAME"].ToString();
            objCommonObj._bpmgrp = _ds.Rows[0]["BPMUSERGRP"].ToString();
            objCommonObj._ProductCode = _ds.Rows[0]["PRODCODE"].ToString();
            objCommonObj._ProductType = _ds.Rows[0]["PRODTYPE"].ToString();
            objCommonObj._ProcessName = _ds.Rows[0]["PROCESSNAME"].ToString();
            objCommonObj._ChannelType = strAppType;
            Session["objCommonObj"] = objCommonObj;

            //Start Pragati backdating
            DateTime drrr;
            DataSet _ds1 = new DataSet();
            objUSSComm.OnlineBussinessDate_GET(ref _ds1, objCommonObj._ApplicationNo, "");
            drrr = Convert.ToDateTime(_ds1.Tables[0].Rows[0][0]);
            _ds1.Dispose();

            string StartDate = string.Empty;
            string EndDate = string.Empty;
            EndDate = Convert.ToDateTime(drrr).ToString("dd-MM-yyyy");
            if (drrr.Month == 4)
            {
                if (drrr.Day < 30)
                {
                    StartDate = Convert.ToDateTime(drrr).AddDays(-(drrr.Day - 1)).ToString("dd-MM-yyyy");
                }
                else
                {
                    StartDate = Convert.ToDateTime(drrr).AddDays(-30).ToString("dd-MM-yyyy");
                }
            }
            else
            {
                StartDate = Convert.ToDateTime(drrr).AddDays(-30).ToString("dd-MM-yyyy");
            }
            HdnBusinessDate.Value = StartDate + "#" + EndDate;
            //End Pragati backdating
        }
    }

    public void FillPageDetails()
    {
        BindApplicationDetails(_dsAppdtls.Tables[0]);
    }

    public void FillApplicationDetails(string strApplicationno, string ChannelType)
    {
        Logger.Info(strApplicationno + "STAG 3 :PageName :Uwdecision.aspx.CS // MethodeName :FillApplicationDetails" + System.Environment.NewLine);
        objComm.OnlineApplicationDisplayDetails_GET(ref _dsAppdtls, strApplicationno, ChannelType);
        BindApplicationDetails(_dsAppdtls.Tables[0]);
    }

    public void BindApplicationDetails(DataTable _dsAppdtls)
    {
        Logger.Info(strApplicationno + "STAG3:-Function Call BindApplicationDetails" + System.Environment.NewLine);
        if (_dsAppdtls.Rows.Count > 0)
        {
            string strImageUrl = string.Empty;
            txtAppno.Text = _dsAppdtls.Rows[0]["AppNo"].ToString();
            txtPolno.Text = _dsAppdtls.Rows[0]["PolNo"].ToString();
            txtAppsigndate.Text = _dsAppdtls.Rows[0]["AppSignDate"].ToString();
            txtAppchannel.Text = _dsAppdtls.Rows[0]["Channel"].ToString();
            txtPivcStatus.Text = _dsAppdtls.Rows[0]["PIVCSTATUS"].ToString();
            bool strBackDateFlag = Convert.ToBoolean(_dsAppdtls.Rows[0]["BACKDATEFLAG"]);
            bool strIsstaff = Convert.ToBoolean(_dsAppdtls.Rows[0]["IsStaff"].ToString());
            ddlAutoPaytype.SelectedValue = _dsAppdtls.Rows[0]["AUTOPAYTYPE"].ToString();
            txtBackDateIntrest.Text = Convert.ToString(_dsAppdtls.Rows[0]["BACKDATEINTREST"]);
            txtAgentChannel.Text = _dsAppdtls.Rows[0]["AgentChannel"].ToString();
            Context.Items["AgentChannel"] = txtAgentChannel.Text; //Kavita 26/02/2020 CR-26885
            if (!string.IsNullOrEmpty(_dsAppdtls.Rows[0]["BACKDATE"].ToString()))
            {
                txtRcdreq.Text = _dsAppdtls.Rows[0]["BACKDATE"].ToString();
                txtRcdreq.CssClass = "form-control lblLable";
            }
            if (!string.IsNullOrEmpty(_dsAppdtls.Rows[0]["BACHDATEREASON"].ToString()))
            {
                ddlBkdateReason.SelectedValue = _dsAppdtls.Rows[0]["BACHDATEREASON"].ToString();
                ddlBkdateReason.CssClass = "form-control lblLable";
            }
            if (strIsstaff == true)
            {
                hd_que_2.Checked = true;
            }
            else
            {
                hd_que_2.Checked = false;
            }

            if (strBackDateFlag == true)
            {
                switch_havInsurance.Checked = true;
                //lblBackdateCaption.CssClass = lblBackdateCaption.CssClass.Replace("form-control lblLable", "form-control");

            }
            else
            {
                switch_havInsurance.Checked = false;
            }
            /*added by shri on 08 sept 17 to bind txtPivcRejectReason*/
            txtPivcRejectReason.Text = Convert.ToString(_dsAppdtls.Rows[0]["PIVCRJCREASON"]);
            /*added by shri on 23 oct 17 to add pivc status*/
            if (Convert.ToInt16(_dsAppdtls.Rows[0]["SCRH_PIVC_STATUS"]) == 1)
            {
                strImageUrl = @"../dist/img/Success.png";
                imgPivcStatus.ImageUrl = strImageUrl;
                //clsName = divDecisionDetails.Attributes["class"].ToString();
                ////divDecisionDetails.Attributes.Add("class", clsName.Replace(clsName, "col-md-12"));                
                //divDecisionDetails.Attributes.Add("class", clsName.Replace("lblLable", string.Empty).Replace("HideControl", string.Empty));
            }
            else
            {
                strImageUrl = @"~/dist/img/Failuer.png";
                imgPivcStatus.ImageUrl = strImageUrl;
                /*
                if (ddlUWDecesion.Items.FindByValue("proposal") != null)
                {
                    ddlUWDecesion.Items.FindByValue("proposal").Selected = true;
                    ddlUWDecesion.Enabled = false;
                }
                */
                //divDecisionDetails.Attributes.Add("class", "col-md-12 HideControl");
            }
            /*added by shri on 16 nov 17*/
            cbIsNsap.Checked = Convert.ToBoolean(_dsAppdtls.Rows[0]["APP_isNSAP"]);
            /*added by shri for mandate */
            /*ID:10 START*/
            cbIsSicl.Checked = Convert.ToBoolean(_dsAppdtls.Rows[0]["APP_isSICL"]);
            /*ID:10 END*/
            /*ID:12 START*/
            //txtApplicationDetailsCibil.Text = Convert.ToString(_dsAppdtls.Rows[0]["APP_Cibil"]);
            strCIBILScore = Convert.ToString(_dsAppdtls.Rows[0]["APP_Cibil"]);
            /*ID:12 END*/
            /*ID:24 START*/
            bool IsPlvcVideoUploaded = Convert.ToBoolean(_dsAppdtls.Rows[0]["IsPlvcVideoUploaded"]);
            if (IsPlvcVideoUploaded == true)
            {
                btnPlvcVideo.Visible = true;
                ChangeThumbStatus(imgPlvcVideo, true);
            }
            else
            {
                btnPlvcVideo.Visible = false;
                lblMsgPlvcVideo.Text = "Plvc video not available.";
                ChangeThumbStatus(imgPlvcVideo, false);
            }
            /*ID:24 END*/

            HideShowMandate();
            /*end here*/

            //added by suraj for CR - 29847 - Backdating of ULIP to be disallowed in UW stag on 19 JAN 2021
            if (_dsAppdtls.Rows[0]["ProductType"].ToString() == "UL")
            {
                hdnprodtype.Value = _dsAppdtls.Rows[0]["ProductType"].ToString();
                txtRcdreq.Text = string.Empty;
                txtRcdreq.CssClass = "form-control lblLable";

                ddlBkdateReason.SelectedValue = "0";
                ddlBkdateReason.CssClass = "form-control lblLable";

                lblBackdateCaption.Attributes.Add("class", "form-control lblLable");
                switch_havInsurance.Checked = false;
            }
            //end

            // Added by Brijesh Pandey

            if (strIsstaff == true)
            {
                divRelationwithStaff.Visible = true;
            }
            else
            {
                divRelationwithStaff.Visible = false;
                ddlRelationStaff.SelectedValue = "0";
            }
            if (!string.IsNullOrEmpty(_dsAppdtls.Rows[0]["RelationwithStaff"].ToString()))
            {
                ddlRelationStaff.SelectedValue = _dsAppdtls.Rows[0]["RelationwithStaff"].ToString();
            }
            //End
        }
    }

    public void UWFollowupServiceCall(string strApplicationNo, string strAppType)
    {
        DataSet _dsFollowup = new DataSet();
        objChangeObj = (ChangeValue)Session["objLoginObj"];
        objUWDecision.OnlineApplicationLAServiceDetails_PUSH(strApplicationNo, strAppType, objChangeObj, ref _dsFollowup, ref _dsPrevPol, "FOLLOWUP", ref strLApushErrorCode, ref strLApushStatus, ref strConsentRespons);
    }


    public void FillAgentDetails(string strApplicationno, string ChannelType)
    {
        Logger.Info(strApplicationno + "STAG 3 :PageName :Uwdecision.aspx.CS // MethodeName :FillAgentDetails" + System.Environment.NewLine);
        objComm.OnlineAgentDisplayDetails_GET(ref _dsAgentdetails, strApplicationno, ChannelType);
        BindAgentDetails(_dsAgentdetails.Tables[0]);
    }

    public void BindAgentDetails(DataTable _dsAgentdetails)
    {
        if (_dsAgentdetails.Rows.Count > 0)
        {
            string strImageUrl = string.Empty;
            Logger.Info(strApplicationno + "STAG3:-Function Call BindAgentDetails" + System.Environment.NewLine);
            txtAgentcode.Text = _dsAgentdetails.Rows[0]["AgentCode"].ToString();
            txtFgempcode.Text = _dsAgentdetails.Rows[0]["EmpCode"].ToString();
            txtPartnerempcode.Text = _dsAgentdetails.Rows[0]["PartnerCode"].ToString();
            txtcampaigncode.Text = _dsAgentdetails.Rows[0]["CampaignCode"].ToString();
            txtLeadcode.Text = _dsAgentdetails.Rows[0]["LeadCode"].ToString();
            chkAgentverified.Checked = Convert.ToBoolean(_dsAgentdetails.Rows[0]["IsAgentVerified"]);
            txtAgentName.Text = Convert.ToString(_dsAgentdetails.Rows[0]["AgentName"]);
            Context.Items["AgentCode"] = txtAgentcode.Text; //kavita 26/02 CR-26885
            /*ID 33 START*/
            //txtAgentvintage.Text = Convert.ToString(_dsAgentdetails.Rows[0]["AgentVintage"]);
            /*ID 33 END*/
            if (!string.IsNullOrEmpty(txtLeadcode.Text))
            {
                chkAgentLeadcode.Checked = true;

            }
            else
            {
                chkAgentLeadcode.Checked = false;
            }

            if (!string.IsNullOrEmpty(_dsAgentdetails.Rows[0]["MDRTAgent"].ToString()))
            {
                strImageUrl = @"../dist/img/Success.png";
                imagemdrt.ImageUrl = strImageUrl;
            }
            else
            {
                strImageUrl = @"~/dist/img/Failuer.png";
                imagemdrt.ImageUrl = strImageUrl;
            }

        }
    }

    public void FillBankDetails(string strApplicationno, string ChannelType)
    {
        Logger.Info(strApplicationno + "STAG 3 :PageName :Uwdecision.aspx.CS // MethodeName :FillBankDetails" + System.Environment.NewLine);
        objComm.OnlineBankDisplayDetails_GET(ref _dsBank, strApplicationno, ChannelType);
        BindBankDetails(_dsBank.Tables[0]);
    }

    public void BindBankDetails(DataTable _dsBank)
    {
        if (_dsBank.Rows.Count > 0)
        {
            Logger.Info(strApplicationno + "STAG3:-Function Call BindBankDetails" + System.Environment.NewLine);
            txtBnkClientname.Text = _dsBank.Rows[0]["ClientName"].ToString();
            txtBnkClienttype.Text = _dsBank.Rows[0]["ClientType"].ToString();
            txtBnkClientnumber.Text = _dsBank.Rows[0]["ClientNumber"].ToString();
            txtBnkIfsccode.Text = _dsBank.Rows[0]["IFSCCode"].ToString();
            txtBnkBankname.Text = _dsBank.Rows[0]["BankName"].ToString();
            txtBnkBranchname.Text = _dsBank.Rows[0]["BankBranch"].ToString();
            txtBnkBankaddress.Text = _dsBank.Rows[0]["BankAddress"].ToString();
            txtBnkBankaccno.Text = _dsBank.Rows[0]["BankAccountNumber"].ToString();
        }
    }

    public void FillPanDetails(string strApplicationno, string ChannelType)
    {
        Logger.Info(strApplicationno + "STAG 3 :PageName :Uwdecision.aspx.CS // MethodeName :FillPanDetails" + System.Environment.NewLine);
        objComm.OnlinePanDisplayDetails_GET(ref _dsPandtls, strApplicationno, ChannelType);
        BindPanDetails(_dsPandtls.Tables[0]);
    }

    public void BindPanDetails(DataTable _dsPandtls)
    {
        if (_dsPandtls.Rows.Count > 0)
        {
            //26.1 Begin of Changes; Bibekananda Nanda - [1103055]

            string ND_PanStatus = string.Empty;
            string ND_PanTitle = string.Empty;
            string PanYear = string.Empty;
            string IsNSAP = string.Empty;

            //26.1 End of Changes; Bibekananda Nanda - [1103055]

            /*added by shri on 22 july 17 to check pan conditionally*/
            //chkPanCopy.Checked = true;
            /*end here*/
            Logger.Info(strApplicationno + "STAG3:-Function Call BindPanDetails" + System.Environment.NewLine);
            txtPannumber.Text = _dsPandtls.Rows[0]["PANCardNo"].ToString();
            /*added by shri on 22 july 17 to check pan conditionally*/
            if (Convert.ToBoolean(_dsPandtls.Rows[0]["ISPANAPPLIED"]) && string.IsNullOrEmpty(txtPannumber.Text))
            {
                chkForm16Copy.Checked = true;
                //chkForm16Copy.Visible = true;
                //chkPanCopy.Visible = false;
                chkPanCopy.Checked = false;
                //divPanValidation.Visible = false;
                //divPanDetails.Style.Add("display", "none"); 
                divPanValidation.Attributes["class"] = divPanValidation.Attributes["class"] + " HideControl";
                divPanManipulate.Attributes["class"] = divPanManipulate.Attributes["class"] + " HideControl";
                /* logic changed as suggested by ganesh rajput on 12/10/2018
                chkPanCopy.Checked = true;
                //chkPanCopy.Visible = true;
                //chkForm16Copy.Visible = false;
                chkForm16Copy.Checked = false;
                //divPanDetails.Style.Add("display", "none");
                divPanValidation.Attributes["class"] = divPanValidation.Attributes["class"].Replace("HideControl", string.Empty);
                divPanManipulate.Attributes["class"] = divPanManipulate.Attributes["class"].Replace("HideControl", string.Empty);
                */
            }
            else
            {
                chkPanCopy.Checked = true;
                //chkPanCopy.Visible = true;
                //chkForm16Copy.Visible = false;
                chkForm16Copy.Checked = false;
                //divPanDetails.Style.Add("display", "none");
                divPanValidation.Attributes["class"] = divPanValidation.Attributes["class"].Replace("HideControl", string.Empty);
                divPanManipulate.Attributes["class"] = divPanManipulate.Attributes["class"].Replace("HideControl", string.Empty);
                /*
                chkForm16Copy.Checked = true;
                //chkForm16Copy.Visible = true;
                //chkPanCopy.Visible = false;
                chkPanCopy.Checked = false;
                //divPanValidation.Visible = false;
                //divPanDetails.Style.Add("display", "none"); 
                divPanValidation.Attributes["class"] = divPanValidation.Attributes["class"] + " HideControl";
                divPanManipulate.Attributes["class"] = divPanManipulate.Attributes["class"] + " HideControl";
                */
            }
            txtPanComment.Text = Convert.ToString(_dsPandtls.Rows[0]["COMMENT"]); ;
            txtPanDescription.Text = Convert.ToString(_dsPandtls.Rows[0]["RESULTDETAILS"]);
            lblPanIsValidated.Text = Convert.ToString(_dsPandtls.Rows[0]["ISMATCHED"]);

            //26.1 Begin of Changes; Bibekananda Nanda - [1103055]
            lblnsdlPanType.Text = Convert.ToString(_dsPandtls.Rows[0]["ND_PanType"]);

            lblnsdlLastUpdDt.Text = Convert.ToString(_dsPandtls.Rows[0]["ND_LastUpdDate"]);

            ND_PanStatus = Convert.ToString(_dsPandtls.Rows[0]["ND_PanStatus"]);
            ND_PanTitle = Convert.ToString(_dsPandtls.Rows[0]["ND_PanTitle"]);

            PanYear = Convert.ToString(_dsPandtls.Rows[0]["PanYear"]);
            IsNSAP = Convert.ToString(_dsPandtls.Rows[0]["IsNSAP"]);

            if (PanYear == "0" && IsNSAP == "false")
            {
                lblPanMsgProp.Visible = true;
                lblPanMsg.Visible = true;
                lblPanMsg.Text = "PAN card issued within 1 year, please process with due diligence";
            }
            else
            {
                lblPanMsgProp.Visible = false;
                lblPanMsg.Visible = false;
                lblPanMsg.Text = "";
            }
            //26.1 End of Changes; Bibekananda Nanda - [1103055]

            if (lblPanIsValidated.Text.Contains("Manual") || lblPanIsValidated.Text.Contains("Auto Matched"))
            {
                chkIsPanValidate.Checked = true;
                ChangeThumbStatus(imgPanVerified, true);
            }
            else
            {
                chkIsPanValidate.Checked = false;
                ChangeThumbStatus(imgPanVerified, false);
            }
            /*end here*/
        }
    }

    public void FillTsmrMsarDetails(string strApplicationno, string ChannelType)
    {
        Logger.Info(strApplicationno + "STAG3:-Function Call FillTsmrMsarDetails" + System.Environment.NewLine);
        Logger.Info(strApplicationno + "STAG 2 :PageName :Uwdecision.aspx.CS // MethodeName :FillTsmrMsarDetails");
        DataSet _dsMsarTsar = new DataSet();
        strLApushErrorCode = 0;
        strLApushStatus = string.Empty;
        objChangeObj = (ChangeValue)Session["objLoginObj"];
        objComm.OnlineTsmrMsarDisplayDetails_GET(ref _dsTsarMsarDtls, strApplicationno, strChannelType);
        if (_dsTsarMsarDtls != null && _dsTsarMsarDtls.Tables.Count > 0 && _dsTsarMsarDtls.Tables[0].Rows.Count > 0)
        {
            objUWDecision.OnlineApplicationLAServiceDetails_PUSH(strApplicationno, ChannelType, objChangeObj, ref _dsMsarTsar, ref _dsPrevPol, "MSAR", ref strLApushErrorCode, ref strLApushStatus, ref strConsentRespons);
            if (_dsMsarTsar != null && _dsMsarTsar.Tables.Count > 0)
            {
                SaveTsarMsarDetails(_dsMsarTsar.Tables[0], strApplicationno);
                BindTsarMsarDetails(_dsMsarTsar.Tables[0]);
            }
            if (_dsPrevPol != null && _dsPrevPol.Tables.Count > 0)
            {
                BindPreviousPolictDetails(_dsPrevPol.Tables[0]);
            }
            //objUWDecision.OnlineApplicationLAServiceDetails_PUSH(strApplicationno, ChannelType, objChangeObj, ref _dsMsarTsar, ref _dsPrevPol, "MSARSARAL", ref strLApushErrorCode, ref strLApushStatus, ref strConsentRespons);
            //BindTsarMsarDetailsSaral(_dsMsarTsar.Tables[0]);
            //BindPreviousPolictDetailsSaral(_dsPrevPol.Tables[0]);
        }
    }
    public void SaveTsarMsarDetails(DataTable _dtTsarMsar, string strAppno)
    {
        int resp = 0;
        objBuss.Save_TsarMsar(_dtTsarMsar, strAppno, ref resp);
    }
    public void BindPreviousPolictDetails(DataTable _dsPrev)
    {
        if (_dsPrev.Rows.Count > 0)
        {
            _dsPrev.Columns.Remove("stat");
            _dsPrev.Columns.Remove("ageProofSubmitted");
            _dsPrev.Columns.Remove("idProofSubmitted");
            _dsPrev.Columns.Remove("addressProofSubmitted");
            _dsPrev.Columns.Remove("incomeProofSubmitted");
            _dsPrev.Columns.Remove("underwriterComments");

            divPrePolicy.Visible = true;
            gridPrevPol.DataSource = _dsPrev;
            gridPrevPol.DataBind();
        }
        else
        {
            divPrePolicy.Visible = false;
            lblErrorPrevpol.Text = "No Previous Policy Details found";
        }
    }
    public void BindTsarMsarDetails(DataTable _dsTsarMsarDtls)
    {
        if (_dsTsarMsarDtls.Rows.Count > 0)
        {
            GridMsarTsar.DataSource = _dsTsarMsarDtls;
            GridMsarTsar.DataBind();
        }

    }

    //43.1 Begin of Changes; Bhaumik Patel - [CR-4134]
    public void FillRedFlagDetails(String strApplicationno)
    {
        chkredflag.Checked = false;
        DataSet _dsRedFlagDtls = new DataSet();
        string Mode;
        Mode = "UWDecisionRedFlagGrid";
        objComm.OnlineRedFlagtDetails_GET(ref _dsRedFlagDtls, strApplicationno, Mode);
        BindRedFlagDetails(_dsRedFlagDtls.Tables[0]);

    }

    public void BindRedFlagDetails(DataTable _dsRedFlagDtls)
    {
        if (_dsRedFlagDtls.Rows.Count > 0)
        {

            GridRedFlag.DataSource = _dsRedFlagDtls;
            GridRedFlag.DataBind();
        }

    }
    //43.1 End of Changes; Bhaumik Patel - [CR-4134]

    public void FillProductDetails(string strApplicationno, string ChannelType)
    {
        Logger.Info(strApplicationno + "STAG 3 :PageName :Uwdecision.aspx.CS // MethodeName :FillProductDetails" + System.Environment.NewLine);
        objComm.OnlineProductDisplayDetails_GET(ref _dsProdDtls, strApplicationno, ChannelType);
        BindProductDetails(_dsProdDtls.Tables[0]);
        //BindRiderDetails(_dsProdDtls.Tables[1]);
    }

    public void BindProductDetails(DataTable _dsProdDtls)
    {
        string ProductName = string.Empty;
        if (_dsProdDtls.Rows.Count > 0)
        {
            //48.1 Begin of Changes; Bhaumik Patel - [CR-5307]
            ProdDtls objprodchangevalue = new ProdDtls();
            //48.1 End of Changes; Bhaumik Patel - [CR-5307]
            double strServiceTax = Convert.ToDouble(ConfigurationManager.AppSettings["ServiceTax"]);
            double strBasePremium = Math.Round(Convert.ToInt32(_dsProdDtls.Rows[0]["BasePremium"].ToString()) * strServiceTax) + Convert.ToInt32(_dsProdDtls.Rows[0]["BasePremium"].ToString());
            Logger.Info(strApplicationno + "STAG3:-Function Call BindProductDetails" + System.Environment.NewLine);
            hdnProductType.Value = _dsProdDtls.Rows[0]["ProductType"].ToString();
            ViewState["ProdCode"] = _dsProdDtls.Rows[0]["ProductCode"].ToString();
            //48.1 Begin of Changes; Bhaumik Patel - [CR-5307]
            objprodchangevalue._Sumassured =  _dsProdDtls.Rows[0]["SumAssured"].ToString();
            //48.1 End of Changes; Bhaumik Patel - [CR-5307]
            //hdnPolNum.Value= _dsProdDtls.Rows[0]["PolicyNo"].ToString();
            //added by suraj for combi--start
            //48.1 Begin of Changes; Bhaumik Patel - [CR-5307]
            Session["objprodchangevalue"] = objprodchangevalue;
            //48.1 End of Changes; Bhaumik Patel - [CR-5307]
            int i = 0;
            rptproductlist.DataSource = _dsProdDtls;
            rptproductlist.DataBind();
            FillProductControlDetails(strApplicationno, strChannelType);
            foreach (RepeaterItem item in rptproductlist.Items)
            {
                if (_dsProdDtls.Rows[i]["ProductCode"].ToString()=="E91" || _dsProdDtls.Rows[i]["ProductCode"].ToString() == "E92")
                {
                    DropDownList ddlpayoutfreq = (DropDownList)item.FindControl("ddlpayoutfreq");
                    //DropDownList ddlCategory = (DropDownList)item.FindControl("ddlCategory");
                    ddlpayoutfreq.SelectedValue = _dsProdDtls.Rows[i]["PayOutFrquency"].ToString();
                    //ddlCategory.SelectedItem.Text= _dsProdDtls.Rows[i]["Category"].ToString();
                }
                if (_dsProdDtls.Rows[i]["ProductCode"].ToString() == "E97" || _dsProdDtls.Rows[i]["ProductCode"].ToString() == "E98"|| _dsProdDtls.Rows[i]["ProductCode"].ToString() == "EA2")// new Product EA2
                {
                    DropDownList ddlpayoutfreq = (DropDownList)item.FindControl("ddlpayoutfreq");
                    DropDownList ddlPayoutType = (DropDownList)item.FindControl("ddlPayoutType");
                    ddlpayoutfreq.SelectedValue = _dsProdDtls.Rows[i]["PayOutFrquency"].ToString();
                    ddlPayoutType.SelectedValue = _dsProdDtls.Rows[i]["PayOutType"].ToString();
                }
                i++;   
            }
            //foreach (RepeaterItem rptitem in rptproductlist.Items)
            //{
            //    if (ViewState["ProdCode"].ToString() == "E91" || ViewState["ProdCode"].ToString() == "E92" || ViewState["ProdCode"].ToString() == "T36" || ViewState["ProdCode"].ToString() == "T37")
            //    {
            //        HtmlGenericControl divCategory = rptitem.FindControl("divCategory") as HtmlGenericControl;
            //        HtmlGenericControl divPayoutType = rptitem.FindControl("divPayoutType") as HtmlGenericControl;
            //        HtmlGenericControl divPayoutTerm = rptitem.FindControl("divPayoutTerm") as HtmlGenericControl;
            //        HtmlGenericControl divpayoutfreq = rptitem.FindControl("divpayoutfreq") as HtmlGenericControl;
            //        HtmlGenericControl divprodcategory = rptitem.FindControl("divprodcategory") as HtmlGenericControl;
            //        divCategory.Visible = true;
            //        divPayoutType.Visible = true;
            //        divPayoutTerm.Visible = true;
            //        divpayoutfreq.Visible = true;
            //        divprodcategory.Visible = true;
            //    }
            //}

            ViewState["ProdDetail"] = _dsProdDtls;

            rptDecision.DataSource = _dsProdDtls;
            rptDecision.DataBind();
            ViewState["SA"] = _dsProdDtls.Rows[0]["SumAssured"].ToString();
            //end
            /*
            double strServiceTax = Convert.ToDouble(ConfigurationManager.AppSettings["ServiceTax"]);
            double strBasePremium = Math.Round(Convert.ToInt32(_dsProdDtls.Rows[0]["BasePremium"].ToString()) * strServiceTax) + Convert.ToInt32(_dsProdDtls.Rows[0]["BasePremium"].ToString());
            Logger.Info(strApplicationno + "STAG3:-Function Call BindProductDetails" + System.Environment.NewLine);
            hdnProductType.Value = _dsProdDtls.Rows[0]["ProductType"].ToString();
            txtProdcode.Text = _dsProdDtls.Rows[0]["ProductCode"].ToString();
            txtProname.Text = _dsProdDtls.Rows[0]["ProdcutName"].ToString();
            txtBasepolno.Text = _dsProdDtls.Rows[0]["PolicyNo"].ToString();
            txtPolterm.Text = _dsProdDtls.Rows[0]["PolicyTerm"].ToString();
            txtPrepayterm.Text = _dsProdDtls.Rows[0]["PremiumTerm"].ToString();
            txtSumassure.Text = _dsProdDtls.Rows[0]["SumAssured"].ToString();
            ddlFrequency.SelectedValue = _dsProdDtls.Rows[0]["PremiumFreq"].ToString();
            //29.1 Begin of Changes by Akshada; CR-28153	
            hdfSumassure.Value = _dsProdDtls.Rows[0]["SumAssured"].ToString();
            hfdCalPremSA.Value = _dsProdDtls.Rows[0]["SumAssured"].ToString();
            //29.1 End of Changes  by Akshada; CR-28153
            // txtSisamount.Text = _dsProdDtls.Rows[0]["AmountInSIS"].ToString();
            txtBasepremium.Text = _dsProdDtls.Rows[0]["BasePremium"].ToString();
            txtServicetax.Text = _dsProdDtls.Rows[0]["ServiceTax"].ToString();
            txtTotalpremium.Text = _dsProdDtls.Rows[0]["TotalPremium"].ToString();
            txtMonthlyPayoutBase.Text = (string.IsNullOrEmpty(Convert.ToString(_dsProdDtls.Rows[0]["MonthlyPayout"]))) ? "0" : _dsProdDtls.Rows[0]["MonthlyPayout"].ToString();*/
            /*ID:8 START*/
            //txtProdBranchBasePremium.Text = Convert.ToString(_dsProdDtls.Rows[0]["BranchBasePremium"]);
            IsBasePremiumDifferentChecker();
            /*ID:8 END*/
            /*ID:10 START*/
            if (_dsProdDtls.Columns.Contains("SpecialInsuranceType"))
            {
                if (ddlApplicationDetailsProposalType.Items.FindByValue(Convert.ToString(_dsProdDtls.Rows[0]["SpecialInsuranceType"])) != null)
                {
                    ddlApplicationDetailsProposalType.ClearSelection();
                    ddlApplicationDetailsProposalType.Items.FindByValue(Convert.ToString(_dsProdDtls.Rows[0]["SpecialInsuranceType"])).Selected = true;
                    //added by suraj on 10 MAY 2018 for disable assign type dropdown
                    if (ddlApplicationDetailsProposalType.SelectedValue.Equals("EMP"))
                    {
                        ddlAssigmentType.Attributes["class"] = ddlAssigmentType.Attributes["class"].ToString().Replace("lblLable", "");
                    }
                    if (ddlApplicationDetailsProposalType.SelectedValue.Equals("NRI"))
                    {
                        ddlcountry.Attributes["class"] = ddlcountry.Attributes["class"].ToString().Replace("lblLable", "");
                    }
                }
            }
            /*ID:10 END*/



            foreach (DataRow dr in _dsProdDtls.Rows)
            {
                ProductName += dr["ProdcutName"].ToString() + " + ";
            }
            ProductName = ProductName.Remove(ProductName.Length - 2);
            updProductDetails.Update();
        }
        ((Label)Master.FindControl("lblProductName")).Text = ProductName;
        /*ID:10 start*/
        if (IsUserLimitLessThanSumAssured())
        {
            RemoveWarningMessage("1");
            FillWarningMessage("1");
            DisplaySaralWarningMessage();
        }
        /*ID:10 end*/
    }

    public void BindRiderDetails(DataTable _dsProdDtls)
    {
        DataTable dt = _dsProdDtls.Clone();
        DataTable dtCloned = dt.Clone();
        dt.Columns["IsActive"].DataType = typeof(bool);
        DataSet _ds = new DataSet();
        objComm.GetMandatoryRider(ref _ds, _dsProdDtls.Rows[0]["ProductCode"].ToString());
        ViewState["MandatoryRider"] = _ds.Tables[0];
        foreach (DataRow row in _dsProdDtls.Rows)
        {
            dt.ImportRow(row);
        }

        _dsProdDtls.Columns.RemoveAt(0);
        if (_dsProdDtls.Rows.Count > 0)
        {
            Logger.Info(strApplicationno + "STAG3:-Function Call BindRiderDetails" + System.Environment.NewLine);
            ViewState["Rider"] = _dsProdDtls;
            div6.Attributes.Add("class", "col-md-12");
            gvRiderDtls.DataSource = dt;
            gvRiderDtls.DataBind();
        }
        else
        {
            div6.Attributes.Add("class", "col-md-12 HideControl");
        }
        DataView dtactiverider = new DataView(dt);
        dtactiverider.RowFilter = "IsActive = True";
        //_dsProdDtls = dtactiverider.ToTable();

        foreach (GridViewRow gvrow in gvRiderDtls.Rows)
        {
            CheckBox cbIsActive = (CheckBox)gvrow.FindControl("chkremoveRider");
            if (dtactiverider != null && dtactiverider.Count > 0 && _ds != null && _ds.Tables.Count > 0 && _ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < _ds.Tables[0].Rows.Count; i++)
                {
                    //if (dt.Rows[i]["RTABLE"].ToString() == gvrow.Cells[2].Text)
                    //{
                    //for (int j = 0; j < dtactiverider.Count; j++)
                    //{
                    if (Convert.ToString(_ds.Tables[0].Rows[i]["RTABLE"]) == Convert.ToString(dtactiverider[i]["RIDERCODE"]))
                        cbIsActive.Enabled = false;
                    //}

                    //}
                }
            }
        }

    }

    public void FillRiderDetails(string strApplicationno)
    {
        Logger.Info(strApplicationno + "STAG 2 :PageName :Uwdecision.aspx.CS // MethodeName :FillRiderDetails" + System.Environment.NewLine);
        objComm.OnlineRiderDisplayDetails_GET(ref _dsRiderDtls, strApplicationno);
    }

    public void FillfundsDetails(string strApplicationno, string ChannelType)
    {
        Logger.Info(strApplicationno + "STAG 3 :PageName :Uwdecision.aspx.CS // MethodeName :FillfundsDetails" + System.Environment.NewLine);
        objCommonObj = (CommonObject)Session["objCommonObj"];
        objComm.OnlineFundsDisplayDetails_GET(ref _dsFundsDtls, strApplicationno, objCommonObj._ProductCode, ChannelType);
        BindFundDetails(_dsFundsDtls.Tables[0]);
    }

    public void BindFundDetails(DataTable _dsFundsDtls)
    {
        _dsFundsDtls.Columns.RemoveAt(0);
        if (_dsFundsDtls.Rows.Count > 0)
        {
            Logger.Info(strApplicationno + "STAG3:-Function Call BindFundDetails" + System.Environment.NewLine);
            divFunddetails.Attributes.Add("Class", "col-md-12");
            gvFundDtls.DataSource = _dsFundsDtls;
            gvFundDtls.DataBind();
        }
        else
        {
            divFunddetails.Attributes.Add("Class", "col-md-12 HideControl");
        }
    }

    public void FillCommentsDetails(string strApplicationno, string ChannelType, string strCommenttype)
    {
        Logger.Info(strApplicationno + "STAG 3 :PageName :Uwdecision.aspx.CS // MethodeName :FillCommentsDetails" + System.Environment.NewLine);
        objComm.OnlineCommentsDisplayDetails_GET(ref _dscommentDtls, strApplicationno, ChannelType, strCommenttype);
        BindCommentsDetails(_dscommentDtls.Tables[0]);
        clsName = divExistingComments.Attributes["class"].ToString();
        divExistingComments.Attributes.Add("class", clsName.Replace(clsName, "col-md-12"));
    }

    public void BindCommentsDetails(DataTable _dscommentDtls)
    {
        _dscommentDtls.Columns.RemoveAt(0);
        if (_dscommentDtls.Rows.Count > 0)
        {
            Logger.Info(strApplicationno + "STAG3:-Function Call BindCommentsDetails" + System.Environment.NewLine);
            gvUWComments.DataSource = _dscommentDtls;
            gvUWComments.DataBind();
            ViewState["UWComments"] = _dscommentDtls;
        }
    }

    public void FillPaymentsDetails(string strApplicationno, string ChannelType)
    {
        Logger.Info(strApplicationno + "STAG 3 :PageName :Uwdecision.aspx.CS // MethodeName :FillPaymentsDetails" + System.Environment.NewLine);
        objComm.OnlinePaymentsDisplayDetails_GET(ref _dsPymentsDtls, strApplicationno, ChannelType);

    }


    public void FillRequirmentDetails(string strApplicationno, string ChannelType)
    {
        Logger.Info(strApplicationno + "STAG 3 :PageName :Uwdecision.aspx.CS // MethodeName :FillRequirmentDetails" + System.Environment.NewLine);
        objComm.OnlineRequirmentDisplayDetails_GET(ref _dsRequrmentDtls, strApplicationno, ChannelType);
        BindRequirmentDetails(_dsRequrmentDtls.Tables[0]);
    }

    public void BindRequirmentDetails(DataTable _dtRequrmentDtls)
    {
        _dtRequrmentDtls.Columns.RemoveAt(0);
        if (_dtRequrmentDtls.Rows.Count > 0)
        {
            Logger.Info(strApplicationno + "STAG3:-Function Call BindRequirmentDetails" + System.Environment.NewLine);
            ViewState["CurrentTable1"] = _dtRequrmentDtls.Copy();
            //ViewState["CurrentTable1"] = _dtRequrmentDtls;
            Session["ReqCount"] = _dtRequrmentDtls.Rows.Count;
            gvRequirmentDetails.DataSource = _dtRequrmentDtls;
            gvRequirmentDetails.DataBind();
            if (strUserId != "F1130654" && strUserId != "F1126229")
            {
                ddlPEPApproved.Enabled = false;
            }
            else
            {

                ddlPEPApproved.Enabled = true;
            }
            //suraj bhamre on 17 FEb 20202 fro PEP case validations
            //chkPEP.Enabled = false;
            DataView dv = new DataView(_dtRequrmentDtls);
            dv.RowFilter = "REQ_followUpCode = 'PPE' and REQ_status not in ('O','L')";
            if (dv.Count > 0)
            {
                ddlPEP.Enabled = true;

                ddlPEP.ClearSelection();
                ddlPEP.SelectedValue = "1";
                //if (strUserId != "F1130654" && strUserId != "F1126229")
                //Added by Suraj on 13 FEB 2020 for save PEP case/NON PEP case in db
                int resp2 = 0;
                if (strUserId != "F1130654" && strUserId != "F1126229")
                {
                    if (Convert.ToString(ddlPEP.SelectedValue) != "" || Convert.ToInt32(ddlPEP.SelectedValue) != 0)
                    {
                        objBuss.Save_PEPCase(strApplicationno, Convert.ToString(ddlPEP.SelectedItem.Text), strUserId, ref resp2);
                    }
                }
                /*
                if (ddlPEPApproved.SelectedValue != "1")
                {

                    ddlUWDecesion.Items.Remove(ddlUWDecesion.Items.FindByValue("Approved"));

                }
                */
            }
            else
            {
                ddlPEP.Enabled = false;
                ddlPEP.SelectedValue = "0";
            }

        }
    }


    public void FillReceiptDetails(string strApplicationno, string strReqSource)
    {
        Logger.Info(strApplicationno + "STAG 3 :PageName :Uwdecision.aspx.CS // MethodeName :FillReceiptDetails" + System.Environment.NewLine);
        objComm.OnlineReceiptDisplayDetails_GET(ref _dsReceiptDtls, strApplicationno, strReqSource);
        BindReciptDetails(_dsReceiptDtls.Tables[0]);
    }

    public void BindReciptDetails(DataTable _dsReceiptDtls)
    {
        _dsReceiptDtls.Columns.RemoveAt(0);
        if (_dsReceiptDtls.Rows.Count > 0)
        {
            Logger.Info(strApplicationno + "STAG3:-Function Call BindReciptDetails" + System.Environment.NewLine);
            gvRcptDtls.DataSource = _dsReceiptDtls;
            gvRcptDtls.DataBind();
            //txtInstalamentAmt.Text = _dsReceiptDtls.Tables[1].Rows[0]["INSTALLMENTPREMIUM"].ToString();
            //txtTotalamtPaid.Text = _dsReceiptDtls.Tables[1].Rows[0]["TOTALAMOUNT"].ToString();
            //txtAmountRequired.Text = _dsReceiptDtls.Tables[1].Rows[0]["AMOUNTREQUIRED"].ToString();

        }
    }

    public void FillLoadingDetails(string strApplicationno, string strReqSource)
    {
        Logger.Info(strApplicationno + "STAG 3 :PageName :Uwdecision.aspx.CS // MethodeName :FillLoadingDetails" + System.Environment.NewLine);
        objComm.OnlineLoadingDisplayDetails_GET(ref _dsLoadingDtls, strApplicationno, strReqSource);
        BindLoadingDetails(_dsLoadingDtls.Tables[0]);
    }

    public void BindLoadingDetails(DataTable _dsLoadingDtls)
    {
        //_dsLoadingDtls.Columns.RemoveAt(0);
        if (_dsLoadingDtls.Rows.Count > 0)
        {
            Logger.Info(strApplicationno + "STAG3:-Function Call BindLoadingDetails" + System.Environment.NewLine);
            //divExistingloading.Attributes.Remove("Class");
            //divExistingloading.Attributes.Add()
            lblErrorExistingLoading.Text = "";
            clsName = divExistingloading.Attributes["class"].ToString();
            divExistingloading.Attributes.Add("class", clsName.Replace(clsName, "col-md-12"));
            ViewState["ExitingLoadingData"] = _dsLoadingDtls.Copy();
            gvExtLoadDetails.DataSource = _dsLoadingDtls;
            gvExtLoadDetails.DataBind();
        }
        else
        {
            //divExistingloading.Attributes.Add("Class", "HideControl");
            gvExtLoadDetails.DataSource = null;
            gvExtLoadDetails.DataBind();
        }
    }

    public void FillReportDetails(string strApplicationno)
    {
        Logger.Info(strApplicationno + "STAG 2 :PageName :Uwdecision.aspx.CS // MethodeName :FillReportDetails" + System.Environment.NewLine);
        objComm.OnlineReportDisplayDetails_GET(ref _dsReportDtls, strApplicationno);
    }

    public void FillSubMasterDetails(ref DataSet _dsFollowuo, string strDatavalue, string ddlType, string ddlsubtype)
    {
        Logger.Info(strApplicationno + "STAG 2 :PageName :Uwdecision.aspx.CS // MethodeName :FillSubMasterDetails" + System.Environment.NewLine);
        objComm.OnlineSubMasterDisplayDetails_GET(ref _dsFollowuo, strDatavalue, ddlType, ddlsubtype);
    }

    public void FillNsaploadingDetails(string strApplicationno, string ChannelType)
    {
        objcomm.OnlineNsapProductDetails_GET(ref _dsProdontrol, strApplicationno, strChannelType);
        AddLoadingDetails(_dsProdontrol);
    }
    public void AddLoadingDetails(DataSet _dS)
    {
        if (_dS != null && _dS.Tables[0].Rows.Count > 0)
        {
            lblErrorloadingdtls.Text = string.Empty;
            int LoadingResult = 0;
            objChangeObj = (ChangeValue)Session["objLoginObj"];
            string _strLoadRiderName = string.Empty;
            string _strLoadType = string.Empty;
            string _strLoadDiscp = string.Empty;
            //51.1 Begin of Changes; Bhaumik Patel - [CR-3334]
            string _strLoadReason1 = string.Empty;
            string _strLoadReason2 = string.Empty;
            string _strLoadReason3 = string.Empty;
            string _strLoadReason4 = string.Empty;
            //51.1 End of Changes; Bhaumik Patel - [CR-3334]
            string _strLoadPercent = string.Empty;
            string _strRateAdjust = string.Empty;
            string _strFlatmortality = string.Empty;
            string _strLetterPrint = string.Empty;
            string _strRiderCode = string.Empty;
            string _strLoadCode = string.Empty;
            string _strReason1code = string.Empty;
            string _strReason2code = string.Empty;
            string _strSumAssured = string.Empty;
            string _strPremiumPayingterm = string.Empty;
            _strLoadCode = _dS.Tables[0].Rows[0]["LD_code"].ToString();
            _strLoadDiscp = _dS.Tables[0].Rows[0]["LD_loadingType"].ToString();
            //51.1 Begin of Changes; Bhaumik Patel - [CR-3334]
            string loadrsncode = Request.Form[ddlLoadRsn1.UniqueID];
            
            for (int k = 0; k < loadrsncode.Split(',').Length; k++)
            {
                if (k == 0)
                {
                    _strLoadReason1 = loadrsncode.Split(',')[k];
                }


                if (k == 1)
                {
                    _strLoadReason2 = loadrsncode.Split(',')[k];
                }

                if (k == 2)
                {
                    _strLoadReason3 = loadrsncode.Split(',')[k];
                }


                if (k == 3)
                {
                    _strLoadReason4 = loadrsncode.Split(',')[k];
                }
            }

            //_strReason1code = _dS.Tables[0].Rows[0]["LD_reason1"].ToString();
            //_strReason2code = _dS.Tables[0].Rows[0]["LD_reason2"].ToString();
            //51.1 End of Changes; Bhaumik Patel - [CR-3334]
            _strSumAssured = _dS.Tables[0].Rows[0]["LD_sumAssured"].ToString();
            _strRateAdjust = _dS.Tables[0].Rows[0]["LD_rateAdjustment"].ToString();
            _strFlatmortality = _dS.Tables[0].Rows[0]["LD_flatMortality"].ToString();
            _strPremiumPayingterm = _dS.Tables[0].Rows[0]["LD_premiumPayingTerm"].ToString();
            _strLetterPrint = _dS.Tables[0].Rows[0]["LD_isLetterPrintRequired"].ToString();
            _strLoadRiderName = _dS.Tables[0].Rows[0]["LD_rider"].ToString();
            LoadDtls objLoad = new LoadDtls();
            objLoad._strProdcode = _dS.Tables[0].Rows[0]["LD_rider"].ToString();
            objChangeObj.Load_Loadingdetails = objLoad;
            Session["UserName"] = objChangeObj.userLoginDetails._UserName;
            //51.1 Begin of Changes; Bhaumik Patel - [CR-3334]
            objComm.OnlineLoadingDetails_Save(objCommonObj._AppType, strApplicationno, _strLoadCode, _strLoadDiscp, _strLoadReason1, _strLoadReason2, _strLoadReason3, _strSumAssured, txtLoadPer.Text, _strRateAdjust, _strFlatmortality, _strPremiumPayingterm, _strLetterPrint, _strLoadRiderName, objChangeObj.userLoginDetails._UserID, objChangeObj.userLoginDetails._UserName, objChangeObj.userLoginDetails._UserGroup, objChangeObj.userLoginDetails._userBranch, objChangeObj.userLoginDetails._userBranch, objChangeObj.userLoginDetails._ProcessName, strApplicationno, _strLoadReason4, ref LoadingResult);
            //51.1 End of Changes; Bhaumik Patel - [CR-3334]
            if (LoadingResult != -1)
            {
                objUWDecision.OnlineApplicationLAServiceDetails_PUSH(strApplicationno, strChannelType, objChangeObj, ref _ds, ref _dsPrevPol, "CONTRACTMODIFICATION", ref strLApushErrorCode, ref strLApushStatus, ref strConsentRespons);
                //objUWDecision.OnlineApplicationLAServiceDetails_PUSH(strApplicationno, strChannelType, objChangeObj, ref _ds, "RATEUP", ref strLApushErrorCode, ref strLApushStatus);
                if (strLApushErrorCode == 0)
                {
                }
            }
        }
    }

    public void FillProductControlDetails(string strApplicationno, string ChannelType)
    {
        objcomm.OnlineProdcutControlMasterDetails_GET(ref _dsProdontrol, strApplicationno, strChannelType);
        BindProductControlDetails(_dsProdontrol);
    }
    public void BindProductControlDetails(DataSet _ds)
    {
        if (_ds != null && _ds.Tables.Count > 0)
        {
            int count = 0;
            DataTable _dt = _ds.Tables[0];
            foreach (RepeaterItem rptitem in rptproductlist.Items)
            {
                TextBox txtPolterm = (TextBox)rptitem.FindControl("txtPolterm");
                TextBox txtPrepayterm = (TextBox)rptitem.FindControl("txtPrepayterm");
                TextBox txtSumassure = (TextBox)rptitem.FindControl("txtSumassure");
                ViewState["SA"] = txtSumassure.Text;
                TextBox txtMonthlyPayoutBase = (TextBox)rptitem.FindControl("txtMonthlyPayoutBase");
                TextBox txtBasepremium = (TextBox)rptitem.FindControl("txtBasepremium");
                TextBox lblMonthlyPayout = (TextBox)rptitem.FindControl("txtMonthlyPayoutBase");
                DropDownList ddlFrequency = (DropDownList)rptitem.FindControl("ddlFrequency");
                DropDownList ddlCategory = (DropDownList)rptitem.FindControl("ddlCategory");
                DropDownList ddlPayoutType = (DropDownList)rptitem.FindControl("ddlPayoutType");
                DropDownList ddlPayoutTerm = (DropDownList)rptitem.FindControl("ddlPayoutTerm");
                DropDownList ddlpayoutfreq = (DropDownList)rptitem.FindControl("ddlpayoutfreq");
                DropDownList ddlprodcategory = (DropDownList)rptitem.FindControl("ddlprodcategory");
                HtmlGenericControl divCategory = rptitem.FindControl("divCategory") as HtmlGenericControl;
                HtmlGenericControl divPayoutType = rptitem.FindControl("divPayoutType") as HtmlGenericControl;
                HtmlGenericControl divPayoutTerm = rptitem.FindControl("divPayoutTerm") as HtmlGenericControl;
                HtmlGenericControl divpayoutfreq = rptitem.FindControl("divpayoutfreq") as HtmlGenericControl;
                HtmlGenericControl divprodcategory = rptitem.FindControl("divprodcategory") as HtmlGenericControl;
                /*36.1 START*/
                HtmlGenericControl lblPayoutType = rptitem.FindControl("lblPayoutType") as HtmlGenericControl;
                /*36.1 END*/
                if (_dt != null && _dt.Rows.Count > 0)
                {
                    txtPolterm.Enabled = (!string.IsNullOrEmpty(_dt.Rows[0]["PT"].ToString())) ? Convert.ToBoolean(_dt.Rows[0]["PT"]) : false;
                    txtPrepayterm.Enabled = (!string.IsNullOrEmpty(_dt.Rows[0]["PPT"].ToString())) ? Convert.ToBoolean(_dt.Rows[0]["PPT"]) : false;
                    txtBasepremium.Enabled = (!string.IsNullOrEmpty(_dt.Rows[0]["BasePremium"].ToString())) ? Convert.ToBoolean(_dt.Rows[0]["BasePremium"]) : false;
                    txtSumassure.Enabled = (!string.IsNullOrEmpty(_dt.Rows[0]["SumAssure"].ToString())) ? Convert.ToBoolean(_dt.Rows[0]["SumAssure"]) : false;
                    ddlFrequency.Enabled = (!string.IsNullOrEmpty(_dt.Rows[0]["Frequency"].ToString())) ? Convert.ToBoolean(_dt.Rows[0]["Frequency"]) : false;
                    //txtMonthlyPayoutBase.Visible = lblMonthlyPayout.Visible = (!string.IsNullOrEmpty(_dt.Rows[0]["MonthlyPayout"].ToString())) ? Convert.ToBoolean(_dt.Rows[0]["MonthlyPayout"]) : false;
                    //txtMonthlyPayoutBase.Enabled = (!string.IsNullOrEmpty(_dt.Rows[0]["MonthlyPayout"].ToString())) ? Convert.ToBoolean(_dt.Rows[0]["MonthlyPayout"]) : false;
                }
                else
                {
                    txtPolterm.Enabled = true;
                    txtPrepayterm.Enabled = true;
                    txtBasepremium.Enabled = false;
                    txtSumassure.Enabled = true;
                    ddlFrequency.Enabled = true;
                    //txtMonthlyPayoutBase.Enabled = false;
                }
               
                //Added by Suraj Bhamre on 20/11/2020 -- drop down for new product t36/t37/e91/e92
                if (_ds != null && _ds.Tables.Count > 1 && _ds.Tables[1].Rows.Count > 0)
                {
                    ViewState["ProductCode"] = _ds.Tables[1].Rows[count]["PROD_productCode_CHDRTYPE"].ToString();

                    //for product code T36/T37
                    if (Get_DropDownData(ddlCategory, "category", "", ViewState["ProductCode"].ToString(), "Value", "Text"))
                    {
                        //divCategory.Visible = true;
                    }
                    else
                    {
                        divCategory.Visible = false;
                    }
                    if (Get_DropDownData(ddlPayoutType, "payouttype", "", ViewState["ProductCode"].ToString(), "Value", "Text"))
                    {
                        /*36.1 START*/
                        if (ViewState["ProductCode"].ToString() == "E97" || ViewState["ProductCode"].ToString() == "E98")
                        {
                            lblPayoutType.InnerText = "Income Option";
                            ddlPayoutType.Enabled = false;
                            ddlpayoutfreq.Enabled = false;
                        }
                        /*36.1 END*/
                        divPayoutType.Visible = true;
                    }
                    else
                    {
                        divPayoutType.Visible = false;
                    }
                    if (Get_DropDownData(ddlPayoutTerm, "payoutterm", "", ViewState["ProductCode"].ToString(), "Value", "Text"))
                    {
                        divPayoutTerm.Visible = true;
                    }
                    else
                    {
                        divPayoutTerm.Visible = false;
                    }

                    //for product code E91/E92
                    if (Get_DropDownData(ddlpayoutfreq, "payoutfreq", "", ViewState["ProductCode"].ToString(), "Value", "Text"))
                    {
                        divpayoutfreq.Visible = true;
                    }
                    else
                    {
                        divpayoutfreq.Visible = false;
                    }
                    //for product code E93/E94
                    if (Get_DropDownData(ddlprodcategory, "productcategory", "", ViewState["ProductCode"].ToString(), "Value", "Text"))
                    {
                        divprodcategory.Visible = true;
                    }
                    else
                    {
                        divprodcategory.Visible = false;
                    }
                }
                count++;
                //end
                //SetProductControlVisibility();
            }
        }
    }

    //public void SetProductControlVisibility()
    //{
    //    txtPolterm.Enabled = (!string.IsNullOrEmpty(hdnBasePP.Value)) ? Convert.ToBoolean(hdnBasePP.Value) : false;
    //    txtPrepayterm.Enabled = (!string.IsNullOrEmpty(hdnBasePPT.Value)) ? Convert.ToBoolean(hdnBasePPT.Value) : false;
    //    txtBasepremium.Enabled = (!string.IsNullOrEmpty(hdnBasePremium.Value)) ? Convert.ToBoolean(hdnBasePremium.Value) : false;
    //    txtSumassure.Enabled = (!string.IsNullOrEmpty(hdnBaseSumassured.Value)) ? Convert.ToBoolean(hdnBaseSumassured.Value) : false;
    //    ddlFrequency.Enabled = (!string.IsNullOrEmpty(hdnBaseFrequency.Value)) ? Convert.ToBoolean(hdnBaseFrequency.Value) : false;
    //    txtMonthlyPayoutBase.Enabled = (!string.IsNullOrEmpty(hdnBaseMonthlypayout.Value)) ? Convert.ToBoolean(hdnBaseMonthlypayout.Value) : false;

    //    txtCombPolTerm.Enabled = (!string.IsNullOrEmpty(hdnComboPP.Value)) ? Convert.ToBoolean(hdnComboPP.Value) : false;
    //    txtCombPayTerm.Enabled = (!string.IsNullOrEmpty(hdnComboPPT.Value)) ? Convert.ToBoolean(hdnComboPPT.Value) : false;
    //    txtCombPremAmount.Enabled = (!string.IsNullOrEmpty(hdnComboPremium.Value)) ? Convert.ToBoolean(hdnComboPremium.Value) : false;
    //    txtCombSumAssured.Enabled = (!string.IsNullOrEmpty(hdnComboSumassued.Value)) ? Convert.ToBoolean(hdnComboSumassued.Value) : false;
    //    ddlComboFrequency.Enabled = (!string.IsNullOrEmpty(hdnComboFrequency.Value)) ? Convert.ToBoolean(hdnComboFrequency.Value) : false;
    //    txtComboMonthlyPayout.Enabled = (!string.IsNullOrEmpty(hdnBaseMonthlypayout.Value)) ? Convert.ToBoolean(hdnBaseMonthlypayout.Value) : false;
    //}


    public void FillMasterDetailsOld(ref DataSet _dsFollowuo)
    {
        Logger.Info(strApplicationno + "STAG 2A:-Fill master Details Region" + System.Environment.NewLine);
        objComm.OnlineMasterDisplayDetails_GET(ref _dsFollowuo);
        //added by suraj for combi
        ListBox ddlUWreason1 = (ListBox)rptDecision.FindControl("ddlUWreason1");
        DropDownList ddlUWDecesion = (DropDownList)rptDecision.FindControl("ddlUWDecesion");
        if (_dsFollowuo.Tables.Count > 0)
        {
            ViewState["_dsFollowuo"] = _dsFollowuo;
           // BindMasterDetails(ddlUWreason);
            BindMasterDetails(ddlUWDecesion);
            BindMasterDetails(ddlBkdateReason);
            BindMasterDetails(ddlLoadType);
            //51.1 Begin of Changes; Bhaumik Patel - [CR - 3334]
            // BindMasterDetails(ddlLoadRsn1);
            // BindMasterDetails(ddlLoadRsn2);
            //51.1 End of Changes; Bhaumik Patel - [CR - 3334]
            BindMasterDetails(ddlLoadFlatMortality);
            BindMasterDetails(ddlCommonStatus);
            //BindMasterDetails(ddlIfscCode);            
            BindMasterDetails(ddlAutoPaytype);
            //Added by Suraj on 18 APRIL 2018 for add reason dropdown for medical
            BindMasterDetails(ddlRequirementMedicalReason);
        }
    }

    public void FillMasterDetails(ref DataSet _dsFollowuo)
    {
        Logger.Info(strApplicationno + "STAG 2A:-Fill master Details Region" + System.Environment.NewLine);
        /*check if cache is null or not */

        //pragati backdating start
        string sss = HdnBusinessDate.Value;

        objComm.GetHealthProduct(ref _dsAppNo, strApplicationno, "01");

        if (_dsAppNo.Tables[0].Rows.Count > 0)
        {
            hdnHealth.Value = "Health";
            //Logger.Info(strApplicationno + "STAG 2 :PageName :Uwdecision.aspx.CS // MethodeName :FillSubMasterDetails" + System.Environment.NewLine);
            // objComm.OnlineSubMasterDisplayDetails_GET1(ref _dsFollowuo, strDatavalue, ddlType, ddlsubtype);

            objComm.OnlineMasterDisplayDetails_GET1(ref _dsFollowuo);
        }
        else
        {
            //objComm.OnlineSubMasterDisplayDetails_GET2(ref _dsFollowuo, strDatavalue, ddlType, ddlsubtype);
            hdnHealth.Value = "NotHealth";
            objComm.OnlineMasterDisplayDetails_GET(ref _dsFollowuo);
        }
        //pragati backdating end


        //if (HttpRuntime.Cache["DropDownList"] == null)
        //{

        //    //Step 1 (Call ur procedure

        //    objComm.GetHealthProduct(ref _dsAppNo, strApplicationno, "01");

        //    if (_dsAppNo.Tables[0].Rows.Count > 0)
        //    {
        //        hdnHealth.Value = "Health";
        //        //Logger.Info(strApplicationno + "STAG 2 :PageName :Uwdecision.aspx.CS // MethodeName :FillSubMasterDetails" + System.Environment.NewLine);
        //        // objComm.OnlineSubMasterDisplayDetails_GET1(ref _dsFollowuo, strDatavalue, ddlType, ddlsubtype);

        //        objComm.OnlineMasterDisplayDetails_GET1(ref _dsFollowuo);
        //    }
        //    else
        //    {
        //        //objComm.OnlineSubMasterDisplayDetails_GET2(ref _dsFollowuo, strDatavalue, ddlType, ddlsubtype);
        //        hdnHealth.Value = "NotHealth";
        //        objComm.OnlineMasterDisplayDetails_GET(ref _dsFollowuo);
        //    }

        //    //objComm.OnlineMasterDisplayDetails_GET(ref _dsFollowuo);


        //    //fill cache 
        //    HttpRuntime.Cache.Add("DropDownList", _dsFollowuo, null, System.DateTime.MaxValue, TimeSpan.Zero, CacheItemPriority.Normal, null);
        //}
        //else
        //{
        //    //fill DsFolloUp From Cache
        //    _dsFollowuo = (DataSet)HttpRuntime.Cache["DropDownList"];
        //}

        /*end here*/
        /*end here*/
        //added by Suraj for combi
        DropDownList ddlUWDecesion = new DropDownList();
        ListBox ddlUWreason1 = new ListBox();
        foreach (RepeaterItem item in rptDecision.Items)
        {
            ddlUWDecesion = (DropDownList)rptDecision.FindControl("ddlUWDecesion");
            ddlUWreason1 = (ListBox)rptDecision.FindControl("ddlUWreason1");
        }
        //end
        if (_dsFollowuo.Tables.Count > 0)
        {
            ViewState["_dsFollowuo"] = _dsFollowuo;
           // BindMasterDetails(ddlUWreason);
            BindMasterDetails(ddlUWDecesion);
            BindMasterDetails(ddlBkdateReason);
            BindMasterDetails(ddlLoadType);
            //51.1 Begin of Changes; Bhaumik Patel - [CR - 3334]
            // BindMasterDetails(ddlLoadRsn1);
            // BindMasterDetails(ddlLoadRsn2);
            //51.1 End of Changes; Bhaumik Patel - [CR - 3334]
            BindMasterDetails(ddlLoadFlatMortality);
            BindMasterDetails(ddlCommonStatus);
            //BindMasterDetails(ddlIfscCode);            
            BindMasterDetails(ddlAutoPaytype);
            /*ID:10 START*/
            if (_dsFollowuo.Tables.Count > 9)
            {
                BindMasterDetails(ddlApplicationDetailsProposalType);
            }
            if (_dsFollowuo.Tables.Count > 10)
            {
                BindMasterDetails(cblDecisionTypeDecisions);
            }
            if (_dsFollowuo.Tables.Count > 11)
            {
                BindMasterDetails(cblDecisionTypeIncompleteDocument);
            }
            if (_dsFollowuo.Tables.Count > 12)
            {
                BindMasterDetails(cblDecisionTypeCleanCase);
            }

            /*ID:10 END*/
            //Added by Suraj on 25 APRIL 2018
            if (_dsFollowuo.Tables.Count > 13)
            {
                BindMasterDetails(ddlAssigmentType);
            }
            //Added by Suraj on 18 APRIL 2018 for add reason dropdown for medical
            if (_dsFollowuo.Tables.Count > 18)
            {
                BindMasterDetails(ddlRequirementMedicalReason);
            }
            //Added by Suraj on 05 JULY 2018 for add country list
            if (_dsFollowuo.Tables.Count > 19)
            {
                BindMasterDetails(ddlcountry);
            }
            //Added by Suraj on 25 JULY 2019 for signature match
            if (_dsFollowuo.Tables.Count > 20)
            {
                BindMasterDetails(ddlSignature);
            }
            // added by Brijesh
            if (_dsFollowuo.Tables.Count > 21)// check count
            {
                BindMasterDetails(ddlRelationStaff);
            }
            //  end added by Brijesh

        }
    }
    //public void FillMasterDetails(ref DataSet _dsFollowuo)
    //{
    //    Logger.Info(strApplicationno + "STAG 2A:-Fill master Details Region" + System.Environment.NewLine);
    //    /*
    //    //check if cache is null or not 
    //    if (HttpRuntime.Cache["DropDownList"] == null)
    //    {
    //        objComm.OnlineMasterDisplayDetails_GET(ref _dsFollowuo);
    //        //fill cache 
    //        HttpRuntime.Cache.Add("DropDownList", _dsFollowuo, null, System.DateTime.MaxValue, TimeSpan.Zero, CacheItemPriority.Normal, null);
    //    }
    //    else
    //    {
    //        //fill DsFolloUp From Cache
    //        _dsFollowuo = (DataSet)HttpRuntime.Cache["DropDownList"];
    //    }
    //    */
    //    //Start Pragati backdating
    //    string sss = HdnBusinessDate.Value;

    //    objComm.GetHealthProduct(ref _dsAppNo, strApplicationno, "01");

    //    if (_dsAppNo.Tables[0].Rows.Count > 0)
    //    {
    //        hdnHealth.Value = "Health";
    //        //Logger.Info(strApplicationno + "STAG 2 :PageName :Uwdecision.aspx.CS // MethodeName :FillSubMasterDetails" + System.Environment.NewLine);
    //        // objComm.OnlineSubMasterDisplayDetails_GET1(ref _dsFollowuo, strDatavalue, ddlType, ddlsubtype);

    //        objComm.OnlineMasterDisplayDetails_GET1(ref _dsFollowuo);
    //    }
    //    else
    //    {
    //        //objComm.OnlineSubMasterDisplayDetails_GET2(ref _dsFollowuo, strDatavalue, ddlType, ddlsubtype);
    //        hdnHealth.Value = "NotHealth";
    //        objComm.OnlineMasterDisplayDetails_GET(ref _dsFollowuo);
    //    }
    //    /*end Pragati backdating*/

    //    if (_dsFollowuo.Tables.Count > 0)
    //    {
    //        ViewState["_dsFollowuo"] = _dsFollowuo;
    //        BindMasterDetails(ddlUWreason);
    //        BindMasterDetails(ddlUWDecesion);
    //        BindMasterDetails(ddlBkdateReason);
    //        BindMasterDetails(ddlLoadType);
    //        BindMasterDetails(ddlLoadRsn1);
    //        BindMasterDetails(ddlLoadRsn2);
    //        BindMasterDetails(ddlLoadFlatMortality);
    //        BindMasterDetails(ddlCommonStatus);
    //        //BindMasterDetails(ddlIfscCode);            
    //        BindMasterDetails(ddlAutoPaytype);
    //        /*ID:10 START*/
    //        if (_dsFollowuo.Tables.Count > 9)
    //        {
    //            BindMasterDetails(ddlApplicationDetailsProposalType);
    //        }
    //        if (_dsFollowuo.Tables.Count > 10)
    //        {
    //            BindMasterDetails(cblDecisionTypeDecisions);
    //        }
    //        if (_dsFollowuo.Tables.Count > 11)
    //        {
    //            BindMasterDetails(cblDecisionTypeIncompleteDocument);
    //        }
    //        if (_dsFollowuo.Tables.Count > 12)
    //        {
    //            BindMasterDetails(cblDecisionTypeCleanCase);
    //        }

    //        /*ID:10 END*/
    //        //Added by Suraj on 25 APRIL 2018
    //        if (_dsFollowuo.Tables.Count > 13)
    //        {
    //            BindMasterDetails(ddlAssigmentType);
    //        }
    //        //Added by Suraj on 18 APRIL 2018 for add reason dropdown for medical
    //        if (_dsFollowuo.Tables.Count > 18)
    //        {
    //            BindMasterDetails(ddlRequirementMedicalReason);
    //        }
    //        //Added by Suraj on 05 JULY 2018 for add country list
    //        if (_dsFollowuo.Tables.Count > 19)
    //        {
    //            BindMasterDetails(ddlcountry);
    //        }
    //        //Added by Suraj on 25 JULY 2019 for signature match
    //        if (_dsFollowuo.Tables.Count > 20)
    //        {
    //            BindMasterDetails(ddlSignature);
    //        }
    //    }
    //}


    [WebMethod]
    public static List<string> GetAutoCompleteData(string IFSC)
    {
        Logger.Info("STAG 2 :PageName :Uwdecision.aspx.CS // MethodeName :GetAutoCompleteData" + System.Environment.NewLine);
        List<string> empResult = new List<string>();
        List<string> result = new List<string>();
        string connectionString = ConfigurationManager.AppSettings["transactiondbLF"];
        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand objcmd = new SqlCommand("usp_GetBankAutoCompleteData", con);
        objcmd.Parameters.AddWithValue("@Ifsc", IFSC);
        DataTable dtIfscData = new DataTable();
        objcmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(objcmd);
        da.Fill(dtIfscData);
        if (dtIfscData.Rows.Count > 0)
        {
            foreach (DataRow dr in dtIfscData.Rows)
            {
                empResult.Add(dr["IFSC CODE"].ToString());
            }
        }
        return empResult;
    }

    [WebMethod]
    public static string[] GetTextChanged(string Ifsc)
    {
        Logger.Info("STAG 2 :PageName :Uwdecision.aspx.CS // MethodeName :GetTextChanged" + System.Environment.NewLine);
        List<string> strDetailIDList = new List<string>();
        //List<string> empResult = new List<string>();
        // List<string> result = new List<string>();
        string connectionString = ConfigurationManager.AppSettings["transactiondbLF"];
        SqlConnection Sqlconn = new SqlConnection(connectionString);

        SqlCommand objcmd = new SqlCommand("Ups_IfscCode", Sqlconn);
        objcmd.Parameters.AddWithValue("@Ifsc", Ifsc);
        DataSet dsFollowUpDate = new DataSet();
        objcmd.CommandType = CommandType.StoredProcedure;

        SqlDataAdapter da = new SqlDataAdapter(objcmd);
        //DataTable dtIFSC = new DataTable();

        da.Fill(dsFollowUpDate);
        if (dsFollowUpDate.Tables[0].Rows.Count > 0)
        {
            strDetailIDList.Add(dsFollowUpDate.Tables[0].Rows[0][1].ToString());
            strDetailIDList.Add(dsFollowUpDate.Tables[0].Rows[0][4].ToString());
            strDetailIDList.Add(dsFollowUpDate.Tables[0].Rows[0][6].ToString());
        }
        else
        {
            //strDetailIDList.Add(dsFollowUpDate.Tables[0].Rows[0][1].ToString());
            //strDetailIDList.Add(dsFollowUpDate.Tables[0].Rows[0][4].ToString());
            //strDetailIDList.Add(dsFollowUpDate.Tables[0].Rows[0][6].ToString());
        }
        //foreach (DataRow row in dsFollowUpDate.Tables[0].Rows)
        //{

        //}
        string[] strDetailID = strDetailIDList.ToArray();
        return strDetailID;
    }


    private void AddNewRowToGrid1()
    {
        Logger.Info("STAG 2 :PageName :Uwdecision.aspx.CS // MethodeName :AddNewRowToGrid1" + System.Environment.NewLine);
        if (ViewState["CurrentTable1"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable1"];
            DataRow drCurrentRow = null;

            DropDownList REQ_APPLICATIONNOSTR;//added by suraj for combi
            DropDownList REQ_followUpCode;
            TextBox REQ_description;
            DropDownList REQ_category;
            DropDownList REQ_criteria;
            DropDownList REQ_lifeType;
            DropDownList REQ_status;
            Label lblRaiseddate;
            //Label lblRaisedby;
            Label lblClosedDate;
            //Label lblClosedBy;


            if (dtCurrentTable.Rows.Count > 0)
            {
                drCurrentRow = dtCurrentTable.NewRow();
                // drCurrentRow["RowNumber"] = dtCurrentTable.Rows.Count + 1;
                //add new row to DataTable
                dtCurrentTable.Rows.Add(drCurrentRow);

                //Store the current data to ViewState
                ViewState["CurrentTable1"] = dtCurrentTable;
                DateTime _strGetdate = DateTime.Now;
                for (int i = 0; i < dtCurrentTable.Rows.Count - 1; i++)
                {
                    //extract the DropDownList Selected Items
                    REQ_APPLICATIONNOSTR = (DropDownList)gvRequirmentDetails.Rows[i].Cells[0].FindControl("ddlAppNoReq");//added by suraj for combi
                    REQ_followUpCode = (DropDownList)gvRequirmentDetails.Rows[i].Cells[0].FindControl("ddlfollowupcode");
                    //37.1 Begin  of Changes; Sagar Thorave-[mfl00886]
                    NotSelectMerCheckbox(REQ_followUpCode.Text);
                    SelectMerCheckbox(REQ_followUpCode.Text);
                    //37.1 End of Changes; Sagar Thorave-[mfl00886]
                    REQ_description = (TextBox)gvRequirmentDetails.Rows[i].Cells[1].FindControl("lblfollowupDiscp");
                    REQ_category = (DropDownList)gvRequirmentDetails.Rows[i].Cells[2].FindControl("ddlCategory");
                    REQ_criteria = (DropDownList)gvRequirmentDetails.Rows[i].Cells[3].FindControl("ddlCriteria");
                    REQ_lifeType = (DropDownList)gvRequirmentDetails.Rows[i].Cells[4].FindControl("ddlLifeType");
                    REQ_status = (DropDownList)gvRequirmentDetails.Rows[i].Cells[5].FindControl("ddlStatus");

                    //add requirment raisedby details 17 nov2017
                    lblRaiseddate = (Label)gvRequirmentDetails.Rows[i].Cells[6].FindControl("lblRaiseddate");
                    //lblRaisedby = (Label)gvRequirmentDetails.Rows[i].Cells[6].FindControl("lblRaisedby");
                    lblClosedDate = (Label)gvRequirmentDetails.Rows[i].Cells[7].FindControl("lblClosedDate");
                    //lblClosedBy = (Label)gvRequirmentDetails.Rows[i].Cells[6].FindControl("lblClosedBy");
                    //if (HighRisk == true)
                    //{
                    //    REQ_followUpCode.SelectedValue = "PRE";
                    //}
                    dtCurrentTable.Rows[i]["REQ_APPLICATIONNOSTR"] = REQ_APPLICATIONNOSTR.SelectedValue;//added by suraj for combi
                    dtCurrentTable.Rows[i]["REQ_followUpCode"] = REQ_followUpCode.SelectedValue;
                    dtCurrentTable.Rows[i]["REQ_description"] = REQ_description.Text;
                    dtCurrentTable.Rows[i]["REQ_category"] = REQ_category.SelectedValue;
                    dtCurrentTable.Rows[i]["REQ_criteria"] = REQ_criteria.SelectedValue;
                    dtCurrentTable.Rows[i]["REQ_lifeType"] = REQ_lifeType.SelectedValue;
                    dtCurrentTable.Rows[i]["REQ_status"] = REQ_status.SelectedValue;
                    dtCurrentTable.Rows[i]["REQ_RaisedDate"] = lblRaiseddate.Text == "" ? Convert.ToString(_strGetdate) : lblRaiseddate.Text;
                    //dtCurrentTable.Rows[i]["lblRaisedby"] = lblRaisedby.Text;
                    dtCurrentTable.Rows[i]["REQ_ClosedDate"] = lblClosedDate.Text == "" ? (object)DBNull.Value : lblClosedDate.Text;
                    // dtCurrentTable.Rows[i]["lblClosedBy"] = lblClosedBy.Text;

                }

                //for (int i = dtCurrentTable.Rows.Count-2; i > 0; i--)
                //{
                //    DropDownList REQ_followUpCode1 = new DropDownList();
                //    REQ_followUpCode1 = (DropDownList)gvRequirmentDetails.Rows[i].Cells[1].FindControl("ddlfollowupcode");
                //    REQ_followUpCode1.Enabled = true;
                //}

                //Rebind the Grid with the current data
                gvRequirmentDetails.DataSource = dtCurrentTable;
                gvRequirmentDetails.DataBind();

                UpdatePanel1.Update();
            }
        }

        //Set Previous Data on Postbacks
        SetPreviousData1();
    }

    private void AddNewRowToLoadingGrid1()
    {
        Logger.Info("STAG 2 :PageName :Uwdecision.aspx.CS // MethodeName :AddNewRowToLoadingGrid1" + System.Environment.NewLine);
        if (ViewState["LoadingView"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["LoadingView"];
            DataRow drCurrentRow = null;

            if (dtCurrentTable.Rows.Count > 0)
            {
                drCurrentRow = dtCurrentTable.NewRow();
                drCurrentRow["RowNumber"] = dtCurrentTable.Rows.Count + 1;
                //add new row to DataTable
                dtCurrentTable.Rows.Add(drCurrentRow);
                //Store the current data to ViewState
                ViewState["LoadingView"] = dtCurrentTable;

                for (int i = 0; i < dtCurrentTable.Rows.Count - 1; i++)
                {
                    //extract the DropDownList Selected Items
                    Label lblAppno = (Label)gvLoadingDtls.Rows[0].Cells[0].FindControl("lblAppno");//added by Suraj for combi product
                    Label lblLoadType = (Label)gvLoadingDtls.Rows[0].Cells[0].FindControl("lblLoadType");
                    Label lblLoadRsn1 = (Label)gvLoadingDtls.Rows[0].Cells[0].FindControl("lblLoadRsn1");
                    Label lblLoadRsn2 = (Label)gvLoadingDtls.Rows[0].Cells[0].FindControl("lblLoadRsn2");
                    Label lblLoadper = (Label)gvLoadingDtls.Rows[0].Cells[0].FindControl("lblLoadper");
                    Label lblRateAdjust = (Label)gvLoadingDtls.Rows[0].Cells[0].FindControl("lblRateAdjust");
                    Label lblFlatMortality = (Label)gvLoadingDtls.Rows[0].Cells[0].FindControl("lblFlatMortality");

                    dtCurrentTable.Rows[i]["ddlAppno"] = lblAppno.Text;//added by Suraj for combi product
                    dtCurrentTable.Rows[i]["ddlLoadType"] = lblLoadType.Text;
                    dtCurrentTable.Rows[i]["ddlLoadRsn1"] = lblLoadRsn1.Text;
                    dtCurrentTable.Rows[i]["ddlRsn2"] = lblLoadRsn2.Text;
                    dtCurrentTable.Rows[i]["txtLoadPer"] = lblLoadper.Text;
                    dtCurrentTable.Rows[i]["txtRateAdjust"] = lblRateAdjust.Text;
                    dtCurrentTable.Rows[i]["ddlLoadFlatMortality"] = lblFlatMortality.Text;
                    //dtCurrentTable.Rows[i]["ddlLoadFlatMortality"] = lblFlatMortality.Text;
                }

                //Rebind the Grid with the current data
                gvLoadingDtls.DataSource = dtCurrentTable;
                gvLoadingDtls.DataBind();
            }
        }
        else
        {
            Response.Write("ViewState is null");
        }

        //Set Previous Data on Postbacks
        SetPreviousLoadingData();
    }

    private void SetPreviousLoadingData()
    {
        Logger.Info("STAG 2 :PageName :Uwdecision.aspx.CS // MethodeName :SetPreviousLoadingData" + System.Environment.NewLine);
        int rowIndex = 0;
        if (ViewState["LoadingView"] != null)
        {
            DataTable dt = (DataTable)ViewState["LoadingView"];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Label lblAppno = (Label)gvLoadingDtls.Rows[0].Cells[0].FindControl("lblAppno");//added by Suraj for combi product
                    Label lblLoadType = (Label)gvLoadingDtls.Rows[0].Cells[0].FindControl("lblLoadType");
                    Label lblLoadRsn1 = (Label)gvLoadingDtls.Rows[0].Cells[0].FindControl("lblLoadRsn1");
                    Label lblLoadRsn2 = (Label)gvLoadingDtls.Rows[0].Cells[0].FindControl("lblLoadRsn2");
                    Label lblLoadper = (Label)gvLoadingDtls.Rows[0].Cells[0].FindControl("lblLoadper");
                    Label lblRateAdjust = (Label)gvLoadingDtls.Rows[0].Cells[0].FindControl("lblRateAdjust");
                    Label lblFlatMortality = (Label)gvLoadingDtls.Rows[0].Cells[0].FindControl("lblFlatMortality");


                    //Fill the DropDownList with Data
                    //FillDropDownList(ddlLoadType, "LoadingCode", "Mst");
                    //BindMasterDetails(ddlLoadType);
                    //BindMasterDetails(ddlLoadType);

                    if (i <= dt.Rows.Count - 1)
                    {
                        lblAppno.Text = dt.Rows[i]["ddlAppno"].ToString();//added by suraj for combi product
                        lblLoadType.Text = dt.Rows[i]["ddlLoadType"].ToString();
                        lblLoadRsn1.Text = dt.Rows[i]["ddlLoadRsn1"].ToString();
                        lblLoadRsn2.Text = dt.Rows[i]["ddlRsn2"].ToString();
                        lblLoadper.Text = dt.Rows[i]["txtLoadPer"].ToString();
                        lblRateAdjust.Text = dt.Rows[i]["txtRateAdjust"].ToString();
                        lblFlatMortality.Text = dt.Rows[i]["ddlLoadFlatMortality"].ToString();

                        //ddlLoadType.Items.FindByText(dt.Rows[i]["ddlLoadType"].ToString()).Selected = true;
                        //txtLoadDesc.Text = dt.Rows[i]["txtLoadDesc"].ToString();
                        //ddlLoadRsn1.Items.FindByText(dt.Rows[i]["ddlLoadRsn1"].ToString()).Selected = true;
                        // txtRsn1Desc.Text = dt.Rows[i]["txtRsn1Desc"].ToString();
                        //ddlRsn2.Items.FindByText(dt.Rows[i]["ddlRsn2"].ToString()).Selected = true;
                        //txtRsn2Desc.Text = dt.Rows[i]["txtRsn2Desc"].ToString();
                        //txtLoadPer.Text = dt.Rows[i]["txtLoadPer"].ToString();
                        //txtRateAdjust.Text = dt.Rows[i]["txtRateAdjust"].ToString();
                        //ddlLoadFlatMortality.Items.FindByText(dt.Rows[i]["ddlLoadFlatMortality"].ToString()).Selected = true;
                        // ddlLoadletterPrint.Items.FindByText(dt.Rows[i]["ddlLoadletterPrint"].ToString()).Selected = true;
                    }
                    rowIndex++;
                }
            }
        }
    }

    private void SetInitialRequirmentGrid()
    {
        Logger.Info("STAG 2 :PageName :Uwdecision.aspx.CS // MethodeName :SetInitialRequirmentGrid" + System.Environment.NewLine);
        DataTable dt = new DataTable();
        DataSet _ds = new DataSet();
        _ds.Tables.Add(dt);
        DataRow dr = null;

        //Define the Columns
        dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
        dt.Columns.Add(new DataColumn("ddlAppNoReq", typeof(string)));//added by suraj for combi product
        dt.Columns.Add(new DataColumn("REQ_followUpCode", typeof(string)));
        dt.Columns.Add(new DataColumn("REQ_description", typeof(string)));
        dt.Columns.Add(new DataColumn("REQ_category", typeof(string)));
        dt.Columns.Add(new DataColumn("REQ_criteria", typeof(string)));
        dt.Columns.Add(new DataColumn("REQ_lifeType", typeof(string)));
        dt.Columns.Add(new DataColumn("REQ_status", typeof(string)));
        dt.Columns.Add(new DataColumn("lblRaiseddate", typeof(string)));
        //dt.Columns.Add(new DataColumn("lblRaisedby", typeof(string)));
        dt.Columns.Add(new DataColumn("lblClosedDate", typeof(string)));
        //dt.Columns.Add(new DataColumn("lblClosedBy", typeof(string)));

        //Add a Dummy Data on Initial Load
        dr = dt.NewRow();
        dr["RowNumber"] = 1;
        dt.Rows.Add(dr);

        //Store the DataTable in ViewState
        ViewState["CurrentTable1"] = _ds;
        //Bind the DataTable to the Grid
        gvRequirmentDetails.DataSource = _ds;
        gvRequirmentDetails.DataBind();

        DropDownList ddlAppNoReq = (DropDownList)gvRequirmentDetails.Rows[0].Cells[0].FindControl("ddlAppNoReq");//added by suraj for combi product
        DropDownList ddlfollowupcode = (DropDownList)gvRequirmentDetails.Rows[0].Cells[0].FindControl("ddlfollowupcode");
        TextBox txtLoadRider = (TextBox)gvRequirmentDetails.Rows[0].Cells[1].FindControl("lblfollowupDiscp");
        DropDownList ddlCategory = (DropDownList)gvRequirmentDetails.Rows[0].Cells[2].FindControl("ddlCategory");
        DropDownList ddlCriteria = (DropDownList)gvRequirmentDetails.Rows[0].Cells[3].FindControl("ddlCriteria");
        DropDownList ddlLifeType = (DropDownList)gvRequirmentDetails.Rows[0].Cells[4].FindControl("ddlLifeType");
        DropDownList ddlStatus = (DropDownList)gvRequirmentDetails.Rows[0].Cells[5].FindControl("ddlStatus");
        Label lblRaiseddate = (Label)gvRequirmentDetails.Rows[0].Cells[6].FindControl("lblRaiseddate");
        //Label lblRaisedby = (Label)gvRequirmentDetails.Rows[0].Cells[7].FindControl("lblRaisedby");
        Label lblClosedDate = (Label)gvRequirmentDetails.Rows[0].Cells[8].FindControl("lblClosedDate");
        // Label lblClosedBy = (Label)gvRequirmentDetails.Rows[0].Cells[9].FindControl("lblClosedBy");

        //Fill the DropDownList with Data
        //FillDropDownList(ddlLoadType, "LoadingCode", "Mst");
        btnReqaddrows.CssClass = "btn btn-primary";
        BindMasterDetails(ddlAppNoReq);//added by suraj for combi product
        BindMasterDetails(ddlfollowupcode);
        BindMasterDetails(ddlCategory);
        BindMasterDetails(ddlCriteria);
        //BindMasterDetails(ddlLifeType);
        BindMasterDetails(ddlStatus);

    }

    public void PopulateLoadingDetails()
    {
        Logger.Info("STAG 2 :PageName :Uwdecision.aspx.CS // MethodeName :PopulateLoadingDetails" + System.Environment.NewLine);
        DataTable _dtLoaddata = new DataTable();
        DataRow _drRow = null;
        objChangeObj = (ChangeValue)Session["objLoginObj"];
        LoadDtls objLoad = new LoadDtls();
        //51.1 Begin of Changes; Bhaumik Patel - [CR - 3334]
        string _strLoadReason1 = string.Empty;
        string _strLoadReason2 = string.Empty;
        string _strLoadReason3 = string.Empty;
        string _strLoadReason4 = string.Empty;
        string loadrsncode = Request.Form[ddlLoadRsn1.UniqueID];
        //51.1 End of Changes; Bhaumik Patel - [CR - 3334]
        //if (Session["LoadingData"] == null)
        //{
        if (ViewState["LoadingData"] == null)
        {
            _dtLoaddata.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            _dtLoaddata.Columns.Add(new DataColumn("ddlAppNo", typeof(string)));//added by suraj for combi product
            _dtLoaddata.Columns.Add(new DataColumn("ddlLoadType", typeof(string)));
            //51.1 Begin of Changes; Bhaumik Patel - [CR - 3334]
            //_dtLoaddata.Columns.Add(new DataColumn("ddlLoadRsn1", typeof(string)));
            //_dtLoaddata.Columns.Add(new DataColumn("ddlRsn2", typeof(string)));
            _dtLoaddata.Columns.Add(new DataColumn("txtRsn1Desc", typeof(string)));
            _dtLoaddata.Columns.Add(new DataColumn("txtRsn2Desc", typeof(string)));
            _dtLoaddata.Columns.Add(new DataColumn("txtRsn3Desc", typeof(string)));
            _dtLoaddata.Columns.Add(new DataColumn("txtRsn4Desc", typeof(string)));
            //51.1 End of Changes; Bhaumik Patel - [CR - 3334]

            _dtLoaddata.Columns.Add(new DataColumn("txtLoadPer", typeof(string)));
            _dtLoaddata.Columns.Add(new DataColumn("txtRateAdjust", typeof(string)));
            _dtLoaddata.Columns.Add(new DataColumn("ddlLoadFlatMortality", typeof(string)));
            _dtLoaddata.Columns.Add(new DataColumn("RiderName", typeof(string)));
            _dtLoaddata.Columns.Add(new DataColumn("LoadingDiscp", typeof(string)));
            _dtLoaddata.Columns.Add(new DataColumn("LetterPrint", typeof(string)));
            _dtLoaddata.Columns.Add(new DataColumn("ddlLoadCode", typeof(string)));

            //51.1 Begin of Changes; Bhaumik Patel - [CR - 3334]
            //_dtLoaddata.Columns.Add(new DataColumn("Reason1Discp", typeof(string)));
            //_dtLoaddata.Columns.Add(new DataColumn("Reason2Discp", typeof(string)));
            //_dtLoaddata.Columns.Add(new DataColumn("ddlLoadRsn1Code", typeof(string)));
            //_dtLoaddata.Columns.Add(new DataColumn("ddlLoadRsn2Code", typeof(string)));
            //51.1 End of Changes; Bhaumik Patel - [CR - 3334]

            _dtLoaddata.Columns.Add(new DataColumn("RiderCode", typeof(string)));
            _dtLoaddata.Columns.Add(new DataColumn("LoadType", typeof(string)));
            //51.1 Begin of Changes; Bhaumik Patel - [CR - 3334]
            _dtLoaddata.Columns.Add(new DataColumn("Loadrsn1", typeof(string)));
            _dtLoaddata.Columns.Add(new DataColumn("Loadrsn2", typeof(string)));
            _dtLoaddata.Columns.Add(new DataColumn("Loadrsn3", typeof(string)));
            _dtLoaddata.Columns.Add(new DataColumn("Loadrsn4", typeof(string)));
            //51.1 End of Changes; Bhaumik Patel - [CR - 3334]

            _drRow = _dtLoaddata.NewRow();
            _drRow[1] = ddlAppNo.SelectedItem.Text;//added by suraj for combi product
            _drRow[2] = ddlLoadType.SelectedItem.Text;
            //51.1 Begin of Changes; Bhaumik Patel - [CR - 3334]
            //_drRow[2] = ddlLoadRsn1.SelectedItem.Text;
            _drRow[3] = txtRsn1Desc.Text = Request.Form[txtRsn1Desc.UniqueID];
            _drRow[4] = txtRsn2Desc.Text = Request.Form[txtRsn2Desc.UniqueID];
            _drRow[5] = txtRsn3Desc.Text = Request.Form[txtRsn3Desc.UniqueID];
            _drRow[6] = txtRsn4Desc.Text = Request.Form[txtRsn4Desc.UniqueID];
            //_drRow[3] = ddlLoadRsn2.SelectedItem.Text;
            //51.1 End of Changes; Bhaumik Patel - [CR - 3334]

            _drRow[7] = txtLoadPer.Text;
            _drRow[8] = txtRateAdjust.Text;
            _drRow[9] = ddlLoadFlatMortality.SelectedValue;
            _drRow[10] = ddlLoadRiderCode.SelectedValue;
            _drRow[11] = txtLoadDesc.Text;
            //51.1 Begin of Changes; Bhaumik Patel - [CR - 3334]
            //_drRow[10] = txtRsn1Desc.Text;
            // _drRow[11] = txtRsn2Desc.Text;
            //51.1 End of Changes; Bhaumik Patel - [CR - 3334]
            _drRow[12] = ddlLoadletterPrint.SelectedValue;
            _drRow[13] = ddlLoadType.SelectedValue;
            //51.1 Begin of Changes; Bhaumik Patel - [CR - 3334]
            //_drRow[14] = ddlLoadRsn1.SelectedValue;
            //_drRow[15] = ddlLoadRsn2.SelectedValue;
            //51.1 End of Changes; Bhaumik Patel - [CR - 3334]
            _drRow[14] = ddlLoadRiderCode.SelectedValue.ToString().Substring(0, ddlLoadRiderCode.SelectedValue.ToString().Length - 1);//GetData("POLNum");
            _drRow[15] = ddlLoadType.SelectedItem.Text;

            if (!string.IsNullOrEmpty(loadrsncode))
            {
                for (int k = 0; k < loadrsncode.Split(',').Length; k++)
                {
                    if (k == 0)
                    {
                        _strLoadReason1 = loadrsncode.Split(',')[k];
                    }


                    if (k == 1)
                    {
                        _strLoadReason2 = loadrsncode.Split(',')[k];
                    }

                    if (k == 2)
                    {
                        _strLoadReason3 = loadrsncode.Split(',')[k];
                    }


                    if (k == 3)
                    {
                        _strLoadReason4 = loadrsncode.Split(',')[k];
                    }
                }
            }
            else
            {
                _strLoadReason1 = string.Empty;
                _strLoadReason2 = string.Empty;
                _strLoadReason3 = string.Empty;
                _strLoadReason4 = string.Empty;
            }
            _drRow[16] = _strLoadReason1;
            _drRow[17] = _strLoadReason2;
            _drRow[18] = _strLoadReason3;
            _drRow[19] = _strLoadReason4;


            _dtLoaddata.Rows.Add(_drRow);
            //Session["LoadingData"] = _dtLoaddata;
            ViewState["LoadingData"] = _dtLoaddata.Copy();
            gvLoadingDtls.DataSource = _dtLoaddata;
            gvLoadingDtls.DataBind();


            //ddlLoadType.CssClass = "form-control";
            //ddlLoadRsn1.CssClass = "form-control";
            //ddlLoadRsn2.CssClass = "form-control";            
            //txtLoadPer.CssClass = "form-control";
            //txtLoadDesc.CssClass = "form-control";
            //txtRsn1Desc.CssClass = "form-control";
            //txtRsn2Desc.CssClass = "form-control";
            ddlLoadFlatMortality.CssClass = "form-control";
            txtRateAdjust.CssClass = "form-control ";
            ddlLoadletterPrint.CssClass = "form-control";

            ddlLoadType.SelectedValue = "0";
            //51.1 Begin of Changes; Bhaumik Patel - [CR - 3334]
           
            txtRsn1Desc.Text = "";
            txtRsn2Desc.Text = "";
            txtRsn3Desc.Text = "";
            txtRsn4Desc.Text = "";
            //ddlLoadRsn1.SelectedValue = "";
            //ddlLoadRsn2.SelectedValue = "0";
            //txtRsn1Desc.Text = "";
            //txtRsn2Desc.Text = "";
            //51.1 End of Changes; Bhaumik Patel - [CR - 3334]
            ddlLoadFlatMortality.SelectedValue = "0";
            txtLoadPer.Text = "";
            txtLoadDesc.Text = "";
           
            txtRateAdjust.Text = "";
            ddlLoadletterPrint.SelectedValue = "0";
            ddlLoadFlatMortality.SelectedValue = "0";



            updLoadType.Update();
            UpdatePanel3.Update();
            UpdatePanel4.Update();
            UpdatePanel5.Update();


        }
        else
        {
            //_dtLoaddata = (DataTable)Session["LoadingData"];
            _dtLoaddata = (DataTable)ViewState["LoadingData"];
            _drRow = _dtLoaddata.NewRow();
            _drRow[1] = ddlAppNo.SelectedItem.Text;//added by suraj for combi product
            _drRow[2] = ddlLoadType.SelectedItem.Text;
            //51.1 Begin of Changes; Bhaumik Patel - [CR - 3334]k
            //_drRow[2] = ddlLoadRsn1.SelectedItem.Text;
            _drRow[3] = txtRsn1Desc.Text = Request.Form[txtRsn1Desc.UniqueID];
            _drRow[4] = txtRsn2Desc.Text = Request.Form[txtRsn2Desc.UniqueID];
            _drRow[5] = txtRsn3Desc.Text = Request.Form[txtRsn3Desc.UniqueID];
            _drRow[6] = txtRsn4Desc.Text = Request.Form[txtRsn4Desc.UniqueID];
            //_drRow[3] = ddlLoadRsn2.SelectedItem.Text;
            //51.1 End of Changes; Bhaumik Patel - [CR - 3334]
            _drRow[7] = txtLoadPer.Text;
            _drRow[8] = txtRateAdjust.Text;
            _drRow[9] = ddlLoadFlatMortality.SelectedValue;
            _drRow[10] = ddlLoadRiderCode.SelectedValue;
            _drRow[11] = txtLoadDesc.Text;
            //51.1 Begin of Changes; Bhaumik Patel - [CR - 3334]
            //_drRow[10] = txtRsn1Desc.Text;
            //_drRow[11] = txtRsn2Desc.Text;
            //51.1 End of Changes; Bhaumik Patel - [CR - 3334]k
            _drRow[12] = ddlLoadletterPrint.SelectedValue;
            _drRow[13] = ddlLoadType.SelectedValue;
            //51.1 Begin of Changes; Bhaumik Patel - [CR - 3334]k
            //_drRow[15] = ddlLoadRsn1.SelectedValue;
            //_drRow[16] = ddlLoadRsn2.SelectedValue;
            //51.1 End of Changes; Bhaumik Patel - [CR - 3334]k
            _drRow[14] = ddlLoadRiderCode.SelectedValue.ToString().Substring(0, ddlLoadRiderCode.SelectedValue.ToString().Length - 1);//GetData("POLNum");
            _drRow[15] = ddlLoadType.SelectedItem.Text;
            //51.1 Begin of Changes; Bhaumik Patel - [CR - 3334]
            if (!string.IsNullOrEmpty(loadrsncode))
            {
                for (int k = 0; k < loadrsncode.Split(',').Length; k++)
                {
                    if (k == 0)
                    {
                        _strLoadReason1 = loadrsncode.Split(',')[k];
                    }


                    if (k == 1)
                    {
                        _strLoadReason2 = loadrsncode.Split(',')[k];
                    }

                    if (k == 2)
                    {
                        _strLoadReason3 = loadrsncode.Split(',')[k];
                    }


                    if (k == 3)
                    {
                        _strLoadReason4 = loadrsncode.Split(',')[k];
                    }
                }
            }
            else
            {
                _strLoadReason1 = string.Empty;
                _strLoadReason2 = string.Empty;
                _strLoadReason3 = string.Empty;
                _strLoadReason4 = string.Empty;
            }
            _drRow[16] = _strLoadReason1;
            _drRow[17] = _strLoadReason2;
            _drRow[18] = _strLoadReason3;
            _drRow[19] = _strLoadReason4;
            //51.1 End of Changes; Bhaumik Patel - [CR - 3334]
            _dtLoaddata.Rows.Add(_drRow);
            // Session["LoadingData"] = _dtLoaddata;
            ViewState["LoadingData"] = _dtLoaddata.Copy();
            gvLoadingDtls.DataSource = _dtLoaddata;
            gvLoadingDtls.DataBind();


            //ddlLoadType.CssClass = "form-control";
            //ddlLoadRsn1.CssClass = "form-control";
            //ddlLoadRsn2.CssClass = "form-control";
            //ddlLoadFlatMortality.CssClass = "form-control";
            //txtLoadPer.CssClass = "form-control";
            //txtLoadDesc.CssClass = "form-control";
            //txtRsn1Desc.CssClass = "form-control";
            //txtRsn2Desc.CssClass = "form-control";
            //txtRateAdjust.CssClass = "form-control";

            ddlLoadFlatMortality.CssClass = "form-control";
            txtRateAdjust.CssClass = "form-control";
            ddlLoadletterPrint.CssClass = "form-control";

            ddlLoadType.SelectedValue = "0";
            //51.1 Begin of Changes; Bhaumik Patel - [CR - 3334]
            //ddlLoadRsn1.SelectedValue = "";
            txtRsn1Desc.Text = "";
            txtRsn2Desc.Text = "";
            txtRsn3Desc.Text = "";
            txtRsn4Desc.Text = "";
            // ddlLoadRsn2.SelectedValue = "0";
            //51.1 End of Changes; Bhaumik Patel - [CR - 3334]
            ddlLoadFlatMortality.SelectedValue = "0";
            txtLoadPer.Text = "";
            txtLoadDesc.Text = "";
            //51.1 Begin of Changes; Bhaumik Patel - [CR - 3334]
            //txtRsn1Desc.Text = "";
            // txtRsn2Desc.Text = "";
            //51.1 End of Changes; Bhaumik Patel - [CR - 3334]
            txtRateAdjust.Text = "";
            ddlLoadFlatMortality.SelectedValue = "0";
            ddlLoadletterPrint.SelectedValue = "0";

            updLoadType.Update();
            UpdatePanel3.Update();
            UpdatePanel4.Update();
            UpdatePanel5.Update();
        }
        if (gvLoadingDtls.Rows.Count > 0)
        {

            //hdnIsConsentReq.Value = response.ToString();
            if (objChangeObj.Load_Loadingdetails == null)
                objChangeObj.Load_Loadingdetails = new LoadDtls();
            objLoad._strProdcode = objChangeObj.Load_Loadingdetails._strProdcode;
            objLoad.isConsentRequired = true;
            objChangeObj.Load_Loadingdetails = objLoad;
            Session["objLoginObj"] = objChangeObj;
        }
        else
        {
            objChangeObj.Load_Loadingdetails.isConsentRequired = false;
        }
        Session["objLoginObj"] = objChangeObj;
    }

    private void SetInitialLoadingGrid()
    {
        Logger.Info("STAG 2 :PageName :Uwdecision.aspx.CS // MethodeName :SetInitialLoadingGrid" + System.Environment.NewLine);
        DataTable dt = new DataTable();
        DataRow dr = null;
        if (ViewState["LoadingView"] != null)
        {

            //Define the Columns
            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("ddlLoadType", typeof(string)));
            dt.Columns.Add(new DataColumn("ddlLoadRsn1", typeof(string)));
            dt.Columns.Add(new DataColumn("ddlRsn2", typeof(string)));
            dt.Columns.Add(new DataColumn("txtLoadPer", typeof(string)));
            dt.Columns.Add(new DataColumn("txtRateAdjust", typeof(string)));
            dt.Columns.Add(new DataColumn("ddlLoadFlatMortality", typeof(string)));
            //dt.Columns.Add(new DataColumn("ddlLoadletterPrint", typeof(string)));


            //Add a Dummy Data on Initial Load
            dr = dt.NewRow();

            dt.Rows.Add(dr);

            //Store the DataTable in ViewState

            //Bind the DataTable to the Grid
            gvLoadingDtls.DataSource = dt;
            gvLoadingDtls.DataBind();

            Label lblLoadType = (Label)gvLoadingDtls.Rows[0].Cells[0].FindControl("lblLoadType");
            Label lblLoadRsn1 = (Label)gvLoadingDtls.Rows[0].Cells[0].FindControl("lblLoadRsn1");
            Label lblLoadRsn2 = (Label)gvLoadingDtls.Rows[0].Cells[0].FindControl("lblLoadRsn2");
            Label lblLoadper = (Label)gvLoadingDtls.Rows[0].Cells[0].FindControl("lblLoadper");
            Label lblRateAdjust = (Label)gvLoadingDtls.Rows[0].Cells[0].FindControl("lblRateAdjust");
            Label lblFlatMortality = (Label)gvLoadingDtls.Rows[0].Cells[0].FindControl("lblFlatMortality");

            lblLoadType.Text = ddlLoadType.SelectedItem.Text;
            lblLoadRsn1.Text = ddlLoadRsn1.SelectedItem.Text;
            //lblLoadRsn2.Text = ddlLoadRsn2.SelectedItem.Text;
            lblLoadper.Text = txtLoadPer.Text;
            lblRateAdjust.Text = txtRateAdjust.Text;
            lblFlatMortality.Text = ddlLoadFlatMortality.SelectedValue;
            ViewState["LoadingView"] = dt;
            //TextBox txtLoadRider = (TextBox)gvLoadingDtls.Rows[0].Cells[0].FindControl("txtLoadRider");
            //DropDownList ddlLoadType = (DropDownList)gvLoadingDtls.Rows[0].Cells[1].FindControl("ddlLoadType");
            //TextBox txtLoadDesc = (TextBox)gvLoadingDtls.Rows[0].Cells[2].FindControl("txtLoadDesc");
            //DropDownList ddlLoadRsn1 = (DropDownList)gvLoadingDtls.Rows[0].Cells[3].FindControl("ddlLoadRsn1");
            //TextBox txtRsn1Desc = (TextBox)gvLoadingDtls.Rows[0].Cells[4].FindControl("txtRsn1Desc");
            //DropDownList ddlRsn2 = (DropDownList)gvLoadingDtls.Rows[0].Cells[5].FindControl("ddlRsn2");
            //TextBox txtRsnDesc = (TextBox)gvLoadingDtls.Rows[0].Cells[6].FindControl("txtRsn2Desc");
            //TextBox txtLoadPer = (TextBox)gvLoadingDtls.Rows[0].Cells[7].FindControl("txtLoadPer");
            //TextBox txtRateAdjust = (TextBox)gvLoadingDtls.Rows[0].Cells[8].FindControl("txtRateAdjust");
            //DropDownList ddlLoadFlatMortality = (DropDownList)gvLoadingDtls.Rows[0].Cells[9].FindControl("ddlLoadFlatMortality");
            //DropDownList ddlLoadletterPrint = (DropDownList)gvLoadingDtls.Rows[0].Cells[10].FindControl("ddlLoadletterPrint");

            //Fill the DropDownList with Data
            //FillDropDownList(ddlLoadType, "LoadingCode", "Mst");
            //txtLoadRider.Text = txtProname.Text;
            //txtLoadRider.Enabled = false;
            //BindMasterDetails(ddlLoadType);
            //BindMasterDetails(ddlLoadFlatMortality);
        }
        else
        {
            dt = (DataTable)ViewState["LoadingView"];
            dr = dt.NewRow();
            dt.Rows.Add(dr);
            ViewState["LoadingView"] = dt;
            //Bind the DataTable to the Grid
            gvLoadingDtls.DataSource = dt;
            gvLoadingDtls.DataBind();

            Label lblLoadType = (Label)gvLoadingDtls.Rows[0].Cells[0].FindControl("lblLoadType");
            Label lblLoadRsn1 = (Label)gvLoadingDtls.Rows[0].Cells[0].FindControl("lblLoadRsn1");
            Label lblLoadRsn2 = (Label)gvLoadingDtls.Rows[0].Cells[0].FindControl("lblLoadRsn2");
            Label lblLoadper = (Label)gvLoadingDtls.Rows[0].Cells[0].FindControl("lblLoadper");
            Label lblRateAdjust = (Label)gvLoadingDtls.Rows[0].Cells[0].FindControl("lblRateAdjust");
            Label lblFlatMortality = (Label)gvLoadingDtls.Rows[0].Cells[0].FindControl("lblFlatMortality");

            lblLoadType.Text = ddlLoadType.SelectedItem.Text;
            lblLoadRsn1.Text = ddlLoadRsn1.SelectedItem.Text;
            //lblLoadRsn2.Text = ddlLoadRsn2.SelectedItem.Text;
            lblLoadper.Text = txtLoadPer.Text;
            lblRateAdjust.Text = txtRateAdjust.Text;
            lblFlatMortality.Text = ddlLoadFlatMortality.SelectedValue;
        }
    }

    private void SetPreviousData1()
    {
        Logger.Info("STAG 2 :PageName :Uwdecision.aspx.CS // MethodeName :SetPreviousData1" + System.Environment.NewLine);
        int rowIndex = 0;
        if (ViewState["CurrentTable1"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable1"];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count - 1; i++)
                {
                    DropDownList ddlAppNoReq = (DropDownList)gvRequirmentDetails.Rows[i].Cells[0].FindControl("ddlAppNoReq");//added by suraj for combi product
                    DropDownList ddlfollowupcode = (DropDownList)gvRequirmentDetails.Rows[i].Cells[0].FindControl("ddlfollowupcode");
                    TextBox lblfollowupDiscp = (TextBox)gvRequirmentDetails.Rows[i].Cells[1].FindControl("lblfollowupDiscp");
                    DropDownList ddlCategory = (DropDownList)gvRequirmentDetails.Rows[i].Cells[2].FindControl("ddlCategory");
                    DropDownList ddlCriteria = (DropDownList)gvRequirmentDetails.Rows[i].Cells[3].FindControl("ddlCriteria");
                    DropDownList ddlLifeType = (DropDownList)gvRequirmentDetails.Rows[i].Cells[4].FindControl("ddlLifeType");
                    DropDownList ddlStatus = (DropDownList)gvRequirmentDetails.Rows[i].Cells[5].FindControl("ddlStatus");
                    Label lblRaiseddate = (Label)gvRequirmentDetails.Rows[i].Cells[6].FindControl("lblRaiseddate");
                    //Label lblRaisedby = (Label)gvRequirmentDetails.Rows[i].Cells[7].FindControl("lblRaisedby");
                    Label lblClosedDate = (Label)gvRequirmentDetails.Rows[i].Cells[7].FindControl("lblClosedDate");
                    //Label lblClosedBy = (Label)gvRequirmentDetails.Rows[i].Cells[9].FindControl("lblClosedBy");

                    //Fill the DropDownList with Data
                    //FillDropDownList(ddlfollowupcode, "followupcode", "Mst");
                    BindMasterDetails(ddlfollowupcode);

                    if (i < dt.Rows.Count - 1)
                    {
                        ddlAppNoReq.SelectedValue = dt.Rows[i]["REQ_APPLICATIONNOSTR"].ToString();//added by suraj for combi product
                        ddlfollowupcode.ClearSelection();
                        ddlfollowupcode.Items.FindByText(dt.Rows[i]["REQ_followUpCode"].ToString()).Selected = true;
                        ddlfollowupcode.SelectedValue = dt.Rows[i]["REQ_followUpCode"].ToString();
                        lblfollowupDiscp.Text = dt.Rows[i]["REQ_description"].ToString();
                        ddlCategory.SelectedValue = dt.Rows[i]["REQ_category"].ToString();
                        ddlCriteria.SelectedValue = dt.Rows[i]["REQ_criteria"].ToString();
                        ddlLifeType.SelectedValue = dt.Rows[i]["REQ_lifeType"].ToString();
                        ddlStatus.SelectedValue = dt.Rows[i]["REQ_status"].ToString();
                        lblRaiseddate.Text = dt.Rows[i]["REQ_RaisedDate"].ToString();
                        //lblRaisedby.Text = dt.Rows[i]["lblRaisedby"].ToString();
                        lblClosedDate.Text = dt.Rows[i]["REQ_ClosedDate"].ToString();
                        //lblClosedBy.Text = dt.Rows[i]["lblClosedBy"].ToString();
                    }
                    rowIndex++;
                }
            }
            //LinkButton lnkReqRemoveRow = (LinkButton)gvRequirmentDetails.Rows[dt.Rows.Count - 1].Cells[6].FindControl("lnkReqRemoveRow");
            //lnkReqRemoveRow.CssClass = "";
            btnReqaddrows.CssClass = "btn btn-primary";
            gvRequirmentDetails.CssClass = "table table-bordered table-striped";
            UpdatePanel1.Update();
        }
    }

    private ArrayList GetDummyData(string ddlType, string ddlsubtype)
    {
        Logger.Info("STAG 2 :PageName :Uwdecision.aspx.CS // MethodeName :GetDummyData" + System.Environment.NewLine);
        ArrayList arr = new ArrayList();
        DataSet dt12 = new DataSet();
        FillSubMasterDetails(ref dt12, null, ddlType, ddlsubtype);

        if (dt12.Tables[0].Rows.Count > 0)
        {
            arr.Add(new ListItem("Select", "0"));
            foreach (DataRow row in dt12.Tables[0].Rows)
            {
                arr.Add(new ListItem(row["REQ_followUpCode"].ToString(), row["REQ_followUpCode"].ToString()));
            }
        }
        return arr;


    }

    public void BindMasterDetails(DropDownList ddl)
    {
        Logger.Info("STAG 2 :PageName :Uwdecision.aspx.CS // MethodeName :BindMasterDetails" + System.Environment.NewLine);
        string strTableName = ddl.ID;
        if (strTableName == "ddlExstingLoadType")
        {
            strTableName = "ddlLoadType";
        }
        //51.1 Begin of Changes; Bhaumik Patel - [CR - 3334]
        else if (strTableName == "ddlExistingLoadRsn1")
        {

            //strTableName = "ddlLoadRsn1";
        }
        else if (strTableName == "ddlExistingLoadRsn2")
        {
            // strTableName = "ddlLoadRsn2";
        }
        //51.1 End of Changes; Bhaumik Patel - [CR - 3334]
        else if (strTableName == "ddlExistingLoadFlatMort")
        {
            strTableName = "ddlLoadFlatMortality";
        }
        else if (strTableName == "ddlCommonStatus")
        {
            strTableName = "ddlStatus";
        }
        /*ID:10 START*/
        else if (strTableName == "ddlApplicationDetailsProposalType")
        {
            strTableName = "ddlProposalType";
        }
        /*ID:10 END*/
        //Added by Suraj on 25 APRIL 2018
        else if (strTableName == "ddlAssigmentType")
        {
            strTableName = "ddlAssigmentType";
        }
        //Added by Suraj on 18 APRIL 2018 for medical reson dropdown 
        else if (strTableName == "ddlRequirementMedicalReason")
        {
            strTableName = "ddlRequirementMedicalReason";
        }
        //Added by Suraj on 19 APRIL 2018 for close file review question's answer 
        else if (strTableName == "ddlAnswer")
        {
            strTableName = "ddlAnswer";
        }
        //Added by Suraj on 05 JULY 2018 for add country list
        else if (strTableName == "ddlcountry")
        {
            strTableName = "ddlcountry";
        }
        //Added by Suraj on 25 JULY 2019 for signature match flag
        else if (strTableName == "ddlSignature")
        {
            strTableName = "ddlSignature";
        }
        //Added by Brijesh CR 27524 for ddlRsnExcessPremium
        else if (strTableName == "ddlRelationStaff")
        {
            strTableName = "ddlRelationStaff";
        }
        //end
        DataSet _dsMaster = (DataSet)ViewState["_dsFollowuo"];
        ArrayList arr = new ArrayList();
        if (_dsMaster != null && _dsMaster.Tables.Count > 0)
        {
            if (_dsMaster.Tables[strTableName] != null && _dsMaster.Tables[strTableName].Rows.Count > 0)
            {
                //48.1 Begin of Changes; Bhaumik Patel - [CR-5307]
                if (strTableName == "ddlUWDecesion")
                {
                    DataSet ds = new DataSet();
                    commobj.OnlineDecisionRightsDisplayDetails_GET("GetUserAccess_DecisionRights", strUserId,UserLimit, ref ds);
                    ddl.DataSource = ds.Tables[strTableName];
                    ddl.DataTextField = "NAME";
                    ddl.DataValueField = "VALUE";
                    ddl.DataBind();
                    ddl.Items.Insert(0, new ListItem("--Select--", "0"));
                    //ddlUWDecesion.SelectedValue = "proposal";
                }
                   //48.1 End of Changes; Bhaumik Patel - [CR-5307]
                    //47.1 Begin of Changes; Bhaumik Patel - [CR-5855]
               else if (strTableName == "ddlLoadFlatMortality")
                {
                    DataSet ds = new DataSet();
                    commobj.OnlineFlatMortalityDetails_GET("GetFlatMortalityData_BIND", strUserId, ref ds);
                    ddl.DataSource = ds.Tables[strTableName];
                    ddl.DataTextField = "NAME";
                    ddl.DataValueField = "VALUE";
                    ddl.DataBind();
                    ddl.Items.Insert(0, new ListItem("--Select--", "0"));
                }
                //47.1 END of Changes; Bhaumik Patel - [CR-5855]
                else
                {
                    ddl.DataSource = _dsMaster.Tables[strTableName];
                    ddl.DataTextField = "NAME";
                    ddl.DataValueField = "VALUE";
                    ddl.DataBind();
                    ddl.Items.Insert(0, new ListItem("--Select--", "0"));
                }
            }
        }
        //added by suraj for combi
        DataTable dt = new DataTable();
        dt = (DataTable)Session["AppNos"];
        if (strTableName == "ddlAppNoReq" && dt != null && dt.Rows.Count > 0)
        {
            ddl.DataSource = dt;
            ddl.DataTextField = "NAME";
            ddl.DataValueField = "VALUE";
            ddl.DataBind();
            //ddl.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        //end
    }
    private void FillDropDownList(DropDownList ddl, string ddlType, string ddlsubtype)
    {
        Logger.Info("STAG 2 :PageName :Uwdecision.aspx.CS // MethodeName :FillDropDownList" + System.Environment.NewLine);
        ArrayList arr = GetDummyData(ddlType, ddlsubtype);
        foreach (ListItem item in arr)
        {
            ddl.Items.Add(item);
        }
    }
    public void ShowHideLoader(string LoadingType, string strEvent)
    {
        Logger.Info("STAG 2 :PageName :Uwdecision.aspx.CS // MethodeName :ShowHideLoader" + System.Environment.NewLine);
        string script = "ldrModal.show()";
        if (LoadingType == "Show")
        {
            //string strValidationMsg = "alert('Request is Accepted')";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", script, true);
            //ClientScript.RegisterStartupScript(this.GetType(), LoadingType, script, true);
        }
        else
        {
            Page.ClientScript.RegisterOnSubmitStatement(this.GetType(), LoadingType, "ldrModal.fadeOut()");
        }
    }
    #region Page Events Begins.


    //protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        //Find the DropDownList in the Row
    //        DropDownList ddlfollowupcode = (e.Row.FindControl("ddlfollowupcode") as DropDownList);
    //        ddlfollowupcode.DataSource = _dsFollowuo.Tables[0];
    //        ddlfollowupcode.DataTextField = "REQ_followUpCode";
    //        ddlfollowupcode.DataValueField = "REQ_followUpCode";
    //        ddlfollowupcode.DataBind();

    //        //Add Default Item in the DropDownList
    //        ddlfollowupcode.Items.Insert(0, new ListItem("Please select"));

    //        //Select the Country of Customer in DropDownList
    //        //string country = (e.Row.FindControl("lblCountry") as Label).Text;
    //        //ddlCountries.Items.FindByValue(country).Selected = true;
    //    }
    //}
    protected void ddlfollowupcode_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Logger.Info("STAG 2 :PageName :Uwdecision.aspx.CS // MethodeName :ddlfollowupcode_SelectedIndexChanged");
            DataSet _dsFollowupSubDtls = new DataSet();
            // Get the master DropDownList and its value
            DropDownList ddlEditEducationEstablishment = (DropDownList)sender;
            string educationEstablishmentCode = ddlEditEducationEstablishment.SelectedValue;
            // Get the GridViewRow in which this master DropDownList exists

            //37.1 Begin of Changes; Sagar Thorave-[mfl00886]
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable1"];

            for (int i = 0; i < dtCurrentTable.Rows.Count - 1; i++)
            {
                //extract the DropDownList Selected Items
                string REQ_followUpCode = dtCurrentTable.Rows[i]["REQ_followUpCode"].ToString();
                NotSelectMerCheckbox(REQ_followUpCode);
            }
            for (int i = 0; i < dtCurrentTable.Rows.Count - 1; i++)
            {
                string REQ_followUpCode = dtCurrentTable.Rows[i]["REQ_followUpCode"].ToString();
                SelectMerCheckbox(REQ_followUpCode);
            }
            SelectMerCheckbox(educationEstablishmentCode);
            //37.1 End of Changes; Sagar Thorave-[mfl00886]

            GridViewRow row = (GridViewRow)ddlEditEducationEstablishment.NamingContainer;
            DropDownList ddlEditSchool = (DropDownList)row.FindControl("ddlfollowupcode");
            FillSubMasterDetails(ref _dsFollowupSubDtls, educationEstablishmentCode, "followupcode", "");
            if (_dsFollowupSubDtls.Tables.Count > 0 && _dsFollowupSubDtls.Tables[0].Rows.Count > 0)
            {
                TextBox lblfollowupDiscp = (TextBox)row.FindControl("lblfollowupDiscp");
                lblfollowupDiscp.Text = _dsFollowupSubDtls.Tables[0].Rows[0]["Followupdescp"].ToString();

                DropDownList ddlCategory = (DropDownList)row.FindControl("ddlCategory");
                ddlCategory.SelectedValue = _dsFollowupSubDtls.Tables[0].Rows[0]["Category"].ToString();


                DropDownList ddlCriteria = (DropDownList)row.FindControl("ddlCriteria");
                ddlCriteria.SelectedValue = _dsFollowupSubDtls.Tables[0].Rows[0]["Criteria"].ToString();

                DropDownList ddlLifeType = (DropDownList)row.FindControl("ddlLifeType");
                ddlLifeType.SelectedValue = _dsFollowupSubDtls.Tables[0].Rows[0]["LifeType"].ToString();

                if (_dsFollowupSubDtls.Tables[0].Rows[0]["Criteria"].ToString() == "Text to be Appended")
                {
                    //lblfollowupDiscp.Enabled = true;
                    lblfollowupDiscp.CssClass = "form-control";
                }
                else
                {
                    lblfollowupDiscp.CssClass = "form-control lblLable";
                }
                UpdatePanel1.Update();
            }
        }
        catch (Exception Error)
        {
            objcomm.SaveErrorLogs("", "Failed", "UWPortfolio", "ddlfollowupcode_SelectedIndexChanged", "UWPortfolio", "E-Error", "", "", Error.ToString());
        }


    }

    protected void gvRequirmentDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            int ReqCount = Convert.ToInt16(Session["ReqCount"]);
            Logger.Info("STAG 2 :PageName :Uwdecision.aspx.CS // MethodeName :gvRequirmentDetails_RowDataBound");
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //added by suraj for combi product
                DropDownList ddlAppNoReq = (DropDownList)e.Row.FindControl("ddlAppNoReq");
                BindMasterDetails(ddlAppNoReq);
                //end

                DropDownList ddlfollowupcode = (DropDownList)e.Row.FindControl("ddlfollowupcode");
                BindMasterDetails(ddlfollowupcode);

                DropDownList ddl1 = (DropDownList)e.Row.FindControl("ddlfollowupcode");
                BindMasterDetails(ddl1);

                DropDownList ddlCategory = (DropDownList)e.Row.FindControl("ddlCategory");
                BindMasterDetails(ddlCategory);

                DropDownList ddlCriteria = (DropDownList)e.Row.FindControl("ddlCriteria");
                BindMasterDetails(ddlCriteria);

                DropDownList ddlStatus = (DropDownList)e.Row.FindControl("ddlStatus");
                BindMasterDetails(ddlStatus);
                //FillDropDownList(ddl1, "followupcode", "Mst");
                _Dt = (DataTable)ViewState["CurrentTable1"];
                if (_Dt.Rows.Count >= 1)
                {
                    //LinkButton lb = e.Row.FindControl("lnkReqRemoveRow") as LinkButton;
                    //ScriptManager.GetCurrent(this).RegisterAsyncPostBackControl(lb);

                    //Image ing = e.Row.FindControl("Image8") as Image;
                    ddlAppNoReq.SelectedValue = _Dt.Rows[e.Row.RowIndex]["REQ_APPLICATIONNOSTR"].ToString();//added by suraj for combi product

                    //DropDownList ddlfollowupcode = (DropDownList)e.Row.FindControl("ddlfollowupcode");
                    ddlfollowupcode.SelectedValue = _Dt.Rows[e.Row.RowIndex]["REQ_followUpCode"].ToString();
                    //37.1 Begin of Changes; Sagar Thorave-[mfl00886]
                    SelectMerCheckbox(ddlfollowupcode.SelectedValue);
                    //37.1 End of Changes; Sagar Thorave-[mfl00886]
                    TextBox lblfollowupDiscp = (TextBox)e.Row.FindControl("lblfollowupDiscp");
                    lblfollowupDiscp.Text = _Dt.Rows[e.Row.RowIndex]["REQ_description"].ToString();

                    //DropDownList ddlCategory = (DropDownList)e.Row.FindControl("ddlCategory");
                    ddlCategory.SelectedValue = _Dt.Rows[e.Row.RowIndex]["REQ_category"].ToString();

                    //DropDownList ddlCriteria = (DropDownList)e.Row.FindControl("ddlCriteria");
                    ddlCriteria.SelectedValue = _Dt.Rows[e.Row.RowIndex]["REQ_criteria"].ToString();

                    DropDownList ddlLifeType = (DropDownList)e.Row.FindControl("ddlLifeType");
                    ddlLifeType.SelectedValue = _Dt.Rows[e.Row.RowIndex]["REQ_lifeType"].ToString();

                    Label lblRaiseddate = (Label)e.Row.FindControl("lblRaiseddate");
                    lblRaiseddate.Text = _Dt.Rows[e.Row.RowIndex]["REQ_RaisedDate"].ToString();

                    //Label lblRaisedby = (Label)e.Row.FindControl("lblRaisedby ");
                    //lblRaisedby.Text = _Dt.Rows[e.Row.RowIndex]["lblRaisedby "].ToString();

                    Label lblClosedDate = (Label)e.Row.FindControl("lblClosedDate");
                    lblClosedDate.Text = _Dt.Rows[e.Row.RowIndex]["REQ_ClosedDate"].ToString();

                    //Label lblClosedBy = (Label)e.Row.FindControl("lblClosedBy");
                    //lblClosedBy.Text = _Dt.Rows[e.Row.RowIndex]["lblClosedBy"].ToString();

                    if (ddlCategory.SelectedValue == "Medical")
                    {
                        DataSet dsREq = new DataSet();
                        objComm.GET_MedicalReportoShow(ref dsREq, strApplicationno);
                        if (dsREq.Tables.Count > 0 && dsREq.Tables[0].Rows.Count > 0)
                        {
                            ddlRequirementMedicalReason.SelectedValue = Convert.ToString(dsREq.Tables[0].Rows[0]["ReqMedicalReason"]);
                        }

                    }

                    //DropDownList ddlStatus = (DropDownList)e.Row.FindControl("ddlStatus");
                    ddlStatus.SelectedValue = _Dt.Rows[e.Row.RowIndex]["REQ_status"].ToString();

                    //Added by Suraj on 19 APRIL 2018 for medical reason dropdown

                    //if (e.Row.RowIndex >= ReqCount)
                    //{
                    //    Image Img = (Image)e.Row.FindControl("Image8");
                    //    Img.CssClass = "";
                    //}
                    //else
                    //{
                    //    Image Img = (Image)e.Row.FindControl("Image8");
                    //    Img.CssClass = "HideControl";
                    //}
                    //CR-26885 Start Kavita 26/02/2020
                    #region CR-26885
                    if (ddlfollowupcode.SelectedValue == "PRE")
                    {
                        if (ddlStatus.SelectedValue != "O" && ddlStatus.SelectedValue != "L" && ddlStatus.SelectedValue != "W")
                        {
                            lblInvest.Visible = true;
                            ddlInvestigationReport.Visible = true;
                            ddlInvestigationReport.Enabled = true;
                            Session["CheckPREStatus"] = ddlStatus.SelectedValue.ToString();
                        }
                        else
                        {
                            Session["CheckPREStatus"] = "";
                            lblInvest.Visible = false;
                            ddlInvestigationReport.Visible = false;
                            ddlInvestigationReport.Enabled = false;
                        }
                    }
                    #endregion CR-26885

                    //CR-26885 End

                    //CR-27523 Start Kavita 05/05/2020
                    #region CR-27523
                    if (ddlfollowupcode.SelectedValue == "PRE")
                    {
                        if (ddlStatus.SelectedValue != "O" && ddlStatus.SelectedValue != "L")
                        {
                            lblRiskInve.Visible = true;
                            ddlRiskInvestDecision.Visible = true;
                            ddlRiskInvestDecision.Enabled = true;
                            Session["CheckdecStatus"] = ddlStatus.SelectedValue.ToString();
                        }
                        else
                        {
                            Session["CheckdecStatus"] = "";
                            lblRiskInve.Visible = false;
                            ddlRiskInvestDecision.Visible = false;
                            ddlRiskInvestDecision.Enabled = false;
                        }
                    }
                    #endregion CR-27523

                    //CR-27523 End
                }

            }
        }
        catch (Exception Error)
        {
            objcomm.SaveErrorLogs("", "Failed", "UWPortfolio", "gvRequirmentDetails_RowDataBound", "UWPortfolio", "E-Error", "", "", Error.ToString());
        }
    }

    protected void btnRequirmentDtlsSave_Click(object sender, EventArgs e)
    {
        Logger.Info("STAG 2 :PageName :Uwdecision.aspx.CS // MethodeName :btnRequirmentDtlsSave_Click");
        string _strfollowupcode = string.Empty;
        string _strfollowupdiscp = string.Empty;
        string _strfollowupcategory = string.Empty;
        string _strfollowupcriteria = string.Empty;
        string _strfollowuplifetype = string.Empty;
        string _strfollowupstatus = string.Empty;
        int strFollowupResult = 0;
        bool _FollowupStatus = false;
        bool _strFolloUPflag = true;
        lblErrorRequirementDetailBody.Text = lblErrorreqdtls.Text = string.Empty;
        // objCommonObj = (CommonObject)Session["objCommonObj"];
        objChangeObj = (ChangeValue)Session["objLoginObj"];
        foreach (GridViewRow rowfollowup in gvRequirmentDetails.Rows)
        {
            DropDownList ddlfollowupcode = rowfollowup.FindControl("ddlfollowupcode") as DropDownList;
            DropDownList ddlCategory = rowfollowup.FindControl("ddlCategory") as DropDownList;
            DropDownList ddlCriteria = rowfollowup.FindControl("ddlCriteria") as DropDownList;
            DropDownList ddlStatus = rowfollowup.FindControl("ddlStatus") as DropDownList;
            DropDownList ddlLifeType = rowfollowup.FindControl("ddlLifeType") as DropDownList;
            TextBox lblfollowupDiscp = rowfollowup.FindControl("lblfollowupDiscp") as TextBox;
            _strfollowupcode = ddlfollowupcode.SelectedValue;
            _strfollowupcategory = ddlCategory.SelectedValue;
            _strfollowupcriteria = ddlCriteria.SelectedValue;
            _strfollowuplifetype = ddlLifeType.SelectedValue;
            _strfollowupstatus = ddlStatus.SelectedValue;
            _strfollowupdiscp = lblfollowupDiscp.Text;
            if (_strfollowupstatus == "O")
            {
                _FollowupStatus = true;
            }
            objBuss.FollowupDetails_Save(strChannelType, strApplicationno, _strfollowupcode, _strfollowupdiscp, _strfollowupcategory, _strfollowupcriteria, "", objChangeObj.userLoginDetails._UserID, _strfollowupstatus,
                _strfollowupcategory, _strfollowuplifetype, objChangeObj.userLoginDetails._UserID, objChangeObj.userLoginDetails._UserName, objChangeObj.userLoginDetails._UserGroup, objChangeObj.userLoginDetails._userBranch, objChangeObj.userLoginDetails._userBranch, strChannelType, strApplicationno, ref strFollowupResult);
            if (strFollowupResult == 0)
            {
                _strFolloUPflag = false;
            }
        }
        if (_strFolloUPflag)
        {
            chkReqDtls.Checked = false;
            lblErrorreqdtls.Text = "Requirment details save successfully";
            objUWDecision.OnlineApplicationLAServiceDetails_PUSH(strApplicationno, strChannelType, objChangeObj, ref _ds, ref _dsPrevPol, "FOLLOWUP", ref strLApushErrorCode, ref strLApushStatus, ref strConsentRespons);
            if (strLApushErrorCode == 0)
            {
                if (_FollowupStatus == true)
                {
                    //objCommonObj = (CommonObject)Session["objCommonObj"];
                    // strUserId = objCommonObj._Bpmuserdetails._UserID;
                    // strApplicationno = objCommonObj._ApplicationNo;
                    //strUserGroup = objCommonObj._Bpmuserdetails._UserGroup;
                    objChangeObj = (ChangeValue)Session["objLoginObj"];
                    strUserGroup = objChangeObj.userLoginDetails._UserGroup;
                    //strAppstatusKey = (strUserGroup == "UW") ? "UR" : "DR";
                    strAppstatusKey = (strUserGroup == "UW") ? "UR" : "DR";
                    objComm.OnlineApplicationchangeStatus(strApplicationno, objChangeObj.userLoginDetails._UserID, strAppstatusKey, "", ref strFollowupResult);
                }
                chkReqDtls.Checked = false;
                btnReqaddrows.CssClass = "btn-primary HideControl";
                lblErrorreqdtls.Text = "Requirment Details Updated in Life Asia successfully";
                lblErrorRequirementDetailBody.Text = "Requirment Details Updated in Life Asia successfully";
                FillRequirmentDetails(strApplicationno, strChannelType);
            }
            else
            {
                chkReqDtls.Checked = false;
                lblErrorreqdtls.Text = "Requirment Details Not Updated in Life Asia,Please Contact system admin";
                lblErrorRequirementDetailBody.Text = strLApushStatus;
            }
        }
        else
        {
            chkReqDtls.Checked = false;
            lblErrorRequirementDetailBody.Text = "Requirment details Not Updated in DataBase";
            lblErrorreqdtls.Text = "Requirment details Not Save CLICK to know more";
        }
    }

    protected void btnReqaddrows_Click(object sender, EventArgs e)
    {
        try
        {
            /*added by shri on 28 dec 17 to add tracking*/
            int intTrackingRet = -1;
            objCommonObj = (CommonObject)Session["objCommonObj"];
            strUserId = objCommonObj._Bpmuserdetails._UserID;
            InsertUwDecisionTracking(strApplicationno, strUserId, DateTime.Now, "REQ_ADD_NEW_ROW", ref intTrackingRet);
            /*end here*/
            Logger.Info("STAG 2 :PageName :Uwdecision.aspx.CS // MethodeName :btnReqaddrows_Click");
            if (gvRequirmentDetails.Rows.Count <= 0)
            {
                SetInitialRequirmentGrid();
            }
            else
            {
                AddNewRowToGrid1();
            }
            /*added by shri on 28 dec 17 to update tracking*/
            UpdateUwDecisionTracking(intTrackingRet, DateTime.Now, ref intTrackingRet);
            /*END HERE*/
        }
        catch (Exception ex)
        {

        }
        finally
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "disp_confirm", "<script>hideloading()</script>", false);
        }

    }
    //Set Previous Data on Postbacks
    //SetPreviousLoadingData();


    //}
    protected void btnUWCommSave_Click(object sender, EventArgs e)
    {
        SaveUwComment();
        /*
        //suraj
        if (ViewState["CommonViewState"] == null)
        {
            CommonViewState viewstst = new CommonViewState();
            viewstst.IsCommentSave = true;
            ViewState["CommonViewState"] = viewstst;
        }
        else
        {
            CommonViewState viewstst = (CommonViewState)ViewState["CommonViewState"];
            viewstst.IsCommentSave = true;
            ViewState["CommonViewState"] = viewstst;
        }
        */
    }
    protected void btnAddLoadingRow_Click(object sender, EventArgs e)
    {
        objUWDecision = new UWSaralDecision.BussLayer();
        Logger.Info("STAG 2 :PageName :Uwdecision.aspx.CS // MethodeName :btnAddLoadingRow_Click");
        /*added by shri on 28 dec 17 to add tracking*/
        int intTrackingRet = -1;
        objCommonObj = (CommonObject)Session["objCommonObj"];
        strUserId = objCommonObj._Bpmuserdetails._UserID;
        InsertUwDecisionTracking(strApplicationno, strUserId, DateTime.Now, "LOAD_ADD_NEWROW", ref intTrackingRet);
        //47.1 BEGIN of Changes; Bhaumik Patel - [CR-5855]
        DataSet _dsRate = new DataSet();
        commobj.OnlineFlatMortalityDetails_GET_RateAdjust("GetRateAdjustData_ByUSERID", strUserId, ref _dsRate);
        if (_dsRate.Tables.Count > 0 && _dsRate.Tables["RateAdjust"].Rows.Count > 0)
        {
            if ((Convert.ToInt32(txtRateAdjust.Text)) > Convert.ToInt32(_dsRate.Tables["RateAdjust"].Rows[0]["Flat_Extra"]))
            {
                ShowPopupMessage("Rate Adjust between 0  To " + _dsRate.Tables["RateAdjust"].Rows[0]["Flat_Extra"] + "");
                //throw new Exception("Rate Adjust between 0  To " + _dsRate.Tables["RateAdjust"].Rows[0]["Flat_Extra"] + "");
            }
            //47.1 END of Changes; Bhaumik Patel - [CR-5855]
            else 
            {
                /*end here*/
                if (gvLoadingDtls.Rows.Count <= 0)
                {
                    ViewState["LoadingData"] = null;
                    //Session["LoadingData"] = null;
                }
                PopulateLoadingDetails();
                btnAddLoadingRow.CssClass = "btn btn-primary lnkButton";
                /*added by shri on 16 dec 17 to add sis reqirement on addition of loading*/
                objChangeObj = (ChangeValue)Session["objLoginObj"];
                string strReqFollowupCode = "SIS", strReqDescription = "Please provide consent and fresh sis for extra premium in view of Medical/Non Medical Reasons. Sign Enclosed Letter."
                , strReqCategory = "Non Medical", strReqCriteria = "FIXED", strReqLifeType = "01", strReqStatus = "L"
                   , srtReqRaisedBy = objChangeObj.userLoginDetails._UserID;
                AddNewRequirement(strReqFollowupCode, strReqDescription, strReqCategory, strReqCriteria, strReqLifeType, strReqStatus
                    , srtReqRaisedBy);
                /*end here*/
                /*added by shri on 28 dec 17 to update tracking*/
                UpdateUwDecisionTracking(intTrackingRet, DateTime.Now, ref intTrackingRet);
                /*END HERE*/
                ScriptManager.RegisterStartupScript(Page, GetType(), "disp_confirm", "<script>hideloading()</script>", false);
                DataSet _ds = new DataSet(), _dsPrevPol = new DataSet();
                int LAPushErrorCode = 0; string strLAPushErrorMsg = string.Empty; string strConsentResponse = string.Empty;
                _ds = null;
                //Added by Suraj on 19 APRIL 2018 for Real time updating required for any addition or deletion of rate up loading
                ReplicaXml objReplicaXml = new ReplicaXml();
                int intResponse = -1;
                bool isdataSave = true;
                string strResponse = string.Empty;
                ManageLoadingDetails(isdataSave, ref isdataSave, objReplicaXml, _ds, false, ref strResponse);
                //PremiumCalculation(objReplicaXml, ref isdataSave, ref _ds, ref intResponse, ref strResponse);
                objUWDecision.OnlineApplicationLAServiceDetails_PUSH(strApplicationno, strChannelType, objChangeObj, ref _ds, ref _dsPrevPol, "proposal", ref LAPushErrorCode, ref strLAPushErrorMsg, ref strConsentResponse);
                UWPreIssueServiceCall(strApplicationno, strChannelType);
                //End
                /*ID:18 Start*/
                chkLoadingDtls.Checked = false;
                //47.1 BEGIN of Changes; Bhaumik Patel - [CR-5855]
                rgvrateAdjust.ErrorMessage = "";
                //47.1 END of Changes; Bhaumik Patel - [CR-5855]
                updLoadingDetails.Update();
                /*added for testing purpose*/
                updProductDetails.Update();
                /*ID:18 End*/
            }
        }
       
    }
    protected void btnUwdecisiondtlsSave_Click(object sender, EventArgs e)
    {
        BussLayer objBussLayer = new BussLayer();
        int LAPushErrorCode = 0;
        int UWDecisionResult = 0;
        string strLAPushErrorMsg = string.Empty;
        int Result = 0;
        objCommonObj = (CommonObject)Session["objCommonObj"];
        // objCommonObj = new CommonObject();
        objChangeObj = (ChangeValue)Session["objLoginObj"];
        string struserid = objChangeObj.userLoginDetails._UserID;
        // strUserGroup = objChangeObj.userLoginDetails._UserGroup;
        //strApplicationno = objCommonObj._ApplicationNo;
        strUWmode = strChannelType;
        UWSaralDecision.BussLayer objBuss = new UWSaralDecision.BussLayer();
        Logger.Info(strApplicationno + "STAG 2 :PageName :Bpmuwmodule.cs // MethodeName :btnPost_Click" + System.Environment.NewLine);
        //DropDownList ddlUWDecesion = (DropDownList)ContentPlaceHolder1.FindControl("ddlUWDecesion");
        //DropDownList ddlUWreason = (DropDownList)ContentPlaceHolder1.FindControl("ddlUWreason");
        //DropDownList ddlPostpone = (DropDownList)ContentPlaceHolder1.FindControl("ddlPeriod");
        //Label lblErrorDecisiondtls = (Label)ContentPlaceHolder1.FindControl("lblErrorDecisiondtls");
        foreach (RepeaterItem item in rptDecision.Items)
        {
            DropDownList ddlUWDecesion = (DropDownList)item.FindControl("ddlUWDecesion");
           // ListBox ddlUWreason1 = (ListBox)item.FindControl("ddlUWreason1");
            DropDownList ddlPeriod = (DropDownList)item.FindControl("ddlPeriod");
            //51.1 BEGIN of Changes; Bhaumik Patel - [CR- 3334]
            ListBox ddlUWreason1 = (ListBox)item.FindControl("ddlUWreason1");
            TextBox txtUWreason2 = (TextBox)item.FindControl("txtUWreason2");
            //51.1 End of Changes; Bhaumik Patel - [CR- 3334]
            string _strUWDecesion = ddlUWDecesion.SelectedValue;
            //string _strUWDecesion = ddlUWDecesion.SelectedValue;
            string _strUWPeriod = ddlPeriod.SelectedValue == "0" ? "" : ddlPeriod.SelectedValue;
            string _strDataValue = string.Empty;
            //string _strPolicyStatus = string.Empty;
            int intRetVal = -1;
            //51.1 BEGIN of Changes; Bhaumik Patel - [CR- 3334]
            string reasonscode = Request.Form[ddlUWreason1.UniqueID];
            string UWReason2value = reasonscode.Split(',')[1];
            string UWReason2 = Request.Form[txtUWreason2.UniqueID];
            //51.1 End of Changes; Bhaumik Patel - [CR- 3334]
            objComm.OnlineUWDecisionDetails_Save(objCommonObj._AppType, strApplicationno, ddlUWDecesion.SelectedItem.Text, ddlUWreason1.SelectedItem.Text, ddlUWDecesion.SelectedValue, ddlUWreason1.SelectedItem.Value, _strUWPeriod, struserid, objChangeObj.userLoginDetails._UserName, objChangeObj.userLoginDetails._UserGroup, objCommonObj._bpm_branchCode, objCommonObj._bpm_creationDate,
              objCommonObj._bpm_systemDate, objCommonObj._bpm_businessDate, objChangeObj.userLoginDetails._userBranch, objChangeObj.userLoginDetails._ProcessName, strApplicationno,  ref UWDecisionResult);
            if (UWDecisionResult != -1)
            {
                //lblErrorDecisiondtls.Text = "Decision details save successfully";
                objBuss.OnlineApplicationLAServiceDetails_PUSH(strApplicationno, strUWmode, objChangeObj, ref _ds, ref _dsPrevPol, ddlUWDecesion.SelectedValue, ref LAPushErrorCode, ref strLAPushErrorMsg, ref strConsentRespons);
                if (LAPushErrorCode == 0)
                {
                    lblErrorDecisiondtls.Text = "Decision Details Updated in Life Asia successfully";
                    if (ddlUWDecesion.SelectedValue == "Approved" && LAPushErrorCode == 0)
                    {
                        //objComm.OnlineUWMISDecision_Save(strApplicationno, ddlUWDecesion.SelectedValue, objCommonObj._bpm_branchCode, objChangeObj.userLoginDetails._ProcessName, objChangeObj.userLoginDetails._userBranch,
                        //    objCommonObj._AppType, struserid, objChangeObj.userLoginDetails._UserGroup, "", "", ref UWDecisionResult);
                        strAppstatusKey = (strUserGroup == "UW") ? "UC" : "DC";
                        objComm.OnlineApplicationchangeStatus(strApplicationno, struserid, strAppstatusKey, "", ref Result);
                        //_strPolicyStatus = "IF";
                        objBussLayer.UpdatePolicyStatus(strApplicationno, "UW", struserid, ref intRetVal);
                    }
                    else if (ddlUWDecesion.SelectedValue == "Declined" && LAPushErrorCode == 0)
                    {
                        //objComm.OnlineUWMISDecision_Save(strApplicationno, ddlUWDecesion.SelectedValue, objCommonObj._bpm_branchCode, objChangeObj.userLoginDetails._ProcessName, objChangeObj.userLoginDetails._userBranch,
                        //    objCommonObj._AppType, struserid, objChangeObj.userLoginDetails._UserGroup, ddlUWreason.SelectedValue, ddlUWreason.SelectedItem.Text, ref UWDecisionResult);
                        strAppstatusKey = (strUserGroup == "UW") ? "UC" : "DC";
                        objComm.OnlineApplicationchangeStatus(strApplicationno, struserid, strAppstatusKey, "", ref Result);
                        //_strPolicyStatus = "DC";
                        objBussLayer.UpdatePolicyStatus(strApplicationno, "DC", struserid, ref intRetVal);
                    }
                    else if (ddlUWDecesion.SelectedValue == "Postponed" && LAPushErrorCode == 0)
                    {
                        strAppstatusKey = (strUserGroup == "UW") ? "UC" : "DC";
                        objComm.OnlineApplicationchangeStatus(strApplicationno, struserid, strAppstatusKey, "", ref Result);
                        //_strPolicyStatus = "PO";
                        objBussLayer.UpdatePolicyStatus(strApplicationno, "PO", struserid, ref intRetVal);
                    }
                    else if (ddlUWDecesion.SelectedValue == "Withdrawn" && LAPushErrorCode == 0)
                    {
                        strAppstatusKey = (strUserGroup == "UW") ? "UC" : "DC";
                        objComm.OnlineApplicationchangeStatus(strApplicationno, struserid, strAppstatusKey, "", ref Result);
                        //_strPolicyStatus = "WD";
                        objBussLayer.UpdatePolicyStatus(strApplicationno, "WD", struserid, ref intRetVal);
                    }
                    /*added by shri on 06-07-17 to close page on success*/
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "show success message", "alert('Decision details save successfully');window.close();", true);
                    /*end here*/
                }
                else
                {
                    /*commented and added by shri on 06-07-17 to close page on success*/
                    //lblErrorDecisiondtls.Text = "Decision Details Not Updated in Life Asia,Please Contact system admin";
                    //lblErrorDecisiondtls.Focus();
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "show failure message", "alert('Decision Details Not Updated in Life Asia,Please Contact system admin');", true);
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

    }
    //protected void btnLoadingDtlsSave_Click(object sender, EventArgs e)
    //{

    //    string _strLoadRider = string.Empty;
    //    string _strLoadType = string.Empty;
    //    string _strLoadDesc = string.Empty;
    //    string _strLoadRsn1 = string.Empty;
    //    string _strRsn1Desc = string.Empty;
    //    string _strRsn2 = string.Empty;
    //    string _strRsn2Desc = string.Empty;
    //    string _strLoadPer = string.Empty;
    //    string _strRateAdjust = string.Empty;
    //    string _strLoadFlatMortality = string.Empty;
    //    string _strLoadletterPrint = string.Empty;
    //    int strFollowupResult = 0;
    //    objCommonObj = (CommonObject)ViewState["objCommonObj"];
    //    foreach (GridViewRow rowfollowup in gvLoadingDtls.Rows)
    //    {
    //        TextBox txtLoadRider = rowfollowup.FindControl("txtLoadRider") as TextBox;
    //        DropDownList ddlLoadType = rowfollowup.FindControl("ddlLoadType") as DropDownList;
    //        TextBox txtLoadDesc = rowfollowup.FindControl("txtLoadDesc") as TextBox;
    //        DropDownList ddlLoadRsn1 = rowfollowup.FindControl("ddlLoadRsn1") as DropDownList;
    //        TextBox txtRsn1Desc = rowfollowup.FindControl("txtRsn1Desc") as TextBox;
    //        DropDownList ddlRsn2 = rowfollowup.FindControl("ddlRsn2") as DropDownList;
    //        TextBox txtRsn2Desc = rowfollowup.FindControl("txtRsn2Desc") as TextBox;
    //        TextBox txtLoadPer = rowfollowup.FindControl("txtLoadPer") as TextBox;
    //        TextBox txtRateAdjust = rowfollowup.FindControl("txtRateAdjust") as TextBox;
    //        DropDownList ddlLoadFlatMortality = rowfollowup.FindControl("ddlLoadFlatMortality") as DropDownList;
    //        DropDownList ddlLoadletterPrint = rowfollowup.FindControl("ddlLoadletterPrint") as DropDownList;
    //        _strLoadRider = txtLoadRider.Text;
    //        _strLoadType = ddlLoadType.SelectedValue;
    //        _strLoadDesc = ddlLoadType.SelectedItem.Text;
    //        _strLoadRsn1 = ddlLoadRsn1.SelectedValue;
    //        _strRsn1Desc = txtRsn1Desc.Text;
    //        _strRsn2 = ddlRsn2.SelectedValue;
    //        _strRsn2Desc = txtRsn2Desc.Text;
    //        _strLoadPer = txtLoadPer.Text;
    //        _strRateAdjust = txtRateAdjust.Text;
    //        _strLoadFlatMortality = ddlLoadFlatMortality.SelectedValue;
    //        _strLoadletterPrint = ddlLoadletterPrint.SelectedValue;
    //        int LoadingResult = 0;
    //        objComm.OnlineLoadingDetails_Save(objCommonObj._ApplicationNo, objCommonObj._ApplicationNo, _strLoadType, _strLoadDesc, _strLoadRsn1, _strRsn2, "", "", "", _strRateAdjust, _strLoadFlatMortality, "", _strLoadletterPrint, "", objCommonObj._bpm_userID, objCommonObj._bpm_userName, objCommonObj._bpmgrp, objCommonObj._bpm_branchCode, objCommonObj._bpm_userBranch, objCommonObj._ProcessName, objCommonObj._ApplicationNo, ref LoadingResult);
    //    }



    //}

    protected void btnBankDtlsSave_Click(object sender, EventArgs e)
    {
        int BankResult = 0;

        //objCommonObj = (CommonObject)Session["objCommonObj"];
        lblErrorbankdtls.Text = string.Empty;
        Logger.Info(strApplicationno + " STAG 2 :PageName :Uwdecision.aspx.CS // MethodeName :btnBankDtlsSave_Click");
        objComm.OnlineBankDetails_Save(strApplicationno, txtBnkClientnumber.Text, txtBnkIfsccode.Text, txtBnkBankname.Text, txtBnkBranchname.Text, txtBnkBankaddress.Text, txtBnkBankaccno.Text, txtBnkClientname.Text, ref BankResult);
        if (BankResult != -1)
        {
            chkBankDtls.Checked = false;
            lblErrorbankdtls.Text = "Bank Details save successfully.";
        }
        else
        {
            lblErrorbankdtls.Text = "Bank Details Not Save ";
        }
    }

    protected void btnAppDtlsSave_Click(object sender, EventArgs e)
    {
        int AppResult = 0;
        int intServicesResultCount = 0, intTotalServiceCount = 3;
        string date = hdnRcdReq.Value;
        // objCommonObj = (CommonObject)Session["objCommonObj"];
        lblErrorAppDetailsBody.Text = lblErrorappdtls.Text = string.Empty;
        objChangeObj = (ChangeValue)Session["objLoginObj"];
        AppDtls objApplicationdetails = new AppDtls();
        objApplicationdetails._Backdate = Request.Form[txtRcdreq.UniqueID];
        objChangeObj.App_backdate = objApplicationdetails;

        Logger.Info(strApplicationno + "STAG 2 :PageName :Uwdecision.aspx.CS // MethodeName :btnAppDtlsSave_Click");
        objUWDecision.OnlineApplicationLAServiceDetails_PUSH(strApplicationno, strChannelType, objChangeObj, ref _ds, ref _dsPrevPol, "CONTRACTMODIFICATION", ref strLApushErrorCode, ref strLApushStatus, ref strConsentRespons);
        lblErrorAppDetailsBody.Text = strLApushStatus;
        if (strLApushErrorCode == 0)
        {
            intServicesResultCount++;
            LoadDtls objLoad = new LoadDtls();
            objLoad._strProdcode = "";
            objChangeObj.Load_Loadingdetails = objLoad;
            lblErrorappdtls.Text += "Application Details  updated in Life asia";
            //objUWDecision.OnlineApplicationLAServiceDetails_PUSH(strApplicationno, strChannelType, objChangeObj, ref _ds, "RATEUP", ref strLApushErrorCode, ref strLApushStatus);
            //if (strLApushErrorCode == 0)
            //{
            //    //lblErrorappdtls.Text = "lOADING Details Updated in LifeAsia successfully";
            //}
            FillLoadParam(ref objChangeObj, strApplicationno);
            objUWDecision.OnlineApplicationLAServiceDetails_PUSH(strApplicationno, strChannelType, objChangeObj, ref _ds, ref _dsPrevPol, "PREMIUMCAL", ref strLApushErrorCode, ref strLApushStatus, ref strConsentRespons);
            lblErrorAppDetailsBody.Text = strLApushStatus;
            if (_ds != null && _ds.Tables[0].Rows.Count > 0)
            {
                intServicesResultCount++;
                //ServiceTax = Convert.ToDecimal(WebConfigurationManager.AppSettings["ServiceTax"]);
                //txtBackDateIntrest.Text = Convert.ToString(Math.Round(Convert.ToDecimal(_ds.Tables[0].Rows[0][1].ToString())+(Convert.ToDecimal(_ds.Tables[0].Rows[0][1].ToString()) * ServiceTax),MidpointRounding.AwayFromZero));
                txtBackDateIntrest.Text = _ds.Tables[0].Rows[0]["BackDateintrest"].ToString();

            }
            //lblErrorappdtls.Text += "Application Details Updated in LifeAsia successfully";
            objComm.OnlineApplicationDetails_Save(strPolicyNo, strApplicationno, "Yes", Request.Form[txtRcdreq.UniqueID], ddlBkdateReason.SelectedItem.Value, objChangeObj.userLoginDetails._UserName, objChangeObj.userLoginDetails._UserID, objChangeObj.userLoginDetails._userBranch, objChangeObj.userLoginDetails._userBranch, "UWSaralUnderwritting", strApplicationno, objChangeObj.userLoginDetails._UserID, strChannelType, txtBackDateIntrest.Text, ref AppResult);
            if (AppResult != -1)
            {
                //lblErrorappdtls.Text += "Application Details save and updated in life asia successfully";
                chkAppDtls.Checked = false;
            }
            else
            {
                //lblErrorappdtls.Text += "Application Details Not save,Please Contact system admin";
                chkAppDtls.Checked = false;
            }
            if (intServicesResultCount == intTotalServiceCount)
            {
                lblErrorappdtls.Text = "Backdating details updated Successfully Click to know more";
            }
        }
        else
        {
            lblErrorappdtls.Text += "Application Details Not updated in Life asia CLICK to know more";
            lblErrorAppDetailsBody.Text = strLApushStatus;
            // chkAppDtls.Checked = true;
            chkAppDtls.Checked = false;
        }

    }

    #endregion Page Events End.
    protected void gvRiderDtls_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Logger.Info("STAG 5 :PageName :Uwdecision.aspx.CS // MethodeName :gvRiderDtls_RowDataBound" + System.Environment.NewLine);
        DataTable dt = (DataTable)ViewState["MandatoryRider"];
        CheckBox cbIsActive = (CheckBox)e.Row.FindControl("chkremoveRider");

        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            if (e.Row.Cells[0].Text.ToUpper() == "TRUE")
            {

                cbIsActive.Checked = true;
            }
            else
            {
                cbIsActive.Checked = false;
            }
        }
    }
    protected void btnValidatepan_Click(object sender, EventArgs e)
    {
        try
        {
            //34.1 Begin of Changes; Pooja Shetye - [1133038]
            string ClientMode = "";
            String panno = txtPannumber.Text;
            ClientMode = objcomm.GetClientType(strApplicationno);
            bool IsvalidPAN = ValidatePANNumber(panno, ClientMode);

            if (IsvalidPAN == true)
            { //34.1 End of Changes; Pooja Shetye - [1133038]

                /*ID:18 Start*/
                chkPanDtls.Checked = false;
                /*ID:18 End*/
                int _PanResult = 0;

                //26.1 Begin of Changes; Bibekananda Nanda - [1103055]
                string strnsdlPanNumber = string.Empty;
                string strnsdlLastUpdDT = string.Empty;
                string strnsdlPanStatus = string.Empty;
                string strnsdlPanTitle = string.Empty;
                string strnsdlPanType = string.Empty;
                DateTime? NSDLPropLastUpdDT = null;

                //26.1 End of Changes; Bibekananda Nanda - [1103055]

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Script", "DisplayPrgressShow();", true);
                objChangeObj = (ChangeValue)Session["objLoginObj"];
                Logger.Info(strApplicationno + "STAG 6 :PageName :Uwdecision.aspx.CS // MethodeName :btnValidatepan_Click" + System.Environment.NewLine);
                //objComm.OnlinePancardDetails_Save(txtBnkClientnumber.Text, txtBnkClientname.Text, "", "", "", "", "", "", "", txtPannumber.Text, objChangeObj.userLoginDetails._UserID, objChangeObj.userLoginDetails._UserName, objChangeObj.userLoginDetails._userBranch, objChangeObj.userLoginDetails._userBranch, "UWSaral", strChannelType, chkPanCopy.Checked, ref _PanResult, strnsdlPanStatus, strnsdlPanTitle, NSDLPropLastUpdDT, lblnsdlPanType.Text);
                //objComm.OnlinePancardDetails_Save(txtBnkClientnumber.Text, txtBnkClientname.Text, "", "", "", "", "", "", "", txtPannumber.Text, objChangeObj.userLoginDetails._UserID, objChangeObj.userLoginDetails._UserName, objChangeObj.userLoginDetails._userBranch, objChangeObj.userLoginDetails._userBranch, "UWSaral", strChannelType, chkPanCopy.Checked, ref _PanResult);
                objUWDecision.OnlineApplicationLAServiceDetails_PUSH(strApplicationno, strChannelType, objChangeObj, ref _ds, ref _dsPrevPol, "PANVALIDATION", ref strLApushErrorCode, ref strLApushStatus, ref strConsentRespons);
                if (_ds.Tables.Count > 0 && _ds.Tables[0].Rows.Count > 0)
                {
                    // chkPanDtls.Checked = false;
                    int intRet = -1;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Script", "DisplayPrgress();", false);
                    gvPanResult.DataSource = _ds;
                    gvPanResult.DataBind();
                    btnPandtlsSave.CssClass = btnPandtlsSave.CssClass.Replace("HideControl", "");
                    //call pan details from db
                    DataSet _dsDbPayer = new DataSet();
                    objcomm.FetchClientInfoOnApplciationNo(ref _dsDbPayer, strApplicationno, "PAYER");
                    string strReturn = string.Empty;
                    chkIsPanValidate.Checked = IsPanValid(_ds, _dsDbPayer, ref strReturn);
                    txtPanDescription.Text = strReturn;

                    //26.1 Begin of Changes; Bibekananda Nanda - [1103055]

                    strnsdlPanNumber = _ds.Tables[0].Rows[0]["PanNumber"].ToString();
                    strnsdlLastUpdDT = _ds.Tables[0].Rows[0]["LastUpdateDate"].ToString();
                    strnsdlPanStatus = _ds.Tables[0].Rows[0]["PanStatus"].ToString();
                    strnsdlPanTitle = _ds.Tables[0].Rows[0]["PanTitle"].ToString();
                    //strnsdlPanType = _ds.Tables[0].Rows[0]["PanNumber"].ToString();


                    char c = strnsdlPanNumber[3];
                    if (c.ToString().ToUpper() == "P")
                    {
                        lblnsdlPanType.Text = "Personal";

                    }
                    else
                    {
                        lblnsdlPanType.Text = "Other Than Personal";
                    }

                    lblnsdlLastUpdDt.Visible = false;
                    lblLastUpdDT.Visible = false;
                    lblnsdlLastUpdDt.Text = "";
                    //lblnsdlLastUpdDt.Text = strnsdlLastUpdDT;


                    if (!String.IsNullOrEmpty(strnsdlLastUpdDT))
                    {
                        NSDLPropLastUpdDT = DateTime.ParseExact(strnsdlLastUpdDT, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    }

                    //26.1 End of Changes; Bibekananda Nanda - [1103055]
                    if (chkIsPanValidate.Checked)
                    {
                        lblPanIsValidated.Text = "Auto Matched";
                        chkIsPanValidate.Checked = true;
                        /*added by shri on 16 jan 18 to update is pan updated flag*/
                        ManagePanAdharFlagUpdation(strApplicationno, true, 1, ref intRet);
                        ChangeThumbStatus(imgPanVerified, true);
                        /*end here*/
                    }
                    else
                    {
                        lblPanIsValidated.Text = "Not Matched";
                        chkIsPanValidate.Checked = false;
                        ManagePanAdharFlagUpdation(strApplicationno, false, 1, ref intRet);
                        ChangeThumbStatus(imgPanVerified, false);
                    }
                    //chkIsPanValidate.Attributes["class"] = chkIsPanValidate.Attributes["class"].Replace(" HideControl",string.Empty);
                }
                else
                {
                    //chkPanDtls.Checked = false;
                }

                //26.1 Begin of Changes; Bibekananda Nanda - [1103055]

                objComm.OnlinePancardDetails_Save(txtBnkClientnumber.Text, txtBnkClientname.Text, "", "", "", "", "", "", "", txtPannumber.Text, objChangeObj.userLoginDetails._UserID, objChangeObj.userLoginDetails._UserName, objChangeObj.userLoginDetails._userBranch, objChangeObj.userLoginDetails._userBranch, "UWSaral", strChannelType, chkPanCopy.Checked, ref _PanResult, strnsdlPanStatus, strnsdlPanTitle, NSDLPropLastUpdDT, lblnsdlPanType.Text);

                objComm.OnlinePanDisplayDetails_GET(ref _dsPandtls, strApplicationno, strChannelType);
                string NSDLPanYear;
                string NSDLIsNSAP;

                NSDLPanYear = Convert.ToString(_dsPandtls.Tables[0].Rows[0]["PanYear"]);
                NSDLIsNSAP = Convert.ToString(_dsPandtls.Tables[0].Rows[0]["IsNSAP"]);

                if (NSDLPanYear == "0" && NSDLIsNSAP == "false")
                {
                    lblPanMsgProp.Visible = true;
                    lblPanMsg.Visible = true;
                    lblPanMsg.Text = "PAN card issued within 1 year, please process with due diligence";
                }
                else
                {
                    lblPanMsgProp.Visible = false;
                    lblPanMsg.Visible = false;
                    lblPanMsg.Text = "";
                }
                //26.1 End of Changes; Bibekananda Nanda - [1103055]
                divPanValidation.Attributes["class"] = divPanValidation.Attributes["class"].Replace(" HideControl", string.Empty);
                divPanManipulate.Attributes["class"] = divPanManipulate.Attributes["class"].Replace(" HideControl", string.Empty);
            }
            else
            {
                //34.1 Begin of Changes; Pooja Shetye - [1133038]
                ShowPopupMessage("Please enter valid PAN number [4th character of PAN should match with client category. For Personal client it should be 'P', for Corporate client it should be H,A,,F,C,T,B,L,J,G]");
                throw new Exception("UDE-Please enter valid PAN number [4th character of PAN should match with client category. For Personal client it should be 'P', for Corporate client it should be H,A,,F,C,T,B,L,J,G]");
                //34.1 End of Changes; Pooja Shetye - [1133038]
            }
        }
        catch (Exception ex)
        {

        }
        finally
        {
            updAutoUwDetails.Update();
            ScriptManager.RegisterStartupScript(Page, GetType(), "disp_confirm", "<script>hideloading()</script>", false);
        }
    }

    protected void btnPandtlsSave_Click(object sender, EventArgs e)
    {
        /*ID:18 Start*/
        chkPanDtls.Checked = false;
        /*ID:18 End*/
        int _PanResult = 0;
        UWSaralServices.AmlDetails objAml = new UWSaralServices.AmlDetails();
        int strLAPushErrorcode = -1;
        string strLAPushStatus = "";
        lblErrorPanDetailsBody.Text = lblErrorpandtls.Text = string.Empty;
        objChangeObj = (ChangeValue)Session["objLoginObj"];
        Logger.Info(strApplicationno + "STAG 7 :PageName :Uwdecision.aspx.CS // MethodeName :btnPandtlsSave_Click" + System.Environment.NewLine);
        /*added by shri on 11 sept 17 to add is applied flag*/
        string strFirstName = string.Empty, strMiddleName = string.Empty, strLastName = string.Empty;

        //26.1 Begin of Changes; Bibekananda Nanda - [1103055]

        string strPanStatus = string.Empty;
        string strPanTitle = string.Empty;
        string strLastUpdDate = string.Empty;

        //26.1 End of Changes; Bibekananda Nanda - [1103055]

        /*fetch first name middle name last name*/
        if (chkPanCopy.Checked)
        {
            int i = 3;
            if (gvPanResult.Rows.Count > 0)
            {
                foreach (GridViewRow rows in gvPanResult.Rows)
                {
                    strLastName = rows.Cells[i].Text;
                    strFirstName = rows.Cells[i + 1].Text;
                    strMiddleName = rows.Cells[i + 2].Text;

                    //26.1 Begin of Changes; Bibekananda Nanda - [1103055]

                    strPanStatus = rows.Cells[2].Text;
                    strPanTitle = rows.Cells[6].Text;
                    strLastUpdDate = rows.Cells[7].Text;

                    //26.1 End of Changes; Bibekananda Nanda - [1103055]
                }
            }
            else
            {
                objUWDecision.OnlineApplicationLAServiceDetails_PUSH(strApplicationno, strChannelType, objChangeObj, ref _ds, ref _dsPrevPol, "PANVALIDATION", ref strLApushErrorCode, ref strLApushStatus, ref strConsentRespons);
                if (_ds != null && _ds.Tables.Count > 0 && _ds.Tables[0].Rows.Count > 0)
                {
                    strLastName = Convert.ToString(_ds.Tables[0].Rows[0][i]);
                    strFirstName = Convert.ToString(_ds.Tables[0].Rows[0][i + 1]);
                    strMiddleName = Convert.ToString(_ds.Tables[0].Rows[0][i + 2]);

                    //26.1 Begin of Changes; Bibekananda Nanda - [1103055]

                    strPanStatus = Convert.ToString(_ds.Tables[0].Rows[0][2]);
                    strPanTitle = Convert.ToString(_ds.Tables[0].Rows[0][6]);
                    strLastUpdDate = Convert.ToString(_ds.Tables[0].Rows[0][7]);

                    //26.1 End of Changes; Bibekananda Nanda - [1103055]
                }
            }

        }

        /*end here*/
        //26.1 Begin of Changes; Bibekananda Nanda - [1103055]

        DateTime? NSDLPropLastUpdDT = null;
        if (!String.IsNullOrEmpty(strLastUpdDate))
        {
            NSDLPropLastUpdDT = DateTime.ParseExact(strLastUpdDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
        string strnsdlPanNumber = txtPannumber.Text;
        char c = strnsdlPanNumber[3];
        if (c.ToString().ToUpper() == "P")
        {
            lblnsdlPanType.Text = "Personal";
        }
        else
        {
            lblnsdlPanType.Text = "Other Than Personal";
        }

        /*end here*/

        objComm.OnlinePancardDetails_Save(txtBnkClientnumber.Text, strFirstName, strLastName, strMiddleName, string.Empty, lblPanIsValidated.Text, txtPanDescription.Text, "", txtPanComment.Text, txtPannumber.Text, objChangeObj.userLoginDetails._UserID, objChangeObj.userLoginDetails._UserName, objChangeObj.userLoginDetails._userBranch, objChangeObj.userLoginDetails._userBranch, "UWSaral", strChannelType, (chkPanCopy.Checked), ref _PanResult,
            strPanStatus, strPanTitle, NSDLPropLastUpdDT, lblnsdlPanType.Text);

        //26.1 End of Changes; Bibekananda Nanda - [1103055]
        //objComm.OnlinePancardDetails_Save(txtBnkClientnumber.Text, strFirstName, strLastName, strMiddleName, string.Empty, lblPanIsValidated.Text, txtPanDescription.Text, "", txtPanComment.Text, txtPannumber.Text, objChangeObj.userLoginDetails._UserID, objChangeObj.userLoginDetails._UserName, objChangeObj.userLoginDetails._userBranch, objChangeObj.userLoginDetails._userBranch, "UWSaral", strChannelType, (chkPanCopy.Checked), ref _PanResult);
        /*end here*/
        if (_PanResult != -1)
        {
            if (chkPanCopy.Checked)
            {
                divPanValidation.Attributes["class"] = divPanValidation.Attributes["class"].Replace("HideControl", string.Empty);
            }
            else
            {
                divPanValidation.Attributes["class"] = divPanValidation.Attributes["class"] + " HideControl";
            }
            lblErrorpandtls.Text = "Pan Details save successfully";
            objcomm.AMLDetails_Get(ref _ds, strApplicationno, strChannelType);
            if (_ds != null && _ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in _ds.Tables[0].Rows)
                {
                    //39.1 Begin of Changes; Sagar Thorave-[mfl00886]
                    DataSet ds12 = null;
               
                    objComm.Featch_AMLFLAG_Details(ref ds12, strApplicationno, "SaralUW");
                    string CLNTRSKIND = (ds12.Tables[0].Rows[0]["CLNTRSKIND"].ToString());
                    objAml.AMLPushService(strApplicationno, row, objChangeObj, ref strLAPushErrorcode, ref strLAPushStatus, CLNTRSKIND);
                    //39.1 End of Changes; Sagar Thorave-[mfl00886]
                    if (strLAPushErrorcode == 0)
                    {
                        chkPanDtls.Checked = false;
                        btnPandtlsSave.CssClass = btnPandtlsSave.CssClass.Insert(0, "HideControl ");
                        lblErrorPanDetailsBody.Text = lblErrorpandtls.Text = "Pan Details Updated in Life Asia successfully";

                    }
                    else
                    {
                        chkPanDtls.Checked = false;
                        lblErrorpandtls.Text = "Pan Details Not Updated Successfully";
                        lblErrorPanDetailsBody.Text = strLApushStatus;
                    }
                }
            }
            else
            {
                chkPanDtls.Checked = false;
                lblErrorpandtls.Text = "Pan Details Not Updated";
                lblErrorJournalDetailsBody.Text = "Pan Details Not Fetched From DataBase";
            }
        }
        else
        {
            chkPanDtls.Checked = false;
            lblErrorpandtls.Text = "Pan Details Not Updated";
            lblErrorJournalDetailsBody.Text = "Pan Details Not Saved In DataBase";
        }
    }

    protected void rptproductlist_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        DataTable _dtprod = new DataTable();
        _dtprod = (DataTable)ViewState["ProdDetail"];
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DropDownList ddlFrequency_Combi = (e.Item.FindControl("ddlFrequency") as DropDownList);
            string freq = (e.Item.DataItem as DataRowView)["PremiumFreq"].ToString();
            ddlFrequency_Combi.Items.FindByValue(freq).Selected = true;
        }
    }
    protected void btnProddtlsSave_Click(object sender, EventArgs e)
    {
        //    int _ProdResult = 0;
        //    string strComboMonthlyPayout = string.Empty;
        //    string strProdMonthlyPayout = string.Empty;
        //    //lblErrorProductDetailBody.Text = lblErrorproddtls.Text = "";
        //    //gridPremCal_Product.DataSource = null;
        //    //gridPremCal_Product.DataBind();
        //    //  objCommonObj = (CommonObject)Session["objCommonObj"];
        //    //lblErrorproddtls.Text = string.Empty;
        //    objChangeObj = (ChangeValue)Session["objLoginObj"];
        //    Logger.Info(strApplicationno + "STAG 8 :PageName :Uwdecision.aspx.CS // MethodeName :btnProddtlsSave_Click" + System.Environment.NewLine);
        //    ProdDtls objprodchangevalue = new ProdDtls();

        //    objprodchangevalue._PolicyTerm = Request.Form[txtPolterm.UniqueID];
        //    objprodchangevalue._Premiumpayingterm = Request.Form[txtPrepayterm.UniqueID];
        //    objprodchangevalue._Sumassured = Request.Form[txtSumassure.UniqueID];
        //    objprodchangevalue._Paymentfrequency = ddlFrequency.SelectedValue;
        //    strProdMonthlyPayout = objprodchangevalue._MonthlyPayoutBase = Request.Form[txtMonthlyPayoutBase.UniqueID];
        //    objprodchangevalue._ProdcodeBase = txtProdcode.Text;
        //    // objprodchangevalue._Amountinsis = txtSisamount.Text;
        //    objprodchangevalue._Basepremiumamount = Request.Form[txtBasepremium.UniqueID];
        //    objprodchangevalue._TotalPremiumamount = txtTotalpremium.Text;
        //    if (!string.IsNullOrEmpty(txtCombProdCode.Text))
        //    {
        //        objprodchangevalue._ProdcodeCombo = Request.Form[txtCombProdCode.UniqueID];
        //        objprodchangevalue._PolicyTermCombo = Request.Form[txtCombPolTerm.UniqueID];
        //        objprodchangevalue._PremiumpayingtermCombo = Request.Form[txtCombPayTerm.UniqueID];
        //        objprodchangevalue._SumassuredCombo = Request.Form[txtCombSumAssured.UniqueID];
        //        objprodchangevalue._BasepremiumamountCombo = txtCombPremAmount.Text;
        //        objprodchangevalue._TotalPremiumamountCombo = txtCombTotalPrem.Text;
        //        strComboMonthlyPayout = objprodchangevalue._MonthlyPayoutCombo = Request.Form[txtComboMonthlyPayout.UniqueID];
        //    }
        //    objChangeObj.Prod_policydetails = objprodchangevalue;


        //    #region Premium calculation Service call begin.
        //    objUWDecision.OnlineApplicationLAServiceDetails_PUSH(strApplicationno, strChannelType, objChangeObj, ref _ds, ref _dsPrevPol, "PREMIUMCAL", ref strLApushErrorCode, ref strLApushStatus, ref strConsentRespons);

        //    List<RiderInfo> lstRiderInfo = new List<RiderInfo>();
        //    Commfun.FillRiderInfoFromPremiumCalcDataTable(ref lstRiderInfo, _ds.Tables[0]);

        //    if (strLApushErrorCode == 0 && _ds.Tables.Count > 0)
        //    {
        //        DataSet _dsPremiumCalculation;
        //        lblErrorProductDetailBody.Text = "Premium calculation succeed";
        //        //clsName = divPremiumdetails.Attributes["class"].ToString();
        //        //divPremiumdetails.Attributes.Add("class", clsName.Replace(clsName, "col-md-12"));

        //        RiderInfo objrider = lstRiderInfo.Where(x => x.RiderType.Equals("BS") && x.ProductCode.Equals(txtProdcode.Text)).SingleOrDefault();
        //        if (objrider != null)
        //        {
        //            txtBasepremium.Text = objprodchangevalue._Basepremiumamount = objrider.InstalmentPremiumAmt.ToString();
        //            txtTotalpremium.Text = objprodchangevalue._TotalPremiumamount = objrider.TotalPremiumAmount.ToString();
        //            txtServicetax.Text = objprodchangevalue._ServiceTax = objrider.ServiceTax.ToString();
        //            txtSumassure.Text = objprodchangevalue._Sumassured = objrider.SumAssured.ToString();
        //        }
        //        RiderInfo objComb = lstRiderInfo.Where(x => x.RiderType.Equals("BS") && x.ProductCode.Equals(txtCombProdCode.Text)).SingleOrDefault();
        //        if (objComb != null)
        //        {
        //            txtCombPremAmount.Text = objprodchangevalue._BasepremiumamountCombo = objComb.InstalmentPremiumAmt.ToString();
        //            txtCombTotalPrem.Text = objprodchangevalue._TotalPremiumamountCombo = objComb.TotalPremiumAmount.ToString();
        //            txtCombServiceTax.Text = objprodchangevalue._ServiceTaxCombo = objComb.ServiceTax.ToString();
        //            txtCombSumAssured.Text = objprodchangevalue._SumassuredCombo = objComb.SumAssured.ToString();
        //            txtComboMonthlyPayout.Text = string.IsNullOrEmpty(strComboMonthlyPayout) ? "0" : strComboMonthlyPayout;
        //        }

        //        objChangeObj.Prod_policydetails = objprodchangevalue;
        //        #region Call Contract Modification Service Begins.
        //        objUWDecision.OnlineApplicationLAServiceDetails_PUSH(strApplicationno, strChannelType, objChangeObj, ref _ds, ref _dsPrevPol, "CONTRACTMODIFICATION", ref strLApushErrorCode, ref strLApushStatus, ref strConsentRespons);
        //        if (strLApushErrorCode == 0)
        //        {
        //            lblErrorProductDetailBody.Text += ",Contract modification succeed";
        //            //objComm.OnlineProductDetails_Save(strChannelType, strApplicationno, strPolicyNo, txtProdcode.Text, txtSumassure.Text, txtPolterm.Text, txtPrepayterm.Text, ddlFrequency.SelectedValue, txtBasepremium.Text, txtTotalpremium.Text, txtBasepremium.Text, txtMonthlyPayoutBase.Text, ref _ProdResult);
        //            chkProductDtls.Checked = false;
        //            int _RiderResult = 0;
        //            lblErrorProductDetailBody.Text += ",Product Details save succeed";
        //            //Amit 08062017 Start

        //            //objUWDecision.OnlineApplicationLAServiceDetails_PUSH(strApplicationno, strChannelType, objChangeObj, ref _ds, "RATEUP", ref strLApushErrorCode, ref strLApushStatus);
        //            //if (strLApushErrorCode == 0)
        //            //{
        //            //    lblErrorProductDetailBody.Text += ",Loading modification succeed";
        //            //}
        //            if (gvRiderDtls.Rows.Count > 0)
        //            {
        //                foreach (GridViewRow rows in gvRiderDtls.Rows)
        //                {
        //                    Label lblRiderCode = (Label)rows.FindControl("lblRiderCode");
        //                    TextBox txtRiderSumAssure = (TextBox)rows.FindControl("txtRiderSumAssure");
        //                    TextBox txtRiderPremium = (TextBox)rows.FindControl("txtRiderPremium");
        //                    objComm.OnlineRiderDetails_Save(strChannelType, strApplicationno, lblRiderCode.Text, txtRiderPremium.Text, txtRiderSumAssure.Text, ref _RiderResult);
        //                }
        //                if (_RiderResult != -1)
        //                {
        //                    chkProductDtls.Checked = false;
        //                    lblErrorProductDetailBody.Text += ",Product Details save succeed";
        //                    lblErrorproddtls.Text = "Product Details Updated Successfully";
        //                }
        //                else
        //                {
        //                    chkProductDtls.Checked = false;
        //                    lblErrorProductDetailBody.Text += "Product Details failed,Please Contact system admin";
        //                    lblErrorproddtls.Text = "Product Details Not Updated Successfully";
        //                }
        //            }
        //            //Amit 08062017 End.

        //        }
        //        else
        //        {
        //            FillProductDetails(strApplicationno, strChannelType);
        //            chkProductDtls.Checked = false;
        //            lblErrorproddtls.Text = "Product Details Not Updated Successfully";
        //            lblErrorProductDetailBody.Text += ",Contract modification failed Error:" + strLApushStatus;
        //            //lblErrorProductDetailBody.Text += ",Contract modification failed,Please Contact system admin";

        //        }
        //        #endregion Call Contract Modification Service End.
        //    }

        //    //Amit 08062017 start.
        //    else if (strLApushErrorCode == 1)
        //    {
        //        chkProductDtls.Checked = false;
        //        lblErrorproddtls.Text = strLApushStatus;
        //        gridPremiumdetails.DataSource = null;
        //        gridPremiumdetails.DataBind();
        //        divPremiumdetails.Attributes.Add("class", "col-md-12 HideControl");
        //    }
        //    //Amit 08062017 end.
        //    else
        //    {
        //        chkProductDtls.Checked = false;
        //        lblErrorproddtls.Text = "Product Details Not Updated Successfully";
        //        lblErrorProductDetailBody.Text = "Premium calculation failed,Please Contact system admin";
        //        divPremiumdetails.Attributes.Add("class", "col-md-12 HideControl");
        //    }
        //    #endregion calculation service call end
        //    /*added by shri to show updated monthly payout*/
        //    txtMonthlyPayoutBase.Text = strProdMonthlyPayout;
        //    /*end here*/
    }

    protected void btnRiderDtlsSave_Click(object sender, EventArgs e)
    {
        int _RiderResult = 0;
        objCommonObj = (CommonObject)Session["objCommonObj"];
        Logger.Info(objCommonObj._ApplicationNo + "STAG 9 :PageName :Uwdecision.aspx.CS // MethodeName :btnRiderDtlsSave_Click" + System.Environment.NewLine);
        foreach (GridViewRow rows in gvRiderDtls.Rows)
        {
            Label lblRiderCode = (Label)rows.FindControl("lblRiderCode");
            TextBox txtRiderSumAssure = (TextBox)rows.FindControl("txtRiderSumAssure");
            TextBox txtRiderPremium = (TextBox)rows.FindControl("txtRiderPremium");
            objComm.OnlineRiderDetails_Save(objCommonObj._ChannelType, objCommonObj._ApplicationNo, lblRiderCode.Text, txtRiderPremium.Text, txtRiderSumAssure.Text, ref _RiderResult);
        }

    }

    protected void btnFundDtlsSave_Click(object sender, EventArgs e)
    {
        int _FundResult = 0;
        lblErrorfunddtls.Text = string.Empty;
        objCommonObj = (CommonObject)Session["objCommonObj"];
        objChangeObj = (ChangeValue)Session["objLoginObj"];
        Logger.Info(strApplicationno + "STAG 10 :PageName :Uwdecision.aspx.CS // MethodeName :btnFundDtlsSave_Click" + System.Environment.NewLine);
        DataSet _dsFundResponce = null;
        foreach (GridViewRow rows in gvFundDtls.Rows)
        {
            Label lblFundvalue = (Label)rows.FindControl("lblFundvalue");
            Label lblFundName = (Label)rows.FindControl("lblFundName");
            TextBox txtFundvalue = (TextBox)rows.FindControl("txtFundvalue");
            objComm.OnlineFundDetails(strChannelType, objCommonObj._AppType, strApplicationno, lblFundvalue.Text, lblFundName.Text, txtFundvalue.Text, objChangeObj.userLoginDetails._UserID, objChangeObj.userLoginDetails._UserName, objChangeObj.userLoginDetails._UserGroup, objChangeObj.userLoginDetails._userBranch, objChangeObj.userLoginDetails._userBranch, objChangeObj.userLoginDetails._ProcessName, strApplicationno, ref _FundResult);
            if (_FundResult != -1)
            {
                lblErrorfunddtls.Text = "Fund Details save successfully";
                objUWDecision.OnlineApplicationLAServiceDetails_PUSH(strApplicationno, strChannelType, objChangeObj, ref _dsFundResponce, ref _dsPrevPol, "CONTRACTMODIFICATION", ref strLApushErrorCode, ref strLApushStatus, ref strConsentRespons);
                if (strLApushErrorCode == 0)
                {
                    lblErrorfunddtls.Text = "Fund Details updated in Life Asia  successfully";
                }
                else
                {
                    lblErrorfunddtls.Text = "Fund Details not updated in Life Asia  successfully";
                }
            }
            else
            {
                lblErrorfunddtls.Text = "Fund Details Not Save ,Please Contact system admin";
            }
        }
        ScriptManager.RegisterStartupScript(Page, GetType(), "disp_confirm", "<script>hideloading()</script>", false);
    }


    //51.1 Begin of Changes; Bhaumik Patel - [CR - 3334]
    protected void ddlUWDecesion_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int index = 0;
            lblErrorDecisiondtls.Text = "";
            foreach (RepeaterItem item in rptDecision.Items)
            {

                DataSet _dsDecisionCatrgory = null;
                DataSet _OthereReason = new DataSet();
                Logger.Info("STAG 11 :PageName :Uwdecision.aspx.CS // MethodeName :ddlUWDecesion_SelectedIndexChanged" + System.Environment.NewLine);

                FillSubMasterDetailsCategory(ref _dsDecisionCatrgory, "", "", "Category", "");
                HtmlGenericControl divPostponedPeriod = item.FindControl("divPostponedPeriod") as HtmlGenericControl;
                HtmlGenericControl divUWDecesioncategory = item.FindControl("divUWDecesioncategory") as HtmlGenericControl;
                HtmlGenericControl divUWReason1 = item.FindControl("divUWReason1") as HtmlGenericControl;
                HtmlGenericControl divUWReason2 = item.FindControl("divUWReason2") as HtmlGenericControl;
                HtmlGenericControl divbtnaddnewrow = item.FindControl("divbtnaddnewrow") as HtmlGenericControl;
                DropDownList ddlUWDecesioncategory = item.FindControl("ddlUWDecesioncategory") as DropDownList;
                DropDownList ddlPeriod = item.FindControl("ddlPeriod") as DropDownList;
                //48.1 Begin of Changes; Sagar Thorave - [CR - 7049]
                ListBox ddlUWreason1 = item.FindControl("ddlUWreason1") as ListBox;
                //48.1 End of Changes; Sagar Thorave - [CR - 7049]
                DropDownList ddlUWDecesion = item.FindControl("ddlUWDecesion") as DropDownList;
                TextBox txtUWreason2 = item.FindControl("txtUWreason2") as TextBox;

                HtmlGenericControl Acceptance_Reason = item.FindControl("Acceptance_Reason") as HtmlGenericControl;


                string ddlUWDecesionclass = "ddlUWDecesion_" + (index + 1).ToString();
                string ddlUWDecesioncategoryClass = "ddlUWDecesioncategory_" + (index + 1).ToString();
                //48.1 Begin of Changes; Sagar Thorave - [CR - 7049]
                ListBox ddlAcceptanceReason = item.FindControl("ddlAcceptanceReason") as ListBox;
                string ddlAcceptanceReasonClass = "ddlAcceptanceReason_" + (index + 1).ToString();
                //48.1 End of Changes; Sagar Thorave - [CR - 7049]

                //49.1 Begin of Changes; Jayendra Patnakar - [WebAshlar01]
                HtmlGenericControl divAcceptanceOtherReasonText = item.FindControl("divAcceptanceOtherReasonText") as HtmlGenericControl;
                TextBox txtAcceptanceOtherReasonText = item.FindControl("txtAcceptanceOtherReasonText") as TextBox;
                string txtAcceptanceOtherReasonTextClass = "txtAcceptanceOtherReasonText_" + (index + 1).ToString();
                txtAcceptanceOtherReasonText.CssClass = "form-control txtAcceptanceOtherReasonText " + txtAcceptanceOtherReasonTextClass;
                //49.1 End of Changes; Jayendra Patnakar - [WebAshlar01]

                string ddlUWreason1Class = "ddlUWreason1_" + (index + 1).ToString();
                string txtUWreason2Class = "txtUWreason2_" + (index + 1).ToString();
                ddlUWDecesion.CssClass = "form-control select2 Decision " + ddlUWDecesionclass;
                ddlUWDecesioncategory.CssClass = "form-control select2 " + ddlUWDecesioncategoryClass;
                txtUWreason2.CssClass = "form-control " + txtUWreason2Class;
                ddlUWreason1.CssClass = "form-control label ddlUWreason1 " + ddlUWreason1Class + " " + ddlUWDecesioncategoryClass + " " + ddlUWDecesionclass;
                //48.1 Begin of Changes; Sagar Thorave - [CR - 7049]
                ddlAcceptanceReason.CssClass = "form-control label ddlAcceptanceReason " + ddlAcceptanceReasonClass;
                //48.1 End of Changes; Sagar Thorave - [CR - 7049]
                ddlUWDecesioncategory.DataSource = _dsDecisionCatrgory.Tables[0];
                if (_dsDecisionCatrgory.Tables.Count > 0 && _dsDecisionCatrgory.Tables[0].Rows.Count > 0)
                {
                    if (ddlUWDecesion.SelectedValue == "Postponed" || ddlUWDecesion.SelectedValue == "Declined")
                    {
                        // ddlUWreason1.Items.Clear();
                        //48.1 Begin of Changes; Sagar Thorave - [CR - 7049]
                        Acceptance_Reason.Visible = false;
                        //48.1 End of Changes; Sagar Thorave - [CR - 7049]
                        divUWDecesioncategory.Visible = true;
                        ddlUWDecesioncategory.DataTextField = "NAME";
                        ddlUWDecesioncategory.DataValueField = "VALUE";
                        ddlUWDecesioncategory.DataBind();
                        ddlUWDecesioncategory.Items.Insert(0, new ListItem("--Select--", "0"));
                        ddlUWDecesioncategory.ClearSelection();
                        divUWReason1.Visible = true;
                        divUWReason2.Visible = true;
                        if (ddlUWDecesion.SelectedValue == "Postponed")
                        {
                            divPostponedPeriod.Visible = true;

                        }
                        else
                        {
                            ddlPeriod.ClearSelection();
                            divPostponedPeriod.Visible = false;

                        }

                        if (!string.IsNullOrEmpty(Request.Form[ddlUWreason1.UniqueID.ToString()]) && ddlUWreason1.Items.Count > 0)
                        {

                            for (int i = 0; i < ddlUWreason1.Items.Count; i++)
                            {
                                string[] selectedarray = Request.Form[ddlUWreason1.UniqueID.ToString()].Split(',');
                                if (selectedarray.Contains(ddlUWreason1.Items[i].Text))
                                    ddlUWreason1.Items[i].Selected = true;
                            }

                        }
                        else
                        {
                            ddlUWreason1.Items.Clear();

                        }
                        if (!string.IsNullOrEmpty(Request.Form[txtUWreason2.UniqueID.ToString()]))
                        {
                            txtUWreason2.Text = Request.Form[txtUWreason2.UniqueID.ToString()];

                        }
                        else
                        {
                            txtUWreason2.Text = "";
                        }
                        if (!string.IsNullOrEmpty(Request.Form[ddlUWDecesioncategory.UniqueID.ToString()]) && ddlUWDecesioncategory.Items.Count > 0)
                        {

                            for (int i = 0; i < ddlUWDecesioncategory.Items.Count; i++)
                            {
                                ddlUWDecesioncategory.SelectedValue = Request.Form[ddlUWDecesioncategory.UniqueID];

                            }

                        }
                        else
                        {
                            ddlUWDecesioncategory.SelectedValue = "";
                        }
                        //48.1 Begin of Changes; Sagar Thorave - [CR - 7049]
                        if (!string.IsNullOrEmpty(Request.Form[ddlAcceptanceReason.UniqueID.ToString()]) && ddlAcceptanceReason.Items.Count > 0)
                        {

                            for (int i = 0; i < ddlAcceptanceReason.Items.Count; i++)
                            {
                                string[] selectedarray = Request.Form[ddlAcceptanceReason.UniqueID.ToString()].Split(',');
                                if (selectedarray.Contains(ddlAcceptanceReason.Items[i].Text))
                                    ddlAcceptanceReason.Items[i].Selected = true;
                            }

                        }

                        //48.1 End of Changes; Sagar Thorave - [CR - 7049]

                    }
                    else
                    {

                        FillSubMasterDetailsCategory(ref _OthereReason, ddlUWDecesion.SelectedValue, "", "Other", "");
                        if (ddlUWDecesion.SelectedValue == "proposal" || ddlUWDecesion.SelectedValue == "0")
                        {
                            //48.1 Begin of Changes; Sagar Thorave - [CR - 7049]
                            Acceptance_Reason.Visible = false;
                            //48.1 End of Changes; Sagar Thorave - [CR - 7049]
                            divUWReason1.Visible = false;
                            divUWReason2.Visible = false;
                            divUWDecesioncategory.Visible = false;
                            ddlUWreason1.Items.Clear();
                            //divbtnaddnewrow.Visible = true;
                        }
                        else
                        {
                            //48.1 Begin of Changes; Sagar Thorave - [CR - 7049]
                            Acceptance_Reason.Visible = false;
                            //48.1 End of Changes; Sagar Thorave - [CR - 7049]
                            ddlUWreason1.DataSource = _OthereReason.Tables[0];
                            divUWReason1.Visible = true;
                            divUWReason2.Visible = false;
                            divUWDecesioncategory.Visible = false;
                            ddlUWreason1.Items.Clear();

                        }
                        if (_OthereReason.Tables[0].Rows.Count > 0)
                        {


                            //ddlUWreason1.Items.Insert(0, new ListItem("Please select ", ""));

                            foreach (DataRow row in _OthereReason.Tables[0].Rows)
                            {

                                if (row["value"] != null)
                                    ddlUWreason1.DataValueField = row["value"].ToString();
                                else
                                    ddlUWreason1.DataValueField = "";

                                if (row["name"] != null)
                                    ddlUWreason1.DataTextField = row["name"].ToString();
                                else
                                    ddlUWreason1.DataTextField = "";

                                ddlUWreason1.Items.Add(new ListItem(ddlUWreason1.DataTextField, ddlUWreason1.DataValueField));


                            }

                        }

                        if (ddlUWDecesion.SelectedValue == "Postponed")
                        {
                            divPostponedPeriod.Visible = true;

                        }
                        //48.1 Begin of Changes; Sagar Thorave - [CR-7049]
                        else if (ddlUWDecesion.SelectedValue == "Approved")
                        {

                            divPostponedPeriod.Visible = false;
                            if (txtriskcat.Text == "High" || txtriskcat.Text == "Very High")
                            {
                                DataSet ds = new DataSet();
                                FillAcceptanceMaster(ref ds);
                                Acceptance_Reason.Visible = true;
                                ddlPeriod.ClearSelection();
                                divUWReason2.Visible = false;
                                divPostponedPeriod.Visible = false;
                                if (ds.Tables[0].Rows.Count > 0)
                                {

                                    ddlAcceptanceReason.Items.Clear();
                                    ddlAcceptanceReason.SelectedValue = "";
                                    foreach (DataRow row in ds.Tables[0].Rows)
                                    {

                                        if (row["value"] != null)
                                            ddlAcceptanceReason.DataValueField = row["value"].ToString();
                                        else
                                            ddlAcceptanceReason.DataValueField = "";

                                        if (row["name"] != null)
                                            ddlAcceptanceReason.DataTextField = row["name"].ToString();
                                        else
                                            ddlAcceptanceReason.DataTextField = "";

                                        ddlAcceptanceReason.Items.Add(new ListItem(ddlAcceptanceReason.DataTextField, ddlAcceptanceReason.DataValueField));

                                    }

                                }
                            }
                            //48.1 End of Changes; Sagar Thorave - [CR-7049]
                            else
                            {
                                Acceptance_Reason.Visible = false;
                            }

                        }
                        else
                        {
                            divPostponedPeriod.Visible = false;
                            //48.1 Begin of Changes; Sagar Thorave - [CR - 7049]
                            Acceptance_Reason.Visible = false;
                            //48.1 End of Changes; Sagar Thorave - [CR - 7049]
                        }


                        if (!string.IsNullOrEmpty(Request.Form[ddlUWreason1.UniqueID.ToString()]) && ddlUWreason1.Items.Count > 0)
                        {

                            for (int i = 0; i < ddlUWreason1.Items.Count; i++)
                            {
                                string[] selectedarray = Request.Form[ddlUWreason1.UniqueID.ToString()].Split(',');
                                if (selectedarray.Contains(ddlUWreason1.Items[i].Value))
                                    ddlUWreason1.Items[i].Selected = true;
                            }
                        }
                        //48.1 Begin of Changes; Sagar Thorave - [CR - 7049]
                        if (!string.IsNullOrEmpty(Request.Form[ddlAcceptanceReason.UniqueID.ToString()]) && ddlAcceptanceReason.Items.Count > 0)
                        {

                            for (int i = 0; i < ddlAcceptanceReason.Items.Count; i++)
                            {
                                string[] selectedarray = Request.Form[ddlAcceptanceReason.UniqueID.ToString()].Split(',');
                                if (selectedarray.Contains(ddlAcceptanceReason.Items[i].Text))
                                    ddlAcceptanceReason.Items[i].Selected = true;
                            }

                        }
                        //48.1 End of Changes; Sagar Thorave - [CR - 7049]
                    }

                }
                else
                {
                    divUWDecesioncategory.Visible = false;
                }

                if (gvExtLoadDetails.Rows.Count > 0)
                {
                    if (ddlUWDecesion.SelectedValue == "Approved")
                    {
                        //ddlUWreason1.SelectedValue = "A02";
                    }
                }


                index++;
            }

        }
        catch (Exception ex)
        {


        }
        finally
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "disp_confirm", "<script>hideloading()</script>", false);
        }
    }

    protected void ddlUWDecesioncategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        foreach (RepeaterItem item in rptDecision.Items)
        {


            DataSet _dsDecisionReason = new DataSet();
            HtmlGenericControl divPostponedPeriod = item.FindControl("divPostponedPeriod") as HtmlGenericControl;
            HtmlGenericControl divUWDecesioncategory = item.FindControl("divUWDecesioncategory") as HtmlGenericControl;
            HtmlGenericControl divUWReason1 = item.FindControl("divUWReason1") as HtmlGenericControl;
            HtmlGenericControl divUWReason2 = item.FindControl("divUWReason2") as HtmlGenericControl;
            HtmlGenericControl divbtnaddnewrow = item.FindControl("divbtnaddnewrow") as HtmlGenericControl;
            DropDownList ddlUWDecesioncategory = item.FindControl("ddlUWDecesioncategory") as DropDownList;
            ListBox ddlUWreason1 = item.FindControl("ddlUWreason1") as ListBox;
            DropDownList ddlUWDecesion = item.FindControl("ddlUWDecesion") as DropDownList;
            TextBox txtUWreason2 = item.FindControl("txtUWreason2") as TextBox;
            Button btnaddnewrow_Decision = item.FindControl("btnaddnewrow_Decision") as Button;
            if (ddlUWDecesion.SelectedValue == "Postponed" || ddlUWDecesion.SelectedValue == "Declined")
            {
                FillSubMasterDetailsCategory(ref _dsDecisionReason, ddlUWDecesion.SelectedItem.Text, ddlUWDecesioncategory.SelectedItem.Text, "UWReason", "");
                ddlUWreason1.DataSource = _dsDecisionReason.Tables[0];
            }
            else
            {

                //FillSubMasterDetailsCategory(ref _dsDecisionReason, "", "", "UWReason", "");
                //ddlUWreason1.DataSource = _dsDecisionReason.Tables[0];
            }


            if (_dsDecisionReason.Tables.Count > 0 && _dsDecisionReason.Tables[0].Rows.Count > 0)
            {
                divUWReason1.Visible = true;
                divUWReason2.Visible = true;
                //txtUWreason2.Text = "";
                ddlUWreason1.Items.Clear();
                if (_dsDecisionReason.Tables[0].Rows.Count > 0)
                {


                    foreach (DataRow row in _dsDecisionReason.Tables[0].Rows)
                    {

                        if (row["value"] != null)
                            ddlUWreason1.DataValueField = row["value"].ToString();
                        else
                            ddlUWreason1.DataValueField = "";

                        if (row["name"] != null)
                            ddlUWreason1.DataTextField = row["name"].ToString();
                        else
                            ddlUWreason1.DataTextField = "";

                        ddlUWreason1.Items.Add(new ListItem(ddlUWreason1.DataTextField, ddlUWreason1.DataValueField));

                    }

                }

                if (!string.IsNullOrEmpty(Request.Form[ddlUWreason1.UniqueID.ToString()]) && ddlUWreason1.Items.Count > 0)
                {

                    for (int i = 0; i < ddlUWreason1.Items.Count; i++)
                    {
                        string[] selectedarray = Request.Form[ddlUWreason1.UniqueID.ToString()].Split(',');
                        if (selectedarray.Contains(ddlUWreason1.Items[i].Value))
                            ddlUWreason1.Items[i].Selected = true;
                    }

                }
                else
                {
                    // ddlUWreason1.Items.Clear();

                }
                if (!string.IsNullOrEmpty(Request.Form[txtUWreason2.UniqueID.ToString()]))
                {
                    txtUWreason2.Text = Request.Form[txtUWreason2.UniqueID.ToString()];

                }
                else
                {
                    //txtUWreason2.Text = "";
                }

            }
            else
            {
                //divUWReason1.Visible = false;
                divUWReason2.Visible = false;
                //divbtnaddnewrow.Visible = false;
            }
        }



    }

    protected void btnaddnewrow_Decision_Click(object sender, EventArgs e)
    {
        try
        {
            HtmlGenericControl divPostponedPeriod = (HtmlGenericControl)rptDecision.FindControl("divPostponedPeriod");
            HtmlGenericControl divUWDecesioncategory = (HtmlGenericControl)rptDecision.FindControl("divUWDecesioncategory");
            HtmlGenericControl divUWReason1 = (HtmlGenericControl)rptDecision.FindControl("divUWReason1");
            HtmlGenericControl divUWReason2 = (HtmlGenericControl)rptDecision.FindControl("divUWReason2");
            HtmlGenericControl divbtnaddnewrow = (HtmlGenericControl)rptDecision.FindControl("divbtnaddnewrow") as HtmlGenericControl;
            DropDownList ddlUWDecesioncategory = (DropDownList)rptDecision.FindControl("ddlUWDecesioncategory");
            ListBox ddlUWreason1 = (ListBox)rptDecision.FindControl("ddlUWreason1");
            DropDownList ddlUWDecesion = (DropDownList)rptDecision.FindControl("ddlUWDecesion");
            TextBox txtUWreason2 = (TextBox)rptDecision.FindControl("txtUWreason2");
            Button btnaddnewrow_Decision = (Button)rptDecision.FindControl("btnaddnewrow_Decision");
            DropDownList ddlPeriod = (DropDownList)rptDecision.FindControl("ddlPeriod") as DropDownList;
            objUWDecision = new UWSaralDecision.BussLayer();
            Logger.Info("STAG 2 :PageName :Uwdecision.aspx.CS // MethodeName :btnAddLoadingRow_Click");

            int intTrackingRet = -1;
            objCommonObj = (CommonObject)Session["objCommonObj"];
            strUserId = objCommonObj._Bpmuserdetails._UserID;
            InsertUwDecisionTracking(strApplicationno, strUserId, DateTime.Now, "Decision_ADD_NEWROW", ref intTrackingRet);
            if (gvLoadingDtls.Rows.Count <= 0)
            {
                // ViewState["UWDecisionData"] = null;
                //Session["LoadingData"] = null;
            }
            // PopulateDecisionDetails();
            // btnaddnewrow_Decision.CssClass = "btn btn-primary lnkButton";
            PopulateDecisionDetails();
            objChangeObj = (ChangeValue)Session["objLoginObj"];
            string strReqFollowupCode = "SIS", strReqDescription = "Please provide consent and fresh sis for extra premium in view of Medical/Non Medical Reasons. Sign Enclosed Letter."
            , strReqCategory = "Non Medical", strReqCriteria = "FIXED", strReqLifeType = "01", strReqStatus = "L"
               , srtReqRaisedBy = objChangeObj.userLoginDetails._UserID;
            AddNewRequirement(strReqFollowupCode, strReqDescription, strReqCategory, strReqCriteria, strReqLifeType, strReqStatus
                , srtReqRaisedBy);
            UpdateUwDecisionTracking(intTrackingRet, DateTime.Now, ref intTrackingRet);
            ScriptManager.RegisterStartupScript(Page, GetType(), "disp_confirm", "<script>hideloading()</script>", false);
            DataSet _ds = new DataSet(), _dsPrevPol = new DataSet();
            int LAPushErrorCode = 0; string strLAPushErrorMsg = string.Empty; string strConsentResponse = string.Empty;
            _ds = null;
            ReplicaXml objReplicaXml = new ReplicaXml();
            int intResponse = -1;
            bool isdataSave = true;
            string strResponse = string.Empty;
            ManageDecision_Details(isdataSave, ref isdataSave, objReplicaXml, _ds, ref strResponse);
            DataSet _dsPREMCAL = new DataSet();
            objUWDecision.OnlineApplicationLAServiceDetails_PUSH(strApplicationno, strChannelType, objChangeObj, ref _ds, ref _dsPrevPol, "proposal", ref LAPushErrorCode, ref strLAPushErrorMsg, ref strConsentResponse);

            UWPreIssueServiceCall(strApplicationno, strChannelType);

            //ddlUWDecesioncategory.SelectedValue = "0";
            //ddlUWreason1.Items.Clear();
            //txtUWreason2.Text = "";
            //lblErrorDecisiondtls.Text = "";
            //End
            /*ID:18 Start*/
            //chkLoadingDtls.Checked = false;
            //updLoadingDetails.Update();
            ///*added for testing purpose*/
            //updProductDetails.Update();
            /*ID:18 End*/
        }
        catch (Exception ex)
        {

        }
        finally
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "disp_confirm", "<script>hideloading()</script>", false);
        }

    }

    public void PopulateDecisionDetails()
    {
        DataTable _dtDecisiondata = new DataTable();
        DataRow _drRow = null;
        objChangeObj = (ChangeValue)Session["objLoginObj"];
        DecisionDtls objdecisiondtls = new DecisionDtls();
        _dtDecisiondata.Columns.Add(new DataColumn("lblAppno", typeof(string)));
        _dtDecisiondata.Columns.Add(new DataColumn("lblPolNum", typeof(string)));
        _dtDecisiondata.Columns.Add(new DataColumn("ddlUWDecesion", typeof(string)));
        _dtDecisiondata.Columns.Add(new DataColumn("ddlUWDecesioncategory", typeof(string)));
        _dtDecisiondata.Columns.Add(new DataColumn("ddlUWreason1", typeof(string)));
        _dtDecisiondata.Columns.Add(new DataColumn("txtUWreason2", typeof(string)));
        _dtDecisiondata.Columns.Add(new DataColumn("ddlPeriod", typeof(string)));

        foreach (RepeaterItem item in rptDecision.Items)
        {
            Logger.Info("STAG 2 :PageName :Uwdecision.aspx.CS // MethodeName :PopulateLoadingDetails" + System.Environment.NewLine);
            HtmlGenericControl divPostponedPeriod = item.FindControl("divPostponedPeriod") as HtmlGenericControl;
            HtmlGenericControl divUWDecesioncategory = item.FindControl("divUWDecesioncategory") as HtmlGenericControl;
            HtmlGenericControl divUWReason1 = item.FindControl("divUWReason1") as HtmlGenericControl;
            HtmlGenericControl divUWReason2 = item.FindControl("divUWReason2") as HtmlGenericControl;
            //HtmlGenericControl divbtnaddnewrow = item.FindControl("divbtnaddnewrow") as HtmlGenericControl;
            DropDownList ddlUWDecesioncategory = item.FindControl("ddlUWDecesioncategory") as DropDownList;
            ListBox ddlUWreason1 = item.FindControl("ddlUWreason1") as ListBox;
            DropDownList ddlUWDecesion = item.FindControl("ddlUWDecesion") as DropDownList;
            TextBox txtUWreason2 = item.FindControl("txtUWreason2") as TextBox;
            // Button btnaddnewrow_Decision = item.FindControl("btnaddnewrow_Decision") as Button;
            DropDownList ddlPeriod = item.FindControl("ddlPeriod") as DropDownList;
            Label lblAppno = item.FindControl("lblAppno") as Label;
            Label lblPolNum = item.FindControl("lblPolNum") as Label;
            //GridView griddecision = item.FindControl("griddecision") as GridView;
            string uwsplitstr = Request.Form[ddlUWreason1.UniqueID];
            if (uwsplitstr == null)
            {
                uwsplitstr = "";
            }


            if (ViewState["UWDecisionData"] == null)
            {
                _drRow = _dtDecisiondata.NewRow();
                _drRow[0] = lblAppno.Text;
                _drRow[1] = lblPolNum.Text;
                _drRow[2] = ddlUWDecesion.SelectedItem.Text;
                if (ddlUWDecesion.SelectedItem.Text == "Postponed" || ddlUWDecesion.SelectedItem.Text == "Declined")
                {

                    _drRow[3] = ddlUWDecesioncategory.SelectedItem.Text;
                    _drRow[4] = ddlUWreason1.SelectedItem.Text;// = uwsplitstr.Split(',')[0];
                    _drRow[5] = txtUWreason2.Text = Request.Form[txtUWreason2.UniqueID];
                    _drRow[6] = ddlPeriod.SelectedItem.Text;
                }
                else
                {
                    _drRow[3] = "";
                    _drRow[4] = ddlUWreason1.SelectedItem.Text;
                    _drRow[5] = "";
                    _drRow[6] = "";
                }

                _dtDecisiondata.Rows.Add(_drRow);
            }
            else
            {
                _dtDecisiondata = (DataTable)ViewState["UWDecisionData"];
                _drRow = _dtDecisiondata.NewRow();
                _drRow[0] = lblAppno.Text;
                _drRow[1] = lblPolNum.Text;
                _drRow[2] = ddlUWDecesion.SelectedItem.Text;
                if (ddlUWDecesion.SelectedItem.Text == "Postponed" || ddlUWDecesion.SelectedItem.Text == "Declined")
                {

                    _drRow[3] = ddlUWDecesioncategory.SelectedItem.Text;
                    _drRow[4] = ddlUWreason1.SelectedItem.Text;//= uwsplitstr.Split(',')[0];
                    _drRow[5] = txtUWreason2.Text = Request.Form[txtUWreason2.UniqueID];
                    _drRow[6] = ddlPeriod.SelectedItem.Text;
                }
                else
                {
                    _drRow[3] = "";
                    _drRow[4] = ddlUWreason1.SelectedItem.Text;
                    _drRow[5] = "";
                    _drRow[6] = "";
                }

                _dtDecisiondata.Rows.Add(_drRow);

            }
        }
        ViewState["UWDecisionData"] = _dtDecisiondata.Copy();
        griddecision.DataSource = _dtDecisiondata;
        griddecision.DataBind();
        if (griddecision.Rows.Count > 0)
        {

            //hdnIsConsentReq.Value = response.ToString();
            if (objChangeObj.Decision_details == null)
            {
                objChangeObj.Decision_details = new DecisionDtls();
            }

            objdecisiondtls._strProdcode = objChangeObj.Decision_details._strProdcode;
            objdecisiondtls.isConsentRequired = true;
            objChangeObj.Decision_details = objdecisiondtls;
            Session["objLoginObj"] = objChangeObj;
        }
        else
        {
            objChangeObj.Decision_details.isConsentRequired = false;
        }
        foreach (RepeaterItem item in rptDecision.Items)
        {
            DropDownList ddlUWDecesioncategory = item.FindControl("ddlUWDecesioncategory") as DropDownList;
            ListBox ddlUWreason1 = item.FindControl("ddlUWreason1") as ListBox;
            DropDownList ddlUWDecesion = item.FindControl("ddlUWDecesion") as DropDownList;
            TextBox txtUWreason2 = item.FindControl("txtUWreason2") as TextBox;
            Button btnaddnewrow_Decision = item.FindControl("btnaddnewrow_Decision") as Button;
            DropDownList ddlPeriod = item.FindControl("ddlPeriod") as DropDownList;
            HtmlGenericControl divPostponedPeriod = item.FindControl("divPostponedPeriod") as HtmlGenericControl;
            HtmlGenericControl divUWDecesioncategory = item.FindControl("divUWDecesioncategory") as HtmlGenericControl;
            HtmlGenericControl divUWReason1 = item.FindControl("divUWReason1") as HtmlGenericControl;
            HtmlGenericControl divUWReason2 = item.FindControl("divUWReason2") as HtmlGenericControl;
            //GridView griddecision = (GridView)rptDecision.FindControl("griddecision");
            //ddlUWreason1.Items.Clear();
            // txtUWreason2.Text = "";
            // ddlPeriod.SelectedValue = "0";
            // ddlUWDecesioncategory.Items.Clear();

            if (ddlUWDecesion.SelectedValue == "Postponed" || ddlUWDecesion.SelectedValue == "Declined")
            {
                divUWReason1.Visible = true;
                divUWReason2.Visible = true;
                divUWDecesioncategory.Visible = true;
                if (ddlUWDecesion.SelectedValue == "Postponed")
                {
                    divPostponedPeriod.Visible = true;
                }
                else
                {
                    divPostponedPeriod.Visible = false;
                }

                ddlUWDecesion.SelectedValue = Request.Form[ddlUWDecesion.UniqueID];
                ddlUWDecesioncategory.SelectedValue = Request.Form[ddlUWDecesioncategory.UniqueID];
                ddlPeriod.SelectedValue = Request.Form[ddlPeriod.UniqueID];
                //ddlUWreason1.SelectedItem.Text ;//= Request.Form[ddlUWreason1.UniqueID].Split(',')[0];
                txtUWreason2.Text = Request.Form[txtUWreason2.UniqueID];
            }
            else
            {
                ddlUWDecesion.SelectedValue = Request.Form[ddlUWDecesion.UniqueID];
                // ddlUWreason1.SelectedItem.Text = Request.Form[ddlUWreason1.UniqueID].Split(',')[0];
                divUWReason1.Visible = true;
            }

            //divUWReason2.Visible = false;


        }
        // Session["objLoginObj"] = objChangeObj;


    }
    private void ManageDecision_Details(bool blnUpdateInLa, ref bool isdataSave, ReplicaXml objReplica, DataSet _dsPremium, ref string strErrorMessage)
    {
        Logger.Info(strApplicationno + "STEP :6 Save Decision details Start" + System.Environment.NewLine);
        Logger.Info(strApplicationno + "Remark:" + "Bank details" + "STAG 8 :PageName :Uwdecision.aspx.CS // MethodeName :ManageDecision_Details" + System.Environment.NewLine);
        Logger.Info(strApplicationno + "Is Updated in datatabse:" + blnUpdateInLa + System.Environment.NewLine);
        try
        {
            DataTable _dtDecisiondata = new DataTable();
            lblErrorloadingdtls.Text = string.Empty;
            int DecisionResult = 0;
            objChangeObj = (ChangeValue)Session["objLoginObj"];
            Logger.Info(strApplicationno + "STAG 15 :PageName :Uwdecision.aspx.CS // MethodeName :btnLoadingDtlsSave_Click" + System.Environment.NewLine);
            string _strDecisionType = string.Empty;
            string _strCategory = string.Empty;
            string _strUwreason1 = string.Empty;
            string _strUwreason2 = string.Empty;
            string _strperiod = string.Empty;


            _dtDecisiondata = (DataTable)ViewState["UWDecisionData"];
            int i = 0;

            
            // lstLoading.Add(objLoadingSection);
            Logger.Info(strApplicationno + "MethodeName :ManageLoadingDetails Object" + System.Environment.NewLine);
            // Logger.Info(strApplicationno + "MethodeName :ManageLoadingDetails Object" + GetXMLFromObject(objLoadingSection) + System.Environment.NewLine);


            //pull value from view state
            if (_dtDecisiondata != null && _dtDecisiondata.Rows.Count > 0)
            {
                Logger.Info(strApplicationno + "Save data from Selecting loading  begin" + System.Environment.NewLine);
                for (i = 0; i < _dtDecisiondata.Rows.Count; i++)
                {


                    _strDecisionType = _dtDecisiondata.Rows[i]["ddlUWDecesion"].ToString();

                    _strCategory = _dtDecisiondata.Rows[i]["ddlUWDecesioncategory"].ToString();

                    _strUwreason1 = _dtDecisiondata.Rows[i]["ddlUWreason1"].ToString();

                    _strUwreason2 = _dtDecisiondata.Rows[i]["txtUWreason2"].ToString();

                    _strperiod = _dtDecisiondata.Rows[i]["ddlperiod"].ToString();


                    if (blnUpdateInLa)
                    {
                        Logger.Info(strApplicationno + "Save View state Loading data from" + System.Environment.NewLine);
                        objComm.OnlineDecisionDetails_Save( strApplicationno, _strDecisionType, _strCategory, _strUwreason1, _strUwreason2, _strperiod, objChangeObj.userLoginDetails._UserID, objChangeObj.userLoginDetails._UserName, objChangeObj.userLoginDetails._UserGroup, objChangeObj.userLoginDetails._userBranch, objChangeObj.userLoginDetails._ProcessName,  ref DecisionResult);


                        if (DecisionResult > 0)
                        {
                            Logger.Info(strApplicationno + "Save View state Loading data to database Success" + System.Environment.NewLine);
                            lblErrorDecisiondtls.Text = " Decision Details Save Successfully In DataBase";
                            //lblErrorDecisiondtls.Text += " Decision Details Save Successfully In DataBase";
                        }
                        else
                        {
                            Logger.Info(strApplicationno + "Save View state Loading data to database Failed" + System.Environment.NewLine);
                            lblErrorDecisiondtls.Text = " Decision Details Not Save Successfully In DataBase Click Here To Know More";
                            // lblErrorDecisiondtls.Text += " Decision Details Not Save Successfully In DataBase";
                        }
                    }
                    // lstLoading.Add(objLoadingSection);
                    Logger.Info(strApplicationno + "MethodeName :ManageLoadingDetails Object" + System.Environment.NewLine);
                    //Logger.Info(strApplicationno + "MethodeName :ManageLoadingDetails Object" + GetXMLFromObject(objLoadingSection) + System.Environment.NewLine);
                }

                Logger.Info(strApplicationno + "MethodeName :ManageDecision_Details Object" + System.Environment.NewLine);
                // Logger.Info(strApplicationno + "MethodeName :ManageDecision_Details Object" + GetXMLFromObject(lstLoading) + System.Environment.NewLine);

            }
           
        }
        catch (Exception Error)
        {
            strErrorMessage = "Error While Saving Decision Details,Please Contact System Admin ";
            isdataSave = false;
            Logger.Info(strApplicationno + "Remark:" + "Exception Requirments details" + "STAG 8 :PageName :Uwdecision.aspx.CS // MethodeName :ManageDecision_Details" + System.Environment.NewLine);
            Logger.Info(strApplicationno + "Exception Message:" + Error.Message + System.Environment.NewLine);
            if (Error.Message.Contains("UDE-"))
            {
                throw new Exception(Error.Message);
            }
            else
            {
                throw new Exception("Try Again Later");
            }
        }
        Logger.Info(strApplicationno + "STEP :6 Save Decision details end" + System.Environment.NewLine);
    }
    protected void lnkDecisionRemoveRow_Click1(object sender, EventArgs e)
    {

        try
        {

            Logger.Info("STAG 2 :PageName :Uwdecision.aspx.CS // MethodeName :lnkDecisionRemoveRow_Click" + System.Environment.NewLine);
            LinkButton lb = (LinkButton)sender;
            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;

            int rowID = gvRow.RowIndex + 1;
            if (ViewState["UWDecisionData"] != null)
            {
                int intResponse = 0;
                DataTable dt = (DataTable)ViewState["UWDecisionData"];
                if (dt.Rows.Count >= 1)
                {
                    DataRow dr = dt.Rows[rowID - 1];
                    DeleteExistingDecision(strApplicationno, ref intResponse);
                    if (gvRow.RowIndex <= dt.Rows.Count - 1)
                    {
                        dt.Rows.Remove(dt.Rows[rowID - 1]);
                    }
                }
                if (dt.Rows.Count == 0)
                {
                    objChangeObj = (ChangeValue)Session["objLoginObj"];
                    objChangeObj.Decision_details.isConsentRequired = false;
                    Session["objLoginObj"] = objChangeObj;
                }
                //Store the current data in ViewState for future reference
                if (ViewState["UWDecisionData"] != null)
                {
                    griddecision.DataSource = dt;
                }
                else
                {
                    ViewState["UWDecisionData"] = null;
                    ViewState["UWDecisionData"] = dt;
                    griddecision.DataSource = dt;
                }

                //Re bind the GridView for the updated data

                griddecision.DataBind();

                //ddlUWreason1.Items.Clear();
                //txtUWreason2.Text = "";
                //ddlPeriod.SelectedValue = "0";
                if (intResponse > 0)
                {
                    Logger.Info(strApplicationno + "Save View state Loading data to database Success" + System.Environment.NewLine);
                    lblErrorDecisiondtls.Text = " Decision Details Removed Successfully In DataBase";
                    //lblErrorDecisiondtls.Text += " Decision Details Save Successfully In DataBase";
                }
                else
                {
                    Logger.Info(strApplicationno + "Save View state Loading data to database Failed" + System.Environment.NewLine);
                    lblErrorDecisiondtls.Text = " Decision Details Not Removed Successfully In DataBase Click Here To Know More";
                    // lblErrorDecisiondtls.Text += " Decision Details Not Save Successfully In DataBase";
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "disp_confirm", "<script>hideloading()</script>", false);
        }
    }
    private void DeleteExistingDecision(string strAppno, ref int response)
    {
        Commfun objCommfun = new Commfun();
        objCommfun.DeleteExistingDecision(strAppno, ref response);
    }

    public void FillSubMasterDetailsCategory(ref DataSet _dsFollowuo, string strDatavalue, string category, string ddlType, string ddlsubtype)
    {
        Logger.Info(strApplicationno + "STAG 2 :PageName :Uwdecision.aspx.CS // MethodeName :FillSubMasterDetails" + System.Environment.NewLine);
        objComm.OnlineSubMasterDisplay_DecisionDetails_GET(ref _dsFollowuo, strDatavalue, category, ddlType, ddlsubtype);
    }

    //51.1 End of Changes; Bhaumik Patel - [CR - 3334]


    //protected void ddlUWDecesion_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        int index = 0;
    //        foreach (RepeaterItem item in rptDecision.Items)
    //        {

    //            DropDownList ddlUWDecesioninner = (DropDownList)item.FindControl("ddlUWDecesion");
    //            DropDownList ddlUWreasoninner = (DropDownList)item.FindControl("ddlUWreason");
    //            HtmlGenericControl divUWReason = (HtmlGenericControl)item.FindControl("divUWReason");
    //            // HtmlGenericControl divUWReason = e.item.FindControl("divUWReason") as HtmlGenericControl;
    //            HtmlGenericControl divPostponedPeriod = (HtmlGenericControl)item.FindControl("divPostponedPeriod");
    //            //49.1 Begin of Changes; Sagar Thorave - [CR - 7049]
    //            ListBox ddlUWreason1 = item.FindControl("ddlUWreason1") as ListBox;
    //            //49.1 End of Changes; Sagar Thorave - [CR - 7049]
    //            //49.1 Begin of Changes; Sagar Thorave - [CR - 7049]
    //            HtmlGenericControl Acceptance_Reason = item.FindControl("Acceptance_Reason") as HtmlGenericControl;
    //            string ddlAcceptanceReasonClass = "ddlAcceptanceReason_" + (index + 1).ToString();
    //            //49.1 End of Changes; Sagar Thorave - [CR - 7049]
    //            //49.1 Begin of Changes; Sagar Thorave - [CR - 7049]
    //            ListBox ddlAcceptanceReason = item.FindControl("ddlAcceptanceReason") as ListBox;
    //            ddlAcceptanceReason.CssClass = "form-control label ddlAcceptanceReason " + ddlAcceptanceReasonClass;
    //            DropDownList ddlPeriod = item.FindControl("ddlPeriod") as DropDownList;
    //            //49.1 End of Changes; Sagar Thorave - [CR - 7049]


    //            //50.1 Begin of Changes; Jayendra Patnakar - [WebAshlar01]
    //            HtmlGenericControl divAcceptanceOtherReasonText = item.FindControl("divAcceptanceOtherReasonText") as HtmlGenericControl;
    //            TextBox txtAcceptanceOtherReasonText = item.FindControl("txtAcceptanceOtherReasonText") as TextBox;
    //            string txtAcceptanceOtherReasonTextClass = "txtAcceptanceOtherReasonText_" + (index + 1).ToString();
    //            txtAcceptanceOtherReasonText.CssClass = "form-control txtAcceptanceOtherReasonText " + txtAcceptanceOtherReasonTextClass;
    //            //50.1 End of Changes; Jayendra Patnakar - [WebAshlar01]


    //            DataSet _dsDecisionReason = null;
    //            Logger.Info("STAG 11 :PageName :Uwdecision.aspx.CS // MethodeName :ddlUWDecesion_SelectedIndexChanged" + System.Environment.NewLine);
    //            FillSubMasterDetails(ref _dsDecisionReason, ddlUWDecesioninner.SelectedValue, "UWReason", "");
    //            ddlUWreasoninner.DataSource = _dsDecisionReason.Tables[0];
    //            if (_dsDecisionReason.Tables.Count > 0 && _dsDecisionReason.Tables[0].Rows.Count > 0)
    //            {
    //                divUWReason.Visible = true;
    //                ddlUWreasoninner.DataTextField = "NAME";
    //                ddlUWreasoninner.DataValueField = "VALUE";
    //                ddlUWreasoninner.DataBind();
    //                ddlUWreasoninner.Items.Insert(0, new ListItem("--Select--", "0"));
    //            }
    //            else
    //            {
    //                divUWReason.Visible = false;
    //            }
    //            if (ddlUWDecesioninner.SelectedValue == "Postponed")
    //            {
    //                //49.1 Begin of Changes; Sagar Thorave - [CR - 7049]
    //                Acceptance_Reason.Visible = false;
    //                //49.1 End of Changes; Sagar Thorave - [CR - 7049]
    //                clsName = divPostponedPeriod.Attributes["class"].ToString();
    //                divPostponedPeriod.Attributes.Add("class", clsName.Replace(clsName, "col-md-12"));
    //            }
    //            else if (ddlUWDecesioninner.SelectedValue == "Approved")
    //            {
    //                //txtriskcat.Text = "High";
    //                if (txtriskcat.Text == "High" || txtriskcat.Text == "Very High")
    //                {
    //                    ScriptManager.RegisterStartupScript(Page, GetType(), "fnAcceptanceReason", "fnAcceptanceReason()", true);
    //                    DataSet ds = new DataSet();
    //                    FillAcceptanceMaster(ref ds);
    //                    Acceptance_Reason.Visible = true;
    //                    ddlPeriod.ClearSelection();
    //                    divUWReason.Visible = false;
    //                    divPostponedPeriod.Visible = false;
    //                    if (ds.Tables[0].Rows.Count > 0)
    //                    {

    //                        ddlAcceptanceReason.Items.Clear();
    //                        //ddlUWreason1.Items.Insert(0, new ListItem("Please select ", ""));
    //                        ddlAcceptanceReason.SelectedValue = "";
    //                        foreach (DataRow row in ds.Tables[0].Rows)
    //                        {

    //                            if (row["value"] != null)
    //                                ddlAcceptanceReason.DataValueField = row["value"].ToString();
    //                            else
    //                                ddlAcceptanceReason.DataValueField = "";

    //                            if (row["name"] != null)
    //                                ddlAcceptanceReason.DataTextField = row["name"].ToString();
    //                            else
    //                                ddlAcceptanceReason.DataTextField = "";

    //                            ddlAcceptanceReason.Items.Add(new ListItem(ddlAcceptanceReason.DataTextField, ddlAcceptanceReason.DataValueField));

    //                        }

    //                    }
    //                }
    //                //49.1 End of Changes; Sagar Thorave - [CR-7049]
    //                else
    //                {
    //                    Acceptance_Reason.Visible = false;

    //                }
    //                //48.1 Begin of Changes; Sagar Thorave - [CR - 7049]
    //                if (!string.IsNullOrEmpty(Request.Form[ddlAcceptanceReason.UniqueID.ToString()]) && ddlAcceptanceReason.Items.Count > 0)
    //                {

    //                    for (int i = 0; i < ddlAcceptanceReason.Items.Count; i++)
    //                    {
    //                        string[] selectedarray = Request.Form[ddlAcceptanceReason.UniqueID.ToString()].Split(',');
    //                        if (selectedarray.Contains(ddlAcceptanceReason.Items[i].Text))
    //                            ddlAcceptanceReason.Items[i].Selected = true;
    //                    }

    //                }
    //                //48.1 End of Changes; Sagar Thorave - [CR - 7049]

    //            }

    //            else
    //            {
    //                divPostponedPeriod.Attributes.Add("class", "HideControl");
    //            }
    //            if (gvExtLoadDetails.Rows.Count > 0)
    //            {
    //                if (ddlUWDecesioninner.SelectedValue == "Approved")
    //                {
    //                    ddlUWreasoninner.SelectedValue = "A02";
    //                }
    //            }
    //            if (ddlUWDecesioninner.SelectedValue != "Approved")
    //            {
    //                Acceptance_Reason.Visible = false;
    //            }
    //            index++;
    //        }
    //        /*ID:19 START*/
    //        //if (ddlUWDecesion.SelectedValue.Equals("Declined"))
    //        //{
    //        //    if (!string.IsNullOrEmpty(txtSaralRiskScore.Text) && Convert.ToInt32(txtSaralRiskScore.Text) < 75)
    //        //    {
    //        //        FillWarningMessage("10");
    //        //        DisplaySaralWarningMessage();
    //        //    }
    //        //    if (!string.IsNullOrEmpty(txtSaralRiskChannel.Text) && txtSaralRiskChannel.Text.Equals("Bankassurance-AU"))
    //        //    {
    //        //        FillWarningMessage("11");
    //        //        DisplaySaralWarningMessage();
    //        //    }
    //        //}
    //        /*ID:19 END*/

    //    }
    //    catch (Exception ex)
    //    {


    //    }
    //    finally
    //    {
    //        ScriptManager.RegisterStartupScript(Page, GetType(), "disp_confirm", "<script>hideloading()</script>", false);
    //    }
    //}
    //49.1 Start of Changes; Sagar Thorave - [CR-7049]
    public void FillAcceptanceMaster(ref DataSet _dsFollowuo)
    {
        Logger.Info(strApplicationno + "STAG 2 :PageName :Uwdecision.aspx.CS // MethodeName :FillSubMasterDetails" + System.Environment.NewLine);
        objComm.FeatchAcceptanemaster(ref _dsFollowuo);
    }
    //49.1 End of Changes; Sagar Thorave - [CR-7049]
    protected void ddlLoadType_SelectedIndexChanged(object sender, EventArgs e)
    {
        Logger.Info("STAG 12 :PageName :Uwdecision.aspx.CS // MethodeName :ddlLoadType_SelectedIndexChanged" + System.Environment.NewLine);
        DataSet _dsLoadVal = new DataSet();
        Boolean _strLoadPer = true;
        Boolean _strRateAdjustment = true;
        Boolean _strFlatMortality = true;
        txtLoadDesc.Text = ddlLoadType.SelectedItem.Text;
        ddlLoadType.CssClass = "form-control";
        ddlLoadType.Enabled = true;
        _dsLoadVal = (DataSet)ViewState["_dsFollowuo"];

        if (_dsLoadVal.Tables.Count > 0 && _dsLoadVal.Tables["ddlLoadTypeVal"].Rows.Count > 0)
        {
            DataTable _dt = _dsLoadVal.Tables["ddlLoadTypeVal"];
            DataTable tblFiltered = _dt.AsEnumerable()
          .Where(row => row.Field<String>("LoadType") == ddlLoadType.SelectedValue
                   && row.Field<String>("PlanId") == "TD"
                   && row.Field<String>("PlanType") == "Base Plan").CopyToDataTable();

            _strLoadPer = Convert.ToBoolean(Convert.ToInt32(tblFiltered.Rows[0]["LoadPer"]));
            _strRateAdjustment = Convert.ToBoolean(Convert.ToInt32(tblFiltered.Rows[0]["RateAdjustment"]));
            _strFlatMortality = Convert.ToBoolean(Convert.ToInt32(tblFiltered.Rows[0]["FlatMortality"]));
            if (_strLoadPer)
            {
                txtLoadPer.CssClass = "form-control Numeric";
            }
            else
            {
                txtLoadPer.CssClass = "form-control lblLable";
            }

            if (_strRateAdjustment)
            {

                //47.1 Begin of Changes; Bhaumik Patel - [CR-5855]
                DataSet _dsRate = new DataSet();
                commobj.OnlineFlatMortalityDetails_GET_RateAdjust("GetRateAdjustData_ByUSERID", strUserId, ref _dsRate);
                if (_dsRate.Tables.Count > 0 && _dsRate.Tables["RateAdjust"].Rows.Count > 0)
                {
                    txtRateAdjust.CssClass = "form-control Numeric";
                    rgvrateAdjust.MinimumValue = "0";
                    rgvrateAdjust.MaximumValue = _dsRate.Tables["RateAdjust"].Rows[0]["Flat_Extra"].ToString();
                    rgvrateAdjust.ErrorMessage = "RateAdjustment Between 0 To " + _dsRate.Tables["RateAdjust"].Rows[0]["Flat_Extra"].ToString() + "";
                    rgvrateAdjust.ForeColor = System.Drawing.Color.Red;
                    UpdatePanel5.Update();
                }
                //47.1 END of Changes; Bhaumik Patel - [CR-5855]
            }
            else
            {
                txtRateAdjust.CssClass = "form-control lblLable";
            }

            if (_strFlatMortality)
            {
                ddlLoadFlatMortality.CssClass = "form-control";
                ddlLoadFlatMortality.Enabled = true;
            }
            else
            {
                ddlLoadFlatMortality.CssClass = "form-control lblLable";
                ddlLoadFlatMortality.Enabled = false;
                ddlLoadFlatMortality.SelectedIndex = 0;
            }
            ddlLoadletterPrint.CssClass = "form-control";
            ddlLoadletterPrint.Enabled = true;
            UpdatePanel5.Update();
            updLoadType.Update();

            //51.1 Begin of Changes; Bhaumik Patel - [CR - 3334]
            txtRsn1Desc.Text = "";
            txtRsn2Desc.Text = "";
            txtRsn3Desc.Text = "";
            txtRsn4Desc.Text = "";
            FillloadingReason(ddlLoadType.SelectedItem.Text);
            UpdatePanel3.Update();
            //51.1 End of Changes; Bhaumik Patel - [CR - 3334]
        }

    }
    //51.1 Begin of Changes; Bhaumik Patel - [CR - 3334]
    public void FillloadingReason(String lodingtype)
    {
        chkredflag.Checked = false;
        DataTable _reason = new DataTable();
        objComm.OnlinelReason_Based_loadType_MasterDetails_GET(ref _ds, strChannelType, lodingtype, strApplicationno);
        BindRLoadType_Reaso_Details(_ds.Tables[0]);

    }

    public void BindRLoadType_Reaso_Details(DataTable _ds)
    {
        if (_ds.Rows.Count > 0)
        {

            ddlLoadRsn1.Items.Clear();
            ddlLoadRsn1.SelectedValue = "";
            foreach (DataRow row in _ds.Rows)
            {

                if (row["value"] != null)
                    ddlLoadRsn1.DataValueField = row["value"].ToString();
                else
                    ddlLoadRsn1.DataValueField = "";

                if (row["name"] != null)
                    ddlLoadRsn1.DataTextField = row["name"].ToString();
                else
                    ddlLoadRsn1.DataTextField = "";

                ddlLoadRsn1.Items.Add(new ListItem(ddlLoadRsn1.DataTextField, ddlLoadRsn1.DataValueField));

            }

        }



    }

    //protected void ddlLoadRsn1_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    DataSet _dsLoadReasonDiscp = new DataSet();
    //    Logger.Info("STAG 13 :PageName :Uwdecision.aspx.CS // MethodeName :ddlLoadRsn1_SelectedIndexChanged" + System.Environment.NewLine);
    //    ddlLoadRsn1.Enabled = true;
    //    FillSubMasterDetails(ref _dsLoadReasonDiscp, ddlLoadRsn1.SelectedValue, "LoadReason1", "");
    //    if (_dsLoadReasonDiscp.Tables.Count > 0 && _dsLoadReasonDiscp.Tables[0].Rows.Count > 0)
    //    {
    //        txtRsn1Desc.Text = _dsLoadReasonDiscp.Tables[0].Rows[0]["NAME"].ToString();
    //        ddlLoadRsn1.CssClass = "form-control";
    //    }
    //}
    //protected void ddlLoadRsn2_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    DataSet _dsLoadReasonDiscp = new DataSet();
    //    Logger.Info("STAG 14 :PageName :Uwdecision.aspx.CS // MethodeName :ddlLoadRsn2_SelectedIndexChanged" + System.Environment.NewLine);
    //    ddlLoadRsn2.Enabled = true;
    //    FillSubMasterDetails(ref _dsLoadReasonDiscp, ddlLoadRsn2.SelectedValue, "LoadReason2", "");
    //    if (_dsLoadReasonDiscp.Tables.Count > 0 && _dsLoadReasonDiscp.Tables[0].Rows.Count > 0)
    //    {
    //        txtRsn2Desc.Text = _dsLoadReasonDiscp.Tables[0].Rows[0]["NAME"].ToString();
    //        ddlLoadRsn2.CssClass = "form-control";

    //    }
    //}

    //51.1 End of Changes; Bhaumik Patel - [CR - 3334]

    protected void btncalculatePrem_Load_Click(object sender, EventArgs e)
    {
        try
        {
            /*added by shri on 28 dec 17 to add tracking*/
            int intTrackingRet = -1;
            objCommonObj = (CommonObject)Session["objCommonObj"];
            strUserId = objCommonObj._Bpmuserdetails._UserID;
            InsertUwDecisionTracking(strApplicationno, strUserId, DateTime.Now, "LOADING_PREM", ref intTrackingRet);
            /*end here*/
            int _ProdResult = 0;
            string strComboMonthlyPayout = string.Empty;
            string strProdMonthlyPayout = string.Empty;
            //lblErrorproddtls.Text = "";
            //gridPremCal_Product.DataSource = null;
            //gridPremCal_Product.DataBind();
            //  objCommonObj = (CommonObject)Session["objCommonObj"];
            //lblErrorproddtls.Text = string.Empty;
            objChangeObj = (ChangeValue)Session["objLoginObj"];
            Logger.Info(strApplicationno + "STAG 8 :PageName :Uwdecision.aspx.CS // MethodeName :btnProddtlsSave_Click" + System.Environment.NewLine);
            ProdDtls objprodchangevalue = new ProdDtls();
            //gridPremCal_Product.DataSource = null;
            //gridPremCal_Product.DataBind();
            //objprodchangevalue._PolicyTerm = Request.Form[txtPolterm.UniqueID];
            //objprodchangevalue._Premiumpayingterm = Request.Form[txtPrepayterm.UniqueID];
            //objprodchangevalue._Sumassured = Request.Form[txtSumassure.UniqueID];
            //objprodchangevalue._Paymentfrequency = ddlFrequency.SelectedValue;
            //strProdMonthlyPayout = objprodchangevalue._MonthlyPayoutBase = Request.Form[txtMonthlyPayoutBase.UniqueID];
            //objprodchangevalue._ProdcodeBase = txtProdcode.Text;
            //// objprodchangevalue._Amountinsis = txtSisamount.Text;
            //objprodchangevalue._Basepremiumamount = Request.Form[txtBasepremium.UniqueID];
            //objprodchangevalue._TotalPremiumamount = txtTotalpremium.Text;
            foreach (RepeaterItem item in rptproductlist.Items)
            {
                TextBox txtAppno = (TextBox)item.FindControl("txtAppno");
                if (txtAppno.Text == ddlAppNo.SelectedValue)
                {


                    TextBox txtBasepolno = (TextBox)item.FindControl("txtBasepolno");
                    TextBox txtProdcode = (TextBox)item.FindControl("txtProdcode");
                    TextBox txtProname = (TextBox)item.FindControl("txtProname");
                    TextBox txtPolterm = (TextBox)item.FindControl("txtPolterm");
                    TextBox txtPrepayterm = (TextBox)item.FindControl("txtPrepayterm");
                    TextBox txtSumassure = (TextBox)item.FindControl("txtSumassure");
                    DropDownList ddlFrequency = (DropDownList)item.FindControl("ddlFrequency");
                    TextBox txtBasepremium = (TextBox)item.FindControl("txtBasepremium");
                    TextBox txtServicetax = (TextBox)item.FindControl("txtServicetax");
                    TextBox txtTotalpremium = (TextBox)item.FindControl("txtTotalpremium");
                    TextBox txtMonthlyPayoutBase = (TextBox)item.FindControl("txtMonthlyPayoutBase");

                    objprodchangevalue._PolicyTerm = txtPolterm.Text;// GetData("POLNum");
                    objprodchangevalue._Premiumpayingterm = txtPrepayterm.Text;//GetData("POLNum");
                    objprodchangevalue._Sumassured = txtSumassure.Text;//GetData("POLNum");
                    objprodchangevalue._Paymentfrequency = ddlFrequency.SelectedValue;//ddlFrequency.SelectedValue;
                    strProdMonthlyPayout = objprodchangevalue._MonthlyPayoutBase = txtMonthlyPayoutBase.Text;//GetData("POLNum");
                    objprodchangevalue._ProdcodeBase = txtProdcode.Text;//GetData("POLNum");
                                                                        // objprodchangevalue._Amountinsis = txtSisamount.Text;
                    objprodchangevalue._Basepremiumamount = txtBasepremium.Text;//GetData("POLNum");
                    objprodchangevalue._TotalPremiumamount = txtTotalpremium.Text;//GetData("POLNum");
                }
            }
            /*
            if (!string.IsNullOrEmpty(txtCombProdCode.Text))
            {
                objprodchangevalue._ProdcodeCombo = Request.Form[txtCombProdCode.UniqueID];
                objprodchangevalue._PolicyTermCombo = Request.Form[txtCombPolTerm.UniqueID];
                objprodchangevalue._PremiumpayingtermCombo = Request.Form[txtCombPayTerm.UniqueID];
                objprodchangevalue._SumassuredCombo = Request.Form[txtCombSumAssured.UniqueID];
                objprodchangevalue._BasepremiumamountCombo = txtCombPremAmount.Text;
                objprodchangevalue._TotalPremiumamountCombo = txtCombTotalPrem.Text;
                strComboMonthlyPayout = objprodchangevalue._MonthlyPayoutCombo = Request.Form[txtComboMonthlyPayout.UniqueID];
            }
            */
            objChangeObj.Prod_policydetails = objprodchangevalue;

            //To Bring NonMedicalLoading and MedicalClass
            FillLoadParam(ref objChangeObj, ddlAppNo.SelectedValue);

            objUWDecision.OnlineApplicationLAServiceDetails_PUSH(strApplicationno, strChannelType, objChangeObj, ref _ds, ref _dsPrevPol, "PREMIUMCAL", ref strLApushErrorCode, ref strLApushStatus, ref strConsentRespons);
            if (_ds != null && _ds.Tables[0].Rows.Count > 0)
            {
                //23nov2017
                //_ds.Tables[0].Columns.RemoveAt(2);
                //_ds.Tables[0].Columns.RemoveAt(2);
                gridPremCal_Loading.DataSource = _ds;
                gridPremCal_Loading.DataBind();
                chkProductDtls.Checked = false;
                lblErrorLoadingDetailBody.Text = lblErrorloadingdtls.Text = "Premium Calculation Success";
                /*ID:18 Start*/
                chkLoadingDtls.Checked = false;
                /*ID:18 End*/
                //29.1 Begin of Changes by Akshada; CR-28153	
                hfdCalPremSA.Value = objprodchangevalue._Sumassured;//txtSumassure.Text.Trim();
                hfdCalPremFlag.Value = "1";
                //29.1 End of Changes by Akshada; CR-28153
            }
            else
            {
                /*ID:18 Start*/
                chkLoadingDtls.Checked = false;

                /*ID:18 End*/
                FillProductDetails(strApplicationno, strChannelType);
                chkProductDtls.Checked = false;
                lblErrorloadingdtls.Text = "Premium Calculation Failed";
                //29.1 Begin of Changes by Akshada; CR-28153	
                hfdCalPremFlag.Value = "0";
                //29.1 End of Changes by Akshada; CR-28153
                lblErrorLoadingDetailBody.Text = strLApushStatus;
            }
            /*added by shri on 28 dec 17 to update tracking*/
            UpdateUwDecisionTracking(intTrackingRet, DateTime.Now, ref intTrackingRet);
            /*END HERE*/
        }
        catch (Exception ex)
        {

        }
        finally
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "disp_confirm", "<script>hideloading()</script>", false);
        }
    }
    int copy = 0;
    DataTable dtcopy = new DataTable();
    protected void btncalculatePrem_Prod_Click(object sender, EventArgs e)
    {
        try
        {
            #region Coomented code


            //int _ProdResult = 0;
            //string strComboMonthlyPayout = string.Empty;
            //string strProdMonthlyPayout = string.Empty;
            //lblErrorproddtls.Text = "";
            //gridPremCal_Product.DataSource = null;
            //gridPremCal_Product.DataBind();
            ////  objCommonObj = (CommonObject)Session["objCommonObj"];
            //lblErrorproddtls.Text = string.Empty;
            //objChangeObj = (ChangeValue)Session["objLoginObj"];
            //Logger.Info(strApplicationno + "STAG 8 :PageName :Uwdecision.aspx.CS // MethodeName :btnProddtlsSave_Click" + System.Environment.NewLine);
            //ProdDtls objprodchangevalue = new ProdDtls();
            //gridPremCal_Product.DataSource = null;
            //gridPremCal_Product.DataBind();
            //objprodchangevalue._PolicyTerm = Request.Form[txtPolterm.UniqueID];
            //objprodchangevalue._Premiumpayingterm = Request.Form[txtPrepayterm.UniqueID];
            //objprodchangevalue._Sumassured = Request.Form[txtSumassure.UniqueID];
            //objprodchangevalue._Paymentfrequency = ddlFrequency.SelectedValue;
            //strProdMonthlyPayout = objprodchangevalue._MonthlyPayoutBase = Request.Form[txtMonthlyPayoutBase.UniqueID];
            //objprodchangevalue._ProdcodeBase = txtProdcode.Text;
            //// objprodchangevalue._Amountinsis = txtSisamount.Text;
            //objprodchangevalue._Basepremiumamount = Request.Form[txtBasepremium.UniqueID];
            //objprodchangevalue._TotalPremiumamount = txtTotalpremium.Text;
            //if (!string.IsNullOrEmpty(txtCombProdCode.Text))
            //{
            //    objprodchangevalue._ProdcodeCombo = Request.Form[txtCombProdCode.UniqueID];
            //    objprodchangevalue._PolicyTermCombo = Request.Form[txtCombPolTerm.UniqueID];
            //    objprodchangevalue._PremiumpayingtermCombo = Request.Form[txtCombPayTerm.UniqueID];
            //    objprodchangevalue._SumassuredCombo = Request.Form[txtCombSumAssured.UniqueID];
            //    objprodchangevalue._BasepremiumamountCombo = txtCombPremAmount.Text;
            //    objprodchangevalue._TotalPremiumamountCombo = txtCombTotalPrem.Text;
            //    strComboMonthlyPayout = objprodchangevalue._MonthlyPayoutCombo = Request.Form[txtComboMonthlyPayout.UniqueID];
            //}
            //objChangeObj.Prod_policydetails = objprodchangevalue;
            ///*added by shri to rider details */
            //bool blnIsGreateThanSumAssured = true;
            //List<RiderInfo> LstRiderInfo = new List<RiderInfo>();
            //foreach (GridViewRow rowfollowup in gvRiderDtls.Rows)
            //{
            //    RiderInfo objRiderInfo = new RiderInfo();
            //    //define variable            
            //    CheckBox cbIsRider = (CheckBox)rowfollowup.FindControl("chkremoveRider");
            //    Label lblRiderName = (Label)rowfollowup.FindControl("lblRiderName");
            //    Label lblRiderCode = (Label)rowfollowup.FindControl("lblRiderCode");
            //    TextBox txtRiderSumAssured = (TextBox)rowfollowup.FindControl("txtRiderSumAssure");
            //    TextBox txtRiderTotalPremium = (TextBox)rowfollowup.FindControl("txtRiderPremium");
            //    TextBox txtServiceTax = (TextBox)rowfollowup.FindControl("txtriderservicetax");
            //    string[] strRiderSumAssured = txtRiderSumAssured.Text.Split(',');
            //    string[] strRiderTotalPremium = txtRiderTotalPremium.Text.Split(',');
            //    string[] strServiceTax = txtServiceTax.Text.Split(',');
            //    if (strRiderSumAssured.Length > 0)
            //    {
            //        txtRiderSumAssured.Text = strRiderSumAssured[strRiderSumAssured.Length - 1];
            //    }
            //    if (strRiderTotalPremium.Length > 0)
            //    {
            //        txtRiderTotalPremium.Text = strRiderTotalPremium[strRiderTotalPremium.Length - 1];
            //    }
            //    if (strServiceTax.Length > 0)
            //    {
            //        txtServiceTax.Text = strServiceTax[strServiceTax.Length - 1];
            //    }
            //    if (cbIsRider.Checked && string.IsNullOrEmpty(txtRiderSumAssured.Text))
            //    {
            //        lblRiderDetailsError.Text = "Enter sum assured for all the checked riders";
            //        return;
            //    }
            //    else if (cbIsRider.Checked && !string.IsNullOrEmpty(txtRiderSumAssured.Text) && Convert.ToDouble(txtRiderSumAssured.Text) < 1)
            //    {
            //        lblRiderDetailsError.Text = "Enter sum assured for all the checked riders";
            //        return;
            //    }
            //    //get value from it
            //    if (cbIsRider.Checked)
            //    {

            //    }


            //    objRiderInfo.RiderId = lblRiderCode.Text;
            //    objRiderInfo.SumAssured = string.IsNullOrEmpty(txtRiderSumAssured.Text) ? Convert.ToDouble("0.00") : Convert.ToDouble(txtRiderSumAssured.Text);
            //    LstRiderInfo.Add(objRiderInfo);
            //    //add data row to datatable            
            //    if (!string.IsNullOrEmpty(txtRiderSumAssured.Text))
            //    {
            //        if (Convert.ToDouble(txtRiderSumAssured.Text) > Convert.ToDouble(txtSumassure.Text))
            //        {
            //            blnIsGreateThanSumAssured = false;
            //            break;
            //        }
            //    }
            //}
            //if (blnIsGreateThanSumAssured)
            //{
            //    Page.ClientScript.RegisterStartupScript(Page.GetType(), "show rider message", "alert('Rider Sum sssured should be less than total sum assured');", true);
            //    return;
            //}
            ///*end here*/
            //objChangeObj.RiderInfo = LstRiderInfo;
            //objUWDecision.OnlineApplicationLAServiceDetails_PUSH(strApplicationno, strChannelType, objChangeObj, ref _ds, "PREMIUMCAL", ref strLApushErrorCode, ref strLApushStatus);
            //if (_ds != null && _ds.Tables[0].Rows.Count > 0)
            //{
            //    _ds.Tables[0].Columns.RemoveAt(2);
            //    _ds.Tables[0].Columns.RemoveAt(2);
            //    gridPremCal_Product.DataSource = _ds;
            //    gridPremCal_Product.DataBind();
            //    chkProductDtls.Checked = false;
            //}
            //else
            //{
            //    FillProductDetails(strApplicationno, strChannelType);
            //    chkProductDtls.Checked = false;
            //    lblErrorproddtls.Text = "Premium Calculation Failed to know more click here";
            //    lblErrorProductDetailBody.Text = strLApushStatus;
            //}
            #endregion


            //added by suraj for combi
            foreach (RepeaterItem item in rptproductlist.Items)
            {
                TextBox txtProdcode = (TextBox)item.FindControl("txtProdcode");
                TextBox txtPolterm = (TextBox)item.FindControl("txtPolterm");
                TextBox txtPrepayterm = (TextBox)item.FindControl("txtPrepayterm");
                TextBox txtSumassure = (TextBox)item.FindControl("txtSumassure");
                TextBox txtBasepremium = (TextBox)item.FindControl("txtBasepremium");
                TextBox txtMonthlyPayoutBase = (TextBox)item.FindControl("txtMonthlyPayoutBase");
                DropDownList ddlFrequency = (DropDownList)item.FindControl("ddlFrequency");
                TextBox txtTotalpremium = (TextBox)item.FindControl("txtTotalpremium");
                TextBox txtBasepolno = (TextBox)item.FindControl("txtBasepolno");
                TextBox txtProname = (TextBox)item.FindControl("txtProname");
                TextBox txtServicetax = (TextBox)item.FindControl("txtServicetax");
                GridView gridPremCal_Product = (GridView)item.FindControl("gridPremCal_Product");
                Label lblErrorproddtls = (Label)item.FindControl("lblErrorproddtls");
                Label lblErrorProductDetailBody = (Label)item.FindControl("lblErrorProductDetailBody");

                //added by suraj for new product code T36/37 & E91/92
                DropDownList ddlCategory = (DropDownList)item.FindControl("ddlCategory");
                DropDownList ddlPayoutTerm = (DropDownList)item.FindControl("ddlPayoutTerm");
                DropDownList ddlPayoutType = (DropDownList)item.FindControl("ddlPayoutType");
                DropDownList ddlpayoutfreq = (DropDownList)item.FindControl("ddlpayoutfreq");
                TextBox txtLumpSumPercent = (TextBox)item.FindControl("txtLumpSumPercent");
                DropDownList ddlprodcategory = (DropDownList)item.FindControl("ddlprodcategory");
                //end

                string strProdMonthlyPayout = string.Empty;
                ProdDtls objprodchangevalue = new ProdDtls();
                ProductSection objProductSectionBase = new ProductSection();
                List<ProductSection> lstprodctlistsec = new List<ProductSection>();

                objProductSectionBase.ProductCode = objprodchangevalue._ProdcodeBase = Request.Form[txtProdcode.UniqueID];
                objProductSectionBase.PolicyTerm = objprodchangevalue._PolicyTerm = Request.Form[txtPolterm.UniqueID];
                objProductSectionBase.PremiumTerm = objprodchangevalue._Premiumpayingterm = Request.Form[txtPrepayterm.UniqueID];
                objProductSectionBase.SumAssured = objprodchangevalue._Sumassured = Request.Form[txtSumassure.UniqueID];
                objProductSectionBase.PremiumFreq = objprodchangevalue._Paymentfrequency = ddlFrequency.SelectedValue;
                objProductSectionBase.BasePremium = objprodchangevalue._Basepremiumamount = Request.Form[txtBasepremium.UniqueID];
                objProductSectionBase.MonthlyPayout = strProdMonthlyPayout = objprodchangevalue._MonthlyPayoutBase = Request.Form[txtMonthlyPayoutBase.UniqueID];

                objProductSectionBase.TotalPremium = objprodchangevalue._TotalPremiumamount = Request.Form[txtTotalpremium.UniqueID]; ;
                objProductSectionBase.MonthlyPayout = (string.IsNullOrEmpty(objProductSectionBase.MonthlyPayout)) ? string.Empty : objProductSectionBase.MonthlyPayout;
                objProductSectionBase.ProductType = hdnProductType.Value;
                objProductSectionBase.ProdcutName = Request.Form[txtProname.UniqueID];
                objProductSectionBase.PolicyNo = Request.Form[txtBasepolno.UniqueID];
                objProductSectionBase.Section = "ProductDetails";

                //added by suraj for new product code T36/37 & E91/92
                objProductSectionBase.Category = objprodchangevalue._Category = ddlCategory.SelectedValue;
                objProductSectionBase.PayoutTerm = objprodchangevalue._PayoutTerm = ddlPayoutTerm.SelectedValue;
                objProductSectionBase.PayoutType = objprodchangevalue._PayoutType = ddlPayoutType.SelectedValue;
                objProductSectionBase.PayoutFreq = objprodchangevalue._PayOutFrquency = ddlpayoutfreq.SelectedValue;
                objProductSectionBase.LumpsumPer = objprodchangevalue._LumpSumPercent = txtLumpSumPercent.Text;
                objProductSectionBase.ProductCategory = objprodchangevalue._ProductCategory = ddlprodcategory.SelectedValue;
                //end

                lstprodctlistsec.Add(objProductSectionBase);
                //end
                ReplicaXml objReplicaXml = new ReplicaXml();
                DataSet _ds = new DataSet();
                int intResponse = -1;
                bool isdataSave = true;
                string strResponse = string.Empty;
                objcomm = new Commfun();
                int intTrackingRet = -1;
                /*added by shri on 28 dec 17 to add tracking*/
                objCommonObj = (CommonObject)Session["objCommonObj"];
                strUserId = objCommonObj._Bpmuserdetails._UserID;
                InsertUwDecisionTracking(strApplicationno, strUserId, DateTime.Now, "PRODUCT_PREM", ref intTrackingRet);
                /*end here*/
                PremiumCalculation(objReplicaXml, ref isdataSave, ref _ds, ref intResponse, ref strResponse, objProductSectionBase, rptprodctlistcount);
                if (_ds != null && _ds.Tables.Count > 0 && _ds.Tables[0].Rows.Count > 0)
                {
                    //_ds.Tables[0].Columns.RemoveAt(2);
                    //_ds.Tables[0].Columns.RemoveAt(2);
                    gridPremCal_Product.DataSource = _ds;
                    gridPremCal_Product.DataBind();
                    chkProductDtls.Checked = false;

                    lblErrorproddtls.Text = "";

                    //added by suraj for combi
                    if (_ds.Tables[0].Rows[0]["ExtraPremiumAmt"].ToString() != "0")
                    {
                        if (copy == 0)
                        {
                            dtcopy = _ds.Tables[0].Copy();
                            copy++;
                        }
                        else
                        {
                            dtcopy.Merge(_ds.Tables[0]);

                            gridPremCal_Loading.DataSource = dtcopy;
                            gridPremCal_Loading.DataBind();
                            copy = 0;
                            dtcopy.Dispose();
                        }




                    }
                    //end
                }
                else
                {
                    //FillProductDetails(strApplicationno, strChannelType);
                    chkProductDtls.Checked = false;
                    lblErrorproddtls.Text = "Premium Calculation Failed to know more click here";
                    lblErrorProductDetailBody.Text = strLApushStatus;
                }

                updProductDetails.Update();
                updLoadingDetails.Update();
                /*added by shri on 28 dec 17 to update tracking*/
                UpdateUwDecisionTracking(intTrackingRet, DateTime.Now, ref intTrackingRet);
                /*END HERE*/
            }

        }
        catch (Exception ex)
        {

        }
        finally
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "disp_confirm", "<script>hideloading()</script>", false);
        }
    }
    protected void btnLoadingDtlsSave_Click(object sender, EventArgs e)
    {
        lblTotalLoadingPremium.Text = lblLoadingPremium.Text = string.Empty;
        chkLoadingDtls.Checked = false;
        DataTable _dtLoaddata = new DataTable();
        lblErrorloadingdtls.Text = string.Empty;
        int LoadingResult = 0;
        //objCommonObj = (CommonObject)Session["objCommonObj"];
        objChangeObj = (ChangeValue)Session["objLoginObj"];
        // objChangeObj = (ChangeValue)ViewState["LoadingData"];
        Logger.Info(strApplicationno + "STAG 15 :PageName :Uwdecision.aspx.CS // MethodeName :btnLoadingDtlsSave_Click" + System.Environment.NewLine);
        string _strLoadRiderName = string.Empty;
        string _strLoadType = string.Empty;
        string _strLoadDiscp = string.Empty;
        //string _strLoadReason1 = string.Empty;
        //string _strLoadReason1Discp = string.Empty;
        //string _strLoadReason2 = string.Empty;
        //string _strLoadReason2Discp = string.Empty;
        string _strLoadReason1 = string.Empty;
        string _strLoadReason2 = string.Empty;
        string _strLoadReason3 = string.Empty;
        string _strLoadReason4 = string.Empty;
        string _strLoadPercent = string.Empty;
        string _strRateAdjust = string.Empty;
        string _strFlatmortality = string.Empty;
        string _strLetterPrint = string.Empty;
        string _strRiderCode = string.Empty;
        string _strLoadCode = string.Empty;
        string _strReason1code = string.Empty;
        string _strReason2code = string.Empty;
        int strTotalLoadedPremiumAB = 0;
        int LoadedPremiumA = 0;
        int TotalPremiumA = 0;
        int LoadedPremiumB = 0;
        int TotalPremiumB = 0;
        int TotalPremiumAB = 0;
        int LoadedPremiumAB = 0;
        _dtLoaddata = (DataTable)ViewState["LoadingData"];
        int i = 0;
        if (_dsLoadingDtls != null && _dsLoadingDtls.Tables.Count > 0 && _dsLoadingDtls.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < _dtLoaddata.Rows.Count; i++)
            {
                _strLoadRiderName = _dtLoaddata.Rows[i]["RiderName"].ToString();
                _strLoadType = _dtLoaddata.Rows[i]["ddlLoadType"].ToString();
                _strLoadDiscp = _dtLoaddata.Rows[i]["LoadingDiscp"].ToString();
                //51.1 Begin of Changes; Bhaumik Patel - [CR-3334]
          
                _strLoadReason1 = _dtLoaddata.Rows[i]["Loadrsn1"].ToString();
                _strLoadReason2 = _dtLoaddata.Rows[i]["Loadrsn2"].ToString();
                _strLoadReason3 = _dtLoaddata.Rows[i]["Loadrsn3"].ToString();
                _strLoadReason4 = _dtLoaddata.Rows[i]["Loadrsn4"].ToString();
               
                //51.1 End of Changes; Bhaumik Patel - [CR-3334]
                _strLoadPercent = _dtLoaddata.Rows[i]["txtLoadPer"].ToString();
                _strRateAdjust = _dtLoaddata.Rows[i]["txtRateAdjust"].ToString();
                _strFlatmortality = (_dtLoaddata.Rows[i]["ddlLoadFlatMortality"].ToString() == "0") ? "" : _dtLoaddata.Rows[i]["ddlLoadFlatMortality"].ToString();
                _strLetterPrint = _dtLoaddata.Rows[i]["LetterPrint"].ToString();
                _strRiderCode = _dtLoaddata.Rows[i]["RiderCode"].ToString();
                _strLoadCode = _dtLoaddata.Rows[i]["ddlLoadCode"].ToString();
                _strReason1code = _dtLoaddata.Rows[i]["ddlLoadRsn1Code"].ToString();
                _strReason2code = _dtLoaddata.Rows[i]["ddlLoadRsn2Code"].ToString();
                //51.1 Begin of Changes; Bhaumik Patel - [CR-3334]
                objComm.OnlineLoadingDetails_Save(objCommonObj._AppType, strApplicationno, _strLoadCode, _strLoadDiscp, _strLoadReason1, _strLoadReason2, _strLoadReason3, "", txtLoadPer.Text, _strRateAdjust, _strFlatmortality, "", _strLetterPrint, _strLoadRiderName, objChangeObj.userLoginDetails._UserID, objChangeObj.userLoginDetails._UserName, objChangeObj.userLoginDetails._UserGroup, objChangeObj.userLoginDetails._userBranch, objChangeObj.userLoginDetails._userBranch, objChangeObj.userLoginDetails._ProcessName, strApplicationno, _strLoadReason4, ref LoadingResult);
                //51.1 End of Changes; Bhaumik Patel - [CR-3334]
            }
            if (LoadingResult != -1)
            {
                chkLoadingDtls.Checked = false;
                //Session["LoadingData"] = null;
                ViewState["LoadingData"] = null;
                gvLoadingDtls.DataSource = null;
                gvLoadingDtls.DataBind();
                ddlLoadType.SelectedValue = "0";
                ddlLoadRsn1.SelectedValue = "0";
                //ddlLoadRsn2.SelectedValue = "0";
                ddlLoadFlatMortality.SelectedValue = "0";
                ddlLoadletterPrint.SelectedValue = "0";
                txtLoadDesc.Text = "";
                //51.1 Begin of Changes; Bhaumik Patel - [CR-3334]
                txtRsn1Desc.Text = "";
                txtRsn2Desc.Text = "";
                txtRsn3Desc.Text = "";
                txtRsn4Desc.Text = "";
                //51.1 End of Changes; Bhaumik Patel - [CR-3334]
                txtLoadPer.Text = "";
                txtRateAdjust.Text = "";

                FillLoadingDetails(strApplicationno, strChannelType);
                lblErrorloadingdtls.Text = "Loading details save successfully";
                LoadDtls objLoad = new LoadDtls();
                objLoad._strProdcode = ddlLoadRiderCode.SelectedValue;
                objChangeObj.Load_Loadingdetails = objLoad;
                //objUWDecision.OnlineApplicationLAServiceDetails_PUSH(strApplicationno, strChannelType, objChangeObj, ref _ds, "RATEUP", ref strLApushErrorCode, ref strLApushStatus);

                objUWDecision.OnlineApplicationLAServiceDetails_PUSH(strApplicationno, strChannelType, objChangeObj, ref _ds, ref _dsPrevPol, "CONTRACTMODIFICATION", ref strLApushErrorCode, ref strLApushStatus, ref strConsentRespons);
                if (strLApushErrorCode == 0)
                {
                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        TotalPremiumAB = Convert.ToInt32(_ds.Tables[0].Rows[0]["TotalPremiumAB"].ToString().Replace(".00", ""));
                        LoadedPremiumAB = Convert.ToInt32(_ds.Tables[0].Rows[0]["LoadedPremiumAB"].ToString().Replace(".00", ""));
                        TotalPremiumA = Convert.ToInt32(_ds.Tables[0].Rows[0]["TotalPremiumA"].ToString().Replace(".00", ""));
                        LoadedPremiumA = Convert.ToInt32(_ds.Tables[0].Rows[0]["LoadedPremiumA"].ToString().Replace(".00", ""));
                        TotalPremiumB = Convert.ToInt32(_ds.Tables[0].Rows[0]["TotalPremiumB"].ToString().Replace(".00", ""));
                        LoadedPremiumB = Convert.ToInt32(_ds.Tables[0].Rows[0]["LoadedPremiumB"].ToString().Replace(".00", ""));

                        strLApushStatus = "";
                        //objUWDecision.OnlineApplicationLAServiceDetails_PUSH(strApplicationno, strChannelType, objChangeObj, ref _ds, "PREMIUMCAL", ref strLApushErrorCode, ref strLApushStatus);
                        //if (strLApushErrorCode == 0 && _ds.Tables.Count > 0)
                        //{
                        //    lblErrorloadingdtls.Text = "Premium calculation succeed";
                        clsName = divPremiumDetailsLoading.Attributes["class"].ToString();
                        divPremiumDetailsLoading.Attributes.Add("class", clsName.Replace(clsName, "col-md-12"));
                        //    gridPremiumDetailsLoading.DataSource = _ds;
                        //    gridPremiumDetailsLoading.DataBind();
                        //}
                        lblLoadingPremium.Text = "Loading premium is : " + LoadedPremiumAB;
                        lblTotalLoadingPremium.Text = "Total premium is : " + TotalPremiumAB;
                        if (strChannelType.ToUpper() == "ONLINE")
                        {
                            objComm.OnlinepremiumLoadingDetails_Save(strApplicationno, LoadedPremiumAB, _strLoadDiscp, _strLoadCode, _strReason1code, "", _strLoadDiscp, LoadedPremiumA, LoadedPremiumB, TotalPremiumA, TotalPremiumB, "", ref strLApushErrorCode);
                        }
                        else if (strChannelType.ToUpper() == "OFFLINE")
                        {
                            //objComm.OnlinePremiumExtraLoadingdetails_Save(0, strApplicationno, txtPolno.Text, ddlLoadRiderCode.SelectedItem.Text, "", "", ddlLoadRiderCode.SelectedValue, 0, Convert.ToDecimal(TotalPremiumAB), ddlLoadRsn2.SelectedItem.Text, 0, Convert.ToDecimal(LoadedPremiumA), Convert.ToDecimal(TotalPremiumAB * 4.5), 0, Convert.ToDecimal(LoadedPremiumA), 0, 0, 0, 0, 0, 0, 0, ref strLApushErrorCode);

                        }
                    }
                    /*added by shri on 22 july 17 to dont update text box*/
                    //txtTotalpremium.Text = TotalPremium.ToString();
                    //txtBasepremium.Text = LoadedPremium.ToString();
                    /*end here*/
                    btnAddLoadingRow.CssClass = "btn btn-primary HideControl";
                    //btnLoadingDtlsSave.CssClass = "btn-primary HideControl";
                    lblErrorloadingdtls.Text = "Loading Details Updated in Life Asia successfully";
                    FillLoadingDetails(strApplicationno, strChannelType);
                }
                else
                {
                    btnAddLoadingRow.CssClass = "btn btn-primary HideControl";
                    //btnAddLoadingRow.CssClass = "form-control";
                    lblErrorloadingdtls.Text = "Loading Details Not Updated in Life Asia,Please Contact system admin";
                }
            }
            else
            {
                lblErrorloadingdtls.Text = "Loading Details Not save successfully";
                btnAddLoadingRow.CssClass = "btn btn-primary";
                //btnLoadingDtlsSave.CssClass = "btn-primary";
            }
        }

    }

    protected void gvLoadingDtls_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Logger.Info("STAG 16 :PageName :Uwdecision.aspx.CS // MethodeName :gvLoadingDtls_RowDataBound" + System.Environment.NewLine);
    }

    protected void gvExtLoadDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataTable _ds = new DataTable();
        Logger.Info("STAG 17 :PageName :Uwdecision.aspx.CS // MethodeName :gvExtLoadDetails_RowDataBound" + System.Environment.NewLine);
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //51.1 Begin of Changes; Bhaumik Patel - [CR - 3334]
            //DropDownList ddlLoadType = (DropDownList)e.Row.FindControl("ddlExstingLoadType");
            //BindMasterDetails(ddlLoadType);


            //DropDownList ddlLoadRsn1 = (DropDownList)e.Row.FindControl("ddlExistingLoadRsn1");
            //BindMasterDetails(ddlLoadRsn1);
            // DropDownList ddlLoadRsn2 = (DropDownList)e.Row.FindControl("ddlExistingLoadRsn2");
            // BindMasterDetails(ddlLoadRsn2);
            //DropDownList ddlLoadFlatMortality = (DropDownList)e.Row.FindControl("ddlExistingLoadFlatMort");
            //BindMasterDetails(ddlLoadFlatMortality);
            //51.1 End of Changes; Bhaumik Patel - [CR - 3334]




            //FillDropDownList(ddl1, "followupcode", "Mst");
            _ds = (DataTable)ViewState["ExitingLoadingData"];
            if (_ds.Rows.Count > 0)
            {
                //DropDownList ddlfollowupcode = (DropDownList)e.Row.FindControl("ddlfollowupcode");
                //ddlLoadType.SelectedValue = _ds.Rows[e.Row.RowIndex]["LaodingCode"].ToString();

               
                //51.1 Begin of Changes; Bhaumik Patel - [CR - 3334]
                Label ddlExstingLoadType = (Label)e.Row.FindControl("ddlExstingLoadType");
                ddlExstingLoadType.Text = _ds.Rows[e.Row.RowIndex]["LoadingType"].ToString();

                Label ddlExstingLoadTypeCode = (Label)e.Row.FindControl("ddlExstingLoadTypeCode");
                ddlExstingLoadTypeCode.Text = _ds.Rows[e.Row.RowIndex]["LaodingCode"].ToString();

                Label Appno = (Label)e.Row.FindControl("lblAPPno");
                Appno.Text = _ds.Rows[e.Row.RowIndex]["LD_applicationNoStr"].ToString();
                Label Rider = (Label)e.Row.FindControl("lblRiderName");
                Rider.Text = _ds.Rows[e.Row.RowIndex]["RiderName"].ToString();
                Label Reason1 = (Label)e.Row.FindControl("lblExistingLoadRsn1");
                Reason1.Text = _ds.Rows[e.Row.RowIndex]["LD_reason1Desc"].ToString();

                Label Reason1Code = (Label)e.Row.FindControl("lblExistingLoadRsn1Code");
                Reason1Code.Text = _ds.Rows[e.Row.RowIndex]["LD_reason1"].ToString();

                Label Reason2Code = (Label)e.Row.FindControl("lblExistingLoadRsn2Code");
                Reason2Code.Text = _ds.Rows[e.Row.RowIndex]["LD_reason2"].ToString();

                Label Reason2 = (Label)e.Row.FindControl("lblExistingLoadRsn2");
                Reason2.Text = _ds.Rows[e.Row.RowIndex]["LD_reason2Desc"].ToString();

                Label Reason3 = (Label)e.Row.FindControl("lblExistingLoadRsn3");
                Reason3.Text = _ds.Rows[e.Row.RowIndex]["LD_reason3Desc"].ToString();
                Label Reason4 = (Label)e.Row.FindControl("lblExistingLoadRsn4");
                Reason4.Text = _ds.Rows[e.Row.RowIndex]["LD_reason4Desc"].ToString();
                Label ddlLoadFlatMortality = (Label)e.Row.FindControl("ddlExistingLoadFlatMort");
                ddlLoadFlatMortality.Text = _ds.Rows[e.Row.RowIndex]["FlatMortalitydisc"].ToString();
                Label ddlLoadFlatMortalityCode = (Label)e.Row.FindControl("ddlExistingLoadFlatMortCode");
                ddlLoadFlatMortalityCode.Text = _ds.Rows[e.Row.RowIndex]["FlatMortality"].ToString();
                //ddlLoadRsn1.SelectedValue = _ds.Rows[e.Row.RowIndex]["LoadReasoncode1"].ToString();
                //DropDownList ddlCriteria = (DropDownList)e.Row.FindControl("ddlCriteria");
                //ddlLoadRsn2.SelectedValue = _ds.Rows[e.Row.RowIndex]["LoadReasoncode2"].ToString();
                //ddlLoadFlatMortality.SelectedValue = _ds.Rows[e.Row.RowIndex]["FlatMortality"].ToString();
                //51.1 End of Changes; Bhaumik Patel - [CR - 3334]


                Label Loadingper = (Label)e.Row.FindControl("lblExistingLoadPer");
                Loadingper.Text = _ds.Rows[e.Row.RowIndex]["Loading"].ToString();

                Label RateAdjust = (Label)e.Row.FindControl("lblExistingRateAdjust");
                RateAdjust.Text = _ds.Rows[e.Row.RowIndex]["RateAdjustment"].ToString();

            }

        }
    }

    protected void lnkBankDtlsRefresh_Click(object sender, EventArgs e)
    {

        chkBankDtls.Checked = false;
        //objCommonObj = (CommonObject)Session["objCommonObj"];
        FillBankDetails(strApplicationno, strChannelType);
    }

    protected void lnkAgentDtlsRefresh_Click(object sender, EventArgs e)
    {
        chkAgentDtls.Checked = false;
        // objCommonObj = (CommonObject)Session["objCommonObj"];
        FillAgentDetails(strApplicationno, strChannelType);
    }

    protected void lnkApplicationDtlsRefresh_Click(object sender, EventArgs e)
    {
        chkAppDtls.Checked = false;
        // objCommonObj = (CommonObject)Session["objCommonObj"];
        FillApplicationDetails(strApplicationno, strChannelType);
    }

    protected void lnkPreIssueDtlsRefresh_Click(object sender, EventArgs e)
    {
        try
        {
            /*added by shri on 28 dec 17 to add tracking*/
            int intTrackingRet = -1;
            objCommonObj = (CommonObject)Session["objCommonObj"];
            strUserId = objCommonObj._Bpmuserdetails._UserID;
            InsertUwDecisionTracking(strApplicationno, strUserId, DateTime.Now, "PRE_ISSUE", ref intTrackingRet);
            /*end here*/
            UWPreIssueServiceCall(strApplicationno, strChannelType);
            /*added by shri on 28 dec 17 to update tracking*/
            UpdateUwDecisionTracking(intTrackingRet, DateTime.Now, ref intTrackingRet);
            /*END HERE*/
        }
        catch (Exception ex)
        {
            Logger.Error(strApplicationno + "STAG 2 :PageName :UwDecisions.CS // MethodeName :lnkPreIssueDtlsRefresh_Click Error :" + System.Environment.NewLine + ex.ToString());
        }
        finally
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "disp_confirm", "<script>hideloading()</script>", false);
        }
    }

    protected void lnkStpDtlsRefresh_Click(object sender, EventArgs e)
    {
        //objCommonObj = (CommonObject)Session["objCommonObj"];
        //UWSTPServiceCall(strApplicationno, strChannelType);
    }

    protected void lnkAwDtlsRefresh_Click(object sender, EventArgs e)
    {
        // objCommonObj = (CommonObject)Session["objCommonObj"];
        objChangeObj = (ChangeValue)Session["objLoginObj"];
        //DashbordUWResultDynamic_Get(strApplicationno, objChangeObj.userLoginDetails._UserID, objChangeObj.userLoginDetails._UserGroup, strUWmode);
    }

    protected void lnkPanDtlsRefresh_Click(object sender, EventArgs e)
    {
        chkPanDtls.Checked = false;
        //objCommonObj = (CommonObject)Session["objCommonObj"];
        FillPanDetails(strApplicationno, strChannelType);
    }

    protected void lnkSarDtlsRefresh_Click(object sender, EventArgs e)
    {
        // objCommonObj = (CommonObject)Session["objCommonObj"];
        FillTsmrMsarDetails(strApplicationno, strChannelType);
    }

    protected void lnkProductDtlsRefresh_Click(object sender, EventArgs e)
    {
        chkProductDtls.Checked = false;
        // objCommonObj = (CommonObject)Session["objCommonObj"];
        FillProductDetails(strApplicationno, strChannelType);
        FillRiderDetails(strApplicationno);
    }

    protected void lnkFundDelsRefresh_Click(object sender, EventArgs e)
    {
        //chkFunddtlsSave.Checked = false;
        // objCommonObj = (CommonObject)Session["objCommonObj"];
        //FillfundsDetails(strApplicationno, strChannelType);
    }

    protected void lnkPaymentDtlsRefresh_Click(object sender, EventArgs e)
    {
        // objCommonObj = (CommonObject)Session["objCommonObj"];        
        //FillPaymentsDetails(strApplicationno, strChannelType);
        FillReceiptDetails(strApplicationno, strChannelType);
    }

    protected void lnkReqDtlsRefresh_Click(object sender, EventArgs e)
    {
        chkReqDtls.Checked = false;
        //objCommonObj = (CommonObject)Session["objCommonObj"];
        FillRequirmentDetails(strApplicationno, strChannelType);
    }

    protected void lnkLoadingDtlsRefresh_Click(object sender, EventArgs e)
    {
        chkLoadingDtls.Checked = false;
        // objCommonObj = (CommonObject)Session["objCommonObj"];
        FillLoadingDetails(strApplicationno, strChannelType);
    }

    //protected void lnkUwCmntDtlsRefresh_Click(object sender, EventArgs e)
    //{
    //    chkCommentDtls.Checked = false;
    //    objCommonObj = (CommonObject)Session["objCommonObj"];
    //    FillCommentsDetails(strApplicationno, strChannelType, "General");
    //}

    protected void lnkDecisionDtlsRefresh_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (RepeaterItem item in rptDecision.Items)
            {
                //51.1 Begin of Changes; Bhaumik Patel - [CR - 3334]
                DropDownList ddlUWDecesion = (DropDownList)item.FindControl("ddlUWDecesion");
                ListBox ddlUWreason1 = (ListBox)item.FindControl("ddlUWreason1");
                ddlUWDecesion.SelectedIndex = 0;
               
                //ddlUWreason1.SelectedIndex = 0;
                //51.1 Begin of Changes; Bhaumik Patel - [CR - 3334]
                ddlUWDecesion.Enabled = true;
            }

        }
        catch (Exception ex)
        {
            
        }
        finally
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "disp_confirm", "<script>hideloading()</script>", false);
        }
    }

    protected void lnkLoadRemoveRow_Click(object sender, EventArgs e)
    {
        try
        {
            Logger.Info("STAG 2 :PageName :Uwdecision.aspx.CS // MethodeName :lnkLoadRemoveRow_Click" + System.Environment.NewLine);
            LinkButton lb = (LinkButton)sender;
            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;

            int rowID = gvRow.RowIndex + 1;
            if (ViewState["LoadingData"] != null)
            {
                int intResponse = 0;
                DataTable dt = (DataTable)ViewState["LoadingData"];
                if (dt.Rows.Count >= 1)
                {
                    DataRow dr = dt.Rows[rowID - 1];
                    DeleteExistingLoading(strApplicationno, Convert.ToString(dr["RiderName"]), Convert.ToString(dr["ddlLoadType"]), ref intResponse);
                    if (gvRow.RowIndex <= dt.Rows.Count - 1)
                    {
                        dt.Rows.Remove(dt.Rows[rowID - 1]);
                    }
                }
                if (dt.Rows.Count == 0)
                {
                    objChangeObj = (ChangeValue)Session["objLoginObj"];
                    objChangeObj.Load_Loadingdetails.isConsentRequired = false;
                    Session["objLoginObj"] = objChangeObj;
               //51.1 Begin of Changes; Bhaumik Patel - [CR - 3334]
                    //Store the current data in ViewState for future reference
                    ViewState["LoadingData"] = dt;
                    //Re bind the GridView for the updated data
                    gvLoadingDtls.DataSource = dt;
                    gvLoadingDtls.DataBind();

                    txtRsn1Desc.Text = "";
                    txtRsn2Desc.Text = "";
                    txtRsn3Desc.Text = "";
                    txtRsn4Desc.Text = "";
                    ddlLoadRsn1.Items.Clear();
                    updLoadingDetails.Update();
                }
                else
                {
                    //Store the current data in ViewState for future reference
                    ViewState["LoadingData"] = dt;
                    //Re bind the GridView for the updated data
                    gvLoadingDtls.DataSource = dt;
                    gvLoadingDtls.DataBind();

                    txtRsn1Desc.Text = "";
                    txtRsn2Desc.Text = "";
                    txtRsn3Desc.Text = "";
                    txtRsn4Desc.Text = "";
                    ddlLoadRsn1.Items.Clear();
                    BindLoadingDetails(dt);
                    updLoadingDetails.Update();
                    
                }
                //51.1 End of Changes; Bhaumik Patel - [CR - 3334]
            }
        }
        catch (Exception ex)
        {

        }
        finally
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "disp_confirm", "<script>hideloading()</script>", false);
        }
    }

    protected void lnkReqRemoveRow_Click(object sender, EventArgs e)
    {
        Logger.Info("STAG 2 :PageName :Uwdecision.aspx.CS // MethodeName :lnkReqRemoveRow_Click" + System.Environment.NewLine);
        LinkButton lb = (LinkButton)sender;
        GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
        int rowID = gvRow.RowIndex + 1;
        if (ViewState["CurrentTable1"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable1"];
            if (dt.Rows.Count >= 1)
            {

                if (gvRow.RowIndex <= dt.Rows.Count - 1)
                {
                    dt.Rows.Remove(dt.Rows[rowID - 1]);
                }
            }
            //Store the current data in ViewState for future reference
            ViewState["CurrentTable1"] = dt;
            //Re bind the GridView for the updated data
            gvRequirmentDetails.DataSource = dt;
            gvRequirmentDetails.DataBind();
            chkReqDtls.Checked = false;
        }

        //Set Previous Data on Postbacks
        SetPreviousData1();


    }

    protected void lnkExistingLoadRemoveRow_Click(object sender, EventArgs e)
    {
        try
        {
            /*added by shri on 28 dec 17 to add tracking*/
            int intTrackingRet = -1;
            objCommonObj = (CommonObject)Session["objCommonObj"];
            strUserId = objCommonObj._Bpmuserdetails._UserID;
            InsertUwDecisionTracking(strApplicationno, strUserId, DateTime.Now, "LOAD_REMOVE", ref intTrackingRet);
            /*end here*/
            string response = "";
            Logger.Info("STAG 2 :PageName :Uwdecision.aspx.CS // MethodeName :lnkExistingLoadRemoveRow_Click" + System.Environment.NewLine);
            LinkButton lb = (LinkButton)sender;
            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
            int rowID = gvRow.RowIndex + 1;
            if (ViewState["ExitingLoadingData"] != null)
            {
                DataTable dt = (DataTable)ViewState["ExitingLoadingData"];
                if (dt.Rows.Count >= 1)
                {
                    if (gvRow.RowIndex <= dt.Rows.Count - 1)
                    {
                        objCommonObj = (CommonObject)Session["objCommonObj"];
                        DeleteSpecificLoading(dt.Rows[rowID - 1], objCommonObj._ApplicationNo, objCommonObj._ChannelType, ref response);
                        //if (response != -1)
                        //{
                        dt.Rows.Remove(dt.Rows[rowID - 1]);
                        //}
                    }
                }
                if (dt.Rows.Count == 0)
                {
                    clsName = divExistingloading.Attributes["class"].ToString();
                    divExistingloading.Attributes.Add("class", clsName.Replace(clsName, "col-md-12 HideControl"));
                }
                ViewState["ExitingLoadingData"] = dt;
                gvExtLoadDetails.DataSource = dt;
                gvExtLoadDetails.DataBind();
                BindLoadingDetails(dt);
            }
            /*added by shri on 28 dec 17 to update tracking*/
            UpdateUwDecisionTracking(intTrackingRet, DateTime.Now, ref intTrackingRet);
            /*END HERE*/
        }
        catch (Exception ex)
        {


        }
        finally
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "disp_confirm", "<script>hideloading()</script>", false);
        }
    }

    public void DeleteSpecificLoading(DataRow dr, string strApplicationno, string ChannelType, ref string response)
    {
        int result = -1;
        DataSet _ds = new DataSet();
        Logger.Info("STAG 2 :PageName :Uwdecision.aspx.CS // MethodeName :DeleteSpecificLoading" + System.Environment.NewLine);
        objcomm.DeleteExistingLoading(dr, ref result);
        if (result != -1)
        {
            lblErrorExistingLoading.Text = "Loading deleted successfully";
            objChangeObj = (ChangeValue)Session["objLoginObj"];
            LoadDtls objLoad = new LoadDtls();
            objLoad._strProdcode = dr["RiderName"].ToString();
            objChangeObj.Load_Loadingdetails = objLoad;
            objUWDecision.OnlineApplicationLAServiceDetails_PUSH(strApplicationno, ChannelType, objChangeObj, ref _ds, ref _dsPrevPol, "CONTRACTMODIFICATION", ref strLApushErrorCode, ref strLApushStatus, ref strConsentRespons);
            if (strLApushErrorCode == 0)
            {
                //if (_ds.Tables[0].Rows.Count > 0)
                //{

                //}
            }
        }
        else
        {
            lblErrorExistingLoading.Text = "Loading details not updated in Life Asia";
        }
    }

    /*added by shri on 21 june 17 to fetch basic client details*/
    private void FetchClientBasicDetails(ref DataSet _ds, string strApplnNo)
    {
        BussLayer objBussLayer = new BussLayer();
        objBussLayer.ClientBasicInfo_GET(ref _ds, strApplnNo);
    }

    protected void btnRefreshClientProfile_Click(object sender, EventArgs e)
    {
        try
        {
            FetchClientBasicDetails(ref _ds, strApplicationno);
            if (_ds != null && _ds.Tables.Count > 0 && _ds.Tables[0].Rows.Count > 0)
            {
                gvClientDetails.DataSource = _ds;
                gvClientDetails.DataBind();
                _ds.Clear();
            }
        }
        catch (Exception ex)
        {

        }
        finally
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "disp_confirm", "<script>hideloading()</script>", false);
        }
    }

    /*added by shri on 19 july 17 to manage rider info*/
    protected void btnSaveRiderInfo_Click(object sender, EventArgs e)
    {
        lblRiderDetailsError.Text = lblErrorRiderDetailsBody.Text = string.Empty;
        try
        {
            objCommonObj = (CommonObject)Session["objCommonObj"];
            DataTable dtRiderInfo = new DataTable();
            DefineDataTable(ref dtRiderInfo);
            bool blnIsGreateThanSumAssured = true;
            foreach (GridViewRow rowfollowup in gvRiderDtls.Rows)
            {
                //define variable
                DataRow dr = dtRiderInfo.NewRow();
                CheckBox cbIsRider = (CheckBox)rowfollowup.FindControl("chkremoveRider");
                Label lblRiderName = (Label)rowfollowup.FindControl("lblRiderName");
                Label lblRiderCode = (Label)rowfollowup.FindControl("lblRiderCode");
                TextBox txtRiderSumAssured = (TextBox)rowfollowup.FindControl("txtRiderSumAssure");
                TextBox txtRiderTotalPremium = (TextBox)rowfollowup.FindControl("txtRiderPremium");
                TextBox txtServiceTax = (TextBox)rowfollowup.FindControl("txtriderservicetax");
                string[] strRiderSumAssured = txtRiderSumAssured.Text.Split(',');
                string[] strRiderTotalPremium = txtRiderTotalPremium.Text.Split(',');
                string[] strServiceTax = txtServiceTax.Text.Split(',');
                if (strRiderSumAssured.Length > 0)
                {
                    txtRiderSumAssured.Text = strRiderSumAssured[strRiderSumAssured.Length - 1];
                }
                if (strRiderTotalPremium.Length > 0)
                {
                    txtRiderTotalPremium.Text = strRiderTotalPremium[strRiderTotalPremium.Length - 1];
                }
                if (strServiceTax.Length > 0)
                {
                    txtServiceTax.Text = strServiceTax[strServiceTax.Length - 1];
                }
                if (cbIsRider.Checked && string.IsNullOrEmpty(txtRiderSumAssured.Text))
                {
                    lblRiderDetailsError.Text = "Enter sum assured for all the checked riders";
                    return;
                }
                else if (cbIsRider.Checked && !string.IsNullOrEmpty(txtRiderSumAssured.Text) && Convert.ToDouble(txtRiderSumAssured.Text) < 1)
                {
                    lblRiderDetailsError.Text = "Enter sum assured for all the checked riders";
                    return;
                }
                //get value from it
                dr[0] = strApplicationno;
                dr[1] = cbIsRider.Checked;
                dr[2] = lblRiderName.Text;
                dr[3] = lblRiderCode.Text;
                dr[4] = (string.IsNullOrEmpty(txtRiderSumAssured.Text)) ? "0.00" : txtRiderSumAssured.Text;
                dr[5] = (string.IsNullOrEmpty(txtRiderTotalPremium.Text)) ? "0.00" : txtRiderTotalPremium.Text;
                dr[6] = (string.IsNullOrEmpty(txtServiceTax.Text)) ? "0.00" : txtServiceTax.Text;
                dr[7] = string.Empty;
                dr[8] = "";//txtProdcode.Text;
                dr[9] = "";//txtPolterm.Text;
                dr[10] = "";//txtPrepayterm.Text;
                dr[11] = "";//txtSumassure.Text;
                //add data row to datatable
                dtRiderInfo.Rows.Add(dr);
                if (!string.IsNullOrEmpty(txtRiderSumAssured.Text))
                {
                    //if (Convert.ToDouble(txtRiderSumAssured.Text) > Convert.ToDouble(txtSumassure.Text))
                    //{
                    //    blnIsGreateThanSumAssured = false;
                    //    break;
                    //}
                }
            }
            if (blnIsGreateThanSumAssured)
            {
                int intResponse = -1;
                //data table is not null then
                if (dtRiderInfo != null && dtRiderInfo.Rows.Count > 0)
                {
                    //save to data base
                    objcomm.ManageRiderInfo(strApplicationno, dtRiderInfo, strUserId, ref intResponse);
                    if (intResponse > 0)
                    {
                        //call premium calculation
                        string strIdentifier = "PREMIUMCAL";
                        objUWDecision.OnlineApplicationLAServiceDetails_PUSH(strApplicationno, objCommonObj._ChannelType, objChangeObj, ref _ds, ref _dsPrevPol, strIdentifier, ref strLApushErrorCode, ref strLApushStatus, ref strConsentRespons);
                        if (strLApushErrorCode == 0)
                        {
                            List<RiderInfo> lstRiderInfo = new List<RiderInfo>();
                            Commfun.FillRiderInfoFromPremiumCalcDataTable(ref lstRiderInfo, _ds.Tables[0]);

                            DataTable dtRider = _ds.Tables[0].Copy();
                            dtRider.Columns.Remove("ProductCode");
                            dtRider.Columns.Remove("MedicalLoadingPremium");
                            dtRider.Columns.Remove("NonMedicalLoadingPremium");
                            dtRider.Columns.Remove("TotalInstalmentPremium");
                            //dtRider.Columns.Remove("TotalPremiumAmount");
                            dtRider.Columns.Remove("SumAssured");
                            /*added by shri on 22 aug 17 to remove back date column from offline */
                            if (dtRider.Columns.Contains("BackDateintrest"))
                            {
                                dtRider.Columns.Remove("BackDateintrest");
                            }
                            /*end here*/
                            //if success
                            //update total premium service tax
                            //double dblServiceTax, dblTotalInstalmentPremium;
                            //dblServiceTax = Convert.ToDouble(_ds.Tables[0].Rows[0]["ServiceTax"]);
                            //dblTotalInstalmentPremium = Convert.ToDouble(_ds.Tables[0].Rows[0]["InstalmentPremiumAmt"]);
                            objcomm.UpdateInstalmentWithWithoutTax(strApplicationno, dtRider, ref intResponse);
                            //if (intResponse > 0)
                            //{
                            //    lblErrorRiderDetailsBody.Text = lblErrorRiderDetailsBody.Text + " Rider updated in db";
                            //}
                            //contract modification
                            strIdentifier = "CONTRACTMODIFICATION";
                            objChangeObj = (ChangeValue)Session["objLoginObj"];
                            objUWDecision.OnlineApplicationLAServiceDetails_PUSH(objCommonObj._ApplicationNo, objCommonObj._ChannelType, objChangeObj, ref _ds, ref _dsPrevPol, strIdentifier
                            , ref strLApushErrorCode, ref strLApushStatus, ref strConsentRespons);
                            lblErrorRiderDetailsBody.Text = lblErrorRiderDetailsBody.Text + " Contract Modification " + strLApushStatus;
                            //rebind grid view
                            DataSet dsRiderInfo = new DataSet();
                            objcomm.FetchRiderGrid_GET(strApplicationno, objCommonObj._ChannelType, ref dsRiderInfo);
                            if (dsRiderInfo != null && dsRiderInfo.Tables.Count > 0 && dsRiderInfo.Tables[0].Rows.Count > 0)
                            {
                                gvRiderDtls.DataSource = dsRiderInfo;
                                gvRiderDtls.DataBind();
                            }
                            /*refill product details*/
                            chkProductDtls.Checked = false;
                            // objCommonObj = (CommonObject)Session["objCommonObj"];
                            FillProductDetails(strApplicationno, strChannelType);
                            FillRiderDetails(strApplicationno);
                            updProductDetails.Update();
                            /*end here*/
                            lblErrorRiderDetailsBody.Text = lblErrorRiderDetailsBody.Text + " Rider Info Updated Successfully";
                            lblRiderDetailsError.Text = "Rider Updated Successfully CLICK here to know more";
                        }
                        else
                        {
                            lblErrorRiderDetailsBody.Text = strLApushStatus;
                            lblRiderDetailsError.Text = "Rider Not Updated Successfully CLICK here to know more";
                        }
                    }
                    else
                    {
                        lblRiderDetailsError.Text = "Rider Updated Successfully CLICK here to know more";
                        lblErrorRiderDetailsBody.Text = "Rider Not Updated In Database";
                    }
                }
            }
            else
            {
                lblRiderDetailsError.Text = "Rider Sum Assured Cannot Be Greater Than Produce Sum Assured";
            }
        }

        catch (Exception ex)
        {
            lblRiderDetailsError.Text = "Rider Updated Successfully CLICK here to know more";
            lblErrorRiderDetailsBody.Text = ex.Message; ;
        }
    }

    private void DefineDataTable(ref DataTable dt)
    {
        dt.Columns.Add("ApplicationNo", typeof(string));
        dt.Columns.Add("IsActive", typeof(bool));
        dt.Columns.Add("RiderName", typeof(string));
        dt.Columns.Add("RiderCode", typeof(string));
        dt.Columns.Add("RiderSumAssured", typeof(string));
        dt.Columns.Add("RiderTotalPremium", typeof(string));
        dt.Columns.Add("ServiceTax", typeof(string));
        dt.Columns.Add("ProductType", typeof(string));
        dt.Columns.Add("ProductCode", typeof(string));
        dt.Columns.Add("ProdPoliyTerm", typeof(string));
        dt.Columns.Add("ProdPremPayingTerm", typeof(string));
        dt.Columns.Add("ProdSumAssured", typeof(string));
    }
    /*end here*/

    /*added by shri on 15 july 17 to recalculate premium details*/
    protected void btnClosePopupClientProfile_Click(object sender, EventArgs e)
    {
        FetchClientBasicDetails(ref _ds, strApplicationno);
        if (_ds != null && _ds.Tables.Count > 0 && _ds.Tables[0].Rows.Count > 0)
        {
            gvClientDetails.DataSource = _ds;
            gvClientDetails.DataBind();
            _ds.Clear();
        }
        string strAppType = string.Empty;
        if (Session["objCommonObj"] != null)
        {
            objCommonObj = (CommonObject)Session["objCommonObj"];
            strAppType = objCommonObj._ChannelType;
        }
        objUWDecision.OnlineApplicationLAServiceDetails_PUSH(strApplicationno, strAppType, objChangeObj, ref _ds, ref _dsPrevPol, "CONTRACTMODIFICATION", ref strLApushErrorCode, ref strLApushStatus, ref strConsentRespons);

        FillProductDetails(strApplicationno, strChannelType);
        FillRiderDetails(strApplicationno);
    }
    /*added by shri to fill journal details*/
    private void BindJournalDetails(DataTable dt)
    {
        if (dt != null && dt.Rows.Count > 0)
        {
            txtJournalApplicatonNumber.Text = Convert.ToString(dt.Rows[0]["APPLICATION_NUMBER"]);
            txtJournalDocumentNo.Text = Convert.ToString(dt.Rows[0]["DOCUMENT_NUMBER"]);
            divJournalDetails.Attributes.Add("Class", "col-md-12");
        }
        else
        {
            divJournalDetails.Attributes.Add("Class", "col-md-12 HideControl");
        }
    }

    /*added by shri on 23 oct 17 to manage grid*/
    private void ManageUwDecisionGrid(DataTable dt)
    {
        if (dt != null && dt.Rows.Count > 0)
        {
            if (1 != Convert.ToInt16(dt.Rows[0]["DecisionGrid"]))
            {
                foreach (RepeaterItem item in rptDecision.Items)
                {
                    DropDownList ddlUWDecesion = (DropDownList)item.FindControl("ddlUWDecesion");
                    if (ddlUWDecesion.Items.FindByValue("proposal") != null)
                    {
                        ddlUWDecesion.Items.FindByValue("proposal").Selected = true;
                        ddlUWDecesion.Enabled = false;
                    }
                }
            }
            //pending state
            //if (Convert.ToString(dt.Rows[0]["FE_STATUS"]).Equals("PENDING"))
            //{
            //    ListItem objListItem = ddlUWDecesion.Items.FindByValue("proposal");

            //    ddlUWDecesion.Items.Clear();
            //    ddlUWDecesion.Items.Add(objListItem);
            //}
        }
    }
    /*end here*/
    protected void lnkBtnRefreshRiderInfo_Click(object sender, EventArgs e)
    {
        lblRiderDetailsError.Text = string.Empty;
        //rebind grid view
        DataSet dsRiderInfo = new DataSet();
        objCommonObj = (CommonObject)Session["objCommonObj"];
        objcomm.FetchRiderGrid_GET(strApplicationno, objCommonObj._ChannelType, ref dsRiderInfo);
        if (dsRiderInfo != null && dsRiderInfo.Tables.Count > 0 && dsRiderInfo.Tables[0].Rows.Count > 0)
        {
            gvRiderDtls.DataSource = dsRiderInfo;
            gvRiderDtls.DataBind();
        }
    }

    protected void ddlCommonStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow gvRow in gvRequirmentDetails.Rows)
        {
            DropDownList ddlStatus = gvRow.FindControl("ddlStatus") as DropDownList;
            ddlStatus.SelectedValue = ddlCommonStatus.SelectedValue;
        }
        clsName = gvRequirmentDetails.CssClass.Replace("lblLable", "");
        gvRequirmentDetails.CssClass = clsName;
        ddlCommonStatus.Enabled = true;
        clsName = ddlCommonStatus.CssClass.Replace("lblLable", "");
        ddlCommonStatus.CssClass = clsName;

    }

    protected void btnMandateDtlsSave_Click(object sender, EventArgs e)
    {
        string strSpace = " ";
        try
        {
            MandateDetails objMandateDetails = new MandateDetails();
            objMandateDetails.ApplicationNo = strApplicationno;
            objMandateDetails.AccountType = txtMandAccountType.Text;
            objMandateDetails.AccountNumber = txtMandAccountno.Text;
            objMandateDetails.AutoPay = ddlAutoPaytype.SelectedValue;
            if (Session["objLoginObj"] != null)
            {
                objChangeObj = (ChangeValue)Session["objLoginObj"];
                objMandateDetails.objLoginUserDetails = objChangeObj.userLoginDetails;
            }
            /*ADDED BY SHRI FOR MANDATE SI */

            if (ddlAutoPaytype.SelectedValue.ToUpper() == "SI")
            {
                objMandateDetails.CreditCardNo = txtCreditcardno.Text;
                objMandateDetails.CreditCardType = txtcreditcardType.Text;
                objMandateDetails.ValidUpto = txtValidupto.Text;
                objMandateDetails.MicroCode = string.Empty;
                objMandateDetails.BankName = string.Empty;
                objMandateDetails.BranchName = string.Empty;
                objMandateDetails.MandateDate = (string.IsNullOrEmpty(txtMandateSigndate.Text)) ? Convert.ToDateTime("01-01-0001") : Convert.ToDateTime(txtMandateSigndate.Text);
                objMandateDetails.AccountHolderName = txtHolderName.Text;
            }
            else
            {
                objMandateDetails.MicroCode = txtMandMicrocode.Text;
                objMandateDetails.BankName = txtMandBankName.Text;
                objMandateDetails.BranchName = txtMandBranchName.Text;
                objMandateDetails.MandateDate = (string.IsNullOrEmpty(txtMandateassigndate.Text)) ? Convert.ToDateTime("01-01-0001") : Convert.ToDateTime(txtMandateassigndate.Text);
                objMandateDetails.AccountHolderName = txtMandAccountholder.Text;
            }
            /*END HERE*/

            int intRetVal = -1;
            objcomm.ManageMandate(objMandateDetails, ref intRetVal);
            if (intRetVal > 0)
            {
                objChangeObj = (ChangeValue)Session["objLoginObj"];
                if (Session["objCommonObj"] != null)
                {
                    objCommonObj = (CommonObject)Session["objCommonObj"];
                }
                string strAppType = objCommonObj._ChannelType;
                DataSet _dsMandateResp = new DataSet();
                objUWDecision.OnlineApplicationLAServiceDetails_PUSH(strApplicationno, strAppType, objChangeObj, ref _dsMandateResp, ref _dsPrevPol, "BANKENQ", ref strLApushErrorCode, ref strLApushStatus, ref strConsentRespons);
                lblErrorMandate.Text = strLApushStatus;
                if (strLApushErrorCode == 0)
                {
                    //contract modification                   
                    objUWDecision.OnlineApplicationLAServiceDetails_PUSH(strApplicationno, strAppType, objChangeObj, ref _ds, ref _dsPrevPol, "CONTRACTMODIFICATION", ref strLApushErrorCode, ref strLApushStatus, ref strConsentRespons);
                    if (strLApushErrorCode == 0)
                    {
                        lblErrorMandate.Text = lblErrorMandate.Text + strSpace + "Contract Modified Successfully";
                    }
                }
            }
            HideShowMandate();
        }
        catch (Exception ex)
        {
            HideShowMandate();
            lblErrorMandate.Text = lblErrorMandate.Text + strSpace + "Try again later";
        }
        chkMandate.Checked = false;
    }
    protected void txtMandMicrocode_TextChanged(object sender, EventArgs e)
    {
        FillDetailsFromMicrCode(txtMandMicrocode.Text);
    }

    private void FillMandateDetails(DataTable dt)
    {
        if (dt != null && dt.Rows.Count > 0)
        {
            txtMandAccountType.Text = Convert.ToString(dt.Rows[0]["ACCOUNT_TYPE"]);
            txtMandAccountno.Text = Convert.ToString(dt.Rows[0]["ACCOUNT_NUMBER"]);
            txtHolderName.Text = txtMandAccountholder.Text = Convert.ToString(dt.Rows[0]["ACCOUNT_HOLDER_NAME"]);
            txtMandateSigndate.Text = txtMandateassigndate.Text = Convert.ToString(dt.Rows[0]["MANDATE_DATE"]);
            //txtSiMicrCode.Text = txtMandMicrocode.Text = Convert.ToString(dt.Rows[0]["MICRO_CODE"]);
            //txtSiBankName.Text = txtMandBankName.Text = Convert.ToString(dt.Rows[0]["BANK_NAME"]);
            //txtSiBranchCode.Text = txtMandBranchName.Text = Convert.ToString(dt.Rows[0]["BRANCH_NAME"]);
            txtCreditcardno.Text = Convert.ToString(dt.Rows[0]["CREDIT_CARD_NO"]);
            txtcreditcardType.Text = Convert.ToString(dt.Rows[0]["CREDIT_CARD_TYPE"]);
            txtValidupto.Text = Convert.ToString(dt.Rows[0]["VALID_DATE"]);
            txtMandMicrocode.Text = Convert.ToString(dt.Rows[0]["MICRO_CODE"]);
            txtMandBankName.Text = Convert.ToString(dt.Rows[0]["BANK_NAME"]);
            txtMandBranchName.Text = Convert.ToString(dt.Rows[0]["BRANCH_NAME"]);
            /*Added by Suraj on 30/10/2018 as suggest by amit*/
            //txtIFSC.Text = Convert.ToString(dt.Rows[0]["IFSC"]);
            /*Added by Suraj on 13/08/2020 as suggest by darshak/Giridhar for CPG 2.0*/
            txtIFSC.Text = Convert.ToString(dt.Rows[0]["IFSC"]);
            txtPreferredDate.Text = Convert.ToString(dt.Rows[0]["PREFERRED_DATE"]);
            txtAmount.Text = Convert.ToString(dt.Rows[0]["MANDAMT"]);
            /*End*/
            ddlAutoPaytype.ClearSelection();
            if (ddlAutoPaytype.Items.FindByValue(Convert.ToString(dt.Rows[0]["AUTO_PAY_TYPE"])) != null)
            {
                ddlAutoPaytype.Items.FindByValue(Convert.ToString(dt.Rows[0]["AUTO_PAY_TYPE"])).Selected = true;
            }
            HideShowMandate();

        }
    }
    protected void ddlCommentsearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillCommentsDetails(strApplicationno, strChannelType, ddlCommentsearch.SelectedValue);
    }
    protected void btnSaveJournal_Click(object sender, EventArgs e)
    {
        try
        {
            lblErrorJournalDetailsBody.Text = lblJournalMessage.Text = string.Empty;
            if (Session["objCommonObj"] != null)
            {
                objCommonObj = (CommonObject)Session["objCommonObj"];
            }
            string strAppType = objCommonObj._ChannelType;
            /*added by shri on 28 dec 17 to add tracking*/
            int intTrackingRet = -1;
            strUserId = objCommonObj._Bpmuserdetails._UserID;
            InsertUwDecisionTracking(strApplicationno, strUserId, DateTime.Now, "JOURNAL", ref intTrackingRet);
            /*end here*/
            Journal objJournal = new Journal();
            objJournal.ApplicationNumber = txtJournalApplicatonNumber.Text;
            objJournal.DocumentNumber = txtJournalDocumentNo.Text;
            objJournal.Password = txtJournalPassword.Text;

            if (Session["objLoginObj"] != null)
            {
                objChangeObj = (ChangeValue)Session["objLoginObj"];
            }
            objChangeObj.Journal = objJournal;
            objUWDecision.OnlineApplicationLAServiceDetails_PUSH(strApplicationno, strAppType, objChangeObj, ref _ds, ref _dsPrevPol, "JOURNAL", ref strLApushErrorCode, ref strLApushStatus, ref strConsentRespons);
            if (strLApushErrorCode == 0)
            {
                lblErrorJournalDetailsBody.Text = "Authenticated Successfully : " + strLApushStatus;
                lblJournalMessage.Text = "Authenticated Successfully to know more click here";
                lblJournalMessage.CssClass = "LableSuccess";
            }
            else
            {
                lblErrorJournalDetailsBody.Text = "Authentication Failed : " + strLApushStatus;
                lblJournalMessage.Text = "Authentication Failed";
            }
            chkJournal.Checked = false;
            /*added by shri on 28 dec 17 to update tracking*/
            UpdateUwDecisionTracking(intTrackingRet, DateTime.Now, ref intTrackingRet);
            /*END HERE*/
        }
        catch (Exception ex)
        {

        }
        finally
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "disp_confirm", "<script>hideloading()</script>", false);
        }
    }
    protected void txtSiMicrCode_TextChanged(object sender, EventArgs e)
    {
        //FillDetailsFromMicrCode(txtSiMicrCode.Text);        
    }
    private void FillDetailsFromMicrCode(string strMicrCode)
    {
        DataSet _ds = new DataSet();
        objComm.OnlineBankdetailsfromMicrocode_GET(ref _ds, strMicrCode, strApplicationno);
        if (_ds != null && _ds.Tables[0].Rows.Count > 0)
        {
            //txtSiBankName.Text = txtMandBankName.Text = _ds.Tables[0].Rows[0]["BankName"].ToString();
            //txtSiBranchCode.Text = txtMandBranchName.Text = _ds.Tables[0].Rows[0]["BankBranchName"].ToString();            
            txtMandBankName.Text = _ds.Tables[0].Rows[0]["BankName"].ToString();
            txtMandBranchName.Text = _ds.Tables[0].Rows[0]["BankBranchName"].ToString();
        }
        HideShowMandate();
    }
    private void HideShowMandate()
    {
        /*hide show mandate si and ecs*/
        divMandate.Attributes["class"] = divMandate.Attributes["class"] + " HideControl";
        divMandatesi.Attributes["class"] = divMandatesi.Attributes["class"] + " HideControl";
        divMandateecs.Attributes["class"] = divMandateecs.Attributes["class"] + " HideControl";
        if (ddlAutoPaytype.SelectedValue == "0" || ddlAutoPaytype.SelectedValue == "NO")
        {
            divMandate.Attributes["class"] = divMandate.Attributes["class"] + " HideControl";
        }
        if (ddlAutoPaytype.SelectedValue == "SI")
        {
            divMandatesi.Attributes["class"] = divMandatesi.Attributes["class"].Replace("HideControl", string.Empty);
            divMandate.Attributes["class"] = divMandate.Attributes["class"].Replace("HideControl", string.Empty);
        }
        else if (ddlAutoPaytype.SelectedValue == "ECS")
        {
            divMandateecs.Attributes["class"] = divMandateecs.Attributes["class"].Replace("HideControl", string.Empty);
            divMandate.Attributes["class"] = divMandate.Attributes["class"].Replace("HideControl", string.Empty);
        }
        /*Added by Suraj on 13/08/2020 for CPG 2.0*/
        else if (ddlAutoPaytype.SelectedValue == "ENACH")
        {
            divMandateecs.Attributes["class"] = divMandateecs.Attributes["class"].Replace("HideControl", string.Empty);
            divMandate.Attributes["class"] = divMandate.Attributes["class"].Replace("HideControl", string.Empty);
        }
    }

    protected void lnkRefreshJournal_Click(object sender, EventArgs e)
    {
        chkJournal.Checked = false;
        FillJournalkDetails(strApplicationno, strChannelType);
    }

    public void FillJournalkDetails(string strApplicationno, string ChannelType)
    {
        Logger.Info(strApplicationno + "STAG 3 :PageName :Uwdecision.aspx.CS // MethodeName :FillJournalkDetails" + System.Environment.NewLine);
        objComm.OnlineJournalDetails_GET(ref _dsJournal, strApplicationno, ChannelType);
        BindJournalDetails(_dsJournal.Tables[0]);
    }

    private bool IsPanValid(DataSet _dsService, DataSet _dsDb, ref string strReturn)
    {

        int intCounter = 0;
        if (_dsService != null && _dsService.Tables.Count > 0 && _dsService.Tables[0].Rows.Count > 0 && _dsDb != null && _dsDb.Tables.Count > 0 && _dsDb.Tables[0].Rows.Count > 0)
        {
            if (Convert.ToString(_dsService.Tables[0].Rows[0]["LastName"]).ToLower().Equals(Convert.ToString(_dsDb.Tables[0].Rows[0]["LAST_NAME"]).ToLower()))
            {
                intCounter++;
                strReturn = "Last Name Matched";
            }
            else
            {
                strReturn = "Last Name Not Matched";
            }
            if (Convert.ToString(_dsService.Tables[0].Rows[0]["FirstName"]).ToLower().Equals(Convert.ToString(_dsDb.Tables[0].Rows[0]["FIRST_NAME"]).ToLower()))
            {
                intCounter++;
                strReturn = strReturn + " First Name Matched";
            }
            else
            {
                strReturn = strReturn + " First Name Not Matched";
            }
            if (intCounter == 2)
            {
                return true;
            }
        }
        return false;
    }
    protected void btnCommonEvent_Command(object sender, CommandEventArgs e)
    {
        //if (Session["objLoginObj"] != null)
        //{
        //    objChangeObj = (ChangeValue)Session["objLoginObj"];
        //    int intRetVal = -1;
        //    objcomm.MaintainApplicationLog(strApplicationno, e.CommandName, string.Empty, objChangeObj.userLoginDetails._UserID, ref intRetVal);
        //}
    }
    protected void btnDedupeClient_Click(object sender, EventArgs e)
    {
        int intTrackingRet = -1;
        try
        {
            /*added by shri on 28 dec 17 to add tracking*/
            objCommonObj = (CommonObject)Session["objCommonObj"];
            strUserId = objCommonObj._Bpmuserdetails._UserID;
            InsertUwDecisionTracking(strApplicationno, strUserId, DateTime.Now, "UW_DEDUPE", ref intTrackingRet);
            /*end here*/
            BussLayer objBusinessLayer = new BussLayer();
            DataSet _dsDbLA = new DataSet();
            objcomm.FetchClientInfoOnApplciationNo(ref _dsDbLA, strApplicationno, "LA");
            if (_dsDbLA != null && _dsDbLA.Tables.Count > 0 && _dsDbLA.Tables[0].Rows.Count > 0)
            {
                string strFirstName,
                        strLastName
                        , strGender
                        , strDob;
                //set values
                strFirstName = Convert.ToString(_dsDbLA.Tables[0].Rows[0]["FIRST_NAME"]);
                strLastName = Convert.ToString(_dsDbLA.Tables[0].Rows[0]["LAST_NAME"]);
                strGender = Convert.ToString(_dsDbLA.Tables[0].Rows[0]["GENDER"]);
                strDob = Convert.ToString(_dsDbLA.Tables[0].Rows[0]["DOB"]);
                objBusinessLayer.DedupeSearch_GET(ref _ds, strFirstName, strLastName, (string.IsNullOrEmpty(strDob) ? string.Empty : Convert.ToDateTime(strDob).ToString("MM-dd-yyyy")), (strGender.Equals("MALE")) ? 'M' : 'F', string.Empty);
                if (_ds != null && _ds.Tables.Count > 0 && _ds.Tables[0].Rows.Count > 0)
                {
                    dgUwDedupe.DataSource = _ds;
                    dgUwDedupe.DataBind();
                    divDgClientDedupe.Attributes["class"] = divDgClientDedupe.Attributes["class"].Replace(" HideControl", string.Empty);
                }
                else
                {
                    dgUwDedupe.DataSource = null;
                    dgUwDedupe.DataBind();
                    divDgClientDedupe.Attributes["class"] = divDgClientDedupe.Attributes["class"] + " HideControl";
                }
            }

            //strRet = FillDedupeDetails(_ds);
        }
        catch (Exception ex)
        {


        }
        finally
        {
            /*added by shri on 28 dec 17 to update tracking*/
            UpdateUwDecisionTracking(intTrackingRet, DateTime.Now, ref intTrackingRet);
            /*END HERE*/
            ScriptManager.RegisterStartupScript(Page, GetType(), "disp_confirm", "<script>hideloading()</script>", false);
        }
    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {

    }

    private void BindRiskParameter(DataTable dt)
    {
        #region 42.1 Begin Of Changes Of CR-30543 changes by Sushant Devkate [MFL00905]
        bool ISTermProduct = false;
        foreach (RepeaterItem item in rptproductlist.Items)
        {
            TextBox txtProdcode = (TextBox)item.FindControl("txtProdcode");
            ISTermProduct = new Commfun().GetIsTermProduct(txtProdcode.Text.Trim());
        }
        #endregion 42.1 End Of Changes Of CR-30543 changes by Sushant Devkate [MFL00905]

        if (dt != null && dt.Rows.Count > 0)
        {
            txtBMI.Text = Convert.ToString(dt.Rows[0]["DATA"]);
            if (Convert.ToInt32(dt.Rows[1]["DATA"]) == 0)
            {
                chkRiskParamIsSmoker.Checked = false;
            }
            else
            {
                #region 42.1 Begin Of Changes Of CR-30543 changes by Sushant Devkate [MFL00905]
                if (ISTermProduct)//Term Product 
                {
                    chkRiskParamIsSmoker.Enabled = false;
                }
                #endregion 42.1 End Of Changes Of CR-30543 changes by Sushant Devkate [MFL00905]
                chkRiskParamIsSmoker.Checked = true;
            }
            /*ID:9 START*/
            txtSaralRiskBmi.Text = Convert.ToString(dt.Rows[0]["DATA"]);
            txtHeight.Text = Convert.ToString(dt.Rows[0]["HEIGHT"]);
            txtWeight.Text = Convert.ToString(dt.Rows[0]["WEIGHT"]);
            if (Convert.ToInt32(dt.Rows[1]["DATA"]) == 0)
            {
                chkSaralRiskIsSmoker.Checked = false;
            }
            else
            {
                #region 42.1 Begin Of Changes Of CR-30543 changes by Sushant Devkate [MFL00905]
                if (ISTermProduct)//Term Product 
                {
                    chkRiskParamIsSmoker.Enabled = false;
                }
                #endregion 42.1 End Of Changes Of CR-30543 changes by Sushant Devkate [MFL00905]
                chkSaralRiskIsSmoker.Checked = true;
            }
            #region 42.1 Begin Of Changes Of CR-30543 changes by Sushant Devkate [MFL00905]
            if (ISTermProduct == false) //Non Term Product 
            {
                chkSaralRiskIsSmoker.Enabled = false;
            }
            #endregion 42.1 End Of Changes Of CR-30543 changes by Sushant Devkate [MFL00905]
            /*ID:9 END*/
        }
    }
    /*added by shri on 24 dec 17 to show excel risk parameter*/
    private void BindExcelRiskParameter(DataTable dt)
    {
        /*ID:9 START*/
        if (Convert.ToString(dt.Rows[0][0]).Equals("EXCEL_UPLOAD"))
        {
            /*ID:9 END*/

            if (dt != null && dt.Rows.Count > 0)
            {
                txtRiskParametersCombination.ToolTip = txtRiskParametersCombination.Text = Convert.ToString(dt.Rows[0]["PARAMETERS_COMBINATION"]);
                txtRiskUnderwritingDueDiligenceRequired.ToolTip = txtRiskUnderwritingDueDiligenceRequired.Text = Convert.ToString(dt.Rows[0]["UNDERWRITING_DUE_DILIGENCE_REQUIRED"]);
                txtRiskScore.ToolTip = txtRiskScore.Text = Convert.ToString(dt.Rows[0]["RISK_SCORE"]);
                txtRiskSuggestiveRequirement.ToolTip = txtRiskSuggestiveRequirement.Text = Convert.ToString(dt.Rows[0]["SUGGESTIVE_REQUIREMENT"]);
                txtRiskRemarks.ToolTip = txtRiskRemarks.Text = Convert.ToString(dt.Rows[0]["RISK_REMARKS"]);
                txtRiskBranchName.ToolTip = txtRiskBranchName.Text = Convert.ToString(dt.Rows[0]["BRANCH_NAME"]);

                //designing based on value



                if (Convert.ToInt32(txtRiskScore.Text) >= 75)
                {

                    txtRiskScore.BackColor = System.Drawing.Color.Red;
                    txtRiskScore.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    txtRiskScore.BackColor = System.Drawing.Color.Green;
                    txtRiskScore.ForeColor = System.Drawing.Color.White;
                }
                if (txtRiskParametersCombination.Text.Contains("Parameters") && Convert.ToInt32(txtRiskParametersCombination.Text.Substring(txtRiskParametersCombination.Text.Length - 1)) > 3)
                {
                    /*ID:19 START*/
                    //FillWarningMessage("8");
                    //DisplaySaralWarningMessage();
                    /*ID:19 END*/
                    txtRiskParametersCombination.BackColor = System.Drawing.Color.Red;
                    txtRiskParametersCombination.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    txtRiskParametersCombination.BackColor = System.Drawing.Color.Green;
                    txtRiskParametersCombination.ForeColor = System.Drawing.Color.White;
                }
                /*COMMENTED AND ADDED BY SHRI ON 30 DEC TO SHOW CHANNEL NAME */
                txtRiskChannel.Text = Convert.ToString(dt.Rows[0]["CHANNEL_NAME"]);

                /*END HERE*/
            }
            /*ID:9 START*/
        }
        else if (Convert.ToString(dt.Rows[0][0]).Equals("SARAL_RISK"))
        {
            //txtSaralRiskParamComb.ToolTip = txtSaralRiskParamComb.Text = Convert.ToString(dt.Rows[0]["PARAMETERS_COMBINATION"]);
            //txtSaralRiskUwDueDiligenceReq.ToolTip = txtSaralRiskUwDueDiligenceReq.Text = Convert.ToString(dt.Rows[0]["UNDERWRITING_DUE_DILIGENCE_REQUIRED"]);
            txtSaralRiskScore.ToolTip = txtSaralRiskScore.Text = Convert.ToString(dt.Rows[0]["RISK_SCORE"]);
            txtSaralRiskSuggestiveReq.ToolTip = txtSaralRiskSuggestiveReq.Text = Convert.ToString(dt.Rows[0]["SUGGESTIVE_REQUIREMENT"]);
            //txtSaralRiskRemark.ToolTip = txtSaralRiskRemark.Text = Convert.ToString(dt.Rows[0]["RISK_REMARKS"]);
            txtSaralRiskBranchName.ToolTip = txtSaralRiskBranchName.Text = Convert.ToString(dt.Rows[0]["BRANCH_NAME"]);
            //designing based on value
            txtSaralRiskChannel.Text = Convert.ToString(dt.Rows[0]["CHANNEL_NAME"]);
            //Added by Suraj on 12 DEC 2019 display IIB ,CIBIL score and Income Estimator
            txtIIBScore.ToolTip = txtIIBScore.Text = Convert.ToString(dt.Rows[0]["IIB_SCORE"]);

            if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["CIBIL_SCORE"])))
            {
                txtApplicationDetailsCibil.Text = Convert.ToString(dt.Rows[0]["CIBIL_SCORE"]).TrimStart(new Char[] { '0' });
            }
            else
            {
                txtApplicationDetailsCibil.Text = strCIBILScore;
            }

            txtincomeest.Text = Convert.ToString(dt.Rows[0]["INCOME_ESTIMATOR"]);

            if (!string.IsNullOrWhiteSpace(txtSaralRiskScore.Text) && Convert.ToInt32(txtSaralRiskScore.Text) > 70)
            {

                txtSaralRiskScore.BackColor = System.Drawing.Color.Red;
                txtSaralRiskScore.ForeColor = System.Drawing.Color.White;
            }
            else
            {
                txtSaralRiskScore.BackColor = System.Drawing.Color.Green;
                txtSaralRiskScore.ForeColor = System.Drawing.Color.White;
            }

            if (!string.IsNullOrWhiteSpace(txtApplicationDetailsCibil.Text))
            {
                if (Convert.ToInt32(txtApplicationDetailsCibil.Text) >= 600)
                {
                    txtApplicationDetailsCibil.BackColor = System.Drawing.Color.Green;
                    txtApplicationDetailsCibil.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    txtApplicationDetailsCibil.BackColor = System.Drawing.Color.Red;
                    txtApplicationDetailsCibil.ForeColor = System.Drawing.Color.White;
                }

            }
            //else
            //{
            //    txtApplicationDetailsCibil.BackColor = System.Drawing.Color.Red;
            //    txtApplicationDetailsCibil.ForeColor = System.Drawing.Color.White;
            //}
            //Added by Suraj on 06 June 2019 for color change when IIB score is >= 800
            if (!string.IsNullOrWhiteSpace(txtIIBScore.Text) && Convert.ToInt32(txtIIBScore.Text) >= 700)
            {

                txtIIBScore.BackColor = System.Drawing.Color.Red;
                txtIIBScore.ForeColor = System.Drawing.Color.White;
            }
            else
            {
                if (!string.IsNullOrEmpty(txtIIBScore.Text))
                {
                    txtIIBScore.BackColor = System.Drawing.Color.Green;
                    txtIIBScore.ForeColor = System.Drawing.Color.White;
                }

            }
            //END

            /*ID:21 START*/
            txtENYScore.Text = Convert.ToString(dt.Rows[0]["ENY_SCORE"]);
            if (!string.IsNullOrEmpty(txtENYScore.Text))
            {
                /*ID:1 START*/
                //if (Convert.ToInt32(txtENYScore.Text) >= 72)
                if (Convert.ToInt32(txtENYScore.Text) > 111)/*ID:1 END*/
                {
                    txtENYScore.BackColor = System.Drawing.Color.Red;
                    txtENYScore.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    txtENYScore.BackColor = System.Drawing.Color.Green;
                    txtENYScore.ForeColor = System.Drawing.Color.White;
                }
            }
            /*ID:21 END*/
            //if (txtSaralRiskParamComb.Text.Contains("Parameters") && Convert.ToInt32(txtSaralRiskParamComb.Text.Substring(txtSaralRiskParamComb.Text.Length - 1)) > 3)
            //{
            //    /*ID:19 START*/
            //    //FillWarningMessage("8");
            //    //DisplaySaralWarningMessage();

            //    /*ID:19 END*/
            //    txtSaralRiskParamComb.BackColor = System.Drawing.Color.Red;
            //    txtSaralRiskParamComb.ForeColor = System.Drawing.Color.White;
            //}
            //else
            //{
            //    txtSaralRiskParamComb.BackColor = System.Drawing.Color.Green;
            //    txtSaralRiskParamComb.ForeColor = System.Drawing.Color.White;
            //}

            /*WarningId is comming from warning msg API ,below code should be in page load
            string WarningId = string.Empty;
            string[] Warningsplit = WarningId.Split(',');
            foreach (string  item in Warningsplit)
            {

            }
            */

            /*ID:19 START*/
            DataSet _dsstate = new DataSet();
            DataSet _dsIsClient = new DataSet();
            DataSet _dsPrevstatus = new DataSet();
            objcomm.FetchBranchState(ref _dsstate, strApplicationno);
            string strbranchstate = string.Empty;
            string strcuststate = string.Empty;
            string strCustPincode = string.Empty;
            string strBranchPincode = string.Empty;

            if (_dsstate.Tables.Count > 0)
            {
                if (_dsstate.Tables[0].Rows.Count > 0)
                {
                    strbranchstate = Convert.ToString(_dsstate.Tables[0].Rows[0]["STATE"]).ToUpper().TrimEnd();
                    strBranchPincode = Convert.ToString(_dsstate.Tables[0].Rows[0]["BranchPincode"]).ToUpper().TrimEnd();
                    strBranchPincode = new string(strBranchPincode.Take(3).ToArray());
                }
                if (_dsstate.Tables[1].Rows.Count > 0)
                {
                    strcuststate = Convert.ToString(_dsstate.Tables[1].Rows[0]["ADR_state"]).ToUpper().TrimEnd();
                    strCustPincode = Convert.ToString(_dsstate.Tables[1].Rows[0]["CustPincode"]).ToUpper().TrimEnd();
                    strCustPincode = new string(strCustPincode.Take(3).ToArray());
                }
                //For Term product with Salaried
                if (_dsstate.Tables[7].Rows.Count > 0)
                {

                    if (!string.IsNullOrWhiteSpace(txtApplicationDetailsCibil.Text))
                    {
                        if (Convert.ToInt32(txtApplicationDetailsCibil.Text) >= 650)
                        {
                            txtApplicationDetailsCibil.BackColor = System.Drawing.Color.Green;
                            txtApplicationDetailsCibil.ForeColor = System.Drawing.Color.White;
                        }
                        else
                        {
                            txtApplicationDetailsCibil.BackColor = System.Drawing.Color.Red;
                            txtApplicationDetailsCibil.ForeColor = System.Drawing.Color.White;
                        }
                    }
                    //else
                    //{
                    //    txtApplicationDetailsCibil.BackColor = System.Drawing.Color.Red;
                    //    txtApplicationDetailsCibil.ForeColor = System.Drawing.Color.White;
                    //}
                }
                /*
                //For Term product except salaried
                if (_dsstate.Tables[8].Rows.Count > 0)
                {

                    if (!string.IsNullOrWhiteSpace(txtApplicationDetailsCibil.Text) && (Convert.ToInt32(txtApplicationDetailsCibil.Text) >= 00700 || Convert.ToInt32(txtApplicationDetailsCibil.Text) >= 700))
                    {
                        txtApplicationDetailsCibil.BackColor = System.Drawing.Color.Green;
                        txtApplicationDetailsCibil.ForeColor = System.Drawing.Color.White;

                    }
                    else
                    {
                        txtApplicationDetailsCibil.BackColor = System.Drawing.Color.Red;
                        txtApplicationDetailsCibil.ForeColor = System.Drawing.Color.White;
                    }
                }
                */
                //For BFL cases
                if (_dsstate.Tables[9].Rows.Count > 0)
                {

                    if (!string.IsNullOrWhiteSpace(txtApplicationDetailsCibil.Text))
                    {
                        if (Convert.ToInt32(txtApplicationDetailsCibil.Text) >= 600)
                        {
                            txtApplicationDetailsCibil.BackColor = System.Drawing.Color.Green;
                            txtApplicationDetailsCibil.ForeColor = System.Drawing.Color.White;
                        }
                        else
                        {
                            txtApplicationDetailsCibil.BackColor = System.Drawing.Color.Red;
                            txtApplicationDetailsCibil.ForeColor = System.Drawing.Color.White;
                        }
                    }
                    //else
                    //{
                    //    txtApplicationDetailsCibil.BackColor = System.Drawing.Color.Red;
                    //    txtApplicationDetailsCibil.ForeColor = System.Drawing.Color.White;
                    //}
                }
                //For Amex cases or For Term product except salaried
                if (_dsstate.Tables[8].Rows.Count > 0 || _dsstate.Tables[10].Rows.Count > 0)
                {

                    if (!string.IsNullOrWhiteSpace(txtApplicationDetailsCibil.Text) && Convert.ToInt32(txtApplicationDetailsCibil.Text) >= 700)
                    {
                        if (Convert.ToInt32(txtApplicationDetailsCibil.Text) >= 700)
                        {
                            txtApplicationDetailsCibil.BackColor = System.Drawing.Color.Green;
                            txtApplicationDetailsCibil.ForeColor = System.Drawing.Color.White;

                        }
                        else
                        {
                            txtApplicationDetailsCibil.BackColor = System.Drawing.Color.Red;
                            txtApplicationDetailsCibil.ForeColor = System.Drawing.Color.White;
                        }


                    }
                    //else
                    //{
                    //    txtApplicationDetailsCibil.BackColor = System.Drawing.Color.Red;
                    //    txtApplicationDetailsCibil.ForeColor = System.Drawing.Color.White;
                    //}
                }
            }
            if (!string.IsNullOrWhiteSpace(txtApplicationDetailsCibil.Text))
            {
                if (Convert.ToInt32(txtApplicationDetailsCibil.Text) == -1)
                {
                    txtApplicationDetailsCibil.BackColor = System.Drawing.Color.White;
                    txtApplicationDetailsCibil.ForeColor = System.Drawing.Color.Black;
                }
            }
            //string[] strBranchName = { "New Delhi Pitampura", "EZone Rohini New Delhi", "Gwalior", "Jaipur", "Bangalore", "Guwahati", "Nashik", "Hyderabad", "Gorakhpur", "Bhubaneshwar", "Baroda", "Ahmedabad", "Bhopal", "Aligarh" };
            //for (int i = 0; i < strBranchName.Length; i++)
            //{
            //_dsstate.Tables[2].Rows.Count == 0 this condition is for high risk city is exist

            if (!string.IsNullOrEmpty(txtdistance.Text) && _dsstate != null && _dsstate.Tables.Count > 0)
            {
                //added by suraj on 07-02-2019 for If Login branch is BAG or JAI or BAR or AHM and Channel is Direct and Distance is above 50KM/Other state then msg display
                if (((Convert.ToDouble(txtdistance.Text) > 50 || (!strbranchstate.Equals(strcuststate) && (!strCustPincode.Equals("121") && !strCustPincode.Equals("122") && !strCustPincode.Equals("110") && !strCustPincode.Equals("201")) && (!strBranchPincode.Equals("121") && !strBranchPincode.Equals("122") && !strBranchPincode.Equals("110") && !strBranchPincode.Equals("201")))) && _dsstate.Tables[2].Rows.Count > 0 && (Convert.ToString(_dsstate.Tables[2].Rows[0]["BranchCode"]).Equals("BAG") || Convert.ToString(_dsstate.Tables[2].Rows[0]["BranchCode"]).Equals("JAI") || Convert.ToString(_dsstate.Tables[2].Rows[0]["BranchCode"]).Equals("BAR") || Convert.ToString(_dsstate.Tables[2].Rows[0]["BranchCode"]).Equals("AHM")) && Convert.ToString(txtSaralRiskChannel.Text).Equals("Direct Sales")))
                {
                    FillWarningMessage("64");
                    DisplaySaralWarningMessage();

                }
                if (_dsstate.Tables[0].Rows.Count > 0)
                {
                    if (_dsstate.Tables[2].Rows.Count > 0 && (Convert.ToDouble(txtdistance.Text) > 50 || (!strbranchstate.Equals(strcuststate) && (!strCustPincode.Equals("121") && !strCustPincode.Equals("122") && !strCustPincode.Equals("110") && !strCustPincode.Equals("201")) && (!strBranchPincode.Equals("121") && !strBranchPincode.Equals("122") && !strBranchPincode.Equals("110") && !strBranchPincode.Equals("201")))) && (Convert.ToString(txtSaralRiskChannel.Text).Equals("Direct Sales") || Convert.ToString(txtSaralRiskChannel.Text).Equals("Tied Agency-Core") || Convert.ToString(txtSaralRiskChannel.Text).Equals("Tied Agency-IM")))
                    {
                        if (!strbranchstate.Equals(strcuststate))
                        {

                        }
                        FillWarningMessage("31");
                        DisplaySaralWarningMessage();
                    }
                    //Commented by Suraj on 18-SEP-2019 for CR NO-27647
                    /*
                    if (_dsstate.Tables[2].Rows.Count == 0 && (Convert.ToDouble(txtdistance.Text) > 50 || (!strbranchstate.Equals(strcuststate) && (!strCustPincode.Equals("121") && !strCustPincode.Equals("122") && !strCustPincode.Equals("110") && !strCustPincode.Equals("201")) && (!strBranchPincode.Equals("121") && !strBranchPincode.Equals("122") && !strBranchPincode.Equals("110") && !strBranchPincode.Equals("201")))) && (Convert.ToString(txtSaralRiskChannel.Text).Equals("Tied Agency-Core") || Convert.ToString(txtSaralRiskChannel.Text).Equals("Tied Agency-IM")))
                    {
                        FillWarningMessage("23");
                        DisplaySaralWarningMessage();
                    }
                    if (_dsstate.Tables[2].Rows.Count == 0 && (Convert.ToDouble(txtdistance.Text) > 50 || (!strbranchstate.Equals(strcuststate) && (!strCustPincode.Equals("121") && !strCustPincode.Equals("122") && !strCustPincode.Equals("110") && !strCustPincode.Equals("201")) && (!strBranchPincode.Equals("121") && !strBranchPincode.Equals("122") && !strBranchPincode.Equals("110") && !strBranchPincode.Equals("201")))) && (Convert.ToString(txtSaralRiskChannel.Text).Equals("Direct Sales")))
                    {
                        FillWarningMessage("24");
                        DisplaySaralWarningMessage();
                    }
                    */
                }
            }
            //}
            //Commented by Suraj on 18-SEP-2019 for CR NO-27647
            /*
            if (((txtdistance.Text != null && txtdistance.Text != "" && Convert.ToDouble(txtdistance.Text) > 80) || (!strbranchstate.Equals(strcuststate) && (!strCustPincode.Equals("121") && !strCustPincode.Equals("122") && !strCustPincode.Equals("110") && !strCustPincode.Equals("201")) && (!strBranchPincode.Equals("121") && !strBranchPincode.Equals("122") && !strBranchPincode.Equals("110") && !strBranchPincode.Equals("201")))) && !Convert.ToString(txtSaralRiskChannel.Text).Equals("Direct Sales") && !Convert.ToString(txtSaralRiskChannel.Text).Equals("Tied Agency-Core") && !Convert.ToString(txtSaralRiskChannel.Text).Equals("Tied Agency-IM") && !Convert.ToString(txtSaralRiskChannel.Text).Equals("Bankassurance-AU"))
            {
                FillWarningMessage("25");
                DisplaySaralWarningMessage();
            }
            */
            //Added in Warning store proc
            //if (!string.IsNullOrEmpty(txtSaralRiskScore.Text) && !string.IsNullOrEmpty(txtENYScore.Text) && (Convert.ToInt32(txtSaralRiskScore.Text) == 75 || Convert.ToInt32(txtSaralRiskScore.Text) == 150 || ((Convert.ToInt32(txtENYScore.Text) >= 112 && Convert.ToInt32(txtENYScore.Text) <= 158))))
            //{

            //    FillWarningMessage("27");
            //    DisplaySaralWarningMessage();

            //}
            if (cbIsSicl.Checked)
            {
                FillWarningMessage("50");
                DisplaySaralWarningMessage();
            }

            objcomm.IsClientExist(ref _dsIsClient, strApplicationno);
            if (_dsIsClient != null && _dsIsClient.Tables.Count > 0 && _dsIsClient.Tables[0].Rows.Count > 0)
            {
                for (int f = 0; f < _dsIsClient.Tables[0].Rows.Count; f++)
                {
                    objcomm.PreviousCaseStatus(ref _dsPrevstatus, Convert.ToString(_dsIsClient.Tables[0].Rows[f]["CLT_applicationNo"]));
                    if (_dsPrevstatus.Tables.Count > 0 && _dsPrevstatus.Tables[0].Rows.Count > 0 && (_dsPrevstatus.Tables[0].Rows[0]["POL_riskCommencementStrDate"] != null || Convert.ToString(_dsPrevstatus.Tables[0].Rows[0]["POL_riskCommencementStrDate"]) != ""))
                    {
                        DateTime YR = Convert.ToDateTime(_dsPrevstatus.Tables[0].Rows[0]["POL_riskCommencementStrDate"]);
                        double year = (DateTime.Now - YR).Days / 365;
                        if ((year > 2))
                        {
                            FillWarningMessage("41");
                            DisplaySaralWarningMessage();
                            break;
                        }
                    }
                }
            }
            /*ID:19 END*/

        }
        /*ID:9 END*/
    }
    /*end here */
    protected void btnSaveToXml(object sender, EventArgs e)
    {
        Logger.Info(strApplicationno + "PAGE_NAME:UWSaralDecision/btnSaveToXml //EVENT_NAME:OnlineApplicationLAServiceDetails_PUSH//I-INFO:Funcation Execution Begin" + System.Environment.NewLine);
        ReplicaXml objReplica = new ReplicaXml();
        DataSet _dsPremium = new DataSet();
        int intResponse = -1;
        string strResponse = string.Empty;
        bool blnFalse = false;
        Logger.Info(strApplicationno + "STEP :1 Save XMl Start" + System.Environment.NewLine);
        Logger.Info(strApplicationno + "Remark:" + "Save data to xml" + "STAG 8 :PageName :Uwdecision.aspx.CS // MethodeName :btnSaveToXml" + System.Environment.NewLine);
        Logger.Info(strApplicationno + "Is Updated in datatabse: " + blnFalse + System.Environment.NewLine);
        bool isdataSave = true;
        //application details 
        //ManageApplicationDetails(blnFalse, objReplica);

        //PremiumCalculation(objReplica, ref isdataSave, ref _dsPremium, ref intResponse, ref strResponse);
        if (isdataSave == true)
        {
            //bank details
            ManageBankDetails(blnFalse, ref isdataSave, objReplica, ref strResponse);
            Logger.Info(strApplicationno + "Remark:" + "Bank details" + "Bank Details Section Save in Xml" + System.Environment.NewLine);
            //product & rider details 
            if (isdataSave == true)
            {
                ManageProductRiderDetails(blnFalse, ref isdataSave, objReplica, ref strResponse);
                Logger.Info(strApplicationno + "Remark:" + "ProductRider details" + "ProductRider Details Section Save in Xml" + System.Environment.NewLine);
                if (isdataSave == true)
                {
                    ManageMandateDetails(blnFalse, ref isdataSave, objReplica, ref strResponse);
                    Logger.Info(strApplicationno + "Remark:" + "Mandate details" + "Mandate Details Section Save in Xml" + System.Environment.NewLine);
                    //requirement details
                    if (isdataSave == true)
                    {
                        ManageRequirementDetails(blnFalse, ref isdataSave, objReplica, ref strResponse);
                        Logger.Info(strApplicationno + "Remark:" + "Requirments details" + "Mandate Details Section Save in Xml" + System.Environment.NewLine);

                        //Fund Details
                        if (isdataSave == true)
                        {
                            ManageFundDetails(blnFalse, ref isdataSave, objReplica, ref strResponse);
                            Logger.Info(strApplicationno + "Remark:" + "Fund details" + "Fund Details Section Save in Xml" + System.Environment.NewLine);

                            //LOADING DETAILS
                            if (isdataSave == true)
                            {
                                ManageLoadingDetails(blnFalse, ref isdataSave, objReplica, _dsPremium, true, ref strResponse);
                                Logger.Info(strApplicationno + "Remark:" + "Loading details" + "Loading Details Section Save in Xml" + System.Environment.NewLine);
                                //manage applicaiton status                              
                                if (isdataSave == true)
                                {
                                    if (Session["objCommonObj"] != null)
                                    {
                                        Logger.Info(strApplicationno + "STEP :8 Save Replica xml in DB Start" + System.Environment.NewLine);
                                        objCommonObj = (CommonObject)Session["objCommonObj"];
                                        //44.1 Begin of changes Added By Royson Pinto on 22nd NOV to store Restrict Further Cover
                                        if (objCommonObj._Restrict_Further_Cover != "")
                                        {
                                            int res = 0;
                                            objBuss.Save_Country("RestrictFurtherCover", strApplicationno, objCommonObj._Restrict_Further_Cover, objChangeObj.userLoginDetails._UserID, ref res);
                                        }
                                        //44.1 End of changes Added By Royson Pinto on 22nd NOV to store Restrict Further Cover

                                        int intRet = -1;
                                        int intSrNo = Convert.ToInt32(hdnSrNo.Value);
                                        Logger.Info(strApplicationno + "******************Replica xml Object Begin**************" + System.Environment.NewLine);
                                        Logger.Info(strApplicationno + "Replica xml Object" + GetXMLFromObject(objReplica) + System.Environment.NewLine);
                                        Logger.Info(strApplicationno + "******************Replica xml Object End**************" + System.Environment.NewLine);
                                        ManageApplicatonObject(intSrNo, strApplicationno, objReplica, false, ref isdataSave, objCommonObj._Bpmuserdetails._UserID, ref intRet);
                                        if (isdataSave == true)
                                        {
                                            ShowPopupMessage("Details Save Successfully");
                                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('replica Xml Save  succeed')", true);
                                            Logger.Info(strApplicationno + "Remark:" + "Xml details Save in DB" + "Xml details Save in DB " + System.Environment.NewLine);
                                        }
                                        else
                                        {
                                            Logger.Info(strApplicationno + "Remark:" + "Xml details Save in DB" + "Xml details Not Save in DB " + System.Environment.NewLine);
                                            ShowPopupMessage("Error While Save Details ,Please Contact System Admin");
                                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('replica Xml Save Not succeed')", true);
                                            return;
                                        }
                                        hdnSrNo.Value = Convert.ToString(intRet);
                                        Logger.Info(strApplicationno + "STEP :8 Save Replica xml in DB end" + System.Environment.NewLine);
                                    }

                                }
                                else
                                {
                                    return;
                                }
                            }
                            else
                            {
                                Logger.Info(strApplicationno + "Remark:" + "Fund details" + "Fund Details Section Not Save in Xml" + System.Environment.NewLine);
                                ShowPopupMessage(strResponse);
                                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Requirment Details Not succeed')", true);
                                return;
                            }
                        }
                        else
                        {
                            Logger.Info(strApplicationno + "Remark:" + "Requirement details" + "Requirement Details Section Not Save in Xml" + System.Environment.NewLine);
                            ShowPopupMessage(strResponse);
                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Mandate Details Not succeed')", true);
                            return;
                        }
                    }
                    else
                    {
                        Logger.Info(strApplicationno + "Remark:" + "Mandate details" + "Mandate Details Section Not Save in Xml" + System.Environment.NewLine);
                        ShowPopupMessage(strResponse);
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ProductRider Details Not succeed')", true);
                        return;
                    }
                }
                else
                {
                    Logger.Info(strApplicationno + "Remark:" + "Rider details" + "Rider Details Section Not Save in Xml" + System.Environment.NewLine);
                    ShowPopupMessage(strResponse);
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Bank Details Not succeed')", true);
                    return;
                }
                /*end here*/
            }
            else
            {
                Logger.Info(strApplicationno + "Remark:" + "Bank details" + "Bank Details Section Not Save in Xml" + System.Environment.NewLine);
                ShowPopupMessage(strResponse);
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Bank Details Not succeed')", true);
                return;
            }

            //MANAGE PRODUCT DETAILS
            //ManageProductDetails(blnFalse, objReplica);              
        }
        else
        {
            Logger.Info(strApplicationno + "Remark:" + "Premium Calculation --XML SAVE" + "Premium Calculation not Success while save data to XML" + System.Environment.NewLine);
            ShowPopupMessage(strResponse);
            // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Premium Calculation Not succeed, Please Click on Calculate Premium to verify')", true);
            return;
        }
    }

    protected void btnSaveToDatabase(object sender, EventArgs e)
    {
        /*ID:6 START*/
        if (!string.IsNullOrEmpty(txtUWComments.Value))
        {
            SaveUwComment();
        }
        #region Start 38.1: This CR-2809 changes done by Sushant Devkate MFL00905 
        SaveIIBImpact(strApplicationno);
        #endregion End 38.1: This CR-2809 changes done by Sushant Devkate MFL00905
        /*ID:6 END*/
        if (!ddlrelaAU.SelectedValue.Equals("0"))
        {
            AUBankRelationSave();
        }
        /*ID:5 START*/
        /*
        if (ddlUWDecesion.SelectedValue.Equals("Approved") && strChannelType.ToLower().Equals("online"))
        {
            if (imgAadharVerified.ImageUrl.Contains("Failuer"))
            {
                ShowPopupMessage("Please verify aadhar details");
                throw new Exception("UDE-Verify Aadhar Details");
            }
            if (imgPanVerified.ImageUrl.Contains("Failuer"))
            {
                ShowPopupMessage("Please verify pan details");
                throw new Exception("UDE-Verify pan Details");
            }
        }
        */
        /*ID:5 END*/
        /*ID:8 START*/
        //if (strChannelType.Equals("offline") && (Convert.ToInt32(txtBasepremium.Text)-Convert.ToInt32(txtProdBranchBasePremium.Text))>200)
        //{
        //    throw new Exception("UDE-01");
        //}
        /*ID:8 END*/
        Logger.Info(strApplicationno + "PAGE_NAME:UWPortfolio/UWdecision/btnSaveToDatabase //EVENT_NAME:OnlineApplicationLAServiceDetails_PUSH//I-INFO:Funcation Execution Begin" + Environment.NewLine);
        ReplicaXml objReplica = new ReplicaXml();
        DataSet _dsPremium = new DataSet();
        int intResponse = -1;
        string strResponse = string.Empty;
        bool blnFalse = !false;
        bool isdataSave = true;
        //GetMEdicalComment();

        //Added by kavita on 06/05/2020 CR-27523--------------------------------------------
        if (ddlRiskInvestDecision.SelectedIndex != 0)
        {
            string decisionStatus = ddlRiskInvestDecision.SelectedValue.ToString();
            objcomm.InsertRiskInvestigationStatusForPostClick(strApplicationno, decisionStatus);
        }
        //Ended by kavita on 06/05/2020 CR-27523--------------------------------------------

        //added by suraj for combi
        ProductSection objprodctlis = new ProductSection();

        foreach (RepeaterItem item in rptproductlist.Items)
        {
            TextBox txtPolNo = (TextBox)item.FindControl("txtBasepolno");
            if (txtPolNo.Text == strPolicyNo)
            {
                BindProductDetails_Combi(item, ref objprodctlis);
                PremiumCalculation(objReplica, ref isdataSave, ref _dsPremium, ref intResponse, ref strResponse, objprodctlis, rptprodctlistcount);
            }

        }

        rptprodctlistcount++;
        //end
        //PremiumCalculation(objReplica, ref isdataSave, ref _dsPremium, ref intResponse, ref strResponse);
        if (isdataSave == true)
        {
            //bank details
            ManageBankDetails(blnFalse, ref isdataSave, objReplica, ref strResponse);
            //product & rider details 
            if (isdataSave == true)
            {
                ManageProductRiderDetails(blnFalse, ref isdataSave, objReplica, ref strResponse);
                //manage mandate 
                if (isdataSave == true)
                {
                    // ManageMandateDetails(blnFalse, ref isdataSave, objReplica, ref strResponse);
                    //requirement details
                    if (isdataSave == true)
                    {
                        ManageRequirementDetails(blnFalse, ref isdataSave, objReplica, ref strResponse);
                        //Fund Details
                        if (isdataSave == true)
                        {
                            ManageFundDetails(blnFalse, ref isdataSave, objReplica, ref strResponse);
                            Logger.Info(strApplicationno + "Remark:" + "Fund details" + "Fund Details Section Save in Xml" + System.Environment.NewLine);
                            //LOADING DETAILS
                            if (isdataSave == true)
                            {
                                ManageLoadingDetails(blnFalse, ref isdataSave, objReplica, _dsPremium, true, ref strResponse);
                                //manage applicaiton status
                                if (isdataSave == true)
                                {
                                    //ManageApplicatoinStatus(ref isdataSave);
                                    //ManageApplicationObjectLog    
                                    if (isdataSave == true)
                                    {
                                        if (Session["objCommonObj"] != null)
                                        {
                                            Logger.Info(strApplicationno + "STEP :8 Save Replica xml in DB Start" + System.Environment.NewLine);
                                            objCommonObj = (CommonObject)Session["objCommonObj"];
                                            int intRet = -1;
                                            int intSrNo = Convert.ToInt32(hdnSrNo.Value);
                                            Logger.Info(strApplicationno + "******************Replica xml Object Begin**************" + System.Environment.NewLine);
                                            Logger.Info(strApplicationno + "Replica xml Object" + GetXMLFromObject(objReplica) + System.Environment.NewLine);
                                            Logger.Info(strApplicationno + "******************Replica xml Object End**************" + System.Environment.NewLine);
                                            ManageApplicatonObject(intSrNo, strApplicationno, objReplica, true, ref isdataSave, objCommonObj._Bpmuserdetails._UserID, ref intRet);
                                            if (isdataSave == true)
                                            {
                                                Logger.Info(strApplicationno + "Remark:" + "UWsaral details post Success" + System.Environment.NewLine);
                                            }
                                            else
                                            {
                                                Logger.Info(strApplicationno + "Remark:" + "Post replica xml details not save in Database" + System.Environment.NewLine);
                                                ShowPopupMessage("Details Post Successfully");
                                                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Details Post Successfully')", true);
                                            }
                                            int intRetVal = -1;
                                            string strEventkey = string.Empty;
                                            foreach (RepeaterItem item in rptDecision.Items)
                                            {
                                                Label lblAppno = (Label)item.FindControl("lblAppno");
                                                DropDownList ddlUWDecesion_combi = (DropDownList)item.FindControl("ddlUWDecesion");
                                                if (lblAppno.Text == strApplicationno)
                                                {
                                                    if (ddlUWDecesion_combi.SelectedValue != "proposal")
                                                    {
                                                        strEventkey = ddlUWDecesion_combi.SelectedValue;

                                                    }
                                                    else
                                                    {
                                                        strEventkey = "POST";
                                                    }
                                                }
                                            }
                                            //objcomm.MaintainApplicationLog(strApplicationno, strEventkey, "", objChangeObj.userLoginDetails._UserID, "", ref intRetVal);
                                            Logger.Info(strApplicationno + "STEP :8 Save Replica xml in DB End" + System.Environment.NewLine);
                                            /*ID:10 START*/
                                            ManageDecisionType();
                                            /*ID:10 END*/
                                            //Added by Suraj on 25 APRIL 2018
                                            int resp = 0;
                                            if (Convert.ToInt32(ddlAssigmentType.SelectedValue) != 0 || Convert.ToString(ddlAssigmentType.SelectedValue) != "")
                                            {
                                                objBuss.Save_MedicalReport_Reason(2, strApplicationno, Convert.ToInt32(ddlAssigmentType.SelectedValue), objChangeObj.userLoginDetails._UserID, ref resp);
                                            }
                                            //End
                                            //Added by Suraj on 5 JULY 2018 for save Country in db
                                            int resp1 = 0;
                                            if (Convert.ToString(ddlcountry.SelectedValue) != "" || Convert.ToInt32(ddlcountry.SelectedValue) != 0)
                                            {
                                                //objBuss.Save_Country(strApplicationno, Convert.ToString(ddlcountry.SelectedItem.Text), objChangeObj.userLoginDetails._UserID, ref resp1);
                                                objBuss.Save_Country("Country", strApplicationno, Convert.ToString(ddlcountry.SelectedItem.Text), objChangeObj.userLoginDetails._UserID, ref resp1);
                                            }
                                            //end
                                            if (Convert.ToString(ddlSignature.SelectedValue) != "" || Convert.ToInt32(ddlSignature.SelectedValue) != 0)
                                            {
                                                objBuss.Save_Country("Signature", strApplicationno, Convert.ToString(ddlSignature.SelectedItem.Text), objChangeObj.userLoginDetails._UserID, ref resp1);
                                            }
                                            //Added by Suraj on 13 FEB 2020 for save PEP case/NON PEP case in db
                                            int resp2 = 0;
                                            if (Convert.ToString(ddlPEP.SelectedValue) != "" || Convert.ToInt32(ddlPEP.SelectedValue) != 0)
                                            {
                                                objBuss.Save_PEPCase(strApplicationno, Convert.ToString(ddlPEP.SelectedItem.Text), objChangeObj.userLoginDetails._UserID, ref resp2);
                                            }
                                            //end
                                            /*ID:13 START*/
                                            //ManagePolicyPrinting();
                                            /*ID:13 END*/
                                            //Brijesh start 
                                            string RelationStaff = ddlRelationStaff.SelectedValue == "0" ? "" : ddlRelationStaff.SelectedValue;
                                            string Category = ddlNAWPCatagory.SelectedValue;
                                            objBuss.Save_StaffDetails(strApplicationno, RelationStaff, hd_que_2.Checked, Category, "UW", objChangeObj.userLoginDetails._UserID, ref resp1);
                                            //end  
                                            //39.1 Begin of changes; Sagar Thorave[mfl00886]
                                            string Amlval = GetAmlValTOLifeAsia();
                                            //39.1 End of changes; Sagar Thorave[mfl00886]
                                            /*ID 33 START*/
                                            //objBuss.Save_BusinessException("BusinessException", strApplicationno, chkexcep.Checked, objChangeObj.userLoginDetails._UserID, ref resp1);
                                            /*ID 33 END*/
                                        }
                                    }
                                    else
                                    {
                                        Logger.Info(strApplicationno + "Remark:" + "ApplicationStatus details" + "ApplicationStatus Details Section Not Save in Xml" + System.Environment.NewLine);
                                        ShowPopupMessage("ApplicationStatus Details Not Save");
                                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ApplicationStatus Details Not succeed')", true);
                                        return;
                                    }
                                }
                                else
                                {
                                    Logger.Info(strApplicationno + "Remark:" + "Loading details" + "Loading Details Section Not Save in Xml" + System.Environment.NewLine);
                                    ShowPopupMessage("Loading Details Not Save");
                                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Loading Details Not succeed')", true);
                                    return;
                                }
                            }
                            else
                            {
                                Logger.Info(strApplicationno + "Remark:" + "Requirment details" + "Requirment Details Section Not Save in Xml" + System.Environment.NewLine);
                                ShowPopupMessage("Requirment Details Not Save");
                                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Requirment Details Not succeed')", true);
                                return;
                            }
                        }
                        else
                        {
                            Logger.Info(strApplicationno + "Remark:" + "Fund details" + "Fund Details Section Not Save" + System.Environment.NewLine);
                            ShowPopupMessage("Fund Details Not Save");
                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Requirment Details Not succeed')", true);
                            return;
                        }

                    }
                    else
                    {
                        Logger.Info(strApplicationno + "Remark:" + "Mandate details" + "Mandate Details Section Not Save in Xml" + System.Environment.NewLine);
                        ShowPopupMessage("Mandate Details Not Save");
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Mandate Details Not succeed')", true);
                        return;
                    }
                }
                else
                {
                    Logger.Info(strApplicationno + "Remark:" + "ProductRider details" + "ProductRider Details Section Not Save in Xml" + System.Environment.NewLine);
                    ShowPopupMessage("ProductRider Details Not Save");
                    // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ProductRider Details Not succeed')", true);
                    return;
                }
            }
            else
            {
                Logger.Info(strApplicationno + "Remark:" + "Bank details" + "Bank Details Section Not Save in Xml" + System.Environment.NewLine);
                ShowPopupMessage("Bank Details Not Save");
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Bank Details Not succeed')", true);
                return;
            }
        }
        else
        {
            ShowPopupMessage("Premium calculation not succeed,please Click on calculate button");
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Premium calculation not succeed,please calculate on Premium calculation button to verify')", true);
            return;
        }
        //MANAGE PRODUCT DETAILS
        //ManageProductDetails(blnFalse, objReplica);                                            
        Logger.Info(strApplicationno + "PAGE_NAME:UWPortfolio/UWdecision/btnSaveToDatabase //EVENT_NAME:OnlineApplicationLAServiceDetails_PUSH//I-INFO:Funcation Execution Begin" + System.Environment.NewLine);
    }
    /*ADDED BY SHRI TO CALL VALIDATION */
    protected void btnServerValidation(object sender, EventArgs e)
    {

        string str = this.strApplicationno;
        #region 41.1 End Of Changes Of CR-2394 Validation coustomer mob with agent by Sushant Devkate [MFL00905]
        foreach (RepeaterItem item in rptDecision.Items)
        {
            DropDownList ddlUWDecesion_combi = (DropDownList)item.FindControl("ddlUWDecesion");
            Label lblAppno = (Label)item.FindControl("lblAppno");
            if (ddlUWDecesion_combi.SelectedValue.Equals("Approved"))
            {
                bool IsAPICAll = Convert.ToBoolean(ConfigurationManager.AppSettings["IsAgntChkAPIURLCall"].ToString());
                if (IsAPICAll)
                {
                    objChangeObj = (ChangeValue)Session["objLoginObj"];
                    ValidationDO ObjValidationDO = new CheckValidationBLL().GetClientHolderDataforValidation(strApplicationno, "UW", objChangeObj.userLoginDetails._UserID);

                    if (ObjValidationDO != null)
                    {
                        if (ObjValidationDO.IsValid == false && ObjValidationDO.Message != "")
                        {
                            ShowPopupMessage(ObjValidationDO.Message);
                            throw new Exception("UDE-" + ObjValidationDO.Message);
                        }
                    }
                }
                //45.1 Begin of Changes; Jayendra - [WebAshlar01]

                bool IsUINNoCheck = false;
                IsUINNoCheck = new Commfun().IsUinNoStatusCheck(lblAppno.Text.Trim());

                if (IsUINNoCheck)
                {
                    ShowPopupMessage("UINNO is mismatch. Please withdraw the application!");
                    throw new Exception("UDE-UINNO is mismatch. Please withdraw the application!");
                }
                //45.1 End of Changes; Jayendra - [WebAshlar01]
            }
        }
        #endregion 41.1 End Of Changes Of CR-2394 Validation coustomer mob with agent by Sushant Devkate [MFL00905]
        DataTable _datatable = new DataTable();
        for (int i = 0; i < gvRequirmentDetails.Columns.Count; i++)
        {
            _datatable.Columns.Add(gvRequirmentDetails.Columns[i].ToString());
        }
        foreach (GridViewRow row in gvRequirmentDetails.Rows)
        {
            DataRow dr = _datatable.NewRow();
            string DDLFC = string.Empty, DDLCAT = string.Empty, DDLSTAT = string.Empty, FD = string.Empty;
            DropDownList dp = (DropDownList)row.FindControl("ddlfollowupcode");
            if (dp != null)
                DDLFC = dp.SelectedItem.Text;
            DropDownList dpc = (DropDownList)row.FindControl("ddlCategory");
            if (dpc != null)
                DDLCAT = dpc.SelectedItem.Text;
            DropDownList dps = (DropDownList)row.FindControl("ddlStatus");
            if (dps != null)
                DDLSTAT = dps.SelectedValue;
            TextBox lblfollowupDiscp = (TextBox)row.FindControl("lblfollowupDiscp");
            if (lblfollowupDiscp != null)
                FD = lblfollowupDiscp.Text;

            dr[0] = DDLFC;
            dr[1] = FD;
            dr[2] = DDLCAT;
            dr[5] = DDLSTAT;

            _datatable.Rows.Add(dr);
        }

        string strPipe = "|";
        if (lblErrorcommentdtls.Text == "")
        {
            ShowPopupMessage("Please enter comment..!");
            throw new Exception("UDE-Please enter comment..!");
        }

        //ADDED BY SURAJ FOR COMBI
        strApplicationno = Session["AppNo_Combi"].ToString(); //((Appcode_Bpmuwmodule)this.Master).v; ;//object.Equals.strApplicationno;//this.strApplicationno;
        strPolicyNo = Session["PolNo_Combi"].ToString();
        int counter = 0;
        string strPrevdecision = string.Empty;
        DataSet _dscombi = new DataSet();
        objcomm.GetCombiFlag(ref _dscombi, strApplicationno);
        if (_dscombi != null && _dscombi.Tables.Count > 1 && _dscombi.Tables[1].Rows.Count > 0)
        {
            Session["IsDetach"] = "No";
            foreach (RepeaterItem item in rptDecision.Items)
            {

                DropDownList ddldecision = (DropDownList)item.FindControl("ddlUWDecesion");
                if (ddldecision != null)
                {
                    if (counter > 0)
                    {
                        if (strPrevdecision != ddldecision.SelectedValue)
                        {
                            ShowPopupMessage("Acceptance of Combi Proposals with different decision terms or with any change in premium or SA of any of individual plans are not permitted. Please check with UW HOD before processing or demerge the combi");
                            throw new Exception("UDE-Acceptance of Combi Proposals with different decision terms or with any change in premium or SA of any of individual plans are not permitted. Please check with UW HOD before processing or demerge the combi");
                        }
                    }
                    else
                    {
                        strPrevdecision = ddldecision.SelectedValue;
                    }
                }

                counter++;
                //strdecision = ddldecision.SelectedValue;
            }
        }
        else
        {
            Session["IsDetach"] = "Yes";
        }
        //END


        DataTable dtreq = new DataTable();
        dtreq = (DataTable)ViewState["CurrentTable1"];
        DataView dv = new DataView(dtreq);
        if (ddlPEP.SelectedValue.Equals("1"))
        {
            dv.RowFilter = "REQ_followUpCode = 'PPE'";
            if (dv.Count == 0)
            {
                ShowPopupMessage("Please add follow up code PPE, as you have selected PEP flag!!");
                throw new Exception("UDE-Please add follow up code PPE, as you have selected PEP flag!!");
            }
            //dv.RowFilter = "REQ_followUpCode = 'MHR'";
            //if (dv.Count == 0)
            //{
            //    ShowPopupMessage("Please add follow up code MHR, as you have selected PEP flag!!");
            //    throw new Exception("UDE-Please add follow up code MHR, as you have selected PEP flag!!");
            //}
        }
        //Added by Suraj on 22-06-2020 for selection of dropdown medical reson when medical followupcode with O/L status

        dtreq = (DataTable)ViewState["CurrentTable1"];
        DataView dvMedicalRea = new DataView(_datatable);
        //dvMedicalRea.RowFilter = "REQ_category = 'Medical' and (REQ_status = 'O' OR REQ_status = 'L' OR REQ_status = 'R')";
        dvMedicalRea.RowFilter = "Category = 'Medical' and Status <> 'W'";
        //dvMedicalRea.RowFilter = "REQ_status = 'O' OR REQ_status = 'L'";
        if (dvMedicalRea.Count > 0 && ddlRequirementMedicalReason.SelectedValue == "0")
        {
            ShowPopupMessage("Please select Medical Reason in Requirement Details!!");
            throw new Exception("UDE-Please select Medical Reason in Requirement Details!!");
        }
        //end

        //Start----------CR-26885 Kavita 26/02/2020 
        foreach (RepeaterItem item in rptDecision.Items)
        {
            DropDownList ddlUWDecesion_combi = (DropDownList)item.FindControl("ddlUWDecesion");
            ListBox ddlAcceptanceReason = item.FindControl("ddlAcceptanceReason") as ListBox;
            if (ddlUWDecesion_combi.SelectedValue != "proposal" && ddlUWDecesion_combi.SelectedValue != "Withdrawn")
             {
                //remove logiv from only offline to add here for both channel on 27032022
                #region 35.1 start: CR -2639 changes done by sushant Devkate [MFL00905]
                if (IsUserLimitLessThanSumAssured())
                {
                    // ShowPopupMessage("You Cannot Process the case since your limit is less than Sum Assured");
                    //throw new Exception("UDE-You Cannot Process the case since your limit is less than Sum Assured");
                    ShowPopupMessage("You Cannot Process the case since your limit is less than FSAR band limit");
                    throw new Exception("UDE-You Cannot Process the case since your limit is less than FSAR band limit");
                }
                #endregion 35.1 END: CR -2639 changes done by sushant Devkate [MFL00905]

                DataSet ds = new DataSet();
                objComm.GetExistingInvestDetails(ref ds, strApplicationno);
                if (ddlInvestigationReport.SelectedIndex == 3)
                {
                    if (Session["CheckPREStatus"] != "" || Session["CheckPREStatus"] != null)
                    {
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            ShowPopupMessage("You have selected as Investigation report not satisfactory, please provide relevant details!!");
                            throw new Exception("UDE-You have selected as Investigation report not satisfactory, please provide relevant details!");

                        }
                    }
                }
            }

            //End------------CR-26885 Kavita 26/02/2020 
            DropDownList ddlCategory = (DropDownList)item.FindControl("ddlCategory");
            if (ddlUWDecesion_combi.SelectedValue.Equals("Approved"))
            {
                //34.1 Begin of Changes; Pooja Shetye - [1133038]
                bool IsvalidPAN = true;
                IsvalidPAN = CheckFlaggingofPANandForm60(txtPannumber.Text, chkPanCopy.Checked, chkForm16Copy.Checked);

                if (IsvalidPAN == true)
                { //34.1 End of Changes; Pooja Shetye - [1133038]

                    //added by suraj on 25 JULY 2019 for signature match
                    if (ddlSignature.SelectedValue.Equals("12"))
                    {
                        string strSignaturecode = ConfigurationManager.AppSettings["SignatureCode"];

                        dv.RowFilter = "REQ_followUpCode = '" + strSignaturecode + "'";
                        dv.RowFilter = "REQ_status = 'R' OR REQ_status = 'W'";
                        if (dv.Count == 0)
                        {
                            ShowPopupMessage("Please raise requirement code 'SEN', if alresdy exists then change status to Received or Waived!!");
                            throw new Exception("UDE-Please raise requirement code 'SEN', if alresdy exists then change status to Received or Waived!!");
                        }
                    }
                    //end
                    //added by suraj on 23 AUG 2019 for reinsurer comment
                    DataTable dtreinsu = new DataTable();
                    dtreinsu = (DataTable)ViewState["CurrentTable1"];
                    string strReinsucode = ConfigurationManager.AppSettings["ReinsurerCode"];
                    DataView dvReinsucode = new DataView(dtreinsu);
                    dvReinsucode.RowFilter = "REQ_followUpCode = '" + strReinsucode + "'";

                    DataTable dtComment = new DataTable();
                    dtComment = (DataTable)ViewState["UWComments"];
                    DataView dvComment = new DataView(dtComment);
                    dvComment.RowFilter = "Remark Like '%Reinsurer Comments%'";

                    if (dvReinsucode.Count != 0 && dvComment.Count == 0)
                    {
                        ShowPopupMessage("Please save Reinsurer comment!!");
                        throw new Exception("UDE-Please save Reinsurer comment!!");
                    }
                    //end
                    /*
                    //added by suraj on 08 APR 2020 for CR NO-26884 
                    UWPreIssueServiceCall(strApplicationno, strChannelType);
                    if (!string.IsNullOrEmpty(txtTotalPremDue.Text) && !string.IsNullOrEmpty(txtTotalpremium.Text))
                    {
                        if ((Convert.ToDecimal(txtTotalpremium.Text) - Convert.ToDecimal(txtTotalPremDue.Text)) > 10 || (Convert.ToDecimal(txtTotalPremDue.Text) - Convert.ToDecimal(txtTotalpremium.Text)) > 10)
                        {
                            ShowPopupMessage("Life Asia total premium and Saral total premium mismatch!!");
                            throw new Exception("UDE-Life Asia total premium and Saral total premium mismatch");
                        }
                    }
                    */

                    DataSet dsresult = new DataSet();
                    objcomm.ChkNomineePresence(strApplicationno, ref dsresult);
                    if (dsresult != null && dsresult.Tables.Count > 0 && dsresult.Tables[0].Rows.Count == 0)
                    {
                        ShowPopupMessage("Nominee Not Exists Even Though LA And Proposer Are Same!!");
                        throw new Exception("UDE-Nominee Not Exists Even Though LA And Proposer Are Same!");
                    }
                    // Start Brijesh Pandey
                    //if ((hd_que_2.Checked == true || ddlCategory.SelectedValue == "staff" || ddlNAWPCatagory.SelectedValue == "staff") && ddlRelationStaff.SelectedValue == "0")
                    if ((hd_que_2.Checked == true || ddlNAWPCatagory.SelectedValue == "staff") && ddlRelationStaff.SelectedValue == "0")
                    {
                        ShowPopupMessage("Please fill Relation with Staff Dropdown in Application Details!!");
                        throw new Exception("UDE-Please fill Relation with Staff Dropdown in Application Details!!");
                    }
                    // End

                    DataView dvMedicaldata = new DataView(_datatable);
                    //dvMedicalRea.RowFilter = "REQ_category = 'Medical' and (REQ_status = 'O' OR REQ_status = 'L' OR REQ_status = 'R')";
                    dvMedicaldata.RowFilter = "Category = 'Medical' and Status NOT IN ('W','R')";
                    DataSet _dsmedical = new DataSet();
                    GetMEdicalComment(ref _dsmedical);
                    if (!IsMedicalDE && dvMedicaldata.Count > 0)
                    {
                        ShowPopupMessage("Please Complete Medical Data Entry..!");
                        throw new Exception("UDE-Please Complete Medical Data Entry..!");
                    }
                }
                else
                {
                    //34.1 Begin of Changes; Pooja Shetye - [1133038]
                    ShowPopupMessage("Correct the PAN/Form 60 Flagging.");
                    throw new Exception("UDE-Correct the PAN/Form 60 Flagging.");
                    //34.1 End of Changes; Pooja Shetye - [1133038]
                }

                //49.1 Begin of Changes; Sagar Thorave - [CR-7049]
                showacceptanceApprove();
                //49.1 End of Changes; Sagar Thorave - [CR-7049]

            }

            //Start----------CR-27523 Kavita 26/02/2020 
            if (ddlRiskInvestDecision.SelectedIndex != 0)
            {
                if (ddlRiskInvestDecision.SelectedValue == "Negative-Major")
                {
                    ShowPopupMessage("No serviceable location for CPV, hence raise some other requirement");
                    throw new Exception("No serviceable location for CPV, hence raise some other requirement");
                }
            }
            //End----------CR-27523 Kavita 26/02/2020 
            if (ddlApplicationDetailsProposalType.SelectedValue.Equals("NRI"))
            {
                if (ddlcountry.SelectedValue.Equals("0"))
                {
                    ShowPopupMessage("Please select Residence country of customer");
                    throw new Exception("UDE-Please select Residence country of customer");
                }

            }
            if (strChannelType.ToUpper().Equals("ONLINE"))
            {
                //Added by suraj on 06 June 2019 -bank details mandatory for all policy bazaar cases(FPB)
                if (strApplicationno.Contains("FPB"))
                {
                    if (ddlUWDecesion_combi.SelectedValue.Equals("Approved"))
                    {
                        /*
                        //as discussed with dharmesh sir,add like condition for FPB cases
                        if ((txtProdcode.Text.Equals("U33") || txtProdcode.Text.Equals("U34") || txtProdcode.Text.Equals("U35") || txtProdcode.Text.Equals("U36")) && (string.IsNullOrEmpty(txtBnkIfsccode.Text) || string.IsNullOrEmpty(txtBnkBankaccno.Text)))
                        {
                            ShowPopupMessage("Policy Bazaar Case : Future Payout Bank details are mandatory");
                            throw new Exception("UDE-Policy Bazaar Case : Future Payout Bank details are mandatory");

                        }
                        */
                    }

                }
                /*ID:5 START*/
                /*
                if (ddlUWDecesion.SelectedValue.Equals("Approved") && strChannelType.ToLower().Equals("online"))
                {
                    if (imgAadharVerified.ImageUrl.Contains("Failuer"))
                    {
                        ShowPopupMessage("Please verify aadhar details");
                        throw new Exception("UDE-Verify Aadhar Details");
                    }
                    if (imgPanVerified.ImageUrl.Contains("Failuer"))
                    {
                        ShowPopupMessage("Please verify pan details");
                        throw new Exception("UDE-Verify pan Details");
                    }
                }
                */
                /*ID:5 END*/
            }
            if (strChannelType.ToUpper().Equals("OFFLINE"))
            {
                /*ID:10 START*/

                //not proposalbtnser
                if (!ddlUWDecesion_combi.SelectedValue.Equals("proposal"))
                {
                    //not  decline 
                    if (ddlUWDecesion_combi.SelectedValue.Equals("Approved"))
                    {
                        //check if Nominee Exists Even Though LA And Proposer Are different
                        if (hdnWarningMessage.Value.Contains(strPipe + "2" + strPipe))
                        {
                            ShowPopupMessage("Nominee Exists Even Though LA And Proposer Are different");
                            throw new Exception("UDE-Nominee Exists Even Though LA And Proposer Are different");
                        }

                        //CIBIL
                        if (hdnWarningMessage.Value.Contains(strPipe + "6" + strPipe) && string.IsNullOrEmpty(txtApplicationDetailsCibil.Text))
                        {
                            ShowPopupMessage("Enter CIBIL Score Before Approving");
                            throw new Exception("UDE-Enter CIBIL Score Before Approving");
                        }

                        /*risk mandatory---added txtiib score suggested ny diju on 29 may 2021 commented as this is not feasible*/
                        //if (string.IsNullOrEmpty(txtENYScore.Text) || string.IsNullOrEmpty(txtSaralRiskScore.Text))//|| string.IsNullOrEmpty(txtIIBScore.Text))
                        if ( string.IsNullOrEmpty(txtSaralRiskScore.Text))//|| string.IsNullOrEmpty(txtIIBScore.Text))
                        {
                            ShowPopupMessage("Cannot Approve Since Risk/ENY/IIB Score Is Not Updated");
                            throw new Exception("UDE-Cannot Approve Since Risk/ENY/IIB Score Is Not Updated");
                        }
                        //Added by Suraj on 24 JULY 18 for High Risk category cases
                        DataSet dsresult = new DataSet();
                        objChangeObj = (ChangeValue)Session["objLoginObj"];
                        objcomm.ChkHighCatCasesForWarning(strApplicationno, objChangeObj.userLoginDetails._UserID, ref dsresult);
                        if (dsresult.Tables.Count > 0 && dsresult.Tables[0].Rows.Count > 0)
                        {
                            if (Convert.ToInt32(dsresult.Tables[0].Rows[0]["ID"]) == 28 || Convert.ToInt32(dsresult.Tables[0].Rows[0]["ID"]) == 35 || cbIsSicl.Checked)
                            {
                                HighRisk = true;
                                AddNewRowToGrid1();
                                ShowPopupMessage("High Risk case wherein Profile investigation is mandatory. Please check");
                                throw new Exception("UDE-High Risk case wherein Profile investigation is mandatory. Please check");
                            }
                        }
                        /*ID:13 START*/
                        //if (ddlDecisionDetailsIsPolicyPrintingToHolding.SelectedValue == "-1")
                        //{
                        //    ShowPopupMessage("UDE-Select Whether To Hold Policy Details Or Not");
                        //    throw new Exception("UDE-Select Whether To Hold Policy Details Or Not");
                        //}
                        /*ID:13 END*/
                    }

                    //strUserId
                    //if (IsUserLimitLessThanSumAssured())
                    //{
                    //    ShowPopupMessage("You Cannot Process the case since your limit is less than Sum Assured");
                    //    throw new Exception("UDE-You Cannot Process the case since your limit is less than Sum Assured");
                    //}
                }
            }
            //Added by Suraj on 25 APRIL 2018
            if (ddlApplicationDetailsProposalType.SelectedValue.Equals("EMP"))
            {

                //divassign.Attributes["class"] = divassign.Attributes["class"].ToString().Replace("HideControl", "");
                //clsName = divApplicationDetails.Attributes["class"].ToString();
                //divApplicationDetails.Attributes.Add("class", clsName.Replace(clsName, "col-md-12"));
                if (ddlAssigmentType.SelectedValue.Equals("0"))
                {
                    ShowPopupMessage("Please select Assignment Type");
                    throw new Exception("UDE-Please select Assignment Type");
                }

            }

            //Added by Suraj on 02/12/2018 for those contires which are not allowed to approve the case
            if (Convert.ToString(ddlcountry.SelectedValue) != "" || Convert.ToInt32(ddlcountry.SelectedValue) != 0)
            {
                objBuss.GetCountry(strApplicationno, ref _ds);
                if (_ds.Tables != null && _ds.Tables.Count > 0 && _ds.Tables[0].Rows.Count > 0)
                {
                    ShowPopupMessage("Country is not valid,please check!!");
                    throw new Exception("UDE-Country is not valid,please check!!");
                }
            }
            //else
            //{
            //    divassign.Attributes.Add("Class", "HideControl");
            //}

            bool blnIsCheckedDecisionType = true;
            //if (!ddlUWDecesion.SelectedValue.Equals("proposal"))
            //{
            blnIsCheckedDecisionType = false;
            foreach (ListItem li in cblDecisionTypeDecisions.Items)
            {
                if (li.Selected)
                {
                    blnIsCheckedDecisionType = true;
                    break;
                }

            }
            foreach (ListItem li in cblDecisionTypeDecisions.Items)
            {
                if (!li.Selected)
                {
                    if (Convert.ToInt32(li.Value) == 14 && txtSaralRiskScore.Text != null && txtSaralRiskScore.Text != "" && Convert.ToInt32(txtSaralRiskScore.Text) > 70)
                    {
                        ShowPopupMessage("HOD approval in decision type is mandatory for this risk score");
                        throw new Exception("UDE-HOD approval is mandatory for this risk score");
                    }
                }
            }
            //}
            if (!blnIsCheckedDecisionType)
            {
                foreach (ListItem li in cblDecisionTypeIncompleteDocument.Items)
                {
                    if (li.Selected)
                    {
                        blnIsCheckedDecisionType = true;
                        break;
                    }
                }
                if (!blnIsCheckedDecisionType)
                {
                    foreach (ListItem li in cblDecisionTypeCleanCase.Items)
                    {
                        if (li.Selected)
                        {
                            blnIsCheckedDecisionType = true;
                            break;
                        }
                    }
                    if (!blnIsCheckedDecisionType)
                    {
                        ShowPopupMessage("Please select decision type before proceeding");
                        throw new Exception("UDE-Please select decision type before proceeding");
                    }
                }
            }
            /*ID:10 END*/
            /*ID:8 START*/
            //if (strChannelType.Equals("offline") && (Convert.ToInt32(txtBasepremium.Text)-Convert.ToInt32(txtProdBranchBasePremium.Text))>200)
            //{
            //    throw new Exception("UDE-01");
            //}
            /*ID:8 END*/

            //48.1 Begin of Changes; Bhaumik Patel - [CR-5307]
            if (txtriskcat.Text.ToString().Trim() != "IRSM not applicable")
            {
                showerrorrisk();
            }
            //48.1 Begin of Changes; Bhaumik Patel - [CR-5307]
        }
    }
    /*END HERE*/
    //48.1 Begin of Changes; Bhaumik Patel - [CR-5307]
    protected void showerrorrisk()
    {
        DataSet ds = new DataSet();
        int errocode = 0;
        commobj.OnlineDecisionRightsDisplayDetails_GET("GetUserAccess_Risk_Category", strUserId,UserLimit, ref ds);
        if (ds.Tables[0].Rows.Count > 0)
        {

            foreach (DataRow rows in ds.Tables[0].Rows)
            {
                if (txtriskcat.Text.ToString().Trim() == rows["NAME"].ToString().Trim())
                {
                    errocode = 1;
                }
            }

            if (errocode == 0)
            {
                ShowPopupMessage("" + struserName + " Have No Access For " + txtriskcat.Text + "Risk Category Case ....");
                throw new Exception("UDE-" + struserName + " Have No Access For " + txtriskcat.Text + "Risk Category Case ....");
            }
        }
    }
    //48.1 End of Changes; Bhaumik Patel - [CR-5307]

    private void ManageApplicationDetails(bool blnUpdateInLA, ref bool isdataSave, ReplicaXml objReplica)
    {
        //variable declaration part
        int AppResult = 0;
        int intServicesResultCount = 0, intTotalServiceCount = 3;
        string date = hdnRcdReq.Value;
        lblErrorAppDetailsBody.Text = lblErrorappdtls.Text = string.Empty;
        objChangeObj = (ChangeValue)Session["objLoginObj"];
        AppDtls objApplicationdetails = new AppDtls();
        objApplicationdetails._Backdate = Request.Form[txtRcdreq.UniqueID];
        objChangeObj.App_backdate = objApplicationdetails;
        if (blnUpdateInLA)
        {
            //update in life asia as well as in database
            Logger.Info(strApplicationno + "STAG 2 :PageName :Uwdecision.aspx.CS // MethodeName :btnAppDtlsSave_Click");
            objUWDecision.OnlineApplicationLAServiceDetails_PUSH(strApplicationno, strChannelType, objChangeObj, ref _ds, ref _dsPrevPol, "CONTRACTMODIFICATION", ref strLApushErrorCode, ref strLApushStatus, ref strConsentRespons);
            lblErrorAppDetailsBody.Text = strLApushStatus;
            if (strLApushErrorCode == 0)
            {
                intServicesResultCount++;
                LoadDtls objLoad = new LoadDtls();
                objLoad._strProdcode = "";
                objChangeObj.Load_Loadingdetails = objLoad;
                lblErrorappdtls.Text += "Application Details  updated in Life asia";
                objUWDecision.OnlineApplicationLAServiceDetails_PUSH(strApplicationno, strChannelType, objChangeObj, ref _ds, ref _dsPrevPol, "PREMIUMCAL", ref strLApushErrorCode, ref strLApushStatus, ref strConsentRespons);
                lblErrorAppDetailsBody.Text = strLApushStatus;
                if (_ds != null && _ds.Tables[0].Rows.Count > 0)
                {
                    intServicesResultCount++;
                    txtBackDateIntrest.Text = _ds.Tables[0].Rows[0]["BackDateintrest"].ToString();

                }
                Session["UserName"] = objChangeObj.userLoginDetails._UserName;
                objComm.OnlineApplicationDetails_Save(strPolicyNo, strApplicationno, "Yes", Request.Form[txtRcdreq.UniqueID], ddlBkdateReason.SelectedItem.Value, objChangeObj.userLoginDetails._UserName, objChangeObj.userLoginDetails._UserID, objChangeObj.userLoginDetails._userBranch, objChangeObj.userLoginDetails._userBranch, "UWSaralUnderwritting", strApplicationno, objChangeObj.userLoginDetails._UserID, strChannelType, txtBackDateIntrest.Text, ref AppResult);
                if (AppResult != -1)
                {
                    chkAppDtls.Checked = false;
                }
                else
                {
                    chkAppDtls.Checked = false;
                }
                if (intServicesResultCount == intTotalServiceCount)
                {
                    lblErrorappdtls.Text = "Backdating details updated Successfully Click to know more";
                }
            }
            else
            {
                lblErrorappdtls.Text += "Application Details Not updated in Life asia CLICK to know more";
                lblErrorAppDetailsBody.Text = strLApushStatus;
                chkAppDtls.Checked = false;
            }
        }
        /*added by shri on 08 nov 17 to add data into replica object */
        ApplicationSection objApplicationSection = new ApplicationSection();
        objApplicationSection.AppNo = txtAppno.Text;
        objApplicationSection.PolNo = txtPolno.Text;
        objApplicationSection.AppSignDate = txtAppsigndate.Text;
        objApplicationSection.PIVCSTATUS = txtPivcStatus.Text;
        objApplicationSection.BACKDATEFLAG = switch_havInsurance.Checked;
        objApplicationSection.BACKDATEINTREST = txtBackDateIntrest.Text;
        objApplicationSection.AgentChannel = txtAgentChannel.Text;
        objApplicationSection.BACKDATE = txtRcdreq.Text;
        objApplicationSection.BACHDATEREASON = ddlBkdateReason.SelectedValue;
        objApplicationSection.IsStaff = hd_que_2.Checked;
        objApplicationSection.PIVCRJCREASON = txtPivcRejectReason.Text;
        objApplicationSection.Channel = txtAppchannel.Text;
        if (imgPivcStatus.ImageUrl.Equals(@"../dist/img/Success.png"))
        {
            objApplicationSection.SCRH_PIVC_STATUS = 1;
        }
        else
        {
            objApplicationSection.SCRH_PIVC_STATUS = 0;
        }
        objApplicationSection.AUTOPAYTYPE = ddlAutoPaytype.SelectedValue;
        objApplicationSection.Section = "ApplicationDetails";
        if (objApplicationSection != null)
        {
            objReplica.ApplicationSection = objApplicationSection;
        }
        /*end here*/
    }

    public static string GetXMLFromObject(object o)
    {
        StringWriter sw = new StringWriter();
        XmlTextWriter tw = null;
        try
        {
            XmlSerializer serializer = new XmlSerializer(o.GetType());
            tw = new XmlTextWriter(sw);
            serializer.Serialize(tw, o);
        }
        catch (Exception ex)
        {
            //Handle Exception Code
        }
        finally
        {
            sw.Close();
            if (tw != null)
            {
                tw.Close();
            }
        }
        return sw.ToString();
    }

    private void ManageBankDetails(bool blnUpdateInLA, ref bool isdataSave, ReplicaXml objReplica, ref string strErrorMessage)
    {
        //This is the common funcation to save bank details in xml or database base on blnUpdateInLA parameter value.
        Logger.Info(strApplicationno + "STEP :2 Save BANKDETAILS Start" + System.Environment.NewLine);
        Logger.Info(strApplicationno + "Remark:" + "Bank details" + "STAG 8 :PageName :Uwdecision.aspx.CS // MethodeName :ManageBankDetails" + System.Environment.NewLine);
        Logger.Info(strApplicationno + "Is Updated in datatabse:" + blnUpdateInLA + System.Environment.NewLine);
        int BankResult = 0;
        try
        {
            //objCommonObj = (CommonObject)Session["objCommonObj"];
            // Assign bank section control value to replica xml bank class.
            lblErrorbankdtls.Text = string.Empty;
            BankSection objBankSection = new BankSection();
            objBankSection.ClientName = txtBnkClientname.Text;
            objBankSection.ClientType = txtBnkClienttype.Text;
            objBankSection.ClientNumber = txtBnkClientnumber.Text;
            objBankSection.IFSCCode = txtBnkIfsccode.Text;
            objBankSection.BankName = txtBnkBankname.Text;
            objBankSection.BankBranch = txtBnkBranchname.Text;
            objBankSection.BankAddress = txtBnkBankaddress.Text;
            objBankSection.BankAccountNumber = txtBnkBankaccno.Text;
            objBankSection.Section = "BankDetails";

            Logger.Info(strApplicationno + "MethodeName :ManageBankDetails Object" + System.Environment.NewLine);
            Logger.Info(strApplicationno + "MethodeName :ManageBankDetails Object" + GetXMLFromObject(objBankSection) + System.Environment.NewLine);
            //Add Bank object to replica Xml.
            objReplica.BankSection = objBankSection;
            //check weather value of bank section to be updated in database or save in xml.
            if (blnUpdateInLA)
            {
                Logger.Info(strApplicationno + "remark : Save bank details to database " + " STAG 2 :PageName :Uwdecision.aspx.CS // MethodeName :ManageBankDetails" + System.Environment.NewLine);
                //Save bank details section data in database
                objComm.OnlineBankDetails_Save(strApplicationno, txtBnkClientnumber.Text, txtBnkIfsccode.Text, txtBnkBankname.Text, txtBnkBranchname.Text, txtBnkBankaddress.Text, txtBnkBankaccno.Text, txtBnkClientname.Text, ref BankResult);
                if (BankResult != -1)
                {
                    Logger.Info(strApplicationno + "Remark : Save bank details save in database" + System.Environment.NewLine);
                    chkBankDtls.Checked = false;
                    isdataSave = true;
                    //lblErrorbankdtls.Text = "Bank Details save successfully";
                }
                else
                {
                    isdataSave = false;
                    Logger.Info(strApplicationno + "Remark : Save bank details Not save in database" + System.Environment.NewLine);
                    //lblErrorbankdtls.Text = "Bank Details Not Save ";
                    //lblErrorBankDetailsBody.Text = "Bank Details Not save";
                }
            }
            else
            {

                Logger.Info(strApplicationno + "Remark : bank object save in Xml" + System.Environment.NewLine);
                //lblErrorbankdtls.Text = "Bank Details save successfully";
                //lblErrorBankDetailsBody.Text = "Bank Details save successfully";
            }
            Logger.Info(strApplicationno + "Remark:" + "Bank details End " + "STAG 8 :PageName :Uwdecision.aspx.CS // MethodeName :ManageBankDetails" + System.Environment.NewLine);
        }
        catch (Exception ErrorBank)
        {
            Logger.Info(strApplicationno + "Remark:" + "Exception Bank details" + "STAG 8 :PageName :Uwdecision.aspx.CS // MethodeName :ManageBankDetails" + System.Environment.NewLine);
            Logger.Info(strApplicationno + "Exception Message:" + ErrorBank.Message + System.Environment.NewLine);
            strErrorMessage = "Error While Saving Bank Details ,Please Contact System Admin";
            isdataSave = false;
        }
        Logger.Info(strApplicationno + "STEP :2 Save BANKDETAILS End" + System.Environment.NewLine);
    }

    private void ManageProductDetails(bool blnUpdateInLa, ref bool isdataSave, ReplicaXml objReplica)
    {
        Logger.Info(strApplicationno + "Remark:" + "Product details" + "STAG 8 :PageName :Uwdecision.aspx.CS // MethodeName :ManageProductDetails" + System.Environment.NewLine);
        Logger.Info(strApplicationno + "Is Updated in datatabse:" + blnUpdateInLa + System.Environment.NewLine);
        try
        {
            if (blnUpdateInLa)
            {
                Logger.Info(strApplicationno + "Remark : product details save in database is begins" + System.Environment.NewLine);
                string strComboMonthlyPayout = string.Empty;
                string strProdMonthlyPayout = string.Empty;
                //lblErrorProductDetailBody.Text = lblErrorproddtls.Text = "";
                //gridPremCal_Product.DataSource = null;
                //gridPremCal_Product.DataBind();
                //  objCommonObj = (CommonObject)Session["objCommonObj"];
                //lblErrorproddtls.Text = string.Empty;
                objChangeObj = (ChangeValue)Session["objLoginObj"];
                // Logger.Info(strApplicationno + "STAG 8 :PageName :Uwdecision.aspx.CS // MethodeName :btnProddtlsSave_Click" + System.Environment.NewLine);
                ProdDtls objprodchangevalue = new ProdDtls();

                objprodchangevalue._PolicyTerm = "";// Request.Form[txtPolterm.UniqueID];
                objprodchangevalue._Premiumpayingterm = "";//Request.Form[txtPrepayterm.UniqueID];
                objprodchangevalue._Sumassured = "";//Request.Form[txtSumassure.UniqueID];
                objprodchangevalue._Paymentfrequency = "";//ddlFrequency.SelectedValue;
                strProdMonthlyPayout = objprodchangevalue._MonthlyPayoutBase = "";//Request.Form[txtMonthlyPayoutBase.UniqueID];
                objprodchangevalue._ProdcodeBase = "";// txtProdcode.Text;
                objprodchangevalue._Basepremiumamount = "";//Request.Form[txtBasepremium.UniqueID];
                objprodchangevalue._TotalPremiumamount = "";//txtTotalpremium.Text;

                objChangeObj.Prod_policydetails = objprodchangevalue;

                Logger.Info(strApplicationno + "Remark : product details save in xml" + System.Environment.NewLine + objprodchangevalue + System.Environment.NewLine);

                #region Premium calculation Service call begin.
                objUWDecision.OnlineApplicationLAServiceDetails_PUSH(strApplicationno, strChannelType, objChangeObj, ref _ds, ref _dsPrevPol, "PREMIUMCAL", ref strLApushErrorCode, ref strLApushStatus, ref strConsentRespons);

                List<RiderInfo> lstRiderInfo = new List<RiderInfo>();
                Commfun.FillRiderInfoFromPremiumCalcDataTable(ref lstRiderInfo, _ds.Tables[0]);

                if (strLApushErrorCode == 0 && _ds.Tables.Count > 0)
                {
                    DataSet _dsPremiumCalculation;
                    //lblErrorProductDetailBody.Text = "Premium calculation succeed";
                    //clsName = divPremiumdetails.Attributes["class"].ToString();
                    //divPremiumdetails.Attributes.Add("class", clsName.Replace(clsName, "col-md-12"));
                    Logger.Info(strApplicationno + "Remark : product Premium calculation success while save to database" + System.Environment.NewLine);
                    RiderInfo objrider = lstRiderInfo.Where(x => x.RiderType.Equals("BS") && x.ProductCode.Equals("")).SingleOrDefault();
                    if (objrider != null)
                    {
                        //txtBasepremium.Text = objprodchangevalue._Basepremiumamount = objrider.InstalmentPremiumAmt.ToString();
                        //txtTotalpremium.Text = objprodchangevalue._TotalPremiumamount = objrider.TotalPremiumAmount.ToString();
                        //txtServicetax.Text = objprodchangevalue._ServiceTax = objrider.ServiceTax.ToString();
                        //txtSumassure.Text = objprodchangevalue._Sumassured = objrider.SumAssured.ToString();
                    }
                    RiderInfo objComb = lstRiderInfo.Where(x => x.RiderType.Equals("BS") && x.ProductCode.Equals("")).SingleOrDefault();
                    if (objComb != null)
                    {
                        //txtCombPremAmount.Text = objprodchangevalue._BasepremiumamountCombo = objComb.InstalmentPremiumAmt.ToString();
                        //txtCombTotalPrem.Text = objprodchangevalue._TotalPremiumamountCombo = objComb.TotalPremiumAmount.ToString();
                        //txtCombServiceTax.Text = objprodchangevalue._ServiceTaxCombo = objComb.ServiceTax.ToString();
                        //txtCombSumAssured.Text = objprodchangevalue._SumassuredCombo = objComb.SumAssured.ToString();
                        //txtComboMonthlyPayout.Text = string.IsNullOrEmpty(strComboMonthlyPayout) ? "0" : strComboMonthlyPayout;
                    }

                    objChangeObj.Prod_policydetails = objprodchangevalue;
                    Logger.Info(strApplicationno + "Remark : product details save with Rider details in xml" + System.Environment.NewLine + objprodchangevalue + System.Environment.NewLine);

                    #region Call Contract Modification Service Begins.
                    objUWDecision.OnlineApplicationLAServiceDetails_PUSH(strApplicationno, strChannelType, objChangeObj, ref _ds, ref _dsPrevPol, "CONTRACTMODIFICATION", ref strLApushErrorCode, ref strLApushStatus, ref strConsentRespons);
                    if (strLApushErrorCode == 0)
                    {
                        Logger.Info(strApplicationno + "Remark : Contract modification success to modify contract" + System.Environment.NewLine);
                        //lblErrorProductDetailBody.Text += ",Contract modification succeed";
                        //objComm.OnlineProductDetails_Save(strChannelType, strApplicationno, strPolicyNo, txtProdcode.Text, txtSumassure.Text, txtPolterm.Text, txtPrepayterm.Text, ddlFrequency.SelectedValue, txtBasepremium.Text, txtTotalpremium.Text, txtBasepremium.Text, txtMonthlyPayoutBase.Text, ref _ProdResult);
                        chkProductDtls.Checked = false;
                        int _RiderResult = 0;
                        //lblErrorProductDetailBody.Text += ",Product Details save succeed";
                        //Amit 08062017 Start

                        //objUWDecision.OnlineApplicationLAServiceDetails_PUSH(strApplicationno, strChannelType, objChangeObj, ref _ds, "RATEUP", ref strLApushErrorCode, ref strLApushStatus);
                        //if (strLApushErrorCode == 0)
                        //{
                        //    lblErrorProductDetailBody.Text += ",Loading modification succeed";
                        //}
                        if (gvRiderDtls.Rows.Count > 0)
                        {
                            Logger.Info(strApplicationno + "Remark : Rider details save to database" + System.Environment.NewLine);
                            foreach (GridViewRow rows in gvRiderDtls.Rows)
                            {
                                Label lblRiderCode = (Label)rows.FindControl("lblRiderCode");
                                TextBox txtRiderSumAssure = (TextBox)rows.FindControl("txtRiderSumAssure");
                                TextBox txtRiderPremium = (TextBox)rows.FindControl("txtRiderPremium");
                                objComm.OnlineRiderDetails_Save(strChannelType, strApplicationno, lblRiderCode.Text, txtRiderPremium.Text, txtRiderSumAssure.Text, ref _RiderResult);
                            }
                            if (_RiderResult != -1)
                            {
                                chkProductDtls.Checked = false;
                                Logger.Info(strApplicationno + "Remark : Rider details save to database successfully" + System.Environment.NewLine);
                                //lblErrorProductDetailBody.Text += ",Product Details save succeed";
                                // lblErrorproddtls.Text = "Product Details Updated Successfully";
                            }
                            else
                            {
                                chkProductDtls.Checked = false;
                                Logger.Info(strApplicationno + "Remark : Rider details not save to database" + System.Environment.NewLine);
                                //lblErrorProductDetailBody.Text += "Product Details failed,Please Contact system admin";
                                //lblErrorproddtls.Text = "Product Details Not Updated Successfully";
                            }
                        }
                        //Amit 08062017 End.

                    }
                    else
                    {
                        Logger.Info(strApplicationno + "Remark : Contract modification Failed to modify contract" + System.Environment.NewLine);
                        FillProductDetails(strApplicationno, strChannelType);
                        chkProductDtls.Checked = false;
                        //lblErrorproddtls.Text = "Product Details Not Updated Successfully";
                        //lblErrorProductDetailBody.Text += ",Contract modification failed Error:" + strLApushStatus;
                        //lblErrorProductDetailBody.Text += ",Contract modification failed,Please Contact system admin";

                    }
                    #endregion Call Contract Modification Service End.
                }

                //Amit 08062017 start.
                else if (strLApushErrorCode == 1)
                {
                    Logger.Info(strApplicationno + "Remark : product Premium calculation failed while save to database" + System.Environment.NewLine);
                    chkProductDtls.Checked = false;
                    //lblErrorproddtls.Text = strLApushStatus;
                    //gridPremiumdetails.DataSource = null;
                    //gridPremiumdetails.DataBind();
                    divPremiumdetails.Attributes.Add("class", "col-md-12 HideControl");
                }
                //Amit 08062017 end.
                else
                {
                    chkProductDtls.Checked = false;
                    Logger.Info(strApplicationno + "Remark : product Premium calculation failed while save to database" + System.Environment.NewLine);
                    //lblErrorproddtls.Text = "Product Details Not Updated Successfully";
                    //lblErrorProductDetailBody.Text = "Premium calculation failed,Please Contact system admin";
                    divPremiumdetails.Attributes.Add("class", "col-md-12 HideControl");
                }
                #endregion calculation service call end
                /*added by shri to show updated monthly payout*/
                //txtMonthlyPayoutBase.Text = string.IsNullOrEmpty(strProdMonthlyPayout) ? "0" : strProdMonthlyPayout;
                /*end here*/
            }
            else
            {
                Logger.Info(strApplicationno + "Remark:" + "Product details save to xml" + "STAG 8 :PageName :Uwdecision.aspx.CS // MethodeName :ManageProductDetails" + System.Environment.NewLine);
                List<ProductSection> lstProductSection = new List<ProductSection>();
                int _ProdResult = 0;
                string strComboMonthlyPayout = string.Empty;
                string strProdMonthlyPayout = string.Empty;
                //lblErrorProductDetailBody.Text = lblErrorproddtls.Text = "";
                //gridPremCal_Product.DataSource = null;
                //gridPremCal_Product.DataBind();
                //lblErrorproddtls.Text = string.Empty;
                objChangeObj = (ChangeValue)Session["objLoginObj"];
                Logger.Info(strApplicationno + "STAG 8 :PageName :Uwdecision.aspx.CS // MethodeName :btnProddtlsSave_Click" + System.Environment.NewLine);
                ProdDtls objprodchangevalue = new ProdDtls();
                ProductSection objProductSectionBase = new ProductSection();
                ProductSection objProductSectionCombo = new ProductSection();

                objProductSectionBase.ProductCode = objprodchangevalue._ProdcodeBase = "";//txtProdcode.Text;
                objProductSectionBase.PolicyTerm = objprodchangevalue._PolicyTerm = "";//Request.Form[txtPolterm.UniqueID];
                objProductSectionBase.PremiumTerm = objprodchangevalue._Premiumpayingterm = "";//Request.Form[txtPrepayterm.UniqueID];
                objProductSectionBase.SumAssured = objprodchangevalue._Sumassured = "";// Request.Form[txtSumassure.UniqueID];
                objProductSectionBase.PremiumFreq = objprodchangevalue._Paymentfrequency = "";//ddlFrequency.SelectedValue;
                objProductSectionBase.BasePremium = objprodchangevalue._Basepremiumamount = "";// Request.Form[txtBasepremium.UniqueID];
                objProductSectionBase.TotalPremium = objprodchangevalue._TotalPremiumamount = "";// txtTotalpremium.Text;
                objProductSectionBase.MonthlyPayout = strProdMonthlyPayout = objprodchangevalue._MonthlyPayoutBase = "";//Request.Form[txtMonthlyPayoutBase.UniqueID];
                objProductSectionBase.MonthlyPayout = (string.IsNullOrEmpty(objProductSectionBase.MonthlyPayout)) ? string.Empty : objProductSectionBase.MonthlyPayout;
                objProductSectionBase.ProductType = hdnProductType.Value;
                objProductSectionBase.ProdcutName = "";//txtProname.Text;
                objProductSectionBase.PolicyNo = "";//txtBasepolno.Text;
                objProductSectionBase.Section = "ProductDetails";
                Logger.Info(strApplicationno + "MethodeName :ManageProductDetails Object" + System.Environment.NewLine);
                Logger.Info(strApplicationno + "Xml data for Product--base Plan" + objProductSectionBase + System.Environment.NewLine);
                //if (!string.IsNullOrEmpty(txtCombProdCode.Text))
                //{
                //    objProductSectionCombo.ProductCode = objprodchangevalue._ProdcodeCombo = Request.Form[txtCombProdCode.UniqueID];
                //    objProductSectionCombo.PolicyTerm = objprodchangevalue._PolicyTermCombo = Request.Form[txtCombPolTerm.UniqueID];
                //    objProductSectionCombo.PremiumTerm = objprodchangevalue._PremiumpayingtermCombo = Request.Form[txtCombPayTerm.UniqueID];
                //    objProductSectionCombo.SumAssured = objprodchangevalue._SumassuredCombo = Request.Form[txtCombSumAssured.UniqueID];
                //    objProductSectionCombo.PremiumFreq = objprodchangevalue._Paymentfrequency = ddlFrequency.SelectedValue;
                //    objProductSectionCombo.BasePremium = objprodchangevalue._BasepremiumamountCombo = txtCombPremAmount.Text;
                //    objProductSectionCombo.TotalPremium = objprodchangevalue._TotalPremiumamountCombo = txtCombTotalPrem.Text;
                //    objProductSectionCombo.MonthlyPayout = strComboMonthlyPayout = objprodchangevalue._MonthlyPayoutCombo = Request.Form[txtComboMonthlyPayout.UniqueID];
                //    objProductSectionCombo.MonthlyPayout = (string.IsNullOrEmpty(objProductSectionCombo.MonthlyPayout)) ? string.Empty : objProductSectionCombo.MonthlyPayout;
                //    objProductSectionCombo.ProductType = hdnProductType.Value;
                //    objProductSectionCombo.PolicyNo = txtCombopolno.Text;
                //    objProductSectionCombo.ProdcutName = txtCombProdName.Text;
                //    objProductSectionCombo.PremiumFreq = ddlComboFrequency.SelectedValue;
                //    objProductSectionCombo.Section = "ProductDetails";
                //    Logger.Info(strApplicationno + "MethodeName :ManageProductDetails Object" + System.Environment.NewLine);
                //    Logger.Info(strApplicationno + "Xml data for Product--Combo Plan" + objProductSectionCombo + System.Environment.NewLine);
                //}
                objChangeObj.Prod_policydetails = objprodchangevalue;


                #region Premium calculation Service call begin.
                objUWDecision.OnlineApplicationLAServiceDetails_PUSH(strApplicationno, strChannelType, objChangeObj, ref _ds, ref _dsPrevPol, "PREMIUMCAL", ref strLApushErrorCode, ref strLApushStatus, ref strConsentRespons);

                List<RiderInfo> lstRiderInfo = new List<RiderInfo>();
                Commfun.FillRiderInfoFromPremiumCalcDataTable(ref lstRiderInfo, _ds.Tables[0]);

                if (strLApushErrorCode == 0 && _ds.Tables.Count > 0)
                {
                    Logger.Info(strApplicationno + "Remark : Premium calculation success to save data in xml" + System.Environment.NewLine);

                    DataSet _dsPremiumCalculation;
                    //lblErrorProductDetailBody.Text = "Premium calculation succeed";
                    RiderInfo objProd = lstRiderInfo.Where(x => x.RiderType.Equals("BS") && x.ProductCode.Equals("")).SingleOrDefault();
                    if (objProd != null)
                    {
                        Logger.Info(strApplicationno + "Remark : Rider details  save data in xml begin" + System.Environment.NewLine);
                        objProductSectionBase.BasePremium = objprodchangevalue._Basepremiumamount = objProd.InstalmentPremiumAmt.ToString();
                        objProductSectionBase.TotalPremium = objprodchangevalue._TotalPremiumamount = objProd.TotalPremiumAmount.ToString();
                        objProductSectionBase.ServiceTax = objprodchangevalue._ServiceTax = objProd.ServiceTax.ToString();
                        objProductSectionBase.SumAssured = objprodchangevalue._Sumassured = objProd.SumAssured.ToString();
                        //objComm.OnlineProductDetails_Save(strChannelType, strApplicationno, strPolicyNo, txtProdcode.Text, txtSumassure.Text, txtPolterm.Text, txtPrepayterm.Text
                        //    , ddlFrequency.SelectedValue, txtBasepremium.Text, txtTotalpremium.Text, txtServicetax.Text, txtMonthlyPayoutBase.Text, ref _ProdResult);
                        //if (_ProdResult > 0)
                        //{                        
                        //lblErrorproddtls.Text = "Product Details Updated Successfully";
                        //lblErrorProductDetailBody.Text += ",Product Details save succeed";
                        //}
                        //else
                        //{
                        //lblErrorproddtls.Text = "Product Details Not Updated Successfully CLICK here to know more";
                        //lblErrorProductDetailBody.Text += ",Product Details NOT save in database";
                        //}
                        lstProductSection.Add(objProductSectionBase);
                    }
                    RiderInfo objComb = lstRiderInfo.Where(x => x.RiderType.Equals("BS") && x.ProductCode.Equals("")).SingleOrDefault();
                    if (objComb != null)
                    {
                        objProductSectionCombo.BasePremium = objprodchangevalue._BasepremiumamountCombo = objComb.InstalmentPremiumAmt.ToString();
                        objProductSectionCombo.TotalPremium = objprodchangevalue._TotalPremiumamountCombo = objComb.TotalPremiumAmount.ToString();
                        objProductSectionCombo.ServiceTax = objprodchangevalue._ServiceTaxCombo = objComb.ServiceTax.ToString();
                        objProductSectionCombo.SumAssured = objprodchangevalue._SumassuredCombo = objComb.SumAssured.ToString();
                        objProductSectionCombo.MonthlyPayout = strComboMonthlyPayout;
                        lstProductSection.Add(objProductSectionCombo);
                        //objComm.OnlineProductDetails_Save(strChannelType, strApplicationno, strPolicyNo, txtCombProdCode.Text, txtCombSumAssured.Text, txtPolterm.Text, txtPrepayterm.Text
                        //    , ddlFrequency.SelectedValue, txtCombPremAmount.Text, txtCombTotalPrem.Text, txtServicetax.Text, txtComboMonthlyPayout.Text, ref _ProdResult);
                        //if (_ProdResult > 0)
                        //{
                        //    lblErrorProductDetailBody.Text += ",Combo Product Details save succeed";
                        //}
                        //else
                        //{
                        //    lblErrorProductDetailBody.Text += ",Combo Product Details NOT save in database";
                        //}

                    }

                    objChangeObj.Prod_policydetails = objprodchangevalue;
                    chkProductDtls.Checked = false;
                    int _RiderResult = 0;
                    //lblErrorProductDetailBody.Text += ",Product Details save succeed";
                    #endregion Call Contract Modification Service End.
                }

                //Amit 08062017 start.
                else if (strLApushErrorCode == 1)
                {
                    chkProductDtls.Checked = false;
                    //lblErrorproddtls.Text = strLApushStatus;
                    gridPremiumdetails.DataSource = null;
                    gridPremiumdetails.DataBind();
                    divPremiumdetails.Attributes.Add("class", "col-md-12 HideControl");
                }
                //Amit 08062017 end.
                else
                {
                    Logger.Info(strApplicationno + "Remark Premium calculation failed while save data to xml" + System.Environment.NewLine);
                    chkProductDtls.Checked = false;
                    //lblErrorproddtls.Text = "Product Details Not Updated Successfully";
                    //lblErrorProductDetailBody.Text = "Premium calculation failed,Please Contact system admin";
                    divPremiumdetails.Attributes.Add("class", "col-md-12 HideControl");
                }
                /*added by shri to show updated monthly payout*/
                //txtMonthlyPayoutBase.Text = string.IsNullOrEmpty(strProdMonthlyPayout) ? "0" : strProdMonthlyPayout;
                objReplica.LstProductSection = lstProductSection;
                //FillProductDetails(strApplicationno, strChannelType);
                /*end here*/
            }
        }
        catch (Exception ErrorProduct)
        {
            Logger.Info(strApplicationno + "Remark:" + "Exception Bank details" + "STAG 8 :PageName :Uwdecision.aspx.CS // MethodeName :ManageProductDetails" + System.Environment.NewLine);
            Logger.Info(strApplicationno + "Exception Message:" + ErrorProduct.Message + System.Environment.NewLine);
        }
    }
    /*end here*/
    private void ManageProductRiderDetails(bool blnUpdateInLa, ref bool isdataSave, ReplicaXml objReplica, ref string strErrorMessage)
    {
        Logger.Info(strApplicationno + "STEP :3 Save ProductRiderDetails Start" + System.Environment.NewLine);
        try
        {
            Logger.Info(strApplicationno + "Remark:" + "Product-rider-Application details" + "STAG 8 :PageName :Uwdecision.aspx.CS // MethodeName :ManageProductRiderDetails" + System.Environment.NewLine);
            Logger.Info(strApplicationno + "Is Updated in datatabse:" + blnUpdateInLa + System.Environment.NewLine);
            lblRiderDetailsError.Text = lblErrorRiderDetailsBody.Text = string.Empty;
            try
            {
                objCommonObj = (CommonObject)Session["objCommonObj"];
                DataTable dtRiderInfo = new DataTable();
                DefineDataTable(ref dtRiderInfo);
                bool blnIsGreateThanSumAssured = true;
                int intResponse = -1;
                //check if entered amount is greater than sum assured             
                if (blnIsGreateThanSumAssured)
                {
                    DataSet _dsPremiumCalculation = new DataSet();
                    /*commented by shri no need to call premium calculation*/
                    //PremiumCalculation(objReplica, ref isdataSave, ref _dsPremiumCalculation, ref intResponse, ref strResponse);
                    //if (string.IsNullOrEmpty(strResponse))
                    //{
                    /*back date interest*/
                    Logger.Info(strApplicationno + "Remark :ManageProductRiderDetails: Premium calculation success" + System.Environment.NewLine);
                    txtBackDateIntrest.Text = objReplica.ApplicationSection.BACKDATEINTREST;
                    if (objReplica != null && objReplica.LstRiderInfo != null && objReplica.LstRiderInfo.Count > 0)
                    {
                        List<RiderSection> LstRiderSection = new List<RiderSection>();
                        for (int i = 0; i < objReplica.LstRiderInfo.Count; i++)
                        {
                            RiderSection objRiderSection = new RiderSection();
                            RiderInfo objRiderInfo = objReplica.LstRiderInfo[i];

                            //index of old value
                            var index = LstRiderSection.IndexOf(objRiderSection);

                            //fill rider section
                            objRiderSection.Section = "RiderDetails";
                            objRiderSection.RIDERCODE = objRiderInfo.RiderId;
                            objRiderSection.RIDERSUMASSURED = Convert.ToString(objRiderInfo.SumAssured);
                            objRiderSection.RiderTotalPremium = Convert.ToString(objRiderInfo.TotalInstalmentPremium);
                            objRiderSection.SERVICETAX = Convert.ToString(objRiderInfo.ServiceTax);
                            objRiderSection.IsActive = Convert.ToBoolean(objRiderInfo.IsActive);
                            objRiderSection.RIDERNAME = objRiderInfo.RiderName;
                            LstRiderSection.Add(objRiderSection);
                        }
                        objReplica.LstRiderSection = LstRiderSection;
                        Logger.Info(strApplicationno + "MethodeName :Rider Object" + System.Environment.NewLine);
                        Logger.Info(strApplicationno + "MethodeName :Rider Object" + GetXMLFromObject(LstRiderSection) + System.Environment.NewLine);
                        lblErrorRiderDetailsBody.Text = "Rider Updation Success";
                        lblRiderDetailsError.Text = "Rider Updation Success";


                        if (blnUpdateInLa)
                        {

                            Logger.Info(strApplicationno + "Remark:" + "ManageProductRiderDetails" + "Rider Details save in database Begin" + System.Environment.NewLine);
                            /*added by shri to update rider details*/
                            string struserid = objChangeObj.userLoginDetails._UserID;
                            DataTable dtDbRiderInfo = new DataTable();
                            DefineDataTable(ref dtDbRiderInfo);
                            dtDbRiderInfo.Columns.Add("UserId");
                            dtDbRiderInfo.Columns.Add("CurrentDate");
                            dtDbRiderInfo.Columns.Add("ProcessName");
                            for (int i = 0; i < objReplica.LstRiderSection.Count; i++)
                            {
                                RiderSection objRiderSection = LstRiderSection[i];
                                DataRow dr = dtDbRiderInfo.NewRow();

                                //get value from it
                                dr[0] = strApplicationno;
                                dr[1] = objRiderSection.IsActive;
                                dr[2] = objRiderSection.RIDERNAME;
                                dr[3] = objRiderSection.RIDERCODE;
                                dr[4] = objRiderSection.RIDERSUMASSURED;
                                dr[5] = objRiderSection.RiderTotalPremium;
                                dr[6] = objRiderSection.SERVICETAX;
                                dr[7] = objRiderSection.ProductType;
                                dr[8] = objRiderSection.ProductCode;
                                dr[9] = objRiderSection.ProdPoliyTerm;
                                dr[10] = objRiderSection.ProdPremPayingTerm;
                                dr[11] = objRiderSection.RIDERSUMASSURED;
                                dr[12] = struserid;
                                dr[13] = DateTime.Now;
                                dr[14] = "UWSaral";

                                //add data row to datatable
                                dtDbRiderInfo.Rows.Add(dr);
                            }

                            Logger.Info(strApplicationno + "Remark:" + "ManageProductRiderDetails" + "Rider Details save in database Begin" + System.Environment.NewLine);
                            objcomm.ManageRiderInfo(strApplicationno, dtDbRiderInfo, struserid, ref intResponse);
                            if (intResponse > 0)
                            {
                                Logger.Info(strApplicationno + "Remark:" + "ManageProductRiderDetails" + "Rider Details save in database Success" + System.Environment.NewLine);
                                //lblErrorRiderDetailsBody.Text += " Rider Updated Successfuly In Database";
                                //lblRiderDetailsError.Text += " Rider Updated Successfuly In Database";
                            }
                            else
                            {
                                Logger.Info(strApplicationno + "Remark:" + "ManageProductRiderDetails" + "Rider Details Not save in database Success" + System.Environment.NewLine);
                                //lblErrorRiderDetailsBody.Text += " Rider Not Updated In Database ";
                                //lblRiderDetailsError.Text += " Rider Not Updated In Database Click Here To Know More";
                            }
                        }
                    }
                    if (blnUpdateInLa)
                    {
                        /*added by shri to update application details*/
                        Logger.Info(strApplicationno + "Remark:" + "ManageProductRiderDetails" + "Application Details save in database Begin" + System.Environment.NewLine);
                        //check if backdating is done or not if yes then call save details 
                        if (switch_havInsurance.Checked)
                        {
                            objComm.OnlineApplicationDetails_Save(strPolicyNo, strApplicationno, "Yes", Request.Form[txtRcdreq.UniqueID], ddlBkdateReason.SelectedItem.Value
                               , objChangeObj.userLoginDetails._UserName, objChangeObj.userLoginDetails._UserID, objChangeObj.userLoginDetails._userBranch
                               , objChangeObj.userLoginDetails._userBranch, "UWSaralUnderwritting", strApplicationno, objChangeObj.userLoginDetails._UserID
                               , strChannelType, txtBackDateIntrest.Text, ref intResponse);
                        }
                        if (intResponse > 0)
                        {
                            Logger.Info(strApplicationno + "Remark:" + "ManageProductRiderDetails" + "Application Details save in database Success" + System.Environment.NewLine);
                            //lblErrorAppDetailsBody.Text = " Application Details Updated In Database";
                            //lblErrorappdtls.Text = " Application Details Updated In Database";
                        }
                        else
                        {
                            Logger.Info(strApplicationno + "Remark:" + "ManageProductRiderDetails" + "Application Details Not save in database" + System.Environment.NewLine);
                            //lblErrorAppDetailsBody.Text += " Application Details Not Updated In Database Click here to know more ";
                            //lblErrorappdtls.Text += " Application Details Not Updated In Database Click here to know more ";
                        }

                        /*added by shri to update product details*/
                        for (int i = 0; i < objReplica.LstProductSection.Count; i++)
                        {
                            Logger.Info(strApplicationno + "Remark:" + "ManageProductRiderDetails" + "Product Details save in database Begin" + System.Environment.NewLine);
                            ProductSection objProductSection = objReplica.LstProductSection[i];
                            objComm.OnlineProductDetails_Save(strChannelType, strApplicationno, strPolicyNo, objProductSection.ProductCode, objProductSection.SumAssured
                                , objProductSection.PolicyTerm, objProductSection.PremiumTerm, objProductSection.PremiumFreq, objProductSection.BasePremium
                                , objProductSection.TotalPremium, objProductSection.ServiceTax, objProductSection.MonthlyPayout
                                , (ddlApplicationDetailsProposalType.SelectedValue == "0") ? string.Empty : Convert.ToString(ddlApplicationDetailsProposalType.SelectedValue)
                                , txtApplicationDetailsCibil.Text
                                , ref intResponse);

                            if (objProductSection.ProductCode == "E91" || objProductSection.ProductCode == "E92")
                            {
                                objComm.SBFreq_Save(strApplicationno, objProductSection.PayoutFreq, ref intResponse);
                            }
                            if (intResponse > 0)
                            {
                                Logger.Info(strApplicationno + "Remark:" + "ManageProductRiderDetails" + "Product Details save in database Success" + System.Environment.NewLine);
                                //lblErrorproddtls.Text = lblErrorproddtls.Text + " Product Details Updated Successfully In Database";
                                //lblErrorProductDetailBody.Text = lblErrorProductDetailBody.Text + " Product Details Updated Successfully In Database";


                            }
                            else
                            {
                                Logger.Info(strApplicationno + "Remark:" + "ManageProductRiderDetails" + "Product Details not save in database" + System.Environment.NewLine);
                                //lblErrorproddtls.Text = lblErrorproddtls.Text + " Product Details Updated Not In Database Click here to know more ";
                                //lblErrorProductDetailBody.Text = lblErrorProductDetailBody.Text + " Product Details Updated In Database Not Click here to know more ";
                            }

                            //added by suraj for update payout details for product code T36/37/38, E91/92/93/94
                            objcomm.ManagePayoutDetail(strApplicationno, objProductSection.Category, objProductSection.PayoutType, objProductSection.PayoutTerm
                                , objProductSection.LumpsumPer, objProductSection.PayoutFreq, objProductSection.ProductCategory, ref intResponse);
                            if (intResponse > 0)
                            {
                                Logger.Info(strApplicationno + "Remark:" + "ManageProductRiderDetails" + "Payout Details save in database Success" + System.Environment.NewLine);
                            }
                            else
                            {
                                Logger.Info(strApplicationno + "Remark:" + "ManageProductRiderDetails" + "Payout Details Not save in database Success" + System.Environment.NewLine);
                            }
                        }
                    }
                    //}
                    //else
                    //{
                    //    Logger.Info(strApplicationno + "Remark:" + "ManageProductRiderDetails" + "Rider Details not save in database" + System.Environment.NewLine);
                    //    //lblErrorRiderDetailsBody.Text = strResponse;
                    //    //lblRiderDetailsError.Text = "Rider Updation Failed To Know More CLICK Here";
                    //}

                }
                else
                {
                    Logger.Info(strApplicationno + "Remark:" + "ManageProductRiderDetails" + "Rider Sum Assured Cannot Be Greater Than Produce Sum Assured" + System.Environment.NewLine);
                    //lblRiderDetailsError.Text = "Rider Sum Assured Cannot Be Greater Than Produce Sum Assured";
                }
            }

            catch (Exception ex)
            {
                Logger.Info(strApplicationno + "Remark:" + "ManageProductRiderDetails" + "Exception in ManageProductRiderDetails" + System.Environment.NewLine);
                Logger.Info(strApplicationno + "Remark:" + "ManageProductRiderDetails" + ex.Message + System.Environment.NewLine);
                //lblRiderDetailsError.Text = "Rider Updated Successfully CLICK here to know more";
                //lblErrorRiderDetailsBody.Text = ex.Message; ;
            }
        }
        catch (Exception ErrorRider)
        {
            strErrorMessage = "Error While Saving Productrider Details,Please Contact System Admin";
            isdataSave = false;
            Logger.Info(strApplicationno + "Remark:" + "Exception Bank details" + "STAG 8 :PageName :Uwdecision.aspx.CS // MethodeName :ManageProductDetails" + System.Environment.NewLine);
            Logger.Info(strApplicationno + "Exception Message:" + ErrorRider.Message + System.Environment.NewLine);
        }
        Logger.Info(strApplicationno + "STEP :3 Save ProductRiderDetails End" + System.Environment.NewLine);
    }

    private void ManageRequirementDetails(bool blnUpdateInLa, ref bool isdataSave, ReplicaXml objReplica, ref string strErrorMessage)
    {
        Logger.Info(strApplicationno + "STEP :5 Save requirments details Start" + System.Environment.NewLine);
        Logger.Info(strApplicationno + "Remark:" + "Requirment details" + "STAG 8 :PageName :Uwdecision.aspx.CS // MethodeName :ManageRequirementDetails" + System.Environment.NewLine);
        Logger.Info(strApplicationno + "Is Updated in datatabse:" + blnUpdateInLa + System.Environment.NewLine);
        try
        {
            List<RequirmentSection> LstRequirmentSection = new List<RequirmentSection>();
            if (blnUpdateInLa)
            {
                Logger.Info(strApplicationno + "Remark : Save requirment details in database begins" + System.Environment.NewLine);
                Logger.Info("STAG 2 :PageName :Uwdecision.aspx.CS // MethodeName :btnRequirmentDtlsSave_Click");
                string _strfollowupcode = string.Empty;
                string _strfollowupdiscp = string.Empty;
                string _strfollowupcategory = string.Empty;
                string _strfollowupcriteria = string.Empty;
                string _strfollowuplifetype = string.Empty;
                string _strfollowupstatus = string.Empty;
                int strFollowupResult = 0;
                bool _FollowupStatus = false;
                bool _strFolloUPflag = true;
                lblErrorRequirementDetailBody.Text = lblErrorreqdtls.Text = string.Empty;
                // objCommonObj = (CommonObject)Session["objCommonObj"];
                objChangeObj = (ChangeValue)Session["objLoginObj"];
                if (reqcounter == 0)
                {
                    foreach (GridViewRow rowfollowup in gvRequirmentDetails.Rows)
                    {
                        DropDownList ddlAppNoReq = rowfollowup.FindControl("ddlAppNoReq") as DropDownList;//ADDED BY SURAJ FOR COMBI

                        RequirmentSection objRequirmentSection = new RequirmentSection();
                        objRequirmentSection.Section = "RequirmentDetails";
                        DropDownList ddlfollowupcode = rowfollowup.FindControl("ddlfollowupcode") as DropDownList;
                        DropDownList ddlCategory = rowfollowup.FindControl("ddlCategory") as DropDownList;
                        DropDownList ddlCriteria = rowfollowup.FindControl("ddlCriteria") as DropDownList;
                        DropDownList ddlStatus = rowfollowup.FindControl("ddlStatus") as DropDownList;
                        DropDownList ddlLifeType = rowfollowup.FindControl("ddlLifeType") as DropDownList;
                        TextBox lblfollowupDiscp = rowfollowup.FindControl("lblfollowupDiscp") as TextBox;
                        objRequirmentSection.REQ_followUpCode = _strfollowupcode = ddlfollowupcode.SelectedValue;
                        objRequirmentSection.REQ_category = _strfollowupcategory = ddlCategory.SelectedValue;
                        objRequirmentSection.REQ_criteria = _strfollowupcriteria = ddlCriteria.SelectedValue;
                        objRequirmentSection.REQ_lifeType = _strfollowuplifetype = ddlLifeType.SelectedValue;
                        objRequirmentSection.REQ_status = _strfollowupstatus = ddlStatus.SelectedValue;
                        objRequirmentSection.REQ_description = _strfollowupdiscp = lblfollowupDiscp.Text;
                        if (_strfollowupstatus == "O")
                        {
                            _FollowupStatus = true;
                        }
                        /*save to database*/
                        Logger.Info(strApplicationno + "MethodeName :ManageRequirementDetails" + "requirment details save in Db for followup code " + ddlfollowupcode.SelectedValue + System.Environment.NewLine);
                        if (!_strfollowupcode.Equals("0"))
                        {
                            objBuss.FollowupDetails_Save(strChannelType, ddlAppNoReq.SelectedValue, _strfollowupcode, _strfollowupdiscp, _strfollowupcategory, _strfollowupcriteria, ""
                                            , objChangeObj.userLoginDetails._UserID, _strfollowupstatus, _strfollowupcategory, _strfollowuplifetype, objChangeObj.userLoginDetails._UserID
                                            , objChangeObj.userLoginDetails._UserName, objChangeObj.userLoginDetails._UserGroup, objChangeObj.userLoginDetails._userBranch
                                            , objChangeObj.userLoginDetails._userBranch, strChannelType, strApplicationno, ref strFollowupResult);
                        }
                        if (strFollowupResult == 0)
                        {
                            _strFolloUPflag = false;
                        }
                        LstRequirmentSection.Add(objRequirmentSection);
                        Logger.Info(strApplicationno + "MethodeName :ManageRequirementDetails Object" + System.Environment.NewLine);
                        Logger.Info(strApplicationno + "MethodeName :ManageRequirementDetails Object" + GetXMLFromObject(objRequirmentSection) + System.Environment.NewLine);
                    }
                    reqcounter++;
                }
                if (_strFolloUPflag)
                {
                    Logger.Info(strApplicationno + "MethodeName :ManageRequirementDetails Object" + System.Environment.NewLine);
                    Logger.Info(strApplicationno + "Remark :requirment details save successfully in database" + System.Environment.NewLine);
                    /*ADDED BY SHRI ON 04 NOV 17 TO PUSH MEDICAL LOADING*/
                    UWSaralDecision.CommFun objCommFun = new UWSaralDecision.CommFun();
                    objCommFun.FetchMedicalRequirement(strApplicationno, ref _ds);
                    if (_ds.Tables.Count > 0 && _ds.Tables[0].Rows.Count > 0)
                    {
                        UWSaralServices.MedicalDataEntryInvoke objMedicalDataEntryInvoke = new UWSaralServices.MedicalDataEntryInvoke();
                        objMedicalDataEntryInvoke.MedicalPushService(strApplicationno, ref strLApushErrorCode, ref strLApushStatus);
                        if (strLApushErrorCode == 0)
                        {
                            int intRet = -1;
                            objCommFun.UpdateMedicalRequirement(strApplicationno, ref intRet);
                        }
                    }
                    /*END HERE*/
                    //lblErrorRequirementDetailBody.Text = "Requirment details Updated in DataBase";
                    //lblErrorreqdtls.Text = "Requirment details Updated CLICK to know more";
                }
                else
                {
                    chkReqDtls.Checked = false;
                    Logger.Info(strApplicationno + "Remark :requirment details Not save successfully" + System.Environment.NewLine);
                    //lblErrorRequirementDetailBody.Text = "Requirment details Not Updated in DataBase";
                    //lblErrorreqdtls.Text = "Requirment details Not Updated CLICK to know more";
                }
                //Added by Suraj on 19 APRIL 2018 for medical reason dropdown
                int resp = 0;
                if (ddlRequirementMedicalReason.SelectedValue == "0")
                {
                    //lblErrorreqdtls.Text = "Please select Medical Reason!!";
                    //ShowPopupMessage("Please select Medical Reason!!");
                }
                else
                {
                    lblErrorreqdtls.Text = "";
                    //objBuss.Save_MedicalReport_Reason(strApplicationno, Convert.ToInt32(ddlRequirementMedicalReason.SelectedValue), objChangeObj.userLoginDetails._UserID, ref resp);
                    objBuss.Save_MedicalReport_Reason(1, strApplicationno, Convert.ToInt32(ddlRequirementMedicalReason.SelectedValue), objChangeObj.userLoginDetails._UserID, ref resp);
                }
            }
            else
            {
                Logger.Info(strApplicationno + "Remark : Save requirment details in Xml begins" + System.Environment.NewLine);
                Logger.Info("STAG 2 :PageName :Uwdecision.aspx.CS // MethodeName :ManageRequirementDetails");
                string _strfollowupcode = string.Empty;
                string _strfollowupdiscp = string.Empty;
                string _strfollowupcategory = string.Empty;
                string _strfollowupcriteria = string.Empty;
                string _strfollowuplifetype = string.Empty;
                string _strfollowupstatus = string.Empty;
                string _strRaisedDate = string.Empty;
                string _strRaisedBy = string.Empty;
                string _strClosedDate = string.Empty;
                string _strClosedBy = string.Empty;
                int strFollowupResult = 0;
                bool _FollowupStatus = false;
                bool _strFolloUPflag = true;
                lblErrorRequirementDetailBody.Text = lblErrorreqdtls.Text = string.Empty;
                // objCommonObj = (CommonObject)Session["objCommonObj"];
                objChangeObj = (ChangeValue)Session["objLoginObj"];
                foreach (GridViewRow rowfollowup in gvRequirmentDetails.Rows)
                {
                    RequirmentSection objRequirmentSection = new RequirmentSection();
                    objRequirmentSection.Section = "RequirmentDetails";
                    DropDownList ddlAppNoReq = rowfollowup.FindControl("ddlAppNoReq") as DropDownList;//ADDED BY SURAJ FOR COMBI
                    DropDownList ddlfollowupcode = rowfollowup.FindControl("ddlfollowupcode") as DropDownList;
                    DropDownList ddlCategory = rowfollowup.FindControl("ddlCategory") as DropDownList;
                    DropDownList ddlCriteria = rowfollowup.FindControl("ddlCriteria") as DropDownList;
                    DropDownList ddlStatus = rowfollowup.FindControl("ddlStatus") as DropDownList;
                    DropDownList ddlLifeType = rowfollowup.FindControl("ddlLifeType") as DropDownList;
                    TextBox lblfollowupDiscp = rowfollowup.FindControl("lblfollowupDiscp") as TextBox;
                    Label lblRaiseddate = rowfollowup.FindControl("lblRaiseddate") as Label;
                    //Label lblRaisedby = rowfollowup.FindControl("lblRaisedby") as Label;
                    Label lblClosedDate = rowfollowup.FindControl("lblClosedDate") as Label;
                    //Label lblClosedBy = rowfollowup.FindControl("lblClosedBy") as Label;

                    objRequirmentSection.REQ_followUpCode = _strfollowupcode = ddlfollowupcode.SelectedValue;
                    objRequirmentSection.REQ_category = _strfollowupcategory = ddlCategory.SelectedValue;
                    objRequirmentSection.REQ_criteria = _strfollowupcriteria = ddlCriteria.SelectedValue;
                    objRequirmentSection.REQ_lifeType = _strfollowuplifetype = ddlLifeType.SelectedValue;
                    objRequirmentSection.REQ_status = _strfollowupstatus = ddlStatus.SelectedValue;
                    objRequirmentSection.REQ_description = _strfollowupdiscp = lblfollowupDiscp.Text;

                    objRequirmentSection.REQ_RaisedDate = _strRaisedDate = lblRaiseddate.Text;
                    //objRequirmentSection.REQ_RaisedBy = _strRaisedBy = lblRaisedby.Text;
                    objRequirmentSection.REQ_ClosedDate = _strClosedDate = lblClosedDate.Text;
                    //objRequirmentSection.REQ_ClosedBy = _strClosedBy = lblClosedBy.Text;

                    if (_strfollowupstatus == "O")
                    {
                        _FollowupStatus = true;
                    }

                    //objBuss.FollowupDetails_Save(strChannelType, strApplicationno, _strfollowupcode, _strfollowupdiscp, _strfollowupcategory, _strfollowupcriteria, "", objChangeObj.userLoginDetails._UserID, _strfollowupstatus,
                    //    _strfollowupcategory, _strfollowuplifetype, objChangeObj.userLoginDetails._UserID, objChangeObj.userLoginDetails._UserName, objChangeObj.userLoginDetails._UserGroup, objChangeObj.userLoginDetails._userBranch, objChangeObj.userLoginDetails._userBranch, strChannelType, strApplicationno, ref strFollowupResult);
                    //if (strFollowupResult == )
                    //{
                    //    _strFolloUPflag = false;
                    //}
                    LstRequirmentSection.Add(objRequirmentSection);
                    Logger.Info(strApplicationno + "MethodeName :ManageRequirementDetails Object" + System.Environment.NewLine);
                    Logger.Info(strApplicationno + "MethodeName :ManageRequirementDetails Object" + GetXMLFromObject(objRequirmentSection) + System.Environment.NewLine);
                }

                if (_strFolloUPflag)
                {
                    /*ADDED BY SHRI ON 04 NOV 17 TO PUSH MEDICAL LOADING*/
                    Logger.Info(strApplicationno + "MethodeName :ManageRequirementDetails  remark : ths part is not required to save data in xml" + System.Environment.NewLine);

                    UWSaralDecision.CommFun objCommFun = new UWSaralDecision.CommFun();
                    objCommFun.FetchMedicalRequirement(strApplicationno, ref _ds);
                    if (_ds.Tables.Count > 0 && _ds.Tables[0].Rows.Count > 0)
                    {

                        objCommFun.FetchMedicalRequirement(strApplicationno, ref _ds);
                        //if record exists then call service 
                        if (_ds != null && _ds.Tables.Count > 0 && _ds.Tables[0].Rows.Count > 0)
                        {
                            UWSaralServices.MedicalDataEntryInvoke objMedicalDataEntryInvoke = new UWSaralServices.MedicalDataEntryInvoke();
                            objMedicalDataEntryInvoke.MedicalPushService(strApplicationno, ref strLApushErrorCode, ref strLApushStatus);
                            if (strLApushErrorCode == 0)
                            {
                                int intRet = -1;
                                objCommFun.UpdateMedicalRequirement(strApplicationno, ref intRet);
                            }
                        }
                    }
                    /*END HERE*/
                    //lblErrorRequirementDetailBody.Text = "Requirment details Updated in DataBase";
                    //lblErrorreqdtls.Text = "Requirment details Updated CLICK to know more";
                }
                else
                {
                    chkReqDtls.Checked = false;
                    //lblErrorRequirementDetailBody.Text = "Requirment details Not Updated in DataBase";
                    //lblErrorreqdtls.Text = "Requirment details Not Updated CLICK to know more";
                }
            }
            if (LstRequirmentSection != null)
            {
                objReplica.LstRequirementSection = LstRequirmentSection;
                Logger.Info(strApplicationno + "MethodeName :RequirmentDetails Object" + System.Environment.NewLine);
                Logger.Info(strApplicationno + "MethodeName :RequirmentDetails" + GetXMLFromObject(LstRequirmentSection) + System.Environment.NewLine);
                Logger.Info(strApplicationno + "MethodeName :RequirmentDetails  Remark :Requirment object add to replica xml " + System.Environment.NewLine);
            }
        }
        catch (Exception ErrorRequirments)
        {
            strErrorMessage = "Error While Saving Requirments Details,Please Contact System Admin";
            Logger.Info(strApplicationno + "Remark:" + "Exception Requirments details" + "STAG 8 :PageName :Uwdecision.aspx.CS // MethodeName :ManageProductDetails" + System.Environment.NewLine);
            Logger.Info(strApplicationno + "Exception Message:" + ErrorRequirments.Message + System.Environment.NewLine);
        }
        Logger.Info(strApplicationno + "STEP :5 Save requirments details end" + System.Environment.NewLine);
    }

    private void ManageFundDetails(bool blnUpdateInLa, ref bool isdataSave, ReplicaXml objReplica, ref string strErrorMessage)
    {
        Logger.Info(strApplicationno + "STEP :5 Save Fund details Start" + System.Environment.NewLine);
        Logger.Info(strApplicationno + "Remark:" + "Fund details" + "STAG 8 :PageName :Uwdecision.aspx.CS // MethodeName :ManageFundDetails" + System.Environment.NewLine);
        Logger.Info(strApplicationno + "Is Updated in datatabse:" + blnUpdateInLa + System.Environment.NewLine);
        try
        {
            List<FundSection> LstFundSection = new List<FundSection>();
            if (blnUpdateInLa)
            {
                Logger.Info(strApplicationno + "Remark : Save Fund details in database begins" + System.Environment.NewLine);
                Logger.Info("STAG 2 :PageName :Uwdecision.aspx.CS // MethodeName :ManageFundDetails");
                string _strFundCode = string.Empty;
                string _strFundName = string.Empty;
                string _strFundValue = string.Empty;
                int _FundResult = 0;
                bool _FollowupStatus = false;
                bool _strFundflag = true;
                lblErrorFundDetailBody.Text = lblErrorfunddtls.Text = string.Empty;
                objChangeObj = (ChangeValue)Session["objLoginObj"];
                foreach (GridViewRow rowFund in gvFundDtls.Rows)
                {
                    FundSection objFundSection = new FundSection();
                    objFundSection.Section = "FundDetails";
                    Label lblFundCode = rowFund.FindControl("lblFundvalue") as Label;
                    //Label lblRaisedby = rowfollowup.FindControl("lblRaisedby") as Label;
                    Label lblFundName = rowFund.FindControl("lblFundName") as Label;
                    TextBox lblFundvalue = rowFund.FindControl("txtFundvalue") as TextBox;
                    //Label lblClosedBy = rowfollowup.FindControl("lblClosedBy") as Label;
                    objFundSection.FND_fundCode = _strFundCode = lblFundCode.Text;
                    objFundSection.FND_fundName = _strFundValue = lblFundvalue.Text;
                    objFundSection.FND_fundComposition = _strFundName = lblFundName.Text;

                    objComm.OnlineFundDetails(strChannelType, objCommonObj._AppType, strApplicationno, _strFundCode, _strFundName, _strFundValue, objChangeObj.userLoginDetails._UserID, objChangeObj.userLoginDetails._UserName, objChangeObj.userLoginDetails._UserGroup, objChangeObj.userLoginDetails._userBranch, objChangeObj.userLoginDetails._userBranch, objChangeObj.userLoginDetails._ProcessName, strApplicationno, ref _FundResult);
                    if (_FundResult != -1)
                    {
                        isdataSave = true;
                    }
                    else
                    {
                        isdataSave = false;
                    }
                    LstFundSection.Add(objFundSection);
                    Logger.Info(strApplicationno + "MethodeName :ManageFundDetails Object" + System.Environment.NewLine);
                    Logger.Info(strApplicationno + "MethodeName :ManageFundDetails Object" + GetXMLFromObject(objFundSection) + System.Environment.NewLine);
                }
            }
            else
            {
                Logger.Info(strApplicationno + "Remark : Save Fund details in Xml begins" + System.Environment.NewLine);
                Logger.Info("STAG 2 :PageName :Uwdecision.aspx.CS // MethodeName :ManageFundDetails");
                string _strFundCode = string.Empty;
                string _strFundName = string.Empty;
                string _strFundValue = string.Empty;
                int strFollowupResult = 0;
                bool _FollowupStatus = false;
                bool _strFundflag = true;
                lblErrorFundDetailBody.Text = lblErrorreqdtls.Text = string.Empty;
                // objCommonObj = (CommonObject)Session["objCommonObj"];
                objChangeObj = (ChangeValue)Session["objLoginObj"];
                foreach (GridViewRow rowFund in gvFundDtls.Rows)
                {
                    FundSection objFundSection = new FundSection();
                    objFundSection.Section = "FundDetails";
                    Label lblFundCode = rowFund.FindControl("lblFundvalue") as Label;
                    //Label lblRaisedby = rowfollowup.FindControl("lblRaisedby") as Label;
                    Label lblFundName = rowFund.FindControl("lblFundName") as Label;
                    TextBox lblFundvalue = rowFund.FindControl("txtFundvalue") as TextBox;
                    //Label lblClosedBy = rowfollowup.FindControl("lblClosedBy") as Label;
                    objFundSection.FND_fundCode = lblFundCode.Text;
                    objFundSection.FND_fundName = lblFundName.Text;
                    objFundSection.FND_fundComposition = lblFundvalue.Text;
                    //objBuss.FollowupDetails_Save(strChannelType, strApplicationno, _strfollowupcode, _strfollowupdiscp, _strfollowupcategory, _strfollowupcriteria, "", objChangeObj.userLoginDetails._UserID, _strfollowupstatus,
                    //    _strfollowupcategory, _strfollowuplifetype, objChangeObj.userLoginDetails._UserID, objChangeObj.userLoginDetails._UserName, objChangeObj.userLoginDetails._UserGroup, objChangeObj.userLoginDetails._userBranch, objChangeObj.userLoginDetails._userBranch, strChannelType, strApplicationno, ref strFollowupResult);
                    //if (strFollowupResult == )
                    //{
                    //    _strFolloUPflag = false;
                    //}
                    // objComm.OnlineFundDetails(strChannelType, objCommonObj._AppType, strApplicationno, lblFundvalue.Text, lblFundName.Text, txtFundvalue.Text, objChangeObj.userLoginDetails._UserID, objChangeObj.userLoginDetails._UserName, objChangeObj.userLoginDetails._UserGroup, objChangeObj.userLoginDetails._userBranch, objChangeObj.userLoginDetails._userBranch, objChangeObj.userLoginDetails._ProcessName, strApplicationno, ref _FundResult);
                    LstFundSection.Add(objFundSection);
                    Logger.Info(strApplicationno + "MethodeName :ManageFundDetails Object" + System.Environment.NewLine);
                    Logger.Info(strApplicationno + "MethodeName :ManageFundDetails Object" + GetXMLFromObject(objFundSection) + System.Environment.NewLine);
                }
            }
            if (LstFundSection != null)
            {
                objReplica.LstFundSection = LstFundSection;
                isdataSave = true;
                Logger.Info(strApplicationno + "MethodeName :ManageFundDetails Object" + System.Environment.NewLine);
                Logger.Info(strApplicationno + "MethodeName :ManageFundDetails" + GetXMLFromObject(LstFundSection) + System.Environment.NewLine);
                Logger.Info(strApplicationno + "MethodeName :ManageFundDetails  Remark :Requirment object add to replica xml " + System.Environment.NewLine);
            }
        }

        catch (Exception ErrorFunds)
        {
            strErrorMessage = "Error While Saving Fund Details,Please Contact System Admin";
            isdataSave = false;
            Logger.Info(strApplicationno + "Remark:" + "Exception Fund details" + "STAG 8 :PageName :Uwdecision.aspx.CS // MethodeName :ManageProductDetails" + System.Environment.NewLine);
            Logger.Info(strApplicationno + "Exception Message:" + ErrorFunds.Message + System.Environment.NewLine);
        }
    }

    private void ManageLoadingDetails(bool blnUpdateInLa, ref bool isdataSave, ReplicaXml objReplica, DataSet _dsPremium, bool blnIsValidateRiders, ref string strErrorMessage)
    {
        Logger.Info(strApplicationno + "STEP :6 Save Loading details Start" + System.Environment.NewLine);
        Logger.Info(strApplicationno + "Remark:" + "Bank details" + "STAG 8 :PageName :Uwdecision.aspx.CS // MethodeName :ManageBankDetails" + System.Environment.NewLine);
        Logger.Info(strApplicationno + "Is Updated in datatabse:" + blnUpdateInLa + System.Environment.NewLine);
        try
        {
            lblTotalLoadingPremium.Text = lblLoadingPremium.Text = string.Empty;
            chkLoadingDtls.Checked = false;
            DataTable _dtLoaddata = new DataTable();
            lblErrorloadingdtls.Text = string.Empty;
            int LoadingResult = 0;
            //objCommonObj = (CommonObject)Session["objCommonObj"];
            objChangeObj = (ChangeValue)Session["objLoginObj"];
            // objChangeObj = (ChangeValue)ViewState["LoadingData"];
            Logger.Info(strApplicationno + "STAG 15 :PageName :Uwdecision.aspx.CS // MethodeName :btnLoadingDtlsSave_Click" + System.Environment.NewLine);
            string _strLoadRiderName = string.Empty;
            string _strLoadType = string.Empty;
            string _strLoadDiscp = string.Empty;
            //51.1 Begin of Changes; Bhaumik Patel - [CR-3334]
            //string _strLoadReason1Discp = string.Empty;
            //string _strLoadReason2Discp = string.Empty;
            string _strLoadReason1 = string.Empty;
            string _strLoadReason2 = string.Empty;
            string _strLoadReason3 = string.Empty;
            string _strLoadReason4 = string.Empty;
            //51.1 End of Changes; Bhaumik Patel - [CR-3334]
            string _strLoadPercent = string.Empty;
            string _strRateAdjust = string.Empty;
            string _strFlatmortality = string.Empty;
            string _strLetterPrint = string.Empty;
            string _strRiderCode = string.Empty;
            string _strLoadCode = string.Empty;
            string _strReason1code = string.Empty;
            string _strReason2code = string.Empty;
            int strTotalLoadedPremiumAB = 0;
            string strComponentCode = string.Empty;
            string strComponentRiderType = string.Empty;
            int TotalPremium = 0;
            int ExtraPremAmt = 0;
            int ModalPremiumAmt = 0;
            int MedicalLoadingPremium = 0;
            int NonMedicalLoadingPremium = 0;
            _dtLoaddata = (DataTable)ViewState["LoadingData"];
            int i = 0;
            //pull value from gridview        
            List<LoadingSection> lstLoading = new List<LoadingSection>();
            foreach (GridViewRow objGridViewRow in gvExtLoadDetails.Rows)
            {
                Logger.Info(strApplicationno + "Save data from Existing loading grid begin" + System.Environment.NewLine);
                LoadingSection objLoadingSection = new LoadingSection();
                objLoadingSection.Section = "LoadingDetails";
                //51.1 Begin of Changes; Bhaumik Patel - [CR-3334];
                Label ddlExstingLoadType = (Label)objGridViewRow.FindControl("ddlExstingLoadType");
                Label ddlExstingLoadTypeCode = (Label)objGridViewRow.FindControl("ddlExstingLoadTypeCode");
                //51.1 End of Changes; Bhaumik Patel - [CR-3334];

                //added by suraj for combi product
                Label lblexistAppno = (Label)objGridViewRow.FindControl("lblexistAppno");
                string strsumassrd = string.Empty;
                string strprempayterm = string.Empty;

                foreach (RepeaterItem item in rptproductlist.Items)
                {
                    TextBox txtAppno = (TextBox)item.FindControl("txtAppno");
                    if (txtAppno.Text == lblexistAppno.Text)
                    {
                        TextBox txtSumassure = (TextBox)item.FindControl("txtSumassure");
                        TextBox txtPrepayterm = (TextBox)item.FindControl("txtPrepayterm");
                        strsumassrd = txtSumassure.Text;
                        strprempayterm = txtPrepayterm.Text;
                    }
                }
                //END

                //51.1 Begin of Changes; Bhaumik Patel - [CR-3334]
               // Label ddlExstingLoadType = (Label)objGridViewRow.FindControl("ddlExstingLoadType");

                Label lblRiderName = (Label)objGridViewRow.FindControl("lblRiderName");

                Label lblExistingLoadRsn1 = (Label)objGridViewRow.FindControl("lblExistingLoadRsn1");
                Label lblExistingLoadRsn1Code = (Label)objGridViewRow.FindControl("lblExistingLoadRsn1Code");
                Label lblExistingLoadRsn2 = (Label)objGridViewRow.FindControl("lblExistingLoadRsn2");
                Label lblExistingLoadRsn2Code = (Label)objGridViewRow.FindControl("lblExistingLoadRsn2Code");
                Label lblExistingLoadRsn3 = (Label)objGridViewRow.FindControl("lblExistingLoadRsn3");
                Label lblExistingLoadRsn4 = (Label)objGridViewRow.FindControl("lblExistingLoadRsn4");
                
                Label lblExistingLoadPer = (Label)objGridViewRow.FindControl("lblExistingLoadPer");
                Label lblExistingRateAdjust = (Label)objGridViewRow.FindControl("lblExistingRateAdjust");
                // DropDownList ddlExistingLoadFlatMort = (DropDownList)objGridViewRow.FindControl("ddlExistingLoadFlatMort");
                Label ddlExistingLoadFlatMort = (Label)objGridViewRow.FindControl("ddlExistingLoadFlatMort");
                Label ddlExistingLoadFlatMortCode = (Label)objGridViewRow.FindControl("ddlExistingLoadFlatMortCode");
                //51.1 Begin of Changes; Bhaumik Patel - [CR-3334];
                DropDownList LetterPrint = (DropDownList)objGridViewRow.FindControl("LetterPrint");


                //objLoadingSection.ApplicationNo = strApplicationno;
                objLoadingSection.ApplicationNo = lblexistAppno.Text;//added by suraj for combi product
                objLoadingSection.RiderName = lblRiderName.Text;
                objLoadingSection.LoadingType = ddlExstingLoadTypeCode.Text;
                objLoadingSection.LoadingDiscp = ddlExstingLoadType.Text;
                //51.1 Begin of Changes; Bhaumik Patel - [CR-3334]
                objLoadingSection.LoadReasoncode1 = lblExistingLoadRsn1Code.Text;
                objLoadingSection.LoadReasonCode2 = lblExistingLoadRsn2Code.Text;
                //51.1 Begin of Changes; Bhaumik Patel - [CR-3334]
                objLoadingSection.RateAdjustment = lblExistingRateAdjust.Text;
                objLoadingSection.FlatMortality = ddlExistingLoadFlatMortCode.Text;
                objLoadingSection.IsLetterPrint = LetterPrint.SelectedValue;
                objLoadingSection.RiderCode = lblRiderName.Text;
                //51.1 Begin of Changes; Bhaumik Patel - [CR-3334]
                objLoadingSection.LaodingCode = ddlExstingLoadTypeCode.Text;
                //51.1 End of Changes; Bhaumik Patel - [CR-3334]
                objLoadingSection.Loading = lblExistingLoadPer.Text;
                //_strReason1code = Convert.ToString(ddlExistingLoadRsn1.SelectedItem);
                //_strReason2code = Convert.ToString(ddlExistingLoadRsn2.SelectedItem);
                //_strLoadReason1Discp = Convert.ToString(ddlExistingLoadRsn1.SelectedItem);
                //_strLoadReason2Discp = Convert.ToString(ddlExistingLoadRsn2.SelectedItem);

                if (blnUpdateInLa)
                {
                    //objComm.OnlineLoadingDetails_Save(objCommonObj._AppType, strApplicationno, objLoadingSection.LoadingType, 
                    //_strLoadDiscp,objLoadingSection.LoadReasoncode1 , objLoadingSection.LoadReasonCode2, "", txtSumassure.Text, objLoadingSection.Loading,objLoadingSection.RateAdjustment, objLoadingSection.FlatMortality, txtPrepayterm.Text, string.Empty, objLoadingSection.RiderName, objChangeObj.userLoginDetails._UserID, objChangeObj.userLoginDetails._UserName, objChangeObj.userLoginDetails._UserGroup, objChangeObj.userLoginDetails._userBranch, objChangeObj.userLoginDetails._userBranch, objChangeObj.userLoginDetails._ProcessName, strApplicationno, ref LoadingResult);
                    Logger.Info(strApplicationno + "Remark : Save data to database begin" + System.Environment.NewLine);
                    objComm.OnlineLoadingDetails_Save(objCommonObj._AppType, objLoadingSection.ApplicationNo, objLoadingSection.LoadingType,
                       objLoadingSection.LoadingDiscp, objLoadingSection.LoadReasoncode1, objLoadingSection.LoadReasonCode2, "", strsumassrd, objLoadingSection.Loading,
                       objLoadingSection.RateAdjustment, objLoadingSection.FlatMortality, strprempayterm, string.Empty, objLoadingSection.RiderName,
                       objChangeObj.userLoginDetails._UserID, objChangeObj.userLoginDetails._UserName, objChangeObj.userLoginDetails._UserGroup,
                       objChangeObj.userLoginDetails._userBranch, objChangeObj.userLoginDetails._userBranch, objChangeObj.userLoginDetails._ProcessName, strApplicationno,"",
                       ref LoadingResult);

                    if (_dsPremium != null)
                    {
                        if (_dsPremium.Tables[0].Rows.Count > 0)
                        {
                            for (int j = 0; j < _dsPremium.Tables[0].Rows.Count; j++)
                            {

                                //ModalPremiumAmt InstalmentPremiumAmt
                                //ExtraPremiumAmt ExtraPremiumAmt
                                //SeriveTax SeriveTax
                                // MedicalLoadingPremium MedicalLoadingPremium
                                //MedicalLoadingRate notin datatable
                                //NonMedicalLoadingPremium NonMedicalLoadingPremium
                                //NonMedicalLoadingRate notindatatable
                                /* TotalPremium = Convert.ToInt32(_dsPremium.Tables[0].Rows[i]["TotalInstalmentPremium"].ToString());
                                 ExtraPremAmt = Convert.ToInt32(_dsPremium.Tables[0].Rows[i]["ExtraPremiumAmt"].ToString());
                                 ModalPremiumAmt = Convert.ToInt32(_dsPremium.Tables[0].Rows[i]["ModalPremiumAmt"].ToString());
                                 MedicalLoadingPremium = Convert.ToInt32(_dsPremium.Tables[0].Rows[i]["MedicalLoadingPremium"].ToString());
                                 NonMedicalLoadingPremium = Convert.ToInt32(_dsPremium.Tables[0].Rows[i]["NonMedicalLoadingPremium"].ToString());
                                 ServiceTax = Convert.ToInt32(_dsPremium.Tables[0].Rows[i]["ServiceTax"].ToString());
                                 strComponentCode = _dsPremium.Tables[0].Rows[i]["RiderInfo"].ToString();
                                 strComponentRiderType = _dsPremium.Tables[0].Rows[i]["RiderType"].ToString();*/


                                //  LoadedPremiumA = Convert.ToInt32(_dsPremium.Tables[0].Rows[0]["LoadedPremiumA"].ToString().Replace(".00", ""));
                                //  TotalPremiumB = Convert.ToInt32(_dsPremium.Tables[0].Rows[0]["TotalPremiumB"].ToString().Replace(".00", ""));
                                //  LoadedPremiumB = Convert.ToInt32(_dsPremium.Tables[0].Rows[0]["LoadedPremiumB"].ToString().Replace(".00", ""));

                                //if (strChannelType.ToUpper() == "ONLINE")
                                //{
                                //    objComm.OnlinepremiumLoadingDetails_Save(strApplicationno, LoadedPremiumAB, _strLoadDiscp, _strLoadCode, _strReason1code, "", _strLoadDiscp, LoadedPremiumA, LoadedPremiumB, TotalPremiumA, TotalPremiumB, "", ref strLApushErrorCode);
                                //}
                                int BackdatedInt = Convert.ToInt32(Convert.ToString(Math.Round(Convert.ToDecimal(_dsPremium.Tables[0].Rows[j]["BackdatedInt"].ToString()), MidpointRounding.AwayFromZero)));
                                string ComponentCd = _dsPremium.Tables[0].Rows[j]["ComponentCd"].ToString();
                                int EduCess = Convert.ToInt32(Convert.ToString(Math.Round(Convert.ToDecimal(_dsPremium.Tables[0].Rows[j]["EduCess"].ToString()), MidpointRounding.AwayFromZero)));
                                int ExtraPremiumAmt = Convert.ToInt32(Convert.ToString(Math.Round(Convert.ToDecimal(_dsPremium.Tables[0].Rows[j]["ExtraPremiumAmt"].ToString()), MidpointRounding.AwayFromZero)));
                                int InstalmentPremiumAmt = Convert.ToInt32(Convert.ToString(Math.Round(Convert.ToDecimal(_dsPremium.Tables[0].Rows[j]["InstalmentPremiumAmt"].ToString()), MidpointRounding.AwayFromZero)));
                                string LifeType = _dsPremium.Tables[0].Rows[j]["LifeType"].ToString();
                                MedicalLoadingPremium = Convert.ToInt32(Convert.ToString(Math.Round(Convert.ToDecimal(_dsPremium.Tables[0].Rows[j]["MedicalLoadingPremium"].ToString()), MidpointRounding.AwayFromZero)));
                                //MedicalLoadingPremium = Convert.ToInt32(_dsPremium.Tables[0].Rows[i]["MedicalLoadingPremium"].ToString());
                                int MedicalLoadingRate = Convert.ToInt32(Convert.ToString(Math.Round(Convert.ToDecimal(_dsPremium.Tables[0].Rows[j]["MedicalLoadingRate"].ToString()), MidpointRounding.AwayFromZero)));
                                ModalPremiumAmt = Convert.ToInt32(Convert.ToString(Math.Round(Convert.ToDecimal(_dsPremium.Tables[0].Rows[j]["ModalPremiumAmt"].ToString()), MidpointRounding.AwayFromZero)));
                                NonMedicalLoadingPremium = Convert.ToInt32(Convert.ToString(Math.Round(Convert.ToDecimal(_dsPremium.Tables[0].Rows[j]["NonMedicalLoadingPremium"].ToString()), MidpointRounding.AwayFromZero)));
                                int NonMedicalLoadingRate = Convert.ToInt32(Convert.ToString(Math.Round(Convert.ToDecimal(_dsPremium.Tables[0].Rows[j]["NonMedicalLoadingRate"].ToString()), MidpointRounding.AwayFromZero)));
                                string RiderCtg = _dsPremium.Tables[0].Rows[j]["RiderCtg"].ToString();
                                int RiderPPT = Convert.ToInt32(_dsPremium.Tables[0].Rows[j]["RiderPPT"].ToString());
                                int RiderPT = Convert.ToInt32(_dsPremium.Tables[0].Rows[j]["RiderPT"].ToString());
                                int LoadingSeriveTax = Convert.ToInt32(Convert.ToString(Math.Round(Convert.ToDecimal(_dsPremium.Tables[0].Rows[j]["SeriveTax"].ToString()), MidpointRounding.AwayFromZero)));
                                long SumAssured = Convert.ToInt64(Convert.ToString(Math.Round(Convert.ToDecimal(_dsPremium.Tables[0].Rows[j]["SumAssured"].ToString()), MidpointRounding.AwayFromZero)));
                                long SumAssuredAcrossPlans = Convert.ToInt64(_dsPremium.Tables[0].Rows[j]["SumAssuredAcrossPlans"].ToString());
                                long TotalInstalmentPremium = Convert.ToInt64(Convert.ToString(Math.Round(Convert.ToDecimal(_dsPremium.Tables[0].Rows[j]["TotalInstalmentPremium"].ToString()), MidpointRounding.AwayFromZero)));
                                long TotalPremiumAmount = Convert.ToInt64(Convert.ToString(Math.Round(Convert.ToDecimal(_dsPremium.Tables[0].Rows[j]["TotalPremiumAmount"].ToString()), MidpointRounding.AwayFromZero)));
                                //if (strChannelType.ToUpper() == "OFFLINE")
                                //{
                                //objComm.OnlinePremiumExtraLoadingdetails_Save(0, objLoadingSection.ApplicationNo, txtPolno.Text, strComponentCode, "", "", strComponentRiderType, 0, Convert.ToDecimal(TotalPremium), ddlLoadRsn2.SelectedItem.Text, 0, Convert.ToDecimal(ExtraPremAmt), Convert.ToDecimal(ServiceTax), 0, Convert.ToDecimal(ExtraPremAmt), 0, 0, 0, 0, 0, 0, 0, ref strLApushErrorCode);
                                objComm.OnlinePremiumExtraLoadingdetails_Save(0, objLoadingSection.ApplicationNo, txtPolno.Text, ComponentCd, RiderPPT, RiderPT, RiderCtg, BackdatedInt, TotalInstalmentPremium, ddlLoadRsn1.SelectedValue, ModalPremiumAmt, ExtraPremiumAmt, LoadingSeriveTax, EduCess, 0, SumAssured, SumAssuredAcrossPlans, MedicalLoadingPremium, MedicalLoadingRate, NonMedicalLoadingPremium, 0, NonMedicalLoadingRate, ref strLApushErrorCode);
                                //}
                            }
                        }
                    }

                    if (LoadingResult > 0)
                    {
                        Logger.Info(strApplicationno + "Remark : Save loading data to database Success" + System.Environment.NewLine);
                        //lblErrorloadingdtls.Text += " Loading Details Save Successfully In DataBase";
                        //lblErrorLoadingDetailBody.Text += " Loading Details Save Successfully In DataBase";
                    }
                    else
                    {
                        Logger.Info(strApplicationno + "Remark : Save loading data to database Failed" + System.Environment.NewLine);
                        //lblErrorloadingdtls.Text += " Loading Details Not Save Successfully In DataBase Click Here To Know More";
                        //lblErrorLoadingDetailBody.Text += " Loading Details Not Save Successfully In DataBase";
                    }
                }
                lstLoading.Add(objLoadingSection);
                Logger.Info(strApplicationno + "MethodeName :ManageLoadingDetails Object" + System.Environment.NewLine);
                Logger.Info(strApplicationno + "MethodeName :ManageLoadingDetails Object" + GetXMLFromObject(objLoadingSection) + System.Environment.NewLine);
            }

            //pull value from view state
            if (_dtLoaddata != null && _dtLoaddata.Rows.Count > 0)
            {
                Logger.Info(strApplicationno + "Save data from Selecting loading  begin" + System.Environment.NewLine);
                for (i = 0; i < _dtLoaddata.Rows.Count; i++)
                {
                    LoadingSection objLoadingSection = new LoadingSection();
                    objLoadingSection.Section = "LoadingDetails";
                    //objLoadingSection.ApplicationNo = strApplicationno;
                    //ADDED BY SURAJ FOR COMBI
                    objLoadingSection.ApplicationNo = _dtLoaddata.Rows[i]["ddlAppNo"].ToString();
                    string strsumassrd = string.Empty;
                    string strprempayterm = string.Empty;

                    foreach (RepeaterItem item in rptproductlist.Items)
                    {
                        TextBox txtAppno = (TextBox)item.FindControl("txtAppno");
                        if (txtAppno.Text == objLoadingSection.ApplicationNo)
                        {
                            TextBox txtSumassure = (TextBox)item.FindControl("txtSumassure");
                            TextBox txtPrepayterm = (TextBox)item.FindControl("txtPrepayterm");
                            strsumassrd = txtSumassure.Text;
                            strprempayterm = txtPrepayterm.Text;
                        }
                    }
                    //END
                    objLoadingSection.RiderName = _strLoadRiderName = _dtLoaddata.Rows[i]["RiderName"].ToString();
                    objLoadingSection.LoadingType = _strLoadType = _dtLoaddata.Rows[i]["ddlLoadType"].ToString();
                    objLoadingSection.LoadingDiscp = _strLoadDiscp = _dtLoaddata.Rows[i]["LoadingDiscp"].ToString();
                   
                    //51.1 Begin of Changes; Bhaumik Patel - [CR-3334]

                    //objLoadingSection.LoadReasoncode1 = _strLoadReason1 = _dtLoaddata.Rows[i]["ddlLoadRsn1Code"].ToString();
                    //objLoadingSection.LoadReasonCode2 = _strLoadReason2 = _dtLoaddata.Rows[i]["ddlLoadRsn2Code"].ToString();
                    objLoadingSection.Reason1 = _strLoadReason1 = _dtLoaddata.Rows[i]["Loadrsn1"].ToString();
                    objLoadingSection.Reason2 = _strLoadReason2 = _dtLoaddata.Rows[i]["Loadrsn2"].ToString();
                    objLoadingSection.Reason3 = _strLoadReason3 = _dtLoaddata.Rows[i]["Loadrsn3"].ToString();
                    objLoadingSection.Reason4 = _strLoadReason4 = _dtLoaddata.Rows[i]["Loadrsn4"].ToString();
                    //51.1 Begin of Changes; Bhaumik Patel - [CR-3334]

                    objLoadingSection.RateAdjustment = _strRateAdjust = _dtLoaddata.Rows[i]["txtRateAdjust"].ToString();
                    objLoadingSection.FlatMortality = _strFlatmortality = (_dtLoaddata.Rows[i]["ddlLoadFlatMortality"].ToString() == "0") ? "" : _dtLoaddata.Rows[i]["ddlLoadFlatMortality"].ToString();
                    objLoadingSection.IsLetterPrint = _strLetterPrint = _dtLoaddata.Rows[i]["LetterPrint"].ToString();
                    objLoadingSection.RiderCode = _strRiderCode = _dtLoaddata.Rows[i]["RiderCode"].ToString();
                    objLoadingSection.LaodingCode = _strLoadCode = _dtLoaddata.Rows[i]["ddlLoadCode"].ToString();
                    objLoadingSection.Loading = _strLoadPercent = _dtLoaddata.Rows[i]["txtLoadPer"].ToString();
                    //51.1 Begin of Changes; Bhaumik Patel - [CR-3334]
                    //_strReason1code = _dtLoaddata.Rows[i]["ddlLoadRsn1Code"].ToString();
                    //_strReason2code = _dtLoaddata.Rows[i]["ddlLoadRsn2Code"].ToString();
                    //_strLoadReason1Discp = _dtLoaddata.Rows[i]["Reason1Discp"].ToString();
                    //_strLoadReason2Discp = _dtLoaddata.Rows[i]["Reason2Discp"].ToString();
                    //51.1 End of Changes; Bhaumik Patel - [CR-3334]
                    if (blnUpdateInLa)
                    {
                        Logger.Info(strApplicationno + "Save View state Loading data from" + System.Environment.NewLine);
                        //51.1 Begin of Changes; Bhaumik Patel - [CR-3334]
                        objComm.OnlineLoadingDetails_Save(objCommonObj._AppType, objLoadingSection.ApplicationNo, _strLoadCode, _strLoadDiscp, _strLoadReason1, _strLoadReason2, _strLoadReason3,
                            strsumassrd, txtLoadPer.Text, _strRateAdjust, _strFlatmortality, strprempayterm, _strLetterPrint, _strLoadRiderName,
                            objChangeObj.userLoginDetails._UserID, objChangeObj.userLoginDetails._UserName, objChangeObj.userLoginDetails._UserGroup,
                            objChangeObj.userLoginDetails._userBranch, objChangeObj.userLoginDetails._userBranch, objChangeObj.userLoginDetails._ProcessName,
                            strApplicationno, _strLoadReason4,ref LoadingResult);
                        //51.1 End of Changes; Bhaumik Patel - [CR-3334]
                        /*extra loading*/
                        if (_dsPremium != null)
                        {
                            if (_dsPremium.Tables[0].Rows.Count > 0)
                            {
                                for (int j = 0; j < _dsPremium.Tables[0].Rows.Count; j++)
                                {

                                    //ModalPremiumAmt InstalmentPremiumAmt
                                    //ExtraPremiumAmt ExtraPremiumAmt
                                    //SeriveTax SeriveTax
                                    // MedicalLoadingPremium MedicalLoadingPremium
                                    //MedicalLoadingRate notin datatable
                                    //NonMedicalLoadingPremium NonMedicalLoadingPremium
                                    //NonMedicalLoadingRate notindatatable
                                    /* TotalPremium = Convert.ToInt32(_dsPremium.Tables[0].Rows[i]["TotalInstalmentPremium"].ToString());
                                     ExtraPremAmt = Convert.ToInt32(_dsPremium.Tables[0].Rows[i]["ExtraPremiumAmt"].ToString());
                                     ModalPremiumAmt = Convert.ToInt32(_dsPremium.Tables[0].Rows[i]["ModalPremiumAmt"].ToString());
                                     MedicalLoadingPremium = Convert.ToInt32(_dsPremium.Tables[0].Rows[i]["MedicalLoadingPremium"].ToString());
                                     NonMedicalLoadingPremium = Convert.ToInt32(_dsPremium.Tables[0].Rows[i]["NonMedicalLoadingPremium"].ToString());
                                     ServiceTax = Convert.ToInt32(_dsPremium.Tables[0].Rows[i]["ServiceTax"].ToString());
                                     strComponentCode = _dsPremium.Tables[0].Rows[i]["RiderInfo"].ToString();
                                     strComponentRiderType = _dsPremium.Tables[0].Rows[i]["RiderType"].ToString();*/


                                    //  LoadedPremiumA = Convert.ToInt32(_dsPremium.Tables[0].Rows[0]["LoadedPremiumA"].ToString().Replace(".00", ""));
                                    //  TotalPremiumB = Convert.ToInt32(_dsPremium.Tables[0].Rows[0]["TotalPremiumB"].ToString().Replace(".00", ""));
                                    //  LoadedPremiumB = Convert.ToInt32(_dsPremium.Tables[0].Rows[0]["LoadedPremiumB"].ToString().Replace(".00", ""));

                                    //if (strChannelType.ToUpper() == "ONLINE")
                                    //{
                                    //    objComm.OnlinepremiumLoadingDetails_Save(strApplicationno, LoadedPremiumAB, _strLoadDiscp, _strLoadCode, _strReason1code, "", _strLoadDiscp, LoadedPremiumA, LoadedPremiumB, TotalPremiumA, TotalPremiumB, "", ref strLApushErrorCode);
                                    //}
                                    int BackdatedInt = Convert.ToInt32(Convert.ToString(Math.Round(Convert.ToDecimal(_dsPremium.Tables[0].Rows[j]["BackdatedInt"].ToString()), MidpointRounding.AwayFromZero)));
                                    string ComponentCd = _dsPremium.Tables[0].Rows[j]["ComponentCd"].ToString();
                                    int EduCess = Convert.ToInt32(Convert.ToString(Math.Round(Convert.ToDecimal(_dsPremium.Tables[0].Rows[j]["EduCess"].ToString()), MidpointRounding.AwayFromZero)));
                                    int ExtraPremiumAmt = Convert.ToInt32(Convert.ToString(Math.Round(Convert.ToDecimal(_dsPremium.Tables[0].Rows[j]["ExtraPremiumAmt"].ToString()), MidpointRounding.AwayFromZero)));
                                    int InstalmentPremiumAmt = Convert.ToInt32(Convert.ToString(Math.Round(Convert.ToDecimal(_dsPremium.Tables[0].Rows[j]["InstalmentPremiumAmt"].ToString()), MidpointRounding.AwayFromZero)));
                                    string LifeType = _dsPremium.Tables[0].Rows[j]["LifeType"].ToString();
                                    MedicalLoadingPremium = Convert.ToInt32(Convert.ToString(Math.Round(Convert.ToDecimal(_dsPremium.Tables[0].Rows[j]["MedicalLoadingPremium"].ToString()), MidpointRounding.AwayFromZero)));
                                    //MedicalLoadingPremium = Convert.ToInt32(_dsPremium.Tables[0].Rows[i]["MedicalLoadingPremium"].ToString());
                                    int MedicalLoadingRate = Convert.ToInt32(Convert.ToString(Math.Round(Convert.ToDecimal(_dsPremium.Tables[0].Rows[j]["MedicalLoadingRate"].ToString()), MidpointRounding.AwayFromZero)));
                                    ModalPremiumAmt = Convert.ToInt32(Convert.ToString(Math.Round(Convert.ToDecimal(_dsPremium.Tables[0].Rows[j]["ModalPremiumAmt"].ToString()), MidpointRounding.AwayFromZero)));
                                    NonMedicalLoadingPremium = Convert.ToInt32(Convert.ToString(Math.Round(Convert.ToDecimal(_dsPremium.Tables[0].Rows[j]["NonMedicalLoadingPremium"].ToString()), MidpointRounding.AwayFromZero)));
                                    int NonMedicalLoadingRate = Convert.ToInt32(Convert.ToString(Math.Round(Convert.ToDecimal(_dsPremium.Tables[0].Rows[j]["NonMedicalLoadingRate"].ToString()), MidpointRounding.AwayFromZero)));
                                    string RiderCtg = _dsPremium.Tables[0].Rows[j]["RiderCtg"].ToString();
                                    int RiderPPT = Convert.ToInt32(_dsPremium.Tables[0].Rows[j]["RiderPPT"].ToString());
                                    int RiderPT = Convert.ToInt32(_dsPremium.Tables[0].Rows[j]["RiderPT"].ToString());
                                    int LoadingSeriveTax = Convert.ToInt32(Convert.ToString(Math.Round(Convert.ToDecimal(_dsPremium.Tables[0].Rows[j]["SeriveTax"].ToString()), MidpointRounding.AwayFromZero)));
                                    long SumAssured = Convert.ToInt64(_dsPremium.Tables[0].Rows[j]["SumAssured"].ToString());
                                    long SumAssuredAcrossPlans = Convert.ToInt64(_dsPremium.Tables[0].Rows[j]["SumAssuredAcrossPlans"].ToString());
                                    long TotalInstalmentPremium = Convert.ToInt64(Convert.ToString(Math.Round(Convert.ToDecimal(_dsPremium.Tables[0].Rows[j]["TotalInstalmentPremium"].ToString()), MidpointRounding.AwayFromZero)));
                                    long TotalPremiumAmount = Convert.ToInt64(Convert.ToString(Math.Round(Convert.ToDecimal(_dsPremium.Tables[0].Rows[j]["TotalPremiumAmount"].ToString()), MidpointRounding.AwayFromZero)));
                                    if (strChannelType.ToUpper() == "OFFLINE")
                                    {
                                        //objComm.OnlinePremiumExtraLoadingdetails_Save(0, objLoadingSection.ApplicationNo, txtPolno.Text, strComponentCode, "", "", strComponentRiderType, 0, Convert.ToDecimal(TotalPremium), ddlLoadRsn2.SelectedItem.Text, 0, Convert.ToDecimal(ExtraPremAmt), Convert.ToDecimal(ServiceTax), 0, Convert.ToDecimal(ExtraPremAmt), 0, 0, 0, 0, 0, 0, 0, ref strLApushErrorCode);
                                        objComm.OnlinePremiumExtraLoadingdetails_Save(0, objLoadingSection.ApplicationNo, txtPolno.Text, ComponentCd, RiderPPT, RiderPT, RiderCtg, BackdatedInt, TotalInstalmentPremium, ddlLoadRsn1.SelectedValue, ModalPremiumAmt, ExtraPremiumAmt, LoadingSeriveTax, EduCess, 0, SumAssured, SumAssuredAcrossPlans, MedicalLoadingPremium, MedicalLoadingRate, NonMedicalLoadingPremium, 0, NonMedicalLoadingRate, ref strLApushErrorCode);
                                    }
                                }
                            }
                        }
                        /*end here*/
                        if (LoadingResult > 0)
                        {
                            Logger.Info(strApplicationno + "Save View state Loading data to database Success" + System.Environment.NewLine);
                            //lblErrorloadingdtls.Text += " Loading Details Save Successfully In DataBase";
                            //lblErrorLoadingDetailBody.Text += " Loading Details Save Successfully In DataBase";
                        }
                        else
                        {
                            Logger.Info(strApplicationno + "Save View state Loading data to database Failed" + System.Environment.NewLine);
                            //lblErrorloadingdtls.Text += " Loading Details Not Save Successfully In DataBase Click Here To Know More";
                            //lblErrorLoadingDetailBody.Text += " Loading Details Not Save Successfully In DataBase";
                        }
                    }
                    lstLoading.Add(objLoadingSection);
                    Logger.Info(strApplicationno + "MethodeName :ManageLoadingDetails Object" + System.Environment.NewLine);
                    Logger.Info(strApplicationno + "MethodeName :ManageLoadingDetails Object" + GetXMLFromObject(objLoadingSection) + System.Environment.NewLine);
                }
                //if (LoadingResult != -1)
                //{
                //FillLoadingDetails(strApplicationno, strChannelType);
                //lblErrorloadingdtls.Text = "Loading details save successfully";
                //}
                //else
                //{
                //    lblErrorloadingdtls.Text = "Loading Details Not save successfully";
                //    btnAddLoadingRow.CssClass = "btn btn-primary";
                //    btnLoadingDtlsSave.CssClass = "btn-primary";
                //}
                //objReplica.LstLoadingSection = lstLoading;
                Logger.Info(strApplicationno + "MethodeName :ManageLoadingDetails Object" + System.Environment.NewLine);
                Logger.Info(strApplicationno + "MethodeName :ManageLoadingDetails Object" + GetXMLFromObject(lstLoading) + System.Environment.NewLine);

            }
            objReplica.LstLoadingSection = lstLoading;
            /*START ID:22*/
            /*HHI loading on both product validation */
            string procode = string.Empty;
            procode = ddlLoadRiderCode.SelectedValue.ToString();
            if (blnIsValidateRiders)
            {
                if (procode.Equals("H05") || procode.Equals("H06") || procode.Equals("H07") || procode.Equals("H08"))
                {
                    objComm.CheckRider(ref _ds, Convert.ToString(txtAppno.Text));
                    if (_ds != null && _ds.Tables.Count > 0 && _ds.Tables[0].Rows.Count > 0 && Convert.ToString(_ds.Tables[0].Rows[0][0]) == "1")
                    {
                        ShowPopupMessage("Add Appropriate Loading On Heart & Health Product");
                        //throw new Exception("UDE-Add Appropriate Loading On Heart & Health Product");
                    }
                }
            }
            //51.1 Begin of Changes; Bhaumik Patel - [CR-3334]
            txtRsn1Desc.Text = "";
            txtRsn2Desc.Text = "";
            txtRsn3Desc.Text = "";
            txtRsn4Desc.Text = "";
            ddlLoadRsn1.Items.Clear();
            //51.1 End of Changes; Bhaumik Patel - [CR-3334]
            /*END ID:22*/
        }
        catch (Exception Error)
        {
            strErrorMessage = "Error While Saving Loading Details,Please Contact System Admin ";
            isdataSave = false;
            Logger.Info(strApplicationno + "Remark:" + "Exception Requirments details" + "STAG 8 :PageName :Uwdecision.aspx.CS // MethodeName :ManageProductDetails" + System.Environment.NewLine);
            Logger.Info(strApplicationno + "Exception Message:" + Error.Message + System.Environment.NewLine);
            if (Error.Message.Contains("UDE-"))
            {
                throw new Exception(Error.Message);
            }
            else
            {
                throw new Exception("Try Again Later");
            }
        }
        Logger.Info(strApplicationno + "STEP :6 Save Loading details end" + System.Environment.NewLine);
    }

    private void ManageApplicatoinStatus(ref bool isdataSave)
    {
        Logger.Info(strApplicationno + "STEP :7 Save Application Status details Start" + System.Environment.NewLine);
        Logger.Info(strApplicationno + "Remark:" + "Application Stataus" + "STAG 8 :PageName :Uwdecision.aspx.CS // MethodeName :ManageApplicatoinStatus" + System.Environment.NewLine);
        try
        {


            if (Session["objLoginObj"] != null)
            {
                objChangeObj = (ChangeValue)Session["objLoginObj"];
                int intRetVal = -1;
                //objcomm.MaintainApplicationLog(strApplicationno, "save", string.Empty, objChangeObj.userLoginDetails._UserID, "", ref intRetVal);
            }
        }
        catch (Exception Error)
        {
            Logger.Info(strApplicationno + "Remark:" + "Exception in Manage Application log details" + "STAG 8 :PageName :Uwdecision.aspx.CS // MethodeName :ManageApplicatoinStatus" + System.Environment.NewLine);
            Logger.Info(strApplicationno + "Exception Message:" + Error.Message + System.Environment.NewLine);
        }
        Logger.Info(strApplicationno + "STEP :7 Save Application Status details End" + System.Environment.NewLine);
    }

    private void ManageMandateDetails(bool blnUpdateInLa, ref bool isdataSave, ReplicaXml objReplica, ref string strErrorMessage)
    {
        Logger.Info(strApplicationno + "STEP :4 Save ProductRiderDetails Start" + System.Environment.NewLine);
        Logger.Info(strApplicationno + "Remark:" + "Mandate details" + "STAG 8 :PageName :Uwdecision.aspx.CS // MethodeName :ManageMandateDetails" + System.Environment.NewLine);
        Logger.Info(strApplicationno + "Is Updated in datatabse:" + blnUpdateInLa + System.Environment.NewLine);
        string strSpace = " ";
        try
        {
            MandateDetails objMandateDetails = new MandateDetails();
            objMandateDetails.ApplicationNo = strApplicationno;
            objMandateDetails.AccountType = txtMandAccountType.Text;
            objMandateDetails.AccountNumber = txtMandAccountno.Text;
            objMandateDetails.AutoPay = ddlAutoPaytype.SelectedValue;
            if (Session["objLoginObj"] != null)
            {
                objChangeObj = (ChangeValue)Session["objLoginObj"];
                objMandateDetails.objLoginUserDetails = objChangeObj.userLoginDetails;
            }
            /*ADDED BY SHRI FOR MANDATE SI */

            if (ddlAutoPaytype.SelectedValue.ToUpper() == "SI")
            {
                objMandateDetails.CreditCardNo = txtCreditcardno.Text;
                objMandateDetails.CreditCardType = txtcreditcardType.Text;
                objMandateDetails.ValidUpto = txtValidupto.Text;
                objMandateDetails.MicroCode = string.Empty;
                objMandateDetails.BankName = string.Empty;
                objMandateDetails.BranchName = string.Empty;
                objMandateDetails.MandateDate = (string.IsNullOrEmpty(txtMandateSigndate.Text)) ? Convert.ToDateTime("01-01-0001") : Convert.ToDateTime(txtMandateSigndate.Text);
                objMandateDetails.AccountHolderName = txtHolderName.Text;
            }
            else
            {
                objMandateDetails.MicroCode = txtMandMicrocode.Text;
                objMandateDetails.BankName = txtMandBankName.Text;
                objMandateDetails.BranchName = txtMandBranchName.Text;
                objMandateDetails.MandateDate = (string.IsNullOrEmpty(txtMandateassigndate.Text)) ? Convert.ToDateTime("01-01-0001") : Convert.ToDateTime(txtMandateassigndate.Text);
                objMandateDetails.AccountHolderName = txtMandAccountholder.Text;
            }
            /*END HERE*/

            int intRetVal = -1;
            /*commented by shri on 08 nov 17 to comment mandate details db call*/
            if (blnUpdateInLa)
            {
                Logger.Info(strApplicationno + "Remark : manadate details save to database begin:" + System.Environment.NewLine);
                objcomm.ManageMandate(objMandateDetails, ref intRetVal);
            }
            else
            {
                Logger.Info(strApplicationno + "Remark : manadate details save to Xml begin:" + System.Environment.NewLine);
                intRetVal = 1;
            }
            /*end here*/
            HideShowMandate();
            if (intRetVal > 0)
            {
                Logger.Info(strApplicationno + "Remark : manadate details save to database Success:" + System.Environment.NewLine);
                //lblErrorMandate.Text = "Mandate Details Updated In Data Base";
            }
            else
            {
                Logger.Info(strApplicationno + "Remark : manadate details save to database Failed:" + System.Environment.NewLine);
                //lblErrorMandate.Text = "Mandate Details NOT Updated In Data Base";
            }
            MandateSection objMandateSection = new MandateSection();
            objMandateSection.Section = "Mandate";
            objMandateSection.ACCOUNT_TYPE = txtMandAccountType.Text;
            objMandateSection.ACCOUNT_NUMBER = txtMandAccountno.Text;
            objMandateSection.AUTO_PAY_TYPE = ddlAutoPaytype.SelectedValue;
            objMandateSection.CREDIT_CARD_NO = txtCreditcardno.Text;
            objMandateSection.CREDIT_CARD_TYPE = txtcreditcardType.Text;
            objMandateSection.VALID_DATE = txtValidupto.Text;
            if (ddlAutoPaytype.SelectedValue.ToUpper() == "SI")
            {
                objMandateSection.MICRO_CODE = string.Empty;
                objMandateSection.BANK_NAME = string.Empty;
                objMandateSection.BRANCH_NAME = string.Empty;
                objMandateSection.MANDATE_DATE = (string.IsNullOrEmpty(txtMandateSigndate.Text)) ? "01-01-0001" : txtMandateSigndate.Text;
                objMandateSection.ACCOUNT_HOLDER_NAME = txtHolderName.Text;
            }
            else
            {
                objMandateSection.MICRO_CODE = txtMandMicrocode.Text;
                objMandateSection.BANK_NAME = txtMandBankName.Text;
                objMandateSection.BRANCH_NAME = txtMandBranchName.Text;
                objMandateSection.MANDATE_DATE = (string.IsNullOrEmpty(txtMandateassigndate.Text)) ? "01-01-0001" : txtMandateassigndate.Text;
                objMandateSection.ACCOUNT_HOLDER_NAME = txtMandAccountholder.Text;
            }
            objReplica.MandateSection = objMandateSection;
            Logger.Info(strApplicationno + "MethodeName :ManageBankDetails Object" + System.Environment.NewLine);
            Logger.Info(strApplicationno + "MethodeName :ManageBankDetails Object" + GetXMLFromObject(objMandateSection) + System.Environment.NewLine);
            if (blnUpdateInLa)
            {
                objcomm.ManageMandate(objMandateDetails, ref intRetVal);
                if (intRetVal > 0)
                {
                    objChangeObj = (ChangeValue)Session["objLoginObj"];
                    if (Session["objCommonObj"] != null)
                    {
                        objCommonObj = (CommonObject)Session["objCommonObj"];
                    }
                    string strAppType = objCommonObj._ChannelType;
                    DataSet _dsMandateResp = new DataSet();
                    objUWDecision.OnlineApplicationLAServiceDetails_PUSH(strApplicationno, strAppType, objChangeObj, ref _dsMandateResp, ref _dsPrevPol, "BANKENQ", ref strLApushErrorCode, ref strLApushStatus, ref strConsentRespons);
                }
            }

        }
        catch (Exception Error)
        {
            HideShowMandate();
            strErrorMessage = "Error While Saving Mandate Details,Please Contact System Admin";
            isdataSave = false;
            //lblErrorMandate.Text = lblErrorMandate.Text + strSpace + "Try again later";
            Logger.Info(strApplicationno + "Remark:" + "Exception in Manage Manadte details" + "STAG 8 :PageName :Uwdecision.aspx.CS // MethodeName :ManageMandateDetails" + System.Environment.NewLine);
            Logger.Info(strApplicationno + "Exception Message:" + Error.Message + System.Environment.NewLine);
        }
        chkMandate.Checked = false;
        Logger.Info(strApplicationno + "STEP :4 Save ProductRiderDetails End" + System.Environment.NewLine);
    }

    private void ManageApplicatonObject(int intSrNo, string strApplicationNo, ReplicaXml objReplicaXml, bool blnIsPosted, ref bool isdataSave, string strUserId, ref int intRet)
    {
        Logger.Info(strApplicationno + "Remark:" + "Save XMl to database Begin" + "STAG 8 :PageName :Uwdecision.aspx.CS // MethodeName :ManageApplicatonObject" + System.Environment.NewLine);
        Logger.Info(strApplicationno + "Is Updated in datatabse:" + blnIsPosted + System.Environment.NewLine);
        try
        {
            string strObjectData = UWSaralServices.CommFun.GetXMLFromObject(objReplicaXml);
            objcomm.ManageApplicationObject(intSrNo, strApplicationNo, strObjectData, blnIsPosted, strUserId, ref intRet);
            Logger.Info(strApplicationno + "Remark:" + "Save XMl to database end" + "STAG 8 :PageName :Uwdecision.aspx.CS // MethodeName :ManageApplicatonObject" + System.Environment.NewLine);
        }
        catch (Exception Error)
        {
            Logger.Info(strApplicationno + "Remark:" + "Exception in Application object Save to DB" + "STAG 8 :PageName :Uwdecision.aspx.CS // MethodeName :ManageApplicatonObject" + System.Environment.NewLine);
            Logger.Info(strApplicationno + "Exception Message:" + Error.Message + System.Environment.NewLine);
        }
    }

    private void FillUwDecision(DataSet _dsPageData)
    {
        foreach (DataTable dt in _dsPageData.Tables)
        {
            if (dt.Rows.Count > 0)
            {
                switch (dt.Rows[0][0].ToString())
                {
                    case "ApplicationDetails":
                        BindApplicationDetails(dt);
                        clsName = divApplicationDetails.Attributes["class"].ToString();
                        divApplicationDetails.Attributes.Add("class", clsName.Replace(clsName, "col-md-12"));
                        break;

                    case "AgentDetails":
                        BindAgentDetails(dt);
                        clsName = divAgentDetails.Attributes["class"].ToString();
                        divAgentDetails.Attributes.Add("class", clsName.Replace(clsName, "col-md-12"));
                        break;

                    case "BankDetails":
                        BindBankDetails(dt);
                        clsName = divBankDetails.Attributes["class"].ToString();
                        divBankDetails.Attributes.Add("class", clsName.Replace(clsName, "col-md-12"));
                        break;

                    case "PanDetails":
                        BindPanDetails(dt);
                        clsName = divPanDetails.Attributes["class"].ToString();
                        divPanDetails.Attributes.Add("class", clsName.Replace(clsName, "col-md-12"));
                        break;

                    case "ProductDetails":
                        BindProductDetails(dt);
                        clsName = divProductDetails.Attributes["class"].ToString();
                        divProductDetails.Attributes.Add("class", clsName.Replace(clsName, "col-md-12"));
                        break;
                    //Added by Suraj on 27 APRIL 2018
                    case "AssignmentType":
                        if (dt.Rows.Count > 0)
                        {
                            if (ddlApplicationDetailsProposalType.SelectedValue.Equals("EMP"))
                            {
                                if (ddlAssigmentType.Items.FindByValue(Convert.ToString(dt.Rows[0]["Value"])) != null)
                                {
                                    ddlAssigmentType.ClearSelection();
                                    ddlAssigmentType.Items.FindByValue(Convert.ToString(dt.Rows[0]["Value"])).Selected = true;
                                }
                            }
                            else
                            {
                                ddlAssigmentType.SelectedValue = "0";
                            }
                        }
                        break;
                    //END
                    case "Country":
                        if (dt.Rows.Count > 0)
                        {
                            if (ddlApplicationDetailsProposalType.SelectedValue.Equals("NRI"))
                            {
                                if (ddlcountry.Items.FindByValue(Convert.ToString(dt.Rows[0]["Value"])) != null)
                                {
                                    ddlcountry.ClearSelection();
                                    ddlcountry.Items.FindByValue(Convert.ToString(dt.Rows[0]["Value"])).Selected = true;
                                }
                            }
                            else
                            {
                                ddlcountry.SelectedValue = "0";
                            }
                        }
                        break;
                    case "RiderDetails":
                        BindRiderDetails(dt);
                        break;

                    case "FundDetails":
                        BindFundDetails(dt);
                        break;

                    case "ReceiptDetails":
                        BindReciptDetails(dt);
                        clsName = divPaymentDetails.Attributes["class"].ToString();
                        divPaymentDetails.Attributes.Add("class", clsName.Replace(clsName, "col-md-12"));
                        break;

                    case "RequirmentDetails":
                        BindRequirmentDetails(dt);
                        //UWFollowupServiceCall(strApplicationno, strChannelType);
                        clsName = divRequirementDetails.Attributes["class"].ToString();
                        divRequirementDetails.Attributes.Add("class", clsName.Replace(clsName, "col-md-12"));
                        break;

                    // 46.1 Begin of Changes; Jayendra  - [Webashlar01]
                    case "Requirment_STP":
                        BindRequirmentDetails_STP(dt);
                        //UWFollowupServiceCall(strApplicationno, strChannelType);
                        clsName = divRequirementDetails_STP.Attributes["class"].ToString();
                        divRequirementDetails_STP.Attributes.Add("class", clsName.Replace(clsName, "col-md-12"));
                        break;
                    // 46.1 End of Changes; Jayendra  - [Webashlar01]

                    case "LoadingDetails":
                        BindLoadingDetails(dt);
                        clsName = divExistingloading.Attributes["class"].ToString();
                        divExistingloading.Attributes.Add("class", clsName.Replace(clsName, "col-md-12"));
                        break;

                    case "CommentsDetails":
                        BindCommentsDetails(dt);
                        clsName = divExistingComments.Attributes["class"].ToString();
                        divExistingComments.Attributes.Add("class", clsName.Replace(clsName, "col-md-12"));
                        break;

                    case "CommonObjectDetails":
                        BindCommonObjectDetails(dt, strChannelType);
                        break;

                    case "PreIssueDetails":
                        //UWPreIssueServiceCall(strApplicationno, strChannelType);
                        clsName = PreIssue_containerBody.Attributes["class"].ToString();
                        PreIssue_containerBody.Attributes.Add("class", clsName.Replace(clsName, "col-md-12"));
                        break;

                    case "StpDetails":
                    //UWSTPServiceCall(strApplicationno, strChannelType);
                    //clsName = STP_containerBody.Attributes["class"].ToString();
                    //STP_containerBody.Attributes.Add("class", clsName.Replace(clsName, "col-md-12"));
                    //break;

                    case "AutoUwResults":
                        //DashbordUWResultDynamic_Get(strApplicationno, strUserId, strUserGroup, strUWmode);
                        clsName = AuResult_ContainerBody.Attributes["class"].ToString();
                        AuResult_ContainerBody.Attributes.Add("class", clsName.Replace(clsName, "col-md-12"));
                        break;

                    //case "DecisionDetails":
                    //  clsName = divDecisionDetails.Attributes["class"].ToString();
                    //  divDecisionDetails.Attributes.Add("class", clsName.Replace(clsName, "col-md-12"));
                    //  break;

                    case "SarDetails":
                        FillTsmrMsarDetails(strApplicationno, strChannelType);
                        clsName = divSarDetails.Attributes["class"].ToString();
                        divSarDetails.Attributes.Add("class", clsName.Replace(clsName, "col-md-12"));
                        break;

                    //43.1 Begin of Changes; Bhaumik Patel - [CR-4134]   
                    case "RedFlagDetails":
                        FillRedFlagDetails(strApplicationno);
                        clsName = divRedFlag.Attributes["class"].ToString();
                        divRedFlag.Attributes.Add("class", clsName.Replace(clsName, "col-md-12"));
                        break;
                    //43.1 End of Changes; Bhaumik Patel - [CR-4134]
                    case "Mandate":
                        FillMandateDetails(dt);
                        break;
                    case "Journal":
                        BindJournalDetails(dt);
                        break;
                    case "RISKPARAMETER":
                        BindRiskParameter(dt);
                        break;
                    case "DecisionGrid":
                        ManageUwDecisionGrid(dt);
                        break;
                    case "EXCEL_UPLOAD":
                        BindExcelRiskParameter(dt);
                        break;
                    case "AADHAR_PAN_VERIFICATION":
                        BindAadharDetails(dt);
                        break;
                    /*ID:9 START*/
                    case "TPA_STATUS":
                        BindTpaStatus(dt);
                        break;
                    /*ID:9 END*/
                    /*ID:9 START*/
                    case "SARAL_RISK":
                        BindExcelRiskParameter(dt);
                        break;
                    /*ID:9 END*/
                    /*ID:10 START*/
                    case "DECISION_TYPE":
                        BindDecisionType(dt);
                        break;
                    /*ID:10 END*/
                    /*ID:11 START*/
                    case "WARNING":
                        BindUwWarning(dt);
                        break;
                    case "HINT":
                        BindUwHint(dt);
                        break;
                    /*ID:11 END*/
                    case "DISTANCE":
                        Binddistance(dt);
                        break;
                    case "TransactionNo":
                        BindAadharTransactionNo(dt);
                        break;
                    case "MedicalDE":
                        BindMedicalDELink(dt);
                        break;
                    //case "IIBScore":
                    //    BindIIBScore(dt);
                    //    break;
                    //Added by Suraj Bhamre on 18 OCT 2019 for bind Au relation details		
                    case "AURealtionDetails":
                        BindAURelationDetails(dt);
                        break;
                    //Added by Suraj Bhamre on 14 FEB 2020 for get PEP case		
                    case "PEPCASE":
                        BindPEPCase(dt);
                        break;
                    //Added by Suraj Bhamre on 10 DEC 2019 for bind CIBIL score & income estimator
                    //case "CIBIL":
                    //    BindAURelationDetails(dt);
                    //    break;

                    //added by suraj on 14 FEB 2022 for CR-30589 risk category
                    case "RiskCategory":
                        BindRiskCategory(dt);
                        break;
                        //end
                }
            }
        }
    }

    private void PremiumCalculation(ReplicaXml objReplica, ref bool isdataSave, ref DataSet _dsPremiumCalculateResponse, ref int intResponseStatus, ref string strResponse, ProductSection objProductSectionBase, int listcount)
    {
        /*variable declaration*/
        try
        {
            List<ProductSection> lstProductSection = new List<ProductSection>();
            string strComboMonthlyPayout = string.Empty;
            string strProdMonthlyPayout = string.Empty;
            //lblErrorproddtls.Text = "";
            //gridPremCal_Product.DataSource = null;
            //gridPremCal_Product.DataBind();
            //lblErrorproddtls.Text = string.Empty;
            objChangeObj = (ChangeValue)Session["objLoginObj"];
            Logger.Info(strApplicationno + "STAG 8 :PageName :Uwdecision.aspx.CS // MethodeName :private PremiumCalculation" + System.Environment.NewLine);
            ProdDtls objprodchangevalue = new ProdDtls();
            //ProductSection objProductSectionBase = new ProductSection();
            ProductSection objProductSectionCombo = new ProductSection();
            ApplicationSection objApplicationSection = new ApplicationSection();
            AppDtls objAppDtls = new AppDtls();
            objAppDtls._Backdate = Request.Form[txtRcdreq.UniqueID];
            objChangeObj.App_backdate = objAppDtls;

            /*added by shri to add application details*/

            #region Bind Application details to replica begin.
            objApplicationSection.AppNo = txtAppno.Text;
            objApplicationSection.PolNo = txtPolno.Text;
            objApplicationSection.AppSignDate = txtAppsigndate.Text;
            objApplicationSection.PIVCSTATUS = txtPivcStatus.Text;
            objApplicationSection.BACKDATEFLAG = switch_havInsurance.Checked;
            objApplicationSection.BACKDATEINTREST = txtBackDateIntrest.Text;
            objApplicationSection.AgentChannel = txtAgentChannel.Text;
            objApplicationSection.BACKDATE = txtRcdreq.Text;
            objApplicationSection.BACHDATEREASON = ddlBkdateReason.SelectedValue;
            objApplicationSection.IsStaff = hd_que_2.Checked;
            objApplicationSection.PIVCRJCREASON = txtPivcRejectReason.Text;
            objApplicationSection.Channel = txtAppchannel.Text;
            objApplicationSection.APP_isNSAP = cbIsNsap.Checked;
            if (imgPivcStatus.ImageUrl.Equals(@"../dist/img/Success.png"))
            {
                objApplicationSection.SCRH_PIVC_STATUS = 1;
            }
            else
            {
                objApplicationSection.SCRH_PIVC_STATUS = 0;
            }
            objApplicationSection.AUTOPAYTYPE = ddlAutoPaytype.SelectedValue;
            objApplicationSection.Section = "ApplicationDetails";
            #endregion Bind Application details to replica End.

            #region  Bind base Product details to replica begins.
            /*added by shri to fill product details*/
            //added by suraj for combi
            if (objProductSectionBase != null)
            {

                objProductSectionBase.ProductCode = objprodchangevalue._ProdcodeBase = objProductSectionBase.ProductCode;
                objProductSectionBase.PolicyTerm = objprodchangevalue._PolicyTerm = objProductSectionBase.PolicyTerm;
                objProductSectionBase.PremiumTerm = objprodchangevalue._Premiumpayingterm = objProductSectionBase.PremiumTerm;
                objProductSectionBase.SumAssured = objprodchangevalue._Sumassured = objProductSectionBase.SumAssured;
                objProductSectionBase.PremiumFreq = objprodchangevalue._Paymentfrequency = objProductSectionBase.PremiumFreq;
                objProductSectionBase.BasePremium = objprodchangevalue._Basepremiumamount = objProductSectionBase.BasePremium;
                objProductSectionBase.MonthlyPayout = strProdMonthlyPayout = objprodchangevalue._MonthlyPayoutBase = objProductSectionBase.MonthlyPayout;
                objProductSectionBase.TotalPremium = objprodchangevalue._TotalPremiumamount = objProductSectionBase.TotalPremium;
                objProductSectionBase.MonthlyPayout = (string.IsNullOrEmpty(objProductSectionBase.MonthlyPayout)) ? string.Empty : objProductSectionBase.MonthlyPayout;
                objProductSectionBase.ProductType = hdnProductType.Value;
                objProductSectionBase.ProdcutName = objProductSectionBase.ProdcutName;
                objProductSectionBase.PolicyNo = objProductSectionBase.PolicyNo;
                objProductSectionBase.Section = "ProductDetails";

                //added by suraj for new product code T36/37 & E91/92
                objprodchangevalue._Category = objProductSectionBase.Category;
                objprodchangevalue._PayoutTerm = objProductSectionBase.PayoutTerm;
                objprodchangevalue._PayoutType = objProductSectionBase.PayoutType;
                objprodchangevalue._PayOutFrquency = objProductSectionBase.PayoutFreq;
                objprodchangevalue._LumpSumPercent = objProductSectionBase.LumpsumPer;
                objprodchangevalue._ProductCategory = objProductSectionBase.ProductCategory;
                //end
            }
            //end
            #region Commented code


            //objProductSectionBase.ProductCode = objprodchangevalue._ProdcodeBase = txtProdcode.Text;
            ////objProductSectionBase.PolicyTerm = objprodchangevalue._PolicyTerm = Request.Form[txtPolterm.UniqueID];
            ////objProductSectionBase.PremiumTerm = objprodchangevalue._Premiumpayingterm = Request.Form[txtPrepayterm.UniqueID];
            ////objProductSectionBase.SumAssured = objprodchangevalue._Sumassured = Request.Form[txtSumassure.UniqueID];
            ////objProductSectionBase.PremiumFreq = objprodchangevalue._Paymentfrequency = ddlFrequency.SelectedValue;
            ////objProductSectionBase.BasePremium = objprodchangevalue._Basepremiumamount = Request.Form[txtBasepremium.UniqueID];            
            ////objProductSectionBase.MonthlyPayout = strProdMonthlyPayout = objprodchangevalue._MonthlyPayoutBase = Request.Form[txtMonthlyPayoutBase.UniqueID];
            //objProductSectionBase.PolicyTerm = objprodchangevalue._PolicyTerm = txtPolterm.Text;
            //objProductSectionBase.PremiumTerm = objprodchangevalue._Premiumpayingterm = txtPrepayterm.Text;
            //objProductSectionBase.SumAssured = objprodchangevalue._Sumassured = txtSumassure.Text;
            //objProductSectionBase.PremiumFreq = objprodchangevalue._Paymentfrequency = ddlFrequency.SelectedValue;
            //objProductSectionBase.BasePremium = objprodchangevalue._Basepremiumamount = txtBasepremium.Text;
            //objProductSectionBase.MonthlyPayout = strProdMonthlyPayout = objprodchangevalue._MonthlyPayoutBase = txtMonthlyPayoutBase.Text;
            //objProductSectionBase.TotalPremium = objprodchangevalue._TotalPremiumamount = txtTotalpremium.Text;
            //objProductSectionBase.MonthlyPayout = (string.IsNullOrEmpty(objProductSectionBase.MonthlyPayout)) ? string.Empty : objProductSectionBase.MonthlyPayout;
            //objProductSectionBase.ProductType = hdnProductType.Value;
            //objProductSectionBase.ProdcutName = txtProname.Text;
            //objProductSectionBase.PolicyNo = txtBasepolno.Text;
            //objProductSectionBase.Section = "ProductDetails";
            #endregion
            #endregion  Bind base Product details to replica end.

            #region  Bind Combo Product details to replica Begin.
            /*
            if (!string.IsNullOrEmpty(txtCombProdCode.Text))
            {
                objProductSectionCombo.ProductCode = objprodchangevalue._ProdcodeCombo = txtCombProdCode.Text;
                objProductSectionCombo.PolicyTerm = objprodchangevalue._PolicyTermCombo = txtCombPolTerm.Text;
                objProductSectionCombo.PremiumTerm = objprodchangevalue._PremiumpayingtermCombo = txtCombPayTerm.Text;
                objProductSectionCombo.SumAssured = objprodchangevalue._SumassuredCombo = txtCombSumAssured.Text;
                objProductSectionBase.PremiumFreq = objprodchangevalue._Paymentfrequency = ddlFrequency.SelectedValue;
                objProductSectionCombo.BasePremium = objprodchangevalue._BasepremiumamountCombo = txtCombPremAmount.Text;
                objProductSectionCombo.TotalPremium = objprodchangevalue._TotalPremiumamountCombo = txtCombTotalPrem.Text;
                objProductSectionCombo.MonthlyPayout = strComboMonthlyPayout = objprodchangevalue._MonthlyPayoutCombo = txtComboMonthlyPayout.Text;
                objProductSectionCombo.MonthlyPayout = (string.IsNullOrEmpty(objProductSectionCombo.MonthlyPayout)) ? string.Empty : objProductSectionCombo.MonthlyPayout;
                objProductSectionCombo.ProductType = hdnProductType.Value;
                objProductSectionCombo.PolicyNo = txtCombopolno.Text;
                objProductSectionCombo.ProdcutName = txtCombProdName.Text;
                objProductSectionCombo.PremiumFreq = ddlComboFrequency.SelectedValue;
                objProductSectionCombo.Section = "ProductDetails";
            }
            */
            #endregion Bind Combo Product details to replica Begin.
            //set product details to object pass to serbtnvices.
            objChangeObj.Prod_policydetails = objprodchangevalue;
            /*added by shri to rider details */
            bool blnIsGreateThanSumAssured = true;
            List<RiderInfo> LstRiderInfo = new List<RiderInfo>();
            int counter = 0;

            foreach (GridViewRow rowfollowup in gvRiderDtls.Rows)
            {
                RiderInfo objRiderInfo = new RiderInfo();
                //define variable  
                Label lblpolNum = (Label)rowfollowup.FindControl("lblpolNum");
                if (objProductSectionBase.PolicyNo == lblpolNum.Text)
                {
                    CheckBox cbIsRider = (CheckBox)rowfollowup.FindControl("chkremoveRider");
                    Label lblRiderName = (Label)rowfollowup.FindControl("lblRiderName");
                    Label lblRiderCode = (Label)rowfollowup.FindControl("lblRiderCode");
                    TextBox txtRiderSumAssured = (TextBox)rowfollowup.FindControl("txtRiderSumAssure");
                    TextBox txtRiderTotalPremium = (TextBox)rowfollowup.FindControl("txtRiderPremium");
                    TextBox txtServiceTax = (TextBox)rowfollowup.FindControl("txtriderservicetax");
                    string[] strRiderSumAssured = txtRiderSumAssured.Text.Split(',');
                    string[] strRiderTotalPremium = txtRiderTotalPremium.Text.Split(',');
                    string[] strServiceTax = txtServiceTax.Text.Split(',');
                    if (strRiderSumAssured.Length > 0)
                    {
                        txtRiderSumAssured.Text = strRiderSumAssured[strRiderSumAssured.Length - 1];
                    }
                    if (strRiderTotalPremium.Length > 0)
                    {
                        txtRiderTotalPremium.Text = strRiderTotalPremium[strRiderTotalPremium.Length - 1];
                    }
                    if (strServiceTax.Length > 0)
                    {
                        txtServiceTax.Text = strServiceTax[strServiceTax.Length - 1];
                    }
                    if (cbIsRider.Checked && string.IsNullOrEmpty(txtRiderSumAssured.Text))
                    {
                        lblRiderDetailsError.Text = "Enter sum assured for all the checked riders";
                        return;
                    }
                    else if (cbIsRider.Checked && !string.IsNullOrEmpty(txtRiderSumAssured.Text) && Convert.ToDouble(txtRiderSumAssured.Text) < 1)
                    {
                        lblRiderDetailsError.Text = "Enter sum assured for all the checked riders";
                        return;
                    }
                    //get value from it
                    objRiderInfo.IsActive = cbIsRider.Checked;
                    objRiderInfo.RiderId = lblRiderCode.Text;
                    objRiderInfo.SumAssured = string.IsNullOrEmpty(txtRiderSumAssured.Text) ? Convert.ToDouble("0.00") : Convert.ToDouble(txtRiderSumAssured.Text);
                    objRiderInfo.RiderName = lblRiderName.Text;
                    //objRiderInfo.
                    LstRiderInfo.Add(objRiderInfo);
                    //add data row to datatable            
                    if (cbIsRider.Checked && !string.IsNullOrEmpty(txtRiderSumAssured.Text))
                    {
                        //if condition added by suraj on 17 FEB 2020 for compare SA of both combo product,previous only compare one SA with rider now we compare below combo SA with combo rider
                        //if (counter == 0)
                        //{
                        if (Convert.ToDouble(txtRiderSumAssured.Text) > Convert.ToDouble(objProductSectionBase.SumAssured))
                        {
                            blnIsGreateThanSumAssured = false;
                            break;
                        }
                        //}
                        ////if condition added by suraj on 17 FEB 2020 for compare SA of both combo product,previous only compare one SA with rider now we compare below combo SA with combo rider
                        //if (counter == 1)
                        //{
                        //    if (!string.IsNullOrEmpty(txtCombSumAssured.Text))
                        //    {
                        //        if (Convert.ToDouble(txtRiderSumAssured.Text) > Convert.ToDouble(txtCombSumAssured.Text))
                        //        {
                        //            blnIsGreateThanSumAssured = false;
                        //            break;
                        //        }
                        //    }
                        //}
                    }
                }
                //counter++;
            }
            if (!blnIsGreateThanSumAssured)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Rider Sum sssured should be less than total sum assured')", true);
            }
            /*end here*/
            objChangeObj.RiderInfo = LstRiderInfo;
            //fill application objet
            //Add Application object To Replica Xml
            if (objApplicationSection != null)
            {
                objReplica.ApplicationSection = objApplicationSection;
                Logger.Info(strApplicationno + "MethodeName :ApplicationDetails Object" + System.Environment.NewLine);
                Logger.Info(strApplicationno + "MethodeName :ApplicationDetails Object" + GetXMLFromObject(objApplicationSection) + System.Environment.NewLine);
            }

            //added by suraj for combi product
            DataSet _dsAppnoCombi = new DataSet();
            string strAppNo_Combi = string.Empty;

            objComm.GetAppNo(ref _dsAppnoCombi, objProductSectionBase.PolicyNo);
            if (_dsAppnoCombi != null && _dsAppnoCombi.Tables.Count > 0 && _dsAppnoCombi.Tables[0].Rows.Count > 0)
            {
                strAppNo_Combi = _dsAppnoCombi.Tables[0].Rows[0]["pol_applicationnostr"].ToString();
            }

            //To get NonMedicalLoading and MedicalClass
            FillLoadParam(ref objChangeObj, strAppNo_Combi);

            /*call premium calculation service*/
            objUWDecision.OnlineApplicationLAServiceDetails_PUSH(objProductSectionBase.PolicyNo, strChannelType, objChangeObj, ref _dsPremiumCalculateResponse, ref _dsPrevPol, "PREMIUMCAL", ref strLApushErrorCode, ref strLApushStatus, ref strConsentRespons);
            if (_dsPremiumCalculateResponse != null && _dsPremiumCalculateResponse.Tables[0].Rows.Count > 0)
            {
                /*added by shri on 12 dec 17 to use proper back date interest*/
                //objApplicationSection.BACKDATEINTREST = Convert.ToString(_dsPremiumCalculateResponse.Tables[0].Rows[0]["BackDateintrest"]);
                objApplicationSection.BACKDATEINTREST = Convert.ToString(_dsPremiumCalculateResponse.Tables[0].Rows[0]["BackdatedInt"]);
                /*end here*/
                int _ProdResult = 0;
                DataTable distinctTable = _dsPremiumCalculateResponse.Tables[0].DefaultView.ToTable( /*distinct*/ true);
                List<RiderInfo> lstPcRiderInfo = new List<RiderInfo>();
                //Commfun.FillRiderInfoFromPremiumCalcDataTable(ref lstPcRiderInfo, _dsPremiumCalculateResponse.Tables[0]);
                Commfun.FillRiderInfoFromPremiumCalcDataTable(ref lstPcRiderInfo, distinctTable);
                /*update product details*/

                //RiderInfo objProd = lstPcRiderInfo.Where(x => x.RiderType.Equals("BS") && x.ProductCode.Equals(objProductSectionBase.ProductCode)).SingleOrDefault();
                RiderInfo objProd = lstPcRiderInfo.Where(x => x.ProductCode.Equals(objProductSectionBase.ProductCode) && x.RiderType.Equals("BS")).SingleOrDefault();
                if (objProd != null)
                {
                    _ProdResult = 1;
                    //added by suraj for combi
                    objProductSectionBase.BasePremium = objprodchangevalue._Basepremiumamount = objProd.InstalmentPremiumAmt.ToString();
                    objProductSectionBase.TotalPremium = objprodchangevalue._TotalPremiumamount = objProd.TotalPremiumAmount.ToString();
                    objProductSectionBase.ServiceTax = objprodchangevalue._ServiceTax = objProd.ServiceTax.ToString();
                    objProductSectionBase.SumAssured = objprodchangevalue._Sumassured = objProd.SumAssured.ToString();
                    //end
                    /*
                    objProductSectionBase.BasePremium = txtBasepremium.Text = objprodchangevalue._Basepremiumamount = objProd.InstalmentPremiumAmt.ToString();
                    objProductSectionBase.TotalPremium = txtTotalpremium.Text = objprodchangevalue._TotalPremiumamount = objProd.TotalPremiumAmount.ToString();
                    objProductSectionBase.ServiceTax = txtServicetax.Text = objprodchangevalue._ServiceTax = objProd.ServiceTax.ToString();
                    objProductSectionBase.SumAssured = txtSumassure.Text = objprodchangevalue._Sumassured = objProd.SumAssured.ToString();
                    */
                    //objComm.OnlineProductDetails_Save(strChannelType, strApplicationno, strPolicyNo, txtProdcode.Text, txtSumassure.Text, txtPolterm.Text, txtPrepayterm.Text
                    //    , ddlFrequency.SelectedValue, txtBasepremium.Text, txtTotalpremium.Text, txtServicetax.Text, txtMonthlyPayoutBase.Text, ref _ProdResult);
                    if (_ProdResult > 0)
                    {
                        _ProdResult = 0;
                        //lblErrorproddtls.Text = "Product Details Updated Successfully";
                        //lblErrorProductDetailBody.Text += ",Product Details save succeed";
                    }
                    else
                    {
                        //lblErrorproddtls.Text = "Product Details Not Updated Successfully CLICK here to know more";
                        //lblErrorProductDetailBody.Text += ",Product Details NOT save in database";
                    }
                    lstProductSection.Add(objProductSectionBase);
                }
                /*
                RiderInfo objComb = lstPcRiderInfo.Where(x => x.RiderType.Equals("BS") && x.ProductCode.Equals(txtCombProdCode.Text)).SingleOrDefault();
                if (objComb != null)
                {
                    _ProdResult = 1;
                    objProductSectionCombo.BasePremium = txtCombPremAmount.Text = objprodchangevalue._BasepremiumamountCombo = objComb.InstalmentPremiumAmt.ToString();
                    objProductSectionCombo.TotalPremium = txtCombTotalPrem.Text = objprodchangevalue._TotalPremiumamountCombo = objComb.TotalPremiumAmount.ToString();
                    objProductSectionCombo.ServiceTax = txtCombServiceTax.Text = objprodchangevalue._ServiceTaxCombo = objComb.ServiceTax.ToString();
                    objProductSectionCombo.SumAssured = txtCombSumAssured.Text = objprodchangevalue._SumassuredCombo = objComb.SumAssured.ToString();
                    objProductSectionCombo.MonthlyPayout = txtComboMonthlyPayout.Text = strComboMonthlyPayout = string.IsNullOrEmpty(strComboMonthlyPayout) ? "0" : strComboMonthlyPayout;
                    lstProductSection.Add(objProductSectionCombo);
                    if (_ProdResult > 0)
                    {
                        _ProdResult = 1;
                        lblErrorProductDetailBody.Text += ",Combo Product Details save succeed";
                    }
                    else
                    {
                        lblErrorProductDetailBody.Text += ",Combo Product Details NOT save in database";
                    }

                }
                */
                objChangeObj.Prod_policydetails = objprodchangevalue;
                //add product object to replica xml.
                objReplica.LstProductSection = lstProductSection;
                Logger.Info(strApplicationno + "MethodeName :ProductDetails Object" + System.Environment.NewLine);
                Logger.Info(strApplicationno + "MethodeName :ProductDetails Object" + GetXMLFromObject(lstProductSection) + System.Environment.NewLine);
                /*update rider info*/
                //_dsPremiumCalculateResponse.Tables[0].Columns.RemoveAt(2);
                //_dsPremiumCalculateResponse.Tables[0].Columns.RemoveAt(2);
                //gridPremCal_Product.DataSource = _dsPremiumCalculateResponse;
                //gridPremCal_Product.DataBind();
                chkProductDtls.Checked = false;


                for (int i = 0; i < LstRiderInfo.Count; i++)
                {
                    if (lstPcRiderInfo.Count > i)
                    {
                        RiderInfo objRiderServiceTax = lstPcRiderInfo[i];
                        RiderInfo objRiderInfo = LstRiderInfo.Where(x => x.RiderId == objRiderServiceTax.RiderId).FirstOrDefault();
                        int index = LstRiderInfo.FindIndex(x => x.RiderId == objRiderServiceTax.RiderId);
                        if (index != -1)
                        {
                            objRiderInfo.ServiceTax = objRiderServiceTax.ServiceTax;
                            objRiderInfo.TotalInstalmentPremium = objRiderServiceTax.TotalInstalmentPremium;
                            objRiderInfo.SumAssured = objRiderServiceTax.SumAssured;
                            LstRiderInfo[index] = objRiderInfo;
                        }
                    }

                }
                // add rider object to replica xml.
                objReplica.LstRiderInfo = LstRiderInfo;
                intResponseStatus = 0;
                strResponse = string.Empty;
            }
            else
            {
                //FillProductDetails(strApplicationno, strChannelType);
                chkProductDtls.Checked = false;
                //lblErrorproddtls.Text = "Premium Calculation Failed to know more click here";
                //strResponse = lblErrorProductDetailBody.Text = strLApushStatus;
                intResponseStatus = 1;
                isdataSave = false;
            }
            updProductDetails.Update();
            /*ID:8 START*/
            IsBasePremiumDifferentChecker();
            /*ID:8 END*/
            /*ID:10 START*/
            if (IsUserLimitLessThanSumAssured())
            {
                RemoveWarningMessage("1");
                FillWarningMessage("1");
                DisplaySaralWarningMessage();
            }
            /*ID:10 END*/
        }
        catch (Exception Error)
        {
            strResponse = "Error While Calculating Premium " + System.Environment.NewLine;
            isdataSave = false;
            Logger.Info(strApplicationno + "PAGE_NAME:UWPortfolio/Uwdecision.aspx/ //EVENT_NAME:OnlineApplicationLAServiceDetails_PUSH//E-ERROR:Service Call Execution ERROR: PREMIUM CALCULATION" + "ERROR MESSAGE:" + Error.Message + System.Environment.NewLine);
        }
    }

    private void FillProductDetails(DataTable dt, MasterPageComparision objMasterPageComparision)
    {
        List<ProductSection> lstProductSection = new List<ProductSection>();
        if (dt != null && dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ProductSection objProductSection = new ProductSection();

                objProductSection.PolicyTerm = Convert.ToString(dt.Rows[i]["POLICY_TERM"]);
                objProductSection.PremiumFreq = Convert.ToString(dt.Rows[i]["PREMIUM_FREQ"]);
                objProductSection.SumAssured = Convert.ToString(dt.Rows[i]["SUM_ASSURED"]);
                objProductSection.ProductCode = Convert.ToString(dt.Rows[i]["PROD_CODE"]);
                objProductSection.PremiumTerm = Convert.ToString(dt.Rows[i]["PAYING_TERM"]);
                
                lstProductSection.Add(objProductSection);
            }
        }
        objMasterPageComparision.LstProductSection = lstProductSection;
    }

    private void FillRiderDetails(DataTable dt, MasterPageComparision objMasterPageComparision)
    {
        if (dt != null & dt.Rows.Count > 0)
        {
            List<RiderSection> lstRiderSection = new List<RiderSection>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                RiderSection objRiderSection = new RiderSection();
                objRiderSection.RiderCode = Convert.ToString(dt.Rows[i]["RIDERCODE"]);
                objRiderSection.RiderSumAssured = Convert.ToString(dt.Rows[i]["RIDERSUMASSURED"]);
                lstRiderSection.Add(objRiderSection);
            }
            objMasterPageComparision.LstRiderSection = lstRiderSection;
        }
    }

    private void FillClientDetails(DataTable dt, MasterPageComparision objMasterPageComparision)
    {
        if (dt != null && dt.Rows.Count > 0)
        {
            List<ClientSection> lstClientDetails = new List<ClientSection>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ClientSection objClientDetails = new ClientSection();
                objClientDetails.ClientRole = Convert.ToString(dt.Rows[i]["Role"]);
                objClientDetails.ClientId = Convert.ToString(dt.Rows[i]["ClientId"]);
                lstClientDetails.Add(objClientDetails);
            }
            objMasterPageComparision.LstClientDetails = lstClientDetails;
        }
    }

    private void ShowPopupMessage(string alertMessage)
    {
        //lblErrorinfo.Text = alertMessage;
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "ShowModalPopup('" + alertMessage + "');", true);
    }

    public void FillLoadParam(ref ChangeValue objChangeValue, string strappNo_combi)
    {
        List<LoadParam> lstLoadParam = new List<LoadParam>();
        LoadParam objLoadParamBS = new LoadParam();
        LoadParam objLoadParamAD = new LoadParam();
        DataTable _dtExistingLoad = null;
        DataTable _dtLoadMaster = null;
        DataTable _dtNewLoading = null;
        int strNonMedicalLoadingBS = 0, strNonMedicalLoadingAD = 0;
        string strMortalityClassBS = string.Empty;
        string strMortalityClassAD = string.Empty;
        _dtExistingLoad = (DataTable)ViewState["ExitingLoadingData"];
        _dtNewLoading = (DataTable)ViewState["LoadingData"];
        _dtLoadMaster = (DataTable)ViewState["LoadMaster"];
        int k = 0;
        if (_dtExistingLoad != null)
        {
            if (_dtExistingLoad.Rows.Count > 0)
            {
                objLoadParamAD.strMedicalLoadingClass1 = new string[_dtExistingLoad.Rows.Count];
                objLoadParamAD.strNonMedicalLoading1 = new string[_dtExistingLoad.Rows.Count];
                objLoadParamAD.strRiderCode = new string[_dtExistingLoad.Rows.Count];
                objLoadParamBS.strRiderCode = new string[_dtExistingLoad.Rows.Count];
                int ridercount = 0;
                foreach (DataRow dtRow in _dtExistingLoad.Rows)
                {
                    if (dtRow["LD_Applicationnostr"].ToString() == strappNo_combi)
                    {
                        //dtRow["RiderCtg"].ToString().Trim().Equals("BS") &&
                        if (dtRow["RiderCtg"].ToString().Trim().Equals("BS"))
                        {
                            //objLoadParamBS = new LoadParam();
                            if (!dtRow["LoadingType"].ToString().ToUpper().Trim().Equals("MEDICAL"))
                            {
                                strNonMedicalLoadingBS += string.IsNullOrEmpty(dtRow["RateAdjustment"].ToString()) ? 0 : Convert.ToInt32(dtRow["RateAdjustment"]);
                            }
                            else
                            {
                                strMortalityClassBS = Convert.ToString(dtRow["FlatMortality"].ToString().Trim());
                            }
                            objLoadParamAD.strNonMedicalLoading1[ridercount] = Convert.ToString(strNonMedicalLoadingBS);
                            objLoadParamAD.strMedicalLoadingClass1[ridercount] = Convert.ToString(strMortalityClassBS);
                            //objLoadParamBS.strNonMedicalLoading = Convert.ToString(strNonMedicalLoadingBS);
                            //objLoadParamBS.strMedicalLoadingClass = Convert.ToString(strMortalityClassBS);
                            objLoadParamAD.strRiderCtg = Convert.ToString(dtRow["RiderCtg"]);
                            objLoadParamAD.strRiderCode[ridercount] = Convert.ToString(dtRow["RiderName"]);
                        }
                        else
                        {
                            //objLoadParamAD = new LoadParam();
                            if (!dtRow["LoadingType"].ToString().ToUpper().Trim().Equals("MEDICAL"))
                            {
                                strNonMedicalLoadingAD = string.IsNullOrEmpty(dtRow["RateAdjustment"].ToString()) ? 0 : Convert.ToInt32(dtRow["RateAdjustment"]);
                            }
                            else
                            {
                                strMortalityClassAD = Convert.ToString(dtRow["FlatMortality"].ToString().Trim());
                            }
                            //objLoadParamAD.strNonMedicalLoading = Convert.ToString(strNonMedicalLoadingAD);
                            //objLoadParamAD.strMedicalLoadingClass = Convert.ToString(strMortalityClassAD);
                            k++;
                            objLoadParamAD.strNonMedicalLoading1[ridercount] = Convert.ToString(strNonMedicalLoadingAD);
                            objLoadParamAD.strMedicalLoadingClass1[ridercount] = Convert.ToString(strMortalityClassAD);
                            objLoadParamAD.strRiderCtg = Convert.ToString(dtRow["RiderCtg"]);
                            objLoadParamAD.strRiderCode[ridercount] = Convert.ToString(dtRow["RiderName"]);
                        }
                        ridercount++;
                    }
                }
            }
        }
        /*commented by suraj for combi
        //Added by suraj on 09-05-2019 for over rider rider parameter with new loading
        if (!string.IsNullOrEmpty(objLoadParamBS.strRiderCtg))
        {
            lstLoadParam.Add(objLoadParamAD);
        }
        if (!string.IsNullOrEmpty(objLoadParamAD.strRiderCtg))
        {
            lstLoadParam.Add(objLoadParamAD);
        }

        if (objChangeValue.Load_Loadingdetails != null)
        {
            objChangeValue.Load_Loadingdetails.lstLoadParam = lstLoadParam;
            objLoadParamAD = new LoadParam();
        }
        else
        {
            objChangeValue.Load_Loadingdetails = new LoadDtls();
            objChangeValue.Load_Loadingdetails.lstLoadParam = lstLoadParam;
            objLoadParamAD = new LoadParam();
        }
        //end
        */
        if (_dtNewLoading != null)
        {
            if (_dtNewLoading.Rows.Count > 0)
            {
                if (_dtNewLoading.Rows[0]["ddlAppNo"].ToString() == strappNo_combi)
                {
                    objLoadParamAD.strMedicalLoadingClass1 = new string[_dtNewLoading.Rows.Count];
                    objLoadParamAD.strNonMedicalLoading1 = new string[_dtNewLoading.Rows.Count];
                    objLoadParamAD.strRiderCode = new string[_dtNewLoading.Rows.Count];
                    objLoadParamBS.strRiderCode = new string[_dtNewLoading.Rows.Count];
                    int ridercount = 0;
                    foreach (DataRow dtRow in _dtNewLoading.Rows)
                    {
                        if (dtRow["ddlAppNo"].ToString() == strappNo_combi)
                        {
                            DataView dv = new DataView(_dtLoadMaster);
                            string strRiderName = dtRow["LoadType"].ToString();
                            dv.RowFilter = "NAME = '" + strRiderName + "'"; //+ dtRow["RiderName"].ToString();
                            string strRiderCtg = string.Empty;
                            strRiderCtg = dv[0]["RiderCtg"].ToString();
                            if (strRiderCtg.Trim().ToUpper().Equals("BS"))
                            {
                                //51.1 Begin of Changes; Bhaumik Patel - [CR-3334]
                                if (!dtRow["ddlLoadType"].ToString().ToUpper().Trim().Equals("MEDICAL") && (!dtRow["ddlLoadType"].ToString().ToUpper().Trim().Equals("HABITS")))
                                {//51.1 Begin of Changes; Bhaumik Patel - [CR-3334]
                                    strNonMedicalLoadingBS += string.IsNullOrEmpty(dtRow["txtRateAdjust"].ToString()) ? 0 : Convert.ToInt32(dtRow["txtRateAdjust"]);
                                }
                                else
                                {
                                    strMortalityClassBS = Convert.ToString(dtRow["ddlLoadFlatMortality"].ToString().Trim());
                                }
                                objLoadParamAD.strNonMedicalLoading1[ridercount] = Convert.ToString(strNonMedicalLoadingBS);
                                objLoadParamAD.strMedicalLoadingClass1[ridercount] = Convert.ToString(strMortalityClassBS);
                                //objLoadParamBS.strNonMedicalLoading = Convert.ToString(strNonMedicalLoadingBS);
                                //objLoadParamBS.strMedicalLoadingClass = Convert.ToString(strMortalityClassBS);
                                objLoadParamAD.strRiderCtg = strRiderCtg;
                                objLoadParamAD.strRiderCode[ridercount] = dv[0]["VALUE"].ToString();
                            }
                            else
                            {
                                //51.1 Begin of Changes; Bhaumik Patel - [CR-3334]
                                if (!dtRow["ddlLoadType"].ToString().ToUpper().Trim().Equals("MEDICAL") && (!dtRow["ddlLoadType"].ToString().ToUpper().Trim().Equals("HABITS")))
                                {//51.1 End of Changes; Bhaumik Patel - [CR-3334]
                                    strNonMedicalLoadingAD = string.IsNullOrEmpty(dtRow["txtRateAdjust"].ToString()) ? 0 : Convert.ToInt32(dtRow["txtRateAdjust"]);
                                }
                                else
                                {
                                    strMortalityClassAD = Convert.ToString(dtRow["ddlLoadFlatMortality"].ToString().Trim());
                                }
                                //objLoadParamAD.strNonMedicalLoading = Convert.ToString(strNonMedicalLoadingAD);
                                //objLoadParamAD.strMedicalLoadingClass = Convert.ToString(strMortalityClassAD);
                                k++;
                                objLoadParamAD.strNonMedicalLoading1[ridercount] = Convert.ToString(strNonMedicalLoadingAD);
                                objLoadParamAD.strMedicalLoadingClass1[ridercount] = Convert.ToString(strMortalityClassAD);
                                objLoadParamAD.strRiderCtg = strRiderCtg;
                                objLoadParamAD.strRiderCode[ridercount] = dv[0]["VALUE"].ToString();
                            }
                            ridercount++;
                        }
                    }
                }
            }
        }
        if (!string.IsNullOrEmpty(objLoadParamBS.strRiderCtg))
        {
            lstLoadParam.Add(objLoadParamAD);
        }
        if (!string.IsNullOrEmpty(objLoadParamAD.strRiderCtg))
        {
            lstLoadParam.Add(objLoadParamAD);
        }

        if (objChangeValue.Load_Loadingdetails != null)
        {
            objChangeValue.Load_Loadingdetails.lstLoadParam = lstLoadParam;

        }
        else
        {
            objChangeValue.Load_Loadingdetails = new LoadDtls();
            objChangeValue.Load_Loadingdetails.lstLoadParam = lstLoadParam;
        }
    }
    /*added by srhi on 16 dec 17 to add/remove nsap loading */
    protected void cbIsNsap_CheckedChanged(object sender, EventArgs e)
    {
        lblErrorAppDetailsBody.Text = lblErrorappdtls.Text = string.Empty;
        string response = "";
        Logger.Info("STAG 2 :PageName :Uwdecision.aspx.CS // MethodeName :cbIsNsap_CheckedChanged" + System.Environment.NewLine);
        try
        {
            ChangeNsapValue();
        }
        catch (Exception ex)
        {
            Logger.Info("STAG 2 :PageName :Uwdecision.aspx.CS // MethodeName :cbIsNsap_CheckedChanged error" + " " + ex.Message + System.Environment.NewLine);
            lblErrorappdtls.Text = "NSAP Loading not added successfully CLICK HERE to know more";
            lblErrorAppDetailsBody.Text = ex.Message;
        }
        finally
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "disp_confirm", "<script>hideloading()</script>", false);
        }
    }
    private void RemoveNsapLoadingDetails(string strApplicationNo, string strChannelType, ref string response)
    {
        if (ViewState["ExitingLoadingData"] != null)
        {
            DataTable dt = (DataTable)ViewState["ExitingLoadingData"];
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow[] dr = dt.Select("LoadReasoncode1='NN'");
                if (dr != null && dr.Count() > 0)
                {
                    DeleteSpecificLoading(dr[0], strApplicationNo, strChannelType, ref response);
                    dt.Rows.Remove(dr[0]);
                    ViewState["ExitingLoadingData"] = null;
                    BindLoadingDetails(dt);
                }
            }
        }
    }

    /*added by srhi on 16 dec 17 to add sis requirement */
    private void AddNewRequirement(string strReqFollowupCode, string strReqDescription, string strReqCategory, string strReqCriteria, string strReqLifeType, string strReqStatus
            , string srtReqRaisedBy)
    {
        Logger.Info("STAG 2 :PageName :Uwdecision.aspx.CS // MethodeName :AddNewRowToGrid1" + System.Environment.NewLine);
        if (ViewState["CurrentTable1"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable1"];
            DataRow drCurrentRow = null;
            //Label lblClosedBy;


            if (dtCurrentTable.Rows.Count > 0)
            {
                //DataRow drTest =dtCurrentTable

                //add new row to DataTable               
                DataRow[] dr = dtCurrentTable.Select("REQ_followupCode='SIS'");
                if (dr != null && dr.Count() < 1)
                {
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow[0] = strReqFollowupCode;
                    drCurrentRow[1] = strReqDescription;
                    drCurrentRow[2] = strReqCategory;
                    drCurrentRow[3] = strReqCriteria;
                    drCurrentRow[4] = strReqLifeType;
                    drCurrentRow[5] = strReqStatus;
                    drCurrentRow[6] = srtReqRaisedBy;
                    drCurrentRow[7] = System.DateTime.Now.ToString();
                    drCurrentRow[8] = System.DateTime.Now.ToString();
                    drCurrentRow[9] = System.DateTime.Now.ToString();
                    dtCurrentTable.Rows.Add(drCurrentRow);
                }
                //Rebind the Grid with the current data
                gvRequirmentDetails.DataSource = dtCurrentTable;
                gvRequirmentDetails.DataBind();

                UpdatePanel1.Update();
            }
        }
        //Set Previous Data on Postbacks
        //SetPreviousData1();
    }

    /*added by shri on 28 dec 17 to add tracking*/
    private void InsertUwDecisionTracking(string strApplicationNo, string strUserId, DateTime dtCurrentDateTime, string strEventName, ref int intRet)
    {
        objcomm = new Commfun();
        objcomm.InsertUwDecisionTracking(strApplicationNo, strUserId, dtCurrentDateTime.ToString("yyyy-MM-dd HH:mm:ss:fff"), strEventName, ref intRet);
    }

    /*added by shri on 28 dec 17 to update tracking*/
    private void UpdateUwDecisionTracking(int intSrNo, DateTime dtEndDate, ref int intRet)
    {
        objcomm = new Commfun();
        objcomm.UpdateUwDecisionTracking(intSrNo, dtEndDate.ToString("yyyy-MM-dd HH:mm:ss:fff"), ref intRet);
    }
    /*ID:3 START*/
    protected void btnAddComment_Click(object sender, EventArgs e)
    {
        try
        {
            AutoComment objAutoComment = new AutoComment();
            objBuss = new BussLayer();
            objBuss.FetchAutoCommentDetails(strApplicationno, strChannelType, ref _ds);
            BindCommentSection(objAutoComment, _ds);
            objUWDecision.OnlineApplicationLAServiceDetails_PUSH(strApplicationno, strChannelType, objChangeObj, ref dsMSAR, ref _dsPrevPol, "MSAR", ref strLApushErrorCode, ref strLApushStatus, ref strConsentRespons);
            BindSarDetails(objAutoComment, dsMSAR);
            txtUWComments.Value = objAutoComment.SummaryComment;
        }
        catch (Exception ex)
        {

        }
        finally
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "disp_confirm", "<script>hideloading()</script>", false);
        }
    }
    private void BindCommentSection(AutoComment objAutoComment, DataSet _ds)
    {
        if (_ds != null && _ds.Tables.Count > 0 && _ds.Tables[0].Rows.Count > 0)
        {
            objAutoComment.TotalPremium = Convert.ToString(_ds.Tables[0].Rows[0]["TOTAL_PREMIUM"]);
            objAutoComment.NameOfLa = Convert.ToString(_ds.Tables[0].Rows[0]["LA_NAME"]);
            objAutoComment.Gender = Convert.ToString(_ds.Tables[0].Rows[0]["GENDER"]);
            objAutoComment.Age = Convert.ToString(_ds.Tables[0].Rows[0]["AGE"]);
            objAutoComment.Education = Convert.ToString(_ds.Tables[0].Rows[0]["EDUCATION"]);
            objAutoComment.Occupation = Convert.ToString(_ds.Tables[0].Rows[0]["OCCUPATION"]);
            objAutoComment.AnnualIncome = Convert.ToString(_ds.Tables[0].Rows[0]["ANNUAL_INCOME"]);
            objAutoComment.Nominee = Convert.ToString(_ds.Tables[0].Rows[0]["NOMINEE_RELATION"]);
            objAutoComment.Proposer = Convert.ToString(_ds.Tables[0].Rows[0]["PROPOSAR_NAME"]);
            objAutoComment.Bmi = Convert.ToString(_ds.Tables[0].Rows[0]["BMI"]);
            objAutoComment.NatureOfDuty = Convert.ToString(_ds.Tables[0].Rows[0]["NATURE_OF_DUTY"]);
            objAutoComment.TypeOfIncomeProof = Convert.ToString(_ds.Tables[0].Rows[0]["INCOME_PROOF"]);
            objAutoComment.IdProof = Convert.ToString(_ds.Tables[0].Rows[0]["ID_PROOF"]);
            objAutoComment.AddressProof = Convert.ToString(_ds.Tables[0].Rows[0]["ADDR_PROOF"]);
            objAutoComment.AgeProof = Convert.ToString(_ds.Tables[0].Rows[0]["AGE_PROOF"]);
            objAutoComment.FamilyHistory = Convert.ToString(_ds.Tables[0].Rows[0]["FAMILY_HISTORY"]);
            objAutoComment.PersonalMedicalHistory = Convert.ToString(_ds.Tables[0].Rows[0]["PERSONAL_MEDICAL_HISTORY"]);
            //Added by Ajay sahu for auto comment format
            objAutoComment.PlanName = Convert.ToString(_ds.Tables[0].Rows[0]["PLAN_NAME"]);
            objAutoComment.SumAssured = Convert.ToString(_ds.Tables[0].Rows[0]["SUM_ASSURED"]);
            objAutoComment.PolicyTerm = Convert.ToString(_ds.Tables[0].Rows[0]["POLICY_TERM"]);
            objAutoComment.PolicyPayingTerm = Convert.ToString(_ds.Tables[0].Rows[0]["PLOLICY_PAYING_TERM"]);
            objAutoComment.MaritualStatus = Convert.ToString(_ds.Tables[0].Rows[0]["MARITAL_STATUS"]);
            objAutoComment.BranchCode = Convert.ToString(_ds.Tables[0].Rows[0]["BRANCH_CODE"]);
            objAutoComment.RiskScore = Convert.ToString(_ds.Tables[0].Rows[0]["RISK_SCORE"]);
            objAutoComment.EYRiskScore = Convert.ToString(_ds.Tables[0].Rows[0]["ENY_VALUE"]);
            objAutoComment.IIBRiskScore = Convert.ToString(_ds.Tables[0].Rows[0]["IIB_SCORE"]);
            objAutoComment.ChannelName = Convert.ToString(_ds.Tables[0].Rows[0]["CHANNEL_NAME"]);
            string existsins = string.Empty;
            if (_ds.Tables.Count > 0 && _ds.Tables[1].Rows.Count > 0)
            {
                for (int i = 0; i < _ds.Tables[1].Rows.Count; i++)
                {
                    var stringArr = _ds.Tables[1].Rows[i].ItemArray.Select(x => x.ToString()).ToArray();
                    existsins += Environment.NewLine + string.Join("/", stringArr.ToArray());

                }
            }
            objAutoComment.ExistingIns = existsins;
            //Added by suraj on 04/09/2018 as discussed with shabbir sir -display total SA(existing insurance+current) for HHI and Non HHI in auto comment
            if (_ds.Tables.Count > 2 && _ds.Tables[2].Rows.Count > 0)
            {
                objAutoComment.TOTALSA_HHI = Convert.ToString(_ds.Tables[2].Rows[0]["HHI_TSA"]);
                objAutoComment.TOTALSA_NON_HHI = Convert.ToString(_ds.Tables[2].Rows[0]["NON_HHI_TSA"]);
            }
        }
    }
    private void BindSarDetails(AutoComment objAutoComment, DataSet _ds)
    {
        if (_ds != null && _ds.Tables.Count > 0 && _ds.Tables[0].Rows.Count > 0)
        {
            DataRow[] dr = _ds.Tables[0].Select("ClientRole='LA'");
            if (dr != null && dr.Length > 0)
            {
                //objAutoComment.TMSAR = Convert.ToString(dr[0]["TSAR"]);
                objAutoComment.TMSAR = Convert.ToString(dr[0]["MSAR"]);
                objAutoComment.FSAR = Convert.ToString(dr[0]["Fsar"]);
                objAutoComment.TSAR = Convert.ToString(dr[0]["Tsar"]);

            }

        }
        else
        {
            objAutoComment.TMSAR = "";
            objAutoComment.FSAR = "";
            objAutoComment.TSAR = "";
        }
    }
    /*ID:3 END*/
    /*end here*/

    /*ID:4 START*/
    private void ManageContent()
    {
        if (strChannelType.ToLower().Equals("online"))
        {
            string strClass = string.Empty;
            strClass = divPanDetails.Attributes["class"].ToString();
            divPanDetails.Attributes["class"] = strClass.Replace(" HideControl", string.Empty);
            strClass = divAadharDetails.Attributes["class"].ToString();
            divAadharDetails.Attributes["class"] = strClass.Replace(" HideControl", string.Empty);
        }
        else
        {
            string strClass = string.Empty;
            strClass = divPanDetails.Attributes["class"].ToString();
            if (!strClass.Contains("HideControl"))
            {
                divPanDetails.Attributes["class"] = strClass + " HideControl";
            }

            strClass = divAadharDetails.Attributes["class"].ToString();
            if (!strClass.Contains("HideControl"))
            {
                divAadharDetails.Attributes["class"] = strClass + " HideControl";
            }
        }
    }
    /*ID:4 END*/
    /*ID:5 START*/
    protected void BtnAadharDetails_Click(object sender, EventArgs e)
    {
        try
        {
            /*ID:18 Start*/
            CheckBox3.Checked = false;
            /*ID:18 End*/
            int intRet = -1;
            if (!string.IsNullOrEmpty(txtAadharNumber.Text))
            {
                objUWDecision = new UWSaralDecision.BussLayer();
                objChangeObj = new ChangeValue();
                ClientDetails objClientDetails = new ClientDetails();
                objClientDetails.Aadhar = txtAadharNumber.Text;
                objChangeObj.ClientDetails = objClientDetails;
                _ds = new DataSet();
                objUWDecision.OnlineApplicationLAServiceDetails_PUSH(strApplicationno, strChannelType, objChangeObj, ref _ds, ref _ds, "AADHAR_VERIFICATION", ref strLApushErrorCode, ref strLApushStatus, ref strConsentRespons);
                if (strLApushErrorCode == -1)
                {
                    lblErrorAadharBody.Text = lblErrorAadharHead.Text = "Try Again Later";
                }
                else if (strLApushErrorCode == 1)
                {
                    lblErrorAadharBody.Text = lblErrorAadharHead.Text = "Aadhar Is Matched";
                    ManagePanAdharFlagUpdation(strApplicationno, true, 2, ref intRet);
                    ChangeThumbStatus(imgAadharVerified, true);
                }
                else if (strLApushErrorCode == 0)
                {
                    lblErrorAadharBody.Text = lblErrorAadharHead.Text = "Aadhar Not Matched";
                    ManagePanAdharFlagUpdation(strApplicationno, true, 2, ref intRet);
                    ChangeThumbStatus(imgAadharVerified, false);
                }
                gvUWDecisionAadharDetails.DataSource = _ds;
                gvUWDecisionAadharDetails.DataBind();
            }
            else
            {
                lblErrorAadharBody.Text = lblErrorAadharHead.Text = "Enter Aadhar Number";
            }
        }
        catch (Exception ex)
        {
            lblErrorAadharBody.Text = lblErrorAadharHead.Text = "Try Again Later";

        }
        finally
        {
            updAutoUwDetails.Update();
            ScriptManager.RegisterStartupScript(Page, GetType(), "disp_confirm", "<script>hideloading()</script>", false);
        }
    }
    protected void btnUpdateAadharDetails_Click(object sender, EventArgs e)
    {
        try
        {
            /*ID:18 Start*/
            CheckBox3.Checked = false;
            /*ID:18 End*/
            int intRet = -1;
            if (!string.IsNullOrEmpty(txtAadharNumber.Text))
            {
                objBuss = new BussLayer();
                if (Session["objLoginObj"] != null)
                {
                    objChangeObj = (ChangeValue)Session["objLoginObj"];
                }

                objBuss.UpdateUWDecitionAdditionalInfoDetails(strApplicationno, txtAadharNumber.Text, 1, objChangeObj.userLoginDetails._UserID, ref intRet);
                if (intRet > 0)
                {
                    lblErrorAadharHead.Text = "Aadhar Number Saved";
                    lblErrorAadharBody.Text = "Aadhar Number Saved";
                }
                else
                {
                    lblErrorAadharHead.Text = "Aadhar Number Not Saved";
                    lblErrorAadharBody.Text = "Aadhar Number Not Saved";
                }
            }
            else
            {
                lblErrorAadharHead.Text = "Update aadhar failed click here to know more";
                lblErrorAadharBody.Text = "Enter Aadhar Number";
            }
        }
        catch (Exception ex)
        {

        }
    }
    private void BindAadharDetails(DataTable dt)
    {

        txtAadharNumber.Text = Convert.ToString(dt.Rows[0]["AadharNumber"]);
        string strImageUrl = string.Empty;
        //if (Convert.ToBoolean(dt.Rows[0]["IsPanVerified"]))
        //{
        //    ChangeThumbStatus(imgPanVerified, true);
        //}
        //else
        //{
        //    ChangeThumbStatus(imgPanVerified, false);
        //}

        if (!string.IsNullOrEmpty(txtAadharNumber.Text))
        {
            ChangeThumbStatus(imgAadharVerified, true);
            chkIsAadharVerified.Checked = true;
        }
        else
        {
            ChangeThumbStatus(imgAadharVerified, false);
            chkIsAadharVerified.Checked = false;
        }


        //End
    }
    private void BindAadharTransactionNo(DataTable dt)
    {
        //Added By Suraj on 28/08/2018 for BDIP

        if (strChannelType == "ONLINE")
        {
            divimgekyc.Attributes.Add("Class", "form-group");
        }
        else
        {
            divimgekyc.Attributes.Add("Class", "form-group HideControl");
        }
        lblekycbdip.Text = Convert.ToString(dt.Rows[0]["AadharTransaction"]);
        if (Convert.ToString(lblekycbdip.Text) == "" || Convert.ToString(lblekycbdip.Text) == null)
        {
            divaadhartran.Attributes.Add("Class", "form-group HideControl");
            ChangeThumbStatus(imgekycverified, false);
        }
        else
        {
            divaadhartran.Attributes.Add("Class", "form-group");
            ChangeThumbStatus(imgekycverified, true);
        }

        //End
    }
    private void ManagePanAdharFlagUpdation(string strApplicationno, bool blnIsVerified, int intFlag, ref int intRet)
    {
        objBuss = new BussLayer();
        objBuss.UpdateUWDecitionAdditionalInfoFlag(strApplicationno, blnIsVerified, intFlag, ref intRet);
    }

    private void ChangeThumbStatus(Image img, bool blnFlag)
    {
        string strImageUrl = string.Empty;
        if (blnFlag)
        {
            strImageUrl = @"../dist/img/Success.png";
            img.ImageUrl = strImageUrl;
        }
        else
        {
            strImageUrl = @"~/dist/img/Failuer.png";
            img.ImageUrl = strImageUrl;
        }
        updAutoUwDetails.Update();
    }
    /*ID:5 END*/
    protected void chkIsPanValidate_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            int intRet = -1;
            ManagePanAdharFlagUpdation(strApplicationno, chkIsPanValidate.Checked, 1, ref intRet);
            ChangeThumbStatus(imgPanVerified, chkIsPanValidate.Checked);
        }
        catch (Exception ex)
        {
            lblErrorAadharHead.Text = lblErrorAadharBody.Text = "Try Again Later";
        }
    }
    /*ID:6 START*/
    private void SaveUwComment()
    {
        Logger.Info("STAG 2 :PageName :Uwdecision.aspx.CS // MethodeName :btnUWCommSave_Click");
        int UWCommentResult = 0;
        // objCommonObj = (CommonObject)Session["objCommonObj"];
        lblErrorLoadingDetailBody.Text = lblErrorcommentdtls.Text = string.Empty;
        objChangeObj = (ChangeValue)Session["objLoginObj"];
        /*ADDED BY SHRI ON 07 NOV 17 TO CALL MANAGE APPLICATION LIFE CYCLE*/
        /*added by shri on 28 dec 17 to add tracking*/
        int intTrackingRet = -1;
        objCommonObj = (CommonObject)Session["objCommonObj"];
        strUserId = objCommonObj._Bpmuserdetails._UserID;
        InsertUwDecisionTracking(strApplicationno, strUserId, DateTime.Now, "COMMENT_SAVE", ref intTrackingRet);
        /*end here*/
        int intRef = -1;
        //Aded by Suraj for Reinsurer Comments
        if (!string.IsNullOrEmpty(txtUWComments.Value) && txtUWComments.Value.Contains("Reinsurer Comments"))
        {
            objChangeObj.userLoginDetails._ProcessName = "UW Reinsurer";
        }
        objComm.ManageApplicationLifeCycle(strApplicationno, objChangeObj.userLoginDetails._UserID, "UW_DECISION_COMMENT", false, ref intRef);
        /*END HERE*/
        objComm.OnlineUWCommentsDetails_Save(objChangeObj.userLoginDetails._UserName, objChangeObj.userLoginDetails._ProcessName, objChangeObj.userLoginDetails._UserGroup, Convert.ToString(txtUWComments.Value), strApplicationno, objChangeObj.userLoginDetails._UserID, objChangeObj.userLoginDetails._UserName, objChangeObj.userLoginDetails._UserGroup, objChangeObj.userLoginDetails._userBranch, objChangeObj.userLoginDetails._userBranch, objChangeObj.userLoginDetails._ProcessName, strApplicationno, ddlComment.SelectedValue, ref UWCommentResult);
        if (UWCommentResult != 0)
        {
            ddlComment.SelectedValue = "General";
            txtUWComments.Value = "";
            FillCommentsDetails(strApplicationno, strChannelType, ddlComment.SelectedValue);
            lblErrorcommentdtls.Text = "Comment details saved successfully";
            lblErrorLoadingDetailBody.Text = "Comment details saved successfully";
        }
        else
        {
            lblErrorcommentdtls.Text = "Comment details Not Saved CLICK To Know More";
            lblErrorLoadingDetailBody.Text = "Comment details Not Saved In DataBase";
        }
        chkCommentDtls.Checked = false;
        /*ADDED BY SHRI ON 07 NOV 17 TO CALL MANAGE APPLICATION LIFE CYCLE*/
        objComm.ManageApplicationLifeCycle(strApplicationno, objChangeObj.userLoginDetails._UserID, "UW_DECISION_COMMENT", true, ref intRef);
        /*added by shri on 28 dec 17 to update tracking*/
        UpdateUwDecisionTracking(intTrackingRet, DateTime.Now, ref intTrackingRet);
        /*END HERE*/
        ScriptManager.RegisterStartupScript(Page, GetType(), "disp_confirm", "<script>hideloading()</script>", false);
        /*END HERE*/
    }
    protected void chkRiskParamIsSmoker_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            int intRet = -1;
            objBuss = new BussLayer();
            string strUserId = string.Empty;
            objBuss.UpdateUWDecitionAdditionalInfoFlag(strApplicationno, chkSaralRiskIsSmoker.Checked, 3, ref intRet);
            if (intRet > 0)
            {
                objCommonObj = (CommonObject)Session["objCommonObj"];
                objChangeObj = (ChangeValue)Session["objLoginObj"];
                strUserId = objCommonObj._Bpmuserdetails._UserID.ToUpper();
                objUWDecision.OnlineApplicationLAServiceDetails_PUSH(strApplicationno, strChannelType, objChangeObj, ref _ds, ref _dsPrevPol, "CONTRACTMODIFICATION", ref strLApushErrorCode, ref strLApushStatus, ref strConsentRespons);
                objBuss.InsertUserChangesLog(strApplicationno, (strUserId.IndexOf('F') == 0) ? strUserId.Substring(1) : strUserId, "SMOKER", Convert.ToString(chkRiskParamIsSmoker.Checked), ref intRet);
                lblErrorDetailsRiskParameter.Text = "Smoker Updated Successfully";
            }
            else
            {
                lblErrorDetailsRiskParameter.Text = "Smoker Not Updated Successfully";
            }
            //42.1 Begin of Changes; Sushant Devkate -MFL00905
            if (chkSaralRiskIsSmoker.Checked == false)
            {
                chkSaralRiskIsSmoker.Checked = false;
            }
            //42.1 End of Changes; Sushant Devkate -MFL00905
        }
        catch (Exception ex)
        {

            lblErrorDetailsRiskParameter.Text = "Try Again Later";
        }
    }
    protected void chkIsAadharVerified_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            int intRet = -1;
            ManagePanAdharFlagUpdation(strApplicationno, chkIsAadharVerified.Checked, 2, ref intRet);
            ChangeThumbStatus(imgAadharVerified, chkIsAadharVerified.Checked);
        }
        catch (Exception ex)
        {
            lblErrorAadharHead.Text = lblErrorAadharBody.Text = "Try Again Later";
        }
    }
    /*ID:6 END*/
    /*ID:7 START*/
    private void ChangeNsapValue()
    {
        Commfun objCommfun = new Commfun();
        objBuss = new BussLayer();
        int intRef = -1;
        objCommonObj = (CommonObject)Session["objCommonObj"];
        strUserId = objCommonObj._Bpmuserdetails._UserID.ToUpper();
        objCommfun.ManageNsapFlag(strApplicationno, cbIsNsap.Checked, ref intRef);
        if (cbIsNsap.Checked)
        {
            FillNsaploadingDetails(strApplicationno, strChannelType);
            FillLoadingDetails(strApplicationno, strChannelType);
            lblErrorAppDetailsBody.Text = lblErrorappdtls.Text = "NSAP Loading added successfully";
        }
        else
        {
            RemoveNsapLoadingDetails(strApplicationno, strChannelType, ref response);
            if (response != "-1")
            {
                lblErrorAppDetailsBody.Text = lblErrorappdtls.Text = "NSAP Loading removed successfully";
            }
            else
            {
                lblErrorAppDetailsBody.Text = lblErrorappdtls.Text = "NSAP Loading not removed successfully";
            }
        }
        objBuss.InsertUserChangesLog(strApplicationno, (strUserId.IndexOf('F') == 0) ? strUserId.Substring(1) : strUserId, "NSAP", Convert.ToString(cbIsNsap.Checked), ref intRef);
        updLoadingDetails.Update();
    }
    /*ID:7 END*/
    /*ID:8 START*/
    private void IsBasePremiumDifferentChecker()
    {
        foreach (RepeaterItem item in rptproductlist.Items)
        {
            TextBox txtProdBranchBasePremium = (TextBox)item.FindControl("txtProdBranchBasePremium");
            TextBox txtBasepremium = (TextBox)item.FindControl("txtBasepremium");
            TextBox txtAppno = (TextBox)item.FindControl("txtAppno");
            int intSumDifference = (Convert.ToInt32(string.IsNullOrEmpty(txtProdBranchBasePremium.Text) ? "0" : txtProdBranchBasePremium.Text) - Convert.ToInt32(string.IsNullOrEmpty(txtBasepremium.Text) ? "0" : txtBasepremium.Text));
            if (intSumDifference >= 200)
            {
                lblCommentNotificationPremiumChange.Text = "Base premium in saral is different from Base premium entered in branch by Rs. " + Convert.ToString(intSumDifference);
            }
            else
            {
                lblCommentNotificationPremiumChange.Text = string.Empty;
            }
        }
    }
    /*ID:8 END*/
    /*ID:9 START*/
    private void BindTpaStatus(DataTable dt)
    {
        if (dt.Rows.Count > 0)
        {
            Logger.Info(strApplicationno + "STAG3:-Function Call BindTpaStatus" + System.Environment.NewLine);
            divTpaDetails.Attributes.Add("Class", "col-md-12");
            gvTpaDetailsTpaStatus.DataSource = dt;
        }
        else
        {
            gvTpaDetailsTpaStatus.DataSource = null;
            divTpaDetails.Attributes.Add("Class", "col-md-12 HideControl");
        }
        gvTpaDetailsTpaStatus.DataBind();
    }
    /*ID:9 END*/
    /*ID:10 START*/
    private void ManageDecisionType()
    {
        int intRet = -1;
        try
        {
            objBuss = new BussLayer();
            objBuss.UWDecisionManageDecisionDetails(FillDataTableDecisionType(), ref intRet);
        }
        catch (Exception ex)
        {

        }
    }

    private DataTable FillDataTableDecisionType()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("ApplicationNo", typeof(string));
        dt.Columns.Add("DecisionType", typeof(int));
        dt.Columns.Add("UserId", typeof(string));
        objCommonObj = (CommonObject)Session["objCommonObj"];
        strUserId = objCommonObj._Bpmuserdetails._UserID;
        foreach (ListItem item in cblDecisionTypeDecisions.Items)
        {
            if (item.Selected)
            {
                DataRow dr = dt.NewRow();
                dr[0] = strApplicationno;
                dr[1] = item.Value;
                dr[2] = strUserId;
                dt.Rows.Add(dr);
            }
        }
        foreach (ListItem item in cblDecisionTypeIncompleteDocument.Items)
        {
            if (item.Selected)
            {
                DataRow dr = dt.NewRow();
                dr[0] = strApplicationno;
                dr[1] = item.Value;
                dr[2] = strUserId;
                dt.Rows.Add(dr);
            }
        }
        foreach (ListItem item in cblDecisionTypeCleanCase.Items)
        {
            if (item.Selected)
            {
                DataRow dr = dt.NewRow();
                dr[0] = strApplicationno;
                dr[1] = item.Value;
                dr[2] = strUserId;
                dt.Rows.Add(dr);
            }
        }
        return dt;
    }

    private void BindMasterDetails(CheckBoxList ddl)
    {
        Logger.Info("STAG 2 :PageName :Uwdecision.aspx.CS // MethodeName :BindMasterDetails" + System.Environment.NewLine);
        string strTableName = ddl.ID;
        if (strTableName == "ddlExstingLoadType")
        {
            strTableName = "ddlLoadType";
        }
        else if (strTableName == "ddlExistingLoadRsn1")
        {
            //strTableName = "ddlLoadRsn1";
        }
        else if (strTableName == "ddlExistingLoadRsn2")
        {
            //strTableName = "ddlLoadRsn2";
        }
        else if (strTableName == "ddlExistingLoadFlatMort")
        {
            strTableName = "ddlLoadFlatMortality";
        }
        else if (strTableName == "ddlCommonStatus")
        {
            strTableName = "ddlStatus";
        }
        /*ID:10 START*/
        else if (strTableName == "ddlApplicationDetailsProposalType")
        {
            strTableName = "ddlProposalType";
        }
        else if (strTableName == "cblDecisionTypeDecisions")
        {
            strTableName = "cblDecisionType";
        }
        else if (strTableName == "cblDecisionTypeIncompleteDocument")
        {
            strTableName = "ddlProposalType2";
        }
        else if (strTableName == "cblDecisionTypeCleanCase")
        {
            strTableName = "ddlProposalType3";
        }
        /*ID:10 END*/
        //Added by Suraj on 25 APRIL 2018
        else if (strTableName == "ddlAssigmentType")
        {
            strTableName = "ddlAssigmentType";
        }
        //END
        //Added by Suraj on 2 JULY 2018
        else if (strTableName == "ddlcountry")
        {
            strTableName = "ddlcountry";
        }
        DataSet _dsMaster = (DataSet)ViewState["_dsFollowuo"];
        ArrayList arr = new ArrayList();
        if (_dsMaster != null && _dsMaster.Tables.Count > 0)
        {
            if (_dsMaster.Tables[strTableName] != null && _dsMaster.Tables[strTableName].Rows.Count > 0)
            {

                ddl.DataSource = _dsMaster.Tables[strTableName];
                ddl.DataTextField = "NAME";
                ddl.DataValueField = "VALUE";
                ddl.DataBind();
            }
        }
    }

    private void BindDecisionType(DataTable dt)
    {
        if (dt != null && dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (cblDecisionTypeDecisions.Items.FindByValue(Convert.ToString(dt.Rows[i][1])) != null)
                {
                    cblDecisionTypeDecisions.Items.FindByValue(Convert.ToString(dt.Rows[i][1])).Selected = true;
                }
                else if (cblDecisionTypeIncompleteDocument.Items.FindByValue(Convert.ToString(dt.Rows[i][1])) != null)
                {
                    cblDecisionTypeIncompleteDocument.Items.FindByValue(Convert.ToString(dt.Rows[i][1])).Selected = true;
                }
                else if (cblDecisionTypeCleanCase.Items.FindByValue(Convert.ToString(dt.Rows[i][1])) != null)
                {
                    cblDecisionTypeCleanCase.Items.FindByValue(Convert.ToString(dt.Rows[i][1])).Selected = true;
                }
            }
        }
    }
    private void AppWiseWarning()
    {
        objBuss.GetApplication_Warmning(strApplicationno, ref _dsWarning);
        if (_dsWarning != null && _dsWarning.Tables.Count > 0 && _dsWarning.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < _dsWarning.Tables[0].Rows.Count; i++)
            {
                lblUwSaralWarningMessage.Text += Convert.ToString(_dsWarning.Tables[0].Rows[i]["WarningMessage"]);
            }
        }
    }
    private void DisplaySaralWarningMessage()
    {
        WarningMessage objWarning = new WarningMessage();
        lblUwSaralWarningMessage.Text = objWarning.SetMessage(hdnWarningMessage.Value.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries));
        /*
        objBuss.GetApplication_Warmning(strApplicationno, ref _dsWarning);
        if (_dsWarning != null && _dsWarning.Tables.Count > 0 && _dsWarning.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < _dsWarning.Tables[0].Rows.Count; i++)
            {
                lblUwSaralWarningMessage.Text += Convert.ToString(_dsWarning.Tables[0].Rows[i]["WarningMessage"]);
            }
        }
        */
    }

    private void RemoveWarningMessage(string strIndex)
    {
        string strPipe = "|";
        hdnWarningMessage.Value = hdnWarningMessage.Value.Replace(strPipe + strIndex + strPipe, strPipe);
    }
    private void BindUwWarning(DataTable _dt)
    {

        if (_dt != null && _dt.Rows.Count > 0)
        {
            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                FillWarningMessage(Convert.ToString(_dt.Rows[i]["Id"]));
            }
        }

        DisplaySaralWarningMessage();
    }

    private void FillWarningMessage(string strInput)
    {
        string strPipe = "|";
        hdnWarningMessage.Value = hdnWarningMessage.Value + strInput + strPipe;
    }

    private bool IsUserLimitLessThanSumAssured()
    {
        #region start 35.1: This CR-2639 changes done by Sushant Devkate MFL00905 
        decimal FSARofLA = objBuss.GetFSARofLA(strApplicationno);
        //48.1 Begin of Changes; Bhaumik Patel - [CR-5307]
        decimal Userlimit = Convert.ToDecimal(hdnUserLimit.Value);
        //48.1 Begin of Changes; Bhaumik Patel - [CR-5307]
        if (Convert.ToInt64(Userlimit) < Convert.ToInt64(FSARofLA)) //Convert.ToInt64(ViewState["SA"].ToString()))
        {
            return true;
        }
        else
        {
            return false;
        }
        #endregion END 35.1: This CR-2639 changes done by Sushant Devkate MFL00905 
    }
    /*ID:10 END*/
    /*ID:17 END*/
    //Added by Suraj on 10 MAY 2018 for disabled assign type dropdown
    protected void ddlApplicationDetailsProposalType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlApplicationDetailsProposalType.SelectedValue != null || ddlApplicationDetailsProposalType.SelectedValue != "0")
        {
            if (ddlApplicationDetailsProposalType.SelectedValue.Equals("EMP"))
            {
                ddlAssigmentType.Attributes["class"] = ddlAssigmentType.Attributes["class"].ToString().Replace("lblLable", "");

            }
            else
            {
                ddlAssigmentType.Attributes.Add("class", "form-control lblLable");
                ddlAssigmentType.SelectedValue = "0";
            }
            if (ddlApplicationDetailsProposalType.SelectedValue.Equals("NRI"))
            {
                ddlcountry.Attributes["class"] = ddlcountry.Attributes["class"].ToString().Replace("lblLable", "");

            }
            else
            {
                ddlcountry.Attributes.Add("class", "form-control lblLable");
                ddlcountry.SelectedValue = "0";
            }
        }

    }
    /*ID:17 END*/

    /*ID:12 START*/
    protected void btnSaveAnswer_Click(object sender, EventArgs e)
    {
        if (Session["objCommonObj"] != null)
        {
            objCommonObj = (CommonObject)Session["objCommonObj"];

        }
        //GridView grd = (GridView)FindControl("grdclosefilerw");
        int QueId = 1;
        //GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
        DataTable _dt = new DataTable();
        int resp = 0;
        _dt.Columns.Add("AppNo", typeof(string));
        _dt.Columns.Add("QuesId", typeof(int)); //name of the column
        _dt.Columns.Add("Answer", typeof(int));//name of the column
        _dt.Columns.Add("UserId", typeof(string));
        _dt.Columns.Add("CreatedDate", typeof(DateTime));
        //_dt.Columns.Add("Remark", typeof(string));
        foreach (GridViewRow row in grdclosefilerw.Rows)
        {
            QueId = row.RowIndex + 1;
            DropDownList ddl = (DropDownList)row.FindControl("ddlAnswer");
            TextBox txtCloseFileRemark = (TextBox)row.FindControl("txtCloseFileRemark");
            if (ddl.SelectedValue != "")
            {
                int selectedValue = Convert.ToInt32(ddl.SelectedValue);
                if (selectedValue != 0)
                {
                    DataRow dr = _dt.NewRow();
                    dr["AppNo"] = Convert.ToString(txtAppno.Text);
                    dr["QuesId"] = QueId;
                    dr["Answer"] = selectedValue; //row.Cells[1].Text;
                    dr["UserId"] = Convert.ToString(objCommonObj._Bpmuserdetails._UserID);
                    //dr["Remark"] = txtCloseFileRemark.Text;
                    _dt.Rows.Add(dr);
                }
                else
                {
                    //lblerrorclosefile.Text = "";
                }
            }

        }
        objBuss.SaveAnswer_CloseFile(_dt, txtcloseRemark.Text.Trim(), Convert.ToInt32(ddlCaseCategory.SelectedValue), ref resp);
        if (resp > 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "SHOW SUCCESS MESSAGE AND CLOSE PAGE", "window.close();alert('Details save successfully');", true);
            // ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('Details save successfully');window.close();", true);

        }


    }
    /*ID:12 END*/
    /*ID:13 START*/
    protected void BindQuestion_CloseFile()
    {
        //objBuss = new BussLayer();
        objBuss.BindQuestion_CloseFile(ref _dsQuestion);
        if (_dsQuestion.Tables.Count > 0)
        {
            if (_dsQuestion.Tables[0].Rows.Count > 0)
            {
                grdclosefilerw.DataSource = _dsQuestion.Tables[0];
                grdclosefilerw.DataBind();
            }
        }


    }
    /*ID:13 END*/
    /*ID:14 START*/
    protected void grdclosefilerw_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList ddlAnswer = (DropDownList)e.Row.FindControl("ddlAnswer");

            BindMasterDetails(ddlAnswer);
        }
    }
    /*ID:14 END*/
    /*ID:15 START*/
    private void DisableControl_CloseFileReview()
    {
        foreach (RepeaterItem item in rptDecision.Items)
        {
            Label lblproductname = item.FindControl("lblproductname") as Label;
            DropDownList ddlUWDecesion = (DropDownList)rptDecision.FindControl("ddlUWDecesion");
        }

        if (Convert.ToString(strClickBucketLink) == "Close_File_Review")
        {
            divCloseFileReview.Visible = true;
            chkAppDtls.Enabled = false;
            chkAgentDtls.Enabled = false;
            chkJournal.Enabled = false;
            chkBankDtls.Enabled = false;
            chkMandate.Enabled = false;
            chkPanDtls.Enabled = false;
            CheckBox3.Enabled = false;
            CheckBox2.Enabled = false;
            CheckBox1.Enabled = false;
            chkProductDtls.Enabled = false;
            chkFunddtlsSave.Enabled = false;
            chkReqDtls.Enabled = false;
            chkLoadingDtls.Enabled = false;
            chkCommentDtls.Enabled = false;
            btnUWCommSave.Enabled = false;
            //btnCloseFileSaveAnswer.Enabled = false;
            //ddlUWDecesion.Enabled = false;
            gvExtLoadDetails.Enabled = false;
            Master.FindControl("btnPost").Visible = false;
            Master.FindControl("btnReview").Visible = false;
            Master.FindControl("btnReferToCmo").Visible = false;

        }
        else
        {
            divCloseFileReview.Visible = false;
            chkAppDtls.Enabled = true;
            chkAgentDtls.Enabled = true;
            chkJournal.Enabled = true;
            chkBankDtls.Enabled = true;
            chkMandate.Enabled = true;
            chkPanDtls.Enabled = true;
            CheckBox3.Enabled = true;
            CheckBox2.Enabled = true;
            CheckBox1.Enabled = true;
            chkProductDtls.Enabled = true;
            chkFunddtlsSave.Enabled = true;
            chkReqDtls.Enabled = true;
            chkLoadingDtls.Enabled = true;
            chkCommentDtls.Enabled = true;
            btnUWCommSave.Enabled = true;
            //btnCloseFileSaveAnswer.Enabled = true;
            //ddlUWDecesion.Enabled = true;
            gvExtLoadDetails.Enabled = true;
            Master.FindControl("btnPost").Visible = true;
            Master.FindControl("btnReview").Visible = true;
            Master.FindControl("btnReferToCmo").Visible = true;
        }


    }
    /*ID:15 END*/
    /*ID:16 START*/
    private void ManagePolicyPrinting()
    {
        DropDownList ddlUWDecesion = (DropDownList)rptDecision.FindControl("ddlUWDecesion");
        if (ddlUWDecesion.SelectedValue == "Approved")
        {
            int intResp = -1;
            if (ddlDecisionDetailsIsPolicyPrintingToHolding.SelectedValue == "True")
            {
                if (Session["objLoginObj"] != null)
                {
                    objChangeObj = (ChangeValue)Session["objLoginObj"];
                }
                objBuss.ManagePolicyPrinting(strApplicationno, "UW_POLICY_HOLD", Convert.ToBoolean(ddlDecisionDetailsIsPolicyPrintingToHolding.SelectedValue), objChangeObj.userLoginDetails._UserID, "THA", objChangeObj.userLoginDetails._UserID.Substring(1), "THA", "UnderWriting", "Saral UnderWriting", "INSERT", ref intResp);
            }
        }
    }
    /*ID:16 End*/
    private void Binddistance(DataTable dt)
    {
        Label5.Text = string.Empty;
        if (dt != null && dt.Rows.Count > 0 && (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Distance1"])) || !string.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[0]["Distance1"]))))
        {
            txtdistance.Text = Convert.ToString(dt.Rows[0]["Distance1"]);

            /*ID:9 END*/
        }
        else
        {
            Label5.Text = "Distance not available, as branch code is not found";
        }


        //if (dt != null && dt.Rows.Count > 0)
        //{
        //    txtdistance.Text = Convert.ToString(dt.Rows[0]["Distance1"]);


        //    /*ID:9 END*/
        //}
    }

    private void DeleteExistingLoading(string strAppno, string strRiderId, string strLoadingType, ref int response)
    {
        Commfun objCommfun = new Commfun();
        objCommfun.DeleteExistingLoading(strAppno, strRiderId, strLoadingType, ref response);
    }

    private void BindUwHint(DataTable _dt)
    {
        if (_dt != null && _dt.Rows.Count > 0)
        {
            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                FillHintMessage(Convert.ToString(_dt.Rows[i]["Id"]));
            }
        }
        DisplaySaralHintMessage();
    }

    private void FillHintMessage(string strInput)
    {
        string strPipe = "|";
        hdnHintMessage.Value = hdnHintMessage.Value + strInput + strPipe;
    }

    private void DisplaySaralHintMessage()
    {
        WarningMessage objWarning = new WarningMessage();
        lblUwSaralHintMessage.Text = objWarning.SetMessage(hdnHintMessage.Value.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries));
    }
    protected void btnSearchCode_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('REQ_SearchCode.aspx','mywindow','menubar=1,resizable=1,width=900,height=600');", true);
    }
    protected void btnUpadteBMI_Click(object sender, EventArgs e)
    {
        Label5.Text = string.Empty;
        if (!txtHeight.Text.All(c => Char.IsNumber(c)) || !txtWeight.Text.All(c => Char.IsNumber(c)))
        {
            Label5.Text = "Please enter numeric only";
            return;
        }
        else
        {
            try
            {
                DataSet _dsbmiData = new DataSet();
                objcomm.CalculateBMI(ref _dsbmiData, strApplicationno, strChannelType, txtHeight.Text.Trim(), txtWeight.Text.Trim());
                if (_dsbmiData.Tables.Count > 0 && _dsbmiData.Tables[0].Rows.Count > 0 && _dsbmiData.Tables[0].Rows[0]["DATA"] != null)
                {
                    txtSaralRiskBmi.Text = Convert.ToString(_dsbmiData.Tables[0].Rows[0]["DATA"]);
                    Label5.Text = Convert.ToString("BMI updated successfully");
                }
                upSaralRiskParameter.Update();
            }
            catch (Exception ex)
            {
                Label5.Text = Convert.ToString("Please try again later");
            }
        }

    }

    //ADDED BY AJAY SAHU
    //public void BindPreviousPolictDetailsSaral(DataTable _dsPrev)
    //{
    //    //_dsPrev.Columns.Remove("stat");
    //    //_dsPrev.Columns.Remove("ageProofSubmitted");
    //    //_dsPrev.Columns.Remove("idProofSubmitted");
    //    //_dsPrev.Columns.Remove("addressProofSubmitted");
    //    //_dsPrev.Columns.Remove("incomeProofSubmitted");
    //    //_dsPrev.Columns.Remove("underwriterComments");
    //    if (_dsPrev.Rows.Count > 0)
    //    {
    //        divPrePolicySaral.Visible = true;
    //        gridPrevPolSaral.DataSource = _dsPrev;
    //        gridPrevPolSaral.DataBind();

    //    }
    //    else
    //    {
    //        divPrePolicySaral.Visible = false;
    //        lblErrorPrevpolSaral.Text = "No Previous Policy Details found";
    //    }
    //}

    //public void BindTsarMsarDetailsSaral(DataTable _dsTsarMsarDtls)
    //{
    //    if (_dsTsarMsarDtls.Rows.Count > 0)
    //    {
    //        GridMsarTsarSaral.DataSource = _dsTsarMsarDtls;
    //        GridMsarTsarSaral.DataBind();
    //    }

    //}

    //END

    //protected void btnMedDataentry_Click(object sender, EventArgs e)
    //{
    //    // ClientScript.RegisterStartupScript(Page.GetType(), "", "window.open('Appcode/MedicalDataEntryNew.aspx');", true);
    //    ///Response.Redirect(string.Format("MedicalDataEntryNew.aspx?qsAppNo={0}&qsPolicyNo={1}", strApplicationno, strPolicyNo),false);
    //    Response.Redirect("MedicalDataEntryNew.aspx?qsAppNo="+ strApplicationno + "&qsPolicyNo="+ strPolicyNo + "");
    //}

    protected void btnMedDataentry_Click1(object sender, EventArgs e)
    {
        //string pageurl = "MedicalDataEntryNew.aspx?qsAppNo=" + strApplicationno + "&qsPolicyNo="+ strPolicyNo;
        //Response.Write(String.Format("window.open('{0}','_blank')", ResolveUrl(pageurl)));

        //Response.Write("< script > window.open( 'MedicalDataEntryNew.aspx', '_blank'); </ script >");
        //Response.End();
        //Page.ClientScript.RegisterStartupScript(this.GetType(), "openlink", "window.open('" + url + "');   window.location.href = '~/Appcode/Uwdecision.aspx'", true);
        //Response.Redirect(string.Format("~/Appcode/MedicalDataEntryNew.aspx?qsAppNo={0}&qsPolicyNo={1}", strApplicationno, strPolicyNo), false);
        //btnMedDataentry.Attributes.Add("OnClick", "OpenPage('" + url + "');");
        string url = "MedicalDataEntry.aspx?qsAppNo=" + strApplicationno + "&qsPolicyNo=" + strPolicyNo;
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('" + url + "');", true);
        //Response.Redirect("MedicalDataEntryNew.aspx");
    }

    /*ID:24 START*/
    protected void btnPlvcVideo_Click(object sender, EventArgs e)
    {
        string url = ConfigurationManager.AppSettings["PlvcVideo"];
        //url = url + UWSaralDecision.CommFun.Base64EncodingMethod(txtAppno.Text);
        url = url + UWSaralDecision.CommFun.Base64EncodingMethod(strAppno);
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('" + url + "');", true);
    }
    /*ID:24 END*/
    protected void BindVideoMER()
    {
        try
        {
            string Sourcepath = ConfigurationManager.AppSettings["TPASourcePath"];

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(Sourcepath);
            request.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.CacheIfAvailable);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.Credentials = new NetworkCredential("AUX_FTP", "password@1");
            request.KeepAlive = false;
            request.UseBinary = true;
            request.UsePassive = true;
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);


            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(Sourcepath);
            int count = dir.GetFiles().Length;
            //DateTime dt = File.GetLastWriteTime(Sourcepath);
            List<string> files = DirSearch(Sourcepath);
            string StrFileName = string.Empty;
            string StrconcateFileName = string.Empty;
            //string CopyFolder =  @"D:\VideoMER";
            DataTable dt = new DataTable();
            //DataRow dr = dt.NewRow();
            dt.Columns.Add("Application", typeof(string));
            dt.Columns.Add("Date", typeof(DateTime));
            //table.Columns.Add("remainingUpload", typeof(string));

            if (Directory.Exists(Sourcepath))
            {
                for (int i = 0; i < files.Count; i++)
                {
                    DateTime date = File.GetLastWriteTime(files[i]);
                    DataRow dr = dt.NewRow();
                    StrFileName = System.IO.Path.GetFileName(files[i]);
                    StrconcateFileName = StrconcateFileName + " " + StrFileName;
                    //string filepath = Sourcepath +"\\"+ StrFileName;
                    //string strFullFile = Path.Combine(Sourcepath, StrFileName);
                    //FileInfo objfileinfo = null;
                    //objfileinfo = new FileInfo(strFullFile);

                    if (StrFileName.Contains(strApplicationno))
                    {
                        dr["Application"] = StrFileName;
                        dr["Date"] = date;
                        dt.Rows.Add(dr);
                        //objfileinfo.CopyTo(CopyFolder + "\\" + StrFileName, true);
                    }

                }
                //if (StrconcateFileName.Contains(strApplicationno))
                //{

                if (dt.Rows.Count > 0)
                {
                    gvVideoMer.DataSource = dt;
                    gvVideoMer.DataBind();
                }
                else
                {
                    gvVideoMer.DataSource = null;
                    gvVideoMer.DataBind();
                    lblVideoMER.Text = "VideoMER is not available.";
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;//Logger.Info(strApplicationno + "STAG3:-Function Call BINDVIDEOMER" + " : " + ex + System.Environment.NewLine);
        }
    }
    private List<String> DirSearch(string sDir)
    {
        List<String> files = new List<String>();
        try
        {
            foreach (string f in Directory.GetFiles(sDir))
            {
                files.Add(f);
            }
            foreach (string d in Directory.GetDirectories(sDir))
            {
                files.AddRange(DirSearch(d));
            }
        }
        catch (System.Exception excpt)
        {
            //MessageBox.Show(excpt.Message);
        }

        return files;
    }

    protected void gvVideoMer_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            //Determine the RowIndex of the Row whose LinkButton was clicked.
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            string Sourcepath = ConfigurationManager.AppSettings["TPASourcePath"];
            GridViewRow row = gvVideoMer.Rows[rowIndex];
            string name = (row.FindControl("lnlApp") as LinkButton).Text;
            name = name.Split('.')[0] + ".mp4";
            //LinkButton lnkname = row.FindControl("lnlApp") as LinkButton;
            //lnkname.Attributes.Add("href", "TESTPAGE.aspx");
            //lnkname.Attributes.Add("target", "_blank");
            string file = Sourcepath + "\\" + name;

            string PushedtoDMS = string.Empty;
            string Serverpath = string.Empty;
            if (File.Exists(file))
            {

                FileInfo objfileinfo = null;
                objfileinfo = new FileInfo(file);


                PushedtoDMS = HttpContext.Current.Server.MapPath("~/Video\\" + name);

                string virtualPath = ConfigurationManager.AppSettings["VirtualPath"].ToString();
                Serverpath = virtualPath + name;

                if (!File.Exists(PushedtoDMS))
                {
                    objfileinfo.CopyTo(PushedtoDMS, true);
                }
            }
            //PushedtoDMS = "..//Video//" + name;
            // url = UWSaralDecision.CommFun.Base64EncodingMethod(Serverpath);
            string url = UWSaralDecision.CommFun.Base64EncodingMethod(PushedtoDMS);

            // string url = "Popup.aspx";
            //string s = "window.open('" + file + "', 'popup_window', 'width=300,height=100,left=100,top=100,resizable=yes');";
            //ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
            //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( '" + url + "', null, 'height=700,width=760,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);

            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( '../Appcode/result.aspx?path=" + url + "', null, 'height=700,width=760,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
            //Response.Redirect("/Appcode/result.aspx?path = " + file);
            //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( 'http://www.stackoverflow.com', null, 'height=700,width=760,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
        }
    }
    protected void BindMedicalDELink(DataTable _dt)
    {
        if (_dt != null && _dt.Rows.Count > 0)
        {
            btnMedDataentry.BackColor = System.Drawing.Color.Green;
            btnMedDataentry.ForeColor = System.Drawing.Color.White;
            btnMedDataentry.Font.Bold = true;
        }

    }

    //protected void btnYes_Click(object sender, EventArgs e)
    //{
    //    strLApushErrorCode = -1;
    //    Master.masterCallEvent += new EventHandler(btnServerValidation);
    //}

    protected void OfacService()
    {
        objUWDecision.OnlineApplicationLAServiceDetails_PUSH(strApplicationno, strChannelType, objChangeObj, ref _ds, ref _dsPrevPol, "OFAC", ref strLApushErrorCode, ref strLApushStatus, ref strConsentRespons);
        if (strLApushErrorCode == 0)
        {
            //Commented by Suraj on 18-SEP-2019 for CR NO-27647
            //FillWarningMessage("66");
            //DisplaySaralWarningMessage();

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "ShowModalPopupOFAC('This is OFAC case, Please confirm whether you have to proceed further or not!!');", true);
            //throw new Exception("UDE-Please confirm, Are you sure you want to continue?");
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "ShowModalPopup('" + alertMessage + "');", true);
        }
    }
    /*ID:27 START*/
    public void MedicalDE_Mandatory()
    {
        DataSet _ds = new DataSet();
        objcomm.Get_MedicalStatus_Dataentry(ref _ds, strApplicationno);
        if (_ds != null && _ds.Tables.Count > 0 && _ds.Tables[0].Rows.Count > 0)
        {
            if (_ds.Tables[1].Rows.Count > 0)
            {
                btnMedDataentry.Visible = true;
                lblMedicalDE.Visible = false;
                lblMedicalDE.Text = "";
            }
            else
            {
                btnMedDataentry.Visible = false;
                lblMedicalDE.Visible = true;
                lblMedicalDE.Text = "Medical Data Entry not available.";
            }

        }

    }
    /*ID:27 END*/
    private void GetMEdicalComment(ref DataSet _dsMedical)
    {
        //DataSet _dsMedical = new DataSet();
        objcomm.Get_MedicalStatus_Dataentry(ref _dsMedical, strApplicationno);
        //if (_dsMedical != null && _dsMedical.Tables.Count > 1 && _dsMedical.Tables[2].Rows.Count > 0 && _dsMedical.Tables[1].Rows.Count > 0)
        if (_dsMedical != null && _dsMedical.Tables.Count > 1 && _dsMedical.Tables[2].Rows.Count > 0)
        {
            IsMedicalDE = true;
        }

        //else
        //{
        //    IsMedicalDE = false;
        //}
    }
    //Added by Suraj for reinsurer comments
    protected void btnReinsurer_Click(object sender, EventArgs e)
    {
        try
        {
            AutoComment objReinsurerComment = new AutoComment();
            objBuss = new BussLayer();
            objBuss.FetchAutoCommentDetails(strApplicationno, strChannelType, ref _ds);
            BindReinsurerCommentSection(objReinsurerComment, _ds);
            objUWDecision.OnlineApplicationLAServiceDetails_PUSH(strApplicationno, strChannelType, objChangeObj, ref dsMSAR, ref _dsPrevPol, "MSAR", ref strLApushErrorCode, ref strLApushStatus, ref strConsentRespons);
            BindSarDetails(objReinsurerComment, dsMSAR);
            txtUWComments.Value = objReinsurerComment.ReinsurerSummaryComment;
        }
        catch (Exception ex)
        {

        }
        finally
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "disp_confirm", "<script>hideloading()</script>", false);
        }
    }
    //Added by Suraj for reinsurer comments
    private void BindReinsurerCommentSection(AutoComment objReinsuComment, DataSet _ds)
    {
        if (_ds != null && _ds.Tables.Count > 0 && _ds.Tables[0].Rows.Count > 0 && _ds.Tables[3].Rows.Count > 0)
        {
            objReinsuComment.TotalPremium = Convert.ToString(_ds.Tables[0].Rows[0]["TOTAL_PREMIUM"]);
            objReinsuComment.NameOfLa = Convert.ToString(_ds.Tables[3].Rows[0]["LA_NAME"]);
            objReinsuComment.Gender = Convert.ToString(_ds.Tables[3].Rows[0]["GENDER"]);
            objReinsuComment.Age = Convert.ToString(_ds.Tables[3].Rows[0]["AGE"]);
            //objAutoComment.Education = Convert.ToString(_ds.Tables[0].Rows[0]["EDUCATION"]);
            objReinsuComment.Occupation = Convert.ToString(_ds.Tables[3].Rows[0]["OCCUPATION"]);
            objReinsuComment.AnnualIncome = Convert.ToString(_ds.Tables[3].Rows[0]["ANNUAL_INCOME"]);
            //objAutoComment.Nominee = Convert.ToString(_ds.Tables[0].Rows[0]["NOMINEE_RELATION"]);
            objReinsuComment.Nominee = Convert.ToString(_ds.Tables[3].Rows[0]["PROPOSER_RELATION"]);
            objReinsuComment.Proposer = Convert.ToString(_ds.Tables[0].Rows[0]["PROPOSAR_NAME"]);
            //objAutoComment.Bmi = Convert.ToString(_ds.Tables[0].Rows[0]["BMI"]);
            //objAutoComment.NatureOfDuty = Convert.ToString(_ds.Tables[0].Rows[0]["NATURE_OF_DUTY"]);
            //objAutoComment.TypeOfIncomeProof = Convert.ToString(_ds.Tables[0].Rows[0]["INCOME_PROOF"]);
            //objAutoComment.IdProof = Convert.ToString(_ds.Tables[0].Rows[0]["ID_PROOF"]);
            //objAutoComment.AddressProof = Convert.ToString(_ds.Tables[0].Rows[0]["ADDR_PROOF"]);
            //objAutoComment.AgeProof = Convert.ToString(_ds.Tables[0].Rows[0]["AGE_PROOF"]);
            //objAutoComment.FamilyHistory = Convert.ToString(_ds.Tables[0].Rows[0]["FAMILY_HISTORY"]);
            //objAutoComment.PersonalMedicalHistory = Convert.ToString(_ds.Tables[0].Rows[0]["PERSONAL_MEDICAL_HISTORY"]);
            //Added by Ajay sahu for auto comment format
            objReinsuComment.PlanName = Convert.ToString(_ds.Tables[0].Rows[0]["PLAN_NAME"]);
            objReinsuComment.SumAssured = Convert.ToString(_ds.Tables[0].Rows[0]["SUM_ASSURED"]);
            objReinsuComment.PolicyTerm = Convert.ToString(_ds.Tables[0].Rows[0]["POLICY_TERM"]);
            objReinsuComment.PolicyPayingTerm = Convert.ToString(_ds.Tables[0].Rows[0]["PLOLICY_PAYING_TERM"]);
            objReinsuComment.MaritualStatus = Convert.ToString(_ds.Tables[3].Rows[0]["MARITAL_STATUS"]);
            //objAutoComment.BranchCode = Convert.ToString(_ds.Tables[0].Rows[0]["BRANCH_CODE"]);
            objReinsuComment.RiskScore = Convert.ToString(_ds.Tables[0].Rows[0]["RISK_SCORE"]);
            objReinsuComment.EYRiskScore = Convert.ToString(_ds.Tables[0].Rows[0]["ENY_VALUE"]);
            objReinsuComment.IIBRiskScore = Convert.ToString(_ds.Tables[0].Rows[0]["IIB_SCORE"]);
            //objAutoComment.ChannelName = Convert.ToString(_ds.Tables[0].Rows[0]["CHANNEL_NAME"]);
            string existsins = string.Empty;
            if (_ds.Tables.Count > 0 && _ds.Tables[1].Rows.Count > 0)
            {
                for (int i = 0; i < _ds.Tables[1].Rows.Count; i++)
                {
                    var stringArr = _ds.Tables[1].Rows[i].ItemArray.Select(x => x.ToString()).ToArray();
                    existsins += Environment.NewLine + string.Join("/", stringArr.ToArray());

                }
            }
            objReinsuComment.ExistingIns = existsins;
            //Added by suraj on 04/09/2018 as discussed with shabbir sir -display total SA(existing insurance+current) for HHI and Non HHI in auto comment
            //if (_ds.Tables.Count > 2 && _ds.Tables[2].Rows.Count > 0)
            //{
            //    objAutoComment.TOTALSA_HHI = Convert.ToString(_ds.Tables[2].Rows[0]["HHI_TSA"]);
            //    objAutoComment.TOTALSA_NON_HHI = Convert.ToString(_ds.Tables[2].Rows[0]["NON_HHI_TSA"]);
            //}
        }
    }
    /*
    private void BindIIBScore(DataTable dt)
    {
        txtIIBScore.ToolTip = txtIIBScore.Text = Convert.ToString(dt.Rows[0]["IIB_SCORE"]);
        if (Convert.ToInt32(txtIIBScore.Text) >= 800)
        {

            txtIIBScore.BackColor = System.Drawing.Color.Red;
            txtIIBScore.ForeColor = System.Drawing.Color.White;
        }
        else
        {
            txtIIBScore.BackColor = System.Drawing.Color.Green;
            txtIIBScore.ForeColor = System.Drawing.Color.White;
        }

    }
    */
    //added by suraj bhamre on 18 OCT 2019 for show loan amt and loan type text box on selecting loan ac holder relation of la with Au bank		
    protected void ddlrelaAU_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlrelaAU.SelectedValue.Equals("2"))
        {
            txtLoantype.Attributes["class"] = txtLoantype.Attributes["class"].ToString().Replace("lblLable", "");
            txtLoanAmt.Attributes["class"] = txtLoanAmt.Attributes["class"].ToString().Replace("lblLable", "");
            //divPanDetails.Style.Add("display", "none"); 		
        }
        else
        {
            txtLoantype.CssClass = "form-control lblLable";
            txtLoanAmt.CssClass = "form-control lblLable";
        }
    }
    //added by suraj bhamre on 18 OCT 2019 for save Au bank relation details in db		
    private void AUBankRelationSave()
    {
        int resp = 0;
        string strBankRelation = string.Empty;
        string strCustmrcata = string.Empty;
        if (!ddlrelaAU.SelectedItem.Text.Equals("--Select--"))
        {
            strBankRelation = ddlrelaAU.SelectedItem.Text;
        }
        if (!ddlCustCat.SelectedItem.Text.Equals("--Select--"))
        {
            strCustmrcata = ddlCustCat.SelectedItem.Text;
        }
        objBuss.Save_AUBankRelation(strBankRelation, txtLoantype.Text, txtLoanAmt.Text, strCustmrcata, txtacctdt.Text, strAppno, strUserId, ref resp);
    }
    //added by suraj bhamre on 18 OCT 2019 for bind AU bank relation details		
    public void BindAURelationDetails(DataTable dtAUreladetail)
    {
        if (ddlrelaAU.Items.FindByValue(Convert.ToString(dtAUreladetail.Rows[0]["Relation_LA_Bank"])) != null)
        {
            ddlrelaAU.ClearSelection();
            ddlrelaAU.Items.FindByValue(Convert.ToString(dtAUreladetail.Rows[0]["Relation_LA_Bank"])).Selected = true;
        }
        if (ddlCustCat.Items.FindByValue(Convert.ToString(dtAUreladetail.Rows[0]["Customer_Category"])) != null)
        {
            ddlCustCat.ClearSelection();
            ddlCustCat.Items.FindByValue(Convert.ToString(dtAUreladetail.Rows[0]["Customer_Category"])).Selected = true;
        }
        txtLoanAmt.Text = Convert.ToString(dtAUreladetail.Rows[0]["Loan_Amount"]);
        txtLoantype.Text = Convert.ToString(dtAUreladetail.Rows[0]["Loan_Type"]);
        txtacctdt.Text = Convert.ToString(dtAUreladetail.Rows[0]["Account_Opening_date"]);
    }
    protected void GetAUCaes()
    {
        DataSet _dsAUCase = new DataSet();
        objBuss.GetAUBankCases(txtAgentcode.Text, ref _dsAUCase);
        if (_dsAUCase != null && _dsAUCase.Tables.Count > 0 && _dsAUCase.Tables[0].Rows.Count > 0 && Convert.ToString(_dsAUCase.Tables[0].Rows[0]["IsAUCase"]) != "")
        {
            DataTable dtreq = new DataTable();
            dtreq = (DataTable)ViewState["CurrentTable1"];
            //string strSignaturecode = ConfigurationManager.AppSettings["SignatureCode"];
            DataView dv = new DataView(dtreq);
            dv.RowFilter = "(REQ_followUpCode = 'FHR' OR REQ_followUpCode = 'MHM') and REQ_status = 'R'";
            //dv.RowFilter = "REQ_status = 'R'";
            if (dv.Count != 0)
            {
                divAURela.Attributes["class"] = divAURela.Attributes["class"].ToString().Replace("HideControl", "");
            }
        }
        else
        {
            divAURela.Attributes["class"] = divAURela.Attributes["class"] + " HideControl";
        }

    }
    //Added by suraj on 05 DEC 2019 for show CIBIL report
    protected void btnCIBIL_Click(object sender, EventArgs e)
    {
        if (Session["objLoginObj"] != null)
        {
            objChangeObj = (ChangeValue)Session["objLoginObj"];
        }
        //DataSet _dsPincode = new DataSet();
        //objBuss.GetMasterPincode(strApplicationno, ref _dsPincode);
        //if (_dsPincode != null && _dsPincode.Tables.Count > 0 && _dsPincode.Tables[0].Rows.Count == 0)
        //{
        //    ShowPopupMessage("This Please enter pincode!!");
        //    throw new Exception("UDE-Please raise requirement code 'SEN', if alresdy exists then change status to Received or Waived!!");
        //}
        //if (_dsPincode !=null && _dsPincode.Tables.Count > 0 && _dsPincode.Tables[0].Rows.Count > 0)
        //{
        objUWDecision.OnlineApplicationLAServiceDetails_PUSH(strApplicationno, strChannelType, objChangeObj, ref dsMSAR, ref _dsPrevPol, "CIBIL", ref strLApushErrorCode, ref strLApushStatus, ref strConsentRespons);

        //}
        //else
        //{
        //
        //}
        //ShowHideLoader("Show", "");
        //Response.Redirect("~/Appcode/Uwdecision.aspx");
        //40.1 start of Changes; Sagar Thorave-[mfl00886]
        DataSet dsCibil = new DataSet();
        objcomm.GetCiBilScore(ref dsCibil, strApplicationno, strChannelType);
        if (!string.IsNullOrEmpty(Convert.ToString(dsCibil.Tables[0].Rows[0]["CIBIL_SCORE"])))
        {
            txtApplicationDetailsCibil.Text = Convert.ToString(dsCibil.Tables[0].Rows[0]["CIBIL_SCORE"]).TrimStart(new Char[] { '0' });
        }
        else
        {
            txtApplicationDetailsCibil.Text = strCIBILScore;
        }

        if (!string.IsNullOrWhiteSpace(txtApplicationDetailsCibil.Text))
        {
            if (Convert.ToInt32(txtApplicationDetailsCibil.Text) >= 600)
            {
                txtApplicationDetailsCibil.BackColor = System.Drawing.Color.Green;
                txtApplicationDetailsCibil.ForeColor = System.Drawing.Color.White;
            }
            else
            {
                txtApplicationDetailsCibil.BackColor = System.Drawing.Color.Red;
                txtApplicationDetailsCibil.ForeColor = System.Drawing.Color.White;
            }

        }
        txtincomeest.Text = dsCibil.Tables[0].Rows[0]["INCOME_ESTIMATOR"].ToString();

        DataSet _dsstate = new DataSet();
        DataSet _dsIsClient = new DataSet();
        DataSet _dsPrevstatus = new DataSet();
        objcomm.FetchBranchState(ref _dsstate, strApplicationno);
        string strbranchstate = string.Empty;
        string strcuststate = string.Empty;
        string strCustPincode = string.Empty;
        string strBranchPincode = string.Empty;

        if (_dsstate.Tables.Count > 0)
        {
            if (_dsstate.Tables[0].Rows.Count > 0)
            {
                strbranchstate = Convert.ToString(_dsstate.Tables[0].Rows[0]["STATE"]).ToUpper().TrimEnd();
                strBranchPincode = Convert.ToString(_dsstate.Tables[0].Rows[0]["BranchPincode"]).ToUpper().TrimEnd();
                strBranchPincode = new string(strBranchPincode.Take(3).ToArray());
            }
            if (_dsstate.Tables[1].Rows.Count > 0)
            {
                strcuststate = Convert.ToString(_dsstate.Tables[1].Rows[0]["ADR_state"]).ToUpper().TrimEnd();
                strCustPincode = Convert.ToString(_dsstate.Tables[1].Rows[0]["CustPincode"]).ToUpper().TrimEnd();
                strCustPincode = new string(strCustPincode.Take(3).ToArray());
            }
            //For Term product with Salaried
            if (_dsstate.Tables[7].Rows.Count > 0)
            {

                if (!string.IsNullOrWhiteSpace(txtApplicationDetailsCibil.Text))
                {
                    if (Convert.ToInt32(txtApplicationDetailsCibil.Text) >= 650)
                    {
                        txtApplicationDetailsCibil.BackColor = System.Drawing.Color.Green;
                        txtApplicationDetailsCibil.ForeColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        txtApplicationDetailsCibil.BackColor = System.Drawing.Color.Red;
                        txtApplicationDetailsCibil.ForeColor = System.Drawing.Color.White;
                    }
                }

            }

            //For BFL cases
            if (_dsstate.Tables[9].Rows.Count > 0)
            {

                if (!string.IsNullOrWhiteSpace(txtApplicationDetailsCibil.Text))
                {
                    if (Convert.ToInt32(txtApplicationDetailsCibil.Text) >= 600)
                    {
                        txtApplicationDetailsCibil.BackColor = System.Drawing.Color.Green;
                        txtApplicationDetailsCibil.ForeColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        txtApplicationDetailsCibil.BackColor = System.Drawing.Color.Red;
                        txtApplicationDetailsCibil.ForeColor = System.Drawing.Color.White;
                    }
                }
                //else
                //{
                //    txtApplicationDetailsCibil.BackColor = System.Drawing.Color.Red;
                //    txtApplicationDetailsCibil.ForeColor = System.Drawing.Color.White;
                //}
            }
            //For Amex cases or For Term product except salaried
            if (_dsstate.Tables[8].Rows.Count > 0 || _dsstate.Tables[10].Rows.Count > 0)
            {

                if (!string.IsNullOrWhiteSpace(txtApplicationDetailsCibil.Text) && Convert.ToInt32(txtApplicationDetailsCibil.Text) >= 700)
                {
                    if (Convert.ToInt32(txtApplicationDetailsCibil.Text) >= 700)
                    {
                        txtApplicationDetailsCibil.BackColor = System.Drawing.Color.Green;
                        txtApplicationDetailsCibil.ForeColor = System.Drawing.Color.White;

                    }
                    else
                    {
                        txtApplicationDetailsCibil.BackColor = System.Drawing.Color.Red;
                        txtApplicationDetailsCibil.ForeColor = System.Drawing.Color.White;
                    }


                }
                //else
                //{
                //    txtApplicationDetailsCibil.BackColor = System.Drawing.Color.Red;
                //    txtApplicationDetailsCibil.ForeColor = System.Drawing.Color.White;
                //}
            }
        }
        if (!string.IsNullOrWhiteSpace(txtApplicationDetailsCibil.Text))
        {
            if (Convert.ToInt32(txtApplicationDetailsCibil.Text) == -1)
            {
                txtApplicationDetailsCibil.BackColor = System.Drawing.Color.White;
                txtApplicationDetailsCibil.ForeColor = System.Drawing.Color.Black;
            }
        }

        //40.1 End of Changes; Sagar Thorave-[mfl00886]
    }
    /*
    public void BindCIBILScore(DataTable dtCIBIL)
    {
        
        txtApplicationDetailsCibil.Text = Convert.ToString(dtCIBIL.Rows[0]["CIBILScore"]);
        txtincomeest.Text = Convert.ToString(dtCIBIL.Rows[0]["Income"]);
        
    }
    */

    //Start changes to Shweta Mamilwar
    public void getFGData()
    {
        string strEnvironment = System.Configuration.ConfigurationManager.AppSettings["Environment"].ToString();

        #region Start 38.1: This CR-2809 changes done by Sushant Devkate MFL00905 
        IIBQueryDataDO ObjIIBQueryDataDOForDE = objComm.getFGDataShowDE_new(strApplicationno, "DE");

        IIBQueryDataDO ObjIIBQueryDataDOUW = objComm.getFGDataShow_Impact_New(strApplicationno, "UW");

        btnFetchIIBQuery.Enabled = true;

        if (ObjIIBQueryDataDOUW.ObjListOFQueryFG.Count > 0 || ObjIIBQueryDataDOUW.ObjListOFQueryOther.Count > 0)
        {
            BindGridforIIB(ObjIIBQueryDataDOUW, 1);
        }
        else if (ObjIIBQueryDataDOForDE.ObjListOFQueryFG.Count > 0 || ObjIIBQueryDataDOForDE.ObjListOFQueryOther.Count > 0)
        {
            BindGridforIIB(ObjIIBQueryDataDOForDE, 2);

            if (ObjIIBQueryDataDOForDE.ObjListOFQueryFG != null && ObjIIBQueryDataDOForDE.ObjListOFQueryOther != null)
            {
                if (ObjIIBQueryDataDOForDE.ObjListOFQueryFG.Count > 0 || ObjIIBQueryDataDOForDE.ObjListOFQueryOther.Count > 0)
                {
                    btnFetchIIBQuery.Enabled = strEnvironment == "UAT" ? true : false;
                }
            }
        }
        #endregion End 38.1: This CR-2809 changes done by Sushant Devkate MFL00905 

    }
    protected void btnFetchIIBQuery_Click_OLD(object sender, EventArgs e)
    {
        //try
        //{
        //    objComm.IIBLogtable(txtAppno.Text, "btnFetchIIBQuery_Click_starts_01", "", "", "", "", "", "UW", "", "", "IIB query button clicked on UW Decision page");
        //    List<multiplexml> mxml = new List<multiplexml>();
        //    DataSet dt = objComm.FetchIIBData(txtAppno.Text);
        //    if (dt.Tables[0].Rows.Count > 0)
        //    {
        //        objComm.IIBLogtable(txtAppno.Text, "btnFetchIIBQuery_Click_starts_02", "", "", "", "", "", "UW", "", "", "");
        //        for (int i = 0; i < dt.Tables[0].Rows.Count; i++)
        //        {
        //            if (dt.Tables[0].Rows[i]["CLT_assuredType"].ToString() == "LA")
        //            {
        //                objComm.IIBLogtable(txtAppno.Text, "btnFetchIIBQuery_Click_starts_03_LA", "", "", "", "", "", "UW", "", "", "");
        //                multiplexml cxml = new multiplexml();
        //                cxml.Policy_Number = dt.Tables[0].Rows[i]["CLT_applicationNo"].ToString();
        //                cxml.Proposal_Number = dt.Tables[0].Rows[i]["CLT_applicationNo"].ToString();
        //                cxml.Query_Type = "1";
        //                cxml.DoP_DoC = Convert.ToDateTime(txtAppsigndate.Text).ToString("yyyy-MM-dd");//txtAppSignDate.Text
        //                cxml.Sum_Assured = ViewState["SA"].ToString();//txtSumassure.Text;
        //                cxml.LA_First_Name = dt.Tables[0].Rows[i]["CLT_firstName_LGIVNAME"].ToString();
        //                cxml.LA_Middle_Name = "";
        //                cxml.LA_Last_Name = dt.Tables[0].Rows[i]["CLT_lastName_LSURNAME"].ToString();
        //                cxml.LA_DoB = Convert.ToDateTime(dt.Tables[0].Rows[i]["CLT_dob_CLTDOBX"].ToString()).ToString("yyyy-MM-dd");
        //                cxml.LA_Gender = dt.Tables[0].Rows[i]["CLT_gender_CLTSEX"].ToString();
        //                cxml.LA_Current_Address = dt.Tables[0].Rows[i]["LA_Current_Address"].ToString();//"";
        //                cxml.LA_Permanent_Address = dt.Tables[0].Rows[i]["LA_Current_Address"].ToString();//"";
        //                cxml.LA_Pin_Code = dt.Tables[0].Rows[i]["ADR_pinCode_CLTPCODE"].ToString();
        //                cxml.LA_PAN = dt.Tables[0].Rows[i]["CLT_panId_RTAXIDNUM"].ToString();//"BABPK3030L"; //"ASUPK5335L";         //"BABPK3030L";
        //                cxml.LA_Aadhar = "";
        //                cxml.LA_Ckyc = "";
        //                cxml.LA_Passport = "";
        //                cxml.LA_DL = "";
        //                cxml.LA_Voter_Id = "";
        //                cxml.LA_Phone_Number_1 = dt.Tables[0].Rows[i]["ADR_mobileNo_MBLPHONE"].ToString();//"";
        //                cxml.LA_Phone_Number_2 = dt.Tables[0].Rows[i]["ADR_phone1_CLTPHONE01"].ToString();//"";
        //                cxml.LA_Email_1 = dt.Tables[0].Rows[i]["ADR_emailId_RINTERNET"].ToString();//"";
        //                cxml.LA_Email_2 = "";
        //                cxml.Date_of_Death = "";
        //                cxml.type = "LA";
        //                mxml.Add(cxml);
        //            }
        //            else if (dt.Tables[0].Rows[i]["CLT_assuredType"].ToString() == "proposer")
        //            {
        //                objComm.IIBLogtable(txtAppno.Text, "btnFetchIIBQuery_Click_starts_03_proposer", "", "", "", "", "", "UW", "", "", "");
        //                multiplexml cxml = new multiplexml();
        //                cxml.Policy_Number = dt.Tables[0].Rows[i]["CLT_applicationNo"].ToString();
        //                cxml.Proposal_Number = dt.Tables[0].Rows[i]["CLT_applicationNo"].ToString();
        //                cxml.Query_Type = "1";
        //                cxml.DoP_DoC = Convert.ToDateTime(dt.Tables[0].Rows[i]["bpm_creationDate"].ToString()).ToString("yyyy-MM-dd");//txtAppSignDate.Text
        //                cxml.Sum_Assured = ViewState["SA"].ToString(); //txtSumassure.Text;
        //                cxml.LA_First_Name = dt.Tables[0].Rows[i]["CLT_firstName_LGIVNAME"].ToString();
        //                cxml.LA_Middle_Name = "";
        //                cxml.LA_Last_Name = dt.Tables[0].Rows[i]["CLT_lastName_LSURNAME"].ToString();
        //                cxml.LA_DoB = Convert.ToDateTime(dt.Tables[0].Rows[i]["CLT_dob_CLTDOBX"].ToString()).ToString("yyyy-MM-dd");
        //                cxml.LA_Gender = dt.Tables[0].Rows[i]["CLT_gender_CLTSEX"].ToString();
        //                cxml.LA_Current_Address = dt.Tables[0].Rows[i]["LA_Current_Address"].ToString();//"";
        //                cxml.LA_Permanent_Address = dt.Tables[0].Rows[i]["LA_Current_Address"].ToString();//"";
        //                cxml.LA_Pin_Code = dt.Tables[0].Rows[i]["ADR_pinCode_CLTPCODE"].ToString();
        //                cxml.LA_PAN = dt.Tables[0].Rows[i]["CLT_panId_RTAXIDNUM"].ToString();//"BABPK3030L"; //"ASUPK5335L";         //"BABPK3030L";
        //                cxml.LA_Aadhar = "";
        //                cxml.LA_Ckyc = "";
        //                cxml.LA_Passport = "";
        //                cxml.LA_DL = "";
        //                cxml.LA_Voter_Id = "";
        //                cxml.LA_Phone_Number_1 = dt.Tables[0].Rows[i]["ADR_mobileNo_MBLPHONE"].ToString();//"";
        //                cxml.LA_Phone_Number_2 = dt.Tables[0].Rows[i]["ADR_phone1_CLTPHONE01"].ToString();//"";
        //                cxml.LA_Email_1 = dt.Tables[0].Rows[i]["ADR_emailId_RINTERNET"].ToString();//"";
        //                cxml.LA_Email_2 = "";
        //                cxml.Date_of_Death = "";
        //                cxml.type = "proposer";
        //                mxml.Add(cxml);
        //            }
        //            else if (dt.Tables[0].Rows[i]["CLT_assuredType"].ToString() == "payer")
        //            {
        //                objComm.IIBLogtable(txtAppno.Text, "btnFetchIIBQuery_Click_starts_03_proposer", "", "", "", "", "", "UW", "", "", "");
        //                multiplexml cxml = new multiplexml();
        //                cxml.Policy_Number = dt.Tables[0].Rows[i]["CLT_applicationNo"].ToString();
        //                cxml.Proposal_Number = dt.Tables[0].Rows[i]["CLT_applicationNo"].ToString();
        //                cxml.Query_Type = "1";
        //                cxml.DoP_DoC = Convert.ToDateTime(dt.Tables[0].Rows[i]["bpm_creationDate"].ToString()).ToString("yyyy-MM-dd");//txtAppSignDate.Text                   
        //                cxml.Sum_Assured = ViewState["SA"].ToString(); //txtSumassure.Text;
        //                cxml.LA_First_Name = dt.Tables[0].Rows[i]["CLT_firstName_LGIVNAME"].ToString();
        //                cxml.LA_Middle_Name = "";
        //                cxml.LA_Last_Name = dt.Tables[0].Rows[i]["CLT_lastName_LSURNAME"].ToString();
        //                cxml.LA_DoB = Convert.ToDateTime(dt.Tables[0].Rows[i]["CLT_dob_CLTDOBX"].ToString()).ToString("yyyy-MM-dd");
        //                cxml.LA_Gender = dt.Tables[0].Rows[i]["CLT_gender_CLTSEX"].ToString();
        //                cxml.LA_Current_Address = dt.Tables[0].Rows[i]["LA_Current_Address"].ToString();//"";
        //                cxml.LA_Permanent_Address = dt.Tables[0].Rows[i]["LA_Current_Address"].ToString();//"";
        //                cxml.LA_Pin_Code = dt.Tables[0].Rows[i]["ADR_pinCode_CLTPCODE"].ToString();
        //                cxml.LA_PAN = dt.Tables[0].Rows[i]["CLT_panId_RTAXIDNUM"].ToString();//"BABPK3030L"; //"ASUPK5335L";         //"BABPK3030L";
        //                cxml.LA_Aadhar = "";
        //                cxml.LA_Ckyc = "";
        //                cxml.LA_Passport = "";
        //                cxml.LA_DL = "";
        //                cxml.LA_Voter_Id = "";
        //                cxml.LA_Phone_Number_1 = dt.Tables[0].Rows[i]["ADR_mobileNo_MBLPHONE"].ToString();//"";
        //                cxml.LA_Phone_Number_2 = dt.Tables[0].Rows[i]["ADR_phone1_CLTPHONE01"].ToString();//"";
        //                cxml.LA_Email_1 = dt.Tables[0].Rows[i]["ADR_emailId_RINTERNET"].ToString();//"";
        //                cxml.LA_Email_2 = "";
        //                cxml.Date_of_Death = "";
        //                cxml.type = "payer";
        //                mxml.Add(cxml);
        //            }
        //        }
        //    }
        //    //Call mapping master here in a dataset
        //    DataSet dsmapcode = objComm.MappingMaster("");
        //    List<Employee> list = new List<Employee>();
        //    if (dsmapcode != null && dsmapcode.Tables[0].Rows.Count > 0)
        //    {
        //        var myData = dsmapcode.Tables[0].AsEnumerable().Select(r => new Employee
        //        {
        //            Code = r.Field<string>("Code"),
        //            desc = r.Field<string>("PolicyStatusDesc")
        //        });

        //        list = myData.ToList();
        //    }


        //    DataTable alldt = new DataTable();
        //    //loop the list to create xml depending upon the chkbox and hit that many times and get the data in dataset and merge all 
        //    //if only one dt is created then no extra column added but if 2 or 3 dt created extar column is added of type:LA/Proposer
        //    foreach (var item in mxml)
        //    {
        //        XmlDocument xmldoc = new XmlDocument();
        //        XmlElement queryNode = xmldoc.CreateElement("Query");
        //        queryNode.SetAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
        //        //rootNode.AppendChild(detailsNode);
        //        XmlElement rootNode = xmldoc.CreateElement("Details");

        //        XmlNode userNode = xmldoc.CreateElement("Policy_Number");
        //        userNode.InnerText = item.Policy_Number;
        //        rootNode.AppendChild(userNode);

        //        userNode = xmldoc.CreateElement("Proposal_Number");
        //        userNode.InnerText = item.Proposal_Number;
        //        rootNode.AppendChild(userNode);

        //        userNode = xmldoc.CreateElement("Query_Type");
        //        userNode.InnerText = item.Query_Type;
        //        rootNode.AppendChild(userNode);

        //        userNode = xmldoc.CreateElement("DoP_DoC");
        //        userNode.InnerText = item.DoP_DoC;
        //        rootNode.AppendChild(userNode);

        //        userNode = xmldoc.CreateElement("Sum_Assured");
        //        userNode.InnerText = item.Sum_Assured;
        //        rootNode.AppendChild(userNode);

        //        userNode = xmldoc.CreateElement("LA_First_Name");
        //        userNode.InnerText = item.LA_First_Name;
        //        rootNode.AppendChild(userNode);

        //        userNode = xmldoc.CreateElement("LA_Middle_Name");
        //        userNode.InnerText = item.LA_Middle_Name;
        //        rootNode.AppendChild(userNode);

        //        userNode = xmldoc.CreateElement("LA_Last_Name");
        //        userNode.InnerText = item.LA_Last_Name;
        //        rootNode.AppendChild(userNode);

        //        userNode = xmldoc.CreateElement("LA_DoB");
        //        userNode.InnerText = item.LA_DoB;
        //        rootNode.AppendChild(userNode);

        //        userNode = xmldoc.CreateElement("LA_Gender");
        //        userNode.InnerText = item.LA_Gender;
        //        rootNode.AppendChild(userNode);

        //        userNode = xmldoc.CreateElement("LA_Current_Address");
        //        userNode.InnerText = item.LA_Current_Address;
        //        rootNode.AppendChild(userNode);

        //        userNode = xmldoc.CreateElement("LA_Permanent_Address");
        //        userNode.InnerText = item.LA_Permanent_Address;
        //        rootNode.AppendChild(userNode);

        //        userNode = xmldoc.CreateElement("LA_Pin_Code");
        //        userNode.InnerText = item.LA_Pin_Code;
        //        rootNode.AppendChild(userNode);

        //        userNode = xmldoc.CreateElement("LA_PAN");
        //        userNode.InnerText = item.LA_PAN;
        //        rootNode.AppendChild(userNode);

        //        userNode = xmldoc.CreateElement("LA_Aadhar");
        //        userNode.InnerText = item.LA_Aadhar;
        //        rootNode.AppendChild(userNode);

        //        userNode = xmldoc.CreateElement("LA_Ckyc");
        //        userNode.InnerText = item.LA_Ckyc;
        //        rootNode.AppendChild(userNode);

        //        userNode = xmldoc.CreateElement("LA_Passport");
        //        userNode.InnerText = item.LA_Passport;
        //        rootNode.AppendChild(userNode);

        //        userNode = xmldoc.CreateElement("LA_DL");
        //        userNode.InnerText = item.LA_DL;
        //        rootNode.AppendChild(userNode);

        //        userNode = xmldoc.CreateElement("LA_Voter_Id");
        //        userNode.InnerText = item.LA_Voter_Id;
        //        rootNode.AppendChild(userNode);

        //        userNode = xmldoc.CreateElement("LA_Phone_Number_1");
        //        userNode.InnerText = item.LA_Phone_Number_1;
        //        rootNode.AppendChild(userNode);

        //        userNode = xmldoc.CreateElement("LA_Phone_Number_2");
        //        userNode.InnerText = item.LA_Phone_Number_2;
        //        rootNode.AppendChild(userNode);

        //        userNode = xmldoc.CreateElement("LA_Email_1");
        //        userNode.InnerText = item.LA_Email_1;
        //        rootNode.AppendChild(userNode);

        //        userNode = xmldoc.CreateElement("LA_Email_2");
        //        userNode.InnerText = item.LA_Email_2;
        //        rootNode.AppendChild(userNode);

        //        userNode = xmldoc.CreateElement("Date_of_Death");
        //        userNode.InnerText = item.Date_of_Death;
        //        rootNode.AppendChild(userNode);

        //        queryNode.AppendChild(rootNode);
        //        xmldoc.AppendChild(queryNode);

        //        string FileNameRequest = "IIBRequest" + DateTime.Now.ToString("ddMMyyyyhhmmss");
        //        string FolderPathRequest = ConfigurationManager.AppSettings["FolderPathRequest"];
        //        string FolderPathzip = ConfigurationManager.AppSettings["FolderPathZip"];
        //        string FilePathRequest = HttpContext.Current.Server.MapPath(FolderPathRequest + "\\" + FileNameRequest + ".xml");
        //        string Requestpath = FilePathRequest;
        //        StringBuilder sb = new StringBuilder();
        //        sb.Append(FileNameRequest + "," + FolderPathRequest + "," + FolderPathzip + "," + FilePathRequest + "," + Requestpath);
        //        string input = sb.ToString();
        //        objComm.IIBLogtable(txtAppno.Text, "btnFetchIIBQuery_Click_starts_02", input, "", "", "", "", "UW", "", "", "");
        //        xmldoc.Save(Requestpath);
        //        #region ZipFile
        //        objComm.IIBLogtable(txtAppno.Text, "", FileNameRequest, "", "", "", "", "UW", "", "", "");

        //        string pathzip = HttpContext.Current.Server.MapPath(FolderPathzip);
        //        string IIBFilePathZip = pathzip + "\\" + FileNameRequest + ".zip";
        //        if (File.Exists(IIBFilePathZip))
        //        {
        //            File.Delete(IIBFilePathZip);
        //        }

        //        using (var zip = ZipFile.Open(IIBFilePathZip, ZipArchiveMode.Create))
        //            zip.CreateEntryFromFile(FilePathRequest, FileNameRequest + ".xml");
        //        objComm.IIBLogtable(txtAppno.Text, "btnFetchIIBQuery_Click", input, "", "", "", "", "UW", "", "", "zipfilecreated");
        //        #endregion
        //        string ZipFileName = FileNameRequest + ".zip";

        //        //objComm.IIBLogtable(txtAppno.Text, "btnFetchIIBQuery_Click", ZipFileName, "", "", "", "", "UW", "", "", "zipfilecreated");
        //        // Create a byte array of file stream length
        //        byte[] bytes = System.IO.File.ReadAllBytes(IIBFilePathZip);


        //        IIBData.QueryUploadRequest objqueryuploadrequest = new IIBData.QueryUploadRequest();
        //        objqueryuploadrequest.FileContent = bytes;
        //        objComm.IIBLogtable(txtAppno.Text, "btnFetchIIBQuery_Click", objqueryuploadrequest.FileContent.Length.ToString(), "", "", "", "", "UW", "", "", "BeforeFileContent");
        //        objComm.IIBLogtable(txtAppno.Text, "btnFetchIIBQuery_Click", objqueryuploadrequest.FileContent.Length.ToString(), "", "", "", "", "UW", "", "", "FileContentLength");

        //        //IIBResponse 
        //        IIBData.QueryUploadResponse objqueryuploadresponse = new IIBData.QueryUploadResponse();
        //        IIBData.ServiceSoapClient serviceSoapClient = new IIBData.ServiceSoapClient();
        //        objComm.IIBLogtable(txtAppno.Text, "btnFetchIIBQuery_Click", objqueryuploadrequest.FileContent.Length.ToString(), "", "", "", "", "UW", "", "", "BFServiceCall");

        //        byte[] data = serviceSoapClient.QueryUpload(Commfun.GetIIBLoginDetails(), objqueryuploadrequest.FileContent);

        //        objComm.IIBLogtable(txtAppno.Text, "btnFetchIIBQuery_Click", data.Length.ToString(), "", "", "", "", "UW", "", "", "AFServiceCall");
        //        //objComm.IIBLogtable(txtAppno.Text, "", IIBFilePathZip, "", "", "", "", "UW", "", "", "IIBQueryhit");
        //        string decodedString = Encoding.UTF8.GetString(data);
        //        objComm.IIBLogtable(txtAppno.Text, "btnFetchIIBQuery_Click", decodedString, "", "", "", "", "UW", "", "", "decodedString");
        //        xmldoc.LoadXml(decodedString.Replace(@"\r\n", ""));
        //        objComm.IIBLogtable(txtAppno.Text, "btnFetchIIBQuery_Click", xmldoc.ToString(), "", "", "", "", "UW", "", "", "IIB_Response_XML");
        //        XmlNodeList xnList = xmldoc.SelectNodes("/UploadFile");
        //        foreach (XmlNode xn in xnList)
        //        {
        //            XmlNode anode = xn.SelectSingleNode("FileHeader");
        //            if (anode != null)
        //            {

        //                string Status = anode.SelectSingleNode("Status").InnerText;
        //                string Remarks = anode.SelectSingleNode("Remarks").InnerText;
        //                string TransactionID = anode.SelectSingleNode("TransactionID").InnerText;
        //                if (Status == "Success")
        //                {
        //                    objComm.IIBLogtable(txtAppno.Text, "", FileNameRequest, "", Status, Remarks, "", "UW", "", "", "");
        //                    IIBData.GetQueryDataRequest objgetRequest = new IIBData.GetQueryDataRequest();
        //                    objgetRequest.TransactionRefereceNo = TransactionID;
        //                    IIBData.GetQueryDataResponse objgetResponse = new IIBData.GetQueryDataResponse();
        //                    IIBData.ServiceSoapClient objserviceSoapClient = new IIBData.ServiceSoapClient();
        //                    byte[] datareq = objserviceSoapClient.GetQueryData(Commfun.GetIIBLoginDetails(), objgetRequest.TransactionRefereceNo);
        //                    string decodedString1 = Encoding.UTF8.GetString(datareq);
        //                    decodedString1 = decodedString1.Replace("\r\n\r\n\0", string.Empty);
        //                    if (decodedString1.Trim() == "No Match Found")
        //                    {
        //                        //ScriptManager.RegisterStartupScript(Page, GetType(), "disp_confirm", "<script>alert('No Match Found');hideloading();</script>", false);
        //                        ScriptManager.RegisterStartupScript(Page, GetType(), "disp_confirm", "<script>alert('No Match Found');hideloading();</script>", false);
        //                        GridViewOther.Visible = false;
        //                        GridViewFG.Visible = false;
        //                        btnFetchIIBQuery.Enabled = false;
        //                        objComm.IIBLogtable(txtAppno.Text, "", FileNameRequest, "", "", "", "NoMatchFound", "UW", "", "", "DataNotMatchFound");

        //                    }
        //                    else
        //                    {
        //                        string FileNameResponse = DateTime.Now.ToString("ddMMyyyyhhmmss");
        //                        string FolderPathResponse = ConfigurationManager.AppSettings["FolderPathCSVFiles"];
        //                        string FilePathResponse = HttpContext.Current.Server.MapPath(FolderPathResponse + "\\" + FileNameResponse + ".csv");
        //                        string Responsepath = FilePathResponse;
        //                        FileStream fs = new FileStream(Responsepath, FileMode.Create, FileAccess.ReadWrite);
        //                        objComm.IIBLogtable(txtAppno.Text, "", FileNameRequest, FileNameResponse, "", "", "", "UW", "", "", "ResponseFileData");
        //                        BinaryWriter bw = new BinaryWriter(fs);
        //                        bw.Write(datareq);
        //                        bw.Close();
        //                        //string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), Responsepath1);
        //                        //string[] files = File.ReadAllLines(path);
        //                        DataTable dtCsv = new DataTable();
        //                        string Fulltext;
        //                        using (StreamReader sr = new StreamReader(Responsepath))
        //                        {
        //                            while (!sr.EndOfStream)
        //                            {
        //                                Fulltext = sr.ReadToEnd().ToString(); //read full file text  
        //                                string[] rows = Fulltext.Split('\n'); //split full file text into rows  
        //                                for (int i = 0; i < rows.Count() - 1; i++)
        //                                {
        //                                    string[] rowValues = rows[i].Split(','); //split each row with comma to get individual values  
        //                                    {
        //                                        if (i == 0)
        //                                        {
        //                                            for (int j = 0; j < rowValues.Count(); j++)
        //                                            {
        //                                                dtCsv.Columns.Add(rowValues[j].Trim()); //add headers  
        //                                            }
        //                                            dtCsv.Columns["Quest_Sum_Assured"].DataType = typeof(double);  //change for sum assured formation
        //                                        }
        //                                        else
        //                                        {
        //                                            DataRow dr = dtCsv.NewRow();
        //                                            for (int k = 0; k < rowValues.Count(); k++)
        //                                            {
        //                                                if (k == 5)
        //                                                {
        //                                                    var desc = list.Find(x => x.Code == rowValues[k]);
        //                                                    dr[k] = desc.desc;
        //                                                }
        //                                                else
        //                                                {
        //                                                    dr[k] = rowValues[k].ToString().Trim();
        //                                                }

        //                                            }
        //                                            dtCsv.Rows.Add(dr); //add other rows  
        //                                        }
        //                                    }
        //                                }
        //                            }
        //                        }
        //                        //Merge datatable accoreding to checkbox 
        //                        if (item.type == "proposer")
        //                        {
        //                            //Add column for LA0-----------------------  
        //                            // DataRow drowItem;
        //                            DataColumn dcolColumn = new DataColumn("LAProposerPayor", typeof(string));
        //                            //DataColumn isnegativematch = new DataColumn("Is_Negative_Match", typeof(string));
        //                            //dtCsv.Columns.Add(isnegativematch);
        //                            dtCsv.Columns.Add(dcolColumn);
        //                            foreach (DataRow row in dtCsv.Rows)
        //                            {
        //                                row["LAProposerPayor"] = "proposer";
        //                                //row["Is_Negative_Match"] = "Y";
        //                            }
        //                            dtCsv.Rows.RemoveAt(dtCsv.Rows.Count - 1);

        //                            alldt.Merge(dtCsv);
        //                        }
        //                        else if (item.type == "payer")
        //                        {
        //                            //Add Column for Proposer.
        //                            //Add column for LA
        //                            DataColumn dcolColumn = new DataColumn("LAProposerPayor", typeof(string));
        //                            //DataColumn isnegativematch = new DataColumn("Is_Negative_Match", typeof(string));
        //                            //dtCsv.Columns.Add(isnegativematch);
        //                            dtCsv.Columns.Add(dcolColumn);
        //                            foreach (DataRow row in dtCsv.Rows)
        //                            {
        //                                row["LAProposerPayor"] = "payer";
        //                                //row["Is_Negative_Match"] = "Y";
        //                            }
        //                            dtCsv.Rows.RemoveAt(dtCsv.Rows.Count - 1);
        //                            alldt.Merge(dtCsv);
        //                        }
        //                        else
        //                        {
        //                            DataColumn dcolColumn = new DataColumn("LAProposerPayor", typeof(string));
        //                            //DataColumn isnegativematch = new DataColumn("Is_Negative_Match", typeof(string));
        //                            //dtCsv.Columns.Add(isnegativematch);
        //                            dtCsv.Columns.Add(dcolColumn);
        //                            foreach (DataRow row in dtCsv.Rows)
        //                            {
        //                                row["LAProposerPayor"] = "LA";
        //                                //row["Is_Negative_Match"] = "Y";
        //                            }
        //                            dtCsv.Rows.RemoveAt(dtCsv.Rows.Count - 1);
        //                            //}

        //                            alldt.Merge(dtCsv);
        //                            DataTable dt12 = new DataTable();
        //                            dt12.Columns.Add("Input_Proposal_Policy_No");
        //                            dt12.Columns.Add("QuestDBNo");
        //                            dt12.Columns.Add("Input_Matching_Parameter");
        //                            dt12.Columns.Add("Quest_DoP_DoC");
        //                            dt12.Columns.Add("Quest_Sum_Assured");
        //                            dt12.Columns["Quest_Sum_Assured"].DataType = typeof(double);  //change for sum assured formation
        //                            dt12.Columns.Add("Quest_Policy_Status");
        //                            dt12.Columns.Add("Quest_Date_of_Exit");
        //                            dt12.Columns.Add("Quest_Date_of_Death");
        //                            dt12.Columns.Add("Quest_Cause_of_Death");
        //                            dt12.Columns.Add("Quest_Record_last_updated");
        //                            dt12.Columns.Add("Quest_Entity_Caution_Status");
        //                            dt12.Columns.Add("Quest_Intermediary_Caution_Status");
        //                            dt12.Columns.Add("Quest_Company_Number");
        //                            dt12.Columns.Add("Is_Negative_Match");
        //                            dt12.Columns.Add("LAProposerPayor");
        //                            dt12.Columns.Add("Status");
        //                            dt12.Columns.Add("CreatedBy");
        //                            DataRow dr12 = null;


        //                            foreach (DataRow item1 in alldt.Rows)
        //                            {
        //                                //DataRow dr = dttemp.NewRow();
        //                                string ApplicationNo = item1["Input_Proposal_Policy_No"].ToString();
        //                                string QuestDBNo = item1["QuestDBNo"].ToString();
        //                                string Matching_Parameter = item1["Input_Matching_Parameter"].ToString();
        //                                string DoP_DoC = item1["Quest_DoP_DoC"].ToString();
        //                                string Sum_Assured = item1["Quest_Sum_Assured"].ToString().Split('.')[0].ToString();
        //                                string Policy_Status = item1["Quest_Policy_Status"].ToString();
        //                                string Date_of_Exit = item1["Quest_Date_of_Exit"].ToString();
        //                                string Date_of_Death = item1["Quest_Date_of_Death"].ToString();
        //                                string Cause_of_Death = item1["Quest_Cause_of_Death"].ToString();
        //                                string Record_last_updated = item1["Quest_Record_last_updated"].ToString();
        //                                string Entity_Caution_Status = item1["Quest_Entity_Caution_Status"].ToString();
        //                                string Intermediary_Caution_Status = item1["Quest_Intermediary_Caution_Status"].ToString();
        //                                string Company_Number = item1["Quest_Company_Number"].ToString();
        //                                string Negative_Match = item1["Is_Negative_Match"].ToString().Trim();
        //                                string LAProposerPayor = item1["LAProposerPayor"].ToString();
        //                                //string CreatedBy = "UW";

        //                                dr12 = dt12.NewRow();
        //                                dr12["Input_Proposal_Policy_No"] = ApplicationNo;
        //                                dr12["QuestDBNo"] = QuestDBNo;
        //                                dr12["Input_Matching_Parameter"] = Matching_Parameter;
        //                                dr12["Quest_DoP_DoC"] = DoP_DoC;
        //                                dr12["Quest_Sum_Assured"] = Sum_Assured;
        //                                dr12["Quest_Policy_Status"] = Policy_Status;
        //                                dr12["Quest_Date_of_Exit"] = Date_of_Exit;
        //                                dr12["Quest_Date_of_Death"] = Date_of_Death;
        //                                dr12["Quest_Cause_of_Death"] = Cause_of_Death;
        //                                dr12["Quest_Record_last_updated"] = Record_last_updated;
        //                                dr12["Quest_Entity_Caution_Status"] = Entity_Caution_Status;
        //                                dr12["Quest_Intermediary_Caution_Status"] = Intermediary_Caution_Status;
        //                                dr12["Quest_Company_Number"] = Company_Number;
        //                                dr12["Is_Negative_Match"] = Negative_Match;
        //                                dr12["LAProposerPayor"] = LAProposerPayor;
        //                                dr12["Status"] = "Active";
        //                                dr12["CreatedBy"] = "UW";
        //                                dt12.Rows.Add(dr12);

        //                                //objComm.SaveIIBData(ApplicationNo, QuestDBNo, Matching_Parameter, DoP_DoC, Sum_Assured,
        //                                //Policy_Status, Date_of_Exit, Date_of_Death, Cause_of_Death, Record_last_updated, Entity_Caution_Status, Intermediary_Caution_Status, Company_Number, Negative_Match, LAProposerPayor, CreatedBy);
        //                            }
        //                            objComm.IIBQueryData(dt12);
        //                            //dispalythe grid here
        //                        }

        //                    }
        //                }
        //                else if (Status == "Failed")
        //                {
        //                    string replaceSTR = Remarks.Replace("'", "''").Trim();
        //                    string repalce1Str = replaceSTR.Replace("''", " ");
        //                    ScriptManager.RegisterStartupScript(Page, GetType(), "disp_confirm", "<script>alert('" + repalce1Str + "');hideloading();</script>", false);
        //                }
        //            }
        //            else
        //            {
        //            }
        //        }
        //    }
        //    //display the grid here
        //    DataTable dt11 = new DataTable();
        //    alldt.Columns.Remove("Input_Proposal_Policy_No");
        //    //alldt.Columns.Remove("Quest_Company_Number");
        //    //alldt.Columns.Remove("Quest_Date_of_Exit");
        //    //alldt.Columns.Remove("Quest_Date_of_Death");
        //    //alldt.Columns.Remove("Quest_Cause_of_Death");
        //    //alldt.Columns.Remove("Quest_Entity_Caution_Status");
        //    //alldt.Columns.Remove("Quest_Intermediary_Caution_Status"); 
        //    // alldt.AsEnumerable().ToList().ForEach(p => p.SetField<string>("Quest_Sum_Assured", Math.Round(double.Parse(p.Field<string>("Quest_Sum_Assured"), System.Globalization.CultureInfo.InvariantCulture), 1).ToString()));
        //    alldt.AsEnumerable().ToList().ForEach(p => p.SetField<double>("Quest_Sum_Assured", Math.Round(p.Field<double>("Quest_Sum_Assured"), 1)));   //change for sum assured formation
        //    //dt11 = alldt.AsEnumerable()
        //    //   .Where(r => r.Field<string>("Quest_Company_Number") == "133")
        //    //   .CopyToDataTable();
        //    //GridViewFG.DataSource = dt11;
        //    //GridViewFG.DataBind();
        //    //GridViewFG.Visible = true;
        //    //btnFetchIIBQuery.Visible = true;
        //    int FGRecords = alldt.AsEnumerable().Where(x => x["Quest_Company_Number"].ToString() == "133").ToList().Count;
        //    if (FGRecords > 0)
        //    {


        //        dt11 = alldt.AsEnumerable()
        //           .Where(r => r.Field<string>("Quest_Company_Number") == "133")
        //           .CopyToDataTable();
        //        GridViewFG.DataSource = dt11;
        //        GridViewFG.DataBind();
        //        GridViewFG.Visible = true;
        //        btnFetchIIBQuery.Visible = true;
        //    }
        //    else
        //    {

        //        GridViewFG.Visible = false;
        //    }

        //    //DataTable dt2 = new DataTable();
        //    ////dt2.Merge(alldt);
        //    //dt2 = alldt.AsEnumerable()
        //    //               .Where(r => r.Field<string>("Quest_Company_Number") != "133")
        //    //               .CopyToDataTable();
        //    //GridViewOther.DataSource = dt2;
        //    //GridViewOther.DataBind();
        //    //GridViewOther.Visible = true;

        //    DataTable dt2 = new DataTable();
        //    var dtdt2 = alldt.AsEnumerable()
        //  .Where(r => r.Field<string>("Quest_Company_Number") != "133");
        //    //.CopyToDataTable();
        //    var resdtdt2 = dtdt2.Any() ? "1" : "2";
        //    if (resdtdt2.ToString() == "1")
        //    {
        //        dt2 = dtdt2.CopyToDataTable();

        //        GridViewOther.DataSource = dt2;
        //        GridViewOther.DataBind();
        //        GridViewOther.Visible = true;
        //        lblothercompany.Visible = true;
        //        lblothercompany.ForeColor = System.Drawing.Color.Red;
        //        lblothercompany.Text = "The existing policies found in other insurance companies,please ensure to collect the information from client in proposal form / declaration";
        //    }

        //    GridViewOther.Visible = true;
        //    btnFetchIIBQuery.Visible = true;
        //}

        //catch (Exception ex)
        //{
        //    ScriptManager.RegisterStartupScript(Page, GetType(), "disp_confirm", "<script>alert('" + ex.Message + "');hideloading();</script>", false);
        //    objComm.IIBLogtable(txtAppno.Text, "", "", "", "Failed", "", "", "UW", "", ex.ToString(), "Failed");
        //}
        //ScriptManager.RegisterStartupScript(Page, GetType(), "disp_confirm", "<script>alert('Click ok to view complete details');hideloading();</script>", false);
    }

    //35.1 Begin of changes CR-30489 kavita mfl00255
    #region 35.1 Begin of changes  CR-30489 kavita mfl00255
    protected void btnFetchIIBQuery_Click(object sender, EventArgs e)
    {
        #region Start 38.1: This CR-2809 changes done by Sushant Devkate MFL00905 
        //Begin of changes ; by Sushant Devkate -MFL00905
        bool IsAPICAll = Convert.ToBoolean(ConfigurationManager.AppSettings["IsIIBMatchAPICall"].ToString());
        if (IsAPICAll)
        {
            //End of changes ; by Sushant Devkate -MFL00905
            string PageName = "Uwdecision_Combi.aspx.cs";
            try
            {
                objComm.IIBLogtable(txtAppno.Text, "btnFetchIIBQuery_Click_" + PageName, "", "", "", "", "", "UW", "", "", "IIB query button clicked on UWDecision_Combi page");

                List<CoustomerDO> ObjlistCoustomerDO = new List<CoustomerDO>();
                DataSet dtOut = new DataSet();
                ObjlistCoustomerDO = objComm.GetIIBPolicyHolderData(txtAppno.Text);

                if (ObjlistCoustomerDO != null)
                {
                    if (ObjlistCoustomerDO.Count > 0)
                    {
                        ObjlistCoustomerDO = ObjlistCoustomerDO.Distinct().ToList();

                        for (var i = 0; i < ObjlistCoustomerDO.Count; i++)
                        {
                            dtOut = new IIBQueryBLL().GetIIBMatchAPIResponse(ObjlistCoustomerDO[i].ClientType, "GetIIBMatchAPIResponse", ObjlistCoustomerDO[i].FirstName, ObjlistCoustomerDO[i].SurName, ObjlistCoustomerDO[i].DOB, ObjlistCoustomerDO[i].Gender,
                                                           ObjlistCoustomerDO[i].PinCode, "", ObjlistCoustomerDO[i].PanNo, ObjlistCoustomerDO[i].Address,
                                                           ObjlistCoustomerDO[i].Address, ObjlistCoustomerDO[i].MobileNo, ObjlistCoustomerDO[i].PhoneNumber,
                                                           ObjlistCoustomerDO[i].Email, ObjlistCoustomerDO[i].ProductCode,
                                                           ObjlistCoustomerDO[i].AnnualIncome, txtAppno.Text, PageName);

                        }
                    }
                }



                string strEnvironment = System.Configuration.ConfigurationManager.AppSettings["Environment"].ToString();

                IIBQueryDataDO ObjIIBQueryDataDO = objComm.getFGDataShow_Impact_New(strApplicationno, "UW");

                if (ObjIIBQueryDataDO.ObjListOFQueryFG.Count > 0 || ObjIIBQueryDataDO.ObjListOFQueryOther.Count > 0)
                {
                    BindGridforIIB(ObjIIBQueryDataDO, 1);
                }

            }

            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "disp_confirm", "<script>alert('" + ex.Message + "');hideloading();</script>", false);
                objComm.IIBLogtable(txtAppno.Text, "btnFetchIIBQuery_Click_" + PageName, "", "", "Failed", "", "", "UW", "", ex.ToString(), "Failed");
            }
            ScriptManager.RegisterStartupScript(Page, GetType(), "disp_confirm", "<script>alert('Click ok to view complete details');hideloading();</script>", false);
        }
        //Begin of changes ; by Sushant Devkate -MFL00905
        else
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "disp_confirm", "<script>hideloading();</script>", false);
        }
        //End of changes ; by Sushant Devkate -MFL00905
        #endregion End 38.1: This CR-2809 changes done by Sushant Devkate MFL00905 
    }


    #region To save IIB gridview Data
    public void SaveIIBImpact(string AppNo)
    {
        try
        {
            DataTable dt12 = new DataTable();
            dt12.Columns.Add("Input_Proposal_Policy_No");
            dt12.Columns.Add("QuestDBNo");
            dt12.Columns.Add("Input_Matching_Parameter");
            dt12.Columns.Add("Quest_DoP_DoC");
            dt12.Columns.Add("Quest_Sum_Assured");
            dt12.Columns["Quest_Sum_Assured"].DataType = typeof(double);  //change for sum assured formation
            dt12.Columns.Add("Quest_Policy_Status");
            dt12.Columns.Add("Quest_Date_of_Exit");
            dt12.Columns.Add("Quest_Date_of_Death");
            dt12.Columns.Add("Quest_Cause_of_Death");
            dt12.Columns.Add("Quest_Record_last_updated");
            dt12.Columns.Add("Quest_Entity_Caution_Status");
            dt12.Columns.Add("Quest_Intermediary_Caution_Status");
            dt12.Columns.Add("Quest_Company_Number");
            dt12.Columns.Add("Is_Negative_Match");
            dt12.Columns.Add("LAProposerPayor");
            dt12.Columns.Add("Status");
            dt12.Columns.Add("CreatedBy");
            dt12.Columns.Add("IIBServiceResponse");
            dt12.Columns.Add("Impact");
            //IIBServiceResponse
            //Added by kavita new column in IIB Service changes
            dt12.Columns.Add("Product_Type");
            dt12.Columns.Add("Linked_Non_linked");
            dt12.Columns.Add("Medical_Non_Medical");
            dt12.Columns.Add("Whether_Standard_Life");
            dt12.Columns.Add("Reason_for_Decline");
            dt12.Columns.Add("Reason_for_Postpone");
            dt12.Columns.Add("Reason_for_Repudiation");
            //Addded by Sushant
            #region Start 38.1: This CR-2809 changes done by Sushant Devkate MFL00905 
            dt12.Columns.Add("Client_Type");
            dt12.Columns.Add("RolesType");
            dt12.Columns.Add("Type");

            DataTable LAdt = new DataTable();
            DataTable Proposaldt = new DataTable();
            DataTable Payerdt = new DataTable();

            LAdt = dt12.Copy();
            Proposaldt = dt12.Copy();
            Payerdt = dt12.Copy();

            #region FGIL Grid
            #region LA Griview Bind
            foreach (GridViewRow row in GridViewLA.Rows)
            {
                Label lblQuestDBNo1 = (Label)row.FindControl("lblQuestDBNo1");
                Label lblMatchingPara = (Label)row.FindControl("lblMatchingPara");
                Label lblDoC = (Label)row.FindControl("lblDoC");
                Label lblsa = (Label)row.FindControl("lblsa");
                Label lblPolStatus = (Label)row.FindControl("lblPolStatus");
                Label lblDateofExit = (Label)row.FindControl("lblDateofExit");
                Label lblDateofDeath = (Label)row.FindControl("lblDateofDeath");
                Label lblupdateddate = (Label)row.FindControl("lblupdateddate");
                Label lblCautionStatus = (Label)row.FindControl("lblCautionStatus");
                Label lblInterMedCautionStatus = (Label)row.FindControl("lblInterMedCautionStatus");
                Label lblCompany = (Label)row.FindControl("lblCompany");
                Label lblNegative = (Label)row.FindControl("lblNegative");
                Label lblLAProposerPayor = (Label)row.FindControl("lblLAProposerPayor");
                HiddenField hdnLAClientType = (HiddenField)row.FindControl("hdnLACliectType");
                Label lblLARolesType = (Label)row.FindControl("lblLARolesType");

                string QuestDBNo = lblQuestDBNo1.Text;
                string Matching_Parameter = lblMatchingPara.Text;
                string DoP_DoC = lblDoC.Text;
                string Sum_Assured = lblsa.Text;//.Split('.')[0].ToString();
                string Policy_Status = lblPolStatus.Text;
                string Date_of_Exit = lblDateofExit.Text;
                string Date_of_Death = lblDateofDeath.Text;
                string Cause_of_Death = lblCautionStatus.Text;
                string Record_last_updated = lblupdateddate.Text;
                string Entity_Caution_Status = lblCautionStatus.Text;
                string Intermediary_Caution_Status = lblInterMedCautionStatus.Text;
                string Company_Number = lblCompany.Text;
                string Negative_Match = lblNegative.Text;
                string LAProposerPayor = lblLAProposerPayor.Text;
                string LARolesType = lblLARolesType.Text;
                string LAClientType = hdnLAClientType.Value;

                DropDownList ddl = (DropDownList)row.FindControl("ddlimpact");
                string Impact = ddl.SelectedValue.ToString();

                DataRow LAdr = LAdt.NewRow();
                LAdr["Input_Proposal_Policy_No"] = AppNo;
                LAdr["QuestDBNo"] = QuestDBNo;
                LAdr["Input_Matching_Parameter"] = Matching_Parameter;
                LAdr["Quest_DoP_DoC"] = DoP_DoC;
                LAdr["Quest_Sum_Assured"] = Convert.ToDecimal(Sum_Assured);
                LAdr["Quest_Policy_Status"] = Policy_Status;
                LAdr["Quest_Date_of_Exit"] = Date_of_Exit;
                LAdr["Quest_Date_of_Death"] = Date_of_Death;
                LAdr["Quest_Cause_of_Death"] = Cause_of_Death;
                LAdr["Quest_Record_last_updated"] = Record_last_updated;
                LAdr["Quest_Entity_Caution_Status"] = Entity_Caution_Status;
                LAdr["Quest_Intermediary_Caution_Status"] = Intermediary_Caution_Status;
                LAdr["Quest_Company_Number"] = Company_Number;
                LAdr["Is_Negative_Match"] = Negative_Match;
                LAdr["LAProposerPayor"] = LAProposerPayor;
                LAdr["Status"] = "Active";
                LAdr["CreatedBy"] = "UW";
                LAdr["IIBServiceResponse"] = "Success";
                LAdr["Impact"] = Impact;
                //Added by kavita new column in IIB Service changes
                LAdr["Product_Type"] = string.Empty;
                LAdr["Linked_Non_linked"] = string.Empty;
                LAdr["Medical_Non_Medical"] = string.Empty;
                LAdr["Whether_Standard_Life"] = string.Empty;
                LAdr["Reason_for_Decline"] = string.Empty;
                LAdr["Reason_for_Postpone"] = string.Empty;
                LAdr["Reason_for_Repudiation"] = string.Empty;

                //Added by Sushant 
                LAdr["Client_Type"] = (!string.IsNullOrEmpty(LAClientType)) ? LAClientType : "LA";
                LAdr["RolesType"] = (!string.IsNullOrEmpty(LARolesType)) ? LARolesType : new Commfun().GetPreviousPolicyClientType(QuestDBNo, string.Empty);
                LAdr["Type"] = "FG";
                LAdt.Rows.Add(LAdr);
            }

            #endregion

            #region Proposal Griview Bind
            foreach (GridViewRow row in GridViewProposer.Rows)
            {
                Label lblQuestDBNo1 = (Label)row.FindControl("lblQuestDBNo1");
                Label lblMatchingPara = (Label)row.FindControl("lblMatchingPara");
                Label lblDoC = (Label)row.FindControl("lblDoC");
                Label lblsa = (Label)row.FindControl("lblsa");
                Label lblPolStatus = (Label)row.FindControl("lblPolStatus");
                Label lblDateofExit = (Label)row.FindControl("lblDateofExit");
                Label lblDateofDeath = (Label)row.FindControl("lblDateofDeath");
                Label lblupdateddate = (Label)row.FindControl("lblupdateddate");
                Label lblCautionStatus = (Label)row.FindControl("lblCautionStatus");
                Label lblInterMedCautionStatus = (Label)row.FindControl("lblInterMedCautionStatus");
                Label lblCompany = (Label)row.FindControl("lblCompany");
                Label lblNegative = (Label)row.FindControl("lblNegative");
                Label lblLAProposerPayor = (Label)row.FindControl("lblLAProposerPayor");
                Label lblProposerRoles = (Label)row.FindControl("lblProposerRoles");
                HiddenField hdnProposerClientType = (HiddenField)row.FindControl("hdnProposerClientType");


                string QuestDBNo = lblQuestDBNo1.Text;
                string Matching_Parameter = lblMatchingPara.Text;
                string DoP_DoC = lblDoC.Text;
                string Sum_Assured = lblsa.Text;//.Split('.')[0].ToString();
                string Policy_Status = lblPolStatus.Text;
                string Date_of_Exit = lblDateofExit.Text;
                string Date_of_Death = lblDateofDeath.Text;
                string Cause_of_Death = lblCautionStatus.Text;
                string Record_last_updated = lblupdateddate.Text;
                string Entity_Caution_Status = lblCautionStatus.Text;
                string Intermediary_Caution_Status = lblInterMedCautionStatus.Text;
                string Company_Number = lblCompany.Text;
                string Negative_Match = lblNegative.Text;
                string LAProposerPayor = lblLAProposerPayor.Text;
                string ProposerRoles = lblProposerRoles.Text;
                string ProposerClientType = hdnProposerClientType.Value;
                DropDownList ddl = (DropDownList)row.FindControl("ddlimpact");
                string Impact = ddl.SelectedValue.ToString();
                // string Impact = row.Cells[14].Text;
                //string CreatedBy = "UW";

                DataRow Proposaldr = Proposaldt.NewRow();
                Proposaldr["Input_Proposal_Policy_No"] = AppNo;
                Proposaldr["QuestDBNo"] = QuestDBNo;
                Proposaldr["Input_Matching_Parameter"] = Matching_Parameter;
                Proposaldr["Quest_DoP_DoC"] = DoP_DoC;
                Proposaldr["Quest_Sum_Assured"] = Convert.ToDecimal(Sum_Assured);
                Proposaldr["Quest_Policy_Status"] = Policy_Status;
                Proposaldr["Quest_Date_of_Exit"] = Date_of_Exit;
                Proposaldr["Quest_Date_of_Death"] = Date_of_Death;
                Proposaldr["Quest_Cause_of_Death"] = Cause_of_Death;
                Proposaldr["Quest_Record_last_updated"] = Record_last_updated;
                Proposaldr["Quest_Entity_Caution_Status"] = Entity_Caution_Status;
                Proposaldr["Quest_Intermediary_Caution_Status"] = Intermediary_Caution_Status;
                Proposaldr["Quest_Company_Number"] = Company_Number;
                Proposaldr["Is_Negative_Match"] = Negative_Match;
                Proposaldr["LAProposerPayor"] = LAProposerPayor;
                Proposaldr["Status"] = "Active";
                Proposaldr["CreatedBy"] = "UW";
                Proposaldr["IIBServiceResponse"] = "Success";
                Proposaldr["Impact"] = Impact;
                //Added by kavita new column in IIB Service changes
                Proposaldr["Product_Type"] = string.Empty;
                Proposaldr["Linked_Non_linked"] = string.Empty;
                Proposaldr["Medical_Non_Medical"] = string.Empty;
                Proposaldr["Whether_Standard_Life"] = string.Empty;
                Proposaldr["Reason_for_Decline"] = string.Empty;
                Proposaldr["Reason_for_Postpone"] = string.Empty;
                Proposaldr["Reason_for_Repudiation"] = string.Empty;

                //Added by Sushant 
                Proposaldr["Client_Type"] = (!string.IsNullOrEmpty(ProposerClientType)) ? ProposerClientType : "Proposer";
                Proposaldr["RolesType"] = (!string.IsNullOrEmpty(ProposerRoles)) ? ProposerRoles : new Commfun().GetPreviousPolicyClientType(QuestDBNo, string.Empty);
                Proposaldr["Type"] = "FG";
                Proposaldt.Rows.Add(Proposaldr);
            }

            #endregion

            #region Proposal Griview Bind
            foreach (GridViewRow row in GridViewPayer.Rows)
            {
                Label lblQuestDBNo1 = (Label)row.FindControl("lblQuestDBNo1");
                Label lblMatchingPara = (Label)row.FindControl("lblMatchingPara");
                Label lblDoC = (Label)row.FindControl("lblDoC");
                Label lblsa = (Label)row.FindControl("lblsa");
                Label lblPolStatus = (Label)row.FindControl("lblPolStatus");
                Label lblDateofExit = (Label)row.FindControl("lblDateofExit");
                Label lblDateofDeath = (Label)row.FindControl("lblDateofDeath");
                Label lblupdateddate = (Label)row.FindControl("lblupdateddate");
                Label lblCautionStatus = (Label)row.FindControl("lblCautionStatus");
                Label lblInterMedCautionStatus = (Label)row.FindControl("lblInterMedCautionStatus");
                Label lblCompany = (Label)row.FindControl("lblCompany");
                Label lblNegative = (Label)row.FindControl("lblNegative");
                Label lblLAProposerPayor = (Label)row.FindControl("lblLAProposerPayor");
                Label lblPayorRoles = (Label)row.FindControl("lblPayorRoles");
                HiddenField hdnPayerClientType = (HiddenField)row.FindControl("hdnPayerClientType");
                Label lblLARolesType = (Label)row.FindControl("lblLARolesType");

                string QuestDBNo = lblQuestDBNo1.Text;
                string Matching_Parameter = lblMatchingPara.Text;
                string DoP_DoC = lblDoC.Text;
                string Sum_Assured = lblsa.Text;//.Split('.')[0].ToString();
                string Policy_Status = lblPolStatus.Text;
                string Date_of_Exit = lblDateofExit.Text;
                string Date_of_Death = lblDateofDeath.Text;
                string Cause_of_Death = lblCautionStatus.Text;
                string Record_last_updated = lblupdateddate.Text;
                string Entity_Caution_Status = lblCautionStatus.Text;
                string Intermediary_Caution_Status = lblInterMedCautionStatus.Text;
                string Company_Number = lblCompany.Text;
                string Negative_Match = lblNegative.Text;
                string LAProposerPayor = lblLAProposerPayor.Text;
                string PayorRoles = lblPayorRoles.Text;
                string PayerClientType = hdnPayerClientType.Value;

                DropDownList ddl = (DropDownList)row.FindControl("ddlimpact");
                string Impact = ddl.SelectedValue.ToString();

                DataRow Payerdr = Payerdt.NewRow();
                Payerdr["Input_Proposal_Policy_No"] = AppNo;
                Payerdr["QuestDBNo"] = QuestDBNo;
                Payerdr["Input_Matching_Parameter"] = Matching_Parameter;
                Payerdr["Quest_DoP_DoC"] = DoP_DoC;
                Payerdr["Quest_Sum_Assured"] = Convert.ToDecimal(Sum_Assured);
                Payerdr["Quest_Policy_Status"] = Policy_Status;
                Payerdr["Quest_Date_of_Exit"] = Date_of_Exit;
                Payerdr["Quest_Date_of_Death"] = Date_of_Death;
                Payerdr["Quest_Cause_of_Death"] = Cause_of_Death;
                Payerdr["Quest_Record_last_updated"] = Record_last_updated;
                Payerdr["Quest_Entity_Caution_Status"] = Entity_Caution_Status;
                Payerdr["Quest_Intermediary_Caution_Status"] = Intermediary_Caution_Status;
                Payerdr["Quest_Company_Number"] = Company_Number;
                Payerdr["Is_Negative_Match"] = Negative_Match;
                Payerdr["LAProposerPayor"] = LAProposerPayor;
                Payerdr["Status"] = "Active";
                Payerdr["CreatedBy"] = "UW";
                Payerdr["IIBServiceResponse"] = "Success";
                Payerdr["Impact"] = Impact;
                //Added by kavita new column in IIB Service changes
                Payerdr["Product_Type"] = string.Empty;
                Payerdr["Linked_Non_linked"] = string.Empty;
                Payerdr["Medical_Non_Medical"] = string.Empty;
                Payerdr["Whether_Standard_Life"] = string.Empty;
                Payerdr["Reason_for_Decline"] = string.Empty;
                Payerdr["Reason_for_Postpone"] = string.Empty;
                Payerdr["Reason_for_Repudiation"] = string.Empty;

                //Added by Sushant 
                Payerdr["Client_Type"] = (!string.IsNullOrEmpty(PayerClientType)) ? PayerClientType : "Payer";
                Payerdr["RolesType"] = (!string.IsNullOrEmpty(PayorRoles)) ? PayorRoles : new Commfun().GetPreviousPolicyClientType(QuestDBNo, string.Empty);
                Payerdr["Type"] = "FG";
                Payerdt.Rows.Add(Payerdr);
            }

            #endregion

            #endregion

            #region Other FGIL Grid

            #region Other LA

            foreach (GridViewRow row in GridViewOtherLA.Rows)
            {
                Label lblQuestDBNo1 = (Label)row.FindControl("lblQuestDBNo1");
                Label lblMatchingPara = (Label)row.FindControl("lblMatchingPara");
                Label lblDoC = (Label)row.FindControl("lblDoC");
                Label lblsa = (Label)row.FindControl("lblsa");
                Label lblPolStatus = (Label)row.FindControl("lblPolStatus");
                Label lblDateofExit = (Label)row.FindControl("lblDateofExit");
                Label lblDateofDeath = (Label)row.FindControl("lblDateofDeath");
                Label lblupdateddate = (Label)row.FindControl("lblupdateddate");
                Label lblCautionStatus = (Label)row.FindControl("lblCautionStatus");
                Label lblInterMedCautionStatus = (Label)row.FindControl("lblInterMedCautionStatus");
                Label lblCompany = (Label)row.FindControl("lblCompany");
                Label lblNegative = (Label)row.FindControl("lblNegative");
                Label lblLAProposerPayor = (Label)row.FindControl("lblLAProposerPayor");
                HiddenField hdnOtherLACliectType = (HiddenField)row.FindControl("hdnOtherLACliectType");

                string QuestDBNo = lblQuestDBNo1.Text;
                string Matching_Parameter = lblMatchingPara.Text;
                string DoP_DoC = lblDoC.Text;
                string Sum_Assured = lblsa.Text;//.Split('.')[0].ToString();
                string Policy_Status = lblPolStatus.Text;
                string Date_of_Exit = lblDateofExit.Text;
                string Date_of_Death = lblDateofDeath.Text;
                string Cause_of_Death = lblCautionStatus.Text;
                string Record_last_updated = lblupdateddate.Text;
                string Entity_Caution_Status = lblCautionStatus.Text;
                string Intermediary_Caution_Status = lblInterMedCautionStatus.Text;
                string Company_Number = lblCompany.Text;
                string Negative_Match = lblNegative.Text;
                string LAProposerPayor = lblLAProposerPayor.Text;
                string OtherLACliectType = hdnOtherLACliectType.Value;

                DropDownList ddl = (DropDownList)row.FindControl("ddlimpact");
                string Impact = ddl.SelectedValue.ToString();


                DataRow OtherFGdr = LAdt.NewRow();
                OtherFGdr["Input_Proposal_Policy_No"] = AppNo;
                OtherFGdr["QuestDBNo"] = QuestDBNo;
                OtherFGdr["Input_Matching_Parameter"] = Matching_Parameter;
                OtherFGdr["Quest_DoP_DoC"] = DoP_DoC;
                OtherFGdr["Quest_Sum_Assured"] = Convert.ToDecimal(Sum_Assured);
                OtherFGdr["Quest_Policy_Status"] = Policy_Status;
                OtherFGdr["Quest_Date_of_Exit"] = Date_of_Exit;
                OtherFGdr["Quest_Date_of_Death"] = Date_of_Death;
                OtherFGdr["Quest_Cause_of_Death"] = Cause_of_Death;
                OtherFGdr["Quest_Record_last_updated"] = Record_last_updated;
                OtherFGdr["Quest_Entity_Caution_Status"] = Entity_Caution_Status;
                OtherFGdr["Quest_Intermediary_Caution_Status"] = Intermediary_Caution_Status;
                OtherFGdr["Quest_Company_Number"] = Company_Number;
                OtherFGdr["Is_Negative_Match"] = Negative_Match;
                OtherFGdr["LAProposerPayor"] = LAProposerPayor;
                OtherFGdr["Status"] = "Active";
                OtherFGdr["CreatedBy"] = "UW";
                OtherFGdr["IIBServiceResponse"] = "Success";
                OtherFGdr["Impact"] = Impact;

                //Added by kavita new column in IIB Service changes
                OtherFGdr["Product_Type"] = string.Empty;
                OtherFGdr["Linked_Non_linked"] = string.Empty;
                OtherFGdr["Medical_Non_Medical"] = string.Empty;
                OtherFGdr["Whether_Standard_Life"] = string.Empty;
                OtherFGdr["Reason_for_Decline"] = string.Empty;
                OtherFGdr["Reason_for_Postpone"] = string.Empty;
                OtherFGdr["Reason_for_Repudiation"] = string.Empty;
                //Added by Sushant 
                OtherFGdr["Client_Type"] = (!string.IsNullOrEmpty(OtherLACliectType)) ? OtherLACliectType : "LA";
                OtherFGdr["RolesType"] = string.Empty;
                OtherFGdr["Type"] = "OTHER";
                LAdt.Rows.Add(OtherFGdr);
            }

            #endregion


            #region Other Proposer 

            foreach (GridViewRow row in GridViewOtherProposal.Rows)
            {
                Label lblQuestDBNo1 = (Label)row.FindControl("lblQuestDBNo1");
                Label lblMatchingPara = (Label)row.FindControl("lblMatchingPara");
                Label lblDoC = (Label)row.FindControl("lblDoC");
                Label lblsa = (Label)row.FindControl("lblsa");
                Label lblPolStatus = (Label)row.FindControl("lblPolStatus");
                Label lblDateofExit = (Label)row.FindControl("lblDateofExit");
                Label lblDateofDeath = (Label)row.FindControl("lblDateofDeath");
                Label lblupdateddate = (Label)row.FindControl("lblupdateddate");
                Label lblCautionStatus = (Label)row.FindControl("lblCautionStatus");
                Label lblInterMedCautionStatus = (Label)row.FindControl("lblInterMedCautionStatus");
                Label lblCompany = (Label)row.FindControl("lblCompany");
                Label lblNegative = (Label)row.FindControl("lblNegative");
                Label lblLAProposerPayor = (Label)row.FindControl("lblLAProposerPayor");
                HiddenField hdnOtherProposalCliectType = (HiddenField)row.FindControl("hdnOtherProposalCliectType");

                string QuestDBNo = lblQuestDBNo1.Text;
                string Matching_Parameter = lblMatchingPara.Text;
                string DoP_DoC = lblDoC.Text;
                string Sum_Assured = lblsa.Text;//.Split('.')[0].ToString();
                string Policy_Status = lblPolStatus.Text;
                string Date_of_Exit = lblDateofExit.Text;
                string Date_of_Death = lblDateofDeath.Text;
                string Cause_of_Death = lblCautionStatus.Text;
                string Record_last_updated = lblupdateddate.Text;
                string Entity_Caution_Status = lblCautionStatus.Text;
                string Intermediary_Caution_Status = lblInterMedCautionStatus.Text;
                string Company_Number = lblCompany.Text;
                string Negative_Match = lblNegative.Text;
                string LAProposerPayor = lblLAProposerPayor.Text;
                string OtherProposalCliectType = hdnOtherProposalCliectType.Value;
                DropDownList ddl = (DropDownList)row.FindControl("ddlimpact");
                string Impact = ddl.SelectedValue.ToString();


                DataRow OtherFGdr = Proposaldt.NewRow();
                OtherFGdr["Input_Proposal_Policy_No"] = AppNo;
                OtherFGdr["QuestDBNo"] = QuestDBNo;
                OtherFGdr["Input_Matching_Parameter"] = Matching_Parameter;
                OtherFGdr["Quest_DoP_DoC"] = DoP_DoC;
                OtherFGdr["Quest_Sum_Assured"] = Convert.ToDecimal(Sum_Assured);
                OtherFGdr["Quest_Policy_Status"] = Policy_Status;
                OtherFGdr["Quest_Date_of_Exit"] = Date_of_Exit;
                OtherFGdr["Quest_Date_of_Death"] = Date_of_Death;
                OtherFGdr["Quest_Cause_of_Death"] = Cause_of_Death;
                OtherFGdr["Quest_Record_last_updated"] = Record_last_updated;
                OtherFGdr["Quest_Entity_Caution_Status"] = Entity_Caution_Status;
                OtherFGdr["Quest_Intermediary_Caution_Status"] = Intermediary_Caution_Status;
                OtherFGdr["Quest_Company_Number"] = Company_Number;
                OtherFGdr["Is_Negative_Match"] = Negative_Match;
                OtherFGdr["LAProposerPayor"] = LAProposerPayor;
                OtherFGdr["Status"] = "Active";
                OtherFGdr["CreatedBy"] = "UW";
                OtherFGdr["IIBServiceResponse"] = "Success";
                OtherFGdr["Impact"] = Impact;

                //Added by kavita new column in IIB Service changes
                OtherFGdr["Product_Type"] = string.Empty;
                OtherFGdr["Linked_Non_linked"] = string.Empty;
                OtherFGdr["Medical_Non_Medical"] = string.Empty;
                OtherFGdr["Whether_Standard_Life"] = string.Empty;
                OtherFGdr["Reason_for_Decline"] = string.Empty;
                OtherFGdr["Reason_for_Postpone"] = string.Empty;
                OtherFGdr["Reason_for_Repudiation"] = string.Empty;
                //Added by Sushant 
                OtherFGdr["Client_Type"] = (!string.IsNullOrEmpty(OtherProposalCliectType)) ? OtherProposalCliectType : "Proposer";
                OtherFGdr["RolesType"] = string.Empty;
                OtherFGdr["Type"] = "OTHER";
                Proposaldt.Rows.Add(OtherFGdr);
            }

            #endregion

            #region Other Payer
            foreach (GridViewRow row in GridViewOtherPayer.Rows)
            {
                Label lblQuestDBNo1 = (Label)row.FindControl("lblQuestDBNo1");
                Label lblMatchingPara = (Label)row.FindControl("lblMatchingPara");
                Label lblDoC = (Label)row.FindControl("lblDoC");
                Label lblsa = (Label)row.FindControl("lblsa");
                Label lblPolStatus = (Label)row.FindControl("lblPolStatus");
                Label lblDateofExit = (Label)row.FindControl("lblDateofExit");
                Label lblDateofDeath = (Label)row.FindControl("lblDateofDeath");
                Label lblupdateddate = (Label)row.FindControl("lblupdateddate");
                Label lblCautionStatus = (Label)row.FindControl("lblCautionStatus");
                Label lblInterMedCautionStatus = (Label)row.FindControl("lblInterMedCautionStatus");
                Label lblCompany = (Label)row.FindControl("lblCompany");
                Label lblNegative = (Label)row.FindControl("lblNegative");
                Label lblLAProposerPayor = (Label)row.FindControl("lblLAProposerPayor");
                HiddenField hdnOtherPayerCliectType = (HiddenField)row.FindControl("hdnOtherPayerCliectType");

                string QuestDBNo = lblQuestDBNo1.Text;
                string Matching_Parameter = lblMatchingPara.Text;
                string DoP_DoC = lblDoC.Text;
                string Sum_Assured = lblsa.Text;//.Split('.')[0].ToString();
                string Policy_Status = lblPolStatus.Text;
                string Date_of_Exit = lblDateofExit.Text;
                string Date_of_Death = lblDateofDeath.Text;
                string Cause_of_Death = lblCautionStatus.Text;
                string Record_last_updated = lblupdateddate.Text;
                string Entity_Caution_Status = lblCautionStatus.Text;
                string Intermediary_Caution_Status = lblInterMedCautionStatus.Text;
                string Company_Number = lblCompany.Text;
                string Negative_Match = lblNegative.Text;
                string LAProposerPayor = lblLAProposerPayor.Text;
                string OtherPayerCliectType = hdnOtherPayerCliectType.Value;
                DropDownList ddl = (DropDownList)row.FindControl("ddlimpact");
                string Impact = ddl.SelectedValue.ToString();


                DataRow OtherFGdr = Payerdt.NewRow();
                OtherFGdr["Input_Proposal_Policy_No"] = AppNo;
                OtherFGdr["QuestDBNo"] = QuestDBNo;
                OtherFGdr["Input_Matching_Parameter"] = Matching_Parameter;
                OtherFGdr["Quest_DoP_DoC"] = DoP_DoC;
                OtherFGdr["Quest_Sum_Assured"] = Convert.ToDecimal(Sum_Assured);
                OtherFGdr["Quest_Policy_Status"] = Policy_Status;
                OtherFGdr["Quest_Date_of_Exit"] = Date_of_Exit;
                OtherFGdr["Quest_Date_of_Death"] = Date_of_Death;
                OtherFGdr["Quest_Cause_of_Death"] = Cause_of_Death;
                OtherFGdr["Quest_Record_last_updated"] = Record_last_updated;
                OtherFGdr["Quest_Entity_Caution_Status"] = Entity_Caution_Status;
                OtherFGdr["Quest_Intermediary_Caution_Status"] = Intermediary_Caution_Status;
                OtherFGdr["Quest_Company_Number"] = Company_Number;
                OtherFGdr["Is_Negative_Match"] = Negative_Match;
                OtherFGdr["LAProposerPayor"] = LAProposerPayor;
                OtherFGdr["Status"] = "Active";
                OtherFGdr["CreatedBy"] = "UW";
                OtherFGdr["IIBServiceResponse"] = "Success";
                OtherFGdr["Impact"] = Impact;

                //Added by kavita new column in IIB Service changes
                OtherFGdr["Product_Type"] = string.Empty;
                OtherFGdr["Linked_Non_linked"] = string.Empty;
                OtherFGdr["Medical_Non_Medical"] = string.Empty;
                OtherFGdr["Whether_Standard_Life"] = string.Empty;
                OtherFGdr["Reason_for_Decline"] = string.Empty;
                OtherFGdr["Reason_for_Postpone"] = string.Empty;
                OtherFGdr["Reason_for_Repudiation"] = string.Empty;
                //Added by Sushant 
                OtherFGdr["Client_Type"] = (!string.IsNullOrEmpty(OtherPayerCliectType)) ? OtherPayerCliectType : "Payer";
                OtherFGdr["RolesType"] = string.Empty;
                OtherFGdr["Type"] = "OTHER";
                Payerdt.Rows.Add(OtherFGdr);
            }

            #endregion

            #endregion
            #region Insertion

            if (LAdt.Rows.Count > 0)
            {
                objComm.IIBQueryData_Impact(LAdt);
            }

            if (Proposaldt.Rows.Count > 0)
            {
                objComm.IIBQueryData_Impact(Proposaldt);
            }
            if (Payerdt.Rows.Count > 0)
            {
                objComm.IIBQueryData_Impact(Payerdt);
            }

            #endregion



            #endregion End 38.1: This CR-2809 changes done by Sushant Devkate MFL00905 
        }
        catch (Exception)
        { }
    }

    #endregion
    #endregion 35.1 Begin of changes  CR-30489 kavita mfl00255
    //35.1 End of changes CR-30489 kavita mfl00255
    public class Employee
    {
        public string Code { get; set; }
        public string desc { get; set; }
    }
    public class multiplexml
    {
        public string type;
        public string Policy_Number;
        public string Proposal_Number;
        public string Query_Type;
        public string DoP_DoC;
        public string Sum_Assured;
        public string LA_First_Name;
        public string LA_Middle_Name;
        public string LA_Last_Name;
        public string LA_DoB;
        public string LA_Gender;
        public string LA_Current_Address;
        public string LA_Permanent_Address;
        public string LA_Pin_Code;
        public string LA_PAN;
        public string LA_Aadhar;
        public string LA_Ckyc;
        public string LA_Passport;
        public string LA_DL;
        public string LA_Voter_Id;
        public string LA_Phone_Number_1;
        public string LA_Phone_Number_2;
        public string LA_Email_1;
        public string LA_Email_2;
        public string Date_of_Death;
    }
    protected void GridViewFG_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string type = e.Row.Cells[12].Text;
            string Status = e.Row.Cells[4].Text;

            foreach (TableCell cell in e.Row.Cells)
            {
                if (type == "Y")
                {

                    e.Row.Cells[12].BackColor = System.Drawing.Color.Red;

                }

                //added by suraj to get red colour for status is pending suggested by Diju on 29 May 2021
                if (Status.Contains("Pending for U/w"))
                {
                    e.Row.Cells[4].BackColor = System.Drawing.Color.Red;
                }


            }
        }
    }
    protected void GridViewOther_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string type = e.Row.Cells[12].Text;
            string Status = e.Row.Cells[4].Text;

            foreach (TableCell cell in e.Row.Cells)
            {
                if (type == "Y")
                {
                    e.Row.Cells[12].BackColor = System.Drawing.Color.Red;
                }

                //added by suraj to get red colour for status is pending suggested by Diju on 29 May 2021
                if (Status.Contains("Pending for U/w"))
                {
                    e.Row.Cells[4].BackColor = System.Drawing.Color.Red;

                }

            }
        }
    }
    //End changes to Shweta Mamilwar
    //below 3 method Added by suraj on 14 FEB 2020 for get PEP case
    protected void BindPEPCase(DataTable dt)
    {
        if (dt.Columns.Contains("PEPApproved") && dt.Rows[0]["PEPApproved"].ToString() != "")
        {
            if (ddlPEPApproved.Items.FindByValue(Convert.ToInt32(dt.Rows[0]["PEPApproved"]).ToString()) != null)
            {
                ddlPEPApproved.ClearSelection();
                ddlPEPApproved.Items.FindByValue(Convert.ToInt32(dt.Rows[0]["PEPApproved"]).ToString()).Selected = true;
            }
            if (ddlPEPApproved.SelectedValue != "1")
            {
                foreach (RepeaterItem item in rptDecision.Items)
                {
                    DropDownList ddlUWDecesion = (DropDownList)item.FindControl("ddlUWDecesion");
                    ddlUWDecesion.Items.Remove(ddlUWDecesion.Items.FindByValue("Approved"));
                }


            }
        }

        if (dt.Columns.Contains("PEPCase"))
        {
            if (ddlPEP.Items.FindByValue(Convert.ToString(dt.Rows[0]["PEPCase"])) != null)
            {
                ddlPEP.ClearSelection();
                ddlPEP.Items.FindByValue(Convert.ToString(dt.Rows[0]["PEPCase"])).Selected = true;
            }

        }



    }
    protected void ddlPEP_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Added by Suraj on 13 FEB 2020 for save PEP case/NON PEP case in db
        int resp2 = 0;
        if (Convert.ToString(ddlPEP.SelectedValue) != "" || Convert.ToInt32(ddlPEP.SelectedValue) != 0)
        {
            objBuss.Save_PEPCase(strApplicationno, Convert.ToString(ddlPEP.SelectedItem.Text), strUserId, ref resp2);
        }
    }

    protected void ddlPEPApproved_SelectedIndexChanged(object sender, EventArgs e)
    {
        int resp2 = 0;
        if (Convert.ToString(ddlPEPApproved.SelectedValue) != "" || Convert.ToInt32(ddlPEPApproved.SelectedValue) != 0)
        {
            objBuss.Save_PEPApprovedCase(strApplicationno, Convert.ToBoolean(Convert.ToInt32(ddlPEPApproved.SelectedValue)), strUserId, ref resp2);
            foreach (RepeaterItem item in rptDecision.Items)
            {
                DropDownList ddlUWDecesion = (DropDownList)item.FindControl("ddlUWDecesion");
                ddlUWDecesion.Items.Insert(1, new ListItem("Approved", "Approved"));
            }

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You have approved PEP case')", true);
        }
    }
    //CR-26885 26/02/2020
    #region Cr-26885 start Kavita

    private DataSet FetchCategory(int i)
    {
        _ds = new DataSet();
        objBuss = new BussLayer();
        objBuss.GetLookupData(i, ref _ds);
        return _ds;
    }

    private void BindInvestigationReportstatus(DataSet _ds)
    {
        if (_ds != null && _ds.Tables.Count > 0 && _ds.Tables[0].Rows.Count > 0)
        {
            ddlInvestigationReport.DataSource = _ds;
            ddlInvestigationReport.DataTextField = "LOOKUP_DESCRIPTION";
            ddlInvestigationReport.DataValueField = "LOOKUP_NAME";
        }
        else
        {
            ddlInvestigationReport.DataSource = null;
        }
        ddlInvestigationReport.DataBind();
        ddlInvestigationReport.Items.Insert(0, new ListItem("--Select--", "0"));

    }
    protected void ddlInvestigationReport_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            if (ddlInvestigationReport.SelectedIndex == 3)
            {
                //btnInvestReport.
                btnInvestReport.Visible = true;
                btnInvestReport.Disabled = false;
                Session["CheckddlInvestRepStatus"] = ddlInvestigationReport.SelectedValue.ToString();
            }
            else
            {
                btnInvestReport.Visible = false;
                btnInvestReport.Disabled = true;
                Session["CheckddlInvestRepStatus"] = "";
                foreach (RepeaterItem item in rptproductlist.Items)
                {
                    TextBox txtAppno = (TextBox)item.FindControl("txtAppno");
                    TextBox txtProdcode = (TextBox)item.FindControl("txtProdcode");
                    TextBox txtBasepolno = (TextBox)item.FindControl("txtBasepolno");
                    bool val = objComm.InsertInvestigationReportForPostClick(txtBasepolno.Text, txtAppno.Text, txtProdcode.Text, strUserId, ddlInvestigationReport.SelectedValue.ToString());
                }


            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion Cr-26885 End Kavita


    private void BindRiskInvestigationdescddl(DataSet _ds)//CR-27523 Kavita
    {
        if (_ds != null && _ds.Tables.Count > 0 && _ds.Tables[0].Rows.Count > 0)
        {
            ddlRiskInvestDecision.DataSource = _ds;
            ddlRiskInvestDecision.DataTextField = "LOOKUP_DESCRIPTION";
            ddlRiskInvestDecision.DataValueField = "LOOKUP_NAME";
        }
        else
        {
            ddlRiskInvestDecision.DataSource = null;
        }
        ddlRiskInvestDecision.DataBind();
        ddlRiskInvestDecision.Items.Insert(0, new ListItem("--Select--", "0"));

    }
    //added by suraj for combi
    protected object BindProductDetails_Combi(RepeaterItem item, ref ProductSection objprodctlist)
    {
        TextBox txtProdcode = (TextBox)item.FindControl("txtProdcode");
        TextBox txtBasepolno = (TextBox)item.FindControl("txtBasepolno");
        TextBox txtProname = (TextBox)item.FindControl("txtProname");
        TextBox txtPolterm = (TextBox)item.FindControl("txtPolterm");
        TextBox txtPrepayterm = (TextBox)item.FindControl("txtPrepayterm");
        TextBox txtSumassure = (TextBox)item.FindControl("txtSumassure");
        TextBox txtBasepremium = (TextBox)item.FindControl("txtBasepremium");
        TextBox txtServicetax = (TextBox)item.FindControl("txtServicetax");
        TextBox txtTotalpremium = (TextBox)item.FindControl("txtTotalpremium");
        TextBox txtProdBranchBasePremium = (TextBox)item.FindControl("txtProdBranchBasePremium");
        TextBox txtMonthlyPayoutBase = (TextBox)item.FindControl("txtMonthlyPayoutBase");
        DropDownList ddlFrequency = (DropDownList)item.FindControl("ddlFrequency");

        //added by suraj for new product code T36/37 & E91/92
        DropDownList ddlCategory = (DropDownList)item.FindControl("ddlCategory");
        DropDownList ddlPayoutTerm = (DropDownList)item.FindControl("ddlPayoutTerm");
        DropDownList ddlPayoutType = (DropDownList)item.FindControl("ddlPayoutType");
        DropDownList ddlpayoutfreq = (DropDownList)item.FindControl("ddlpayoutfreq");
        TextBox txtLumpSumPercent = (TextBox)item.FindControl("txtLumpSumPercent");
        DropDownList ddlprodcategory = (DropDownList)item.FindControl("ddlprodcategory");
        //end

        objprodctlist.ProductCode = txtProdcode.Text;
        objprodctlist.PolicyNo = txtBasepolno.Text;
        objprodctlist.ProdcutName = txtProname.Text;
        objprodctlist.PolicyTerm = txtPolterm.Text;
        objprodctlist.PremiumTerm = txtPrepayterm.Text;
        objprodctlist.SumAssured = txtSumassure.Text;
        objprodctlist.BasePremium = txtBasepremium.Text;
        objprodctlist.ServiceTax = txtServicetax.Text;
        objprodctlist.TotalPremium = txtTotalpremium.Text;
        objprodctlist.MonthlyPayout = txtMonthlyPayoutBase.Text;
        objprodctlist.PremiumFreq = ddlFrequency.SelectedValue;

        //added by suraj for new product code T36/37 & E91/92
        objprodctlist.Category = ddlCategory.SelectedValue;
        objprodctlist.PayoutTerm = ddlPayoutTerm.SelectedValue;
        objprodctlist.PayoutType = ddlPayoutType.SelectedValue;
        objprodctlist.PayoutFreq = ddlpayoutfreq.SelectedValue;
        objprodctlist.LumpsumPer = txtLumpSumPercent.Text;
        objprodctlist.ProductCategory = ddlprodcategory.SelectedValue;
        //end

        return objprodctlist;
    }

    protected void rptDecision_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {

            HtmlContainerControl divPostponedPeriod = e.Item.FindControl("divPostponedPeriod") as HtmlContainerControl;
            HtmlContainerControl divUWDecesioncategory = e.Item.FindControl("divUWDecesioncategory") as HtmlContainerControl;
            HtmlContainerControl divUWReason1 = e.Item.FindControl("divUWReason1") as HtmlContainerControl;
            HtmlContainerControl divUWReason2 = e.Item.FindControl("divUWReason2") as HtmlContainerControl;
            HtmlContainerControl divbtnaddnewrow = e.Item.FindControl("divbtnaddnewrow") as HtmlContainerControl;
            DropDownList ddlUWDecesioncategory = e.Item.FindControl("ddlUWDecesioncategory") as DropDownList;
            ListBox ddlUWreason1 = e.Item.FindControl("ddlUWreason1") as ListBox;
            DropDownList ddlUWDecesion = e.Item.FindControl("ddlUWDecesion") as DropDownList;
            TextBox txtUWreason2 = e.Item.FindControl("txtUWreason2") as TextBox;
            Button btnaddnewrow_Decision = e.Item.FindControl("btnaddnewrow_Decision") as Button;
            //end
            //divUWReason1.Visible = false;
            //BindMasterDetails(ddlUWreason1);
            BindMasterDetails(ddlUWDecesion);
            //ddlUWreason.Visible = false;
        }
    }
    protected void ddlAppNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet _ds = new DataSet();
        objcomm.OnlineLoadingMasterDetails_GET(ref _ds, ddlAppNo.SelectedValue, strChannelType);
        Logger.Info(strApplicationno + " STAG2:-Q" + System.Environment.NewLine);
        if (_ds != null && _ds.Tables.Count > 0)
        {
            if (_ds.Tables[0].Rows.Count > 0)
            {
                ddlLoadRiderCode.Enabled = true;
                ddlAppNo.CssClass = "form-control";
                ddlLoadRiderCode.Items.Clear();
                Logger.Info(strApplicationno + " STAG2:-R" + System.Environment.NewLine);
                ViewState["LoadMaster"] = _ds.Tables[0];
                ddlLoadRiderCode.DataSource = _ds.Tables[0];
                ddlLoadRiderCode.DataTextField = "NAME";
                ddlLoadRiderCode.DataValueField = "VALUE";
                //ddlLoadRiderCode.DataMember = "Code";
                ddlLoadRiderCode.DataBind();
                ddlLoadRiderCode.Items.Insert(0, new ListItem("--Select--", "0"));
                Logger.Info(strApplicationno + " STAG2:-S" + System.Environment.NewLine);
                //UpdAppno.Update();
                //updLoadingDetails.Update();
            }
            else
            {
                ddlLoadRiderCode.Items.Clear();
                ddlLoadRiderCode.Items.Insert(0, new ListItem("--Select--", "0"));
            }
        }
    }
    protected void btndetach_Click(object sender, EventArgs e)
    {

        string confirmValue = string.Empty;
        confirmValue = Request.Form["confirm_value"];
        if (confirmValue == "Yes")
        {
            string strParentappNo = string.Empty;
            string strAppType = string.Empty;
            DataSet dtCombidetach = new DataSet();
            objUWDecision.OnlineApplicationLAServiceDetails_PUSH(strApplicationno, strAppType, objChangeObj, ref dtCombidetach, ref _dsPrevPol, "COMBIDET", ref strLApushErrorCode, ref strLApushStatus, ref strConsentRespons);
            if (strLApushErrorCode == 0)
            {
                objcomm.UpdateCombiFlag_Detach(ref _ds, strApplicationno, strChannelType);
                ShowPopupMessage("Detachment successfully done....Now cases act as an individual policy!!");
                throw new Exception("UDE-Detachment successfully done....Now cases act as an individual policy!!");
            }
        }

        /*
        foreach (GridViewRow rowCombi in gvCombiDetails_detach.Rows)
        {
            //define variable
            DataTable dtRiderInfo = new DataTable();
            DataRow dr = dtRiderInfo.NewRow();
            CheckBox chkremovepolcy = (CheckBox)rowCombi.FindControl("chkremovepolicy");
            TextBox txtCombiAppno = (TextBox)rowCombi.FindControl("txtCombiAppno");
            TextBox txtCombiPolicyno = (TextBox)rowCombi.FindControl("txtCombiPolicyno");
            HiddenField hdnCombiPolNo = (HiddenField)rowCombi.FindControl("hdnCombiPolNo");

            //if (chkremovepolcy.Checked)
            //{
            //DataSet dtCombidetach = new DataSet();
            objChangeObj = (ChangeValue)Session["objLoginObj"];
            //objUWDecision.OnlineApplicationLAServiceDetails_PUSH(strParentappNo, strAppType, objChangeObj, ref dtCombidetach, ref _dsPrevPol, "COMBIENQ", ref strLApushErrorCode, ref strLApushStatus, ref strConsentRespons);
            //}
           
        }
        */
    }
    //end
    //Added by Suraj Bhamre on 20/11/2020 -- drop down for new product t36/t37/e91/e92
    public bool Get_DropDownData(DropDownList ddl, string Mode, string ProductID, string ProductCode, string dataValue, string dataText)
    {
        string ConStr;
        SqlConnection Con = null;
        SqlDataAdapter da = null;
        bool result = false;
        try
        {
            ConStr = ConfigurationManager.AppSettings["transactiondbLF"].ToString();
            Con = new SqlConnection(ConStr);
            DataSet ds = new DataSet();
            // Con.Open();
            SqlCommand comm = new SqlCommand("USP_GetDropdowndata", Con);
            da = new SqlDataAdapter(comm);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Mode", Mode);
            da.SelectCommand.Parameters.AddWithValue("@ProductID", ProductID);
            da.SelectCommand.Parameters.AddWithValue("@ProductCode", ProductCode);
            da.Fill(ds);
            if (ds != null)
                if (ds.Tables.Count > 0)
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddl.Items.Clear();
                        ddl.AppendDataBoundItems = true;
                        ddl.Items.Insert(0, new ListItem("--Select--"));
                        ddl.DataSource = ds.Tables[0];
                        ddl.DataTextField = dataText;
                        ddl.DataValueField = dataValue;
                        ddl.DataBind();
                        result = true;
                    }
            return result;
        }
        catch (Exception ex)
        {
            //SISExceptionLog("", "", "Get_DropDownData()", ex.ToString());
            return result;
        }
        finally
        {
            if (Con.State == ConnectionState.Open)
                Con.Close();
            if (da != null)
            {
                da.Dispose();
            }
        }
    }
    protected void ddlPayoutType_SelectedIndexChanged(object sender, EventArgs e)
    {
        foreach (RepeaterItem item in rptDecision.Items)
        {

            DropDownList ddlPayoutType = (DropDownList)item.FindControl("ddlPayoutType");
            DropDownList ddlPayoutTerm = (DropDownList)item.FindControl("ddlPayoutTerm");
            HtmlGenericControl divLumpSumPercent = (HtmlGenericControl)item.FindControl("divLumpSumPercent");
            HtmlGenericControl divPayoutTerm = (HtmlGenericControl)item.FindControl("divPayoutTerm");
            /*36.1 START*/
            TextBox txtprocode = (TextBox)item.FindControl("txtProdcode");
            if (txtprocode.Text != "E97" || txtprocode.Text != "E98" || txtprocode.Text != "EA2")// New Product ERA2

            {
                /*36.1 END*/
                if (ddlPayoutType.SelectedValue != "--Select--")
                {


                    if (ddlPayoutType.SelectedValue == "lumpsum")
                    {
                        divLumpSumPercent.Visible = true;
                        divPayoutTerm.Visible = false;
                        //Get_DropDownData(ddlPayoutTerm, "payoutterm", "", ViewState["ProductCode"].ToString(), "Value", "Text");
                    }
                    else
                    {
                        if (ddlPayoutType.SelectedValue == "mixed")
                        {
                            divLumpSumPercent.Visible = true;

                        }
                        else
                        {
                            divLumpSumPercent.Visible = false;
                        }
                        divPayoutTerm.Visible = true;
                        //divLumpSumPercent.Visible = false;
                        Get_DropDownData(ddlPayoutTerm, "payoutterm", "", ViewState["ProductCode"].ToString(), "Value", "Text");
                    }
                }
            }
        }
    }
    //end
    //added by suraj on 08 March 2021 to change OCR link given by Pramod gupta
    protected void lnkOCR_Click(object sender, EventArgs e)
    {
        string OCRLink = ConfigurationManager.AppSettings["OCRLink"];
        Encryption encr = new Encryption();
        var strEncrypt = encr.EncryptStringToBytes(strApplicationno);
        string encodedText = Convert.ToBase64String(strEncrypt);

        // convert code plaint to base64
        string convertText = encr.Base64Encode(encodedText);
        lnkOCR.Attributes.Add("target", "_blank");
        lnkOCR.Attributes.Add("href", OCRLink + convertText);
    }
    //end
    // Added by Brijesh
    protected void ddlNAWPCatagory_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlNAWPCatagory.SelectedValue == "staff")
        {
            hd_que_2.Checked = true;
            divRelationwithStaff.Visible = true;
        }
        else
        {
            hd_que_2.Checked = false;
            divRelationwithStaff.Visible = false;
            ddlRelationStaff.SelectedValue = "0";
        }
    }

    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        string flag = "0";
        foreach (RepeaterItem item in rptDecision.Items)
        {
            DropDownList ddlCategory = (DropDownList)item.FindControl("ddlCategory");
            if (flag == "0")
            {
                if (ddlCategory.SelectedValue == "staff")
                {
                    flag = "1";
                    hd_que_2.Checked = true;
                    divRelationwithStaff.Visible = true;
                }
                else
                {
                    hd_que_2.Checked = false;
                    divRelationwithStaff.Visible = false;
                    ddlRelationStaff.SelectedValue = "0";
                }
            }
        }
    }
    // end

    #region VAPT Point
    public void GetUWREDIRECTDECISION(ref string qsUserGroup, ref string qsAppNo, ref string qsChannelName, ref string qsPolicyNo, ref string qsUserLimit, ref string qsClickBucketLink, string TokenNumber)
    {
        DataSet dataSet = new DataSet();
        objBuss.UWREDIRECTDECISION(ref dataSet, "02", qsUserGroup, qsAppNo, qsChannelName, qsPolicyNo, qsUserLimit, qsClickBucketLink, "", TokenNumber);

        if (dataSet.Tables[0].Rows.Count > 0)
        {
            DataRow dataRow = dataSet.Tables[0].Rows[0];
            if (dataRow["Response"].ToString() == "Success")
            {
                qsUserGroup = UWSaralDecision.CommFun.Base64DecodingMethod(dataRow["qsUserGroup"].ToString());
                qsAppNo = dataRow["qsAppNo"].ToString();
                qsChannelName = UWSaralDecision.CommFun.Base64DecodingMethod(dataRow["qsChannelName"].ToString());
                qsPolicyNo = UWSaralDecision.CommFun.Base64DecodingMethod(dataRow["qsPolicyNo"].ToString());
                qsUserLimit = UWSaralDecision.CommFun.Base64DecodingMethod(dataRow["qsUserLimit"].ToString());
                qsClickBucketLink = UWSaralDecision.CommFun.Base64DecodingMethod(dataRow["qsClickBucketLink"].ToString());
            }
        }

    }
    #endregion

    #region CR - 29431
    //34.1 Begin of Changes; Pooja Shetye - [1133038]
    public bool CheckFlaggingofPANandForm60(string panno, bool copyofpan, bool copyofform60)
    {
        bool result = true; bool IsvalidPAN = true;

        if ((copyofpan == true && copyofform60 == false) || (copyofpan == false && copyofform60 == true))
        {
            result = true;
        }

        if (result == true)
        {
            if (copyofpan == true)
            {
                if (panno.Trim() == "")
                {
                    IsvalidPAN = false;
                }
                else { IsvalidPAN = true; }
            }


            if (copyofform60 == true)
            {
                if (panno.Trim() == "")
                {
                    IsvalidPAN = true;
                }
                else { IsvalidPAN = false; }
            }
        }
        return IsvalidPAN;
    }

    public bool ValidatePANNumber(string PanNo, string ClientType)
    {
        bool IsvalidPAN = true;
        PanNo = PanNo.Trim();
        if (PanNo != "")
        {
            char c = PanNo[3];

            if (ClientType.ToUpper() == "C")
            {
                string[] digit = new string[] { "H", "A", "F", "C", "T", "B", "L", "J", "G" };
                bool isdigitvalidated = false;
                foreach (string s in digit)
                {
                    if (c.ToString().ToUpper().StartsWith(s))
                    {
                        isdigitvalidated = true;
                    }
                }
                if (isdigitvalidated == true)
                {
                    IsvalidPAN = true;
                }
                else { IsvalidPAN = false; }
            }
            else if (ClientType.ToUpper() == "P")
            {
                if (c.ToString().ToUpper() == ClientType.ToUpper())
                {
                    IsvalidPAN = true;

                }
                else
                {
                    IsvalidPAN = false;

                }
            }


        }
        return IsvalidPAN;
    }

    //34.1 End of Changes; Pooja Shetye - [1133038]
    #endregion

    //added by suraj on 14 FEB 2022 for CR 30589-Risk category
    protected void BindRiskCategory(DataTable dt)
    {
        txtriskcat.Text = Convert.ToString(dt.Rows[0]["FINAL_CATEGORY"]);
        txtriskcat.ForeColor = System.Drawing.Color.White;

        if (txtriskcat.Text == "Very High")
        {
            txtriskcat.BackColor = System.Drawing.Color.Red;
        }

        else if (txtriskcat.Text == "High")
        {
            txtriskcat.BackColor = System.Drawing.Color.Orange;
        }
        else if (txtriskcat.Text == "Medium")
        {
            txtriskcat.BackColor = System.Drawing.Color.Yellow;
        }
        else
        {
            txtriskcat.BackColor = System.Drawing.Color.Green;
        }
    }
    //end
    //37.1 Begin of Changes; Sagar Thorave-[mfl00886]
    public void SelectMerCheckbox(string FollowUpcode)
    {

        if (FollowUpcode == "MPV")
        {
            foreach (ListItem li in cblDecisionTypeDecisions.Items)
            {
                if (Convert.ToInt32(li.Value) == 8)
                {
                    li.Selected = true;
                }
            }
        }
        if (FollowUpcode == "MPN")
        {
            foreach (ListItem li in cblDecisionTypeDecisions.Items)
            {
                if (Convert.ToInt32(li.Value) == 3)
                {
                    li.Selected = true;
                }
            }
        }
    }
    public void NotSelectMerCheckbox(string FollowUpcode)
    {

        if (FollowUpcode != "MPV")
        {
            foreach (ListItem li in cblDecisionTypeDecisions.Items)
            {
                if (Convert.ToInt32(li.Value) == 8)
                {
                    li.Selected = false;
                }
            }
        }
        if (FollowUpcode != "MPN")
        {
            foreach (ListItem li in cblDecisionTypeDecisions.Items)
            {
                if (Convert.ToInt32(li.Value) == 3)
                {
                    li.Selected = false;
                }
            }
        }
    }
    //37.1 End of Changes; Sagar Thorave-[mfl00886]
    //39.1 Begin of Changes; Sagar Thorave-[mfl00886]
    public void GetAmlRiskValue()
    {
        string AmlIndicator = DecideAmlRiskFlag();

        if (!string.IsNullOrEmpty(AmlIndicator))
        {
            if (AmlIndicator == "1")
            {
                DrpAml.SelectedValue = "1";
                DrpAml.ForeColor = System.Drawing.Color.White;
                DrpAml.BackColor = System.Drawing.Color.DarkGreen;
            }
            if (AmlIndicator == "4")
            {
                DrpAml.SelectedValue = "4";
                DrpAml.ForeColor = System.Drawing.Color.White;
                DrpAml.BackColor = System.Drawing.Color.IndianRed;
            }
        }
    }
    public string DecideAmlRiskFlag()
    {
        string MainIndiacator = string.Empty;
        try
        {
            Commfun objComm = new Commfun();

            DataSet ds12 = null;
            DataSet ds13 = null;
            DataSet ds14 = null;
            objComm.Featch_AMLFLAG_Details(ref ds12, txtAppno.Text, "SaralUW");
            string AmlIndicator = (ds12.Tables[0].Rows[0]["CLNTRSKIND"].ToString());
            objComm.Featch_AMLFLAG_Details_Payer(ref ds13, txtAppno.Text, "SaralUW");
            string AmlIndicator_payer = (ds13.Tables[0].Rows[0]["CLNTRSKIND"].ToString());
            objComm.Featch_AMLFLAG_Details_Proposar(ref ds14, txtAppno.Text, "SaralUW");
            string AmlIndicator_proposer = (ds14.Tables[0].Rows[0]["CLNTRSKIND"].ToString());

            if (AmlIndicator.Equals("4") || AmlIndicator_payer.Equals("4") || AmlIndicator_proposer.Equals("4"))
            {
                MainIndiacator = "4";
            }
            else
            {
                MainIndiacator = "1";
            }

            return MainIndiacator;
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }
        return MainIndiacator;
    }
    public string GetAmlValTOLifeAsia()
    {
        string AmlValue = string.Empty;
        try
        {
            DataSet ds12 = null;
            DataSet ds14 = null;
            objComm.Featch_AMLFLAG_Details(ref ds12, txtAppno.Text, "SaralUW");
            AmlValue = (ds12.Tables[0].Rows[0]["CLNTRSKIND"].ToString());
            if (ddlApplicationDetailsProposalType.SelectedValue != null || ddlApplicationDetailsProposalType.SelectedValue != "0")
            {

                if (ddlApplicationDetailsProposalType.SelectedValue.Equals("ORD"))
                {
                    if (AmlValue == "1")
                    {
                        objComm.Insert_AMLFLAG_Details(txtAppno.Text, "Low Risk", AmlValue, "Final Value send to Life asia LA", "SaralUW");
                    }
                    if (AmlValue == "4")
                    {
                        objComm.Insert_AMLFLAG_Details(txtAppno.Text, "High Risk", AmlValue, "Final Value send to Life asia LA", "SaralUW");
                    }
                }
                else
                {
                    AmlValue = "4";
                    string ClientId_LA = (ds12.Tables[0].Rows[0]["ClientNo"].ToString());
                    objComm.Featch_AMLFLAG_Details_Proposar(ref ds14, txtAppno.Text, "SaralUW");
                    string ClientId_proposer = (ds14.Tables[0].Rows[0]["ClientNo"].ToString());

                    if (ClientId_LA == ClientId_proposer)
                    {
                        objComm.Insert_AMLFLAG_Details(txtAppno.Text, "High Risk", AmlValue, "Final Value send to Life asia LA", "SaralUW");
                    }
                    else
                    {
                        objComm.Insert_AMLFLAG_Details(txtAppno.Text, "High Risk", AmlValue, "Final Value send to Life asia LA", "SaralUW");
                        objComm.Insert_AMLFLAG_Details_Propser(txtAppno.Text, "High Risk", AmlValue, "Final Value send to Life asia Proposer", "SaralUW");
                    }
                }
            }
            else
            {
                if (AmlValue == "1")
                {
                    objComm.Insert_AMLFLAG_Details(txtAppno.Text, "Low Risk", AmlValue, "Final Value send to Life asia LA", "SaralUW");
                }
                if (AmlValue == "4")
                {
                    objComm.Insert_AMLFLAG_Details(txtAppno.Text, "High Risk", AmlValue, "Final Value send to Life asia LA", "SaralUW");
                }
            }
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }
        return AmlValue;
    }
    protected void DrpAml_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string AmlIndicator = DrpAml.SelectedValue;
            if (!string.IsNullOrEmpty(AmlIndicator))
            {

                if (AmlIndicator == "1")
                {
                    objComm.Insert_AMLFLAG_Details(txtAppno.Text, "Low", AmlIndicator, "Manually Change By User", "SaralUW");
                    DrpAml.SelectedValue = "1";
                    DrpAml.ForeColor = System.Drawing.Color.White;
                    DrpAml.BackColor = System.Drawing.Color.DarkGreen;
                }
                if (AmlIndicator == "4")
                {
                    objComm.Insert_AMLFLAG_Details(txtAppno.Text, "Very High Risk", AmlIndicator, "Manually Change By User", "SaralUW");
                    DrpAml.SelectedValue = "4";
                    DrpAml.ForeColor = System.Drawing.Color.White;
                    DrpAml.BackColor = System.Drawing.Color.DarkRed;

                }
            }

        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }
        ScriptManager.RegisterStartupScript(Page, GetType(), "disp_confirm", "<script>hideloading()</script>", false);

    }
    //39.1 End of Changes; Sagar Thorave-[mfl00886]
    //46.1 Begin of Changes; Sagar Thorave -MFL00886
    public void SetSpecialInsurance()
    {
        try
        {
            DataSet dsPro = new DataSet();
            objComm.SetProposalType(ref dsPro, txtAppno.Text);
            String SpecialInsurance = dsPro.Tables[0].Rows[0]["SpecialInsurance"].ToString();
            ddlApplicationDetailsProposalType.SelectedValue = SpecialInsurance;
            ddlApplicationDetailsProposalType.Items.FindByValue(Convert.ToString(dsPro.Tables[0].Rows[0]["SpecialInsurance"])).Selected = true;
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }
    }
    //46.1 End of Changes; Sagar Thorave -MFL00886

    #region Start 38.1: This CR-2809 changes done by Sushant Devkate MFL00905 
    public void BindGridforIIB(IIBQueryDataDO ObjIIBQueryDataDO, int Bindgrid)
    {

        #region Display none div of FG and Other FG
        LADiv.Style.Add("display", "none");
        divPayer.Style.Add("display", "none");
        ProposerDiv.Style.Add("display", "none");

        DivGridViewOtherLA.Style.Add("display", "none");
        DivGridViewOtherPayer.Style.Add("display", "none");
        DivGridViewOtherProposal.Style.Add("display", "none");
        #endregion

        if (Bindgrid == 1)  //For UW DATA
        {
            if (ObjIIBQueryDataDO.ObjListOFQueryFG.Count > 0)
            {
                var ObjListClientTypeNull = ObjIIBQueryDataDO.ObjListOFQueryFG.Where(x => x.Client_Type == "").ToList();

                var ObjListClientType = ObjIIBQueryDataDO.ObjListOFQueryFG.Where(x => x.Client_Type != "").ToList();


                if (ObjListClientType.Count > 0)
                {

                    var ObjListLA = ObjListClientType.Where(x => x.Client_Type.ToLower() == "la").ToList();

                    var ObjListPayer = ObjListClientType.Where(x => x.Client_Type.ToLower() == "payer").ToList();

                    var ObjListProposer = ObjListClientType.Where(x => x.Client_Type.ToLower() == "proposer").ToList();

                    if (ObjListLA.Count > 0)
                    {
                        LADiv.Style.Add("display", "block");
                        GridViewLA.DataSource = ObjListLA;
                        GridViewLA.DataBind();
                        GridViewLA.Visible = true;
                        LabelLA.Visible = true;
                        LabelLA.Text = "IIB query output for Life Assured";

                        var LAPolicyCountDetails = (from Pstatus in ObjListLA.AsEnumerable()
                                                    group Pstatus by Pstatus.Quest_Policy_Status
                                                  into g
                                                    select new TotalPolicyDO
                                                    {
                                                        PolicyNo = g.First().QuestDBNo,
                                                        PolicyStatus = g.First().Quest_Policy_Status,
                                                        TotalSA = g.Sum(f => f.Quest_Sum_Assured),

                                                    }).ToList();

                        if (LAPolicyCountDetails.Count > 0)
                        {
                            GridViewLAPolicy.DataSource = LAPolicyCountDetails;
                            GridViewLAPolicy.DataBind();
                            GridViewLAPolicy.Visible = true;
                            //lblLAPolicyDetails.Visible = true;
                            //lblLAPolicyDetails.Text = "Total Policy Status";

                        }
                    }

                    if (ObjListPayer.Count > 0)
                    {
                        divPayer.Style.Add("display", "block");
                        GridViewPayer.DataSource = ObjListPayer;
                        GridViewPayer.DataBind();
                        GridViewPayer.Visible = true;
                        LabelPayer.Visible = true;
                        LabelPayer.Text = "IIB query output for Payer";

                        var PayerPolicyCountDetails = (from Pstatus in ObjListPayer.AsEnumerable()
                                                       group Pstatus by Pstatus.Quest_Policy_Status
                                                into g
                                                       select new TotalPolicyDO
                                                       {
                                                           PolicyNo = g.First().QuestDBNo,
                                                           PolicyStatus = g.First().Quest_Policy_Status,
                                                           TotalSA = g.Sum(f => f.Quest_Sum_Assured),

                                                       }).ToList();

                        if (PayerPolicyCountDetails.Count > 0)
                        {
                            GridViewPayerPolicy.DataSource = PayerPolicyCountDetails;
                            GridViewPayerPolicy.DataBind();
                            GridViewPayerPolicy.Visible = true;
                            //lblPayerPolicyDetails.Visible = true;
                            //lblPayerPolicyDetails.Text = "Total Policy Status";

                        }
                    }

                    if (ObjListProposer.Count > 0)
                    {
                        ProposerDiv.Style.Add("display", "block");
                        GridViewProposer.DataSource = ObjListProposer;
                        GridViewProposer.DataBind();
                        GridViewProposer.Visible = true;
                        LabelProposer.Visible = true;
                        LabelProposer.Text = "IIB query output for proposer";

                        var ProposerPolicyCountDetails = (from Pstatus in ObjListProposer.AsEnumerable()
                                                          group Pstatus by Pstatus.Quest_Policy_Status
                                                into g
                                                          select new TotalPolicyDO
                                                          {
                                                              PolicyNo = g.First().QuestDBNo,
                                                              PolicyStatus = g.First().Quest_Policy_Status,
                                                              TotalSA = g.Sum(f => f.Quest_Sum_Assured),

                                                          }).ToList();

                        if (ProposerPolicyCountDetails.Count > 0)
                        {
                            GridViewProposerPolicy.DataSource = ProposerPolicyCountDetails;
                            GridViewProposerPolicy.DataBind();
                            GridViewProposerPolicy.Visible = true;
                            //lblProposerPolicyDetails.Visible = true;
                            //lblProposerPolicyDetails.Text= "Total Policy Status";

                        }
                    }
                }
                else
                {

                    var ObjListLANULL = ObjListClientTypeNull.ToList();
                    if (ObjListLANULL.Count > 0)
                    {
                        LADiv.Style.Add("display", "block");
                        GridViewLA.DataSource = ObjListLANULL;
                        GridViewLA.DataBind();
                        GridViewLA.Visible = true;
                        LabelLA.Visible = true;
                        LabelLA.Text = "IIB query output for Life Assured";

                        var LAPolicyCountDetailsNUll = (from Pstatus in ObjListLANULL.AsEnumerable()
                                                        group Pstatus by Pstatus.Quest_Policy_Status
                                                  into g
                                                        select new TotalPolicyDO
                                                        {
                                                            PolicyNo = g.First().QuestDBNo,
                                                            PolicyStatus = g.First().Quest_Policy_Status,
                                                            TotalSA = g.Sum(f => f.Quest_Sum_Assured),

                                                        }).ToList();

                        if (LAPolicyCountDetailsNUll.Count > 0)
                        {
                            GridViewLAPolicy.DataSource = LAPolicyCountDetailsNUll;
                            GridViewLAPolicy.DataBind();
                            GridViewLAPolicy.Visible = true;
                            //lblLAPolicyDetails.Visible = true;
                            //lblLAPolicyDetails.Text = "Total Policy Status";

                        }
                    }

                }

            }

            if (ObjIIBQueryDataDO.ObjListOFQueryOther.Count > 0)
            {
                var ObjListClientTypeNull = ObjIIBQueryDataDO.ObjListOFQueryOther.Where(x => x.Client_Type == "").ToList();

                var ObjListClientType = ObjIIBQueryDataDO.ObjListOFQueryOther.Where(x => x.Client_Type != "").ToList();


                if (ObjListClientType.Count > 0)
                {
                    var ObjListLA = ObjListClientType.Where(x => x.Client_Type.ToLower() == "la").ToList();

                    var ObjListPayer = ObjListClientType.Where(x => x.Client_Type.ToLower() == "payer").ToList();

                    var ObjListProposer = ObjListClientType.Where(x => x.Client_Type.ToLower() == "proposer").ToList();

                    if (ObjListLA.Count > 0)
                    {
                        DivGridViewOtherLA.Style.Add("display", "block");
                        GridViewOtherLA.DataSource = ObjListLA;
                        GridViewOtherLA.DataBind();
                        GridViewOtherLA.Visible = true;
                        lblGridViewOtherLA.Visible = true;
                        lblGridViewOtherLA.Text = "IIB query output for Life Assured";

                        lblothercompany.Visible = true;
                        lblothercompany.ForeColor = System.Drawing.Color.Red;
                        lblothercompany.Text = "The existing policies found in other insurance companies,please ensure to collect the information from client in proposal form / declaration";


                        var LAOtherPolicyCountDetails = (from Pstatus in ObjListLA.AsEnumerable()
                                                         group Pstatus by Pstatus.Quest_Policy_Status
                                                  into g
                                                         select new TotalPolicyDO
                                                         {
                                                             PolicyNo = g.First().QuestDBNo,
                                                             PolicyStatus = g.First().Quest_Policy_Status,
                                                             TotalSA = g.Sum(f => f.Quest_Sum_Assured),

                                                         }).ToList();

                        if (LAOtherPolicyCountDetails.Count > 0)
                        {
                            GridViewOtherLAPolicy.DataSource = LAOtherPolicyCountDetails;
                            GridViewOtherLAPolicy.DataBind();
                            GridViewOtherLAPolicy.Visible = true;
                        }


                    }

                    if (ObjListPayer.Count > 0)
                    {
                        DivGridViewOtherPayer.Style.Add("display", "block");
                        GridViewOtherPayer.DataSource = ObjListPayer;
                        GridViewOtherPayer.DataBind();
                        GridViewOtherPayer.Visible = true;
                        lblGridViewOtherPayer.Visible = true;
                        lblGridViewOtherPayer.Text = "IIB query output for Payer";

                        lblothercompany.Visible = true;
                        lblothercompany.ForeColor = System.Drawing.Color.Red;
                        lblothercompany.Text = "The existing policies found in other insurance companies,please ensure to collect the information from client in proposal form / declaration";

                        var PayerOTherPolicyCountDetails = (from Pstatus in ObjListPayer.AsEnumerable()
                                                            group Pstatus by Pstatus.Quest_Policy_Status
                                               into g
                                                            select new TotalPolicyDO
                                                            {
                                                                PolicyNo = g.First().QuestDBNo,
                                                                PolicyStatus = g.First().Quest_Policy_Status,
                                                                TotalSA = g.Sum(f => f.Quest_Sum_Assured),

                                                            }).ToList();

                        if (PayerOTherPolicyCountDetails.Count > 0)
                        {
                            GridViewOtherPayerPolicy.DataSource = PayerOTherPolicyCountDetails;
                            GridViewOtherPayerPolicy.DataBind();
                            GridViewOtherPayerPolicy.Visible = true;
                            //lblPayerPolicyDetails.Visible = true;
                            //lblPayerPolicyDetails.Text = "Total Policy Status";

                        }

                    }

                    if (ObjListProposer.Count > 0)
                    {
                        DivGridViewOtherProposal.Style.Add("display", "block");
                        GridViewOtherProposal.DataSource = ObjListProposer;
                        GridViewOtherProposal.DataBind();
                        GridViewOtherProposal.Visible = true;
                        lblGridViewOtherProposal.Visible = true;
                        lblGridViewOtherProposal.Text = "IIB query output for proposer";

                        lblothercompany.Visible = true;
                        lblothercompany.ForeColor = System.Drawing.Color.Red;
                        lblothercompany.Text = "The existing policies found in other insurance companies,please ensure to collect the information from client in proposal form / declaration";


                        var OtherProposerPolicyCountDetails = (from Pstatus in ObjListProposer.AsEnumerable()
                                                               group Pstatus by Pstatus.Quest_Policy_Status
                                                          into g
                                                               select new TotalPolicyDO
                                                               {
                                                                   PolicyNo = g.First().QuestDBNo,
                                                                   PolicyStatus = g.First().Quest_Policy_Status,
                                                                   TotalSA = g.Sum(f => f.Quest_Sum_Assured),

                                                               }).ToList();

                        if (OtherProposerPolicyCountDetails.Count > 0)
                        {
                            GridViewOtherProposerPolicy.DataSource = OtherProposerPolicyCountDetails;
                            GridViewOtherProposerPolicy.DataBind();
                            GridViewOtherProposerPolicy.Visible = true;


                        }


                    }

                }
                else
                {
                    var ObjListLANULL = ObjListClientTypeNull.ToList();
                    if (ObjListLANULL.Count > 0)
                    {
                        DivGridViewOtherLA.Style.Add("display", "block");
                        GridViewOtherLA.DataSource = ObjListLANULL;
                        GridViewOtherLA.DataBind();
                        GridViewOtherLA.Visible = true;
                        lblGridViewOtherLA.Visible = true;
                        lblGridViewOtherLA.Text = "IIB query output for Life Assured";

                        lblothercompany.Visible = true;
                        lblothercompany.ForeColor = System.Drawing.Color.Red;
                        lblothercompany.Text = "The existing policies found in other insurance companies,please ensure to collect the information from client in proposal form / declaration";

                        var OtherLAPolicyCountDetailsNUll = (from Pstatus in ObjListLANULL.AsEnumerable()
                                                             group Pstatus by Pstatus.Quest_Policy_Status
                                                 into g
                                                             select new TotalPolicyDO
                                                             {
                                                                 PolicyNo = g.First().QuestDBNo,
                                                                 PolicyStatus = g.First().Quest_Policy_Status,
                                                                 TotalSA = g.Sum(f => f.Quest_Sum_Assured),

                                                             }).ToList();

                        if (OtherLAPolicyCountDetailsNUll.Count > 0)
                        {
                            GridViewOtherLAPolicy.DataSource = OtherLAPolicyCountDetailsNUll;
                            GridViewOtherLAPolicy.DataBind();
                            GridViewOtherLAPolicy.Visible = true;
                        }


                    }
                }
            }


        }
        else if (Bindgrid == 2)  //IF DE DATA
        {
            if (ObjIIBQueryDataDO.ObjListOFQueryFG.Count > 0)
            {
                var ObjListLA = ObjIIBQueryDataDO.ObjListOFQueryFG.ToList();

                if (ObjListLA.Count > 0)
                {
                    LADiv.Style.Add("display", "block");
                    GridViewLA.DataSource = ObjListLA;
                    GridViewLA.DataBind();
                    GridViewLA.Visible = true;
                    LabelLA.Visible = true;
                    LabelLA.Text = "IIB query output for Life Assured";

                    var LAPolicyCountDetails = (from Pstatus in ObjListLA.AsEnumerable()
                                                group Pstatus by Pstatus.Quest_Policy_Status
                                              into g
                                                select new TotalPolicyDO
                                                {
                                                    PolicyNo = g.First().QuestDBNo,
                                                    PolicyStatus = g.First().Quest_Policy_Status,
                                                    TotalSA = g.Sum(f => f.Quest_Sum_Assured),

                                                }).ToList();

                    if (LAPolicyCountDetails.Count > 0)
                    {
                        GridViewLAPolicy.DataSource = LAPolicyCountDetails;
                        GridViewLAPolicy.DataBind();
                        GridViewLAPolicy.Visible = true;
                        //lblLAPolicyDetails.Visible = true;
                        //lblLAPolicyDetails.Text = "Total Policy Status";

                    }



                }
            }
            if (ObjIIBQueryDataDO.ObjListOFQueryOther.Count > 0)
            {
                var ObjListClientType = ObjIIBQueryDataDO.ObjListOFQueryOther.ToList();
                if (ObjListClientType.Count > 0)
                {
                    DivGridViewOtherLA.Style.Add("display", "block");
                    GridViewOtherLA.DataSource = ObjListClientType;
                    GridViewOtherLA.DataBind();
                    GridViewOtherLA.Visible = true;
                    lblGridViewOtherLA.Visible = true;
                    lblGridViewOtherLA.Text = "IIB query output for Life Assured";

                    lblothercompany.Visible = true;
                    lblothercompany.ForeColor = System.Drawing.Color.Red;
                    lblothercompany.Text = "The existing policies found in other insurance companies,please ensure to collect the information from client in proposal form / declaration";

                    var OtherLAPolicyCountDetails = (from Pstatus in ObjListClientType.AsEnumerable()
                                                     group Pstatus by Pstatus.Quest_Policy_Status
                                              into g
                                                     select new TotalPolicyDO
                                                     {
                                                         PolicyNo = g.First().QuestDBNo,
                                                         PolicyStatus = g.First().Quest_Policy_Status,
                                                         TotalSA = g.Sum(f => f.Quest_Sum_Assured),

                                                     }).ToList();

                    if (OtherLAPolicyCountDetails.Count > 0)
                    {
                        GridViewOtherLAPolicy.DataSource = OtherLAPolicyCountDetails;
                        GridViewOtherLAPolicy.DataBind();
                        GridViewOtherLAPolicy.Visible = true;

                    }

                }


            }

        }
    }

    #region show some cell in color 
    protected void GridViewLA_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string type = e.Row.Cells[12].Text;
            string Status = e.Row.Cells[4].Text;

            foreach (TableCell cell in e.Row.Cells)
            {
                if (type == "Y")
                {
                    e.Row.Cells[12].BackColor = System.Drawing.Color.Red;
                }

                //added by suraj to get red colour for status is pending suggested by Diju on 29 May 2021
                if (Status.Contains("Pending for U/w"))
                {
                    e.Row.Cells[4].BackColor = System.Drawing.Color.Red;

                }
            }
        }
    }
    protected void GridViewProposer_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string type = e.Row.Cells[12].Text;
            string Status = e.Row.Cells[4].Text;

            foreach (TableCell cell in e.Row.Cells)
            {
                if (type == "Y")
                {
                    e.Row.Cells[12].BackColor = System.Drawing.Color.Red;
                }

                //added by suraj to get red colour for status is pending suggested by Diju on 29 May 2021
                if (Status.Contains("Pending for U/w"))
                {
                    e.Row.Cells[4].BackColor = System.Drawing.Color.Red;

                }
            }
        }
    }

    protected void GridViewPayer_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string type = e.Row.Cells[12].Text;
            string Status = e.Row.Cells[4].Text;

            foreach (TableCell cell in e.Row.Cells)
            {
                if (type == "Y")
                {
                    e.Row.Cells[12].BackColor = System.Drawing.Color.Red;
                }

                //added by suraj to get red colour for status is pending suggested by Diju on 29 May 2021
                if (Status.Contains("Pending for U/w"))
                {
                    e.Row.Cells[4].BackColor = System.Drawing.Color.Red;

                }
            }
        }
    }
    #endregion


    protected void GridViewOtherLA_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string type = e.Row.Cells[12].Text;
            string Status = e.Row.Cells[4].Text;

            foreach (TableCell cell in e.Row.Cells)
            {
                if (type == "Y")
                {
                    e.Row.Cells[12].BackColor = System.Drawing.Color.Red;
                }

                //added by suraj to get red colour for status is pending suggested by Diju on 29 May 2021
                if (Status.Contains("Pending for U/w"))
                {
                    e.Row.Cells[4].BackColor = System.Drawing.Color.Red;

                }
            }
        }
    }

    protected void GridViewOtherProposal_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string type = e.Row.Cells[12].Text;
            string Status = e.Row.Cells[4].Text;

            foreach (TableCell cell in e.Row.Cells)
            {
                if (type == "Y")
                {
                    e.Row.Cells[12].BackColor = System.Drawing.Color.Red;
                }

                //added by suraj to get red colour for status is pending suggested by Diju on 29 May 2021
                if (Status.Contains("Pending for U/w"))
                {
                    e.Row.Cells[4].BackColor = System.Drawing.Color.Red;

                }
            }
        }
    }

    protected void GridViewOtherPayer_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string type = e.Row.Cells[12].Text;
            string Status = e.Row.Cells[4].Text;

            foreach (TableCell cell in e.Row.Cells)
            {
                if (type == "Y")
                {
                    e.Row.Cells[12].BackColor = System.Drawing.Color.Red;
                }

                //added by suraj to get red colour for status is pending suggested by Diju on 29 May 2021
                if (Status.Contains("Pending for U/w"))
                {
                    e.Row.Cells[4].BackColor = System.Drawing.Color.Red;

                }
            }
        }
    }


    #endregion End 38.1: This CR-2809 changes done by Sushant Devkate MFL00905
    //42.1 Begin of Changes; Sushant Devkate -MFL00905
    protected void ISSmbtnProceed_Click(object sender, EventArgs e)
    {
        string strOtherReason = string.Empty;
        string strReason = string.Empty;
        bool Reason = false;
        string SaveComments = string.Empty;
        int UWCommentResult = 0;
        try
        {
            if (rbUC.Checked)
            {
                SaveComments = strReason = rbUC.Text.Trim();
                Reason = rbUC.Checked;
            }
            else if (RBOther.Checked)
            {
                strReason = RBOther.Text.Trim();
                SaveComments = strOtherReason = txtotherReasons.Text.Trim();
                Reason = RBOther.Checked;
            }

            objChangeObj = (ChangeValue)Session["objLoginObj"];
            int Success = new Commfun().InsertSmokarReason(strApplicationno, chkSaralRiskIsSmoker.Checked, "", strReason, strOtherReason, objChangeObj.userLoginDetails._UserID);
            objCommonObj = (CommonObject)Session["objCommonObj"];
            objComm.OnlineUWCommentsDetails_Save(objChangeObj.userLoginDetails._UserName, objChangeObj.userLoginDetails._ProcessName, objChangeObj.userLoginDetails._UserGroup, SaveComments, strApplicationno, objChangeObj.userLoginDetails._UserID, objChangeObj.userLoginDetails._UserName, objChangeObj.userLoginDetails._UserGroup, objChangeObj.userLoginDetails._userBranch, objChangeObj.userLoginDetails._userBranch, objChangeObj.userLoginDetails._ProcessName, strApplicationno, ddlComment.SelectedValue, ref UWCommentResult);
            ddlComment.SelectedValue = "General";
            FillCommentsDetails(strApplicationno, strChannelType, ddlComment.SelectedValue);
            updCommentsDtls.Update();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#myModal", "$('.modal-backdrop').remove();$('#myModal').hide();", true);
            //ShowPopupMessage("Reason inserted successfully");
        }
        catch (Exception ex)
        {
            ShowPopupMessage(ex.Message);
            new Commfun().InsertSmokarReasonException(strApplicationno, "ISSmbtnProceed_Click_Combi", ex.Message, objChangeObj.userLoginDetails._UserID);
        }
    }

    protected void btncloseSmoker_Click(object sender, EventArgs e)
    {
        //chkRiskParamIsSmoker_CheckedChanged(null,null);
        chkSaralRiskIsSmoker.Checked = false;
    }

    //42.1 End of Changes; Sushant Devkate -MFL00905

    //43.1 Begin of Changes; Bhaumik Patel - [CR-4134]
    protected void lnkRedFlag_Click(object sender, EventArgs e)
    {
        chkredflag.Checked = false;
        FillRedFlagDetails(strApplicationno);
    }
    protected void btnsaveRedFlag_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow Row in GridRedFlag.Rows)
            {
                if (Row.RowType == DataControlRowType.DataRow)
                {
                    int RedFlagID = Convert.ToInt32(Row.Cells[0].Text);
                    DropDownList ddlredflaguwdecision = (DropDownList)Row.FindControl("ddlredflaguwdecision");
                    string Decision = ddlredflaguwdecision.SelectedItem.Text.ToString();  //_Dt.Rows[Row.RowIndex]["UW Decision"].ToString();

                    TextBox txtuwcomment = (TextBox)Row.FindControl("txtuwcomment");
                    string Comment = txtuwcomment.Text.ToString();  //_Dt.Rows[Row.RowIndex]["UW Comment"].ToString();

                    if (Decision != "Select" && Comment != "")
                    {
                        UpdateUWDecision_RedFlag(RedFlagID, Decision, Comment);
                    }
                    else
                    {
                        //  ScriptManager.RegisterStartupScript(Page, GetType(), "disp_confirm", "<script>ShowErrorMessage();</script>", false);
                    }

                }

            }
            chkredflag.Checked = false;
        }
        catch (Exception ex)
        {
            ShowPopupMessage(ex.Message);
            new Commfun().InsertRedFlagReasonException(strApplicationno, "btnSaveRedFlag", ex.Message, objChangeObj.userLoginDetails._UserID);
        }
    }
    public void UpdateUWDecision_RedFlag(int RedFlagID, string UWdecision, string UWcomments)
    {
        objComm.Online_Update_RedFlagDetails("UpdateUWDecision", strApplicationno, RedFlagID, UWdecision, UWcomments, strUserId);

    }
    protected void GridRedFlag_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridRedFlag.PageIndex = e.NewPageIndex;
        FillRedFlagDetails(strApplicationno);
    }
    //43.1 End of Changes; Bhaumik Patel - [CR-4134]
    //40.1 Begin of Changes; Sagar Thorave-[mfl00886]
    protected void Update_ENY_Click(object sender, EventArgs e)
    {
        if (IsENY == "true")
        {
            Get_EnyScore_Data();
        }

    }
    protected void Update_IIB_Score(object sender, EventArgs e)
    {

        //32.1 Begin of Changes; Brijesh Pandey - [MFL00464]
        string IIBScore = objComm.GetIIBRiskScore(strApplicationno, "UW", "UwdecisionCombi.aspx button_click", strUserId);
        //32.1 End of Changes; Brijesh Pandey - [MFL00464]
        txtIIBScore.Text = IIBScore.ToString();
        if (!string.IsNullOrWhiteSpace(txtIIBScore.Text) && Convert.ToInt32(txtIIBScore.Text) >= 700)
        {

            txtIIBScore.BackColor = System.Drawing.Color.Red;
            txtIIBScore.ForeColor = System.Drawing.Color.White;
        }
        else
        {
            if (!string.IsNullOrEmpty(txtIIBScore.Text))
            {
                txtIIBScore.BackColor = System.Drawing.Color.Green;
                txtIIBScore.ForeColor = System.Drawing.Color.White;
            }

        }

    }

    //40.1 End of Changes; Sagar Thorave-[mfl00886]


    // 46.1 Begin of Changes; Jayendra  - [Webashlar01]


    private void SetInitialRequirmentGrid_STP()
    {
        Logger.Info("STAG 2 :PageName :Uwdecision.aspx.CS // MethodeName :SetInitialRequirmentGrid_STP" + System.Environment.NewLine);
        DataTable dt = new DataTable();
        DataSet _ds = new DataSet();
        _ds.Tables.Add(dt);
        DataRow dr = null;

        //Define the Columns
        dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
        dt.Columns.Add(new DataColumn("REQ_followUpCode", typeof(string)));
        dt.Columns.Add(new DataColumn("REQ_description", typeof(string)));
        dt.Columns.Add(new DataColumn("REQ_category", typeof(string)));
        dt.Columns.Add(new DataColumn("REQ_criteria", typeof(string)));
        dt.Columns.Add(new DataColumn("REQ_lifeType", typeof(string)));
        dt.Columns.Add(new DataColumn("REQ_status", typeof(string)));
        dt.Columns.Add(new DataColumn("lblRaiseddate", typeof(string)));
        //dt.Columns.Add(new DataColumn("lblRaisedby", typeof(string)));
        dt.Columns.Add(new DataColumn("lblClosedDate", typeof(string)));
        //dt.Columns.Add(new DataColumn("lblClosedBy", typeof(string)));

        //Add a Dummy Data on Initial Load
        dr = dt.NewRow();
        dr["RowNumber"] = 1;
        dt.Rows.Add(dr);

        //Store the DataTable in ViewState
        ViewState["CurrentTable1_STP"] = _ds;
        //Bind the DataTable to the Grid
        gvRequirmentDetails.DataSource = _ds;
        gvRequirmentDetails.DataBind();

        DropDownList ddlfollowupcode = (DropDownList)gvRequirmentDetails_STP.Rows[0].Cells[0].FindControl("ddlfollowupcode_STP");
        TextBox txtLoadRider = (TextBox)gvRequirmentDetails_STP.Rows[0].Cells[1].FindControl("lblfollowupDiscp_STP");
        DropDownList ddlCategory = (DropDownList)gvRequirmentDetails_STP.Rows[0].Cells[2].FindControl("ddlCategory_STP");
        DropDownList ddlCriteria = (DropDownList)gvRequirmentDetails_STP.Rows[0].Cells[3].FindControl("ddlCriteria_STP");
        DropDownList ddlLifeType = (DropDownList)gvRequirmentDetails_STP.Rows[0].Cells[4].FindControl("ddlLifeType_STP");
        DropDownList ddlStatus = (DropDownList)gvRequirmentDetails_STP.Rows[0].Cells[5].FindControl("ddlStatus_STP");
        Label lblRaiseddate = (Label)gvRequirmentDetails_STP.Rows[0].Cells[6].FindControl("lblRaiseddate_STP");
        //Label lblRaisedby = (Label)gvRequirmentDetails.Rows[0].Cells[7].FindControl("lblRaisedby");
        Label lblClosedDate = (Label)gvRequirmentDetails_STP.Rows[0].Cells[8].FindControl("lblClosedDate_STP");
        // Label lblClosedBy = (Label)gvRequirmentDetails.Rows[0].Cells[9].FindControl("lblClosedBy");

        //Fill the DropDownList with Data
        //FillDropDownList(ddlLoadType, "LoadingCode", "Mst");
        btnReqaddrows.CssClass = "btn btn-primary";
        BindMasterDetails(ddlfollowupcode);
        BindMasterDetails(ddlCategory);
        BindMasterDetails(ddlCriteria);
        //BindMasterDetails(ddlLifeType);
        BindMasterDetails(ddlStatus);
    }

    private void SetPreviousData1_STP()
    {
        Logger.Info("STAG 2 :PageName :Uwdecision.aspx.CS // MethodeName :SetPreviousData1_STP" + System.Environment.NewLine);
        int rowIndex = 0;
        if (ViewState["CurrentTable1_STP"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable1_STP"];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count - 1; i++)
                {

                    DropDownList ddlfollowupcode = (DropDownList)gvRequirmentDetails_STP.Rows[i].Cells[0].FindControl("ddlfollowupcode_STP");
                    TextBox lblfollowupDiscp = (TextBox)gvRequirmentDetails_STP.Rows[i].Cells[1].FindControl("lblfollowupDiscp_STP");
                    DropDownList ddlCategory = (DropDownList)gvRequirmentDetails_STP.Rows[i].Cells[2].FindControl("ddlCategory_STP");
                    DropDownList ddlCriteria = (DropDownList)gvRequirmentDetails_STP.Rows[i].Cells[3].FindControl("ddlCriteria_STP");
                    DropDownList ddlLifeType = (DropDownList)gvRequirmentDetails_STP.Rows[i].Cells[4].FindControl("ddlLifeType_STP");
                    DropDownList ddlStatus = (DropDownList)gvRequirmentDetails_STP.Rows[i].Cells[5].FindControl("ddlStatus_STP");
                    Label lblRaiseddate = (Label)gvRequirmentDetails_STP.Rows[i].Cells[6].FindControl("lblRaiseddate_STP");
                    Label lblClosedDate = (Label)gvRequirmentDetails_STP.Rows[i].Cells[7].FindControl("lblClosedDate_STP");
                    //Label lblClosedBy = (Label)gvRequirmentDetails.Rows[i].Cells[9].FindControl("lblClosedBy");

                    //Fill the DropDownList with Data
                    //FillDropDownList(ddlfollowupcode, "followupcode", "Mst");
                    BindMasterDetails(ddlfollowupcode);

                    if (i < dt.Rows.Count - 1)
                    {
                        ddlfollowupcode.ClearSelection();
                        ddlfollowupcode.Items.FindByText(dt.Rows[i]["REQ_followUpCode"].ToString()).Selected = true;
                        ddlfollowupcode.SelectedValue = dt.Rows[i]["REQ_followUpCode"].ToString();
                        lblfollowupDiscp.Text = dt.Rows[i]["REQ_description"].ToString();
                        ddlCategory.SelectedValue = dt.Rows[i]["REQ_category"].ToString();
                        ddlCriteria.SelectedValue = dt.Rows[i]["REQ_criteria"].ToString();
                        ddlLifeType.SelectedValue = dt.Rows[i]["REQ_lifeType"].ToString();
                        ddlStatus.SelectedValue = dt.Rows[i]["REQ_status"].ToString();
                        lblRaiseddate.Text = dt.Rows[i]["REQ_RaisedDate"].ToString();
                        //lblRaisedby.Text = dt.Rows[i]["lblRaisedby"].ToString();
                        lblClosedDate.Text = dt.Rows[i]["REQ_ClosedDate"].ToString();
                        //lblClosedBy.Text = dt.Rows[i]["lblClosedBy"].ToString();
                    }
                    rowIndex++;
                }
            }
            //LinkButton lnkReqRemoveRow = (LinkButton)gvRequirmentDetails.Rows[dt.Rows.Count - 1].Cells[6].FindControl("lnkReqRemoveRow");
            //lnkReqRemoveRow.CssClass = "";
            btnReqaddrows.CssClass = "btn btn-primary";
            gvRequirmentDetails_STP.CssClass = "table table-bordered table-striped";
            UpdatePanel1.Update();
        }
    }

    private void AddNewRowToGrid1_STP()
    {
        Logger.Info("STAG 2 :PageName :Uwdecision.aspx.CS // MethodeName :AddNewRowToGrid1_STP" + System.Environment.NewLine);
        if (ViewState["CurrentTable1_STP"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable1_STP"];
            DataRow drCurrentRow = null;

            DropDownList REQ_followUpCode;
            TextBox REQ_description;
            DropDownList REQ_category;
            DropDownList REQ_criteria;
            DropDownList REQ_lifeType;
            DropDownList REQ_status;
            Label lblRaiseddate;
            //Label lblRaisedby;
            Label lblClosedDate;
            //Label lblClosedBy;

            if (dtCurrentTable.Rows.Count > 0)
            {
                drCurrentRow = dtCurrentTable.NewRow();
                // drCurrentRow["RowNumber"] = dtCurrentTable.Rows.Count + 1;
                //add new row to DataTable
                dtCurrentTable.Rows.Add(drCurrentRow);

                //Store the current data to ViewState
                ViewState["CurrentTable1_STP"] = dtCurrentTable;
                DateTime _strGetdate = DateTime.Now;
                for (int i = 0; i < dtCurrentTable.Rows.Count - 1; i++)
                {
                    //extract the DropDownList Selected Items
                    REQ_followUpCode = (DropDownList)gvRequirmentDetails_STP.Rows[i].Cells[0].FindControl("ddlfollowupcode_STP");
                    REQ_description = (TextBox)gvRequirmentDetails_STP.Rows[i].Cells[1].FindControl("lblfollowupDiscp_STP");
                    REQ_category = (DropDownList)gvRequirmentDetails_STP.Rows[i].Cells[2].FindControl("ddlCategory_STP");
                    REQ_criteria = (DropDownList)gvRequirmentDetails_STP.Rows[i].Cells[3].FindControl("ddlCriteria_STP");
                    REQ_lifeType = (DropDownList)gvRequirmentDetails_STP.Rows[i].Cells[4].FindControl("ddlLifeType_STP");
                    REQ_status = (DropDownList)gvRequirmentDetails_STP.Rows[i].Cells[5].FindControl("ddlStatus_STP");
                    lblRaiseddate = (Label)gvRequirmentDetails_STP.Rows[i].Cells[6].FindControl("lblRaiseddate_STP");
                    lblClosedDate = (Label)gvRequirmentDetails_STP.Rows[i].Cells[7].FindControl("lblClosedDate_STP");
                    dtCurrentTable.Rows[i]["REQ_followUpCode"] = REQ_followUpCode.SelectedValue;
                    dtCurrentTable.Rows[i]["REQ_description"] = REQ_description.Text;
                    dtCurrentTable.Rows[i]["REQ_category"] = REQ_category.SelectedValue;
                    dtCurrentTable.Rows[i]["REQ_criteria"] = REQ_criteria.SelectedValue;
                    dtCurrentTable.Rows[i]["REQ_lifeType"] = REQ_lifeType.SelectedValue;
                    dtCurrentTable.Rows[i]["REQ_status"] = REQ_status.SelectedValue;
                    dtCurrentTable.Rows[i]["REQ_RaisedDate"] = lblRaiseddate.Text == "" ? Convert.ToString(_strGetdate) : lblRaiseddate.Text;
                    dtCurrentTable.Rows[i]["REQ_ClosedDate"] = lblClosedDate.Text == "" ? (object)DBNull.Value : lblClosedDate.Text;

                }
                //35.1 Start of Changes; Sagar Thorave-[mfl00886]
                for (int i = 0; i < dtCurrentTable.Rows.Count - 1; i++)
                {
                    REQ_followUpCode = (DropDownList)gvRequirmentDetails.Rows[i].Cells[0].FindControl("ddlfollowupcode");

                    NotSelectMerCheckbox(REQ_followUpCode.Text);
                    SelectMerCheckbox(REQ_followUpCode.Text);
                    if (REQ_followUpCode.Text == "MPN" || REQ_followUpCode.Text == "MPV")
                        break;
                }
                //35.1 End of Changes; Sagar Thorave-[mfl00886]
                gvRequirmentDetails_STP.DataSource = dtCurrentTable;
                gvRequirmentDetails_STP.DataBind();

                UpdatePanel17_STP.Update();
            }
        }

        //Set Previous Data on Postbacks
        SetPreviousData1();
    }

    public void FillRUW_STP_Message(string strApplicationno)
    {
        Logger.Info(strApplicationno + "STAG 3 :PageName :Uwdecision.aspx.CS // MethodeName :FillBankDetails" + System.Environment.NewLine);
        objComm.OnlineRUW_STP_GET(ref _ds, strApplicationno);
        BindRUW_STP_Message(_ds.Tables[0]);
    }

    public void BindRUW_STP_Message(DataTable _ds)
    {
        if (_ds.Rows.Count > 0)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(_ds.Rows[0]["ErrorMessage"])))
            {
                clsName = divRUW_STP.Attributes["class"].ToString();
                if (clsName != "col-md-12")
                {
                    divRUW_STP.Attributes.Add("class", clsName.Replace(clsName, "col-md-12"));
                }
                Logger.Info(strApplicationno + "STAG3:-Function Call BindRUW_STP_Message" + System.Environment.NewLine);
                string RUW_Messages = string.Empty;
                foreach (DataRow row in _ds.Rows)
                {
                    RUW_Messages += row["ErrorMessage"].ToString() + "<br />";
                }
                lblRUW_STP.Text = RUW_Messages;
            }
        }
    }

    public void FillRequirmentDetails_STP(string strApplicationno, string ChannelType)
    {
        Logger.Info(strApplicationno + "STAG 3 :PageName :Uwdecision.aspx.CS // MethodeName :FillRequirmentDetails" + System.Environment.NewLine);
        objComm.OnlineRequirmentDisplayDetails_STP_GET(ref _dsRequrmentDtls_STP, strApplicationno, ChannelType);
        BindRequirmentDetails_STP(_dsRequrmentDtls_STP.Tables[0]);
    }

    protected void ddlfollowupcode_STP_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Logger.Info("STAG 2 :PageName :Uwdecision.aspx.CS // MethodeName :ddlfollowupcode_STP_SelectedIndexChanged");
            DataSet _dsFollowupSubDtls = new DataSet();
            // Get the master DropDownList and its value
            DropDownList ddlEditEducationEstablishment_STP = (DropDownList)sender;
            string educationEstablishmentCode = ddlEditEducationEstablishment_STP.SelectedValue;
            //35.1 Begin of Changes; Sagar Thorave-[mfl00886]
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable1_STP"];

            for (int i = 0; i < dtCurrentTable.Rows.Count - 1; i++)
            {
                DropDownList REQ_followUpCode = (DropDownList)gvRequirmentDetails.Rows[i].Cells[0].FindControl("ddlfollowupcode");

                NotSelectMerCheckbox(REQ_followUpCode.Text);
                SelectMerCheckbox(REQ_followUpCode.Text);
                if (REQ_followUpCode.Text == "MPN" || REQ_followUpCode.Text == "MPV")
                    break;
            }
            SelectMerCheckbox(educationEstablishmentCode);
            //35.1 End of Changes; Sagar Thorave-[mfl00886]
            // Get the GridViewRow in which this master DropDownList exists
            GridViewRow row = (GridViewRow)ddlEditEducationEstablishment_STP.NamingContainer;
            DropDownList ddlEditSchool = (DropDownList)row.FindControl("ddlfollowupcode_STP");
            FillSubMasterDetails(ref _dsFollowupSubDtls, educationEstablishmentCode, "followupcode", "");

            if (_dsFollowupSubDtls.Tables.Count > 0 && _dsFollowupSubDtls.Tables[0].Rows.Count > 0)
            {
                TextBox lblfollowupDiscp = (TextBox)row.FindControl("lblfollowupDiscp_STP");
                lblfollowupDiscp.Text = _dsFollowupSubDtls.Tables[0].Rows[0]["Followupdescp"].ToString();

                DropDownList ddlCategory = (DropDownList)row.FindControl("ddlCategory_STP");
                ddlCategory.SelectedValue = _dsFollowupSubDtls.Tables[0].Rows[0]["Category"].ToString();


                DropDownList ddlCriteria = (DropDownList)row.FindControl("ddlCriteria_STP");
                ddlCriteria.SelectedValue = _dsFollowupSubDtls.Tables[0].Rows[0]["Criteria"].ToString();

                DropDownList ddlLifeType = (DropDownList)row.FindControl("ddlLifeType_STP");
                ddlLifeType.SelectedValue = _dsFollowupSubDtls.Tables[0].Rows[0]["LifeType"].ToString();

                if (_dsFollowupSubDtls.Tables[0].Rows[0]["Criteria"].ToString() == "Text to be Appended")
                {
                    //lblfollowupDiscp.Enabled = true;
                    lblfollowupDiscp.CssClass = "form-control";
                }
                else
                {
                    lblfollowupDiscp.CssClass = "form-control lblLable";
                }
                UpdatePanel1.Update();
            }
        }
        catch (Exception Error)
        {
            objcomm.SaveErrorLogs("", "Failed", "UWPortfolio", "ddlfollowupcode_STP_SelectedIndexChanged", "UWPortfolio", "E-Error", "", "", Error.ToString());
        }
    }
    protected void gvRequirmentDetails_STP_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            int ReqCount = Convert.ToInt16(Session["ReqCount"]);
            Logger.Info("STAG 2 :PageName :Uwdecision.aspx.CS // MethodeName :gvRequirmentDetails_STP_RowDataBound");
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlAppNoReq = (DropDownList)e.Row.FindControl("ddlAppNoReq_STP");
                BindMasterDetails(ddlAppNoReq);

                DropDownList ddlfollowupcode = (DropDownList)e.Row.FindControl("ddlfollowupcode_STP");
                BindMasterDetails(ddlfollowupcode);

                DropDownList ddl1 = (DropDownList)e.Row.FindControl("ddlfollowupcode_STP");
                BindMasterDetails(ddl1);

                DropDownList ddlCategory = (DropDownList)e.Row.FindControl("ddlCategory_STP");
                BindMasterDetails(ddlCategory);

                DropDownList ddlCriteria = (DropDownList)e.Row.FindControl("ddlCriteria_STP");
                BindMasterDetails(ddlCriteria);

                DropDownList ddlStatus = (DropDownList)e.Row.FindControl("ddlStatus_STP");
                BindMasterDetails(ddlStatus);
                //FillDropDownList(ddl1, "followupcode", "Mst");
                _Dt = (DataTable)ViewState["CurrentTable1_STP"];
                if (_Dt.Rows.Count >= 1)
                {
                    //LinkButton lb = e.Row.FindControl("lnkReqRemoveRow") as LinkButton;
                    //ScriptManager.GetCurrent(this).RegisterAsyncPostBackControl(lb);

                    //Image ing = e.Row.FindControl("Image8") as Image;
                    ddlAppNoReq.SelectedValue = _Dt.Rows[e.Row.RowIndex]["REQ_APPLICATIONNOSTR"].ToString();

                    //DropDownList ddlfollowupcode = (DropDownList)e.Row.FindControl("ddlfollowupcode");
                    ddlfollowupcode.SelectedValue = _Dt.Rows[e.Row.RowIndex]["REQ_followUpCode"].ToString();

                    TextBox lblfollowupDiscp = (TextBox)e.Row.FindControl("lblfollowupDiscp");
                    lblfollowupDiscp.Text = _Dt.Rows[e.Row.RowIndex]["REQ_description"].ToString();

                    //DropDownList ddlCategory = (DropDownList)e.Row.FindControl("ddlCategory");
                    ddlCategory.SelectedValue = _Dt.Rows[e.Row.RowIndex]["REQ_category"].ToString();

                    //DropDownList ddlCriteria = (DropDownList)e.Row.FindControl("ddlCriteria");
                    ddlCriteria.SelectedValue = _Dt.Rows[e.Row.RowIndex]["REQ_criteria"].ToString();

                    DropDownList ddlLifeType = (DropDownList)e.Row.FindControl("ddlLifeType");
                    ddlLifeType.SelectedValue = _Dt.Rows[e.Row.RowIndex]["REQ_lifeType"].ToString();

                    Label lblRaiseddate = (Label)e.Row.FindControl("lblRaiseddate");
                    lblRaiseddate.Text = _Dt.Rows[e.Row.RowIndex]["REQ_RaisedDate"].ToString();

                    //Label lblRaisedby = (Label)e.Row.FindControl("lblRaisedby ");
                    //lblRaisedby.Text = _Dt.Rows[e.Row.RowIndex]["lblRaisedby "].ToString();

                    Label lblClosedDate = (Label)e.Row.FindControl("lblClosedDate");
                    lblClosedDate.Text = _Dt.Rows[e.Row.RowIndex]["REQ_ClosedDate"].ToString();

                    //Label lblClosedBy = (Label)e.Row.FindControl("lblClosedBy");
                    //lblClosedBy.Text = _Dt.Rows[e.Row.RowIndex]["lblClosedBy"].ToString();

                    if (ddlCategory.SelectedValue == "Medical")
                    {
                        DataSet dsREq = new DataSet();
                        objComm.GET_MedicalReportoShow(ref dsREq, strApplicationno);
                        if (dsREq.Tables.Count > 0 && dsREq.Tables[0].Rows.Count > 0)
                        {
                            ddlRequirementMedicalReason.SelectedValue = Convert.ToString(dsREq.Tables[0].Rows[0]["ReqMedicalReason"]);
                        }
                        else
                        {
                            ddlRequirementMedicalReason.SelectedValue = "9";
                        }
                    }

                    //DropDownList ddlStatus = (DropDownList)e.Row.FindControl("ddlStatus");
                    ddlStatus.SelectedValue = _Dt.Rows[e.Row.RowIndex]["REQ_status"].ToString();

                    //Added by Suraj on 19 APRIL 2018 for medical reason dropdown

                    //if (e.Row.RowIndex >= ReqCount)
                    //{
                    //    Image Img = (Image)e.Row.FindControl("Image8");
                    //    Img.CssClass = "";
                    //}
                    //else
                    //{
                    //    Image Img = (Image)e.Row.FindControl("Image8");
                    //    Img.CssClass = "HideControl";
                    //}

                }

            }
        }
        catch (Exception Error)
        {
            objcomm.SaveErrorLogs("", "Failed", "UWPortfolio", "gvRequirmentDetails_STP_RowDataBound", "UWPortfolio", "E-Error", "", "", Error.ToString());
        }
    }



    public void BindRequirmentDetails_STP(DataTable _dtRequrmentDtls_STP)
    {
        _dtRequrmentDtls_STP.Columns.RemoveAt(0);
        if (_dtRequrmentDtls_STP.Rows.Count > 0)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(_dtRequrmentDtls_STP.Rows[0]["REQ_Followupcode"])))
            {
                clsName = divRequirementDetails_STP.Attributes["class"].ToString();
                if (clsName != "col-md-12")
                {
                    divRequirementDetails_STP.Attributes.Add("class", clsName.Replace(clsName, "col-md-12"));
                }
                Logger.Info(strApplicationno + "STAG3:-Function Call BindRequirmentDetails_STP" + System.Environment.NewLine);
                ViewState["CurrentTable1_STP"] = _dtRequrmentDtls_STP.Copy();
                //ViewState["CurrentTable1"] = _dtRequrmentDtls;
                Session["ReqCount_STP"] = _dtRequrmentDtls_STP.Rows.Count;
                gvRequirmentDetails_STP.DataSource = _dtRequrmentDtls_STP;
                gvRequirmentDetails_STP.DataBind();
            }

        }
    }

    protected void btnRequirmentDtlsSave_STP_Click(object sender, EventArgs e)
    {
        Logger.Info("STAG 2 :PageName :Uwdecision.aspx.CS // MethodeName :btnRequirmentDtlsSave_STP_Click");
        string _strfollowupcode_stp = string.Empty;
        string _strfollowupdiscp_stp = string.Empty;
        string _strfollowupcategory_stp = string.Empty;
        string _strfollowupcriteria_stp = string.Empty;
        string _strfollowuplifetype_stp = string.Empty;
        string _strfollowupstatus_stp = string.Empty;
        int strFollowupResult_stp = 0;
        bool _FollowupStatus_stp = false;
        bool _strFolloUPflag_stp = true;
        lblErrorRequirementDetailBody.Text = lblErrorreqdtls.Text = string.Empty;
        // objCommonObj = (CommonObject)Session["objCommonObj"];
        objChangeObj = (ChangeValue)Session["objLoginObj"];
        foreach (GridViewRow rowfollowup in gvRequirmentDetails_STP.Rows)
        {
            DropDownList ddlfollowupcode_stp = rowfollowup.FindControl("ddlfollowupcode_STP") as DropDownList;
            DropDownList ddlCategory_stp = rowfollowup.FindControl("ddlCategory_STP") as DropDownList;
            DropDownList ddlCriteria_stp = rowfollowup.FindControl("ddlCriteria_STP") as DropDownList;
            DropDownList ddlStatus_stp = rowfollowup.FindControl("ddlStatus_STP") as DropDownList;
            DropDownList ddlLifeType_stp = rowfollowup.FindControl("ddlLifeType_STP") as DropDownList;
            TextBox lblfollowupDiscp_stp = rowfollowup.FindControl("lblfollowupDiscp_STP") as TextBox;
            _strfollowupcode_stp = ddlfollowupcode_stp.SelectedValue;
            _strfollowupcategory_stp = ddlCategory_stp.SelectedValue;
            _strfollowupcriteria_stp = ddlCriteria_stp.SelectedValue;
            _strfollowuplifetype_stp = ddlLifeType_stp.SelectedValue;
            _strfollowupstatus_stp = ddlStatus_stp.SelectedValue;
            _strfollowupdiscp_stp = lblfollowupDiscp_stp.Text;
            if (_strfollowupstatus_stp == "O")
            {
                _FollowupStatus_stp = true;
            }
            objBuss.FollowupDetails_Save(strChannelType, strApplicationno, _strfollowupcode_stp, _strfollowupdiscp_stp, _strfollowupcategory_stp, _strfollowupcriteria_stp, "", objChangeObj.userLoginDetails._UserID, _strfollowupstatus_stp,
                _strfollowupcategory_stp, _strfollowuplifetype_stp, objChangeObj.userLoginDetails._UserID, objChangeObj.userLoginDetails._UserName, objChangeObj.userLoginDetails._UserGroup, objChangeObj.userLoginDetails._userBranch, objChangeObj.userLoginDetails._userBranch, strChannelType, strApplicationno, ref strFollowupResult_stp);
            if (strFollowupResult_stp == 0)
            {
                _strFolloUPflag_stp = false;
            }
        }
        if (_strFolloUPflag_stp)
        {
            chkReqDtls.Checked = false;
            lblErrorreqdtls.Text = "Requirment details save successfully";
            objUWDecision.OnlineApplicationLAServiceDetails_PUSH(strApplicationno, strChannelType, objChangeObj, ref _ds, ref _dsPrevPol, "FOLLOWUP", ref strLApushErrorCode, ref strLApushStatus, ref strConsentRespons);
            if (strLApushErrorCode == 0)
            {
                if (_FollowupStatus_stp == true)
                {
                    //objCommonObj = (CommonObject)Session["objCommonObj"];
                    // strUserId = objCommonObj._Bpmuserdetails._UserID;
                    // strApplicationno = objCommonObj._ApplicationNo;
                    //strUserGroup = objCommonObj._Bpmuserdetails._UserGroup;
                    objChangeObj = (ChangeValue)Session["objLoginObj"];
                    strUserGroup = objChangeObj.userLoginDetails._UserGroup;
                    //strAppstatusKey = (strUserGroup == "UW") ? "UR" : "DR";
                    strAppstatusKey = (strUserGroup == "UW") ? "UR" : "DR";
                    objComm.OnlineApplicationchangeStatus(strApplicationno, objChangeObj.userLoginDetails._UserID, strAppstatusKey, "", ref strFollowupResult_stp);
                }
                chkReqDtls.Checked = false;
                btnReqaddrows.CssClass = "btn-primary HideControl";
                lblErrorreqdtls.Text = "Requirment Details Updated in Life Asia successfully";
                lblErrorRequirementDetailBody.Text = "Requirment Details Updated in Life Asia successfully";
                FillRequirmentDetails(strApplicationno, strChannelType);
            }
            else
            {
                chkReqDtls.Checked = false;
                lblErrorreqdtls.Text = "Requirment Details Not Updated in Life Asia,Please Contact system admin";
                lblErrorRequirementDetailBody.Text = strLApushStatus;
            }
        }
        else
        {
            chkReqDtls.Checked = false;
            lblErrorRequirementDetailBody.Text = "Requirment details Not Updated in DataBase";
            lblErrorreqdtls.Text = "Requirment details Not Save CLICK to know more";
        }
    }

    protected void btnReqaddrows_STP_Click(object sender, EventArgs e)
    {
        try
        {
            /*added by shri on 28 dec 17 to add tracking*/
            int intTrackingRet = -1;
            objCommonObj = (CommonObject)Session["objCommonObj"];
            strUserId = objCommonObj._Bpmuserdetails._UserID;
            InsertUwDecisionTracking(strApplicationno, strUserId, DateTime.Now, "REQ_ADD_NEW_ROW", ref intTrackingRet);
            /*end here*/
            Logger.Info("STAG 2 :PageName :Uwdecision.aspx.CS // MethodeName :btnReqaddrows_Click");
            if (gvRequirmentDetails.Rows.Count <= 0)
            {
                SetInitialRequirmentGrid_STP();
            }
            else
            {
                AddNewRowToGrid1_STP();
            }
            /*added by shri on 28 dec 17 to update tracking*/
            UpdateUwDecisionTracking(intTrackingRet, DateTime.Now, ref intTrackingRet);
            /*END HERE*/
        }
        catch (Exception)
        {

        }
        finally
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "disp_confirm", "<script>hideloading()</script>", false);
        }

    }

    protected void lnkReqDtlsRefresh_STP_Click(object sender, EventArgs e)
    {
        chkReqDtls.Checked = false;
        //objCommonObj = (CommonObject)Session["objCommonObj"];
        FillRequirmentDetails_STP(strApplicationno, strChannelType);
    }

    protected void ddlCommonStatus_STP_SelectedIndexChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow gvRow in gvRequirmentDetails_STP.Rows)
        {
            DropDownList ddlStatus = gvRow.FindControl("ddlStatus_STP") as DropDownList;
            ddlStatus.SelectedValue = ddlCommonStatus_STP.SelectedValue;
        }
        clsName = gvRequirmentDetails_STP.CssClass.Replace("lblLable", "");
        gvRequirmentDetails_STP.CssClass = clsName;
        ddlCommonStatus_STP.Enabled = true;
        clsName = ddlCommonStatus_STP.CssClass.Replace("lblLable", "");
        ddlCommonStatus_STP.CssClass = clsName;

    }

    protected void btnCommonEvent_STP_Command(object sender, CommandEventArgs e)
    {
        //if (Session["objLoginObj"] != null)
        //{
        //    objChangeObj = (ChangeValue)Session["objLoginObj"];
        //    int intRetVal = -1;
        //    objcomm.MaintainApplicationLog(strApplicationno, e.CommandName, string.Empty, objChangeObj.userLoginDetails._UserID, ref intRetVal);
        //}
    }

    protected void btnSearchCode_STP_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('REQ_SearchCode.aspx','mywindow','menubar=1,resizable=1,width=900,height=600');", true);
    }

    protected void btnMedDataentry_STP_Click1(object sender, EventArgs e)
    {

        string url = "MedicalDataEntry.aspx?qsAppNo=" + strApplicationno + "&qsPolicyNo=" + strPolicyNo;
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('" + url + "');", true);
    }
    // 46.1 End of Changes; Jayendra  - [Webashlar01]

    // 49.1 Begin of Changes; Sagar
    protected void showacceptanceApprove()
    {
        foreach (RepeaterItem item in rptDecision.Items)
        {
            ListBox ddlAcceptanceReason = item.FindControl("ddlAcceptanceReason") as ListBox;
            Label lblAppno = item.FindControl("lblAppno") as Label;
            if (txtriskcat.Text == "High" || txtriskcat.Text == "Very High Risk")
            {
                if (string.IsNullOrEmpty(ddlAcceptanceReason.SelectedValue))
                {
                    ShowPopupMessage("" + struserName + "Please select Acceptance Reason");
                    throw new Exception("UDE-" + struserName + "Please select Acceptance Reason");
                }
                else
                {
                    //50.1 Begin of Changes; Jayendra Patnakar - [WebAshlar01]
                    TextBox txtAcceptanceOtherReasonText = (TextBox)item.FindControl("txtAcceptanceOtherReasonText");
                    string reasons = Request.Form[ddlAcceptanceReason.UniqueID];
                    if (reasons.Contains("Others (Free Text)") && string.IsNullOrEmpty(txtAcceptanceOtherReasonText.Text))
                    {
                        ShowPopupMessage("" + struserName + "Please select Acceptance Other Reason Text");
                        throw new Exception("UDE-" + struserName + "Please select Acceptance Other Reason Text");
                    }
                    //50.1 End of Changes; Jayendra Patnakar - [WebAshlar01]
                    objComm.InsertAcceptanceReason(reasons, txtAcceptanceOtherReasonText.Text, lblAppno.Text, txtAppno.Text);
                }

            }
        }
    }

    // 49.1 End of Changes; Sagar
}