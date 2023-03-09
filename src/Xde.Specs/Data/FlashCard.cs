namespace Xde.Data;

public class FlashCard
{
    /// <summary>
    /// Front side
    /// </summary>
    /// <remarks>
    /// Front side of the flash card
    /// </remarks>
    public string Front { get; set; }

    /// <summary>
    /// Back side
    /// </summary>
    /// <remarks>
    /// Back side of the flash card
    /// </remarks>
    public string Back { get; set; }

    /// <summary>
    /// TODO:
    /// </summary>
    /// <remarks>
    /// Flashcard is reversible, so <see cref="Front"/> side can be used as
    /// a question as well as a <see cref="Back"/> side.
    /// </remarks>
    public bool Reversible { get; set; } = false;
}
