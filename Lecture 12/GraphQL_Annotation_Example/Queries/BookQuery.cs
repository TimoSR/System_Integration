using GraphQL_Annotation_Example.Schema;

namespace GraphQL_Annotation_Example.Queries;

[ExtendObjectType("Query")]
public class BookQuery
{
    public Book GetSchemaBook()
    {
        return new Book("C# in depth", "Jon Skeet");
    }
}