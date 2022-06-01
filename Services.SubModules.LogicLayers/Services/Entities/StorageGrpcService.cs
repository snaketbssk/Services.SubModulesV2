using Microsoft.Extensions.Logging;
using Services.SubModules.Configurations.Entities;
using Services.SubModules.Configurations.Models.Roots.Entities;
using Services.SubModules.LogicLayers.Models.Mappings;
using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    public class StorageGrpcService : GrpcService, IStorageGrpcService
    {
        private readonly ILogger<StorageGrpcService> _logger;
        public StorageGrpcService(
            ITokenService tokenService,
            ILogger<StorageGrpcService> logger)
            : base(GrpcConfiguration<GrpcRoot>.Instance.Root.StorageUrlGrpc, tokenService)
        {
            _logger = logger;
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
                _logger.LogError(exception.StackTrace);
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
                _logger.LogError(exception.StackTrace);
                var result = new StorageFilesGrpcResponse();
                return result;
            }
        }
    }
}
