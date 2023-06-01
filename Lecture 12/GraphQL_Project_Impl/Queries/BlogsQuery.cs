using GraphQL_Project_Impl.Types;

namespace GraphQL_Project_Impl.Queries;

[ExtendObjectType("Query")]
public class BlogsQuery
{
    public BlogsResult GetAllBlogs()
    {
        return new BlogsResult { Blogs = DataStore.blogs };
    }
}