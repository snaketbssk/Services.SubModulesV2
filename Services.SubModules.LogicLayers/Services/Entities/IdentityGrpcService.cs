﻿using Microsoft.Extensions.Logging;
using Services.SubModules.Configurations.Entities;
using Services.SubModules.Configurations.Models.Roots.Entities;
using Services.SubModules.LogicLayers.Models.Mappings;
using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    public class IdentityGrpcService : GrpcService, IIdentityGrpcService
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly ILogger<IdentityGrpcService> _logger;

        /// <summary>
        /// 
        /// </summary>
        private readonly IExceptionService _exceptionService;

        public IdentityGrpcService(
            IExceptionService exceptionService,
            ITokenService tokenService,
            ILogger<IdentityGrpcService> logger)
            : base(GrpcConfiguration<GrpcRoot>.Instance.Root.IdentityUrlGrpc, tokenService)
        {
            _logger = logger;
            _exceptionService = exceptionService;
        }
        public async Task<UserIdentityGrpcResponse> ExecuteAsync(IMapping<UserIdentityGrpcRequest> mapping, CancellationToken cancellationToken = default)
        {
            try
            {
                var client = new IdentityGrpc.IdentityGrpcClient(GrpcChannel);
                var request = mapping.Map();
                var result = await client.GetUserAsync(
                    request: request,
                    headers: GetHeaders(),
                    deadline: GetDeadline(),
                    cancellationToken);
                return result;
            }
            catch (Exception exception)
            {
                await _exceptionService.ExecuteAsync(
                    method: "IdentityGrpcService",
                    path: "GetUserAsync",
                    exception: exception, 
                    cancellationToken);
                var result = new UserIdentityGrpcResponse
                {
                    IsSuccess = false
                };
                return result;
            }
        }
    }
}
