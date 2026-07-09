import { useSelector } from "react-redux";
import { Link } from "react-router";
import { fetchEvents, EventsListSelector } from "../../features/events/slice";
import { useEffect } from "react";
import { useAppDispatch } from "../../store";
import { Button } from "@/components/ui/button";
import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from "@/components/ui/table";

export const DashboardPage = () => {
  const dispatch = useAppDispatch();

  useEffect(() => {
    dispatch(fetchEvents());
  }, [dispatch]);

  const events = useSelector(EventsListSelector);

  return (
    <>
      <div className="flex justify-end p-4">
        <Button render={<Link to="/events/create" />}>Create Event</Button>
      </div>
      <Table>
        <TableHeader>
          <TableRow>
            <TableHead>Name</TableHead>
            <TableHead>Description</TableHead>
            <TableHead>City</TableHead>
            <TableHead>Country</TableHead>
            <TableHead>Start Date</TableHead>
            <TableHead>End Date</TableHead>
            <TableHead>Status</TableHead>
          </TableRow>
        </TableHeader>
        <TableBody>
          {events.map((ev) => (
            <TableRow key={ev.id}>
              <TableCell>{ev.name}</TableCell>
              <TableCell>{ev.description}</TableCell>
              <TableCell>{ev.city}</TableCell>
              <TableCell>{ev.country}</TableCell>
              <TableCell>{new Date(ev.startDate).toLocaleDateString()}</TableCell>
              <TableCell>{new Date(ev.endDate).toLocaleDateString()}</TableCell>
              <TableCell>{ev.isCancelled ? "Cancelled" : "Active"}</TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </>
  );
};
