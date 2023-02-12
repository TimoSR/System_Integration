import * as fs from 'fs';
import yamljs from 'yamljs';
import papaparse from 'papaparse';
import xml2js from 'xml2js';

 class Main {

    // File info

    private readonly fileFolder: string = '../files/';
    private readonly textFilename: string = 'text_file.txt';
    private readonly jsonFilename: string = 'json_file.json';
    private readonly yamlFilename: string = 'yaml_file.yaml';
    private readonly csvFilename: string = 'csv_file.csv';
    private readonly xmlFilename: string = 'xml_file.xml';
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
                console.error(err);
                return;
            }
        
            // As the data in a text file are just plain text, there is no need to parse the contents into a specific data type.

            try {
                this.txtContents = data;
                //console.log(this.txtContents);
            } catch (err) {
                console.error(err);
            }
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
                //console.log(this.jsonContents);
            } catch (err) {
                console.error(err);
            }

        })

    }

    public readingParseYamlToJson() {
        const filepath: string = this.fileFolder + this.yamlFilename;

        fs.readFile(filepath, this.ENCODING, (err, data) => {

            if (err) {
                console.error(err);
                return;
            }

            try {
                this.yamlContents = yamljs.parse(data.toString());
                console.log(this.yamlContents);
            } catch (err) {
                console.error(err);
                return;
            }
        })

    }

    public readingParseCsvToJson() {

        const filepath: string = this.fileFolder + this.csvFilename;

        fs.readFile(filepath, this.ENCODING, (err, data) => {

            if(err) {
                console.error(err);
                return;
            }

            try {
                this.csvContents = papaparse.parse(data, {
                    header: true,
                    dynamicTyping: true,
                    transformHeader: header => header.toLowerCase().replace(/\W/g, '')
                  }).data;
                //console.log(this.csvContents);
            } catch (err) {
                console.error(err);
                return;
            }
        })

    }

    public readParseXmlToJson() {

        const filepath = this.fileFolder + this.xmlFilename;
        const parser = new xml2js.Parser();

        fs.readFile(filepath, this.ENCODING, (err, data) => {

            if (err) {
                console.error(err);
                return;
            }

            parser.parseString(data, (err, result) => {

                if (err) {
                console.error(err);
                return;
                }

                try {
                    const person = result.person;

                    this.xmlContents = {
                        name: person.name[0],
                        age: parseInt(person.age[0]),
                        email: person.email[0],
                        address: {
                            street: person.address[0].street[0],
                            city: person.address[0].city[0],
                            state: person.address[0].state[0],
                            zip: person.address[0].zip[0]
                        }
                    };

                    //console.log(this.xmlContents);
                
                } catch (err) {
                    console.error(err);
                }

                
            });

        });
        
    }
          
 }

const main = new Main();
main.readingTextFile(); 
main.readingJsonFile();
main.readingParseYamlToJson();
main.readingParseCsvToJson();
main.readParseXmlToJson();