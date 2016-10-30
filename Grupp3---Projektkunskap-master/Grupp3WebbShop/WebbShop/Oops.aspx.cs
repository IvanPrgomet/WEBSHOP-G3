using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SqlServer.Server;
using System.Net.Mail;

namespace WebbShop.ErrorPages
{
    public partial class Oops : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBoxErrorMessage.Width = Unit.Percentage(100);
        }

        protected void ButtonSendErrorMail_Click(object sender, EventArgs e)
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

                MailMessage mail = new MailMessage();
                mail.Priority = MailPriority.High;

                //Setting From , To and CC
                mail.Subject = "fel i sidan - Info from user";
                mail.From = new MailAddress("grupp3.projekt.webforms@gmail.com", "MyWeb Site");
                mail.To.Add(new MailAddress("Pmysssspercut@user.com"));
                mail.Body = TextBoxErrorMessage.Text;
                
                smtpClient.Send(mail);
            }
            catch (Exception exception)
            {
                //Ignore
            }
            finally
            {
                
            }
        }
    }
}