namespace Services.SubModules.LogicLayers.Models.Responses.Entities
{
    /// <summary>
    /// Represents a response containing information about an enum value.
    /// </summary>
    public class EnumResponse : IEnumResponse
    {
        /// <summary>
        /// Gets or sets the ID of the enum value.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the label of the enum value.
        /// </summary>
        public string? Label { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumResponse"/> class.
        /// </summary>
        /// <param name="id">The ID of the enum value.</param>
        /// <param name="label">The label of the enum value.</param>
        public EnumResponse(int id, string? label)
        {
            Id = id;
            Label = label;
        }

        /// <summary>
        /// Creates an <see cref="EnumResponse"/> instance from an enum value.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="value">The enum value.</param>
        /// <returns>An <see cref="EnumResponse"/> instance.</returns>
        public static EnumResponse FromEnum<TEnum>(TEnum value) where TEnum : Enum
        {
            var id = Convert.ToInt32(value);
            var result = new EnumResponse(id, value.ToString());
            return result;
        }
    }
}
