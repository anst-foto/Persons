using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persons.RelativeEF;

[Table("table_persons", Schema = "relative")]
public partial class TablePerson
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("first_name")]
    public Guid? FirstName { get; set; }

    [Column("last_name")]
    public Guid? LastName { get; set; }

    [Column("date_of_birth")]
    public Guid? DateOfBirth { get; set; }

    [ForeignKey("DateOfBirth")]
    [InverseProperty("TablePeople")]
    public virtual TableDateOfBirth? DateOfBirthNavigation { get; set; }

    [ForeignKey("FirstName")]
    [InverseProperty("TablePeople")]
    public virtual TableFirstName? FirstNameNavigation { get; set; }

    [ForeignKey("LastName")]
    [InverseProperty("TablePeople")]
    public virtual TableLastName? LastNameNavigation { get; set; }
}
