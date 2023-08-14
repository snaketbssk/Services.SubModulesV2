using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    /// <summary>
    /// Represents a mapping from a custom entity to the protobuf request message for authentication identity.
    /// </summary>
    public class AuthenticationIdentityGrpcRequestMapping : Mapping<AuthenticationIdentityGrpcRequest>
    {
        /// <summary>
        /// Gets or sets the authentication token.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationIdentityGrpcRequestMapping"/> class
        /// with the specified authentication token.
        /// </summary>
        /// <param name="token">The authentication token.</param>
        public AuthenticationIdentityGrpcRequestMapping(string token)
        {
            Token = token;
        }

        /// <summary>
        /// Maps the properties of this instance to a protobuf request message for authentication identity.
        /// </summary>
        /// <returns>The mapped <see cref="AuthenticationIdentityGrpcRequest"/> instance.</returns>
        public override AuthenticationIdentityGrpcRequest Map()
        {
            var result = new AuthenticationIdentityGrpcRequest()
            {
                Token = Token
            };

            return result;
        }

        /// <summary>
        /// Updates an existing protobuf request message instance with the properties of this mapping.
        /// This method is not implemented and will throw an exception.
        /// </summary>
        /// <param name="result">The existing protobuf request message to be updated.</param>
        /// <returns>The updated <see cref="AuthenticationIdentityGrpcRequest"/> instance.</returns>
        public override AuthenticationIdentityGrpcRequest Update(AuthenticationIdentityGrpcRequest result)
        {
            throw new NotImplementedException();
        }
    }
}
