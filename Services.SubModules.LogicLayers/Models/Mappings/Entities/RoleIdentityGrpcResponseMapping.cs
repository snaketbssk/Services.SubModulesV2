using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    /// <summary>
    /// Represents a mapping class for converting a source representation to RoleIdentityGrpcResponse.
    /// </summary>
    public class RoleIdentityGrpcResponseMapping : Mapping<RoleIdentityGrpcResponse>
    {
        /// <summary>
        /// Gets or sets the name of the role.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleIdentityGrpcResponseMapping"/> class.
        /// </summary>
        /// <param name="name">The name of the role.</param>
        public RoleIdentityGrpcResponseMapping(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Maps the properties of the current instance to an instance of RoleIdentityGrpcResponse.
        /// </summary>
        /// <returns>The mapped instance of RoleIdentityGrpcResponse.</returns>
        public override RoleIdentityGrpcResponse Map()
        {
            var result = new RoleIdentityGrpcResponse
            {
                Name = Name
            };
            return result;
        }

        /// <summary>
        /// Updates an existing instance of RoleIdentityGrpcResponse with the properties of the current instance.
        /// This method is intended to be overridden in derived classes.
        /// </summary>
        /// <param name="result">The existing instance of RoleIdentityGrpcResponse to be updated.</param>
        /// <returns>The updated instance of RoleIdentityGrpcResponse.</returns>
        public override RoleIdentityGrpcResponse Update(RoleIdentityGrpcResponse result)
        {
            throw new NotImplementedException();
        }
    }
}
