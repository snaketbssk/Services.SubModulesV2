using Services.SubModules.DataLayers.Models.Tables.Entities;

namespace Services.SubModules.LogicLayers.Models.Responses.Entities
{
    public class CurrencyResponse : BaseTable<Guid>, ICurrencyResponse
    {
        public string? Code { get; set; }

        public string? Symbol { get; set; }

        public int? Number { get; set; }

        public string? Name { get; set; }

        public bool Enable { get; set; }
    }
}
