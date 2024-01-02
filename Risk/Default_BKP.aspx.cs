/*
*********************************************************************************************************************************
COMMENT ID: 1
COMMENTOR NAME :SHRIJEET SHANIL
METHODE/EVENT:PAGE LOAD
REMARK: ADDED BY SHRI TO UPLOAD RISK E&Y
DateTime :10MAY18
**********************************************************************************************************************************
*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Platform.Utilities.LoggerFramework;
using System.IO;
using System.Data.OleDb;
using System.Configuration;
using System.Globalization;
using System.Collections;
using ClosedXML.Excel;

public partial class _Default : System.Web.UI.Page
{

    #region Variable Declaration Begins.
    DataSet _ds = new DataSet();

    string strUserId = string.Empty;
    string strUWmode = string.Empty;
    string strUserGroup = string.Empty;
    string strApplicationno = string.Empty;
    string strOptinselected = string.Empty;
    string strAppstatusKey = string.Empty;
    public string strPolicyEnquiery = string.Empty;
    int Result = 0;
    DataSet _dsDashcount = null;
    Commfun objComm = new Commfun();
    CommanObj objCommonObj = new CommanObj();
    Boolean IsPageRefresh;
    #endregion Variable declaration End.

    DataTable _dtExcel = null;
    int fileSize = 0;
    Commfun objCommFun = null;
    DataSet ds = null;
    int intRet;
    public string strScreen = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                Logger.Error("STAG 2 :PageName :Default.CS// MethodeName :Pageload  info: application start");
                if (Session["objCommonObj"] != null)
                {
                    objCommonObj = (CommanObj)Session["objCommonObj"];
                    objCommonObj._ChannelType = "OFFLINE";
                    Session["objCommonObj"] = objCommonObj;
                    strUWmode = "OFFLINE";
                    strUserId = objCommonObj._Bpmuserdetails._UserID;
                    Logger.Error("STAG 2 :PageName :Default.CS// MethodeName :Pageload  info: Userid Call");
                    FnDesignChange(strUserId);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
              "err_msg",
              "alert'(User Unknown!)');",
              true);
                }
                Logger.Error("STAG 2 :PageName :Default.CS// MethodeName :Pageload  info: SucessFully");
            }
            catch (Exception ex)
            {
                Logger.Error("STAG 2 :PageName :BAL.CS // MethodeName :UpdateAppStatus Error :" + System.Environment.NewLine + ex.ToString());
            }

        }

    }
    protected void lnkFreshCase_Click(object sender, EventArgs e)
    {
        try
        {
            Logger.Error("STAG 2 :PageName :Default.CS// MethodeName :lnkFreshCase_Click  info: start");
            LinkButton lnkOptinselected = (LinkButton)sender;

            if (lnkOptinselected.Text == "RiskUpload")
            {
                Logger.Error("STAG 2 :PageName :Default.CS// MethodeName :lnkFreshCase_Click  info: RiskUpload call");
                LoadingDtls_container.Visible = true;
                dvSearch.Visible = false;

            }
            if (lnkOptinselected.Text == "RiskView")
            {
                Logger.Error("STAG 2 :PageName :Default.CS// MethodeName :lnkFreshCase_Click  info: RiskView call");
                LoadingDtls_container.Visible = false;
                dvSearch.Visible = true;
            }
        }
        catch (Exception ex)
        {
            Logger.Error("STAG 2 :PageName :Default.CS// MethodeName :lnkFreshCase_Click Error :" + System.Environment.NewLine + ex.ToString());
        }

    }
    //protected void lnkUwrefer_Click(object sender, EventArgs e)
    //{
    //    LoadingDtls_container.Visible = false;
    //    dvSearch.Visible = true;
    //}
    protected void lnkPendingcases_Click(object sender, EventArgs e)
    {

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        lblUploadRiskDetailsErrorMessage.Text = string.Empty;

        try
        {
            Logger.Error("STAG 2 :PageName :Default.CS// MethodeName :btnSearch_Click  info: btnSearch_Click call");
            if (!string.IsNullOrEmpty(txtSearchApplicationNo.Text))
            {
                ds = new DataSet();
                objCommFun = new Commfun();
                objCommFun.FetchBulkRiskApplication(txtSearchApplicationNo.Text, ref ds);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    dgRiskApplication.DataSource = ds;
                }
                else
                {
                    dgRiskApplication.DataSource = null;
                    lblUploadRiskDetailsErrorMessage.Text = "No record found";
                }
                dgRiskApplication.DataBind();
                Logger.Error("STAG 2 :PageName :Default.CS// MethodeName :btnSearch_Click  info: dgRiskApplication bind sucessfully");

            }
            else
            {
                lblUploadRiskDetailsErrorMessage.Text = "Enter application number";
                Logger.Error("STAG 2 :PageName :Default.CS// MethodeName :btnSearch_Click  info: dgRiskApplication bind error");
            }

        }

        catch (Exception ex)
        {

            lblUploadRiskDetailsErrorMessage.Text = "Try again later";
            Logger.Error("STAG 2 :PageName :Default.CS// MethodeName :btnSearch_Click Error :" + System.Environment.NewLine + ex.ToString());
        }
        Logger.Error("STAG 2 :PageName :Default.CS// MethodeName :btnSearch_Click  info: dgRiskApplication Success");
    }

    protected void btnUploadFile_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlRiskType.SelectedValue == "-1")
            {
                lblUploadRiskDetailsErrorMessage.Text = "Please Select Risk Type Before Proceeding";
                lblUploadRiskDetailsErrorMessage.Visible = true;
                lblUploadRiskDetailsErrorMessage.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                if (ddlRiskType.SelectedValue == "1")
                {
                    if (fuBulkRisk.HasFile)
                    {
                        lblScoreUpload.Text = string.Empty;
                        string ExcelPath = Server.MapPath(Path.GetFileName(fuBulkRisk.PostedFile.FileName));
                        fuBulkRisk.SaveAs(ExcelPath);

                        int result = 0; 
                        DataTable dt = new DataTable();
                        dt = ConvertExcelToDataTable_ClosedXML(ExcelPath);
                        DataTable Dt1 = new DataTable();
                        Dt1 = RemoveEmptyRowsFromDataTable(dt);
                        DataTable Dt2 = new DataTable();
                        Dt2 = RemoveDuplicateRows(Dt1, "APPLICATIONNO");

                        if (Dt2.Rows.Count > 0)
                        {
                            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TransactiondbLFRisk"].ConnectionString);
                            SqlCommand cmd = new SqlCommand("USP_RISK_SCORE_CRUD", con);
                            cmd.Parameters.AddWithValue("@dt", Dt2);
                            //cmd.Parameters.AddWithValue("@CREATEDBY", Convert.ToString(Session["UserID"]));
                            cmd.Parameters.AddWithValue("@CREATEDBY", strUserId);
                            cmd.Parameters.AddWithValue("@UPDATEDBY", strUserId);
                            cmd.CommandType = CommandType.StoredProcedure;
                            con.Open();
                            result = cmd.ExecuteNonQuery();
                            con.Close();

                            if (result > 0)
                            {
                                lblScoreUpload.Text = "Uploaded Successfully..";
                                lblScoreUpload.ForeColor = System.Drawing.Color.Green;
                            }
                            else
                            {
                                lblScoreUpload.Text = string.Empty;
                            }
                        }
                        else
                        {
                            lblScoreUpload.Text = "No records found..";
                        }
                    }
                    else
                    {
                        lblScoreUpload.Text = "Please Upload a Excel File Only";
                    }
                }
                if (ddlRiskType.SelectedValue == "2")
                {
                    if (fuBulkRisk.HasFile)
                    {
                        lblScoreUpload.Text = string.Empty;
                        string ExcelPath = Server.MapPath(Path.GetFileName(fuBulkRisk.PostedFile.FileName));
                        fuBulkRisk.SaveAs(ExcelPath);

                        int result = 0;
                        DataTable dt = new DataTable();
                        dt = ConvertExcelToDataTable_ClosedXML(ExcelPath);
                        //DataTable Dt1 = new DataTable();
                        //Dt1 = RemoveEmptyRowsFromDataTable(dt);
                        //DataTable Dt2 = new DataTable();
                        //Dt2 = RemoveDuplicateRows(Dt1, "APPLICATIONNO");

                        if (dt.Rows.Count > 0)
                        {
                            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["transactiondbLF"].ConnectionString);
                            SqlCommand cmd = new SqlCommand("USP_UWSARAL_INSERT_CPV", con);
                            cmd.Parameters.AddWithValue("@dtCPA", dt);
                            //cmd.Parameters.AddWithValue("@CREATEDBY", Convert.ToString(Session["UserID"]));
                            cmd.Parameters.AddWithValue("@CREATEDBY", strUserId);
                            //cmd.Parameters.AddWithValue("@UPDATEDBY", strUserId);
                            cmd.CommandType = CommandType.StoredProcedure;
                            con.Open();
                            result = cmd.ExecuteNonQuery();
                            con.Close();

                            if (result > 0)
                            {
                                lblScoreUpload.Text = "Uploaded Successfully..";
                                lblScoreUpload.ForeColor = System.Drawing.Color.Green;
                            }
                            else
                            {
                                lblScoreUpload.Text = string.Empty;
                            }
                        }
                        else
                        {
                            lblScoreUpload.Text = "No records found..";
                        }
                    }
                    else
                    {
                        lblScoreUpload.Text = "Please Upload a Excel File Only";
                    }
                }
            }
            
        }
        catch (Exception ex)
        {
            //string logFilePath = "C:\\Logs\\";
            //File.AppendAllText(logFilePath + "log.txt",ex.ToString());
            //throw ex;

        }
        Logger.Error("STAG 2 :PageName :Default.CS// MethodeName :btnUploadFile_Click  info:Btnclick sucessfully");
    }
    public static DataTable ConvertExcelToDataTable_ClosedXML(string filePath)
    {
        DataTable dt = new DataTable();
        //Open the Excel file using ClosedXML.
        try
        {
            using (XLWorkbook workBook = new XLWorkbook(filePath))
            {
                //Read the first Sheet from Excel file.
                IXLWorksheet workSheet = workBook.Worksheet(1);

                //Create a new DataTable.


                //Loop through the Worksheet rows.
                bool firstRow = true;
                foreach (IXLRow row in workSheet.Rows())
                {
                    //Use the first row to add columns to DataTable.
                    if (firstRow)
                    {
                        foreach (IXLCell cell in row.Cells())
                        {
                            dt.Columns.Add(cell.Value.ToString());
                        }
                        firstRow = false;
                    }
                    else
                    {
                        //Add rows to DataTable.
                        dt.Rows.Add();
                        int i = 0;
                        foreach (IXLCell cell in row.Cells())
                        {

                            
                            if (i < dt.Columns.Count)
                            {
                                if (cell.DataType == ClosedXML.Excel.XLCellValues.Number && !cell.HasFormula)
                                {
                                    dt.Rows[dt.Rows.Count - 1][i] = cell.Value.ToString();
                                }
                                else if (cell.DataType == ClosedXML.Excel.XLCellValues.Text && !cell.HasFormula)
                                {
                                    dt.Rows[dt.Rows.Count - 1][i] = cell.Value.ToString();
                                }
                                else if (cell.DataType == ClosedXML.Excel.XLCellValues.DateTime && !cell.HasFormula)
                                {
                                    dt.Rows[dt.Rows.Count - 1][i] = cell.Value.ToString();
                                }
                                else if (cell.HasFormula && (cell.DataType == ClosedXML.Excel.XLCellValues.Number
                                    || cell.DataType == ClosedXML.Excel.XLCellValues.Text || cell.DataType == ClosedXML.Excel.XLCellValues.DateTime))
                                {
                                    dt.Rows[dt.Rows.Count - 1][i] = cell.Value.ToString();
                                }
                            }


                            i++;
                        }
                    }
                }
            }
            return dt;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    DataTable RemoveEmptyRowsFromDataTable(DataTable dt)
    {
        for (int i = dt.Rows.Count - 1; i >= 0; i--)
        {
            if (dt.Rows[i][1] == DBNull.Value)
                dt.Rows[i].Delete();
        }
        dt.AcceptChanges();
        return dt;
    }
    public DataTable RemoveDuplicateRows(DataTable dTable, string colName)
    {
        Hashtable hTable = new Hashtable();
        ArrayList duplicateList = new ArrayList();

        //Add list of all the unique item value to hashtable, which stores combination of key, value pair.
        //And add duplicate item value in arraylist.
        foreach (DataRow drow in dTable.Rows)
        {
            if (hTable.Contains(drow[colName]))
                duplicateList.Add(drow);
            else
                hTable.Add(drow[colName], string.Empty);
        }

        //Removing a list of duplicate items from datatable.
        foreach (DataRow dRow in duplicateList)
            dTable.Rows.Remove(dRow);

        //Datatable which contains unique records will be return as output.
        return dTable;
    }
    private static DataTable ConvertExcelToDataTable(string FileName)
    {
        DataTable dtResult = null;
        int totalSheet = 0; //No of sheets on excel file  
        try
        {
            string strpath= Path.GetExtension(FileName);

            if (strpath != ".csv")
            {

                using (OleDbConnection objConn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FileName + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1;';"))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    OleDbDataAdapter oleda = new OleDbDataAdapter();
                    DataSet ds = new DataSet();
                    DataTable dt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    string sheetName = string.Empty;
                    if (dt != null)
                    {
                        var tempDataTable = (from dataRow in dt.AsEnumerable()
                                             where !dataRow["TABLE_NAME"].ToString().Contains("FilterDatabase")
                                             select dataRow).CopyToDataTable();
                        dt = tempDataTable;
                        totalSheet = dt.Rows.Count;
                        sheetName = dt.Rows[0]["TABLE_NAME"].ToString();
                    }
                    cmd.Connection = objConn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM [" + sheetName + "]";
                    oleda = new OleDbDataAdapter(cmd);
                    oleda.Fill(ds, "excelData");
                    dtResult = ds.Tables["excelData"];
                    objConn.Close();
                }
            }
            else
            {                
                string filePath = Path.GetDirectoryName(FileName);
                string fileName = Path.GetFileName(FileName);
                string columnHeadExist = "Yes";                

                string q = @"select * from [" + fileName + "]";

                OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties=\"Text;HDR=" + columnHeadExist + "\"");
                OleDbCommand comd = new OleDbCommand(q, conn);
                OleDbDataAdapter adapter = new OleDbDataAdapter(comd);
                dtResult = new DataTable();
                dtResult.Locale = CultureInfo.CurrentCulture;
                adapter.Fill(dtResult);

                adapter.Dispose();
                comd.Dispose();
                conn.Dispose();
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + ":Page :BulkRiskParameterUpload // MethodeName :ConvertExcelToDataTable");
        }

        return dtResult; //Returning Dattable 
    }

    private void RemoveUnwantedColumns(ref DataTable dt)
    {
        if (ddlRiskType.SelectedValue == "1")
        {
            dt.Columns.Remove("REGISTER");
            dt.Columns.Remove("LA_PCODE");
            dt.Columns.Remove("LA_Occupation");
            dt.Columns.Remove("LA_Education");
            dt.Columns.Remove("Product_Name");
            dt.Columns.Remove("LA_Age_At_Entry");
            dt.Columns.Remove("Age_Proof");
            dt.Columns.Remove("LACode");
            dt.Columns.Remove("LA_Annual_Income");
            dt.Columns.Remove("Premium_Amt");
            dt.Columns.Remove("Branch Name");
            dt.Columns["Channel"].ColumnName = "CHANNEL_CODE";
            dt.Columns["channel1"].ColumnName = "CHANNEL_NAME";
            dt.Columns["Risk_Score _(Acturial Model)"].ColumnName = "Risk_Score";


            ////TEST 
            //dt.Columns.Remove("REMARKS");
            //dt.Columns.Remove("APPNO");
            //dt.Columns.Remove("SUMASSURED");
            dt.Columns.Remove("LANAME");
            //dt.Columns.Remove("AGNTNUM");
            //dt.Columns.Remove("CHANNEL_CODE");
            //dt.Columns.Remove("CHANNEL_NAME");
        }
        else if (ddlRiskType.SelectedValue == "2")
        {
            dt.Columns.Remove("AppNo");
            dt.Columns.Remove("SA");
            dt.Columns.Remove("APE");
            dt.Columns.Remove("Premium_Amt");
            dt.Columns.Remove("BILLFREQ");
            dt.Columns.Remove("LA#Pin#Code");
            dt.Columns.Remove("Payment#Mode");
            dt.Columns.Remove("Branch#Name");
            dt.Columns.Remove("BeneficiaryDOB");
            dt.Columns.Remove("Pan#Provided");
            dt.Columns.Remove("LA#DOB");
            dt.Columns.Remove("Agent#No");
            dt.Columns.Remove("Agent#No__1");
            dt.Columns.Remove("LA#s#education");
            dt.Columns.Remove("LA#s#occupation");
            dt.Columns.Remove("LA#State");
            dt.Columns.Remove("Address#proof");
            dt.Columns["Policy#No"].ColumnName = "Policy_No";
        }
    }

    private DataTable ReplicateDataFromDataTable(DataTable dtOld)
    {
        DataTable dt = new DataTable();
        if (ddlRiskType.SelectedValue == "1")
        {
            //give column structure 
            dt.Columns.Add("POLICYNO", typeof(string));
            dt.Columns.Add("Underwriting  Due Diligence Required", typeof(string));
            dt.Columns.Add("PARAMETERS_COMBINATION", typeof(string));
            dt.Columns.Add("Risk_Score", typeof(string));
            dt.Columns.Add("Suggestive _Requirement", typeof(string));
            dt.Columns.Add("Remarks", typeof(string));
            dt.Columns.Add("APPNO", typeof(string));
            dt.Columns.Add("SumAssured", typeof(string));
            //dt.Columns.Add("LANAME", typeof(string));
            dt.Columns.Add("CHANNEL_CODE", typeof(string));
            dt.Columns.Add("AGNTNUM", typeof(string));
            dt.Columns.Add("CHANNEL_NAME", typeof(string));
        }
        else if (ddlRiskType.SelectedValue == "2")
        {
            dt.Columns.Add("Policy_No",typeof(string));
            dt.Columns.Add("score", typeof(string));
            dt.Columns.Add("Early_claim_risk_level", typeof(string));
        }


        //fill data 
        if (dtOld != null && dtOld.Rows.Count > 0)
        {
            foreach (DataRow row in dtOld.Rows)
            {
                dt.ImportRow(row);
            }
        }
        return dt;
    }

    public void FnDesignChange(string UserId)
    {
        try
        {
            Logger.Error("STAG 2 :PageName :Default.CS// MethodeName :FnDesignChange  info:FnDesignChange start");
            ds = new DataSet();
            objCommFun = new Commfun();
            objCommFun.FetchDesignChange(UserId.Substring(1), ref ds);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                RptDivDynamic.DataSource = ds;


            }
            else
            {
                RptDivDynamic.DataSource = null;
                lblUploadRiskDetailsErrorMessage.Text = "No record found";
                Logger.Error("STAG 2 :PageName :Default.CS// MethodeName :FnDesignChange  info:FnDesignChange ds recrd not found");
            }
            RptDivDynamic.DataBind();
            Logger.Info("STAG 2 :PageName :Default.CS // MethodeName :FnDesignChange info: bind sucessfully");

        }
        catch (Exception Error)
        {
            Logger.Error("STAG 2 :PageName :Default.CS// MethodeName :FnDesignChange Error :" + System.Environment.NewLine + Error.ToString());
            //SaveErrorLogs("", "Failed", "UWAutoIssuence", "BAL.CS", "UpdateAppStatus", "E-Error", "", "", Error.ToString());
        }
    }
    private void MakeGui(DataTable _dt)
    {
        for (int i = 0; i < 10; i++)
        {
            //css

            //link

            //name 
        }
    }
    protected void lnkPendingVerification_Click(object sender, EventArgs e)
    {

    }
    /*ID:1 START*/

    /*ID:1 END*/

}
