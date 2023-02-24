using System.Globalization;
using ContactBook.Resources;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StrategyLibrary.SortingExample;

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

            Console.ReadLine();
        }

        private static void StartApp()
        {
            ChangeLanguage();
            var agenda = new Agenda();
            var quit = false;

            do
            {
                Console.WriteLine("Selecione a ação para realizar na agenda");
                Console.WriteLine("1 - Adicionar Pessoas");
                Console.WriteLine("2 - Remover Pessoas");
                Console.WriteLine("3 - Listar Pessoas");
                Console.WriteLine("4 - Alterar Idioma");
                Console.WriteLine("5 - Fechar aplicação");
                var action = Console.ReadLine();
                switch (action)
                {
                    case "1":
                        AddPersons(agenda);
                        break;
                    case "2":
                        RemovePersons(agenda);
                        break;
                    case "3":
                        Console.WriteLine("Iniciando listagem de contatos");
                        agenda.ListPersons();
                        break;
                    case "4":
                        ChangeLanguage();
                        break;
                    case "5":
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("Opção invalida, digite a opção novamente");
                        break;
                }
            } while (quit == false);
        }
        

        private static void ChangeLanguage()
        {
            Console.WriteLine("Selecione o idioma do sistema: (1- pt-BR, 2 - en-US) ");
            var option = Console.ReadLine();
            var ci = new CultureInfo("pt-BR");
            if (option == "2")
                ci = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }

        private static void RemovePersons(Agenda agenda)
        {
            Console.WriteLine("Quantas pessoas deseja remover da lista?");
            var qtd = Console.Read();
            if (qtd > agenda.QtdPersons)
            {
                while (qtd > agenda.QtdPersons)
                {
                    Console.WriteLine("A quantidade de pessoas a remover é maior do que a quantidade de pessoas registrada, digite outra quantidade");
                    qtd = Console.Read();
                }
            }

            for (int i = 0; i < qtd; i++)
            {
                Console.WriteLine("Digite o id da pessoa: ");
                var id = Console.ReadLine();
                agenda.RemovePerson(int.Parse(id));
            }
        }

        private static void AddPersons(Agenda agenda)
        {
           Console.WriteLine("Quantas pessoas deseja adicionar na lista?");
           var qtd = int.Parse(Console.ReadLine());
           for (int i = 0; i < qtd; i++)
           {
               Console.WriteLine("Digite o nome da pessoa: ");
               var name = Console.ReadLine();
               Console.WriteLine("Digite o endereço da pessoa:");
               var endereco = Console.ReadLine();
               Console.WriteLine("Digite o email da pessoa: ");
               var email = Console.ReadLine();
               var person = new Person(name,endereco,email);
               agenda.AddPerson(person);
           }
        }
        
    }
}