using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
namespace productCrud.Infrastructure;


internal class MyContext : DbContext
{
    static string connectionString = "Server=localhost,1435;Database=YourDatabaseName;User Id=dbo;Password=Myp@ssword1;";
    public MyContext() : base(GetOptions(connectionString))
    { }
    public DbSet<ProductModel> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductModel>()
            .HasKey(b => new { b.ManufactureEmail, b.ProduceDate });
        foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
        {
            modelBuilder.Entity(entityType.Name)
            .ToTable(entityType.ClrType.Name);
        }

    }
    private static DbContextOptions GetOptions(string connectionString)
    {
        return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
    }
}