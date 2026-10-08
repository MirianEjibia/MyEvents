import { useMutation, useQueryClient } from "@tanstack/react-query";
import { logInRequest, registerRequest } from "./api";
import { userKeys } from "@/features/user/queries";
import type { RegisterRequest } from "@/types/DTOs/Register";

export const useLogIn = () => {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: logInRequest,
    onSuccess: () => queryClient.invalidateQueries({ queryKey: userKeys.me }),
  });
};

// POST /api/register only creates the account, so log in right after it
export const useRegister = () => {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: async (data: RegisterRequest) => {
      await registerRequest(data);
      await logInRequest(data);
    },
    onSuccess: () => queryClient.invalidateQueries({ queryKey: userKeys.me }),
  });
};
