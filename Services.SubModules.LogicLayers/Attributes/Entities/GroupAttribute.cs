namespace Services.SubModules.LogicLayers.Attributes.Entities
{
    /// <summary>
    /// Custom attribute to represent a group.
    /// </summary>
    public class GroupAttribute : NameAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupAttribute"/> class with the specified group name.
        /// </summary>
        /// <param name="name">The name of the group.</param>
        public GroupAttribute(string name) : base(name)
        {
        }
    }
}
