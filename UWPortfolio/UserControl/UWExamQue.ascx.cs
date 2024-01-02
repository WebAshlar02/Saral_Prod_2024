using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data;
using ClosedXML.Excel;
using System.Configuration;

public partial class UserControl_UWExamQue : System.Web.UI.UserControl
{
    #region "Common Objects"

    private SqlConnection con;
    DataSet dsQue = new DataSet();
    DataLayer objDAL = new DataLayer();

    #endregion


    #region "Events"
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //protected void btnQueUpload_Click(object sender, EventArgs e)
    //{
    //    string ExcelPath = Server.MapPath(Path.GetFileName(QueFileUploadExcel.PostedFile.FileName));
    //    QueFileUploadExcel.SaveAs(ExcelPath);

    //    dsQue = null;
    //    dsQue = ConvertExcelToDataTable(ExcelPath);
    //    int result = 0;
    //    foreach (DataRow dr in dsQue.Tables[0].Rows)
    //    {
    //        var queDesc = dr["QUEST_DISCP"].ToString();
    //        var CorrectAns = dr["CORRECT_ANS"].ToString();
    //        var ansOpt1 = dr["ANS_OPT_DESC"].ToString();
    //        var ansOpt2 = dr["ANS_OPT_DESC1"].ToString();
    //        var ansOpt3 = dr["ANS_OPT_DESC2"].ToString();
    //        var ansOpt4 = dr["ANS_OPT_DESC3"].ToString();
    //        var grpId = dr["GRP_ID"].ToString();

    //        SqlParameter[] _objSqlParam = new SqlParameter[7];

    //        _objSqlParam[0] = new SqlParameter("@QUEDESC", queDesc);
    //        _objSqlParam[1] = new SqlParameter("@CORRECTANS", CorrectAns);
    //        _objSqlParam[2] = new SqlParameter("@ANSOPT1", ansOpt1);
    //        _objSqlParam[3] = new SqlParameter("@ANSOPT2", ansOpt2);
    //        _objSqlParam[4] = new SqlParameter("@ANSOPT3", ansOpt3);
    //        _objSqlParam[5] = new SqlParameter("@ANSOPT4", ansOpt4);
    //        _objSqlParam[6] = new SqlParameter("@GRPID", grpId);
    //        result = objDAL.Insertrecord("USP_IMPORT_EXAM_EXCEL_DATA", _objSqlParam);
    //    }
    //    if (result > 0)
    //    {
    //        lblMsg.Text = "Uploaded Successfully..";
    //        lblMsg.ForeColor = System.Drawing.Color.Green;
    //    }
    //    else
    //    {
    //        lblMsg.Text = string.Empty;
    //    }

    //}


    //protected void btnWarningUploader_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        string ExcelPath = Server.MapPath(Path.GetFileName(AppWarningFileUpld.PostedFile.FileName));
    //        AppWarningFileUpld.SaveAs(ExcelPath);

    //        dsQue = null;
    //        dsQue = ConvertExcelToDataTable(ExcelPath);
    //        int result = 0;
    //        foreach (DataRow dr in dsQue.Tables[0].Rows)
    //        {
    //            var AppNo = dr["AppNo"].ToString();
    //            var Message = dr["WarningMessage"].ToString();
    //            var userid = Convert.ToString(Session["UserID"]);

    //            SqlParameter[] _objSqlParam = new SqlParameter[3];
    //            _objSqlParam[0] = new SqlParameter("@Appno", AppNo);
    //            _objSqlParam[1] = new SqlParameter("@Message", Message);
    //            _objSqlParam[2] = new SqlParameter("@CreatedBy", userid);
    //            result = objDAL.Insertrecord("USP_UWSARAL_INSERT_APPLICATION_WARNINGMESSAGE", _objSqlParam);
    //        }
    //        if (result > 0)
    //        {
    //            lblappwarn.Text = "Uploaded Successfully..";
    //            lblappwarn.ForeColor = System.Drawing.Color.Green;
    //        }
    //        else
    //        {
    //            lblappwarn.Text = string.Empty;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}




    protected void btnQueUpload_Click(object sender, EventArgs e)
    {
        string strError = string.Empty;
        try
        {
            string ExcelPath = Server.MapPath(Path.GetFileName(QueFileUploadExcel.PostedFile.FileName));
            QueFileUploadExcel.SaveAs(ExcelPath);

            //dsQue = null;
            //dsQue = ConvertExcelToDataTable(ExcelPath);

            int result = 0;
            DataTable dt = new DataTable();
            dt = ConvertExcelToDataTable_ClosedXML(ExcelPath);

            if (dt.Rows.Count > 0)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["transactiondbLF"].ConnectionString);
                SqlCommand cmd = new SqlCommand("USP_IMPORT_EXAM_EXCEL_DATA_New", con);
                cmd.Parameters.AddWithValue("@dt", dt);
                cmd.Parameters.AddWithValue("@UserID", Convert.ToString(Session["UserID"]));
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                result = cmd.ExecuteNonQuery();
                con.Close();

                if (result > 0)
                {
                    lblMsg.Text = "Uploaded Successfully..";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblMsg.Text = string.Empty;
                }
            }
            else
            {
                lblappwarn.Text = "No records found..";
            }



            //int result = 0;
            //foreach (DataRow dr in dsQue.Tables[0].Rows)
            //{
            //    var queDesc = dr["QUEST_DISCP"].ToString();
            //    var CorrectAns = dr["CORRECT_ANS"].ToString();
            //    var ansOpt1 = dr["ANS_OPT_DESC"].ToString();
            //    var ansOpt2 = dr["ANS_OPT_DESC1"].ToString();
            //    var ansOpt3 = dr["ANS_OPT_DESC2"].ToString();
            //    var ansOpt4 = dr["ANS_OPT_DESC3"].ToString();
            //    var grpId = dr["GRP_ID"].ToString();

            //    SqlParameter[] _objSqlParam = new SqlParameter[7];

            //    _objSqlParam[0] = new SqlParameter("@QUEDESC", queDesc);
            //    _objSqlParam[1] = new SqlParameter("@CORRECTANS", CorrectAns);
            //    _objSqlParam[2] = new SqlParameter("@ANSOPT1", ansOpt1);
            //    _objSqlParam[3] = new SqlParameter("@ANSOPT2", ansOpt2);
            //    _objSqlParam[4] = new SqlParameter("@ANSOPT3", ansOpt3);
            //    _objSqlParam[5] = new SqlParameter("@ANSOPT4", ansOpt4);
            //    _objSqlParam[6] = new SqlParameter("@GRPID", grpId);
            //    result = objDAL.Insertrecord("USP_IMPORT_EXAM_EXCEL_DATA", _objSqlParam);
            //}
            //if (result > 0)
            //{
            //    lblMsg.Text = "Uploaded Successfully..";
            //    lblMsg.ForeColor = System.Drawing.Color.Green;
            //}
            //else
            //{
            //    lblMsg.Text = string.Empty;
            //}
        }
        catch (Exception ex)
        {
            strError = ex.Message;
            UWUploadError_Add(strError);
            throw ex;
        }
    }
    protected void btnWarningUploader_Click(object sender, EventArgs e)
    {
        string strError = string.Empty;
        try
        {
            string ExcelPath = Server.MapPath(Path.GetFileName(AppWarningFileUpld.PostedFile.FileName));
            AppWarningFileUpld.SaveAs(ExcelPath);
            int result = 0;
            DataTable dt = new DataTable();
            dt = ConvertExcelToDataTable_ClosedXML(ExcelPath);

            if (dt.Rows.Count > 0)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["transactiondbLF"].ConnectionString);
                SqlCommand cmd = new SqlCommand("USP_UWSARAL_INSERT_APPLICATION_WARNINGMESSAGE_New", con);
                cmd.Parameters.AddWithValue("@dt", dt);
                cmd.Parameters.AddWithValue("@UserID", Convert.ToString(Session["UserID"]));
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                result = cmd.ExecuteNonQuery();
                con.Close();

                if (result > 0)
                {
                    lblappwarn.Text = "Uploaded Successfully..";
                    lblappwarn.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblappwarn.Text = string.Empty;
                }
            }
            else
            {
                lblappwarn.Text = "No records found..";
            }


            //int result = 0;
            //foreach (DataRow dr in dsQue.Tables[0].Rows)
            //{
            //    var AppNo = dr["AppNo"].ToString();
            //    var Message = dr["WarningMessage"].ToString();
            //    var userid = Convert.ToString(Session["UserID"]);

            //    SqlParameter[] _objSqlParam = new SqlParameter[3];
            //    _objSqlParam[0] = new SqlParameter("@Appno", AppNo);
            //    _objSqlParam[1] = new SqlParameter("@Message", Message);
            //    _objSqlParam[2] = new SqlParameter("@CreatedBy", userid);
            //    result = objDAL.Insertrecord("USP_UWSARAL_INSERT_APPLICATION_WARNINGMESSAGE", _objSqlParam);
            //}
            //if (result > 0)
            //{
            //    lblappwarn.Text = "Uploaded Successfully..";
            //    lblappwarn.ForeColor = System.Drawing.Color.Green;
            //}
            //else
            //{
            //    lblappwarn.Text = string.Empty;
            //}



        }
        catch (Exception ex)
        {
            strError = ex.Message;
            UWUploadError_Add(strError);
            throw ex;
        }
       
       

    }

    #endregion

    #region "Function"
    #region "Upload Que file Excel"


    public void UWUploadError_Add(string strerror)
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["transactiondbLF"].ConnectionString);
        SqlCommand cmd = new SqlCommand("UWUploadError_Add", con);
        cmd.Parameters.AddWithValue("@ErrorMesage", strerror);
        cmd.Parameters.AddWithValue("@UserID", Convert.ToString(Session["UserID"]));
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
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
                            //if (cell.DataType != null)
                            //{
                            //    dt.Rows[dt.Rows.Count - 1][i] = cell.DataType != null ? Convert.ToString(cell.Value) : "NA";
                            //}

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

                    //GridView1.DataSource = dt;
                    //GridView1.DataBind();
                }


            }
            return dt;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public static DataSet ConvertExcelToDataTable(string FileName)
    {
        DataSet dtResult = null;
        int totalSheet = 0; //No of sheets on excel file  
        try
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
                oleda.Fill(ds);
                dtResult = ds;
                objConn.Close();
            }

        }
        catch (Exception ex)
        {

        }

        return dtResult; //Returning Dattable 

    }

    #endregion
    #endregion

    //Kavita Start 23/01/2020 CR-27785
    #region  CR-27785 Medical Cost
    /*
protected void btnMedicalCost_Click(object sender, EventArgs e)
{
    string strError = string.Empty;
    try
    {
        string ExcelPath = Server.MapPath(Path.GetFileName(MedCostUploaderFileUploader.PostedFile.FileName));
        MedCostUploaderFileUploader.SaveAs(ExcelPath);


        int result = 0;
        DataTable dt = new DataTable();
        dt = ConvertExcelToDataTable_ClosedXML(ExcelPath);

        if (dt.Rows.Count > 0)
        {
            if (dt.Columns.Contains("TotalCost"))
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["transactiondbLF"].ConnectionString);
                SqlCommand cmd = new SqlCommand("UspviewMedicalCostUpload", con);
                cmd.Parameters.AddWithValue("@dt", dt);
                cmd.Parameters.AddWithValue("@createdDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@UserId", Convert.ToString(Session["UserID"]));
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                result = cmd.ExecuteNonQuery();
                con.Close();

                if (result == -1)
                {
                    lblMedWarn.Text = "Uploaded Successfully..";
                    lblMedWarn.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblMedWarn.Text = string.Empty;
                }
            }
            else
            {
                lblMedWarn.Text = "Wrong Excel,Please Select right Excel..";
                lblMedWarn.ForeColor = System.Drawing.Color.Green;
                MedCostUploaderFileUploader.Focus();
            }
        }
        else
        {
            lblMedWarn.Text = "No records found..";
        }

    }
    catch (Exception ex)
    {
        strError = ex.Message;
        UWUploadError_Add(strError);
        throw ex;
    }

}
*/
    protected void btnMedicalCost_Click(object sender, EventArgs e)
    {
        string strError = string.Empty;
        try
        {
            string ExcelPath = Server.MapPath(Path.GetFileName(MedCostUploaderFileUploader.PostedFile.FileName));
            MedCostUploaderFileUploader.SaveAs(ExcelPath);


            int result = 0;
            DataTable dt1 = new DataTable();
            dt1 = ConvertExcelToDataTable_ClosedXML(ExcelPath);

            if (dt1.Rows.Count > 0)
            {
                if (dt1.Columns.Contains("TotalCost"))
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["transactiondbLF"].ConnectionString);
                    SqlCommand cmd = new SqlCommand("UspviewMedicalCostUpload", con);
                    cmd.Parameters.AddWithValue("@dt", dt1);
                    cmd.Parameters.AddWithValue("@createdDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@UserId", Convert.ToString(Session["UserID"]));
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    // cmd.ExecuteNonQuery();
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    con.Close();

                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[2].Rows.Count > 0)
                        {
                            DataTable dt = new DataTable();
                            dt.Merge(ds.Tables[0]);
                            string date = DateTime.Now.ToShortDateString();
                            date = date.Replace("/", "_");
                            string filepath = "MedicalCost" + date;
                            ExportToExcel(dt, filepath);
                            lblMedWarn.Text = "Uploaded Application count is :-" + ds.Tables[3].Rows[0].ToString() + " " + "Excel With Wrong Application No OR Policy No :-" + " " + ds.Tables[4].Rows[0].ToString();
                        }
                    }

                }
                else
                {
                    lblMedWarn.Text = "Wrong Excel,Please Select right Excel..";
                    lblMedWarn.ForeColor = System.Drawing.Color.Green;
                    MedCostUploaderFileUploader.Focus();
                }
            }
            else
            {
                lblMedWarn.Text = "No records found..";
            }

        }
        catch (Exception ex)
        {
            strError = ex.Message;
            UWUploadError_Add(strError);
            throw ex;
        }

    }
    protected void btnDwnlodExcel_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add("ApplicationNo");
            dt.Columns.Add("policynumber");
            dt.Columns.Add("TPAname");
            dt.Columns.Add("MedicalTestdetails");
            dt.Columns.Add("dateofmedicalexamination");
            dt.Columns.Add("TotalCost");
            dt.Columns.Add("MedicalCost");
            dt.Columns.Add("Homevisitcost");
            dt.Columns.Add("ServiceCharge");
            dt.Columns.Add("GST");
            dt.Columns.Add("Digitalizationcharges");
            dt.Columns.Add("penaltyifany");
            string date = DateTime.Now.ToShortDateString();
            date = date.Replace("/", "_");
            string filepath = "MedicalCost" + date;
            ExportToExcel(dt, filepath);
        }
        catch (Exception ex)
        { throw ex; }
    }

    public void ExportToExcel(DataTable dt, string strFileName)
    {
        try
        {

            using (ClosedXML.Excel.XLWorkbook wbook = new ClosedXML.Excel.XLWorkbook())
            {
                wbook.Worksheets.Add(dt, "tab1");
                // Prepare the responsed
                HttpResponse httpResponse = Response;
                httpResponse.Charset = "";
                httpResponse.Clear();
                httpResponse.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                //Provide you file name here
                httpResponse.AddHeader("content-disposition", "attachment;filename=\"" + strFileName + ".xlsx\"");

                // Flush the workbook to the Response.OutputStream
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    wbook.SaveAs(memoryStream);
                    memoryStream.WriteTo(httpResponse.OutputStream);
                    memoryStream.Close();

                    httpResponse.Flush();
                    httpResponse.SuppressContent = true;
                    //HttpContext.Current.Response.Flush();
                    //HttpContext.Current.Response.SuppressContent = true;
                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    #endregion Medical Cost

    //End



}