using Services.SubModules.LogicLayers.Attributes.Entities;
using Services.SubModules.LogicLayers.Constants;

namespace Services.SubModules.LogicLayers.Models.Authentication
{
    public enum GroupAuthentication
    {

        [Group(GroupConstant.SERVICE)]
        Service,

        [Group(GroupConstant.ADMIN)]
        Admin,

        [Group(GroupConstant.USER)]
        User,

        [Group(GroupConstant.MANAGER)]
        Manager,

        [Group(GroupConstant.IDENTITY)]
        Identity
    }
}
