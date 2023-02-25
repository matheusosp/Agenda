using ContactBook.Domain.Interfaces;

namespace ContactBook.Facades.PersonFacade;

public interface IPersonService
{
    void RemovePersons();
    void AddPersons();
}