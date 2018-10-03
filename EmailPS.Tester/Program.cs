using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActiveUp.Net.Mail;
using EmailPS.Common;
using EmailPS.Receiver;
using EmailPS.Sender;

namespace EmailPS.Tester {
    // email: ggggl0238@gmail.com
    // pass: 1qaz!1234

    public class Program {
        static void Main(string[] args) {
            var rep = new MailRepository();

            //rep.UnreadMailsToConsole();

            var res = MailSender.Send("@gmail.com", 
                "Test FROM CONSOLE 4", 
                "SOME BODY 123\r\nTEST098", 
                new List<string> {
                    @"C:\Users\toshe\OneDrive\Bilder\52392-matterhorn-top-1920x1200-nature-wallpaper.jpg",
                    @"C:\Users\toshe\Desktop\Credit request Form.pdf",
                    @"C:\Users\toshe\Desktop\Credit request Form2.pdf"
                });
            Console.WriteLine($"Sent: {res}");

            Console.ReadKey();
        }

        
    }
    
}
