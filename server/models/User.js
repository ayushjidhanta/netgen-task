import mongoose from "mongoose";

const UserSchema = {
  name: String,
  email: String,
  password: String,
};

const User = mongoose.model('user', UserSchema);
export default User;
