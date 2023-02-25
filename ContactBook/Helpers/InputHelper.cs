using ContactBook.Domain;
using ContactBook.Resources;

namespace ContactBook.Helpers;

public static class InputHelper
{
    public static string GetCultureInput()
    {
        Console.WriteLine(Language.SelectLanguage);
        var cultureOption = Console.ReadLine();

        var culture = cultureOption switch
        {
            "1" => "pt-BR",
            "2" => "en-US",
            _ => "pt-BR"
        };
        return culture;
    }

    public static int GetQtdOfPersonsToRemove(int agendaContactQtd)
    {
        Console.WriteLine(Language.HowManyPeopleRemoveToTheList);
        var parseInput = int.TryParse(Console.ReadLine(), out var qtd);
        while (parseInput && qtd > agendaContactQtd)
        {
            Console.WriteLine(Language.NumberOfPeopleToRemoveExceeded);
            parseInput = int.TryParse(Console.ReadLine(), out qtd);
        }

        return qtd;
    }

    public static int GetQtdOfPersonsToAdd()
    {
        bool parse;
        int qtd;
        do
        {
            Console.WriteLine(Language.HowManyPeopleAddToTheList!);
            parse = int.TryParse(Console.ReadLine(), out qtd);
        } while (parse == false);

        return qtd;
    }

    public static string? GetEmailInput(int i)
    {
        Console.WriteLine($"{i + 1} - {Language.EnterThePersonEmail} : ");
        var email = Console.ReadLine();
        return email;
    }

    public static string? GetAddressInput(int i)
    {
        Console.WriteLine($"{i + 1} - {Language.EnterThePersonAddress} : ");
        var endereco = Console.ReadLine();
        return endereco;
    }

    public static string? GetNameInput(int i)
    {
        Console.WriteLine($"{i + 1} - {Language.EnterThePersonName} : ");
        var name = Console.ReadLine();
        return name;
    }

    public static int GetIdInput()
    {
        Console.WriteLine(Language.EnterIdOfThePersonToRemoveFromSchedule);
        int.TryParse(Console.ReadLine(), out var id);
        return id;
    }
}