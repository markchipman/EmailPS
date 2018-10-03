using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailPS.Common {
    public static class Configs {
        public static string Email => ConfigurationManager.AppSettings["Email"];
        public static string Password => ConfigurationManager.AppSettings["Password"];
        public static string SendFromEmail => ConfigurationManager.AppSettings["SendFromEmail"];

        public static string IncomingHost => ConfigurationManager.AppSettings["IncomingHost"];
        public static string OutgoingHost => ConfigurationManager.AppSettings["OutgoingHost"];
        public static int IncomingPort => int.Parse(ConfigurationManager.AppSettings["IncomingPort"]);
        public static int OutgoingPort => int.Parse(ConfigurationManager.AppSettings["OutgoingPort"]);

        public static int Timeout => int.Parse(ConfigurationManager.AppSettings["Timeout"]);

        public static string DefaultInbox => ConfigurationManager.AppSettings["DefaultInbox"];
        public static string UnreadMessages => ConfigurationManager.AppSettings["UnreadMessages"];
        public static string AllMessages => ConfigurationManager.AppSettings["AllMessages"];
    }
}
