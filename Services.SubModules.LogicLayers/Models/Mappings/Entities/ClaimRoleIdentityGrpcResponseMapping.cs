using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    /// <summary>
    /// Represents a mapping from a custom entity to the protobuf response message for claim-role identity.
    /// </summary>
    public class ClaimRoleIdentityGrpcResponseMapping : Mapping<ClaimRoleIdentityGrpcResponse>
    {
        /// <summary>
        /// Gets or sets the claim type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the claim value.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClaimRoleIdentityGrpcResponseMapping"/> class
        /// with the specified claim type and value.
        /// </summary>
        /// <param name="type">The claim type.</param>
        /// <param name="value">The claim value.</param>
        public ClaimRoleIdentityGrpcResponseMapping(string type, string value)
        {
            Type = type;
            Value = value;
        }

        /// <summary>
        /// Maps the properties of this instance to a protobuf response message for claim-role identity.
        /// </summary>
        /// <returns>The mapped <see cref="ClaimRoleIdentityGrpcResponse"/> instance.</returns>
        public override ClaimRoleIdentityGrpcResponse Map()
        {
            var result = new ClaimRoleIdentityGrpcResponse
            {
                Type = Type,
                Value = Value
            };
            return result;
        }

        /// <summary>
        /// Updates an existing protobuf response message instance with the properties of this mapping.
        /// This method is not implemented and will throw an exception.
        /// </summary>
        /// <param name="result">The existing protobuf response message to be updated.</param>
        /// <returns>The updated <see cref="ClaimRoleIdentityGrpcResponse"/> instance.</returns>
        public override ClaimRoleIdentityGrpcResponse Update(ClaimRoleIdentityGrpcResponse result)
        {
            throw new NotImplementedException();
        }
    }
}
