namespace StrategyLibrary.SortingExample;

public class Person
{
    public Person(string name, string email, string endereco)
    {
        Name = name;
        Email = email;
        Endereco = endereco;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Endereco { get; set; }

    public override string ToString() => $"Id:{Id} Name: {Name} - Email: {Email}";
}
