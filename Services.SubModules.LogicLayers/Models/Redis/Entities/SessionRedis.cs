using Services.SubModules.LogicLayers.Models.Responses.Entities;

namespace Services.SubModules.LogicLayers.Models.Redis.Entities
{
    public class SessionRedis : UserAgentResponse, ISessionRedis
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the creation timestamp.
        /// </summary>
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiredAt { get; set; }
    }
}
