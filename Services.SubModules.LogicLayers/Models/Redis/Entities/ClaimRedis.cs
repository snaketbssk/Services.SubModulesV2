namespace Services.SubModules.LogicLayers.Models.Redis.Entities
{
    public class ClaimRedis : IClaimRedis
    {
        public string Type { get; set; }
        public string Value { get; set; }
    }
}
