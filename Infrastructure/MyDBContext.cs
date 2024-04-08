using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
namespace Infrastructure;


internal class MyDBContext : DbContext
{
    static string connectionString = "Server=localhost,1435;Database=master;User Id=sa;Password=Myp@ssword1;TrustServerCertificate=True;";

    public MyDBContext() : base (GetOptions()) { }
    public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
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
    private static DbContextOptions GetOptions()
    {
        return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
    }
}