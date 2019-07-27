namespace Sde.Social
{
    /// <summary>
    /// TODO:
    /// </summary>
    public class PersonSample
    {
        public static PersonSample Alice = new PersonSample
        {
            Id = 1,
            FirstName = "Alice",
            LastName = "Smith"
        };

        public static PersonSample Bob = new PersonSample
        {
            Id = 2,
            FirstName = "Bob",
            LastName = "Johnson"
        };

        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
