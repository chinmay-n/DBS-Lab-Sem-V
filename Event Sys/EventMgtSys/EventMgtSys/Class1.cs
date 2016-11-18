using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EventMgtSys
{
    class Class1
    {
        public Class1() {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("hostel.rup.project@gmail.com");
                mail.To.Add("chinmayn96@gmail.com");
                mail.Subject = "Test Mail";
                mail.Body = "This is for testing SMTP mail from GMAIL";

                SmtpServer.Port = 465;
                SmtpServer.Credentials = new System.Net.NetworkCredential("hostel.rup.project@gmail.com", "projectacc");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
               Console.WriteLine("mail Send");
            }
            catch (Exception ex)
            {
              //  MessageBox.Show(ex.ToString());
            }
        }
    }
}
