using Domain.UseCases.GiveQuote;
using Infrastructure.Common.Presenters;
using Infrastructure.Common.ViewModels;

namespace Infrastructure.Web;

public class WebAdapter
{
    private IGiveQuotePort _quoteUseCase;

    public WebAdapter()
    {
    }
    
    public WebAdapter(IGiveQuotePort quoteUseCase)
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