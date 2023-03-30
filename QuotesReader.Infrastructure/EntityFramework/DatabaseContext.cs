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