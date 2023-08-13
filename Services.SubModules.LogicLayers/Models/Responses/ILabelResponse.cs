namespace Services.SubModules.LogicLayers.Models.Responses
{
    /// <summary>
    /// Represents a response interface containing a label and its associated value.
    /// </summary>
    public interface ILabelResponse
    {
        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        string? Label { get; set; }

        /// <summary>
        /// Gets or sets the value associated with the label.
        /// </summary>
        string? Value { get; set; }
    }
}
