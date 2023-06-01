using GraphQL_Project_Impl.Types;

namespace GraphQL_Project_Impl.Queries;

[ExtendObjectType("Query")]
public class BlogsQuery
{
    public BlogsResult GetAllBlogs()
    {
        try
        {
            return new BlogsResult { Blogs = DataStore.blogs };
        }
        catch
        {
            return new BlogsResult { Errors = new List<string> { "Blog not found." } };
        }   
    }
}