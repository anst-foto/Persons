namespace Persons.Relative;

public record Person
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public DateTime DateOfBirth { get; set; }
}