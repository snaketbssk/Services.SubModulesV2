namespace Services.SubModules.Configurations.Constants
{
    public static class ConfigurationConstant
    {
        // Directories
        public const string APPSETTINGS_DIRECTORY = "appsettings";
        public const string LOGS_DIRECTORY = "logs";
        public const string LOCALIZATIONS_DIRECTORY = "localizations";
        // Files
        public const string EXCEPTION_FILE = "exceptions.txt";
        public const string CORS_FILE = "appsettings.Cors.json";
        public const string GRPC_FILE = "appsettings.Grpc.json";
        public const string ENTITY_FRAMEFORK_FILE = "appsettings.EntityFramework.json";
        public const string SWAGGER_FILE = "appsettings.Swagger.json";
        public const string SERILOG_FILE = "appsettings.Serilog.json";
        public const string SERVICE_FILE = "appsettings.Service.json";
        public const string REDIS_FILE = "appsettings.Redis.json";
        public const string TOKEN_FILE = "appsettings.Token.json";
        public const string CRYPTOGRAPHY_FILE = "appsettings.Cryptography.json";
        public const string LOCALIZATION_FILE = "appsettings.Localization.json";

        // Environments
        public const string SWAGGER_ENVIRONMENT = "SWAGGER_";
        public const string REDIS_ENVIRONMENT = "REDIS_";
        public const string DATABASE_ENVIRONMENT = "DATABASE_";
        public const string ASPNETCORE_ENVIRONMENT = "ASPNETCORE_";
        public const string SERILOG_ENVIRONMENT = "SERILOG_";
        public const string RABBITMQ_ENVIRONMENT = "RABBITMQ_";
        public const string SECURITY_ENVIRONMENT = "SECURITY_";
        public const string GRPC_ENVIRONMENT = "GRPC_";
        public const string LOCALIZATION_ENVIRONMENT = "LOCALIZATION_";
        public const string CRYPTOGRAPHY_ENVIRONMENT = "CRYPTOGRAPHY_";
        public const string SERVICE_ENVIRONMENT = "SERVICE_";

        // Services
        public const string IDENTITY_SERVICE = "IDENTITY";
        public const string LOGGER_SERVICE = "LOGGER";
        public const string MAILER_SERVICE = "MAILER";
        public const string STORAGE_SERVICE = "STORAGE";
        public const string TELEGRAM_SERVICE = "TELEGRAM";
        public const string NOTIFICATIONS_SERVICE = "NOTIFICATIONS";
        public const string WALLETS_SERVICE = "WALLETS";
        public const string COMMON_SERVICE = "COMMON";
    }
}
