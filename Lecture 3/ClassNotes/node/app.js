import express from "express";
const app = express();

// localhost can ikke bruges da det er loopback address

app.get("/datefromfastapi", async (req, res) => {

    try {
        const response = await fetch("http://127.0.0.1:8000/date")
        const date = await response.json();
        res.send(date);
    }
    catch (err) {
        console.error(err);
    }
    
})

app.get("/jokes", async (req, res) => {

    try {
        const response = await fetch("https://2092-195-249-146-101.eu.ngrok.io/jokes")
        const date = await response.json();
        res.send(date);
    }
    catch (err) {
        console.error(err);
    }
    
})


app.get("/jokes", (req, res) => {
    res.send("Why don't scientists trust atoms? Because they make up everything!");
})


app.get("/date", (req, res) => {
    res.send(new Date());
})

app.listen(8100, () => {
    console.log("Server is running on port ", 8100)})