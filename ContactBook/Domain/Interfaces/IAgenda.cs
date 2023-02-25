namespace ContactBook.Domain.Interfaces;

public interface IAgenda
{
    void AddPerson(Person person);
    bool RemovePerson(int id);
    void ListPersons();
    int GetQtdContacts();
    List<Person> GetContacts();
}