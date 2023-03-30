using QuotesReader.Core.Entities.Quote;
using QuotesReader.Infrastructure.EntityFramework;

namespace QuotesReader.Infrastructure.Repositories;

public class QuotesByScientistsUsingEf : IObtainQuotesPort
{
    private readonly DatabaseContext _dbContext;

    public QuotesByScientistsUsingEf(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Quote GetRandomQuote()
    {
        var count = _dbContext.Quotes.Count();
        int random = Random.Shared.Next(1, count + 1);
        var quoteRecord = GetQuoteRecordByIdAsync(random).Result;
        
        return new Quote(quoteRecord.Text, quoteRecord.Attribution);
    }
    
    private async Task<QuoteRecord> GetQuoteRecordByIdAsync(int id)
    {
        var quote = await _dbContext.Quotes
            .FindAsync(id);

        if (quote == null)
            throw new NullReferenceException("Id does not exist in database");

        return quote;
    }
}