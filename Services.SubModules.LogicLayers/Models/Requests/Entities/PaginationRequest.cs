using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Services.SubModules.LogicLayers.Models.Requests.Entities
{
    public class PaginationRequest : IPaginationRequest
    {
        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        public int From { get; set; }

        [DefaultValue(100)]
        [Range(0, int.MaxValue)]
        public int To { get; set; }

        public int Take(int max = 100)
        {
            var result = Math.Abs(To - From);
            if (result <= 0)
            {
                return 1;
            }
            if (result > max)
            {
                return max;
            }
            return result;
        }

        public bool FirstRequest { get; set; }

        public bool OrderByDescending { get; set; }

        public string? PropertyOrderBy { get; set; }
    }
}
