using System.ComponentModel.DataAnnotations;

namespace Services.SubModules.LogicLayers.Models.Requests.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class PhoneRequest : IPhoneRequest
    {
        [StringLength(255, MinimumLength = 1)]
        public string Phone { get; set; }
    }
}
