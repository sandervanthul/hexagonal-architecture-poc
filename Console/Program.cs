using CompositionRoot;
using Infrastructure.Console;
using Microsoft.Extensions.DependencyInjection;

namespace Console;

class Program
{
    public static void Main(string[] args)
    {
        var serviceProvider = MainComponent.SetupDependencyInjectionConsole();
        
        using var scope = serviceProvider.CreateScope();
        var adapter = scope.ServiceProvider.GetService<ConsoleAdapter>();
        
        while (true)
        {
            var quote = adapter.GiveMeAQuote();
            System.Console.WriteLine(quote.Quote);
            System.Console.WriteLine("\n\nPress any key for another quote");
            System.Console.ReadKey();
            System.Console.Clear();
        }
    }
}