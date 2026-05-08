import axiosInstance from "./axios";

export const get = <T>(url: string, params?: object): Promise<T> =>
  axiosInstance.get<T>(url, { params }).then((res) => res.data);

export const post = <T>(url: string, data?: object): Promise<T> =>
  axiosInstance.post<T>(url, data).then((res) => res.data);
