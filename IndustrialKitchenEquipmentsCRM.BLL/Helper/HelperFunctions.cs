using System.Net;
using System.Net.Mail;
using System.Text;
using IndustrialKitchenEquipmentsCRM.DTOs.Category;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IndustrialKitchenEquipmentsCRM.BLL.Helper
{
    public class HelperFunctions
    {
        public static bool EmailSender(string fromSend, string password, string toSend, Attachment attachment, string subject, string body)
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

        public static string GetHTMLString()
        {
            var sb = new StringBuilder();
            sb.Append(@"<!DOCTYPE html>
                            <html lang=""en"">
                            <head>
                                <meta charset=""UTF-8"">
                                <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
                                <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                                <!-- CSS only -->
                            <link href=""https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/css/bootstrap.min.css"" rel=""stylesheet"" integrity=""sha384-Zenh87qX5JnK2Jl0vWa8Ck2rdkQ2Bzep5IDxbcnCeuOxjzrPF/et3URy9Bv1WTRi"" crossorigin=""anonymous"">
                            <!-- JavaScript Bundle with Popper -->
                            <script src=""https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/js/bootstrap.bundle.min.js"" integrity=""sha384-OERcA2EqjJCMA+/3y+gxIOqMEjwtxJY7qPCqsdltbNJuaOe923+mo//f6V8Qbsw3"" crossorigin=""anonymous""></script>
                                <title>Document</title>
                            </head>


                              <body>
                              <div class=""container"">
                                  <table class=""table"">
                                      <thead>
                                        <tr>
                                          <th scope=""col"">#</th>
                                          <th scope=""col"">First</th>
                                          <th scope=""col"">Last</th>
                                        </tr>
                                      </thead>
                                      <tbody>");
            sb.AppendFormat(@"<tr>
              <td>{0}</td>
              <td>{1}</td>
              <td>{2}</td>
            </tr>",1,2,3);

            sb.AppendFormat(@" </tbody>
                            </table>
<button type=""button"" class=""btn btn-primary"">Primary</button>
                      </div>
                      </body>
                    </html>"
            );

            return sb.ToString();

        }

    }
}
