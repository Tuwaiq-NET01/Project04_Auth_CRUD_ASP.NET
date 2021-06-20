import axios from "axios";

const API_URL = "/api/account/";

const register = (email, password) => {
  return axios.post(API_URL + "register", {
    email,
    password,
  });
};

const login = async (email, password) => {
  const login = await axios.post(API_URL + "login", {
    email,
    password,
  });
  if (login.status === 200) {
    const user = await axios.get(API_URL + "user");
    return user.data;
  } else {
    return {
      isAuthenticated: false,
      user: "",
    };
  }
};

const isAuthenticated = async () => {
  const res = await axios.get(API_URL + "user");

  if (res.status !== 200) {
    return { isAuthenticated: false, user: {} };
  }
  return res.data;
};

const AuthService = {
  register,
  login,
  isAuthenticated,
};
export default AuthService;
