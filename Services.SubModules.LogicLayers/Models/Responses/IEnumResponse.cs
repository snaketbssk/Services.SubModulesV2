namespace Services.SubModules.LogicLayers.Models.Responses
{
    /// <summary>
    /// Represents an interface for enumeration response models.
    /// </summary>
    public interface IEnumResponse
    {
        /// <summary>
        /// Gets or sets the identifier of the enumeration.
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Gets or sets the label of the enumeration.
        /// </summary>
        string? Label { get; set; }
    }
}
