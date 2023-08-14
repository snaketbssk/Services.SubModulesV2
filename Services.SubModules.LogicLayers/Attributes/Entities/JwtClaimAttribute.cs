namespace Services.SubModules.LogicLayers.Attributes.Entities
{
    /// <summary>
    /// Custom attribute to represent a JWT claim.
    /// </summary>
    public class JwtClaimAttribute : NameAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JwtClaimAttribute"/> class with the specified claim name.
        /// </summary>
        /// <param name="name">The name of the JWT claim.</param>
        public JwtClaimAttribute(string name) : base(name)
        {
        }
    }
}
