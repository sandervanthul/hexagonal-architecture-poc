namespace QuotesReader.Infrastructure.EntityFramework;

public class QuoteRecord
{
    public int Id { get; set; }
    public string Text { get; set; }
    public string Attribution { get; set; }
}