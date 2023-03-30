using QuotesReader.Core.UseCases.GiveQuote;
using QuotesReader.Infrastructure.Common.Presenters;
using QuotesReader.Infrastructure.Common.ViewModels;

namespace QuotesReader.Infrastructure.Web;

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

    public QuoteViewModel RequestQuote()
    {
        var quote = _quoteUseCase.GiveQuote();

        QuotePresenter presenter = new QuotePresenter();
        
        return presenter.Present(quote);
    }
}