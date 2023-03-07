using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json;
using testproject.domain;

namespace testproject.application
{
    public class PersonFilesParser
    {
        // File Info
        // .. if files is outside a project folder
        private readonly string fileFolder = "./files/";
        private readonly string jsonFilename = "person_file.json";

        // Data Buckets

        private dynamic? _jsonContents;
        public dynamic? jsonContents { get => _jsonContents; set => _jsonContents = value; }

        // Getters

        public string? name { get; set; }
        public int age { get; set; }
        public string? email { get; set; }
        public string? street { get; set; }
        public string? city { get; set; }
        public string? state { get; set; }
        public string? zip { get; set; }

        public PersonFilesParser(string type = "")
        {
            switch (type)
            {
                default:
                    readParseJsonFile();
                    break;
            }
        }

        private void readParseJsonFile()
        {

            string filepath = fileFolder + jsonFilename;

            try
            {

                var jsonString = File.ReadAllText(filepath);
                // Converting jsonString to Person object
                var person = JsonConvert.DeserializeObject<Person>(jsonString);
                // Creating a good format for the console
                var formatetJson = JsonConvert.SerializeObject(person, Formatting.Indented);
                //Console.WriteLine(formatetJson);
                _jsonContents = person;

                // Setting getters
                name = person.name;
                age = person.age;
                email = person.email;
                street = person.address.street;
                city = person.address.city;
                state = person.address.state;
                zip = person.address.zip;


                // Checking if contents is accesble

                // Console.WriteLine(name);
                // Console.WriteLine(age);
                // Console.WriteLine(email);
                // Console.WriteLine(street);
                // Console.WriteLine(city);
                // Console.WriteLine(state);
                // Console.WriteLine(zip);

            }
            catch (Exception err)
            {

                Console.Error.WriteLine(err);

            }

        }

    }
}