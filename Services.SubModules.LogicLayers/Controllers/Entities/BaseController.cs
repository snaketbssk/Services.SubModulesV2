using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.SubModules.LogicLayers.Constants;

namespace Services.SubModules.LogicLayers.Controllers.Entities
{
    [ApiController]
    [Route(RouteConstant.CONTROLLER)]
    [Authorize(AuthenticationSchemes = SchemeConstant.DEFAULT)]
    public class BaseController : ControllerBase
    {
    }
}
