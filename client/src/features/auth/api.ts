import { post as apiPost } from "../../api/index";
import type { LoginRequest, LoginResponse } from "@/types/DTOs/Auth";

export const logInRequest = (credentials: LoginRequest) =>
  apiPost<LoginResponse>("login", credentials);
