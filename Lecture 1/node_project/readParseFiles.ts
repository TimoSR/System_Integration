import * as fs from 'fs';
import yamljs from 'yamljs';
import papaparse from 'papaparse';
import xml2js from 'xml2js';

export default class ReadParseFiles {

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

    public async readParseTextFile() {

        const filepath: string = `${this.fileFolder + this.textFilename}`; 

        try {
            const data = await fs.promises.readFile(filepath, this.ENCODING);
            this.txtContents = data;
            //console.log(this.txtContents);
        } catch (err) {
            console.error(err);
        }
    }

    public async readParseJsonFile() {

        const filepath: string = `${this.fileFolder + this.jsonFilename}`
        
        try {
            const data = await fs.promises.readFile(filepath, this.ENCODING);
            this.jsonContents = JSON.parse(data);
            //console.log(this.jsonContents);
        } catch (err) {
            console.error(err);
        }
    }

    public async readParseYamlToJson() {

        const filepath: string = this.fileFolder + this.yamlFilename;

        try {
            const data = await fs.promises.readFile(filepath, this.ENCODING);
            this.yamlContents = yamljs.parse(data.toString());
            //console.log(this.yamlContents);
        } catch (err) {
            console.error(err);
        }
    }

    public async readParseCsvToJson() {

        const filepath: string = this.fileFolder + this.csvFilename;

        try {
            const data = await fs.promises.readFile(filepath, this.ENCODING);
            this.csvContents = papaparse.parse(data, {
                header: true,
                dynamicTyping: true,
                transformHeader: header => header.toLowerCase().replace(/\W/g, '')
            }).data;
            //console.log(this.csvContents);
        } catch (err) {
            console.error(err);
        }
    }

    public async readParseXmlToJson() {

        const filepath = this.fileFolder + this.xmlFilename;
        const parser = new xml2js.Parser();

        try {
            const data = await fs.promises.readFile(filepath, this.ENCODING);
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
                } 
                catch (err) {
                    console.error(err);
                }
            
            });
            
        } 
        catch (err) {
            console.error(err);
        }
    }
}

