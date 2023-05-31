using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL_Schema_Example.Schema;

namespace GraphQL_Schema_Example.Queries
{
    public class Query
    {
        public Book GetBook()
        {
            return new Book("C# in depth", "Jon Skeet" );
        }
    }
}