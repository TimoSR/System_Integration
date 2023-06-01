using GraphQL_Project_Impl.Types;

namespace GraphQL_Project_Impl.Queries;

[ExtendObjectType("Query")]
public class BookQuery
{
    public Book GetBook()
    {
        return new Book("C# in depth", "Jon Skeet");
    }
}