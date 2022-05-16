using System;
using System.Windows;
using System.Net.Mail;
using System.Net;

namespace Kyrsach
{
    public class MailSender
    {
        private Random rand = new Random();
        public int code;
        public string SaveLog;
        public void SendEmail()
        {
            code = rand.Next(1000,9999);
            MailAddress from = new MailAddress("aksenni.2002@gmail.com", "VA_Crypto");
            MailAddress to = new MailAddress(App.Current.Resources["SaveMail"].ToString());
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Код для входа";
            m.Body = code.ToString();
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("aksenni.2002@gmail.com", "lrcndrelxdypfxiv");
            smtp.Send(m);
            App.Current.Resources["Code"] = code;
            MessageBox.Show("Письмо отправлено");
        }
    }
}
