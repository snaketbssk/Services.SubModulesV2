namespace Services.SubModules.LogicLayers.Models.Redis
{
    public interface IClaimRedis
    {
        string? Type { get; set; }
        string? Value { get; set; }
    }
}
