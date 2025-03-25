namespace Signicat.Services.Signing.Express.Entities
{
    public class NotificationSetup
    {
        public NotificationSetting? Request { get; set; }

        public NotificationSetting? Reminder { get; set; }

        public NotificationSetting? SignatureReceipt { get; set; }

        public NotificationSetting? FinalReceipt { get; set; }

        public NotificationSetting? Canceled { get; set; }

        public NotificationSetting? Expired { get; set; }
    }
}