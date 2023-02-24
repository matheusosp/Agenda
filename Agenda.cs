using StrategyLibrary.SortingExample;

namespace ContactBook;

public class Agenda
{
    private List<Person> _persons { get; set; }
    public int QtdPersons { get; set; }

    public Agenda()
    {
        _persons = new List<Person>();
        QtdPersons = 0;
    }
    public void AddPerson(Person person)
    {
        person.Id = QtdPersons == 0 ? 1 : _persons.FindLast(p => true)!.Id + 1;
        _persons.Add(person);
        QtdPersons++;
        Console.WriteLine("Pessoa adicionada: " + person);
        ListPersons();
    }

    public void RemovePerson(int id)
    {
        QtdPersons--;
        _persons.RemoveAll(p => p.Id == id);
        Console.WriteLine("Pessoa removida Id: " + id);
        ListPersons();
    }

    public void ListPersons()
    {
        if (QtdPersons == 0)
        {
            Console.WriteLine("Agenda vazia");
            return;
        }

        Console.WriteLine("Listando contatos ");
        foreach (var person in _persons)
        {
            Console.WriteLine(person);
        }
    }
}