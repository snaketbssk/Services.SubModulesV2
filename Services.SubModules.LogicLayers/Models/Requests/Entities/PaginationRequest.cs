using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Services.SubModules.LogicLayers.Models.Requests.Entities
{
    public class PaginationRequest : IPaginationRequest
    {
        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        public int NumberPage { get; set; }

        [DefaultValue(100)]
        [Range(1, int.MaxValue)]
        public int SizePage { get; set; }

        public bool? FirstRequest { get; set; }

        public bool? OrderByDescending { get; set; }

        public string? PropertyOrderBy { get; set; }

        public int Skip()
        {
            var result = NumberPage * SizePage;
            return result;
        }
    }
}
