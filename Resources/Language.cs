using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using System.Resources.NetStandard;
using System.Text;


namespace ContactBook.Resources
{
    public static class Language
    {
        private static ResourceSet? _resource;
        private static CultureInfo? _culture;

        private static string? GetString(string key)
        {
            if (CultureInfo.CurrentCulture == _culture) return _resource.GetString(key);
            
            _culture = CultureInfo.CurrentCulture;
            var reader = new ResXResourceReader($"{AppDomain.CurrentDomain.BaseDirectory}" +
                                                $"\\Resources\\Strings.{_culture.Name}.resx");
            _resource = new ResourceSet(reader);

            return _resource.GetString(key);
        }

        public static string? Demonstration
        {
            get { return GetString("Demonstration"); }
        }
    }
}
