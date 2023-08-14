using Services.SubModules.LogicLayers.Attributes.Entities;
using Services.SubModules.LogicLayers.Constants;

namespace Services.SubModules.LogicLayers.Models.Authentication
{
    /// <summary>
    /// Enumeration representing various groups associated with authentication.
    /// </summary>
    public enum GroupAuthentication
    {
        /// <summary>
        /// Represents a service group.
        /// </summary>
        [Group(GroupConstant.SERVICE)]
        Service,

        /// <summary>
        /// Represents an admin group.
        /// </summary>
        [Group(GroupConstant.ADMIN)]
        Admin,

        /// <summary>
        /// Represents a user group.
        /// </summary>
        [Group(GroupConstant.USER)]
        User,

        /// <summary>
        /// Represents a manager group.
        /// </summary>
        [Group(GroupConstant.MANAGER)]
        Manager,

        /// <summary>
        /// Represents an identity group.
        /// </summary>
        [Group(GroupConstant.IDENTITY)]
        Identity
    }
}
