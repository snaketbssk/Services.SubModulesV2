namespace Services.SubModules.LogicLayers.Attributes.Entities
{
    public abstract class NameAttribute : Attribute
    {
        public readonly string Name;
        public NameAttribute(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
