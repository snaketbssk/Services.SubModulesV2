using Microsoft.Extensions.Logging;
using Services.SubModules.Configurations.Entities.Environments;
using Services.SubModules.Configurations.Models.Roots.Entities.Environments;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    public class CommonGrpcService : GrpcService, ICommonGrpcService
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly ILogger<CommonGrpcService> _logger;

        /// <summary>
        /// 
        /// </summary>
        private readonly IExceptionService _exceptionService;

        public CommonGrpcService(
            IExceptionService exceptionService,
            ITokenService tokenService,
            ILogger<CommonGrpcService> logger)
            : base(GrpcEnvironmentConfiguration<GrpcEnvironmentRoot>.Instance.GetRoot().COMMON_HOST, tokenService)
        {
            _logger = logger;
            _exceptionService = exceptionService;
        }
    }
}
