import type { EventItem } from "@/types/DTOs/Event";
import { get as apiGet } from "../../api/index";

export const getEvents = () => apiGet<EventItem[]>("events");
