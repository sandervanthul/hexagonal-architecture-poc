using Domain.Entities.Quote;
using Infrastructure.EntityFramework;

namespace Infrastructure.Repositories;

public class QuotesByScientistsUsingEf : IObtainQuotesPort
{
    private readonly DatabaseContext _dbContext;

    public QuotesByScientistsUsingEf(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Quote GetRandomQuote()
    {
        long random = Random.Shared.Next(1, _dbContext.Quotes.Count() + 1);
        var quoteRecord = GetQuoteRecordByIdAsync(random).Result;
        
        return new Quote(quoteRecord.Text, quoteRecord.Attribution);
    }
    
    private async Task<QuoteRecord> GetQuoteRecordByIdAsync(long id)
    {
        var quote = await _dbContext.Quotes
            .FindAsync(id);

        if (quote == null)
            throw new NullReferenceException("Id does not exist in database");

        return quote;
    }
}