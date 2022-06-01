using System.Security.Claims;

namespace Services.SubModules.LogicLayers.Constants
{
    public static class ClaimConstant
    {
        public const string ID = ClaimTypes.NameIdentifier;
        public const string NAME = ClaimTypes.Name;
        public const string EMAIL = ClaimTypes.Email;
        public const string ROLE = ClaimTypes.Role;
    }
}
