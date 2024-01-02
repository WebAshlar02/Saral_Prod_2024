using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class Appcode_UWFinancialCalculator : System.Web.UI.Page
{
    BussLayer objBussLayer;
    DataSet _ds;
    DataTable _dt;
    string strUserId = "1129151";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {            
            //CHECK QUERY STRING
            //if (string.IsNullOrEmpty(Request.QueryString["qsUserId"]))
            //{
            //    ClientScript.RegisterStartupScript(Page.GetType(), "Close Page", "alert('Invalid User');window.close();",true);
            //}
            if (!Page.IsPostBack)
            {
                txtApplicationNo.Text = "TEST1";
                txtDateOfBirth.Text = System.DateTime.Now.AddYears(-40).ToShortDateString();
                _ds = new DataSet();
                //fetch INCOME DATAdata
                FetchFinancialCalculatorApplicationDetails(txtApplicationNo.Text, ref _ds);
                //bind INCOME data
                BindApplicationDetails(_ds);
                //FETCH LIQUID DATA
                FetchFinancialCalculatorLiquid(txtApplicationNo.Text, ref _ds);
                //bind liquid data
                BindLiquidDetails(_ds);
                //fill Calculated data & bind calculated data 
                BindComputedData(FetchSaralFinancialCalculatorComputedData(txtApplicationNo.Text, strUserId));
            }

        }
        catch (Exception ex)
        {
        }
    }

    private void FetchFinancialCalculatorApplicationDetails(string strApplicationNo, ref DataSet _ds)
    {
        _ds = new DataSet();
        objBussLayer = new BussLayer();
        objBussLayer.FetchFetchSaralFinancialCalculatorApplication(strApplicationNo, ref _ds);
    }

    private void BindApplicationDetails(DataSet _ds)
    {
        if (_ds != null && _ds.Tables.Count > 0 && _ds.Tables[0].Rows.Count > 0)
        {
            gvITR.DataSource = _ds.Tables[0];
            gvITR.DataBind();
            if (_ds.Tables.Count > 1)
            {
                txtExistingInsuranceCover.Text = Convert.ToString(_ds.Tables[1].Rows[0]["ExistingInsuranceCover"]);
            }
        }
    }


    protected void gvITR_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        TextBox objText;
        Label objLabel;
        if (e.Row.RowType == DataControlRowType.Header)
        {
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                objLabel = new Label();
                objLabel.Text = e.Row.Cells[i].Text;
                e.Row.Cells[i].Controls.Add(objLabel);
            }
        }
        else
        {
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                objText = new TextBox();
                objText.Text = e.Row.Cells[i].Text;
                objText.CssClass = "form-control Numeric";
                objText.ID = "textbox" + Convert.ToString(e.Row.RowIndex) + Convert.ToString(i);
                objText.Attributes.Add("runat", "server");
                if (i == 0)
                {
                    objText.ReadOnly = true;
                    objText.Enabled = false;
                }
                e.Row.Cells[i].Controls.Add(objText);
            }
        }
        e.Row.Cells[1].Visible = false;
    }

    protected void btnSaveITRValues_Click(object sender, EventArgs e)
    {
        try
        {
            //VALIDATION
            if (ValidateControls())
            {
                //fill data table 
                _dt = FillITRValuesTable();
                //save financial income to data base 
                SaveFinancialIncomeToDatabase(_dt);
                //save liquid investment to DataBase
                SaveLiquidInvestment();
                //fill Calculated data & bind calculated data 
                BindComputedData(FetchSaralFinancialCalculatorComputedData(txtApplicationNo.Text, strUserId)); 
            }

        }
        catch (Exception ex)
        {

        }
    }

    private DataTable FillITRValuesTable()
    {
        DataTable dt = new DataTable();
        DataRow dr;
        Label lblHeader;
        TextBox txtItems;
        Repeater objRepeater = new Repeater();
        if (gvITR != null && gvITR.Items.Count > 0)
        {
            //make header of data table                        
            for (int i = 0; i < gvITR.Items.Count; i++)
            {
                if (i == 0)
                {
                    objRepeater = (Repeater)gvITR.Controls[0].FindControl("gvITRHeader");
                }
                dr = dt.NewRow();
                for (int k = 0; k < gvITR.Items[0].Controls[1].Controls.Count; k++)
                {
                    //fill columns
                    if (i == 0)
                    {
                        lblHeader = (Label)objRepeater.Items[k].Controls[1];
                        if (lblHeader != null)
                        {
                            dt.Columns.Add(lblHeader.Text, typeof(string));
                        }
                    }
                    //fill rows
                    txtItems = (TextBox)gvITR.Items[i].Controls[1].Controls[k].Controls[1];
                    if (txtItems != null)
                    {
                        dr[k] = txtItems.Text;
                    }

                }
                dt.Rows.Add(dr);
            }
        }


        return dt;
    }

    private void SaveFinancialIncomeToDatabase(DataTable dt)
    {
        string strITR = string.Empty, strFinancialyear = string.Empty, strUserId = Convert.ToString(Request.QueryString["qsUserId"]);
        strUserId = (string.IsNullOrWhiteSpace(strUserId)) ? "1129151" : strUserId;
        decimal dcIncome = -1;
        if (dt != null && dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (dt.Columns[j].ColumnName.Contains("/"))
                    {
                        strITR = Convert.ToString(dt.Rows[i]["ITR"]);
                        strFinancialyear = dt.Columns[j].ColumnName;
                        dcIncome = Convert.ToDecimal(dt.Rows[i][j]);
                        ManageFetchSaralFinancialCalculator(txtApplicationNo.Text, strITR, strFinancialyear, dcIncome, Convert.ToDateTime(txtDateOfBirth.Text), string.IsNullOrWhiteSpace(txtExistingInsuranceCover.Text) ? "0" : txtExistingInsuranceCover.Text, strUserId);
                    }
                }
            }
        }
    }

    private int ManageFetchSaralFinancialCalculator(string strApplicationNo, string strITR, string strFinancailYear, decimal dcIncome, DateTime dtDateOfBirth, string strExistingInsuranceCover, string strUserId)
    {
        objBussLayer = new BussLayer();
        return objBussLayer.ManageFetchSaralFinancialCalculator(strApplicationNo, strITR, strFinancailYear, dcIncome, dtDateOfBirth, strExistingInsuranceCover, strUserId);
    }


    protected void gvITR_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            HtmlTableCell objHtmlTableCell;
            if (e.Item.ItemType == ListItemType.Header)
            {
                Label objLabel;                
                Repeater headerRepeater = e.Item.FindControl("gvITRHeader") as Repeater;
                headerRepeater.DataSource = _ds.Tables[0].Columns;
                headerRepeater.DataBind();
                //get second column and make its visible false
                objLabel = (Label)headerRepeater.Items[1].Controls[1];
                if (objLabel != null)
                {
                    objLabel.CssClass = "form-control";
                    objLabel.Style.Add("display", "none;");
                }
            }

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                TextBox objTextbox;
                Repeater columnRepeater = e.Item.FindControl("gvITItem") as Repeater;
                var row = e.Item.DataItem as System.Data.DataRowView;
                columnRepeater.DataSource = row.Row.ItemArray;
                columnRepeater.DataBind();
                //get second column and make its visible false
                objTextbox = (TextBox)columnRepeater.Items[1].Controls[1];
                //objTextbox.CssClass = "form-control Numeric";
                if (objTextbox != null)
                {
                    objTextbox.Style.Add("display", "none;");
                }
                //get first column and make readonly and enable true
                objTextbox = (TextBox)columnRepeater.Items[0].Controls[1];
                if (objTextbox != null)
                {
                    objTextbox.ReadOnly = true;
                    objTextbox.Enabled = false;
                }
                ////hide cell
                //objHtmlTableCell = (HtmlTableCell)columnRepeater.Items[1].Controls[0];
                //if (objHtmlTableCell != null)
                //{
                //    objHtmlTableCell.Style.Add("display", "none;");
                //}
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void gvITItem_ItemCreated(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Header)
        {
            //HtmlTableCell cell = (HtmlTableCell)e.Item.Controls[]
            //cell.Visible = false;
        }
        else if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            //HtmlTableCell cell = (HtmlTableCell)e.Item.FindControl("tdColumnToHideDetail");
            //cell.Visible = false;
        }
    }

    private DataSet FetchSaralFinancialCalculatorComputedData(string strApplicationNo, string strUserId)
    {
        objBussLayer = new BussLayer();
        _ds = new DataSet();
        objBussLayer.FetchSaralFinancialCalculatorComputedData(strApplicationNo, strUserId, ref _ds);
        return _ds;
    }

    private void BindComputedData(DataSet _ds)
    {
        if (_ds != null && _ds.Tables.Count > 0 && _ds.Tables[0].Rows.Count > 0)
        {
            dgShowCalculation.DataSource = _ds;
            //fill text boxes
            txtPremiumPayingCapacity.Text = Convert.ToString(_ds.Tables[0].Rows[0]["PREMIUMPAYINGCAPACITY"]);
            txtBalanceEligibility.Text = Convert.ToString(_ds.Tables[0].Rows[0]["BALANCEELIGIBILITY"]);
            txtTotalInvestment.Text = Convert.ToString(_ds.Tables[0].Rows[0]["TOTALINVESTMENT"]);
        }
        else
        {
            dgShowCalculation.DataSource = null;
        }
        dgShowCalculation.DataBind();

    }

    private void FetchFinancialCalculatorLiquid(string strApplicationNo, ref DataSet _ds)
    {
        _ds = new DataSet();
        objBussLayer = new BussLayer();
        objBussLayer.FetchFinancialCalculatorLiquid(strApplicationNo, ref _ds);
    }

    private void BindLiquidDetails(DataSet _ds)
    {
        if (_ds != null && _ds.Tables.Count > 0 && _ds.Tables[0].Rows.Count > 0)
        {
            dgLiquidInvestment.DataSource = _ds.Tables[0];
            dgLiquidInvestment.DataBind();
        }
    }

    protected void dgLiquidInvestment_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        e.Item.Cells[0].Style.Add("display", "none;");
    }

    private void SaveLiquidInvestment()
    {
        TextBox objTextBox;        
        if (dgLiquidInvestment != null && dgLiquidInvestment.Items.Count > 0)
        {
            for (int i = 0; i < dgLiquidInvestment.Items.Count; i++)
            {
                objTextBox = (TextBox)(dgLiquidInvestment.Items[i].Cells[2].Controls[1]);
                //save liquid investment to db
                ManageFinancialCalculatorLiquidInvestment(txtApplicationNo.Text, dgLiquidInvestment.Items[i].Cells[0].Text, objTextBox.Text, strUserId);
            }
        }
    }

    private void ManageFinancialCalculatorLiquidInvestment(string strApplicationNo, string strInvestmentType, string strInvestmentAmount, string strUserId)
    {
        objBussLayer = new BussLayer();
        objBussLayer.ManageFinancialCalculatorLiquidInvestment(strApplicationNo, strInvestmentType, strInvestmentAmount, strUserId);
    }

    private bool ValidateControls()
    {        
        decimal decRet;
        if (string.IsNullOrEmpty(txtApplicationNo.Text))
        {
            lblErrorUWFinancialCalculator.Text="Enter Application No";
            txtApplicationNo.Focus();
            return false;
        }

        if (string.IsNullOrEmpty(txtDateOfBirth.Text))
        {
            lblErrorUWFinancialCalculator.Text = "Enter Date Of Birth";
            txtDateOfBirth.Focus();
            return false;
        }

        if (!decimal.TryParse(txtExistingInsuranceCover.Text,out decRet))
        {
            lblErrorUWFinancialCalculator.Text = "Existing Insurance Cover is not numeric";
            txtExistingInsuranceCover.Focus();
            return false;
        }
        return true;
    }

}