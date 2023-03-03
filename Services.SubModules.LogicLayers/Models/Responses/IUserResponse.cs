using Services.SubModules.DataLayers.Models.Tables;
using Services.SubModules.LogicLayers.Models.Responses.Entities;

namespace Services.SubModules.LogicLayers.Models.Responses
{
    public interface IUserResponse : IBaseTable<Guid>
    {
        string? Login { get; set; }
        string? Email { get; set; }
        bool? ConfirmedEmail { get; set; }
        string? PhoneNumber { get; set; }
        bool? ConfirmedPhoneNumber { get; set; }
        bool? TwoFactorEnabled { get; set; }
        List<RoleResponse>? Roles { get; set; }
        List<ClaimResponse>? Claims { get; set; }
    }
}
