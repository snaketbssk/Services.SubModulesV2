namespace Services.SubModules.LogicLayers.Models.Responses.Entities
{
    public class ClaimResponse : IClaimResponse
    {
        public string Type { get; set; }
        public string Value { get; set; }

        public ClaimResponse()
        {
        }

        public ClaimResponse(string type, string value)
        {
            Type = type;
            Value = value;
        }
    }
}
