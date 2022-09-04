using Services.SubModules.LogicLayers.Models.Mappings;
using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Services
{
    public interface IStorageGrpcService
    {
        Task<StorageFileGrpcResponse> ExecuteAsync(IMapping<StorageFileGrpcRequest> mapping, CancellationToken cancellationToken = default);
        Task<StorageFilesGrpcResponse> ExecuteAsync(IMapping<StorageFilesGrpcRequest> mapping, CancellationToken cancellationToken = default);
        Task<StorageReadFilesGrpcResponse> ExecuteAsync(IMapping<StorageReadFilesGrpcRequest> mapping, CancellationToken cancellationToken = default);
        Task<StorageReadFileGrpcResponse> ExecuteAsync(IMapping<StorageReadFileGrpcRequest> mapping, CancellationToken cancellationToken = default);
    }
}
