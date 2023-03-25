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
        public async Task<StorageFileGrpcResponse> ExecuteAsync(IMapping<StorageFileGrpcRequest> mapping, CancellationToken cancellationToken = default)
        {
            try
            {
                var client = new StorageGrpc.StorageGrpcClient(GrpcChannel);
                var request = mapping.Map();
                var result = await client.SendFileAsync(
                    request: request,
                    headers: GetHeaders(),
                    deadline: GetDeadline(),
                    cancellationToken);
                return result;
            }
            catch (Exception exception)
            {
                await _exceptionService.ExecuteAsync(
                    method: "StorageGrpcService",
                    path: "SendFileAsync",
                    exception: exception,
                    cancellationToken);
                var result = new StorageFileGrpcResponse
                {
                    IsSuccess = false
                };
                return result;
            }
        }
        public async Task<StorageFilesGrpcResponse> ExecuteAsync(IMapping<StorageFilesGrpcRequest> mapping, CancellationToken cancellationToken = default)
        {
            try
            {
                var client = new StorageGrpc.StorageGrpcClient(GrpcChannel);
                var request = mapping.Map();
                var result = await client.SendFilesAsync(
                    request: request,
                    headers: GetHeaders(),
                    deadline: GetDeadline(),
                    cancellationToken);
                return result;
            }
            catch (Exception exception)
            {
                await _exceptionService.ExecuteAsync(
                    method: "StorageGrpcService",
                    path: "SendFilesAsync",
                    exception: exception,
                    cancellationToken);
                var result = new StorageFilesGrpcResponse();
                return result;
            }
        }

        public async Task<StorageReadFileGrpcResponse> ExecuteAsync(IMapping<StorageReadFileGrpcRequest> mapping, CancellationToken cancellationToken = default)
        {
            try
            {
                var client = new StorageGrpc.StorageGrpcClient(GrpcChannel);
                var request = mapping.Map();
                var result = await client.GetFileAsync(
                    request: request,
                    headers: GetHeaders(),
                    deadline: GetDeadline(),
                    cancellationToken);
                return result;
            }
            catch (Exception exception)
            {
                await _exceptionService.ExecuteAsync(
                    method: "StorageGrpcService",
                    path: "GetFileAsync",
                    exception: exception,
                    cancellationToken);
                var result = new StorageReadFileGrpcResponse
                {
                    IsSuccess = false
                };
                return result;
            }
        }

        public async Task<StorageReadFilesGrpcResponse> ExecuteAsync(IMapping<StorageReadFilesGrpcRequest> mapping, CancellationToken cancellationToken = default)
        {
            try
            {
                var client = new StorageGrpc.StorageGrpcClient(GrpcChannel);
                var request = mapping.Map();
                var result = await client.GetFilesAsync(
                    request: request,
                    headers: GetHeaders(),
                    deadline: GetDeadline(),
                    cancellationToken);
                return result;
            }
            catch (Exception exception)
            {
                await _exceptionService.ExecuteAsync(
                    method: "StorageGrpcService",
                    path: "GetFilesAsync",
                    exception: exception,
                    cancellationToken);
                var result = new StorageReadFilesGrpcResponse();
                return result;
            }
        }
    }
}
