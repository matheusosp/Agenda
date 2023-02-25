using System.Globalization;
using ContactBook.Domain;
using ContactBook.Domain.Interfaces;
using ContactBook.Facades.PersonFacade;
using ContactBook.Strategy;
using ContactBook.Strategy.Strategies;
using iTextSharp.text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ContactBook;
public static class Program
{
    static void Main(string[] args)
    {
        SetThreadDefaultCulture();

        var host = CreateHostBuilder(args);
        var menu = host.Services.GetRequiredService<IMenu>();
        menu.Execute();
    }

    private static IHost CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureServices((_, services) =>
            {
                services.AddScoped<IMenu, Menu>();
                services.AddScoped<IAgenda, Agenda>();
                services.AddScoped<IPersonService, PersonService>();
                services.AddTransient<IExportContext, ExportContext>();
                services.AddTransient<IExcelExport, ExcelExport>();
                services.AddTransient<IPdfExport, PdfExport>();
                services.AddTransient<Document>(p => new Document());
            })
            .Build();
    }

    private static void SetThreadDefaultCulture()
    {
        var ci = new CultureInfo("pt-BR");
        CultureInfo.DefaultThreadCurrentCulture = ci;
        CultureInfo.DefaultThreadCurrentUICulture = ci;
        Thread.CurrentThread.CurrentCulture = ci;
        Thread.CurrentThread.CurrentUICulture = ci;
    }
}