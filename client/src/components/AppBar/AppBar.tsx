import { Menubar } from "../ui/MenuBar";
import AccountControls from "./components/AccountControl/AccountControls";

export const AppBar = () => {
  return (
    <Menubar className="sticky inset-x-0 z-40 top-0 h-(--header-height) justify-between rounded-none px-5 py-0 shrink-0">
      <div className="flex items-center gap-2">
        <img src="public/logo.svg" className="w-35 h-15" />
      </div>
      <AccountControls />
    </Menubar>
  );
};
