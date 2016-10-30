using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Net.Mail;

namespace WebbShop
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session["MaxValueForRange"] = "100000";
            Session["MinValueForRange"] = "0";
            Session["MinValue"] = "0";
            Session["MaxValue"] = "100000";

            
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            try
            {
                // parametrarna är: Host, och port
                SmtpClient smtpClient = new SmtpClient("localhost", 25);

                //parametrar username, och password
                smtpClient.Credentials = new NetworkCredential("grupp3.projekt.webforms@gmail.com", "grupp3projekt");
                smtpClient.UseDefaultCredentials = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                //smtpClient.EnableSsl = true;
                String ErrorMessage = "The error description is as follows : " + Server.GetLastError().ToString();

                MailMessage mail = new MailMessage();
                mail.Priority = MailPriority.High;

                //Setting From , To and CC
                mail.Subject = "fel i sidan";
                mail.From = new MailAddress("grupp3.projekt.webforms@gmail.com", "MyWeb Site");
                mail.To.Add(new MailAddress("Pmysssspercut@user.com"));
                mail.Body = ErrorMessage;

                smtpClient.Send(mail);
            }
            catch (Exception exception)
            {
                //ignore
            }
            finally
            {
                
            }
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}