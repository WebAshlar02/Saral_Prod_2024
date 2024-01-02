using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UWSaralDecision;
using UWSaralServices;

public partial class DmsVeiwer : System.Web.UI.Page
{
    string Appno = string.Empty;
    string DocType = string.Empty;
    UWSaralServices.CommFun objcomm = new UWSaralServices.CommFun();
    string DocTYP1 = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        
        if (Request.QueryString["ApplnNo"] != null)
        {
            Appno = Convert.ToString(Request.QueryString["ApplnNo"]);
            //Appno = "H00043957";

        }
        //objcomm.MaintainLog("DMS Link 1", "DMS_ViewDoc", string.Empty, IframeAdr.Src, string.Empty, string.Empty, "UWSaral", "UWSaral", string.Empty, Appno);
        if (Request.QueryString["DocType"] != null)
        {
            DocType = Convert.ToString(Request.QueryString["DocType"]);
        }
        FetchData(Appno, DocType);
    }
    protected void Getimg_Click(object sender, EventArgs e)
    {
        FetchData(TxtAppNo.Text, "");
    }

    private void FetchData(string strApplicationNo, string Doctype)
    {
        //objcomm.MaintainLog("DMS Link 2", "DMS_ViewDoc", string.Empty, "", string.Empty, string.Empty, "UWSaral", "UWSaral", string.Empty, strApplicationNo);
        divrw1.Visible = false;
        row2.Visible = true;
        string ApplicationNo = strApplicationNo;
        // string DocTYP = "Age Proof";
        if (!string.IsNullOrEmpty(Doctype))
        {
            DocTYP1 = "Medical Requirement";
        }
        else
        {
            DocTYP1 = "Application Form";
        }
        //objcomm.MaintainLog("DMS Link 3", "DMS_ViewDoc", Doctype, DocTYP1, string.Empty, string.Empty, "UWSaral", "UWSaral", string.Empty, ApplicationNo);
        //string DocTYP2 = "Identification Proof";
        // string DocTYP3 = "Income Proof";
        //string DocTYP4 = "SIS";
        //string DocTYP5 = "Photograph";
        string GETIMAGE = ConfigurationManager.AppSettings["GETIMAGE"].ToString() + "=" + ApplicationNo;
        string DocKey = ConfigurationManager.AppSettings["GETIMAGE"].ToString() + "=" + ApplicationNo + ConfigurationManager.AppSettings["DOCKEY"].ToString();
        //objcomm.MaintainLog("DMS Link 4", "DMS_ViewDoc", DocKey, GETIMAGE, string.Empty, string.Empty, "UWSaral", "UWSaral", string.Empty, ApplicationNo);
        if (!string.IsNullOrEmpty(Doctype))
        {
            IframeAdr.Src = DocKey + DocTYP1;
        }
        else
        {
            IframeAPP.Src = GETIMAGE;
            IframeAdr.Src = DocKey + DocTYP1;
        }
        
        //objcomm.MaintainLog("DMS Link 5", "DMS_ViewDoc", string.Empty, IframeAdr.Src, string.Empty, string.Empty, "UWSaral", "UWSaral", string.Empty, ApplicationNo);
        //IframeAge.Src = DocKey + DocTYP;
        //IframeID.Src = DocKey + DocTYP2;
        //IframeIncome.Src = DocKey + DocTYP3;
        // IframeSIS.Src = DocKey + DocTYP4;
        //IframePIC.Src = DocKey + DocTYP5; 
    }
}