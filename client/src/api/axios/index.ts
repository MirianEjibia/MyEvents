import axios from "axios";
import { router } from "../../Routes";
import { paths } from "../../constants/paths";

const baseURL = (import.meta.env.VITE_BASE_API_URL ??
  "https://localhost:5001/api") as string;

const axiosInstance = axios.create({
  baseURL,
  withCredentials: true,
  headers: {
    "Content-Type": "application/json",
  },
});
axiosInstance.interceptors.response.use(
  (res) => {
    return res;
  },
  (err) => {
    if (err.response.status === 401) router.navigate(paths.login);
  },
);

export default axiosInstance;
