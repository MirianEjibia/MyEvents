import { z } from "zod";

export const EventSchema = z.object({
  name: z.string(),
});

EventSchema.required({ name: true });
