namespace CorazonLibrary.Email.Models
{
    public class MEmailProvider
    {
        /// <summary>
        /// The name of the provider.
        /// Sample Data: GMail
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A string that contains the name or IP address of the host used for SMTP transactions.
        /// Sample Data: smtp.gmail.com
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// An integer greater than zero that contains the port to be used on host.
        /// Sample Data: 587
        /// </summary>
        
        public int Port { get; set; }

        /// <summary>
        /// Flag to determine whether connection to this provider requires a SSL (HTTPS) connection.
        /// </summary>
        public bool EnableSSL { get; set; }
    }
}
