import { createBrowserRouter } from "react-router";
import App from "./App";
import { DashboardPage } from "./pages/dashboard/DashboardPage";
import { CreateEventPage } from "./pages/CreateEvent/CreateEventPage";
import { AIModePage } from "./pages/AIMode/AIModePage";
import { LoginPage } from "./pages/Login/LoginPage";

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
        path: "dashboard",
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
      {
        path: "ai-mode",
        element: <AIModePage />,
      },
    ],
  },
  {
    path: "/auth/login",
    element: <LoginPage />,
  },
]);
