namespace Services.SubModules.LogicLayers.Attributes.Entities
{
    /// <summary>
    /// Custom attribute to represent a claim.
    /// </summary>
    public class ClaimAttribute : NameAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClaimAttribute"/> class with the specified claim name.
        /// </summary>
        /// <param name="name">The name of the claim.</param>
        public ClaimAttribute(string name) : base(name)
        {
        }
    }
}
