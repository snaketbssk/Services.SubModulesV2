using Services.SubModules.LogicLayers.Models.Mappings;
using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Services
{
    public interface IWalletsGrpcService
    {
        Task<(bool isSuccessful, TransactionWalletsGrpcResponse?)> CreditWalletAsync(IMapping<WalletTransactionWalletsGrpcRequest> mapping, CancellationToken cancellationToken = default);
        Task<(bool isSuccessful, TransactionWalletsGrpcResponse?)> DebitWalletAsync(IMapping<WalletTransactionWalletsGrpcRequest> mapping, CancellationToken cancellationToken = default);
    }
}
