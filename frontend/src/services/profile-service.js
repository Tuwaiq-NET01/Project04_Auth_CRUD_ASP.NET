import axios from "axios";

const API_URL = "/api/profile";

const getProfile = () => {
  return axios
    .get(API_URL)
    .then((res) => {
      return res.data;
    })
    .catch((err) => console.log(err));
};

const editProfile = (profile) => {
  return axios.put(API_URL, profile);
};

const ProfileService = {
  getProfile,
  editProfile,
};

export default ProfileService;
