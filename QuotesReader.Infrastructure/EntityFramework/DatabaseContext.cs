using Microsoft.EntityFrameworkCore;

namespace QuotesReader.Infrastructure.EntityFramework;

public class DatabaseContext : DbContext
{
    public DbSet<QuoteRecord> Quotes { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }
}