using System.Text.Json.Serialization;

namespace Persons.FlatEF;

public record Person
{
    [JsonPropertyName("last_name")]
    public string LastName { get; set; }
    
    [JsonPropertyName("first_name")]
    public string FirstName { get; set; }
    
    [JsonPropertyName("date_of_birth")]
    public DateTime DateOfBirth { get; set; }
}