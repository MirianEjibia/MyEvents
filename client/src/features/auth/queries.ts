import { useMutation, useQueryClient } from "@tanstack/react-query";
import { logInRequest } from "./api";
import { userKeys } from "@/features/user/queries";

export const useLogIn = () => {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: logInRequest,
    onSuccess: () => queryClient.invalidateQueries({ queryKey: userKeys.me }),
  });
};
