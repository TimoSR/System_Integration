using System;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using GraphQL_Project_Impl.Types;

namespace GraphQL_Project_Impl.Mutations
{
    [ExtendObjectType("Mutation")]
    public class BlogMutation
    {
        public async Task<Blog> CreateBlog(string title, string description)
        {
            var newBlog = new Blog
            {
                Id = Guid.NewGuid(),
                Title = title,
                Description = description,
                Completed = false
            };

            DataStore.blogs.Add(newBlog);

            return await Task.FromResult(newBlog);
        }
    }
}