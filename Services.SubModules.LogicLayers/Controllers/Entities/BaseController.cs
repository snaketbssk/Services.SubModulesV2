using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.SubModules.LogicLayers.Constants;

namespace Services.SubModules.LogicLayers.Controllers.Entities
{
    /// <summary>
    /// Base controller for all controllers in the application.
    /// Provides common behavior such as authentication and routing.
    /// </summary>
    [ApiController]
    [Route(RouteConstant.CONTROLLER)]  // The route for all actions in controllers derived from this base controller
    [Authorize(AuthenticationSchemes = SchemeConstant.DEFAULT)]  // Enforces authentication using the specified scheme
    public class BaseController : ControllerBase
    {
        // Common behavior or properties for derived controllers can be added here
    }
}
