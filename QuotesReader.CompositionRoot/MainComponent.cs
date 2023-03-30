using QuotesReader.Core.Entities.Quote;
using QuotesReader.Core.UseCases.GiveQuote;
using QuotesReader.Infrastructure.EntityFramework;
using QuotesReader.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CompositionRoot;

public static class MainComponent
{
    public static IServiceCollection DependencyInjection<T>(IServiceCollection services) where T : class
    {
        services.AddDbContext<DatabaseContext>(options =>
        {
            options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Quotes", 
                b => b.MigrationsAssembly("QuotesReader.Infrastructure"));
        });

        services.AddScoped<IObtainQuotesPort, QuotesByScientistsUsingEf>() // configurable dependency; switch between QuotesByFamousPeopleUsingArray
            .AddScoped<IGiveQuotePort, GiveQuoteUseCase>()                 // or QuotesByScientistsUsingEf or QuotesByProgrammersUsingJson
            .AddScoped<T>();

        return services;
    }
}