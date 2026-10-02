import { get as apiGet, post } from "../../api/index";
import type { UserInfo } from "@/types/DTOs/User";

export const getCurrentUser = () => apiGet<UserInfo | "">("me");
export const logout = () => post("logout");
