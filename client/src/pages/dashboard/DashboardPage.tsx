import { Button } from "@/components/ui/button";
import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from "@/components/ui/table";
import { useEffect } from "react";
import { useSelector } from "react-redux";
import { useNavigate } from "react-router";
import { EventsListSelector, fetchEvents } from "../../features/events/slice";
import { useAppDispatch } from "../../store";
import { FilterBar } from "./components/FilterBar";

export const DashboardPage = () => {
  const dispatch = useAppDispatch();

  useEffect(() => {
    dispatch(fetchEvents());
  }, [dispatch]);

  const events = useSelector(EventsListSelector);
  const navigate = useNavigate();
  return (
    <div>
      <>
        <FilterBar />
      </>
      <Button
        onClick={() => navigate("/events/create")}
        className={"float-right m-3"}
      >
        Create Event
      </Button>
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
              <TableCell>
                {new Date(ev.startDate).toLocaleDateString()}
              </TableCell>
              <TableCell>{new Date(ev.endDate).toLocaleDateString()}</TableCell>
              <TableCell>{ev.isCancelled ? "Cancelled" : "Active"}</TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </div>
  );
};
