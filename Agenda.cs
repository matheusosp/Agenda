using StrategyLibrary.SortingExample;

namespace ContactBook;

public class Agenda
{
    private List<Person> _persons { get; set; }
    private int qtdPersons { get; set; }

    public Agenda()
    {
        _persons = new List<Person>();
        qtdPersons = 0;
    }
    public void AddPerson(Person person)
    {
        person.Id = qtdPersons;
        _persons.Add(person);
        qtdPersons++;
        Console.WriteLine("Pessoa adicionada: " + person);
        ListPersons();
    }

    public void RemovePerson(int id)
    {
        _persons.RemoveAll(p => p.Id == id);
        Console.WriteLine("Pessoa removida Id: " + id);
        ListPersons();
    }

    public void ListPersons()
    {
        foreach (var person in _persons)
        {
            Console.WriteLine(person);
        }
    }
}