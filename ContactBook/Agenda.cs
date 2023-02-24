using System;
using System.Collections.Generic;
using ContactBook.Resources;
using StrategyLibrary.SortingExample;

namespace ContactBook;

public class Agenda
{
    private List<Person> _persons { get; set; }

    public Agenda()
    {
        _persons = new List<Person>();
    }
    public void AddPerson(Person person)
    {
        person.Id = _persons.Count == 0 ?
            1 : _persons.FindLast(p => true)!.Id + 1;
        _persons.Add(person);
        Console.WriteLine(Language.PersonAdded+": " + person);
        ListPersons();
    }

    public bool RemovePerson(int id)
    {
        var person = _persons.Find(p => p.Id == id);
        if (person == null)
        {
            Console.WriteLine(Language.PersonDoesNotExistInTheSchedule);
            return false;
        }

        _persons.Remove(person);
        Console.WriteLine(Language.PersonRemoved +" : " + person);
        ListPersons();
        return true;
    }

    public void ListPersons()
    {
        if (_persons.Count == 0)
        {
            Console.WriteLine(Language.EmptySchedule);
            return;
        }

        Console.WriteLine(Language.ShowContacts);
        foreach (var person in _persons)
        {
            Console.WriteLine(person);
        }
    }

    public int GetQtdContacts()
    {
        return _persons.Count;
    }
}