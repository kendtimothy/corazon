using CorazonLibrary.Email.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CorazonLibrary.Email
{
    /// <summary>
    /// Provides SMTP client services.
    /// GitHub - https://github.com/kendtimothy/Corazon/blob/master/Corazon/Email
    /// By Ken D Timothy - Jakarta, Indonesia
    /// 
    /// DEPENDENCIES:
    ///     > Corazon/Email/Models
    /// 
    /// NOTE:
    ///     > You need to define these variables in your web.config under appSettings
    ///       EmailID, EmailDisplayName, EmailPassword (which is your default sender credentials)
    /// </summary>
    public class EmailService
    {
        /// <summary>
        /// Default sender email client. This value needs to be set when attempting to call a function to send with default credentials.
        /// </summary>
        public MEmailClient DefaultSender { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public EmailService() { }


        /// <summary>
        /// Constructor to initialize object with default sender.
        /// </summary>
        public EmailService(MEmailClient defaultSender)
        {
            this.DefaultSender = defaultSender;
        }

        /// <summary>
        /// Send an email message from the sender to the receiver.
        /// </summary>
        /// <param name="sender">The sender of the email with the credentials initialized.</param>
        /// <param name="recipient">The receiver of the email.</param>
        /// <param name="message">The message to send.</param>
        public void Send(MEmailClient sender, List<MEmailClient> recipients, MEmailMessage message)
        {
            // init mail message object
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(sender.EmailID, sender.Password);
            mailMessage.Subject = message.Subject;
            mailMessage.Body = message.Body;
            mailMessage.IsBodyHtml = message.IsBodyHtml;

            // include all recipients to our mail message object
            foreach(MEmailClient recipient in recipients)
            {
                mailMessage.To.Add(recipient.EmailID);
            }

            // set SMTP client object
            SmtpClient smtpClient = new SmtpClient(sender.Provider.Host, sender.Provider.Port);
            smtpClient.EnableSsl = sender.Provider.EnableSSL;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = false;

            // set timeout for the SMTP server to respond
            smtpClient.Timeout = (int)TimeSpan.FromSeconds(10).TotalMilliseconds;

            smtpClient.Send(mailMessage);
        }

        /// <summary>
        /// Send an email message from the sender to the receiver with the default sender configured.
        /// </summary>
        /// <param name="recipient">The receiver of the email to send.</param>
        /// <param name="message">The message to send.</param>
        public void SendWithDefaultSender(List<MEmailClient> recipients, MEmailMessage message)
        {
            Send(DefaultSender, recipients, message);
        }
    }
}
