using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL_Project_Impl.Types;

namespace GraphQL_Project_Impl;

public static class DataStore
{
    public static List<User> users { get; set; }
    public static List<Blog> blogs { get; set; }

    static DataStore()
        {
            users = new List<User>();
            blogs = new List<Blog>();
        }
}