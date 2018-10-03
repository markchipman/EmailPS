using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using EmailPS.Common;

namespace EmailPS.Sender {
    public static class MailSender {
        public static bool Send(string to, 
            string subject, 
            string body, 
            List<string> paths = null,
            List<StreamWrapper> streams = null) {

            try {
                var client = new SmtpClient {
                    Port = Configs.OutgoingPort,
                    Host = Configs.OutgoingHost,
                    EnableSsl = true,
                    Timeout = Configs.Timeout,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new System.Net.NetworkCredential(Configs.Email, Configs.Password)
                };

                var mm = new MailMessage(Configs.SendFromEmail, to, subject, body) {
                    BodyEncoding = Encoding.UTF8,
                    DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
                };

                if (paths != null)
                    foreach (var path in paths)
                        mm.Attachments.Add(new Attachment(path));

                if (streams != null)
                    foreach (var stream in streams)
                        mm.Attachments.Add(new Attachment(stream.Stream, stream.Name, stream.Type));

                client.Send(mm);

                mm.Dispose();
                client.Dispose();

                return true;
            }
            catch (Exception e) {
                Console.WriteLine(e);

                return false;
            }
        }
    }
}
