import { createBrowserRouter } from "react-router";
import App from "./App";
import { DashboardPage } from "./pages/dashboard/DashboardPage";
import { CreateEventPage } from "./pages/CreateEvent/CreateEventPage";
import { AIModePage } from "./pages/AIMode/AIModePage";
import { LoginPage } from "./pages/Login/LoginPage";
import { paths } from "./constants/paths";
import { RegisterPage } from "./pages/Register/RegisterPage";

export const router = createBrowserRouter([
  {
    path: paths.home,
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
    path: paths.login,
    element: <LoginPage />,
  },
  {
    path: paths.register,
    element: <RegisterPage />,
  },
]);
