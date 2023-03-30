namespace QuotesReader.Core.Entities.Quote;

public class Quote
{
    public string Text { get; set; }
    public string Attribution { get; set; }

    public Quote(string text, string attribution)
    {
        Text = text;
        Attribution = attribution;
    }
}