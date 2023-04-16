using Services.SubModules.LogicLayers.Models.Mappings;
using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Services
{
    public interface IStorageGrpcService
    {
        Task<(bool isSuccessful, StorageFileGrpcResponse?)> SendFileAsync(IMapping<StorageFileGrpcRequest> mapping, CancellationToken cancellationToken = default);
        Task<(bool isSuccessful, StorageFilesGrpcResponse?)> SendFilesAsync(IMapping<StorageFilesGrpcRequest> mapping, CancellationToken cancellationToken = default);
        Task<(bool isSuccessful, StorageReadFilesGrpcResponse?)> GetFilesAsync(IMapping<StorageReadFilesGrpcRequest> mapping, CancellationToken cancellationToken = default);
        Task<(bool isSuccessful, StorageReadFileGrpcResponse?)> GetFileAsync(IMapping<StorageReadFileGrpcRequest> mapping, CancellationToken cancellationToken = default);
    }
}
