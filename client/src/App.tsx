import { Navigate, Outlet } from "react-router";
import "./App.css";
import { AppBar } from "./components/AppBar/AppBar";
import { Menu } from "./components/Menu/Menu";
import { useCurrentUser } from "./features/user/queries";
import { paths } from "./constants/paths";

function App() {
  const { isPending, data } = useCurrentUser();
  if (isPending) return <div> Is Laoding </div>;
  if (!data) return <Navigate to={paths.login} replace />;
  return (
    <div className="h-dvh flex flex-col">
      <AppBar />
      <div className="flex flex-1 overflow-hidden">
        <Menu />
        <main className="flex-1 min-w-0 overflow-y-auto p-2">
          <Outlet />
        </main>
      </div>
      <footer />
    </div>
  );
}

export default App;
