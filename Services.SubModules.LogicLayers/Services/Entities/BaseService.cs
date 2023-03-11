using Microsoft.AspNetCore.Http;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    public abstract class BaseService : IService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        private HttpContext _httpContext;

        public HttpContext HttpContext
        {
            get
            {
                if (_httpContext is null)
                {
                    ArgumentNullException.ThrowIfNull(_httpContextAccessor?.HttpContext);
                    _httpContext = _httpContextAccessor.HttpContext;
                }
                
                return _httpContext;
            }
        }

        private HttpResponse _httpResponse;

        public HttpResponse HttpResponse
        {
            get
            {
                if (_httpResponse is null)
                {
                    ArgumentNullException.ThrowIfNull(_httpContextAccessor?.HttpContext?.Response);
                    _httpResponse = _httpContextAccessor.HttpContext.Response;
                }

                return _httpResponse;
            }
        }

        private HttpRequest _httpRequest;

        public HttpRequest HttpRequest
        {
            get
            {
                if (_httpRequest is null)
                {
                    ArgumentNullException.ThrowIfNull(_httpContextAccessor?.HttpContext?.Request);
                    _httpRequest = _httpContextAccessor.HttpContext.Request;
                }

                return _httpRequest;
            }
        }

        protected BaseService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
