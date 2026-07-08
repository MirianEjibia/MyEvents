import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import { logInRequest } from "./api";
import type { LoginRequest, LoginResponse } from "@/types/DTOs/Auth";
import type { RootState } from "@/store";

type AuthState = {
  accessToken: string | null;
  refreshToken: string | null;
  isLoading: boolean;
  error: string | null;
};

const initialState: AuthState = {
  accessToken: null,
  refreshToken: null,
  isLoading: false,
  error: null,
};

export const logIn = createAsyncThunk<LoginResponse, LoginRequest>(
  "auth/login",
  async (credentials) => {
    const res = await logInRequest(credentials);
    return res;
  },
);

const authSlice = createSlice({
  name: "auth",
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(logIn.pending, (state) => {
        state.isLoading = true;
        state.error = null;
      })
      .addCase(logIn.fulfilled, (state, action) => {
        state.isLoading = false;
        state.accessToken = action.payload.accessToken;
        state.refreshToken = action.payload.refreshToken;
      })
      .addCase(logIn.rejected, (state, action) => {
        state.isLoading = false;
        state.error = action.error.message ?? "Login failed";
      });
  },
});

export default authSlice.reducer;

export const authSelector = (state: RootState): AuthState => state.auth;
