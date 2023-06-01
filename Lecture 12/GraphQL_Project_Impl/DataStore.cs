using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL_Project_Impl.Types;

namespace GraphQL_Project_Impl;

public class DataStore
{
    private List<User> users;
    private List<Blog> blogs;

    public DataStore()
    {
        users = new List<User>();
        blogs = new List<Blog>();
    }

    // User methods
    public InsertResult CreateUser(string email, string password)
    {
        var newUser = new User
        {
            Id = Guid.NewGuid(),
            Email = email,
            Password = password
        };
        users.Add(newUser);

        return new InsertResult { Id = newUser.Id };
    }

    // blog methods
    public InsertResult CreateBlog(string title, string description)
    {
        var newBlog = new Blog
        {
            Id = Guid.NewGuid(),
            Title = title,
            Description = description,
            Completed = false,
            OwnerId = Guid.Empty // Set the owner ID accordingly
        };
        blogs.Add(newBlog);

        return new InsertResult { Id = newBlog.Id };
    }

    public BlogsResult GetAllBlogs()
    {
        return new BlogsResult { Blogs = blogs };
    }

    public BlogResult GetBlogById(Guid blogId)
    {
        var blog = blogs.Find(b => b.Id == blogId);

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