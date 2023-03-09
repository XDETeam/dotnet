namespace Xde.Data;

/// <summary>
/// TODO:Flash card
/// </summary>
/// <typeparam name="T"></typeparam>
/// <remarks>
/// Implemented for <typeparamref name="T"/> if it can be converted into
/// <see cref="FlashCard"/>.
/// </remarks>
public interface IFlashCard<T>
{
    IEnumerable<FlashCard> GetCards(T item);
}
