using System.ComponentModel.DataAnnotations;

namespace Services.SubModules.LogicLayers.Models.Requests.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class PhoneRequest : IPhoneRequest
    {
        /// <summary>
        /// 
        /// </summary>
        [StringLength(255, MinimumLength = 1)]
        public string? Phone { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public PhoneRequest()
        {

        }

        public PhoneRequest(string phone)
        {
            Phone = phone ?? throw new ArgumentNullException(nameof(phone));
        }
    }
}
