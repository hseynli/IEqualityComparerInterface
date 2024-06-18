internal class Program
{
    public static void Main()
    {
        List<Person> list = new() 
        {
            new Person("John", "Doe"),
            new Person("Jane", "Doe"),
            new Person("John", "Smith"),
            new Person("Jane", "Smith")
        };

        bool result = list.Contains(new Person("John", "Doe"));
        Console.WriteLine(result);

        Console.WriteLine("\nDone!");
    }
}

// If we use record then the result must be True, otherwise False
internal class Person(string FirstName, string LastName)
{
    public string FirstName { get; } = FirstName;
    public string LastName { get; } = LastName;
}

internal class PersonEqualityComparer : IEqualityComparer<Person>
{
    public bool Equals(Person x, Person y) => x.FirstName == y.FirstName && x.LastName == y.LastName;

    public int GetHashCode(Person obj) => obj.FirstName.GetHashCode() ^ obj.LastName.GetHashCode();
}