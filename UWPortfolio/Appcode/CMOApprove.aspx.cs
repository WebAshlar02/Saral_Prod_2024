using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UWSaralObjects;

public partial class Appcode_CMOApprove : System.Web.UI.Page
{
    Commfun objComm = new Commfun();
    BussLayer buss = new BussLayer();
    ChangeValue objChangeObj = new ChangeValue();
    string FileGetCMO = ConfigurationManager.AppSettings["CMOFileGet"].ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        Application_Number.Text = Request.QueryString["qsAppNo"];
      
        objChangeObj = (ChangeValue)Session["objLoginObj"];
        if (!Page.IsPostBack)
        {
            BindData();
        }
    }

    public void BindData()
    {
        dynamic Values = buss.GetCMOComments(Application_Number.Text);
        TableCMO.DataSource = Values;
        TableCMO.DataBind();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string Filepaths = ConfigurationManager.AppSettings["CMOFileCommentUpload"].ToString();
            int UWCommentResult = 0;
            objComm.OnlineUWCommentsDetails_Save(objChangeObj.userLoginDetails._UserName, objChangeObj.userLoginDetails._ProcessName, objChangeObj.userLoginDetails._UserGroup, Convert.ToString(txtComments.Text), Application_Number.Text, objChangeObj.userLoginDetails._UserID, objChangeObj.userLoginDetails._UserName, objChangeObj.userLoginDetails._UserGroup, objChangeObj.userLoginDetails._userBranch, objChangeObj.userLoginDetails._userBranch, objChangeObj.userLoginDetails._ProcessName, Application_Number.Text, "General", ref UWCommentResult);
            objComm.UpdateUCNNumber(Application_Number.Text, txtComments.Text, objChangeObj.userLoginDetails._UserID);
            objComm.UpdateAppNoPendingToResolve(Application_Number.Text);
            string CommentFilepaths = ConfigurationManager.AppSettings["CMOCommentFilePath"].ToString();
            string FileName = "New Business_" + Application_Number.Text + "_CMO Opinion.txt".ToString();
            string file = CommentFilepaths + FileName;
            if (!System.IO.Directory.Exists(CommentFilepaths))
            {
                System.IO.Directory.CreateDirectory(CommentFilepaths);
            }
            if (File.Exists(file))
            {
                File.Delete(file);
            }
            using (StreamWriter sw = File.CreateText(file))
            {
                sw.WriteLine("ApplicationNo:- " + Application_Number.Text);
                sw.WriteLine("Comment:- "+txtComments.Text);
            }
            File.Move(file, Filepaths + FileName);
        }
        catch (Exception ex)
        {

        }
        string jScript = "<script>window.close();</script>";
        ClientScript.RegisterClientScriptBlock(this.GetType(), "keyClientBlock", jScript);

    }
    protected void btnViewDoc_Click(object sender, EventArgs e)
    {
        try
        {
            List<string> FileList = new List<string>();
            DirectoryInfo di = new DirectoryInfo(FileGetCMO);
           IEnumerable<FileInfo> fileList = di.GetFiles("*.*");
           IEnumerable<FileInfo> fileQuery = from file in fileList
                                      where (file.Name.Contains(Application_Number.Text))
                                      select file;
                    foreach (System.IO.FileInfo fi in fileQuery)
                    {
                    fi.Attributes = FileAttributes.Normal;
                    FileList.Add(fi.FullName);
                    }
            string Path = FileList[0];
            if (File.Exists(Path))
            {

                FileStream fs = new FileStream(Path, FileMode.Open, FileAccess.Read);
                byte[] ar = new byte[(int)fs.Length];
                fs.Read(ar, 0, (int)fs.Length);
                fs.Close();
                Response.AddHeader("content-disposition", "attachment;filename=New Business_" + Application_Number.Text + "_Special Medical Reports.pdf");
                Response.ContentType = "application/pdf";
                Response.BinaryWrite(ar);
                Response.End();
            }
        }
        catch (Exception ex)
        {

        }
    }

}