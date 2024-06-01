import mongoose, { connect } from "mongoose";
const URI =
  "mongodb+srv://admin:admin@demo.ai1hmta.mongodb.net/?retryWrites=true&w=majority";
const connectToMongo = () => {
    try {
        connect(URI);
        console.log("Mongodb connected")
    } catch(error) {
        console.log("Error", error.message);
    }

};

export default connectToMongo;
