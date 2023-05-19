using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json;
using JsonFileEncoderLib.domain;

namespace JsonFileEncoderLib.application
{
    public class PersonJsonEncoder
    {

        public dynamic settings = new JsonSerializerOptions { WriteIndented = true };

        // File Info
        // .. if files is outside a project folder
        private readonly string jsonFilename = "json_file.json";
        private readonly string yaml_filename = "yaml_file.yaml";
        private readonly string text_filename = "text_file.txt";

        string filesFolderPath = Path.Combine("files");

        public PersonJsonEncoder() {}

        public string readJsonFile()
        {

            string filePath = Path.Combine(filesFolderPath, jsonFilename);
            Console.WriteLine(filePath);
            string jsonString = "";

            try
            {

                jsonString = File.ReadAllText(filePath);
                //Console.WriteLine(jsonString);

            }
            catch (Exception err)
            {

                Console.Error.WriteLine(err);

            }

            return jsonString;

        }

    }
}