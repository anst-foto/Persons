using Microsoft.EntityFrameworkCore;

namespace Persons.FlatEF;

public partial class JsonDbContext : DbContext
{
    public JsonDbContext()
    {
    }

    public JsonDbContext(DbContextOptions<JsonDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TablePerson> TablePersons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=json_db;Username=postgres;Password=1234;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("uuid-ossp");

        modelBuilder.Entity<TablePerson>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("table_persons_pkey");

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
