namespace Services.SubModules.DataLayers.Models.Requests.Entities
{
    /// <summary>
    /// Represents a parameter for SQL queries.
    /// </summary>
    public class ParameterSqlRequest : IParameterSqlRequest
    {
        /// <summary>
        /// Gets or sets the parameter key.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets the parameter value.
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterSqlRequest"/> class with the specified key and value.
        /// </summary>
        /// <param name="key">The parameter key.</param>
        /// <param name="value">The parameter value.</param>
        public ParameterSqlRequest(string key, object value)
        {
            Key = key;
            Value = value;
        }
    }
}
