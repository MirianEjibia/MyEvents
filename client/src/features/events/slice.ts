import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import { getEvents } from "./api";
import type { EventItem } from "@/types/DTOs/Event";
import type { RootState } from "@/store";

type EventsState = {
  events: EventItem[];
  isLoading: boolean;
};
const initialState: EventsState = {
  events: [],
  isLoading: false,
};

export const fetchEvents = createAsyncThunk<EventItem[]>(
  "events/fetch",
  async () => {
    const res = await getEvents();
    return res;
  },
);

const documentSlice = createSlice({
  name: "documents",
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder.addCase(fetchEvents.fulfilled, (state, action) => {
      state.events = action.payload;
    });
  },
});

export default documentSlice.reducer;

export const EventsListSelector = (state: RootState): EventItem[] =>
  state.events.events;
