using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileHandlerLib.application
{
    public class FileReader
    {
        
        private readonly string textFilename = "text_file.txt";
        private readonly string jsonFilename = "json_file.json";

        string filesFolderPath = Path.Combine("files");

        public FileReader() {}

        public string readJsonFile()
        {
            string filePath = Path.Combine(filesFolderPath, jsonFilename);
            string jsonString = "";
            
            try
            {
                jsonString = File.ReadAllText(filePath);
            }
            catch (Exception err)
            {
                Console.Error.WriteLine(err);
            }
            return jsonString;

        }

        public string readTextFile() 
        {
            string filePath = Path.Combine(filesFolderPath, textFilename);
            string textString = "";

            try {
                textString = File.ReadAllText(filePath);
            } catch(Exception err) {
                Console.Error.WriteLine(err);
            }
            return textString;
        }

    }
}