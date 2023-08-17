using Services.SubModules.LogicLayers.Models.Mappings;
using Services.SubModules.Protos;
using System.Threading;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.Services
{
    /// <summary>
    /// Represents a service for managing storage-related gRPC operations.
    /// </summary>
    public interface IStorageGrpcService
    {
        /// <summary>
        /// Sends a single file using the specified mapping.
        /// </summary>
        /// <param name="mapping">The mapping containing the file information.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation. A tuple indicating success and the StorageFileGrpcResponse.</returns>
        Task<(bool isSuccessful, StorageFileGrpcResponse?)> SendFileAsync(IMapping<StorageFileGrpcRequest> mapping, CancellationToken cancellationToken = default);

        /// <summary>
        /// Sends multiple files using the specified mapping.
        /// </summary>
        /// <param name="mapping">The mapping containing the files information.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation. A tuple indicating success and the StorageFilesGrpcResponse.</returns>
        Task<(bool isSuccessful, StorageFilesGrpcResponse?)> SendFilesAsync(IMapping<StorageFilesGrpcRequest> mapping, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a list of files using the specified mapping.
        /// </summary>
        /// <param name="mapping">The mapping containing the query information.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation. A tuple indicating success and the StorageReadFilesGrpcResponse.</returns>
        Task<(bool isSuccessful, StorageReadFilesGrpcResponse?)> GetFilesAsync(IMapping<StorageReadFilesGrpcRequest> mapping, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a single file using the specified mapping.
        /// </summary>
        /// <param name="mapping">The mapping containing the query information.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation. A tuple indicating success and the StorageReadFileGrpcResponse.</returns>
        Task<(bool isSuccessful, StorageReadFileGrpcResponse?)> GetFileAsync(IMapping<StorageReadFileGrpcRequest> mapping, CancellationToken cancellationToken = default);
    }
}
