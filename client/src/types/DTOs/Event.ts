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
