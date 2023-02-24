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
        
        public static string? SelectLanguage
        {
            get { return GetString("SelectLanguage"); }
        }
        public static string? SelectTheAction
        {
            get { return GetString("SelectTheAction"); }
        }
        public static string? AddPersons
        {
            get { return GetString("AddPersons"); }
        }
        public static string? RemovePersons
        {
            get { return GetString("RemovePersons"); }
        }
        public static string? ListPersons
        {
            get { return GetString("ListPersons"); }
        }
        public static string? UpdateLanguageString
        {
            get { return GetString("UpdateLanguageString"); }
        }
        public static string? CloseApplication
        {
            get { return GetString("CloseApplication"); }
        }
    }
}
