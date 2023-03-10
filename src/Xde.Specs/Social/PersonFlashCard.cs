using Xde.Data;

namespace Xde.Social;

public class PersonFlashCard
    : IFlashCard<Person>
{
    IEnumerable<FlashCard> IFlashCard<Person>.GetCards(Person item)
    {
        yield return new FlashCard { Front = $"Birtday of {item.Name}", Back = item.Birthday, Reversible = true };
        yield return new FlashCard { Front = $"Phone of {item.Name}", Back = item.Phone, Reversible = true };
    }
}
