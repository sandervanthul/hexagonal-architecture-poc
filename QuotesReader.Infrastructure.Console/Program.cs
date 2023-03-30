using CompositionRoot;
using Microsoft.Extensions.DependencyInjection;

namespace QuotesReader.Infrastructure.Console;

class Program
{
    public static void Main(string[] args)
    {
        var services = new ServiceCollection();
        var serviceProvider = MainComponent.DependencyInjection<ConsoleAdapter>(services).BuildServiceProvider();

        using var scope = serviceProvider.CreateScope();
        var adapter = scope.ServiceProvider.GetService<ConsoleAdapter>();

        while (true)
        {
            var quote = adapter.RequestQuote();
            System.Console.WriteLine(quote.Quote);
            System.Console.WriteLine("\n\nPress any key for another quote");
            System.Console.ReadKey();
            System.Console.Clear();
        }
    }
}