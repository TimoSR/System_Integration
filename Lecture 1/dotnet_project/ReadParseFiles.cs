using System;

namespace MyProgram
{


    public class ReadParseFiles
    {

        // File Info

        private readonly string fileFolder = "../files/";
        private readonly string textFilename = "text_file.txt";

        // Data Buckets

        private dynamic? txtContents = null;

        public ReadParseFiles()
        {

        }

        public void readingTextFile()
        {

            string filepath = $"{fileFolder + textFilename}";

            txtContents = File.ReadAllText(filepath);

            Console.WriteLine(txtContents);

        }

    }

}