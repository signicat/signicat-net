namespace Signicat.Services.Signing.Express.Entities
{
    public class NotificationLogItem
    {
        public string SentTimeStamp { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public string MessageType { get; set; }

        public string Status { get; set; }

        public string FromAddress { get; set; }

        public string Receiver { get; set; }
    }
}