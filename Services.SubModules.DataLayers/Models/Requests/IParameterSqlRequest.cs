namespace Services.SubModules.DataLayers.Models.Requests
{
    /// <summary>
    /// Represents a parameter for SQL requests.
    /// </summary>
    public interface IParameterSqlRequest
    {
        /// <summary>
        /// Gets or sets the parameter key.
        /// </summary>
        string Key { get; set; }

        /// <summary>
        /// Gets or sets the parameter value.
        /// </summary>
        object Value { get; set; }
    }
}
