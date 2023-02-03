using Domain.Entities.Quote;

namespace Infrastructure.Repositories;

public class QuotesByFamousPeopleUsingArray : IObtainQuotesPort
{
    private Quote[] _quotes { get; }

    public QuotesByFamousPeopleUsingArray()
    {
        _quotes = AddQuotes();

        Quote[] AddQuotes()
        {
            var quote1 = new Quote("The greatest glory in living lies not in never falling, but in rising every time we fall.", "Nelson Mandela");
            var quote2 = new Quote("The way to get started is to quit talking and begin doing.", "Walt Disney");
            var quote3 = new Quote("Be the change that you wish to see in the world.", "Mahatma Gandhi");
            var quote4 = new Quote("Be yourself; everyone else is already taken.", "Oscar Wilde");

            return new Quote[] { quote1, quote2, quote3, quote4 };
        }
    }

    public Quote GetRandomQuote()
    {
        var random = Random.Shared.Next(0, _quotes.Length);
        return _quotes[random];
    }
}