using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MedicalUploadUtility
{
    public partial class MedicalUploadUtilityPage : System.Web.UI.Page
    {
        string dtsheetRowCount = string.Empty;
        string strUserId = string.Empty;
        CommonObject objCommonObj = new CommonObject();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Session.Add("USERID", "mfl00255");

            if (!Page.IsPostBack)
            {
                FillDDL("FillDDL");
                //strUserId = Session["USERID"].ToString();
            }
        }

        public void FillDDL(string Option)
        {
            SqlDataAdapter da = null;
            SqlConnection sqlCon;
            try
            {
                objCommonObj = (CommonObject)Session["objCommonObj"];
                strUserId = objCommonObj._Bpmuserdetails._UserID;
                sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["transactiondbLF"].ConnectionString);
                sqlCon.Open();
                DataSet ds = new DataSet();
                SqlCommand comm = new SqlCommand("Usp_MedicalUploadFollowUp", sqlCon);
                comm.CommandType = CommandType.StoredProcedure;
                da = new SqlDataAdapter(comm);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Option", Option);
                da.Fill(ds);

                ddlValue.AppendDataBoundItems = true;
                ddlValue.Items.Insert(0, new ListItem("--Select--"));
                ddlValue.DataSource = ds.Tables[0];
                ddlValue.DataTextField = ds.Tables[0].Columns["FollowUpCode"].ToString();
                ddlValue.DataValueField = ds.Tables[0].Columns["Value"].ToString();
                ddlValue.DataBind();
                sqlCon.Close();
                //return ds;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (da != null)
                {
                    da.Dispose();

                }
            }
        }


        protected void btnSavetoDB_Click(object sender, EventArgs e)
        {
            string excelPath = string.Empty;
            string drpdwnText = string.Empty;

            try
            {
                if (FileUp1.PostedFile != null)
                {
                    //  string filePath = Server.MapPath("~/Files/") + Path.GetFileName(FileUpload1.PostedFile.FileName);
                    strUserId = Convert.ToString(Session["USERID"]);
                    excelPath = Server.MapPath("~/ExcelFile/" + FileUp1.FileName);
                    FileUp1.SaveAs(excelPath);
                    string extension = Path.GetExtension(excelPath);
                    drpdwnText = ddlValue.SelectedItem.Text.ToString();
                    LogsDetails(ExcelToDataTable(excelPath), drpdwnText);


                }
            }
            catch (Exception ex)
            {
                SaveErrorLogs(ex.Message, excelPath, drpdwnText);
            }
        }

        public void SaveErrorLogs(string strerror, string excelPath, string drpdwnText)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["transactiondbLF"].ConnectionString);
            SqlCommand objCmd = new SqlCommand("UspMedicalUploadUtility_ErrorLogs", con);
            objCmd.Parameters.AddWithValue("@ApplicationNo", excelPath);
            objCmd.Parameters.AddWithValue("@FollowUpCode", drpdwnText);
            objCmd.Parameters.AddWithValue("@UserID", strUserId);
            objCmd.Parameters.AddWithValue("@SystemDate", DateTime.Now);
            objCmd.Parameters.AddWithValue("@ErrorMsg", strerror);

            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandTimeout = 0;
            con.Open();
            objCmd.ExecuteNonQuery();
            con.Close();
        }


        public void LogsDetails(DataTable dt, string drpdwnText)
        {
            string rowcount = dt.Rows.Count.ToString();
            try
            {
                if (dt.Rows.Count > 0)
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["transactiondbLF"].ConnectionString);
                    //SqlCommand objCmd = new SqlCommand("UspMedicalUploadUtility_Add", con);
                    SqlCommand objCmd = new SqlCommand("UspMedicalUploadUtility_Add_Test", con);
                    objCmd.Parameters.AddWithValue("@dt", dt);
                    objCmd.Parameters.AddWithValue("@FollowUpCode", drpdwnText);
                    objCmd.Parameters.AddWithValue("@UserID", strUserId);
                    objCmd.Parameters.AddWithValue("@SystemDate", DateTime.Now);
                    objCmd.Parameters.AddWithValue("@Option", "Insert");
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.CommandTimeout = 0;
                    con.Open();
                    objCmd.ExecuteNonQuery();
                    con.Close();
                    lblMsg.Text = "Your file uploaded successfully";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                }
            }
            catch (Exception ex)
            {
                SaveErrorLogs(ex.Message, rowcount, drpdwnText);
            }
        }


        public DataTable ExcelToDataTable(string filePath)
        {
            string drpdwnText1 = ddlValue.SelectedItem.Text.ToString();
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

            }
            catch (Exception ex)
            {
                SaveErrorLogs(ex.Message, filePath, drpdwnText1);
            }
            return dt;

        }



    }
}