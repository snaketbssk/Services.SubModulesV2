namespace Services.SubModules.LogicLayers.Authentications.Claims
{
    public enum TypeClaim
    {
        // Common
        User,
        ManageUser,

        Role,
        ManageRole,

        RealEstate,
        ManageRealEstate,

        Referral,
        ManageReferral,
        // Services
        Service,

        Telegram,
        ManageTelegram,

        Mailer,
        ManageMailer,

        Storage,
        ManageStorage,

        Notifications,
        ManageNotifications,
        // Other Services
        RealtorApplication,
        ManageRealtorApplication,

        CompanyApplication,
        ManageCompanyApplication
    }
}
