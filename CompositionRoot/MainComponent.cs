using Domain.Entities.Quote;
using Domain.UseCases.GiveQuote;
using Infrastructure.Console;
using Infrastructure.EntityFramework;
using Infrastructure.Repositories;
using Infrastructure.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CompositionRoot;

public static class MainComponent
{
    public static ServiceProvider SetupDependencyInjectionConsole()
    {
        var services = new ServiceCollection();
        return SetupDependencyInjection(services).BuildServiceProvider();
    }
    
    private static IServiceCollection SetupDependencyInjection(IServiceCollection services)
    {
        var connectionString = Environment.GetEnvironmentVariable("SQL_SERVER_CONNECTION_STRING");
        
        services.AddDbContext<DatabaseContext>(options =>
        {
            options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Infrastructure"));
        });

        services.AddScoped<IObtainQuotesPort, QuotesByProgrammersUsingJson>()
            .AddScoped<IGiveQuotePort, GiveQuoteUseCase>()
            .AddScoped<ConsoleAdapter>();

        return services;
    }
    
    public static void Register(this IServiceCollection services, IConfiguration configuration)
    {
        SetupDependencyInjection(services);
    }
}