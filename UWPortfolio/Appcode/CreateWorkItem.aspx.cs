using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public partial class Appcode_CreateWorkItem : System.Web.UI.Page
{
    Commfun objCommFun = new Commfun();
    BussLayer objBussLayer = new BussLayer();
    DataSet _ds = null;
    int ret=0;

    CommonObject objCommonObj = new CommonObject();
    string strUserId = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        objCommonObj = (CommonObject)Session["objCommonObj"];
        strUserId = objCommonObj._Bpmuserdetails._UserID;
    }
 
    protected void btnubmit_Single_Click(object sender, EventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(txtappno.Text))
            {
                objCommFun.CreateWorkItem_Single(txtappno.Text, "", ref ret);
                if (ret > 0)
                {
                    lblmsg.Visible = true;
                    lblmsg.Text = "Work item created successfully..";
                    lblmsg.ForeColor = System.Drawing.Color.Green;
                    txtappno.Text = string.Empty;
                    //insert log
                    objCommFun.Logs_Workitem(txtappno.Text, 1, "", strUserId, ref ret);
                }
                else
                {
                    lblmsg.Visible = false;
                    objCommFun.Logs_Workitem(txtappno.Text, 0, "", strUserId, ref ret);
                }
            }
            else
            {
                lblmsg.Visible = true;
                lblmsg.Text = "Please enter application no..";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
            
        }
        catch (Exception ex)
        {

            objCommFun.Logs_Workitem(txtappno.Text, 0, ex.ToString(), strUserId, ref ret);
        }
       
    }

    protected void btnubmit_Bulk_Click(object sender, EventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(txtappno.Text))
            {
                objCommFun.CreateWorkItem_Bulk(txtappno.Text, "", ref ret);
                if (ret > 0)
                {
                    lblmsg.Visible = true;
                    lblmsg.Text = "Work item created successfully..";
                    lblmsg.ForeColor = System.Drawing.Color.Green;
                    //insert log
                    objCommFun.Logs_Workitem(txtappno.Text, 1, "", strUserId, ref ret);
                }
                else
                {
                    lblmsg.Visible = false;
                    //insert log
                    objCommFun.Logs_Workitem(txtappno.Text, 0, "", strUserId, ref ret);
                }
            }
            else
            {
                lblmsg.Visible = true;
                lblmsg.Text = "Please enter application no..";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        catch (Exception ex)
        {

            objCommFun.Logs_Workitem(txtappno.Text, 0,ex.ToString(), strUserId, ref ret);
        }
        
    }
}