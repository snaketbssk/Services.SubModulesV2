using Microsoft.AspNetCore.Http;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    public class HttpResponseMapping : Mapping<HttpResponse>
    {
        public string ContentType { get; set; }
        public int StatusCode { get; set; }
        public HttpResponseMapping(string contentType, int statusCode)
        {
            ContentType = contentType ?? throw new ArgumentNullException(nameof(contentType));
            StatusCode = statusCode;
        }
        public override HttpResponse Map()
        {
            throw new NotImplementedException();
        }
        public override HttpResponse Update(HttpResponse result)
        {
            result.StatusCode = StatusCode;
            result.ContentType = ContentType;
            return result;
        }
    }
}
