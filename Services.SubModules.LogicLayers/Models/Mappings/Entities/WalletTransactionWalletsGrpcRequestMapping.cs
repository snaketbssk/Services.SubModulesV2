using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    public class WalletTransactionWalletsGrpcRequestMapping : Mapping<WalletTransactionWalletsGrpcRequest>
    {
        public decimal Amount { get; set; }

        public string? Description { get; set; }

        public Guid WalletId { get; set; }

        public string? Reference { get; set; }

        public WalletTransactionWalletsGrpcRequestMapping(decimal amount,
                                                          string? description,
                                                          Guid walletId,
                                                          string? reference)
        {
            Amount = amount;
            Description = description;
            WalletId = walletId;
            Reference = reference;
        }

        public override WalletTransactionWalletsGrpcRequest Map()
        {
            var result = new WalletTransactionWalletsGrpcRequest()
            {
                Amount = Amount,
                Description = Description,
                Reference = Reference,
                WalletId = WalletId.ToString(),
            };

            return result;
        }

        public override WalletTransactionWalletsGrpcRequest Update(WalletTransactionWalletsGrpcRequest result)
        {
            throw new NotImplementedException();
        }
    }
}
