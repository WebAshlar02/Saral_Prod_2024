using Platform.Utilities.LoggerFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
#region Cr-26885 start Kavita

public partial class UserControl_InvestigationReport : System.Web.UI.UserControl
{
    string strApplicationno = string.Empty;
    Commfun objComm = new Commfun();
    BussLayer objBuss = new BussLayer();
    DataSet _ds = new DataSet();
    string policyNo = string.Empty;
    string AppNo = string.Empty;
    string ProposalLoginDate = string.Empty;
    string CustORSubName = string.Empty;
    string PreAmnt = string.Empty;
    string BranchName = string.Empty;
    string ChannelName = string.Empty;
    string PolicyStatus = string.Empty;
    string PIVCRemarks = string.Empty;
    string AdvisorCode = string.Empty;
    string AdvisorName = string.Empty;
    string ReportingManagerECode = string.Empty;
    string ReportingManagerName = string.Empty;
    string Product = string.Empty;
    string AgentStatus = string.Empty;
    string PolicyIssueDate = string.Empty;
    string ReferredDate = string.Empty;
    string CategoryofMisconduct = string.Empty;
    string Casereferredby = string.Empty;
    string PrimaryAllegations = string.Empty;
    string ACRSignedby = string.Empty;
    string MHRSigned = string.Empty;
    string F2FSigned = string.Empty;
    string CLSSRNNo = string.Empty;
    string EnquiryCmnt = string.Empty;
    string TypeOfDisposal = string.Empty;
    string SystemDate = string.Empty;
    string UserID = string.Empty;
    CommonObject objCommonObj = new CommonObject();

    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (!Page.IsPostBack)
            {
                // Logger.Info(strApplicationno + " STAG2:-page load start" + System.Environment.NewLine);
                // Logger.Info(strApplicationno + " STAG2:-A" + System.Environment.NewLine);
                BindCatOfMisconduct(FetchCategory(361), ddlCatOFMis);
                BindCatOfMisconduct(FetchCategory(379), ddlCaseRef);
                if (Request.QueryString["qsAppNo"] != null)
                {
                    strApplicationno = Request.QueryString["qsAppNo"].ToString();
                }
                objCommonObj = (CommonObject)Session["objCommonObj"];
                UserID = objCommonObj._Bpmuserdetails._UserID;
                FetchAgentDetails();
                FetchApplicationDetails();
                FetchExistingDetails();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    private DataSet FetchCategory(int i)
    {
        _ds = new DataSet();
        objBuss = new BussLayer();
        objBuss.GetLookupData(i, ref _ds);
        return _ds;
    }


    private void BindCatOfMisconduct(DataSet _ds, DropDownList ddl)
    {
        if (_ds != null && _ds.Tables.Count > 0 && _ds.Tables[0].Rows.Count > 0)
        {
            ddl.DataSource = _ds;
            ddl.DataTextField = "LOOKUP_DESCRIPTION";
            ddl.DataValueField = "LOOKUP_NAME";
        }
        else
        {
            ddlCatOFMis.DataSource = null;
        }
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("--Select--", "0"));
    }


#endregion Cr-26885 End Kavita
    protected void btnsave_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            policyNo = Convert.ToString(txtPolicyNo.Text);
            AppNo = Convert.ToString(txtAppNo.Text);
            ProposalLoginDate = txtLoginDate.Text;
            DateTime dtProLoginDate = Convert.ToDateTime(ProposalLoginDate.ToString());
            CustORSubName = Convert.ToString(txtCustSubName.Text);
            PreAmnt = Convert.ToString(txtPremiumAmt.Text);
            BranchName = Convert.ToString(txtBranchName.Text);
            ChannelName = Convert.ToString(txtChannelName.Text);
            PolicyStatus = Convert.ToString(txtPolicyStatus.Text);
            PIVCRemarks = Convert.ToString(txtPIVCRemark.Text);
            AdvisorCode = Convert.ToString(txtAgencyPartnerCode.Text);
            AdvisorName = Convert.ToString(txtAgencyPartnerName.Text);
            ReportingManagerECode = Convert.ToString(txtRepMangerCode.Text);
            ReportingManagerName = Convert.ToString(txtRepManName.Text);
            Product = Convert.ToString(txtProd.Text);
            AgentStatus = Convert.ToString(txtAgentStatus.Text);
            DateTime PolicyIssueDate = Convert.ToDateTime("");
            DateTime ReferredDate = Convert.ToDateTime(txtReferredDate.Text);
            CategoryofMisconduct = ddlCatOFMis.SelectedValue.ToString();
            Casereferredby = ddlCaseRef.SelectedValue.ToString();
            PrimaryAllegations = Convert.ToString(txtPreAlle.Text);
            ACRSignedby = Convert.ToString(txtACRSign.Text);
            MHRSigned = Convert.ToString(txtMHRSign.Text);
            F2FSigned = Convert.ToString(txtF2fSign.Text);
            CLSSRNNo = Convert.ToString(txtCLSSRNNo.Text);
            EnquiryCmnt = Convert.ToString(txtEnqCmnt.Text);
            TypeOfDisposal = Convert.ToString(txtTypeOfDisp.Text);
            // DateTime SystemDate = DateTime.Now;
            //UserID = 
            string ddlPIInvestigationStatus = Session["CheckddlInvestRepStatus"].ToString();
            objCommonObj = (CommonObject)Session["objCommonObj"];
            UserID = objCommonObj._Bpmuserdetails._UserID;

            bool flag = objComm.InsertInvestigationReport(policyNo, AppNo, dtProLoginDate, CustORSubName, PreAmnt, BranchName, ChannelName, PolicyStatus, PIVCRemarks, AdvisorCode, AdvisorName, ReportingManagerECode,
                ReportingManagerName, Product, AgentStatus, PolicyIssueDate, ReferredDate, CategoryofMisconduct, Casereferredby, PrimaryAllegations, ACRSignedby, MHRSigned, F2FSigned, CLSSRNNo, EnquiryCmnt, TypeOfDisposal, UserID, ddlPIInvestigationStatus);

            if (flag == true)
            {
                lblManualAllocationMsg.Text = "Record Updated Successfully.........";
                lblManualAllocationMsg.ForeColor = System.Drawing.Color.Green;
                
            }
            else
            { }
        }
        catch (Exception ex)
        { }
    }


    public void FetchAgentDetails()
    {
        try
        {
            string AgentChannel = Context.Items["AgentChannel"].ToString();
            txtChannelName.Text = AgentChannel.ToString();
            string AgentCode = Context.Items["AgentCode"].ToString();
            txtReferredDate.Text = Convert.ToString(System.DateTime.Now.ToShortDateString());
            DataSet ds = new DataSet();
            objComm.GetAgentDetails(ref ds, AgentCode);

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtAgencyPartnerCode.Text = ds.Tables[0].Rows[0]["AGENCYCODE"].ToString();
                    txtAgencyPartnerName.Text = ds.Tables[0].Rows[0]["AGENCYPARTNERNAME"].ToString();
                    txtRepMangerCode.Text = ds.Tables[0].Rows[0]["IMMEDIATE REPORTING PERSON"].ToString();
                    txtRepManName.Text = ds.Tables[0].Rows[0]["IMMEDIATE REPORTING PERSON NAME"].ToString();
                    txtAgentStatus.Text = ds.Tables[0].Rows[0]["AGENTSTATUS"].ToString();
                }
            }
        }
        catch (Exception ex)
        { }
        //[Usp_UWSaralFetchAgentDetails] CMS_UAT
    }



    public void FetchApplicationDetails()
    {
        string appno = strApplicationno.ToString();
        DataSet ds1 = new DataSet();
        objComm.GetApplicationDetailsForInvestigationRpt(ref ds1, appno);
        if (ds1.Tables.Count > 0)
        {
            if (ds1.Tables[0].Rows.Count > 0)
            {
                txtPolicyNo.Text = ds1.Tables[0].Rows[0]["POL_policyNumber"].ToString();
                txtAppNo.Text = ds1.Tables[0].Rows[0]["POL_applicationNoStr"].ToString();
                txtPremiumAmt.Text = ds1.Tables[0].Rows[0]["PREM_totalPremium"].ToString();
                txtBranchName.Text = ds1.Tables[0].Rows[0]["bpm_userBranch"].ToString();
                txtPolicyStatus.Text = ds1.Tables[0].Rows[0]["POL_PolicyStatus"].ToString();
                txtProd.Text = ds1.Tables[0].Rows[0]["PRODName"].ToString();
                //txtPolicyIssueDate.Text = ds1.Tables[0].Rows[0]["POL_IssueDate"].ToString();
            }

            if (ds1.Tables[1].Rows.Count > 0)
            {
                txtLoginDate.Text = ds1.Tables[1].Rows[0]["INWD_inwardingDate"].ToString();
            }
            if (ds1.Tables[2].Rows.Count > 0)
            {
                txtCustSubName.Text = ds1.Tables[2].Rows[0]["CustomerName"].ToString();
            }
            if (ds1.Tables[3].Rows.Count > 0)
            {
                txtPIVCRemark.Text = ds1.Tables[3].Rows[0]["PIVCRemark"].ToString();
            }

        }

        //[Usp_UWSaralFetchDetailsForInvestigationRep] trans
    }

    public void FetchExistingDetails()
    {
        try
        {

            if (Request.QueryString["qsAppNo"] != null)
            {
                strApplicationno = Request.QueryString["qsAppNo"].ToString();
            }
            DataSet ds = new DataSet();

            objComm.GetExistingInvestDetails(ref ds, strApplicationno);

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string PA = ds.Tables[0].Rows[0]["PremiumAmount"].ToString();
                    if (ds.Tables[0].Rows[0]["PremiumAmount"].ToString() != "")
                    {
                        txtPolicyNo.Text = ds.Tables[0].Rows[0]["PolicyNo"].ToString();
                        txtAppNo.Text = ds.Tables[0].Rows[0]["ApplicationNumber"].ToString();
                        txtLoginDate.Text = ds.Tables[0].Rows[0]["ProposalLoginDate"].ToString();
                        txtCustSubName.Text = ds.Tables[0].Rows[0]["CustomerORSubjectName"].ToString();
                        txtPremiumAmt.Text = ds.Tables[0].Rows[0]["PremiumAmount"].ToString();
                        txtBranchName.Text = ds.Tables[0].Rows[0]["BranchName"].ToString();
                        txtChannelName.Text = ds.Tables[0].Rows[0]["ChannelName"].ToString();
                        txtPolicyStatus.Text = ds.Tables[0].Rows[0]["PolicyStatus"].ToString();
                        txtPIVCRemark.Text = ds.Tables[0].Rows[0]["PIVCRemarks"].ToString();
                        txtAgencyPartnerCode.Text = ds.Tables[0].Rows[0]["AdvisorCode"].ToString();
                        txtAgencyPartnerName.Text = ds.Tables[0].Rows[0]["AdvisorName"].ToString();
                        txtRepMangerCode.Text = ds.Tables[0].Rows[0]["ReportingManagerECode"].ToString();
                        txtRepManName.Text = ds.Tables[0].Rows[0]["ReportingManagerName"].ToString();
                        txtProd.Text = ds.Tables[0].Rows[0]["Product"].ToString();
                        txtAgentStatus.Text = ds.Tables[0].Rows[0]["AgentStatus"].ToString();
                        //txtPolicyIssueDate.Text = ds.Tables[0].Rows[0]["PolicyIssueDate"].ToString();
                        txtReferredDate.Text = ds.Tables[0].Rows[0]["ReferredDate"].ToString();
                        ddlCatOFMis.SelectedValue = ds.Tables[0].Rows[0]["CategoryofMisconduct"].ToString();
                        ddlCaseRef.SelectedValue = ds.Tables[0].Rows[0]["Casereferredby"].ToString();

                        txtPreAlle.Text = ds.Tables[0].Rows[0]["PrimaryAllegations"].ToString();
                        txtACRSign.Text = ds.Tables[0].Rows[0]["ACRSignedby"].ToString();
                        txtMHRSign.Text = ds.Tables[0].Rows[0]["MHRSigned"].ToString();
                        txtF2fSign.Text = ds.Tables[0].Rows[0]["F2FSigned"].ToString();
                        txtCLSSRNNo.Text = ds.Tables[0].Rows[0]["CLSSRNNo"].ToString();
                        txtEnqCmnt.Text = ds.Tables[0].Rows[0]["EnquiryCmnt"].ToString();
                        txtTypeOfDisp.Text = ds.Tables[0].Rows[0]["TypeOfDisposal"].ToString();
                    }

                }
            }
        }
        catch (Exception ex)
        { }
        //[Usp_UWSaralFetchAgentDetails] CMS_UAT
    }
}




