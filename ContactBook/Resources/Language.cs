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
            if (CultureInfo.CurrentCulture == _culture) return _resource?.GetString(key);

            _culture = CultureInfo.CurrentCulture;
            var reader = new ResXResourceReader($"{AppDomain.CurrentDomain.BaseDirectory}" +
                                                $"\\Resources\\Strings.{_culture.Name}.resx");
            _resource = new ResourceSet(reader);

            return _resource.GetString(key);
        }

        public static void ChangeThreadCulture(string culture)
        {
            var ci = new CultureInfo(culture);
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }

        public static string? SelectLanguage => GetString("SelectLanguage");

        public static string? SelectTheAction => GetString("SelectTheAction");

        public static string? AddPersons => GetString("AddPersons");

        public static string? RemovePersons => GetString("RemovePersons");

        public static string? ListPersons => GetString("ListPersons");

        public static string? UpdateLanguageString => GetString("UpdateLanguageString");

        public static string? CloseApplication => GetString("CloseApplication");

        public static string? StarList => GetString("StarList");

        public static string? HowManyPeopleRemoveToTheList => GetString("HowManyPeopleRemoveToTheList");

        public static string? NumberOfPeopleToRemoveExceeded => GetString("NumberOfPeopleToRemoveExceeded");

        public static string? InvalidOption => GetString("InvalidOption");

        public static string? EnterIdOfThePersonToRemoveFromSchedule
        {
            get { return GetString("EnterIdOfThePersonToRemoveFromSchedule"); }
        }

        public static string? HowManyPeopleAddToTheList => GetString("HowManyPeopleAddToTheList");

        public static string? EnterThePersonName => GetString("EnterThePersonName");

        public static string? EnterThePersonAddress => GetString("EnterThePersonAddress");

        public static string? EnterThePersonEmail => GetString("EnterThePersonEmail");

        public static string? Name => GetString("Name");
        public static string? PersonAdded => GetString("PersonAdded");
        public static string? EmptySchedule => GetString("EmptySchedule");
        public static string? ShowContacts => GetString("ShowContacts");
        public static string? PersonRemoved => GetString("PersonRemoved");
        public static string? PersonDoesNotExistInTheSchedule => GetString("PersonDoesNotExistInTheSchedule");
        public static string? ExportPdf => GetString("ExportPdf");
        public static string? Address => GetString("Address");
        public static string? ContactsDirectoryDate => GetString("ContactsDirectoryDate");
        public static string? Date => GetString("Date");
        public static string? TotalContacts => GetString("TotalContacts");
        public static string? CreateFourFictionalPeople => GetString("CreateFourFictionalPeople");
    }
}