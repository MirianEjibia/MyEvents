import { Outlet } from "react-router";
import "./App.css";
import { AppBar } from "./components/AppBar/AppBar";
import { LoginPage } from "./pages/Login/LoginPage";
import { useAppSelector } from "./store";
import { authSelector } from "./features/auth/slice";

function App() {
  const { accessToken } = useAppSelector(authSelector);

  if (!accessToken) {
    return <LoginPage />;
  }

  return (
    <>
      <AppBar />
      <Outlet />
    </>
  );
}

export default App;
