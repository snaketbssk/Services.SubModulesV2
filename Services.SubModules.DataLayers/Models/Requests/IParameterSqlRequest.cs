namespace Services.SubModules.DataLayers.Models.Requests
{
    public interface IParameterSqlRequest
    {
        string Key { get; set; }
        object Value { get; set; }
    }
}
