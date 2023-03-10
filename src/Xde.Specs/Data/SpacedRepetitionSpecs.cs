using Microsoft.Extensions.DependencyInjection;
using Xde.Data.Information;
using Xde.Social;
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

    [Fact]
    public void TestContacts()
    {
        var services = new ServiceCollection();
        services.AddSingleton<IFlashCard<Person>, PersonFlashCard>();
        var provider = services.BuildServiceProvider();

        var person = new Person()
        {
            Name = "Someone",
            Birthday = "10.02",
            Phone = "322-223"
        };

        var cards = provider
            .GetService<IFlashCard<Person>>()
            ?.GetCards(person)
        ;

        Assert.NotNull(cards);
        Assert.Equal(2, cards.Count());

        var cardBirthday = cards.Single(card => card.Front == $"Birtday of {person.Name}");
        Assert.Equal(person.Birthday, cardBirthday.Back);

        var cardPhone = cards.Single(card => card.Front == $"Phone of {person.Name}");
        Assert.Equal(person.Phone, cardPhone.Back);
    }
}
