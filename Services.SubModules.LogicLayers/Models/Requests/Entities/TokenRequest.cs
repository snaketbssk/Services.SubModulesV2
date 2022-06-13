using System.ComponentModel.DataAnnotations;

namespace Services.SubModules.LogicLayers.Models.Requests.Entities
{
    public class TokenRequest : ITokenRequest
    {
        [StringLength(1024, MinimumLength = 1)]
        public string? Token { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TokenRequest()
        {

        }

        public TokenRequest(string token)
        {
            Token = token ?? throw new ArgumentNullException(nameof(token));
        }
    }
}
