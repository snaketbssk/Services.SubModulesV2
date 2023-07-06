namespace Services.SubModules.Configurations.Models.Roots.Entities.Environments
{
    public class GrpcEnvironmentRoot
    {
        public string? TOKEN { get; set; }
        public int? TIMEOUT { get; set; }
        public int? RECEIVE_SIZE { get; set; }
        public int? SEND_SIZE { get; set; }
        public string? IDENTITY_HOST { get; set; }
        public string? TELEGRAM_HOST { get; set; }
        public string? REALTORS_HOST { get; set; }
        public string? STORAGE_HOST { get; set; }
        public string? MAILER_HOST { get; set; }
        public string? NOTIFICATIONS_HOST { get; set; }
        public string? WALLETS_HOST { get; set; }
        public string? COMMON_HOST { get; set; }
        public string? REFERRALS_HOST { get; set; }
    }
}
