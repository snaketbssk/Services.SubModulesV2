using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    /// <summary>
    /// Represents a mapping class for converting data to UserTransactionWalletsGrpcRequest.
    /// </summary>
    public class UserTransactionWalletsGrpcRequestMapping : Mapping<UserTransactionWalletsGrpcRequest>
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
        /// Gets or sets the user ID.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the currency ID.
        /// </summary>
        public Guid CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets the transaction reference.
        /// </summary>
        public string? Reference { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserTransactionWalletsGrpcRequestMapping"/> class.
        /// </summary>
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

        /// <summary>
        /// Maps the properties of the current instance to an instance of UserTransactionWalletsGrpcRequest.
        /// </summary>
        /// <returns>The mapped instance of UserTransactionWalletsGrpcRequest.</returns>
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

        /// <summary>
        /// Updates an existing instance of UserTransactionWalletsGrpcRequest with the properties of the current instance.
        /// This method is intended to be overridden in derived classes.
        /// </summary>
        /// <param name="result">The existing instance of UserTransactionWalletsGrpcRequest to be updated.</param>
        /// <returns>The updated instance of UserTransactionWalletsGrpcRequest.</returns>
        public override UserTransactionWalletsGrpcRequest Update(UserTransactionWalletsGrpcRequest result)
        {
            throw new NotImplementedException();
        }
    }
}
