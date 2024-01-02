using Platform.Utilities.LoggerFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RiskAllocPendingCases : System.Web.UI.Page
{

    Commfun objComm = new Commfun();
    CommanObj objCommonObj = new CommanObj();
    DataSet _ds = new DataSet();

    string strUserId = string.Empty;
    string strUWmode = string.Empty;
    string strUserGroup = string.Empty;
    string strApplicationno = string.Empty;
    string strOptinselected = string.Empty;
    string strAppstatusKey = string.Empty;
    string strBucketType = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Logger.Error("STAG 2 :PageName :Default.CS// MethodeName :Pageload  info: application start");

            if (!Page.IsPostBack)
            {
                strApplicationno = Request.QueryString["ApplicationNo"];
                strBucketType = Request.QueryString["BucketType"];
                strUserId = Request.QueryString["UserId"];
                SetFieldStatus(strBucketType);
                fillDropdown("Vendor1", "RowNum", ddlvender, "FillVender");
                fillDropdown("Lookup_Description", "Lookup_Name", ddlRCUDecision, "FillRiskDecision");
                fillDropdown("Name", "Value", ddlFollowUpCode, "FollowUpcode");
                
                fillDropdown("Name", "Value", ddlStatus, "FollowUpStatus");
                FillProductNameDDl();
                txtAppno.Text = strApplicationno.ToString();
                fillAllDetails();
            }
        }
        catch (Exception ex)
        { }
    }

    private void SetFieldStatus(string strBucketType1)
    {
        ddlFollowUpCode.Enabled = false;
        txtUWComment.Enabled = false;
        txtTotalPremium.Enabled = false;
        if (strBucketType1 == "PRECases")
        {
            ddlprodName.Enabled = true;
            //txtUWComment.Enabled = true;
            //txtTotalPremium.Enabled = true;
            btnSave.Enabled = true;
            ddlvender.Enabled = true;
        }
        else
        {
            ddlprodName.Enabled = false;
            //txtUWComment.Enabled = false;
            //txtTotalPremium.Enabled = false;
            btnSave.Enabled = false;
            ddlvender.Enabled = false;
        }

    }

    private void fillDropdown(string Text, string value, DropDownList ddl, string Mode)
    {
        DataSet dsCnt = new DataSet();
        objComm.FetchRiskAllocationCount(ref dsCnt, Mode, strApplicationno);
        ddl.DataSource = dsCnt.Tables[0];
        ddl.DataTextField = Text;
        ddl.DataValueField = value;
        ddl.AppendDataBoundItems = true;
        ddl.Items.Insert(0, new ListItem("--Select--"));
        ddl.DataBind();

    }


    public void FillProductNameDDl()
    {
        try
        {
            DataSet ds1 = new DataSet();
            objComm.FetchProductDetails(ref ds1, "ProdName");
            ddlprodName.DataSource = ds1.Tables[0];

            ddlprodName.DataTextField = "LONGDESC";
            ddlprodName.DataValueField = "SHORTDESC";
            ddlprodName.AppendDataBoundItems = true;
            ddlprodName.Items.Insert(0, new ListItem("--Select--"));
            ddlprodName.DataBind();
            //return ds;
        }
        catch (Exception ex)
        {
            throw new Exception("retrieveDropDownListDataSource(): " + ex.Message);
        }

    }




    private void fillAllDetails()
    {
        try
        {
            DataSet dsCnt = new DataSet();
            objComm.FetchRiskAllocationCount(ref dsCnt, "FillDetails", strApplicationno);
            if (dsCnt.Tables.Count > 0 && dsCnt.Tables[0].Rows.Count > 0)
            {
                txtProductCode.Text = dsCnt.Tables[0].Rows[0]["PROD_productCode_CHDRTYPE"].ToString();
                ddlprodName.SelectedItem.Text = dsCnt.Tables[0].Rows[0]["PROD_productName"].ToString();
                txtTotalPremium.Text = dsCnt.Tables[0].Rows[0]["PREM_totalPremium"].ToString();
                txtUWComment.Text = dsCnt.Tables[0].Rows[0]["COMM_remarks"].ToString();
                ddlvender.SelectedItem.Text = dsCnt.Tables[0].Rows[0]["AssignToVender"].ToString();
                ddlFollowUpCode.SelectedItem.Text=dsCnt.Tables[0].Rows[0]["REQ_followUpCode"].ToString();
                ddlStatus.SelectedValue=dsCnt.Tables[0].Rows[0]["REQ_status"].ToString();
                ddlRCUDecision.SelectedValue = dsCnt.Tables[0].Rows[0]["RCU_ReportDecision"].ToString();
                string email = dsCnt.Tables[0].Rows[0]["email"].ToString();
                if (email.ToString() == "True")
                {
                    chkIsMailsend.Checked = true;
                }
                else
                    chkIsMailsend.Checked = false;
            }
        }
        catch (Exception ex)
        { }
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string APPNO = txtAppno.Text;
            string prodcode = txtProductCode.Text;
            string prodName = ddlprodName.SelectedItem.Text.ToString();
            string TotalPre = txtTotalPremium.Text.ToString();
            string comment = txtComment.Text.ToString();
            string RcuDecision = ddlRCUDecision.SelectedValue.ToString();
            string VenderName = ddlvender.SelectedItem.Text.ToString();
            string userid = Request.QueryString["UserId"].ToString();
            string status = ddlStatus.SelectedValue.ToString();

            int i = 0;
            objComm.Save_RiskDecision(APPNO, prodcode, prodName, TotalPre, comment, RcuDecision, VenderName, userid, status, ref i);
            if (i == 3)
            {
                ScriptManager.RegisterStartupScript(base.Page, this.GetType(), ("dialogJavascript" + this.ID), "alert('Record Updated Successfully');", true);
                Page.ClientScript.RegisterOnSubmitStatement(typeof(Page), "closePage", "window.onunload = CloseWindow();");
                return;
            }

        }

        catch (Exception ex)
        { }
    }
    protected void ddlprodName_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            txtProductCode.Text = ddlprodName.SelectedValue.ToString();
        }
        catch (Exception ex) { }

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        //Server.Transfer("Default.aspx");
       // Page.ClientScript.RegisterOnSubmitStatement(typeof(Page), "closePage", "window.onunload = CloseWindow();");
        Page.ClientScript.RegisterOnSubmitStatement(typeof(Page), "closePage", "window.onunload = CloseWindow();");

    }
}