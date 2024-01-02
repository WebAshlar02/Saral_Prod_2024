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

public partial class Appcode_CFRData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtFromDate.Text = null;
            txtToDate.Text = null;
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            dgvCFRData.DataSource = null;
            dgvCFRData.DataBind();

            SqlDataAdapter da = new SqlDataAdapter();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["transactiondbLF"].ConnectionString);
            SqlCommand objCmd = new SqlCommand("UspCFRDataReport", con);
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
            dgvCFRData.DataSource = ds.Tables[0];
            dgvCFRData.DataBind();
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message.ToString();
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
                SqlCommand objCmd = new SqlCommand("UspCFRDataReport", con);
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

                string FileName = "CFRDataReport" + txtFromDate.Text.ToString() + " TO " + txtToDate.Text.ToString();

                ExportToExcel(ds.Tables[0], FileName);
                objCmd.CommandTimeout = 0;
                con.Open();
                objCmd.ExecuteNonQuery();
                con.Close();
            }

        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message.ToString();
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