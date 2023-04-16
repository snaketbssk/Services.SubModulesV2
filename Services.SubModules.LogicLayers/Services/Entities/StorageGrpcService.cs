using Microsoft.Extensions.Logging;
using Services.SubModules.Configurations.Entities.Environments;
using Services.SubModules.Configurations.Models.Roots.Entities.Environments;
using Services.SubModules.LogicLayers.Models.Mappings;
using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    public class StorageGrpcService : GrpcService, IStorageGrpcService
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly ILogger<StorageGrpcService> _logger;

        /// <summary>
        /// 
        /// </summary>
        private readonly IExceptionService _exceptionService;

        public StorageGrpcService(
            IExceptionService exceptionService,
            ITokenService tokenService,
            ILogger<StorageGrpcService> logger)
            : base(GrpcEnvironmentConfiguration<GrpcEnvironmentRoot>.Instance.GetRoot().STORAGE_HOST, tokenService)
        {
            _logger = logger;
            _exceptionService = exceptionService;
        }
        public async Task<(bool isSuccessful, StorageFileGrpcResponse?)> SendFileAsync(IMapping<StorageFileGrpcRequest> mapping, CancellationToken cancellationToken = default)
        {
            try
            {
                var client = new StorageGrpc.StorageGrpcClient(GrpcChannel);
                var request = mapping.Map();
                var result = await client.SendFileAsync(request: request,
                                                        headers: GetHeaders(),
                                                        deadline: GetDeadline(),
                                                        cancellationToken);
                return (true, result);
            }
            catch (Exception exception)
            {
                await _exceptionService.ExecuteAsync(method: "StorageGrpcService",
                                                     path: "SendFileAsync",
                                                     exception: exception,
                                                     cancellationToken);
                return (false, default);
            }
        }
        public async Task<(bool isSuccessful, StorageFilesGrpcResponse?)> SendFilesAsync(IMapping<StorageFilesGrpcRequest> mapping, CancellationToken cancellationToken = default)
        {
            try
            {
                var client = new StorageGrpc.StorageGrpcClient(GrpcChannel);
                var request = mapping.Map();
                var result = await client.SendFilesAsync(request: request,
                                                         headers: GetHeaders(),
                                                         deadline: GetDeadline(),
                                                         cancellationToken);
                return (true, result);
            }
            catch (Exception exception)
            {
                await _exceptionService.ExecuteAsync(method: "StorageGrpcService",
                                                     path: "SendFilesAsync",
                                                     exception: exception,
                                                     cancellationToken);
                return (false, default);
            }
        }

        public async Task<(bool isSuccessful, StorageReadFileGrpcResponse?)> GetFileAsync(IMapping<StorageReadFileGrpcRequest> mapping, CancellationToken cancellationToken = default)
        {
            try
            {
                var client = new StorageGrpc.StorageGrpcClient(GrpcChannel);
                var request = mapping.Map();
                var result = await client.GetFileAsync(request: request,
                                                       headers: GetHeaders(),
                                                       deadline: GetDeadline(),
                                                       cancellationToken);
                return (true, result);
            }
            catch (Exception exception)
            {
                await _exceptionService.ExecuteAsync(method: "StorageGrpcService",
                                                     path: "GetFileAsync",
                                                     exception: exception,
                                                     cancellationToken);
                return (false, default);
            }
        }

        public async Task<(bool isSuccessful, StorageReadFilesGrpcResponse?)> GetFilesAsync(IMapping<StorageReadFilesGrpcRequest> mapping, CancellationToken cancellationToken = default)
        {
            try
            {
                var client = new StorageGrpc.StorageGrpcClient(GrpcChannel);
                var request = mapping.Map();
                var result = await client.GetFilesAsync(request: request,
                                                        headers: GetHeaders(),
                                                        deadline: GetDeadline(),
                                                        cancellationToken);
                return (true, result);
            }
            catch (Exception exception)
            {
                await _exceptionService.ExecuteAsync(method: "StorageGrpcService",
                                                     path: "GetFilesAsync",
                                                     exception: exception,
                                                     cancellationToken);
                return (false, default);
            }
        }
    }
}
