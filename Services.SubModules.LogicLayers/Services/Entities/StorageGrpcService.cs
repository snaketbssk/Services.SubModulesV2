using Microsoft.Extensions.Logging;
using Services.SubModules.Configurations.Entities.Environments;
using Services.SubModules.Configurations.Models.Roots.Entities.Environments;
using Services.SubModules.LogicLayers.Models.Mappings;
using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    /// <summary>
    /// Represents a service for interacting with storage through gRPC.
    /// </summary>
    public class StorageGrpcService : GrpcService, IStorageGrpcService
    {
        private readonly ILogger<StorageGrpcService> _logger;
        private readonly IExceptionService _exceptionService;

        /// <summary>
        /// Initializes a new instance of the StorageGrpcService class.
        /// </summary>
        /// <param name="exceptionService">The service for handling exceptions.</param>
        /// <param name="tokenService">The token service for authentication.</param>
        /// <param name="logger">The logger instance for capturing logs.</param>
        public StorageGrpcService(
            IExceptionService exceptionService,
            ITokenService tokenService,
            ILogger<StorageGrpcService> logger)
            : base(GrpcEnvironmentConfiguration<GrpcEnvironmentRoot>.Instance.GetRoot().STORAGE_HOST, tokenService)
        {
            _logger = logger;
            _exceptionService = exceptionService;
        }

        /// <summary>
        /// Sends a single file through gRPC asynchronously.
        /// </summary>
        /// <param name="mapping">The mapping that defines the file to be sent.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation if needed.</param>
        /// <returns>A tuple indicating whether the operation was successful and the response received.</returns>
        public async Task<(bool isSuccessful, StorageFileGrpcResponse?)> SendFileAsync(IMapping<StorageFileGrpcRequest> mapping, CancellationToken cancellationToken = default)
        {
            try
            {
                // Create a gRPC client instance for the Storage service.
                var client = new StorageGrpc.StorageGrpcClient(GrpcChannel);

                // Map the provided request data using the given mapping.
                var request = mapping.Map();

                // Get the headers for the request.
                var headers = GetHeaders();

                // Get the deadline for the request.
                var deadline = GetDeadline();

                // Send the file request using the gRPC client.
                var result = await client.SendFileAsync(request: request,
                                                        headers: headers,
                                                        deadline: deadline,
                                                        cancellationToken);

                // Return a tuple indicating success and the received response.
                return (true, result);
            }
            catch (Exception exception)
            {
                // If an exception occurs, log it and return a tuple indicating failure.
                await _exceptionService.ExecuteAsync(method: nameof(StorageGrpcService),
                                                     path: nameof(SendFileAsync),
                                                     exception: exception,
                                                     cancellationToken);
                return (false, default);
            }
        }

        /// <summary>
        /// Sends multiple files through gRPC asynchronously.
        /// </summary>
        /// <param name="mapping">The mapping that defines the files to be sent.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation if needed.</param>
        /// <returns>A tuple indicating whether the operation was successful and the response received.</returns>
        public async Task<(bool isSuccessful, StorageFilesGrpcResponse?)> SendFilesAsync(IMapping<StorageFilesGrpcRequest> mapping, CancellationToken cancellationToken = default)
        {
            try
            {
                // Create a gRPC client instance for the Storage service.
                var client = new StorageGrpc.StorageGrpcClient(GrpcChannel);

                // Map the provided request data using the given mapping.
                var request = mapping.Map();

                // Get the headers for the request.
                var headers = GetHeaders();

                // Get the deadline for the request.
                var deadline = GetDeadline();

                // Send the files request using the gRPC client.
                var result = await client.SendFilesAsync(request: request,
                                                         headers: headers,
                                                         deadline: deadline,
                                                         cancellationToken);

                // Return a tuple indicating success and the received response.
                return (true, result);
            }
            catch (Exception exception)
            {
                // If an exception occurs, log it and return a tuple indicating failure.
                await _exceptionService.ExecuteAsync(method: nameof(StorageGrpcService),
                                                     path: nameof(SendFilesAsync),
                                                     exception: exception,
                                                     cancellationToken);
                return (false, default);
            }
        }


        /// <summary>
        /// Retrieves a single file from storage through gRPC asynchronously.
        /// </summary>
        /// <param name="mapping">The mapping that defines the file to be retrieved.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation if needed.</param>
        /// <returns>A tuple indicating whether the operation was successful and the retrieved response.</returns>
        public async Task<(bool isSuccessful, StorageReadFileGrpcResponse?)> GetFileAsync(IMapping<StorageReadFileGrpcRequest> mapping, CancellationToken cancellationToken = default)
        {
            try
            {
                // Create a gRPC client instance for the Storage service.
                var client = new StorageGrpc.StorageGrpcClient(GrpcChannel);

                // Map the provided request data using the given mapping.
                var request = mapping.Map();

                // Get the headers for the request.
                var headers = GetHeaders();

                // Get the deadline for the request.
                var deadline = GetDeadline();

                // Retrieve the file using the gRPC client.
                var result = await client.GetFileAsync(request: request,
                                                       headers: headers,
                                                       deadline: deadline,
                                                       cancellationToken);

                // Return a tuple indicating success and the retrieved response.
                return (true, result);
            }
            catch (Exception exception)
            {
                // If an exception occurs, log it and return a tuple indicating failure.
                await _exceptionService.ExecuteAsync(method: nameof(StorageGrpcService),
                                                     path: nameof(GetFileAsync),
                                                     exception: exception,
                                                     cancellationToken);
                return (false, default);
            }
        }

        /// <summary>
        /// Retrieves multiple files from storage through gRPC asynchronously.
        /// </summary>
        /// <param name="mapping">The mapping that defines the files to be retrieved.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation if needed.</param>
        /// <returns>A tuple indicating whether the operation was successful and the retrieved response.</returns>
        public async Task<(bool isSuccessful, StorageReadFilesGrpcResponse?)> GetFilesAsync(IMapping<StorageReadFilesGrpcRequest> mapping, CancellationToken cancellationToken = default)
        {
            try
            {
                // Create a gRPC client instance for the Storage service.
                var client = new StorageGrpc.StorageGrpcClient(GrpcChannel);

                // Map the provided request data using the given mapping.
                var request = mapping.Map();

                // Get the headers for the request.
                var headers = GetHeaders();

                // Get the deadline for the request.
                var deadline = GetDeadline();

                // Retrieve the files using the gRPC client.
                var result = await client.GetFilesAsync(request: request,
                                                        headers: headers,
                                                        deadline: deadline,
                                                        cancellationToken);

                // Return a tuple indicating success and the retrieved response.
                return (true, result);
            }
            catch (Exception exception)
            {
                // If an exception occurs, log it and return a tuple indicating failure.
                await _exceptionService.ExecuteAsync(method: nameof(StorageGrpcService),
                                                     path: nameof(GetFilesAsync),
                                                     exception: exception,
                                                     cancellationToken);
                return (false, default);
            }
        }

    }
}
