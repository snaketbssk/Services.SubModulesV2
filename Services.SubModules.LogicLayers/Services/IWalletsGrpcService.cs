using Services.SubModules.LogicLayers.Models.Mappings;
using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Services
{
    public interface IWalletsGrpcService
    {
        /// <summary>
        /// Creates a user order for a wallet transaction using the specified mapping.
        /// </summary>
        /// <param name="mapping">The mapping containing the user transaction information.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation. A tuple indicating success and the IdGrpcModel of the created order.</returns>
        Task<(bool isSuccessful, IdGrpcModel?)> CreateUserOrderAsync(IMapping<UserTransactionWalletsGrpcRequest> mapping, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a wallet order for a wallet transaction using the specified mapping.
        /// </summary>
        /// <param name="mapping">The mapping containing the wallet transaction information.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation. A tuple indicating success and the IdGrpcModel of the created order.</returns>
        Task<(bool isSuccessful, IdGrpcModel?)> CreateWalletOrderAsync(IMapping<WalletTransactionWalletsGrpcRequest> mapping, CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Credits a user's wallet with the specified amount using the provided mapping.
        /// </summary>
        /// <param name="mapping">The mapping containing the user transaction information.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation. A tuple indicating success and the IdGrpcModel of the transaction.</returns>
        Task<(bool isSuccessful, IdGrpcModel?)> CreditUserAsync(IMapping<UserTransactionWalletsGrpcRequest> mapping, CancellationToken cancellationToken = default);

        /// <summary>
        /// Credits a wallet with the specified amount using the provided mapping.
        /// </summary>
        /// <param name="mapping">The mapping containing the wallet transaction information.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation. A tuple indicating success and the IdGrpcModel of the transaction.</returns>
        Task<(bool isSuccessful, IdGrpcModel?)> CreditWalletAsync(IMapping<WalletTransactionWalletsGrpcRequest> mapping, CancellationToken cancellationToken = default);

        /// <summary>
        /// Debits a user's wallet with the specified amount using the provided mapping.
        /// </summary>
        /// <param name="mapping">The mapping containing the user transaction information.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation. A tuple indicating success and the IdGrpcModel of the transaction.</returns>
        Task<(bool isSuccessful, IdGrpcModel?)> DebitUserAsync(IMapping<UserTransactionWalletsGrpcRequest> mapping, CancellationToken cancellationToken = default);

        /// <summary>
        /// Debits a wallet with the specified amount using the provided mapping.
        /// </summary>
        /// <param name="mapping">The mapping containing the wallet transaction information.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation. A tuple indicating success and the IdGrpcModel of the transaction.</returns>
        Task<(bool isSuccessful, IdGrpcModel?)> DebitWalletAsync(IMapping<WalletTransactionWalletsGrpcRequest> mapping, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates the state of a wallet transaction using the specified mapping.
        /// </summary>
        /// <param name="mapping">The mapping containing the transaction update information.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation. True if the state was updated successfully; otherwise, false.</returns>
        Task<bool> UpdateStateAsync(IMapping<UpdateTransactionWalletsGrpcRequest> mapping, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates the state of a wallet order transaction using the specified mapping.
        /// </summary>
        /// <param name="mapping">The mapping containing the transaction update information.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation. True if the state was updated successfully; otherwise, false.</returns>
        Task<bool> UpdateStateOrderAsync(IMapping<UpdateTransactionWalletsGrpcRequest> mapping, CancellationToken cancellationToken = default);
    }
}
