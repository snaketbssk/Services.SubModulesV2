using System.Security.Claims;

namespace Services.SubModules.LogicLayers.Constants
{
    public static class ClaimConstant
    {
        public const string ID = ClaimTypes.NameIdentifier;
        public const string NAME = "name";
        public const string EMAIL = ClaimTypes.Email;
        public const string ROLE = ClaimTypes.Role;
        public const string LANGUAGE = "language";
        public const string ACCESS_TOKEN = "access_token";
        public const string SESSION_ID = "session_id";
    }
}
