namespace Services.SubModules.LogicLayers.Models.Requests
{
    public interface IPaginationRequest
    {
        int NumberPage { get; set; }
        int SizePage { get; set; }
        bool? OrderByDescending { get; set; }
        string? PropertyOrderBy { get; set; }
        bool? FirstRequest { get; set; }

        int Skip();
    }
}
