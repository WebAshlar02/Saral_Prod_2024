using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Platform.Utilities.LoggerFramework;
using System.Diagnostics;
using UWSaralServices;
using System.IO;
using ClosedXML.Excel;
using System.Net.Mail;
using System.Configuration;
using System.Web;

namespace TPAREGISTERMIS1
{
    class Program
    {
        static void Main(string[] args)
        {
            Program objprg = new Program();
            objprg.GetMIS();
        }
        private void GetMIS()
        {
            DataLayer objData = new DataLayer();
            Logger.Error("STAG 2 :PageName :TPAREGISTERMIS.CS // MethodeName :GetMIS Start" + System.Environment.NewLine);
            DataSet _ds;
            _ds = objData.RetrieveDataset_woParam("USP_UWSARAL_TPAREGISTER_MIS");
            ExportToExcel(_ds);

            Logger.Error("STAG 2 :PageName :TPAREGISTERMIS.CS // MethodeName :GetMIS End" + System.Environment.NewLine);
        }
        
        protected void ExportToExcel(DataSet ds)
        {

            ds.Tables[0].TableName = "Total Pending & Medical Cases";
            ds.Tables[1].TableName = "Registered Cases";
            ds.Tables[2].TableName = "Pending Registration Cases";
            string AppLocation = "";
            AppLocation = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            AppLocation = AppLocation.Replace("file:\\", "");
            string file = AppLocation + "\\TPAMIS.xlsx";

            XLWorkbook wb = new XLWorkbook();
            for (int i = 0; i < ds.Tables.Count; i++)
            {
                wb.Worksheets.Add(ds.Tables[i], ds.Tables[i].TableName);
            }
            wb.SaveAs(file);

            SendMail(file);
        }
        
        /*
        public void SendEmail(string MailTo, string MailSubject)
        {
            try
            {
                string AppLocation = "";
                AppLocation = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
                AppLocation = AppLocation.Replace("file:\\", "");
                string file = AppLocation + "\\ExcelFiles\\DataFile.xlsx";
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(ConfigurationManager.AppSettings["Host"].ToString());
                mail.From = new MailAddress(ConfigurationManager.AppSettings["MailFrom"].ToString());
                mail.To.Add(MailTo); // Sending MailTo  
                List<string> li = new List<string>();
                li.Add("saihacksoft@gmail.com");
                //li.Add("saihacksoft@gmail.com");  
                //li.Add("saihacksoft@gmail.com");  
                //li.Add("saihacksoft@gmail.com");  
                //li.Add("saihacksoft@gmail.com");  
                mail.CC.Add(string.Join<string>(",", li)); // Sending CC  
                mail.Bcc.Add(string.Join<string>(",", li)); // Sending Bcc   
                mail.Subject = MailSubject; // Mail Subject  
                mail.Body = "Sales Report *This is an automatically generated email, please do not reply*";
                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(file); //Attaching File to Mail  
                mail.Attachments.Add(attachment);
                SmtpServer.Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"]); //PORT  
                SmtpServer.EnableSsl = true;
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new NetworkCredential("Email id of Gmail", "Password of Gmail");
                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        */
        public void SendMail(string file)
        {
            try
            {
                string stremailSub = string.Empty;
                string strTOemail = string.Empty;
                string strsender, strCc, emailbody = string.Empty;
                emailbody = "Hi,</br></br> PFA.";
                SmtpClient objsmtpClient = new SmtpClient();
                strTOemail = ConfigurationSettings.AppSettings["ToEmailId"];
                strsender = ConfigurationSettings.AppSettings["SenderEmailId"];
                stremailSub = ConfigurationSettings.AppSettings["EmailSubject"];
                objsmtpClient.Host = ConfigurationSettings.AppSettings["Host"];
                objsmtpClient.Port = Convert.ToInt32(ConfigurationSettings.AppSettings["MailServerPort"]);
                MailMessage objMailMessage = new MailMessage();
                objMailMessage.From = new MailAddress(strsender);
                foreach (var addressTo in strTOemail.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    objMailMessage.To.Add(strTOemail);
                }
                objMailMessage.Subject = stremailSub;
                objMailMessage.Body = emailbody;
                objMailMessage.IsBodyHtml = true;

                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(file); //Attaching File to Mail  
                objMailMessage.Attachments.Add(attachment);
                objsmtpClient.Send(objMailMessage);
            }
            catch (Exception Error)
            {
                //SaveErrorLogs("", "Failed", "UWRiskScoreSched", "PRECode.cs", "SendMail", "E-Error", "", "", Error.ToString());
            }
        }

    }

}
