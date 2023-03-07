from fastapi import FastAPI
from datetime import datetime
import requests

app = FastAPI()

@app.get("/date")
def get_date():
    return datetime.now()

# Reaching the endpoint
@app.get("/datefromexpress")
def get_date_from_express():
    response = requests.get("http://127.0.0.1:8100/date")
    return response.json()

# Reaching ngrok endpoint
@app.get("/jokes")
def get_joke_from_ngrok():
    response = requests.get("https://2092-195-249-146-101.eu.ngrok.io/jokes")
    joke = response.json()
    return joke