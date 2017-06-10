using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace GoBid.Utility
{
    public class SmsGateway
    {
        public static bool SendSmsViaSmsMobile24(string username, string password, string sender, string recipient, string message)
        {
            //http://smsmobile24.com/components/com_spc/smsapi.php?username=xxxx&password=yyyy&balance=true&
            string balanceurl = "http://smsmobile24.com/components/com_spc/smsapi.php?username=" + username +
                                "&password=" + password + "&balance=true&";

            //http://smsmobile24.com/components/com_spc/smsapi.php?username=xxxx&password=yyyy&sender=@@sender@@&recipient=@@recipient@@&message=@@message@@
            string apiUrl =
                "http://smsmobile24.com/components/com_spc/smsapi.php?username=" + username + "&password=" + password +
                "&sender=" + sender + "&recipient=" + recipient + "&message=" + message;

            var response = "";

            try
            {
                var balReq = WebRequest.Create(balanceurl);
                var balResp = balReq.GetResponse();
                var balSr = new StreamReader(balResp.GetResponseStream());
                var balReadLine = balSr.ReadLine();
                if (balReadLine != null) response = balReadLine.Trim().ToString(CultureInfo.InvariantCulture);

                decimal smsBalance = Convert.ToDecimal(response);
                if (smsBalance > 1)
                {
                    var req = WebRequest.Create(apiUrl);
                    var resp = req.GetResponse();
                    var sr = new StreamReader(resp.GetResponseStream());
                    var readLine = sr.ReadLine();
                    if (readLine != null) response = readLine.Trim().ToString(CultureInfo.InvariantCulture);

                    if (response.Contains("OK"))
                    {
                        return true;
                    }
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

            return false;
        }
    }
}
