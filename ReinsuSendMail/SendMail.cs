using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ReinsuSendMail
{
    public class SendMail
    {
        bool sendmail = false;
        public bool ReinsuSendMail(string strComment,string strSubject)
        {

            SmtpClient smtpClient = new SmtpClient();
            NetworkCredential basicCredential = new NetworkCredential("communications@futuregenerali.in", "");
            MailMessage message = new MailMessage();
            MailAddress fromAddress = new MailAddress("communications@futuregenerali.in");

            // setup up the host, increase the timeout to 5 minutes

            smtpClient.Host = "outlook.fgi.ad";
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = basicCredential;
            smtpClient.Timeout = (60 * 5 * 1000);
            smtpClient.Port = 25;

            message.From = fromAddress;
            message.Subject = strSubject;
            message.IsBodyHtml = true;
            //string BodyHeadText = Body + "\n" + "SP_Name :" + SpName + " , DBName :" + DbName + " , Server Name :" + ServerName + ", Project Name :" + ProjectName+"\n"+ "Please check below Data";
            string BodyHeadText = strComment;
            //message.Body = BodyHeadText;
            StringBuilder sb = new StringBuilder(BodyHeadText);
            //string strhtm = getHTML(dtsp_data);
            //sb.Append(strhtm);
            message.Body = sb.ToString();
            message.To.Add("pinwheel2@futuregenerali.in");
            //message.To.Add(DD);

            //if (location != null)
            //message.Attachments.Add(new Attachment(location));

            smtpClient.Send(message);
            return sendmail;
        }
    }
}
