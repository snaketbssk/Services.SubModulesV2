using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Services.SubModules.LogicLayers.Models.Requests.Entities
{
    public class PaginationRequest : IPaginationRequest
    {
        [DefaultValue(1)]
        [Range(1, int.MaxValue)]
        public int NumberPage { get; set; }

        [DefaultValue(100)]
        [Range(1, int.MaxValue)]
        public int SizePage { get; set; }

        public bool? FirstRequest { get; set; }

        public bool? OrderByDescending { get; set; }

        public bool? RandomOrderBy { get; set; }

        public string? PropertyOrderBy { get; set; }

        public int Skip()
        {
            var result = (NumberPage - 1) * SizePage;
            return result;
        }

        public static IPaginationRequest CreateDefault(int? numberPage = default,
                                                       int? sizePage = default,
                                                       bool? firstRequest = default,
                                                       bool? orderByDescending = default,
                                                       bool? randomOrderBy = default,
                                                       string? propertyOrderBy = default)
        {
            var request = new PaginationRequest()
            {
                NumberPage = 1,
                SizePage = 1,
                FirstRequest = false,
                OrderByDescending = false,
                RandomOrderBy = false,
                PropertyOrderBy = "Id"
            };

            if (numberPage.HasValue)
                request.NumberPage = numberPage.Value;
            if (sizePage.HasValue)
                request.SizePage = sizePage.Value;
            if (firstRequest.HasValue)
                request.FirstRequest = firstRequest.Value;
            if (orderByDescending.HasValue)
                request.OrderByDescending = orderByDescending.Value;
            if (randomOrderBy.HasValue)
                request.RandomOrderBy = randomOrderBy.Value;
            if (!string.IsNullOrEmpty(propertyOrderBy))
                request.PropertyOrderBy = propertyOrderBy;

            return request;
        }
    }
}
