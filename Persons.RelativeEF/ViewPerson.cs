using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Persons.RelativeEF;

[Keyless]
public partial class ViewPerson
{
    [Column("last_name")]
    public string? LastName { get; set; }

    [Column("first_name")]
    public string? FirstName { get; set; }

    [Column("date_of_birth")]
    public DateOnly? DateOfBirth { get; set; }
}
