import axios from "axios";

const baseURL = (import.meta.env.VITE_BASE_API_URL ??
  "https://localhost:5001/api") as string;

const axiosInstance = axios.create({
  baseURL,
  withCredentials: true,
  headers: {
    "Content-Type": "application/json",
  },
});

export default axiosInstance;
