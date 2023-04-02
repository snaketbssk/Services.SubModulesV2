using Services.SubModules.DataLayers.Models.Tables;

namespace Services.SubModules.LogicLayers.Models.Responses
{
    public interface ICurrencyResponse : IBaseTable<Guid>
    {
        string? Code { get; set; }

        string? Symbol { get; set; }

        int? Number { get; set; }

        string? Name { get; set; }

        bool Enable { get; set; }
    }
}
