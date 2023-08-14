using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    /// <summary>
    /// Represents a mapping from custom entity to the protobuf request message for creating referral referrals.
    /// </summary>
    public class CreateReferralReferralsGrpcRequestMapping : Mapping<CreateReferralReferralsGrpcRequest>
    {
        /// <summary>
        /// Gets or sets the user ID for the referral.
        /// </summary>
        public Guid IdUser { get; set; }

        /// <summary>
        /// Gets or sets the referral token.
        /// </summary>
        public string TokenReferral { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateReferralReferralsGrpcRequestMapping"/> class
        /// with the specified user ID and referral token.
        /// </summary>
        /// <param name="idUser">The user ID for the referral.</param>
        /// <param name="tokenReferral">The referral token.</param>
        public CreateReferralReferralsGrpcRequestMapping(Guid idUser, string tokenReferral)
        {
            IdUser = idUser;
            TokenReferral = tokenReferral;
        }

        /// <summary>
        /// Maps the properties of this instance to a protobuf request message for creating referral referrals.
        /// </summary>
        /// <returns>The mapped <see cref="CreateReferralReferralsGrpcRequest"/> instance.</returns>
        public override CreateReferralReferralsGrpcRequest Map()
        {
            var result = new CreateReferralReferralsGrpcRequest
            {
                IdUser = IdUser.ToString(),
                TokenReferral = TokenReferral
            };
            return result;
        }

        /// <summary>
        /// Updates an existing protobuf request message instance with the properties of this mapping.
        /// This method is not implemented and will throw an exception.
        /// </summary>
        /// <param name="result">The existing protobuf request message to be updated.</param>
        /// <returns>The updated <see cref="CreateReferralReferralsGrpcRequest"/> instance.</returns>
        public override CreateReferralReferralsGrpcRequest Update(CreateReferralReferralsGrpcRequest result)
        {
            throw new NotImplementedException();
        }
    }
}
