[AttributeUsage(AttributeTargets.Property | AttributeTargets.Class)]
public class MetadataAttribute : Attribute
{
    public string _name = string.Empty;

    public MetadataAttribute(string name)
    {
        _name = name;
    }
}