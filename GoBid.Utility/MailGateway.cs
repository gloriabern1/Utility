using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
namespace GoBid.Utility
{
    public class MailGateway
    {
        public static string Sendmail(string smtpusername, string smtppassword, int smtpclientport,
            string smtpclienthost, string Senderemail, string senderpassword, string Receivermail, string mailsubject,
            string mailmessage)
        {
            string Error;
            string username = smtpusername; // e.g gloonyi@gmail.com, since i am using gmail smtp host
            string password = smtppassword;
            var smtpclient = new SmtpClient();
            var mail = new System.Net.Mail.MailMessage();
            MailAddress fromaddress = new MailAddress(Senderemail);
            //Set the email smtp host 
            smtpclient.Host = smtpclienthost;
            // setting the smtp server it is sending the email from e.g gmail, yahoo, hotmail etc.
            smtpclient.Port = smtpclientport;
            mail.From = fromaddress;
            mail.To.Add(Receivermail);
            mail.Subject = (mailsubject);
            mail.IsBodyHtml = true;
            mail.Body = mailmessage;
            smtpclient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpclient.Credentials = new System.Net.NetworkCredential(username, password);
            try
            {
                //Sending Email
                smtpclient.Send(mail);
                return Error = "Email Has been sent successfully.";
            }
            catch (Exception ex)
            {
                //Catch if any exception occurs

                return Error = "Email Sending Fail:" + (ex.Message);
            }
        }
    }
}
