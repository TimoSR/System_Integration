using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileHandlerLib.application;
using FileHandlerLib.domain;

namespace console_app
{
    public class TestClass
    {
        static void Main(string[] args)
        {
            FileReader fileReader = new FileReader();
            var jsonFile = fileReader.readJsonFile();
            var textFile = fileReader.readTextFile();
            JsonSerializer serializer = new JsonSerializer();
            var yamlFile = serializer.YamlToJson();

            Console.WriteLine(jsonFile);
            Console.WriteLine(textFile);
            Console.WriteLine(yamlFile);
        }
    }
}