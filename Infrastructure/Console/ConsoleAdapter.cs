using Domain.UseCases.GiveQuote;
using Infrastructure.Common.Presenters;
using Infrastructure.Common.ViewModels;

namespace Infrastructure.Console;

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