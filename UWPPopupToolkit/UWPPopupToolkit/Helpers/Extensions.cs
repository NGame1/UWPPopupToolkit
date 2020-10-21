using System;
using System.Linq;
using System.Reflection;

namespace UWPPopupToolkit.Helpers
{
    public static class Extensions
    {
        public static object GetPropertyValue(this object source, string propertyName)
        {
            var property = source.GetType().GetRuntimeProperties().FirstOrDefault(p => string.Equals(p.Name, propertyName, StringComparison.OrdinalIgnoreCase));
            return property?.GetValue(source);
        }

        public static bool SetPropertyValue(this object source, string propertyName, object value)
        {
            var property = source.GetType().GetRuntimeProperties().FirstOrDefault(p => string.Equals(p.Name, propertyName, StringComparison.OrdinalIgnoreCase));
            property?.SetValue(source, value);
            return source.GetPropertyValue(propertyName) == value;
        }

    }
}
