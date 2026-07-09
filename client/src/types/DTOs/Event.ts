export interface EventItem {
  id: string;
  name: string;
  description: string;
  startDate: string;
  endDate: string;
  city: string;
  country: string;
  isCancelled: boolean;
  meridian: number;
  parallel: number;
}

export type EventItemList = Array<EventItem>;

export interface CreateEventRequest {
  name: string;
  description: string;
  startDate: string;
  country: string;
  city: string;
  parallel: number;
  meridian: number;
}
