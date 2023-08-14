using Services.SubModules.LogicLayers.Models.Requests;
using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    /// <summary>
    /// Represents a mapping class for converting data to IdGrpcModel.
    /// </summary>
    public class UserIdentityGrpcRequestMapping : Mapping<IdGrpcModel>
    {
        /// <summary>
        /// Gets or sets the user ID.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserIdentityGrpcRequestMapping"/> class.
        /// </summary>
        /// <param name="id">The user ID.</param>
        public UserIdentityGrpcRequestMapping(Guid id)
        {
            Id = id;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserIdentityGrpcRequestMapping"/> class.
        /// </summary>
        /// <param name="idRequest">The ID request object containing the user ID.</param>
        public UserIdentityGrpcRequestMapping(IIdRequest idRequest)
        {
            Id = idRequest.Id;
        }

        /// <summary>
        /// Maps the properties of the current instance to an instance of IdGrpcModel.
        /// </summary>
        /// <returns>The mapped instance of IdGrpcModel.</returns>
        public override IdGrpcModel Map()
        {
            var result = new IdGrpcModel
            {
                Id = Id.ToString()
            };
            return result;
        }

        /// <summary>
        /// Updates an existing instance of IdGrpcModel with the properties of the current instance.
        /// This method is intended to be overridden in derived classes.
        /// </summary>
        /// <param name="result">The existing instance of IdGrpcModel to be updated.</param>
        /// <returns>The updated instance of IdGrpcModel.</returns>
        public override IdGrpcModel Update(IdGrpcModel result)
        {
            throw new NotImplementedException();
        }
    }
}
