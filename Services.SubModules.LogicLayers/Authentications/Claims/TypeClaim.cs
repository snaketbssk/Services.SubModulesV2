﻿namespace Services.SubModules.LogicLayers.Authentications.Claims
{
    public enum TypeClaim
    {
        // Common
        User,
        ManageUser,

        ManageRole,

        RealEstate,
        ManageRealEstate,

        Referral,
        ManageReferral,
        // Services

        Telegram,
        ManageTelegram,

        Mailer,
        ManageMailer,

        Storage,
        ManageStorage,

        Notifications,
        ManageNotifications,

        Logger,
        ManageLogger,

        Wallets,
        ManageWallets,

        // Other Services
        RealtorApplication,
        ManageRealtorApplication,

        CompanyApplication,
        ManageCompanyApplication
    }
}
