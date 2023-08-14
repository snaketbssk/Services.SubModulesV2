using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    /// <summary>
    /// Represents a mapping from a custom entity to the protobuf model for a common currency with an ID.
    /// </summary>
    public class CurrencyCommonGrpcRequestMapping : Mapping<IdGrpcModel>
    {
        /// <summary>
        /// Gets or sets the ID of the currency.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyCommonGrpcRequestMapping"/> class
        /// with the specified currency ID.
        /// </summary>
        /// <param name="id">The ID of the currency.</param>
        public CurrencyCommonGrpcRequestMapping(Guid id)
        {
            Id = id;
        }

        /// <summary>
        /// Maps the properties of this instance to a protobuf model for a common currency with an ID.
        /// </summary>
        /// <returns>The mapped <see cref="IdGrpcModel"/> instance.</returns>
        public override IdGrpcModel Map()
        {
            var result = new IdGrpcModel
            {
                Id = Id.ToString()
            };
            return result;
        }

        /// <summary>
        /// Updates an existing protobuf model instance with the properties of this mapping.
        /// This method is not implemented and will throw an exception.
        /// </summary>
        /// <param name="result">The existing protobuf model to be updated.</param>
        /// <returns>The updated <see cref="IdGrpcModel"/> instance.</returns>
        public override IdGrpcModel Update(IdGrpcModel result)
        {
            throw new NotImplementedException();
        }
    }
}
