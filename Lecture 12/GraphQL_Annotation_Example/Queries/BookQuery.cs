namespace GraphQL_Example;

[ExtendObjectType("Query")]
public class BookQuery
{
    public Book GetSchemaBook()
    {
        return new Book("C# in depth", "Jon Skeet");
    }
}

public record Book(string Title, string Author);