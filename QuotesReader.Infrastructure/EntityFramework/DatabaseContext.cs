using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace QuotesReader.Infrastructure.EntityFramework;

public class DatabaseContext : DbContext
{
    public DbSet<QuoteRecord> Quotes { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<QuoteRecord>().HasData(
            new QuoteRecord() { Id = 1, Text = "Test1", Attribution = "Test2" },
            new QuoteRecord() { Id = 2, Text = "Test2", Attribution = "Test2" },
            new QuoteRecord() { Id = 3, Text = "Test3", Attribution = "Test3" },
            new QuoteRecord() { Id = 4, Text = "Test4", Attribution = "Test4" }
        );
    }
}

public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
{
    public DatabaseContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Quotes", 
            b => b.MigrationsAssembly("QuotesReader.Infrastructure"));

        return new DatabaseContext(optionsBuilder.Options);
    }
}