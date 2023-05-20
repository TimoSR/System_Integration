import json
import csv
import xmltodict

class FileHandler:

    def __init__(self):
        # Using name mangling to make the variable harder to access
        self.__fileFolder = "./files/"
        self.__csvFileName = "csv_file.csv"
        self.__xmlFileName = "xml_file.xml"

    def __call__(self):
        self.serialize_csv_to_json()

    def fileFolder(self):
        return self.__fileFolder
    
    def csvFileName(self):
        return self.__csvFileName
    
    def xmlFileName(self):
        return self.__xmlFileName

    def serialize_csv_to_json(self):

        filepath = f"{self.fileFolder()}{self.csvFileName()}"
        jsonObject = None

        try:

            with open(filepath, 'r') as file:
                reader = csv.DictReader(file)
                csvData = [row for row in reader]

            csvContents = [self.transformCsvToPerson(row) for row in csvData]

            # Serilizing the csv contents into a json string
            jsonString = json.dumps(csvContents, indent=2)

            # It is required in FastAPI to parse/marshal the jsonString to an Json Object
            # before sending it as a response.
            jsonObject = json.loads(jsonString)

        except IOError as err:

            print(f"Error reading file: {err}")

        return jsonObject
    
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