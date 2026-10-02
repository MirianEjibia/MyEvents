import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import { createEvent, getEvents } from "./api";

export const eventKeys = {
  all: ["events"] as const,
};

export const useEvents = () =>
  useQuery({
    queryKey: eventKeys.all,
    queryFn: getEvents,
  });

export const useCreateEvent = () => {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: createEvent,
    onSuccess: () => queryClient.invalidateQueries({ queryKey: eventKeys.all }),
  });
};
