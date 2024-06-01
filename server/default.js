import User from "./models/User.js";
import { users } from "./constants/userdata.js";

const DefaultData = async () => {
  try {
    await User.insertMany(users);
    console.log("data imported");
  } catch (error) {
    console.log("error");
  }
};

export default DefaultData;