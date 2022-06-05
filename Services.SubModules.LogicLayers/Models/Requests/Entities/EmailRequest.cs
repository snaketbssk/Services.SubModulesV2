using System.ComponentModel.DataAnnotations;

namespace Services.SubModules.LogicLayers.Models.Requests.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class EmailRequest : IEmailRequest
    {
        /// <summary>
        /// 
        /// </summary>
        [StringLength(255, MinimumLength = 1)]
        public string Email { get; set; }
    }
}
