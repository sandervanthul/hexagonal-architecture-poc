using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using QuotesReader.Core.Entities.Quote;
using QuotesReader.Core.UseCases.GiveQuote;
using QuotesReader.Infrastructure.Common.ViewModels;
using QuotesReader.Infrastructure.Console;

namespace QuotesReader.Tests;

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

        var actual = consoleAdapter.RequestQuote();

        actual.Should().BeEquivalentTo(expected);
    }
}