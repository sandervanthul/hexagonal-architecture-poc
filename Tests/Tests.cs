using Domain.Entities.Quote;
using Domain.UseCases.GiveQuote;
using FluentAssertions;
using Infrastructure.Console;
using Infrastructure.Common.ViewModels;
using NSubstitute;
using NUnit.Framework;

namespace Tests;

public class Tests
{
    [Test]
    public void Should_give_Quote_when_given_valid_Request()
    {
        var expected = new GiveQuoteResponse("Would you rather Test-First, or Debug-Later?", "Robert Cecil Martin");
        
        // IObtainQuotesPort : right side port
        IObtainQuotesPort repository = Substitute.For<IObtainQuotesPort>();
        repository.GetRandomQuote()
            .Returns(new Quote("Would you rather Test-First, or Debug-Later?", "Robert Cecil Martin"));

        // IGiveQuotePort : left side port
        // GiveQuoteUseCase : the application (the hexagon)
        IGiveQuotePort app = new GiveQuoteUseCase(repository);
        
        var actual = app.GiveQuote();
        
        actual.Should().BeEquivalentTo(expected);
    }
    
    [Test]
    public void Should_give_Quote_when_given_valid_Request_from_a_ConsoleAdapter()
    {
        var expected = new QuoteViewModel("Quote:\nThe only way to go fast, is to go well - Robert Cecil Martin");
            
        // right side port with mock adapter
        IObtainQuotesPort repository = Substitute.For<IObtainQuotesPort>();
        repository.GetRandomQuote()
            .Returns(new Quote("The only way to go fast, is to go well", "Robert Cecil Martin"));
        
        IGiveQuotePort app = new GiveQuoteUseCase(repository);
        
        // left side adapter
        var consoleAdapter = new ConsoleAdapter(app);
        
        var actual = consoleAdapter.GiveMeAQuote();
        
        actual.Should().BeEquivalentTo(expected);
    }
}