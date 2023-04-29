using Services.SubModules.DataLayers.Models.Tables;

namespace Services.SubModules.LogicLayers.Models.Responses
{
    public interface ICountryResponse : IBaseTable<Guid>
    {
        string? Name { get; set; }

        string? Iso2 { get; set; }

        string? Iso3 { get; set; }
    }
}
