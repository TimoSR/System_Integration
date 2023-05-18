using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using file_read_parser_lib.application;
using file_read_parser_lib.domain;

namespace console_app
{
    public class TestClass
    {
        static void Main(string[] args)
        {
            PersonFilesParser parser = new PersonFilesParser();

            var contents = parser.jsonContents;

            Console.WriteLine(contents?.ToString());
            Console.WriteLine(contents?.GetType().ToString());
            Console.WriteLine(parser.age);

        }
    }
}