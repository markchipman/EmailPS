using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActiveUp.Net.Mail;
using EmailPS.Common;

namespace EmailPS.Receiver {
    public static class MailReceiver {
        public static IEnumerable<Message> GetAllMails(this MailRepository repo, string mailBox = null) {
            return repo.GetMails(string.IsNullOrEmpty(mailBox) ? Configs.DefaultInbox : mailBox, Configs.AllMessages).Cast<Message>();
        }

        public static IEnumerable<Message> GetUnreadMails(this MailRepository repo, string mailBox = null) {
            return repo.GetMails(string.IsNullOrEmpty(mailBox) ? Configs.DefaultInbox : mailBox, Configs.UnreadMessages).Cast<Message>();
        }

        public static void UnreadMailsToConsole(this MailRepository repo) {
            foreach (var email in repo.GetUnreadMails()) {
                Console.WriteLine($"{email.From}: {email.Subject}\r\n{email.BodyText.Text}");
                if (email.Attachments.Count > 0) {
                    foreach (MimePart attachment in email.Attachments) {
                        Console.WriteLine($"Attachment: {attachment.ContentName} {attachment.ContentType.MimeType}");
                    }
                }
            }
        }

        private static MessageCollection GetMails(this MailRepository repo, string mailBox, string searchPhrase) {
            var mails = repo.Client.SelectMailbox(mailBox);
            var messages = mails.SearchParse(searchPhrase);
            return messages;
        }
    }
}
