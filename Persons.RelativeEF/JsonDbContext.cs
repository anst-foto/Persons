using Microsoft.EntityFrameworkCore;

namespace Persons.RelativeEF;

public partial class JsonDbContext : DbContext
{
    public JsonDbContext()
    {
    }

    public JsonDbContext(DbContextOptions<JsonDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TableDateOfBirth> TableDateOfBirths { get; set; }

    public virtual DbSet<TableFirstName> TableFirstNames { get; set; }

    public virtual DbSet<TableLastName> TableLastNames { get; set; }

    public virtual DbSet<TablePerson> TablePersons { get; set; }

    public virtual DbSet<ViewPerson> ViewPersons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=json_db;Username=postgres;Password=1234;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("uuid-ossp");

        modelBuilder.Entity<TableDateOfBirth>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("table_date_of_births_pkey");

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()");
        });

        modelBuilder.Entity<TableFirstName>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("table_first_names_pkey");

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()");
        });

        modelBuilder.Entity<TableLastName>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("table_last_names_pkey");

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()");
        });

        modelBuilder.Entity<TablePerson>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("table_persons_pkey");

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()");

            entity.HasOne(d => d.DateOfBirthNavigation).WithMany(p => p.TablePeople).HasConstraintName("table_persons_date_of_birth_fkey");

            entity.HasOne(d => d.FirstNameNavigation).WithMany(p => p.TablePeople).HasConstraintName("table_persons_first_name_fkey");

            entity.HasOne(d => d.LastNameNavigation).WithMany(p => p.TablePeople).HasConstraintName("table_persons_last_name_fkey");
        });

        modelBuilder.Entity<ViewPerson>(entity =>
        {
            entity.ToView("view_persons", "relative");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
