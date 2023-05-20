from fastapi import FastAPI
from file_handler import FileHandler

app = FastAPI()

readParseFiles = FileHandler()

@app.get("/")
def read_root():
    return {"Hello": "FastAPI"}

@app.get("/csvToJson")
def csv_to_json():
    jsonString = readParseFiles.readParseCsvToJson()
    return jsonString


@app.get("/items/{item_id}")
def read_item(item_id: int, q: str = None):
    return {"item_id": item_id, "q": q}
