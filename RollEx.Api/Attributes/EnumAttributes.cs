using System;

namespace RollEx.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class EnumDescriptionAttribute : Attribute
    {
        private string descriptionValue;
        public string DescriptionValue { get { return descriptionValue; } set => descriptionValue = value; }

        public EnumDescriptionAttribute(string descriptionValue)
        {
            this.DescriptionValue = descriptionValue;
        }
    }
}
