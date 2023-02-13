
from fastapi import FastAPI;

app = FastAPI(prefix="/api")

@app.get("/")
def root():
    return {"message": "First FastApi route"}


@app.get("/newroute")
def _():
    return {"message": "This is my second route"}