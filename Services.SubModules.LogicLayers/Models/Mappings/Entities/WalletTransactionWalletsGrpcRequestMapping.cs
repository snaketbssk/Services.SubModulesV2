using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    /// <summary>
    /// Represents a mapping class for converting data to WalletTransactionWalletsGrpcRequest.
    /// </summary>
    public class WalletTransactionWalletsGrpcRequestMapping : Mapping<WalletTransactionWalletsGrpcRequest>
    {
        /// <summary>
        /// Gets or sets the transaction amount.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the transaction description.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the wallet ID.
        /// </summary>
        public Guid WalletId { get; set; }

        /// <summary>
        /// Gets or sets the transaction reference.
        /// </summary>
        public string? Reference { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WalletTransactionWalletsGrpcRequestMapping"/> class.
        /// </summary>
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

        /// <summary>
        /// Maps the properties of the current instance to an instance of WalletTransactionWalletsGrpcRequest.
        /// </summary>
        /// <returns>The mapped instance of WalletTransactionWalletsGrpcRequest.</returns>
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

        /// <summary>
        /// Updates an existing instance of WalletTransactionWalletsGrpcRequest with the properties of the current instance.
        /// This method is intended to be overridden in derived classes.
        /// </summary>
        /// <param name="result">The existing instance of WalletTransactionWalletsGrpcRequest to be updated.</param>
        /// <returns>The updated instance of WalletTransactionWalletsGrpcRequest.</returns>
        public override WalletTransactionWalletsGrpcRequest Update(WalletTransactionWalletsGrpcRequest result)
        {
            throw new NotImplementedException();
        }
    }
}
