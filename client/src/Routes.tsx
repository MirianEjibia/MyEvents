import { createBrowserRouter } from "react-router";
import App from "./App";
import { DashboardPage } from "./pages/dashboard/DashboardPage";
import { CreateEventPage } from "./pages/CreateEvent/CreateEventPage";

export const router = createBrowserRouter([
  {
    path: "/",
    element: <App />,
    children: [
      {
        index: true,
        element: <DashboardPage />,
      },
      {
        path: "events",
        element: <DashboardPage />,
      },
      {
        path: "events/create",
        element: <CreateEventPage />,
      },
    ],
  },
]);
