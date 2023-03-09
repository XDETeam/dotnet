namespace Xde.Data.Information;

public class TermFlashCard
    : IFlashCard<Term>
{
    IEnumerable<FlashCard> IFlashCard<Term>.GetCards(Term defintion) => new[]
    {
        new FlashCard()
        {
            Front = defintion.Name,
            Back = defintion.Defintion,
            Reversible = true
        }
    };
}
