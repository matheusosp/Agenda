namespace StrategyLibrary.SortingExample;

public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Endereco { get; set; }

    public override string ToString() => $"{Id} {Name} - {Email}";
}
