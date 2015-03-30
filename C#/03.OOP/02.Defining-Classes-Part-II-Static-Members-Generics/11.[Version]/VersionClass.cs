using System;

[AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class |
    AttributeTargets.Interface | AttributeTargets.Enum |
    AttributeTargets.Method, AllowMultiple = false)]

public class VersionAttribute : Attribute
{
    public string Version
    {
        get;
        private set;
    }
    public VersionAttribute(string version)
    {
        this.Version = version;
    }
}

[Version("2.3.9658")]
public class VersionClass
{

}
