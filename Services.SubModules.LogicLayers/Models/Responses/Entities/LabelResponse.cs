namespace Services.SubModules.LogicLayers.Models.Responses.Entities
{
    /// <summary>
    /// Represents a response containing a label and its associated value.
    /// </summary>
    public class LabelResponse : ILabelResponse
    {
        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        public string? Label { get; set; }

        /// <summary>
        /// Gets or sets the value associated with the label.
        /// </summary>
        public string? Value { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelResponse"/> class.
        /// </summary>
        public LabelResponse()
        {
            // Default constructor
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelResponse"/> class with the specified label and value.
        /// </summary>
        /// <param name="label">The label to set.</param>
        /// <param name="value">The value to set.</param>
        public LabelResponse(string? label, string? value)
        {
            Label = label;
            Value = value;
        }
    }
}
