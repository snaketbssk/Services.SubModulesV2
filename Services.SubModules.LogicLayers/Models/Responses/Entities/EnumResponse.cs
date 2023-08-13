namespace Services.SubModules.LogicLayers.Models.Responses.Entities
{
    public class EnumResponse : IEnumResponse
    {
        public int Id { get; set; }
        public string? Label { get; set; }

        public EnumResponse(int id, string? label)
        {
            Id = id;
            Label = label;
        }

        public static EnumResponse FromEnum<TEnum>(TEnum value) where TEnum : Enum
        {
            var id = Convert.ToInt32(value);
            var result = new EnumResponse(id, value.ToString());
            return result;
        }
    }
}
