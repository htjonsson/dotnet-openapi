using System;
using System.Reflection;

namespace Cmd;

class Program
{
    static void Main(string[] args)
    {


        // https://www.tutorialspoint.com/csharp/csharp_reflection.htm
        
        
        // Console.WriteLine($"Assembly Name: {Assembly.GetExecutingAssembly().GetName().Name}");

        try
        {
            var assembly = Assembly.GetExecutingAssembly();

            var types = assembly.GetTypes();

            foreach(var type in types)
            {
                

                var attributes = type.GetCustomAttributes(true);

                if (attributes.Length > 0)
                {
                    // Console.WriteLine("The attributes for the member {0} are: \n", type.Name);

                    // Console.WriteLine(typeof(ContainerAttribute).Name);

                    for(int j = 0; j < attributes.Length; j++)
                    {
                        string attributeName = $"{attributes[j]}";

                        // Console.WriteLine("The type of the attribute is {0}.", attributeName);

                        // Console.WriteLine("Attribute Name {0}.", attributeName);

                        if (typeof(ContainerAttribute).Name == attributeName)
                        {
                            Console.WriteLine($"{type.FullName} -> {type.Name}");
                            Console.WriteLine("\tIs a container");
                        

                        }
                    }
                }
            }
        }
        catch(Exception e)
        {
            Console.WriteLine("An exception occurred: {0}", e.Message);
        }
    }
}
    