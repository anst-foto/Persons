using System.Text.Json.Serialization;

namespace Persons.FlatJson;

public record Person
{
    public Guid Id { get; init; }
    public string Info { get; init; }
}

public record PersonInfo
{
    [JsonPropertyName("last_name")]
    public string LastName { get; set; }
    
    [JsonPropertyName("first_name")]
    public string FirstName { get; set; }
    
    [JsonPropertyName("date_of_birth")]
    public DateTime DateOfBirth { get; set; }
}