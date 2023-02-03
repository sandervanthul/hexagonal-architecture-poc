namespace Domain.UseCases.GiveQuote;

public class GiveQuoteResponse
{
    public string Text { get; set; }
    public string Attribution { get; set; }

    public GiveQuoteResponse(string text, string attribution)
    {
        Text = text;
        Attribution = attribution;
    }
}