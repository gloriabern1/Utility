using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace GoBid.Utility

{
    public class MailGateway
    {
        public static SmtpClient smtpclient = new SmtpClient();
        public static MailMessage mail = new MailMessage();
        public static string Error;
        public static string SendmailforRegisterconfirm(string Senderemail, string Receivermail, string mailsubject, string Username)
        {


         
           try
            {
                // initializing mail components
                MailAddress fromaddress = new MailAddress(Senderemail);
                mail.From = fromaddress;
                mail.To.Add(Receivermail);
                mail.Subject = (mailsubject);
                mail.IsBodyHtml = true;
                mail.Body = MailGateway.Emailhtmlcontent(Username); 
                smtpclient.DeliveryMethod = SmtpDeliveryMethod.Network;
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


        public static string SendmailwithAttachment(string Senderemail, string Receivermail, string mailsubject, string Username, string attachmentpath)
        {

            try
            {
                // initializing mail components
                MailAddress fromaddress = new MailAddress(Senderemail);
                mail.From = fromaddress;
                mail.To.Add(Receivermail);
                mail.Subject = (mailsubject);
                mail.IsBodyHtml = true;
                mail.Body = MailGateway.Emailhtmlcontent(Username);
                Attachment mailattachment = new Attachment(attachmentpath);
                mail.Attachments.Add(mailattachment);
                smtpclient.DeliveryMethod = SmtpDeliveryMethod.Network;
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


        public static string Emailhtmlcontent(string username)
        {
            StringBuilder SbBody = new StringBuilder();
            SbBody.Append(" <html xmlns='http://www.w3.org/1999/xhtml'>");
            SbBody.Append(" <head><title>Confirmation mail</title></head>");
            SbBody.Append("< body >");
            SbBody.Append("< img src = '//www.GoBid.com/images/Blue/Logo.png'/><br /><br />");
            SbBody.Append("<div style = 'border-top:3px solid #22BCE5' > &nbsp;</div>");
            SbBody.Append("<span style = 'font-family:Arial; font-size:10pt' >");
            SbBody.Append("Hello < b >{username} click the button below to confirm your email and complete your registration <br/> <br/>");
            SbBody.Append(" <a href='www.GoBid.com/Registration/Confirm.aspx' style='background-color:blue; font-size:14px'>Click Here</a>");
            SbBody.Append("< /span >");
            SbBody.Append("< /body >");
            SbBody.Append("< /html >");
            return SbBody.ToString();
        }
    }
}
