import { useEffect, useState } from "react";
import "./App.css";
import axios from "axios";
import { Button } from "@/components/ui/button";

type EventDto = {
  id: string;
  name: string;
};

function App() {
  const [events, setEvents] = useState<EventDto[]>([]);

  useEffect(() => {
    axios
      .get<EventDto[]>("https://localhost:5001/api/events")
      .then((res) => setEvents(res.data))
      .catch((error) => {
        console.error("Failed to load events", error);
      });
  }, []);

  return (
    <div>
      {events?.map((e) => (
        <Button key={e.id}>{e.name}</Button>
      ))}
    </div>
  );
}

export default App;
