using System.Globalization;
using ContactBook.Resources;
using StrategyLibrary.SortingExample;
using static System.Int32;

namespace ContactBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ci = new CultureInfo("pt-BR");
            CultureInfo.DefaultThreadCurrentCulture = ci;
            CultureInfo.DefaultThreadCurrentUICulture = ci;
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
            StartApp();
        }

        private static void StartApp()
        {
            ChangeLanguage();
            var agenda = new Agenda();
            var quit = false;

            do
            {
                Console.WriteLine(Language.SelectTheAction);
                Console.WriteLine("1 - " + Language.AddPersons);
                Console.WriteLine("2 - " + Language.RemovePersons);
                Console.WriteLine("3 - " + Language.ListPersons);
                Console.WriteLine("4 - " + Language.UpdateLanguageString);
                Console.WriteLine("5 - " + Language.CloseApplication);
                var option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        AddPersons(agenda);
                        break;
                    case "2":
                        RemovePersons(agenda);
                        break;
                    case "3":
                        Console.WriteLine(Language.StarList);
                        agenda.ListPersons();
                        break;
                    case "4":
                        ChangeLanguage();
                        break;
                    case "5":
                        quit = true;
                        break;
                    default:
                        Console.WriteLine(Language.InvalidOption);
                        break;
                }
            } while (quit == false);
        }
        

        private static void ChangeLanguage()
        {
            Console.WriteLine(Language.SelectLanguage);
            var option = Console.ReadLine();
            var ci = new CultureInfo("pt-BR");
            if (option == "2")
                ci = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }

        private static void RemovePersons(Agenda agenda)
        {
            Console.WriteLine(Language.HowManyPeople);
            var parseInput = TryParse(Console.ReadLine(), out var qtd);
            while (parseInput && qtd > agenda.GetQtdContacts())
            {
                Console.WriteLine(Language.NumberOfPeopleToRemove);
                parseInput = TryParse(Console.ReadLine(), out qtd);
            }

            for (var i = 0; i < qtd; i++)
            {
                Console.WriteLine(Language.EnterIdOfThePersonToRemoveFromSchedule);
                TryParse(Console.ReadLine(), out var id);
                var remove =agenda.RemovePerson(id);
                if (remove == false)
                    i--;
            }
        }

        private static void AddPersons(Agenda agenda)
        {
            bool parse;
            int qtd;
            do
            {
                Console.WriteLine(Language.HowManyPeopleAddToTheList);
                parse = TryParse(Console.ReadLine(), out qtd);
            } while (parse == false);
            
            for (var i = 0; i < qtd; i++)
            {
                var name = GetNameInput(i);
                var endereco = GetAddressInput(i);
                var email = GetEmailInput(i);
                var person = new Person(name!,endereco!,email!);
                agenda.AddPerson(person);
            }
        }

        private static string? GetEmailInput(int i)
        {
            Console.WriteLine($"{i + 1} - {Language.EnterThePersonEmail} : ");
            var email = Console.ReadLine();
            return email;
        }

        private static string? GetAddressInput(int i)
        {
            Console.WriteLine($"{i + 1} - {Language.EnterThePersonAddress } : ");
            var endereco = Console.ReadLine();
            return endereco;
        }

        private static string? GetNameInput(int i)
        {
            Console.WriteLine($"{i + 1} - {Language.EnterThePersonName} : ");
            var name = Console.ReadLine();
            return name;
        }
    }
}