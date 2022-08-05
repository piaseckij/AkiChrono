using Microsoft.EntityFrameworkCore;

namespace AkiChrono.Model;

public class ChronoDbContext : DbContext
{
    public DbSet<Plane> Planes { get; set; }
    public DbSet<Record> Records { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Plane>()
            .Property(p => p.Name)
            .IsRequired();

        modelBuilder.Entity<Plane>()
            .Property(p => p.TimeAirframe)
            .IsRequired();

        modelBuilder.Entity<Plane>()
            .Property(p => p.TimeEngine)
            .IsRequired();

        modelBuilder.Entity<Plane>()
            .Property(p => p.TimeProp)
            .IsRequired();

        modelBuilder.Entity<Plane>()
            .Property(p => p.TotalTime)
            .IsRequired();

        modelBuilder.Entity<Record>()
            .Property(r => r.Pilot)
            .IsRequired();

        modelBuilder.Entity<Record>()
            .Property(r => r.TimeSum)
            .IsRequired();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=C:\\Users\\Kuba\\source\\repos\\AkiChrono\\AkiChrono\\AkiChronoDb");
    }
}