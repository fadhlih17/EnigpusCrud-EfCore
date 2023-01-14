using EnigpusCrud_EfCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnigpusCrud_EfCore.Repositories;

public class AppDbContext : DbContext
{
    public DbSet<Novel> Novels { get; set; }
    public DbSet<Magazine> Magazines { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=Fadhlih\\SQLEXPRESS;Database=Enigpus;Trusted_Connection=True;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Magazine>(builder =>
        {
            builder.HasIndex(magazine => magazine.Title);
        });

        modelBuilder.Entity<Novel>(modelBuilder =>
        {
            modelBuilder.HasIndex(novel => novel.Title);
        });
    }
}