using GraphQL_Annotation_Example.Schema;

namespace GraphQL_Annotation_Example.Queries;

[ExtendObjectType("Query")]
public class AnnotationQuery 
{
    public string Hello(string name = "World") => $"Hello, {name}!";

    //This will be called Books in GraphQL, as get is not used to describe the data as in REST.
    public IEnumerable<AnnoBook> GetBooks() 
    {
        var author = new Author("Jon Skeet");
        yield return new AnnoBook("C# in Depth", author);
        yield return new AnnoBook("C# in Depth 2nd Edition", author);
    }
    
}