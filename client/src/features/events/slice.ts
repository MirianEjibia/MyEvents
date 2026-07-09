import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import { createEvent as createEventRequest, getEvents } from "./api";
import type { CreateEventRequest, EventItem } from "@/types/DTOs/Event";
import type { RootState } from "@/store";

type EventsState = {
  events: EventItem[];
  isLoading: boolean;
  isCreating: boolean;
  createError: string | null;
};
const initialState: EventsState = {
  events: [],
  isLoading: false,
  isCreating: false,
  createError: null,
};

export const fetchEvents = createAsyncThunk<EventItem[]>(
  "events/fetch",
  async () => {
    const res = await getEvents();
    return res;
  },
);

export const createEvent = createAsyncThunk<string, CreateEventRequest>(
  "events/create",
  async (event) => {
    const res = await createEventRequest(event);
    return res;
  },
);

const documentSlice = createSlice({
  name: "documents",
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(fetchEvents.fulfilled, (state, action) => {
        state.events = action.payload;
      })
      .addCase(createEvent.pending, (state) => {
        state.isCreating = true;
        state.createError = null;
      })
      .addCase(createEvent.fulfilled, (state) => {
        state.isCreating = false;
      })
      .addCase(createEvent.rejected, (state, action) => {
        state.isCreating = false;
        state.createError = action.error.message ?? "Failed to create event";
      });
  },
});

export default documentSlice.reducer;

export const EventsListSelector = (state: RootState): EventItem[] =>
  state.events.events;

export const CreateEventStateSelector = (
  state: RootState,
): Pick<EventsState, "isCreating" | "createError"> => ({
  isCreating: state.events.isCreating,
  createError: state.events.createError,
});
