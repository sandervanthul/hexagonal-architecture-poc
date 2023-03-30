namespace QuotesReader.Infrastructure.Common.ViewModels;

public class QuoteViewModel
{
    public string Quote { get; set; }

    public QuoteViewModel(string quote)
    {
        Quote = quote;
    }
}