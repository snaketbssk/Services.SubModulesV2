using Services.SubModules.LogicLayers.Models.Mappings;
using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Services
{
    public interface IWalletsGrpcService
    {
        Task<(bool isSuccessful, IdGrpcModel?)> CreditUserAsync(IMapping<UserTransactionWalletsGrpcRequest> mapping, CancellationToken cancellationToken = default);
        Task<(bool isSuccessful, IdGrpcModel?)> CreditWalletAsync(IMapping<WalletTransactionWalletsGrpcRequest> mapping, CancellationToken cancellationToken = default);
        Task<(bool isSuccessful, IdGrpcModel?)> DebitUserAsync(IMapping<UserTransactionWalletsGrpcRequest> mapping, CancellationToken cancellationToken = default);
        Task<(bool isSuccessful, IdGrpcModel?)> DebitWalletAsync(IMapping<WalletTransactionWalletsGrpcRequest> mapping, CancellationToken cancellationToken = default);
        Task<(bool isSuccessful, IdGrpcModel?)> InstantlyUserAsync(IMapping<UserTransactionWalletsGrpcRequest> mapping, CancellationToken cancellationToken = default);
        Task<(bool isSuccessful, IdGrpcModel?)> InstantlyWalletAsync(IMapping<WalletTransactionWalletsGrpcRequest> mapping, CancellationToken cancellationToken = default);
    }
}
