using GraphQL_Project_Impl.Types;

namespace GraphQL_Project_Impl.Queries;

[ExtendObjectType("Query")]
public class BlogQuery
{
    public BlogResult GetBlogById(Guid blogId)
    {
        var blog = DataStore.blogs.Find(b => b.Id == blogId);

        if (blog != null)
        {
            return new BlogResult { Blog = blog };
        }
        else
        {
            return new BlogResult { Errors = new List<string> { "Blog not found." } };
        }
    }
}