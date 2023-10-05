using System.Collections.Generic;

namespace Signicat.Services.Signing.Express.Entities
{
    public class ManualReminder 
    {
        /// <summary>
        /// Set what kind of reminders to send
        /// </summary>
        public NotificationSetting NotificationSetting { get; set; }
    
        /// <summary>
        /// Optional: Define the signers that should receive this reminder (if not signed). Dictionary with signer id as key, you can override the signer email/phone as value
        /// </summary>
        public Dictionary<string, SignerOverrides> Signers { get; set; }
    }
}