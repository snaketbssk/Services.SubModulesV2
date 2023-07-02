namespace Services.SubModules.DataLayers.Models.Requests.Entities
{
    public class ParameterSqlRequest : IParameterSqlRequest
    {
        public string Key { get; set; }
        public object Value { get; set; }

        public ParameterSqlRequest(string key, object value)
        {
            Key = key;
            Value = value;
        }
    }
}
