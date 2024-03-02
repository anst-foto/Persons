using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persons.RelativeEF;

[Table("table_first_names", Schema = "relative")]
public partial class TableFirstName
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("name")]
    public string Name { get; set; } = null!;

    [InverseProperty("FirstNameNavigation")]
    public virtual ICollection<TablePerson> TablePeople { get; set; } = new List<TablePerson>();
}
