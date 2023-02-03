﻿using Domain.UseCases.GiveQuote;
using Infrastructure.Common.ViewModels;

namespace Infrastructure.Common.Presenters;

public class QuotePresenter
{
    public QuoteViewModel Present(GiveQuoteResponse quote)
    {
        var presentation = $"Quote:\n{quote.Text} - {quote.Attribution}";
        return new QuoteViewModel(presentation);
    }
}