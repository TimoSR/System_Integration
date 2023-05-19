using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JsonFileEncoderLib.application;
using JsonFileEncoderLib.domain;

namespace console_app
{
    public class TestClass
    {
        static void Main(string[] args)
        {
            PersonJsonEncoder parser = new PersonJsonEncoder();
            var file = parser.readJsonFile();
            Console.WriteLine(file);

        }
    }
}