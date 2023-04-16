using Services.SubModules.LogicLayers.Models.Redis.Entities;

namespace Services.SubModules.LogicLayers.Models.Redis
{
    interface IUserRedis
    {
        string? Name { get; set; }
        string? Email { get; set; }
        bool ConfirmedEmail { get; set; }
        string? PhoneNumber { get; set; }
        bool ConfirmedPhoneNumber { get; set; }
        bool TwoFactorEnabled { get; set; }
        List<ClaimRedis> Claims { get; set; }
    }
}
