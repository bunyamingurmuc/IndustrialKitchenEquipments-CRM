using System.Net;
using System.Net.Mail;

namespace IndustrialKitchenEquipmentsCRM.BLL.Helper
{
    public class HelperFunctions
    {
        public static bool EmailSender(string fromSend, string password,string toSend, Attachment attachment, string subject, string body)
        {
            #region açıklama satırları
            //var mail = new MailMessage();
            //mail.From = new MailAddress("mahmutgurmuc@gmail.com");
            //mail.To.Add(toSend);
            //mail.Subject = subject;
            //mail.Body = body;
            //mail.Attachments.Add(attachment);
            //SmtpClient client = new SmtpClient(host, port)
            //{
            //    Credentials = new NetworkCredential("mahmutgurmuc@gmail.com", "1344230020"),  
            //    EnableSsl = true
            //};
            //client.Send(
            //    new MailMessage());
            //return true;

            #endregion
            MailMessage mailMessage = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Credentials = new NetworkCredential(fromSend, password);
            smtpClient.Port = 587;
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.EnableSsl = true;
            mailMessage.To.Add(toSend);
            mailMessage.From = new MailAddress(fromSend);
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            mailMessage.Attachments.Add(attachment);
            smtpClient.Send(mailMessage);
            return true;
            
        }


    }
}
