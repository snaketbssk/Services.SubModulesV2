namespace Services.SubModules.Configurations.Models.Roots.Entities
{
    public class GrpcRoot
    {
        public int SecondsTimeout { get; set; }
        public int MaxReceiveMessageSize { get; set; }
        public int MaxSendMessageSize { get; set; }
        public string IdentityUrlGrpc { get; set; }
        public string StorageUrlGrpc { get; set; }
        public string TelegramUrlGrpc { get; set; }
        public string RealtorsUrlGrpc { get; set; }
        public string MailerUrlGrpc { get; set; }
        public string NotificationsUrlGrpc { get; set; }
    }
}
