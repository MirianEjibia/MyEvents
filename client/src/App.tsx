import { useEffect, useState } from "react";
import "./App.css";
import axios from "axios";
import { Button } from "@/components/ui/button";
import { AppBar } from "./components/AppBar/AppBar";

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

  return <AppBar />;
}

export default App;
