using QuotesReader.Core.Entities.Quote;

namespace QuotesReader.Core.UseCases.GiveQuote;

public class GiveQuoteUseCase : IGiveQuotePort
{
    private IObtainQuotesPort _repository;
    
    public GiveQuoteUseCase(IObtainQuotesPort repository)
    {
        _repository = repository;
    }

    public GiveQuoteUseCase()
    {
    }
    
    public GiveQuoteResponse GiveQuote()
    {
        var quote = _repository.GetRandomQuote();
        return new GiveQuoteResponse(quote.Text, quote.Attribution);
    }
}