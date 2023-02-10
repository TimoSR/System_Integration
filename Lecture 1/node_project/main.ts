import * as fs from 'fs';

 class Main {

    // File info

    private filepath: string = '../files/';
    private textFilename: string = 'text_file.txt';
    private jsonFilename: string = 'json_file.json';
    private yamlFilename: string = 'yaml_file.yml';
    private csvFilename: string = 'csv_file.csv';
    private xmlFilename: string = 'xml_file.xml';
    private readonly ENCODING = 'utf-8';

    // Data Buckets

    private txtContents: string = '';
    private jsonContents = '';
    private yamlContents = '';
    private csvContents = '';
    private xmlContents = '';

    constructor() {}

    public readingTextFile() {

        fs.readFile(`${this.filepath + this.textFilename}`, this.ENCODING, (err, data) => {
            if (err) {
                console.log(err);
                return;
            }
        
            this.txtContents = data;

            console.log(this.txtContents);
        
        });

    }

    public readingJsonFile() {

    }

    public readingYamlFile() {}

    public readingCsvFile() {}

    public readingXmlFile() {}

 }

const main = new Main();
main.readingTextFile(); 