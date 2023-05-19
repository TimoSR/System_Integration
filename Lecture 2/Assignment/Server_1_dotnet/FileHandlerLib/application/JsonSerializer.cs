using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json;
using YamlDotNet.Serialization;
using FileHandlerLib.domain;

namespace FileHandlerLib.application
{
    public class JsonSerializer
    {

        public dynamic settings = new JsonSerializerOptions { WriteIndented = true };
        
        private readonly string yamlFilename = "yaml_file.yaml";

        string filesFolderPath = Path.Combine("files");

        public JsonSerializer() {}        

        public string YamlToJson() 
        {
            string filePath = Path.Combine(filesFolderPath, yamlFilename);
            string jsonString = "";
            var deserializer = new DeserializerBuilder().Build();

            try
            {
                // Reading the yaml file
                var yamlString = File.ReadAllText(filePath);
                // Parsing the yamlString to a yamlObject
                var yamlObject = deserializer.Deserialize(new StringReader(yamlString));
                // Serializing the yamlObject to a jsonString
                jsonString = System.Text.Json.JsonSerializer.Serialize(yamlObject, settings);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"The file could not be found: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while reading the file: {ex.Message}");
            }

            return jsonString;
        }

    }
}