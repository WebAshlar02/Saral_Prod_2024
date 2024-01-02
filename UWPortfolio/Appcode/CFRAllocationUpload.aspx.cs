using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Appcode_CFRAllocationUpload : System.Web.UI.Page
{
    Commfun objcomm = new Commfun();
    BussLayer objBuss = new BussLayer();
    string strUserId = string.Empty;
    CommonObject objCommonObj = new CommonObject();

    protected void Page_Load(object sender, EventArgs e)
    {
        objCommonObj = (CommonObject)Session["objCommonObj"];
        strUserId = objCommonObj._Bpmuserdetails._UserID;

        if (!Page.IsPostBack)
        {
        }
    }
    

    protected void btnSavetoDB0_Click(object sender, EventArgs e)
    {
        string excelPath = string.Empty;
        string drpdwnText = string.Empty;

        try
        {
            if (FileUp1.HasFile)
            {
                if (FileUp1.PostedFile != null)
                {
                    excelPath = Server.MapPath("~/ExcelFile/" + FileUp1.FileName);
                    FileUp1.SaveAs(excelPath);
                    string extension = Path.GetExtension(excelPath);
                    // drpdwnText = ddlValue.SelectedItem.Text.ToString();
                    LogsDetails(ExcelToDataTable(excelPath));
                }
            }
            else
            {
                lblMsg.Text = "Please Upload File First";
            }
        }
        catch (Exception ex)
        {
            SaveErrorLogs(ex.Message, excelPath);
        }
    }
    public void LogsDetails(DataTable dt)
    {
        string rowcount = dt.Rows.Count.ToString();
        try
        {
            if (dt.Rows.Count > 0)
            {
                objcomm = new Commfun();
                objcomm.InsertCFRAllocationUpload(dt, "2", "0", "SYSTEM", DateTime.Now);
                lblMsg.Text = "Your file uploaded successfully";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
        }
        catch (Exception ex)
        {
            SaveErrorLogs(ex.Message, rowcount);
        }
    }


    public void SaveErrorLogs(string strerror, string excelPath)
    {
        try
        {
            objcomm = new Commfun();
           
            objcomm.InsertCFRAllocationUpload_ErrorLog(excelPath, strUserId, strerror);

        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }

    public DataTable ExcelToDataTable(string filePath)
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

        }
        catch (Exception ex)
        {
            SaveErrorLogs(ex.Message, filePath);
        }
        return dt;

    }
}