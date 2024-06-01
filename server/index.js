import express from "express";
import connectToMongo from "./db.js";
import DefaultData from "./default.js";

connectToMongo();

const app = express();
const port = 5000;

app.listen(port, () => {
  console.log("Successfully running on ", port);
});

app.use("/login", (req, res) => {
    res.send("login screen");
})

DefaultData();