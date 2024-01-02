using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MedicalUploadUtility
{
    public partial class MedicalUpUtilityReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }
        }

        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["transactiondbLF"].ConnectionString);
                    SqlCommand objCmd = new SqlCommand("UspMedicalUploadUtility_Report", con);
                    objCmd.CommandType = CommandType.StoredProcedure;
                    DataSet ds = new DataSet();
                    da = new SqlDataAdapter(objCmd);

                    DateTime res1 = DateTime.Parse(txtFromDate.Text.ToString(), CultureInfo.GetCultureInfo("en-gb"));
                    string fd = res1.ToString("MM/dd/yyyy");
                    DateTime res2 = DateTime.Parse(txtToDate.Text.ToString(), CultureInfo.GetCultureInfo("en-gb"));
                    string td = res2.ToString("MM/dd/yyyy");

                    da.SelectCommand.Parameters.AddWithValue("@FromDate", fd);
                    da.SelectCommand.Parameters.AddWithValue("@ToDate", td);

                    da.Fill(ds);
                    
                    string FileName = "MedicalCheckUtility" + txtFromDate.Text.ToString() +" TO "+ txtToDate.Text.ToString();

                    ExportToExcel(ds.Tables[0], FileName);
                    objCmd.CommandTimeout = 0;
                    con.Open();
                    objCmd.ExecuteNonQuery();
                    con.Close();
                }

            }
            catch
            {

            }
        }

        public void ExportToExcel(DataTable dt, string strFileName)
        {
            try
            {

                using (ClosedXML.Excel.XLWorkbook wbook = new ClosedXML.Excel.XLWorkbook())
                {
                    wbook.Worksheets.Add(dt, "tab1");
                    // Prepare the response
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
                //Response.Flush();
                //Response.SuppressContent = true;
                //HttpContext.Current.Response.Flush();
                //HttpContext.Current.Response.SuppressContent = true;
                //HttpContext.Current.ApplicationInstance.CompleteRequest();
                //httpResponse.End();
            }
            //catch (System.Threading.ThreadAbortException lException)
            //{

            //    // do nothing

            //}
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}