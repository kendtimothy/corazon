namespace CorazonLibrary.Email.Models
{
    public class MEmailClient
    {
        /// <summary>
        /// The name of the client. Can be used for signature name in case the client is the sender, or as a greeting when the client is a recipient.
        /// Sample Data: Ken D Timothy
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The email address of the client.
        /// Sample Data: corazon@kendtimothy.com
        /// </summary>
        public string EmailID { get; set; }

        /// <summary>
        /// The password of the client. Required in case the client is used for the sender.
        /// Sample Data: thisisadummypassword
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// The provider of the email client, such as GMail, Outlook, Yahoo, etc.
        /// </summary>
        public MEmailProvider Provider { get; set; }
    }
}
