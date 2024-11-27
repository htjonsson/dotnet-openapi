using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace Cmd;

class Program
{
    #region Schema

    static void Process_ColumnAttribute(object attribute)
    {
        if (attribute.GetType() == typeof(ColumnAttribute))
        {
            var columnAttribute = (ColumnAttribute)attribute;

            Console.WriteLine($" Name : {columnAttribute.Name ?? string.Empty} Order : {columnAttribute.Order} TypeName : {columnAttribute.TypeName ?? string.Empty}");
        }
    }

    static void Process_NotMappedAttribute(object attribute)
    {
        if (attribute.GetType() == typeof(NotMappedAttribute))
        {
            Console.WriteLine($" Is not mapped ");
        }
    }

    static void Process_TableAttribute(object attribute)
    {
        if (attribute.GetType() == typeof(TableAttribute))
        {
            var tableAttribute = (TableAttribute)attribute;

            Console.WriteLine($" TableName : {tableAttribute.Name} Schema : {tableAttribute.Schema ?? string.Empty} ");
        }
    }

    #endregion

    static void Process_KeyAttribute(object attribute)
    {
        if (attribute.GetType() == typeof(KeyAttribute))
        {
            Console.WriteLine($" Is key ");
        }
    }

    static void Process_MetadataAttribute(object attribute)
    {
        if (attribute.GetType() == typeof(MetadataAttribute))
        {
            var metadataAttribute = (MetadataAttribute)attribute;

            Console.WriteLine($" Metadata : {metadataAttribute._name} ");
        }
    }

    static void Process_MetadataTypeAttribute(object attribute)
    {
        if (attribute.GetType() == typeof(MetadataTypeAttribute))
        {
            var metadataTypeAttribute = (MetadataTypeAttribute)attribute;

            Console.WriteLine($" MetadataClassType : {metadataTypeAttribute.MetadataClassType.ToString()} ");
        }
    }

    static void Process_DataTypeAttribute(object attribute)
    {
        if (attribute.GetType() == typeof(DataTypeAttribute))
        {
            var dataTypeAttribute = (DataTypeAttribute)attribute;

            Console.WriteLine($" DataType: {dataTypeAttribute.DataType.ToString()} CustomDataType: {dataTypeAttribute.CustomDataType}");
        }
    }

    static void Process_EditableAttribute(object attribute)
    {
        if (attribute.GetType() == typeof(EditableAttribute))
        {
            var editableAttribute = (EditableAttribute)attribute;

            Console.WriteLine($" AllowEdit: {editableAttribute.AllowEdit} AllowInitialValue: {editableAttribute.AllowInitialValue}");
        }
    }

    static void Process_RegularExpressionAttribute(object attribute)
    {
        if (attribute.GetType() == typeof(RegularExpressionAttribute))
        {
            var regularExpressionAttribute = (RegularExpressionAttribute)attribute;

            Console.WriteLine($" Pattern: {regularExpressionAttribute.Pattern}");
        }
    }

    static void Process_RequiredAttribute(object attribute)
    {
        if (attribute.GetType() == typeof(RequiredAttribute))
        {
            var requiredAttribute = (RequiredAttribute)attribute;

            Console.WriteLine($" Required: true");

            Console.WriteLine($" Allow Empty Strings: {requiredAttribute.AllowEmptyStrings}");
        }
    }

    #region Process Length

    static void Process_MinLengthAttribute(object attribute)
    {
        if (attribute.GetType() == typeof(MinLengthAttribute))
        {
            var minLengthAttribute = (MinLengthAttribute)attribute;

            Console.WriteLine($" Min length: {minLengthAttribute.Length}");
        }
    }

    static void Process_MaxLengthAttribute(object attribute)
    {
        if (attribute.GetType() == typeof(MaxLengthAttribute))
        {
            var maxLengthAttribute = (MaxLengthAttribute)attribute;

            Console.WriteLine($" Max length: {maxLengthAttribute.Length}");
        }
    }

    static void Process_LengthAttribute(object attribute)
    {
        if (attribute.GetType() == typeof(LengthAttribute))
        {
            var lengthAttribute = (LengthAttribute)attribute;

            Console.WriteLine($" Min length: {lengthAttribute.MinimumLength} Max length: {lengthAttribute.MaximumLength}");
        }
    }

    static void Process_StringLengthAttribute(object attribute)
    {
        if (attribute.GetType() == typeof(StringLengthAttribute))
        {
            var stringLengthAttribute = (StringLengthAttribute)attribute;

            Console.WriteLine($" Min length: {stringLengthAttribute.MinimumLength} Max length: {stringLengthAttribute.MaximumLength}");
        }
    }    

    #endregion

    static void Process(Type type)
    {
        var properties = type.GetProperties();

        foreach(var property in properties)
        {
            Console.WriteLine($" [property] -> {property.ToString()}");

            var propertyAttributes = property.GetCustomAttributes(false);

            // foreach(var propertyAttribute in propertyAttributes)
            // {
            //     Console.WriteLine($" attribute -> {propertyAttribute.ToString()}");
            // }

            var customAttributes = property.GetCustomAttributes(false);

            foreach (var customAttribute in customAttributes)
            {
                Process_MinLengthAttribute(customAttribute);
                Process_MaxLengthAttribute(customAttribute);
                Process_LengthAttribute(customAttribute);
                Process_StringLengthAttribute(customAttribute);
                
                Process_RequiredAttribute(customAttribute);
                Process_RegularExpressionAttribute(customAttribute);
                Process_EditableAttribute(customAttribute);
                Process_DataTypeAttribute(customAttribute);
                Process_MetadataTypeAttribute(customAttribute);
                Process_KeyAttribute(customAttribute);

                Process_ColumnAttribute(customAttribute);
                Process_NotMappedAttribute(customAttribute);
                Process_TableAttribute(customAttribute);

                Process_MetadataAttribute(customAttribute);

                Console.WriteLine($" [attribute] -> {customAttribute.ToString()}");
            }
        }
    }

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

                            Process(type);
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
    