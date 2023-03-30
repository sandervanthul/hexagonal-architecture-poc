using QuotesReader.Core.UseCases.GiveQuote;
using QuotesReader.Infrastructure.Common.ViewModels;

namespace QuotesReader.Infrastructure.Common.Presenters;

public class QuotePresenter
{
    public QuoteViewModel Present(GiveQuoteResponse quote)
    {
        var presentation = $"Quote:\n{quote.Text} - {quote.Attribution}";
        return new QuoteViewModel(presentation);
    }
}