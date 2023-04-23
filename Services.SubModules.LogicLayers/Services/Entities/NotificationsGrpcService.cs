using Services.SubModules.Configurations.Entities.Environments;
using Services.SubModules.Configurations.Models.Roots.Entities.Environments;
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
                                        : base(GrpcEnvironmentConfiguration<GrpcEnvironmentRoot>.Instance.GetRoot().NOTIFICATIONS_HOST, tokenService)
        {
            _exceptionService = exceptionService;
        }
        public async Task<bool> AddSuccessNotificationAsync(IMapping<AddSuccessNotificationsGrpcRequest> mapping, CancellationToken cancellationToken = default)
        {
            try
            {
                var client = new NotificationsGrpc.NotificationsGrpcClient(GrpcChannel);
                var request = mapping.Map();
                var headers = GetHeaders();
                var deadline = GetDeadline();
                var result = await client.AddSuccessNotificationAsync(request: request,
                                                                      headers: headers,
                                                                      deadline: deadline,
                                                                      cancellationToken);
                return true;
            }
            catch (Exception exception)
            {
                await _exceptionService.ExecuteAsync(method: nameof(NotificationsGrpcService),
                                                     path: nameof(AddSuccessNotificationAsync),
                                                     exception: exception,
                                                     cancellationToken);
                return false;
            }
        }

        public async Task<bool> AddWarningNotificationAsync(IMapping<AddWarningNotificationsGrpcRequest> mapping, CancellationToken cancellationToken = default)
        {
            try
            {
                var client = new NotificationsGrpc.NotificationsGrpcClient(GrpcChannel);
                var request = mapping.Map();
                var headers = GetHeaders();
                var deadline = GetDeadline();
                var result = await client.AddWarningNotificationAsync(request: request,
                                                                      headers: headers,
                                                                      deadline: deadline,
                                                                      cancellationToken);
                return true;
            }
            catch (Exception exception)
            {
                await _exceptionService.ExecuteAsync(method: nameof(NotificationsGrpcService),
                                                     path: nameof(AddWarningNotificationAsync),
                                                     exception: exception,
                                                     cancellationToken);
                return false;
            }
        }

        public async Task<bool> AddErrorNotificationAsync(IMapping<AddErrorNotificationsGrpcRequest> mapping, CancellationToken cancellationToken = default)
        {
            try
            {
                var client = new NotificationsGrpc.NotificationsGrpcClient(GrpcChannel);
                var request = mapping.Map();
                var headers = GetHeaders();
                var deadline = GetDeadline();
                var result = await client.AddErrorNotificationAsync(request: request,
                                                                    headers: headers,
                                                                    deadline: deadline,
                                                                    cancellationToken);
                return true;
            }
            catch (Exception exception)
            {
                await _exceptionService.ExecuteAsync(method: nameof(NotificationsGrpcService),
                                                     path: nameof(AddErrorNotificationAsync),
                                                     exception: exception,
                                                     cancellationToken);
                return false;
            }
        }
    }
}
