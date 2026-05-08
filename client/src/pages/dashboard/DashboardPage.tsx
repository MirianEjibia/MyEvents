import { useSelector } from "react-redux";
import { fetchEvents, EventsListSelector } from "../../features/events/slice";
import { useEffect } from "react";
import { useAppDispatch } from "../../store";

export const DashboardPage = () => {
  const dispatch = useAppDispatch();

  useEffect(() => {
    dispatch(fetchEvents());
  }, [dispatch]);

  const events = useSelector(EventsListSelector);
  return <>{events.map((ev) => ev.name)}</>;
};
