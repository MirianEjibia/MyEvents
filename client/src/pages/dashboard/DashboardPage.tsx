import { Button } from "@/components/ui/button";
import { paths } from "@/constants/paths";
import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from "@/components/ui/table";
import { useNavigate } from "react-router";
import { useEvents } from "../../features/events/queries";
import { FilterBar } from "./components/FilterBar";

export const DashboardPage = () => {
  const { data: events = [] } = useEvents();
  const navigate = useNavigate();
  return (
    <div>
      <>
        <FilterBar />
      </>
      <Button
        onClick={() => navigate(paths.createEvent)}
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
