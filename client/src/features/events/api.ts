import type { CreateEventRequest, EventItem } from "@/types/DTOs/Event";
import { get as apiGet, post as apiPost } from "../../api/index";

export const getEvents = () => apiGet<EventItem[]>("events");

export const createEvent = (event: CreateEventRequest) =>
  apiPost<string>("events", event);
