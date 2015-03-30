using System;

class Version
{
    static void Main()
    {
        Type type = typeof(VersionClass);

        foreach (var attr in type.GetCustomAttributes(false))
        {
            if (attr is VersionAttribute)
            {
                Console.WriteLine("This is version {0} of the {1} class.",
                    (attr as VersionAttribute).Version, typeof(VersionClass).FullName);
            }
        }
    }
}