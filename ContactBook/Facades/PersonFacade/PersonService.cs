using ContactBook.Domain;
using ContactBook.Domain.Interfaces;
using ContactBook.Helpers;

namespace ContactBook.Facades.PersonFacade;

public class PersonService : IPersonService
{
    private readonly IAgenda _agenda;

    public PersonService(IAgenda agenda)
    {
        _agenda = agenda;
    }
    public void RemovePersons()
    {
        var qtd = InputHelper.GetQtdOfPersonsToRemove(_agenda.GetQtdContacts());

        for (var i = 0; i < qtd; i++)
        {
            var id = InputHelper.GetIdInput();
            var remove = _agenda.RemovePerson(id);
            if (remove == false)
                i--;
        }
    }

    public void AddPersons()
    {
        var qtd = InputHelper.GetQtdOfPersonsToAdd();
            
        for (var i = 0; i < qtd; i++)
        {
            var name = InputHelper.GetNameInput(i);
            var endereco = InputHelper.GetAddressInput(i);
            var email = InputHelper.GetEmailInput(i);
            var person = new Person(name!,endereco!,email!);
            _agenda.AddPerson(person);
        }
    }
}