import * as fs from 'fs';
import yamljs from 'yamljs';

 class Main {

    // File info

    private fileFolder: string = '../files/';
    private textFilename: string = 'text_file.txt';
    private jsonFilename: string = 'json_file.json';
    private yamlFilename: string = 'yaml_file.yaml';
    private csvFilename: string = 'csv_file.csv';
    private xmlFilename: string = 'xml_file.xml';
    private readonly ENCODING = 'utf-8';

    // Data Buckets

    private txtContents: unknown;
    private jsonContents: unknown;
    private yamlContents: unknown;
    private csvContents: unknown;
    private xmlContents: unknown;

    constructor() {}


    public readingTextFile() {

        const filepath: string = `${this.fileFolder + this.textFilename}`; 

        fs.readFile(filepath, this.ENCODING, (err, data) => {
            if (err) {
                console.log(err);
                return;
            }
        
            // As the data in a text file are just plain text, there is no need to parse the contents into a specific data type.

            this.txtContents = data;

            //console.log(this.txtContents);
        
        });

    }

    public readingJsonFile() {

        const filepath: string = `${this.fileFolder + this.jsonFilename}`
        
        fs.readFile(filepath, this.ENCODING, (err, data) => {
            if (err) {
                console.log(err);
                return;
            }

            try {
                this.jsonContents = JSON.parse(data);
                console.log(this.jsonContents);
            } catch (err) {
                console.log(err);
            }

        })

    }

    public readingYamlFile() {
        const filepath: string = `${this.fileFolder + this.yamlFilename}`

        fs.readFile(filepath, this.ENCODING, (err, data) => {
            if (err) {
                console.log(err);
                return;
            }

            try {
                this.yamlContents = yamljs.parse(data);
                console.log(this.yamlContents);
            } catch (err) {
                console.log(err);
                return;
            }
        })

    }

    public readingCsvFile() {}

    public readingXmlFile() {}

 }

const main = new Main();
main.readingTextFile(); 
main.readingJsonFile();
main.readingYamlFile();