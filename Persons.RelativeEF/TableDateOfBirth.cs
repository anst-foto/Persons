using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Persons.RelativeEF;

[Table("table_date_of_births", Schema = "relative")]
public partial class TableDateOfBirth
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("date_of_birth")]
    public DateOnly DateOfBirth { get; set; }

    [InverseProperty("DateOfBirthNavigation")]
    public virtual ICollection<TablePerson> TablePeople { get; set; } = new List<TablePerson>();
}
