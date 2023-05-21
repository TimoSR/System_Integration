import json
import csv
import xmltodict

class ReadParseFiles:

    def __init__(self):
        # Using name mangling to make the variable harder to access
        self.__fileFolder = "../files/"
        self.__textFileName = "text_file.txt"
        self.__jsonFileName = "json_file.json"
        self.__yamlFilename = "yaml_file.yaml"
        self.__csvFileName = "csv_file.csv"
        self.__xmlFileName = "xml_file.xml"
        self.__txtContents = None
        self.__jsonContents = None
        self.__yamlContents = None
        self.__csvContents = None
        self.__xmlContents = None

    def __call__(self):
        self.readParseTextFile()
        self.readParseJsonFile()
        self.readParseCsvToJson()

    def fileFolder(self):
        return self.__fileFolder
    
    def textFileName(self):
        return self.__textFileName
    
    def jsonFileName(self):
        return self.__jsonFileName
    
    def yamlFileName(self):
        return self.__yamlFilename
    
    def csvFileName(self):
        return self.__csvFileName
    
    def xmlFileName(self):
        return self.__xmlFileName
    

    def readParseTextFile(self):

        filepath = f"{self.fileFolder()}{self.textFileName()}"

        try:

            with open(filepath, 'r') as file:
                self.__txtContents = file.read()
                #print(self.__txtContents)
                
        except IOError as err:

            print(f"Error reading file: {err}")


    def readParseJsonFile(self):
        
        filepath = f"{self.fileFolder()}{self.jsonFileName()}"

        try:
            
            with open(filepath, 'r') as file:
                self.__jsonContents = json.load(file)

            jsonString = json.dumps(self.__jsonContents, indent=2)

            #print(jsonString)
            #print(self.__jsonContents["name"])

        except IOError as err:
            print(f"Error reading file: {err}")
    

    def readParseCsvToJson(self):

        filepath = f"{self.fileFolder()}{self.csvFileName()}"

        try:

            with open(filepath, 'r') as file:
                reader = csv.DictReader(file)
                csvData = [row for row in reader]

            self.csvContents = [self.transformCsvToPerson(row) for row in csvData]

            jsonString = json.dumps(self.csvContents, indent=2)
            self.__csvContents = json.loads(jsonString)
            selectedJsonElement = self.__csvContents[0]
            formattetElement = json.dumps(selectedJsonElement, indent=2)
            print(formattetElement)
            print(selectedJsonElement["name"])

        except IOError as err:

            print(f"Error reading file: {err}")


    def transformCsvToPerson(self, row):
            name_parts = row["name"].split(" ")
            return {
                "name" : f"{name_parts[0]} {name_parts[1]}",
                "age" : row["age"],
                "email" : row["email"],
                "address": {
                    "street": row["street"],
                    "city": row["city"],
                    "state": row["state"],
                    "zip": row["zip"]
                }
            }
    
    def serialize_xml_to_json(self):

        filepath = f"{self.fileFolder()}{self.xmlFileName()}"
        jsonObject = None

        try:

            with open(filepath, 'r') as file:
                xml_data = file.read()
            
            # Serialing the xml_date to jsonString
            jsonString = json.dumps(xmltodict.parse(xml_data), indent=2)

            # It is required by FastAPI to parse/marshal the jsonString to an Json Object
            # before sending it as a response.
            jsonObject = json.loads(jsonString)
        
        except IOError as err:

            print(f"{err}")

        return jsonObject