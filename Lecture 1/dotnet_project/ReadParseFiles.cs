using System;
using YamlDotNet.Serialization;
using System.Text.Json;

namespace MyProgram
{


    public class ReadParseFiles
    {

        // File Info

        private readonly string fileFolder = "../files/";
        private readonly string textFilename = "text_file.txt";
        private readonly string jsonFilename = "json_file.json";
        private readonly string yamlFilename = "yaml_file.yaml";
        private readonly string csvFilename = "csv_file.csv";

        // Data Buckets

        private dynamic? txtContents;
        private dynamic? jsonContents;
        private dynamic? yamlContents;

        public ReadParseFiles()
        {

        }

        public void readParseTextFile()
        {

            string filepath = $"{fileFolder + textFilename}";

            try
            {
                txtContents = File.ReadAllText(filepath);
                //Console.WriteLine(txtContents);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"The file could not be found: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while reading the file: {ex.Message}");
            }

        }

        public void readParseJsonFile()
        {

            string filepath = $"{fileFolder + jsonFilename}";

            try
            {
                var cache = File.ReadAllText(filepath);
                // converting the jsonString to a jsonObject
                jsonContents = JsonSerializer.Deserialize<JsonElement>(cache);
                // Console.WriteLine(jsonContents);
                // // Testing if object was successfully created
                // string name = jsonContents.GetProperty("name").GetString();
                // Console.WriteLine(name);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"The file could not be found: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while reading the file: {ex.Message}");
            }

        }

        public void readParseYamlToJson()
        {

            string filepath = $"{fileFolder + yamlFilename}";

            try
            {
                var cache = File.ReadAllText(filepath);
                var deserializer = new DeserializerBuilder().Build();
                // Converting the string to a yaml object
                var yamlObject = deserializer.Deserialize(new StringReader(cache));
                // Converting the yamlObject to a jsonString
                var jsonString = JsonSerializer.Serialize(yamlObject, new JsonSerializerOptions { WriteIndented = true });
                // Converting the jsonString to a jsonObject
                yamlContents = JsonSerializer.Deserialize<JsonElement>(jsonString);
                // Console.WriteLine(yamlContents);
                // // Testing if object was successfully created
                // string name = yamlContents.GetProperty("name").GetString();
                // Console.WriteLine(name);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"The file could not be found: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while reading the file: {ex.Message}");
            }

        }

    }

}