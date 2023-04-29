using Services.SubModules.DataLayers.Models.Tables.Entities;

namespace Services.SubModules.LogicLayers.Models.Responses.Entities
{
    public class CountryResponse : BaseTable<Guid>, ICountryResponse
    {
        public string? Name { get; set; }

        public string? Iso2 { get; set; }

        public string? Iso3 { get; set; }
    }
}
