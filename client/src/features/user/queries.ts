import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import { getCurrentUser, logout } from "./api";

export const userKeys = {
  me: ["user", "me"] as const,
};

export const useCurrentUser = () =>
  useQuery({
    queryKey: userKeys.me,
    queryFn: async () => {
      const res = await getCurrentUser();
      // GET /api/me returns 204 with an empty body when there's no logged-in user
      return res || null;
    },
  });

export const useLogOut = () => {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: logout,
    onSuccess: () => {
      queryClient.setQueryData(userKeys.me, null);
      queryClient.removeQueries({
        predicate: (q) => q.queryKey[0] !== "user",
      });
    },
  });
};
