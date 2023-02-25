using System.Globalization;
using ContactBook.Domain.Interfaces;
using ContactBook.Facades.PersonFacade;
using ContactBook.Helpers;
using ContactBook.Resources;
using ContactBook.Strategy;
using ContactBook.Strategy.Strategies;
using ContactBook.Strategy.Strategies.Common;
using Microsoft.Extensions.DependencyInjection;

namespace ContactBook.Domain;

public class Menu : IMenu
{
    private readonly IAgenda _agenda;
    private readonly IPersonService _personService;
    private readonly IExportContext _exportContext;
    private readonly IServiceProvider _provider;

    public Menu(IAgenda agenda, IPersonService personService, IExportContext exportContext, IServiceProvider provider)
    {
        _agenda = agenda;
        _personService = personService;
        _exportContext = exportContext;
        _provider = provider;
    }

    public void Execute()
    {
        var culture = InputHelper.GetCultureInput();
        Language.ChangeThreadCulture(culture);

        var quit = false;
        do
        {
            Console.WriteLine(Language.SelectTheAction);
            Console.WriteLine("1 - " + Language.AddPersons);
            Console.WriteLine("2 - " + Language.RemovePersons);
            Console.WriteLine("3 - " + Language.ListPersons);
            Console.WriteLine("4 - " + Language.UpdateLanguageString);
            Console.WriteLine("5 - " + Language.ExportPdf);
            Console.WriteLine("6 - " + Language.CreateFourFictionalPeople);
            Console.WriteLine("7 - " + Language.CloseApplication);
            var option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    _personService.AddPersons();
                    break;
                case "2":
                    _personService.RemovePersons();
                    break;
                case "3":
                    Console.WriteLine(Language.StarList);
                    _agenda.ListPersons();
                    break;
                case "4":
                    culture = InputHelper.GetCultureInput();
                    Language.ChangeThreadCulture(culture);
                    break;
                case "5":
                    _exportContext.SetExportService((IExport)_provider.GetRequiredService<IPdfExport>());
                    _exportContext.ExportFile(_agenda);
                    break;  
                case "6":
                    for (var i = 0; i < 4; i++)
                    {
                        _agenda.AddPerson(
                            new Person($"Nome teste {i}",$"email{i}@teste.com",$"address Teste {i}") );   
                    }
                    break;
                case "7":
                    quit = true;
                    break;
                default:
                    Console.WriteLine(Language.InvalidOption);
                    break;
            }
        } while (quit == false);
    }
}