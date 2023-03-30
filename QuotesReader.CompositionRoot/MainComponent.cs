using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QuotesReader.Core.Entities.Quote;
using QuotesReader.Core.UseCases.GiveQuote;
using QuotesReader.Infrastructure.EntityFramework;
using QuotesReader.Infrastructure.Repositories;

namespace CompositionRoot;

public static class MainComponent
{
    public static IServiceCollection DependencyInjection<T>(IServiceCollection services) where T : class
    {
        var connectionString = Environment.GetEnvironmentVariable("SQL_SERVER_CONNECTION_STRING");
        
        services.AddDbContext<DatabaseContext>(options =>
        {
            options.UseSqlServer(connectionString, b => b.MigrationsAssembly("QuotesReader.Infrastructure"));
        });

        services.AddScoped<IObtainQuotesPort, QuotesByScientistsUsingEf>() // configurable dependency; switch between QuotesByFamousPeopleUsingArray
            .AddScoped<IGiveQuotePort, GiveQuoteUseCase>()                 // or QuotesByScientistsUsingEf or QuotesByProgrammersUsingJson
            .AddScoped<T>();

        return services;
    }
}