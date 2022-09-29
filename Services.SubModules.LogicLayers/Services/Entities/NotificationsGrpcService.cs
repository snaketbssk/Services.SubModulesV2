using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Services.SubModules.Configurations.Entities;
using Services.SubModules.Configurations.Models.Roots.Entities;
using Services.SubModules.LogicLayers.Models.Mappings;
using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    public class NotificationsGrpcService : GrpcService, INotificationsGrpcService
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IExceptionService _exceptionService;

        public NotificationsGrpcService(IExceptionService exceptionService,
                                        ITokenService tokenService)
                                        : base(GrpcConfiguration<GrpcRoot>.Instance.Root.IdentityUrlGrpc, tokenService)
        {
            _exceptionService = exceptionService;
        }
        public async Task<EmptyNotificationsGrpcResponse> ExecuteAsync(IMapping<AddSuccessNotificationsGrpcRequest> mapping, CancellationToken cancellationToken = default)
        {
            try
            {
                var client = new NotificationsGrpc.NotificationsGrpcClient(GrpcChannel);
                var request = mapping.Map();
                var result = await client.AddSuccessNotificationAsync(
                    request: request,
                    headers: GetHeaders(),
                    deadline: GetDeadline(),
                    cancellationToken);
                return result;
            }
            catch (Exception exception)
            {
                await _exceptionService.ExecuteAsync(
                    method: "NotificationsGrpcService",
                    path: "AddSuccessNotificationAsync",
                    exception: exception,
                    cancellationToken);
                var result = new EmptyNotificationsGrpcResponse
                {
                    IsSuccess = false
                };
                return result;
            }
        }

        public async Task<EmptyNotificationsGrpcResponse> ExecuteAsync(IMapping<AddWarningNotificationsGrpcRequest> mapping, CancellationToken cancellationToken = default)
        {
            try
            {
                var client = new NotificationsGrpc.NotificationsGrpcClient(GrpcChannel);
                var request = mapping.Map();
                var result = await client.AddWarningNotificationAsync(
                    request: request,
                    headers: GetHeaders(),
                    deadline: GetDeadline(),
                    cancellationToken);
                return result;
            }
            catch (Exception exception)
            {
                await _exceptionService.ExecuteAsync(
                    method: "NotificationsGrpcService",
                    path: "AddWarningNotificationAsync",
                    exception: exception,
                    cancellationToken);
                var result = new EmptyNotificationsGrpcResponse
                {
                    IsSuccess = false
                };
                return result;
            }
        }

        public async Task<EmptyNotificationsGrpcResponse> ExecuteAsync(IMapping<AddErrorNotificationsGrpcRequest> mapping, CancellationToken cancellationToken = default)
        {
            try
            {
                var client = new NotificationsGrpc.NotificationsGrpcClient(GrpcChannel);
                var request = mapping.Map();
                var result = await client.AddErrorNotificationAsync(
                    request: request,
                    headers: GetHeaders(),
                    deadline: GetDeadline(),
                    cancellationToken);
                return result;
            }
            catch (Exception exception)
            {
                await _exceptionService.ExecuteAsync(
                    method: "NotificationsGrpcService",
                    path: "AddErrorNotificationAsync",
                    exception: exception,
                    cancellationToken);
                var result = new EmptyNotificationsGrpcResponse
                {
                    IsSuccess = false
                };
                return result;
            }
        }
    }
}
