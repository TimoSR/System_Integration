using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json;
using FileHandlerLib.domain;

namespace FileHandlerLib.application
{
    public class PersonJsonEncoder
    {

        public dynamic settings = new JsonSerializerOptions { WriteIndented = true };
        
        private readonly string yaml_filename = "yaml_file.yaml";

        string filesFolderPath = Path.Combine("files");

        public PersonJsonEncoder() {}        

        public string readYamlFile() {
            return "";
        }

    }
}