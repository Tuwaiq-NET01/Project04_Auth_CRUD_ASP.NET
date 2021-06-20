import axios from "axios";

const API_URL = "/api/tags";

const getTags = () => {
  return axios
    .get(API_URL)
    .then((res) => {
      return res.data;
    })
    .catch((err) => console.log(err));
};

const TagsService = {
  getTags,
};

export default TagsService;
