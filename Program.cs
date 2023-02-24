using ContactBook.Resources;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ContactBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args);
            Console.WriteLine(Language.Demonstration);
            Console.ReadLine();
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