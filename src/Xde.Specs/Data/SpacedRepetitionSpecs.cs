using Microsoft.Extensions.DependencyInjection;
using Xde.Data.Information;
using Xunit;

namespace Xde.Data;

public class SpacedRepetitionSpecs
{
    //TODO:Term/contact(birtdate/contact) as a flash card
    //TODO:We will need smth as a flashcard provider that can be tested here

    [Fact]
    public void TestTerm()
    {
        var services = new ServiceCollection();
        services.AddSingleton<IFlashCard<Term>, TermFlashCard>();
        var provider = services.BuildServiceProvider();

        var term = new Term()
        {
            Name = "Smth",
            Defintion = "Defintion of smth"
        };

        var cards = provider
            .GetService<IFlashCard<Term>>()
            ?.GetCards(term)
        ;

        Assert.NotNull(cards);
        Assert.Single(cards);

        var card = cards.Single();

        Assert.Equal(card.Front, term.Name);
        Assert.Equal(card.Back, term.Defintion);
    }
}
