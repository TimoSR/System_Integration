using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json;
using file_read_parser_lib.domain;

namespace file_read_parser_lib.application
{
    public class PersonFilesParser
    {
        // File Info
        // .. if files is outside a project folder
        private readonly string fileFolder = "../files/";
        private readonly string jsonFilename = "json_file.json";
        private readonly string yaml_filename = "yaml_file.yaml";
        private readonly string text_filename = "text_file.txt";

        public PersonFilesParser() {}

        public void readJsonFile()
        {

            string filepath = fileFolder + jsonFilename;

            try
            {

                var jsonString = File.ReadAllText(filepath);
                Console.WriteLine(jsonString.GetType());

            }
            catch (Exception err)
            {

                Console.Error.WriteLine(err);

            }

        }

    }
}