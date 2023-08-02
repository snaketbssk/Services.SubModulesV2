namespace Services.SubModules.LogicLayers.Models.Responses.Entities
{
    public class LabelResponse : ILabelResponse
    {
        public string? Label { get; set; }
        public string? Value { get; set; }

        public LabelResponse()
        {

        }

        public LabelResponse(string? label, string? value)
        {
            Label = label;
            Value = value;
        }
    }
}
