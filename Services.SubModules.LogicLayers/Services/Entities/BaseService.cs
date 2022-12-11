﻿using Microsoft.AspNetCore.Http;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    public abstract class BaseService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        protected HttpRequest _httpRequest => _httpContextAccessor?.HttpContext?.Request;

        protected BaseService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
    }
}