using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persons.RelativeEF;

[Table("table_last_names", Schema = "relative")]
public partial class TableLastName
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("name")]
    public string Name { get; set; } = null!;

    [InverseProperty("LastNameNavigation")]
    public virtual ICollection<TablePerson> TablePeople { get; set; } = new List<TablePerson>();
}
