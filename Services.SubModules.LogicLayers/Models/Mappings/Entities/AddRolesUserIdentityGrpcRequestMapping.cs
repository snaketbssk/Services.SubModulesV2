using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    /// <summary>
    /// Represents a mapping from custom entity to the protobuf request message for adding roles to a user identity.
    /// </summary>
    public class AddRolesUserIdentityGrpcRequestMapping : Mapping<AddRolesUserIdentityGrpcRequest>
    {
        /// <summary>
        /// Gets or sets the ID of the user identity.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the roles to be added to the user identity.
        /// </summary>
        public IEnumerable<string> Roles { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AddRolesUserIdentityGrpcRequestMapping"/> class
        /// with the specified user identity ID and roles.
        /// </summary>
        /// <param name="id">The ID of the user identity.</param>
        /// <param name="roles">The roles to be added to the user identity.</param>
        public AddRolesUserIdentityGrpcRequestMapping(Guid id, IEnumerable<string> roles)
        {
            Id = id;
            Roles = roles;
        }

        /// <summary>
        /// Maps the properties of this instance to a protobuf request message for adding roles to a user identity.
        /// </summary>
        /// <returns>The mapped <see cref="AddRolesUserIdentityGrpcRequest"/> instance.</returns>
        public override AddRolesUserIdentityGrpcRequest Map()
        {
            var result = new AddRolesUserIdentityGrpcRequest();
            result.Id = Id.ToString();
            result.Roles.AddRange(Roles);

            return result;
        }

        /// <summary>
        /// Updates an existing protobuf request message instance with the properties of this mapping.
        /// This method is not implemented and will throw an exception.
        /// </summary>
        /// <param name="result">The existing protobuf request message to be updated.</param>
        /// <returns>The updated <see cref="AddRolesUserIdentityGrpcRequest"/> instance.</returns>
        public override AddRolesUserIdentityGrpcRequest Update(AddRolesUserIdentityGrpcRequest result)
        {
            throw new NotImplementedException();
        }
    }
}
