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
            CultureInfo ci = new CultureInfo("pt-BR");
            Console.WriteLine("Selecione o idioma do sistema: (1- pt-BR, 2 - en-US) ");
            var option = Console.Read();
            if (option == 2)
                ci = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentCulture = ci;
            CultureInfo.DefaultThreadCurrentUICulture = ci;
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
            Console.WriteLine("Selecione a ação para realizar na agenda");
            Console.WriteLine("1 - Adicionar Pessoas");
            Console.WriteLine("2 - Remover Pessoas");
            Console.WriteLine("1 - Listar Pessoas");
            var action = Console.Read();

            var agenda = new Agenda();
            if (action == 1)
            {
                AddPersons(agenda);
            }

            Console.ReadLine();
        }

        private static void AddPersons(Agenda agenda)
        {
           Console.WriteLine("Quantas pessoas deseja adionar na lista?");
           var qtd = Console.Read();
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

        public static IHost CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostBuilderContext, services) =>
                {
                })
                .Build();
        }
    }
}