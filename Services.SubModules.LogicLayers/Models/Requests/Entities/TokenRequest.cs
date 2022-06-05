using System.ComponentModel.DataAnnotations;

namespace Services.SubModules.LogicLayers.Models.Requests.Entities
{
    public class TokenRequest : ITokenRequest
    {
        [StringLength(255, MinimumLength = 1)]
        public string Token { get; set; }
    }
}
