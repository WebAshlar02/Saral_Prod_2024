//****************************************************************************************************************************************
//COMMENT ID: 1
//COMMENTOR NAME : Akshada N Wagh
//METHODE/EVENT:
//REMARK: CR-26273 Reinstatment Email-SMS Communications to be triggered.
//DateTime :04June2020
//*********************************************************************************************************************************/

//************************************************************************************************************************************
//COMMENT ID: 2
//COMMENTOR NAME : AKSHADA WAGH
//METHODE/EVENT:
//REMARK: CHANGES MADE TO TRIGGER EMAIL AND SMS FOR CONSENT FOLLOWUP CODE RAISED.
//DateTime :02-09-2020
//***********************************************************************************************************************************
//********************************************************************
// Sr. No.              : 3
// Company              : Life            
// Module               : UW Saral   
//METHODE/EVENT:BUSSINESS LAYER
// Program Author       : Sushant Devkate - MFL00905
// BRD/CR/Codesk No/Win :  CR-30543 
// Date Of Creation     :  12/10/2022
// Description          : Added functinality on IsSmokar 
//***********************************************************
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Microsoft.ApplicationBlocks.Data;
/// <summary>
/// Summary description for DataLayer
/// </summary>
public class DataLayer
{
    public DataLayer()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region variable declaration Begins

    string strCon = string.Empty;
    SqlConnection sqlCon = null;
    SqlCommand sqlCom = null;
    SqlDataAdapter sqlDA = null;
    SqlDataReader _dr;

    #endregion variable declaration End

    #region Event Begins.
    public DataSet RetrieveDataset_woParam(string spName)
    {
        DataSet _ds;
        string strCon = ConfigurationSettings.AppSettings["transactiondbLF"];
        _ds = SqlHelper.ExecuteDataset(strCon, CommandType.StoredProcedure, spName);
        return _ds;
    }

    public DataSet RetrieveDataset(string spName, SqlParameter[] sqlParam)
    {
        try
        {
            DataSet _ds;
            string strCon = ConfigurationSettings.AppSettings["transactiondbLF"];
            _ds = SqlHelper.ExecuteDataset(strCon, CommandType.StoredProcedure, spName, sqlParam);
            return _ds;
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }

    public int Insertrecord(string spName, SqlParameter[] sqlParam)
    {
        string cnStr = ConfigurationSettings.AppSettings["transactiondbLF"];
        int result;
        result = SqlHelper.ExecuteNonQuery(cnStr, CommandType.StoredProcedure, spName, sqlParam);
        return result;
    }

    public int InsertUpdaterecord(string spName, SqlParameter[] sqlParam)
    {
        string cnStr = ConfigurationSettings.AppSettings["FGLICRM"];
        int result;
        result = SqlHelper.ExecuteNonQuery(cnStr, CommandType.StoredProcedure, spName, sqlParam);
        return result;
    }
    //public DataSet RetrieveDataset_OnlineSales(string spName, SqlParameter[] sqlParam)
    //{
    //    DataSet _ds;
    //    string strCon = ConfigurationSettings.AppSettings["OnlineSalesSTG"];
    //    _ds = SqlHelper.ExecuteDataset(strCon, CommandType.StoredProcedure, spName, sqlParam);
    //    return _ds;
    //}

    //##########################1.1 Begin of Changes CR 26273;Akshada ###########################################
    public DataSet RetrieveDataset_STPDetails(string spName, SqlParameter[] sqlParam)
    {
        DataSet _ds;
        string strCon = ConfigurationSettings.AppSettings["transactiondbLF"];
        _ds = SqlHelper.ExecuteDataset(strCon, CommandType.StoredProcedure, spName, sqlParam);
        return _ds;
    }
    public DataSet RetrieveDataset_PROCODE(string spName, SqlParameter[] sqlParam)
    {
        DataSet _ds;
        string strCon = ConfigurationSettings.AppSettings["Lombardimatersync"];
        _ds = SqlHelper.ExecuteDataset(strCon, CommandType.StoredProcedure, spName, sqlParam);
        return _ds;
    }
    public DataSet revivaldate(string spName, SqlParameter[] sqlParam)
    {
        //DataTable dtdate;
        DataSet dsdate;
        string cnStr = ConfigurationSettings.AppSettings["transactiondbLF"];

        dsdate = SqlHelper.ExecuteDataset(cnStr, CommandType.StoredProcedure, spName, sqlParam);
        //dtdate = dsdate.Tables[0];
        return dsdate;
    }
    //########################## 1.1 End of Changes CR 26273;Akshada  ###########################################

    #endregion Event Ends.

    //########################## 2.1 Begin of Changes by Akshada; CR-28153 ###########################################
    public DataSet GetClientDetails(string spName, SqlParameter[] sqlParam)
    {
        //DataTable dtdate;
        DataSet dsClientdata;
        string cnStr = ConfigurationManager.AppSettings["transactiondbLF"];

        dsClientdata = SqlHelper.ExecuteDataset(cnStr, CommandType.StoredProcedure, spName, sqlParam);
        //dtdate = dsdate.Tables[0];
        return dsClientdata;
    }
    public DataSet GetClientdata(string spName, SqlParameter[] sqlParam)
    {
        //DataTable dtdate;
        DataSet dsClientdata;
        string cnStr = ConfigurationManager.AppSettings["transactiondbLF"];

        dsClientdata = SqlHelper.ExecuteDataset(cnStr, CommandType.StoredProcedure, spName, sqlParam);
        //dtdate = dsdate.Tables[0];
        return dsClientdata;
    }
    //########################## 2.1 End of Changes by Akshada; CR-28153 ###########################################

    #region  Start: CR-30363-Add and Delete Negative Pincode functionality changes by Sushant Devkate [MFL00905]
    public int DeleteRecord(string spName, SqlParameter[] sqlParam)
    {
        string cnStr = ConfigurationManager.AppSettings["transactiondbLF"];
        int result;
        result = SqlHelper.ExecuteNonQuery(cnStr, CommandType.StoredProcedure, spName, sqlParam);
        return result;
    }
    #endregion  End: CR-30363-Add and Delete Negative Pincode functionality changes by Sushant Devkate [MFL00905]

    #region 3.1 Begin Of Changes Of CR-30543 changes by Sushant Devkate [MFL00905]
    public bool IsCheckData(string spName, SqlParameter[] sqlParam)
    {
        string cnStr = ConfigurationSettings.AppSettings["transactiondbLF"];
        bool IsSucess = false;

        IsSucess = Convert.ToBoolean(SqlHelper.ExecuteScalar(cnStr, CommandType.StoredProcedure, spName, sqlParam));

        return IsSucess;
    }

    #endregion 3.1 End Of Changes Of CR-30543 changes by Sushant Devkate [MFL00905]

}