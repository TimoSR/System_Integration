from fastapi import FastAPI
from file_handler import FileHandler

app = FastAPI()

readParseFiles = FileHandler()

@app.get("/csvToJson")
def csv_to_json():
    jsonObject = readParseFiles.serialize_csv_to_json()
    return jsonObject

@app.get("/xmlTojson")
def xml_to_json():
    jsonObject = readParseFiles.serialize_xml_to_json()
    return jsonObject