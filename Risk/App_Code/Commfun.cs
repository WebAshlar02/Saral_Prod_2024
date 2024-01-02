/*
*********************************************************************************************************************************
COMMENT ID: 1
COMMENTOR NAME :SHRIJEET SHANIL
METHODE/EVENT:PAGE LOAD
REMARK: ADDED BY SHRI TO UPLOAD RISK E&Y
DateTime :10MAY18
**********************************************************************************************************************************
 ***********************************************************************************************************************************
COMMENT ID: 2
COMMENTOR NAME :AJAY SAHU
METHODE/EVENT:UnderWritingRequirementUpload
REMARK: TO upload datatable into table 
DateTime :26MAY18
**********************************************************************************************************************************
*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Platform.Utilities.LoggerFramework;


/// <summary>
/// Summary description for Commfun
/// </summary>
public class Commfun
{
    
    DataLayer objData = new DataLayer();
   
    /*added by shri on 29 dec 17 for risk parameter*/
    public void FetchBulkRiskApplication(string strApplicationNo, ref DataSet ds)
    {
        try
        {
            Logger.Info("STAG 2 :PageName :BAL.CS // MethodeName :UpdateApplicationStatus");
            SqlParameter[] _sqlparam = new SqlParameter[1];
            _sqlparam[0] = new SqlParameter("@APPLICATION_NO", strApplicationNo);
            ds = objData.RetrieveDataset("USP_UWSARAL_MANAGE_RISK_APPLICATION", _sqlparam);
        }
        catch (Exception Error)
        {
            Logger.Error("STAG 2 :PageName :BAL.CS // MethodeName :UpdateAppStatus Error :" + System.Environment.NewLine + Error.ToString());
            //SaveErrorLogs("", "Failed", "UWAutoIssuence", "BAL.CS", "UpdateAppStatus", "E-Error", "", "", Error.ToString());
        }
    }

    public void FetchDesignChange(string UserId , ref DataSet ds)
    {
        try
        {
            Logger.Info("STAG 2 :PageName :BAL.CS // MethodeName :UpdateApplicationStatus");
            SqlParameter[] _sqlparam = new SqlParameter[1];
            _sqlparam[0] = new SqlParameter("@UserId", UserId);
            ds = objData.RetrieveDataset("USP_UWSARAL_RISK_DASHBOARD_MANAGE", _sqlparam);
        }
        catch (Exception Error)
        {
            Logger.Error("STAG 2 :PageName :BAL.CS // MethodeName :UpdateAppStatus Error :" + System.Environment.NewLine + Error.ToString());
            //SaveErrorLogs("", "Failed", "UWAutoIssuence", "BAL.CS", "UpdateAppStatus", "E-Error", "", "", Error.ToString());
        }
    }

    /*added by shri on 24 dec 17 for risk parameter*/
    public void ManageBulkRiskParameter(DataTable _dtRiskParameter, ref int intRet)
    {
        try
        {
            Logger.Info("STAG 2 :PageName :BAL.CS // MethodeName :UpdateApplicationStatus");
            SqlParameter[] _sqlparam = new SqlParameter[1];
            _sqlparam[0] = new SqlParameter("@TYP_UWSARAL_RISK_PARAMETER", _dtRiskParameter);
            objData.Insertrecord("USP_UWSARAL_MANAGE_RISK_PARAMETER", _sqlparam);
        }
        catch (Exception Error)
        {
            Logger.Error("STAG 2 :PageName :BAL.CS // MethodeName :UpdateAppStatus Error :" + System.Environment.NewLine + Error.ToString());
            //SaveErrorLogs("", "Failed", "UWAutoIssuence", "BAL.CS", "UpdateAppStatus", "E-Error", "", "", Error.ToString());
        }
    }
    public void TPADocsManualInsert(DataTable _dtRiskParameter, ref int intRet)
    {
        try
        {
            Logger.Info("STAG 2 :PageName :BAL.CS // MethodeName :UpdateApplicationStatus");
            SqlParameter[] _sqlparam = new SqlParameter[1];
            _sqlparam[0] = new SqlParameter("@TYP_UWSARAL_TPA_MANUAL_PUSH", _dtRiskParameter);
            intRet = objData.Insertrecord("[TRANSACTIONDBLFTPA].DBO.[USP_UWSARAL_TPA_UTILITY_MANUAL_DMS_PUSH]", _sqlparam);
        }
        catch (Exception Error)
        {
            Logger.Error("STAG 2 :PageName :BAL.CS // MethodeName :UpdateAppStatus Error :" + System.Environment.NewLine + Error.ToString());
            //SaveErrorLogs("", "Failed", "UWAutoIssuence", "BAL.CS", "UpdateAppStatus", "E-Error", "", "", Error.ToString());
        }
    }
    public void ManageBulkRiskEANDYCASES(DataTable _dtRiskParameter, ref int intRet)
    {
        try
        {
            Logger.Info("STAG 2 :PageName :BAL.CS // MethodeName :UpdateApplicationStatus");
            SqlParameter[] _sqlparam = new SqlParameter[1];
            _sqlparam[0] = new SqlParameter("@TYP_UWSARAL_RISK_EANDY", _dtRiskParameter);
            objData.Insertrecord("USP_UWSARAL_MANAGE_RISK_EANDY_CASES", _sqlparam);
        }
        catch (Exception Error)
        {
            Logger.Error("STAG 2 :PageName :BAL.CS // MethodeName :UpdateAppStatus Error :" + System.Environment.NewLine + Error.ToString());
            //SaveErrorLogs("", "Failed", "UWAutoIssuence", "BAL.CS", "UpdateAppStatus", "E-Error", "", "", Error.ToString());
        }
    }
    /*ID:2 START*/
    public void UnderWritingRequirementUpload(DataTable _dtRiskParameter, ref int intRet)
    {
        try
        {
            Logger.Info("STAG 2 :PageName :BAL.CS // MethodeName :UnderWritingRequirementUpload");
            SqlParameter[] _sqlparam = new SqlParameter[1];
            _sqlparam[0] = new SqlParameter("@dt", _dtRiskParameter);
            intRet = objData.Insertrecord("[TRANSACTIONDBLFTPA].DBO.[USP_UWSARAL_UTILITY_UNDERWRITER_MEDICAL_REQ_RAISED_CASES]", _sqlparam);
            if (intRet == -1)
            {
                intRet = 1;
            }
        }
        catch (Exception Error)
        {
            Logger.Error("STAG 2 :PageName :BAL.CS // MethodeName :UpdateAppStatus Error :" + System.Environment.NewLine + Error.ToString());
            throw new Exception(Error.Message);
            //SaveErrorLogs("", "Failed", "UWAutoIssuence", "BAL.CS", "UpdateAppStatus", "E-Error", "", "", Error.ToString());
        }
    }
    /*ID:2 END*/

    //changes start CR-27523 Kavita 19/07/2020
    public void FetchRiskAllocationCount(ref DataSet ds,string Mode,string AppNo)
    {
        try
        {
            Logger.Info("STAG 2 :PageName :BAL.CS // MethodeName :UpdateApplicationStatus");
            SqlParameter[] _sqlparam = new SqlParameter[2];
            _sqlparam[0] = new SqlParameter("@Mode", Mode);
            _sqlparam[1] = new SqlParameter("@AppNo",AppNo);
            ds = objData.RetrieveDataset1("Usp_TUWSaralFetchRiskInvestAlloc", _sqlparam);
        }
        catch (Exception Error)
        {
            Logger.Error("STAG 2 :PageName :BAL.CS // MethodeName :FetchRiskAllocationCount Error :" + System.Environment.NewLine + Error.ToString());
            //SaveErrorLogs("", "Failed", "UWAutoIssuence", "BAL.CS", "UpdateAppStatus", "E-Error", "", "", Error.ToString());
        }
    }

    //changes start CR-27523
    public void FetchProductDetails(ref DataSet ds, string strLookupCode)
    {
        try
        {
            Logger.Info("STAG 2 :PageName :BAL.CS // MethodeName :FetchProductDetails");
            SqlParameter[] _sqlparam = new SqlParameter[2];
            _sqlparam[0] = new SqlParameter("@lookupCode", strLookupCode);
            _sqlparam[1] = new SqlParameter("@CommandType", "DropDown");
            ds = objData.RetrieveDataset1("usp_QA_GetMasterData_V2", _sqlparam);
            
        }
        catch (Exception Error)
        {
            Logger.Error("STAG 2 :PageName :BAL.CS // MethodeName :FetchProductDetails Error :" + System.Environment.NewLine + Error.ToString());
            //SaveErrorLogs("", "Failed", "UWAutoIssuence", "BAL.CS", "UpdateAppStatus", "E-Error", "", "", Error.ToString());
        }
    }


    public void Save_RiskDecision(string APPNO, string prodcode, string prodName, string TotalPre, string uwcomment, string RcuDecision, string VenderName, string strUserId, string status, ref int output)
    {
        try
        {
            Logger.Info("STAG 2 :PageName :BAL.CS // MethodeName :Save_RiskDecision");
            SqlParameter[] _sqlparam = new SqlParameter[10];
            _sqlparam[0] = new SqlParameter("@AppNo", APPNO);
            _sqlparam[1] = new SqlParameter("@ProductCode", prodcode);
            _sqlparam[2] = new SqlParameter("@ProductName", prodName);
            _sqlparam[3] = new SqlParameter("@TotalPremium", TotalPre);
            _sqlparam[4] = new SqlParameter("@UWComment", uwcomment);
            _sqlparam[5] = new SqlParameter("@RCUDecision", RcuDecision);
            _sqlparam[6] = new SqlParameter("@UserId", strUserId);
            _sqlparam[7] = new SqlParameter("@AssignToVender", VenderName);
            _sqlparam[8] = new SqlParameter("@Mode", "RiskUpd");
            _sqlparam[9] = new SqlParameter("@Status", status);
            output = objData.InsertUpdateRiskRecord("Usp_SaralRiskInvestigationUpdateIsActive", _sqlparam);
        }
        catch (Exception Error)
        {
            Logger.Error("STAG 2 :PageName :BAL.CS // MethodeName :Save_RiskDecision Error :" + System.Environment.NewLine + Error.ToString());
             
        }
    }


    //changes End  End CR-27523 Kavita 19/07/2020
}
