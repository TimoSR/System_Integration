using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testproject.application;

namespace testproject
{
    public class TestClass
    {
        static void Main(string[] args)
        {
            PersonFilesParser parser = new PersonFilesParser();

            var contents = parser.jsonContents;

            Console.WriteLine(contents?.ToString());
            Console.WriteLine(contents?.GetType().ToString());

        }
    }
}