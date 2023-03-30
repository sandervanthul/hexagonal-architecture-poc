using QuotesReader.Core.UseCases.GiveQuote;
using QuotesReader.Infrastructure.Common.Presenters;
using QuotesReader.Infrastructure.Common.ViewModels;

namespace QuotesReader.Infrastructure.Console;

public class ConsoleAdapter
{
    private IGiveQuotePort _quoteUseCase;

    public ConsoleAdapter()
    {
    }

    public ConsoleAdapter(IGiveQuotePort quoteUseCase)
    {
        _quoteUseCase = quoteUseCase;
    }

    public QuoteViewModel GiveMeAQuote()
    {
        var quote = _quoteUseCase.GiveQuote();

        QuotePresenter presenter = new QuotePresenter();
        
        return presenter.Present(quote);
    }
}