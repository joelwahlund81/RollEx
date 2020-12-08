using RollEx.Attributes;
using System;
using System.Reflection;

namespace RollEx.Extensions
{
    public static class EnumExtensions
    {
        public static string GetEnumDescription(this Enum value)
        {
            Type type = value.GetType();
            FieldInfo fieldInfo = type.GetField(value.ToString());
            // Get the stringvalue attributes  
            EnumDescriptionAttribute[] attribs = fieldInfo.GetCustomAttributes(
                 typeof(EnumDescriptionAttribute), false) as EnumDescriptionAttribute[];
            // Return the first if there was a match.  
            return attribs.Length > 0 ? attribs[0].DescriptionValue : null;
        }

        public static T GetRandom<T>()
        {
            var values = Enum.GetValues(typeof(T));
            Random random = new Random();
            T randomBar = (T)values.GetValue(random.Next(values.Length));
            return randomBar;
        }
    }
}
