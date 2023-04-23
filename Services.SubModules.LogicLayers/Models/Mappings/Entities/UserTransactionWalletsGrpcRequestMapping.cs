using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    public class UserTransactionWalletsGrpcRequestMapping : Mapping<UserTransactionWalletsGrpcRequest>
    {
        public decimal Amount { get; set; }

        public string? Description { get; set; }

        public Guid UserId { get; set; }

        public Guid CurrencyId { get; set; }

        public string? Reference { get; set; }

        public UserTransactionWalletsGrpcRequestMapping(decimal amount,
                                                        string? description,
                                                        Guid userId,
                                                        Guid currencyId,
                                                        string? reference)
        {
            Amount = amount;
            Description = description;
            UserId = userId;
            CurrencyId = currencyId;
            Reference = reference;
        }

        public override UserTransactionWalletsGrpcRequest Map()
        {
            var result = new UserTransactionWalletsGrpcRequest()
            {
                Amount = Amount,
                Description = Description,
                Reference = Reference,
                UserId = UserId.ToString(),
                CurrencyId = CurrencyId.ToString(),
            };

            return result;
        }

        public override UserTransactionWalletsGrpcRequest Update(UserTransactionWalletsGrpcRequest result)
        {
            throw new NotImplementedException();
        }
    }
}
