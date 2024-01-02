using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Appcode_result : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
        {
        string strpath = string.Empty;
        //string strpath = "../Video/D00577422-1.mp4";
        //strpath= "http://localhost:58531/video/D00577422-1.mp4";

        //string path = "\\\\10.1.42.35\\uw_tp\\VIDEO FILE\\SampleVideo_1280x720_1mb.mp4";
        //string path = "../SampleVideo_1280x720_1mb.mp4";

        if (Request.QueryString["path"] != null)
        {
            strpath = UWSaralDecision.CommFun.Base64DecodingMethod(Request.QueryString["path"]);
            //strApplicationno = UWSaralDecision.CommFun.Base64DecodingMethod(Request.QueryString["qsAppNo"]);
            //strpath = Request.QueryString["path"];
            Page.Controls.Add(new LiteralControl("<video width='620' height='440' autoplay='autoplay' controls='controls'><source src= '" + strpath + "' type='video/mp4'/></video>"));
            //Page.Controls.Add(new LiteralControl("<video src='"+strpath+"' controls='controls' width='500' height='300'></video>"));

            //HtmlGenericControl control = new HtmlGenericControl("source");
            //control.Attributes.Add("src", strpath);
        }

    }
}