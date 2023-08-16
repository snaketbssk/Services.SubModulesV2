using Microsoft.AspNetCore.Http;
using Services.SubModules.LogicLayers.Models.Authentication.Entities;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    /// <summary>
    /// Base service class providing access to HttpContext and user authentication.
    /// </summary>
    public abstract class BaseService : IService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Initializes a new instance of the BaseService class.
        /// </summary>
        /// <param name="httpContextAccessor">The IHttpContextAccessor used to access the HttpContext.</param>
        protected BaseService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        private HttpContext _httpContext;

        /// <summary>
        /// Gets the current HttpContext.
        /// </summary>
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

        /// <summary>
        /// Gets the current HttpResponse.
        /// </summary>
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

        /// <summary>
        /// Gets the current HttpRequest.
        /// </summary>
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

        private UserAuthentication _userAuthentication;

        /// <summary>
        /// Gets the user authentication information for the current user.
        /// </summary>
        public UserAuthentication UserAuthentication
        {
            get
            {
                if (_userAuthentication is null)
                {
                    ArgumentNullException.ThrowIfNull(_httpContextAccessor?.HttpContext?.User);
                    _userAuthentication = new UserAuthentication(_httpContextAccessor.HttpContext.User);
                }

                return _userAuthentication;
            }
        }
    }
}
