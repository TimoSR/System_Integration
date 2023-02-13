using System;

namespace MyProgram
{


    public class ReadParseFiles
    {

        // File Info

        private readonly string fileFolder = "../files/";
        private readonly string textFilename = "text_file.txt";

        // Data Buckets

        private dynamic? txtContents;

        public ReadParseFiles()
        {

        }

        public void readingTextFile()
        {

            string filepath = $"{fileFolder + textFilename}";

            try
            {
                txtContents = File.ReadAllText(filepath);
                Console.WriteLine(txtContents);
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

        public void readParseJsonFile() {
            
        }

    }

}