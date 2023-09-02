namespace SqlServerTestContainer.Database.Models;

public class Person
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
}