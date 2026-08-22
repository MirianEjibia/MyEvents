import { Outlet } from "react-router";
import "./App.css";
import { AppBar } from "./components/AppBar/AppBar";
import { Menu } from "./components/Menu/Menu";

function App() {
  // if (!accessToken) {
  //   return <LoginPage />;
  // }

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
