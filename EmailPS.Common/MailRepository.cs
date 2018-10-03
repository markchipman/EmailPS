using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActiveUp.Net.Mail;

namespace EmailPS.Common
{
    public class MailRepository {
        private Imap4Client _client;

        public Imap4Client Client => _client ?? (_client = new Imap4Client());

        public MailRepository() {
            Client.ConnectSsl(Configs.IncomingHost, Configs.IncomingPort);
            Client.Login(Configs.Email, Configs.Password);
        }
    }
}
