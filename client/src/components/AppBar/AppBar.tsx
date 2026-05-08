import { Menubar } from "../ui/MenuBar";
import AccountControls from "./components/AccountControl/AccountControls";

export const AppBar = () => {
  return (
    <>
      <Menubar className="flex h-auto justify-between rounded-none px-5 py-0">
        <img src="public/logo.svg" className="w-35 h-15" />
        <AccountControls />
      </Menubar>
    </>
  );
};
