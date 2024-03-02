using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persons.FlatEF;

[Table("table_persons", Schema = "flat")]
public partial class TablePerson
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("info", TypeName = "json")]
    public string Info { get; set; } = null!;
}
