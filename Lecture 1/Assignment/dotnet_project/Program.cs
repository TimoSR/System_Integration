using System;

namespace MyProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadParseFiles readParser = new ReadParseFiles();

            readParser.readParseTextFile();
            readParser.readParseJsonFile();
            readParser.readParseYamlToJson();
            readParser.readParseCsvToJson();
            readParser.readParseXmlToJson();

        }
    }
}
