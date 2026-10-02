import {
  MenubarContent,
  MenubarGroup,
  MenubarItem,
  MenubarMenu,
  MenubarTrigger,
} from "@/components/ui/MenuBar";
import { useCurrentUser, useLogOut } from "@/features/user/queries";
import { KeyRound, LogOut, User } from "lucide-react";
import type { FC } from "react";

const AccountControls: FC = () => {
  const { data: info } = useCurrentUser();
  const displayName = info?.dispalyName || info?.userName || info?.email;
  const { mutate: logOut } = useLogOut();

  return (
    <MenubarMenu>
      <MenubarTrigger>
        <User className="text-foreground" />
        <span className="text-foreground destruc"> {displayName}</span>
      </MenubarTrigger>
      <MenubarContent>
        <MenubarGroup>
          <MenubarItem>
            <KeyRound /> Change Password
          </MenubarItem>
          <MenubarItem onClick={() => logOut()}>
            <LogOut /> Log out
          </MenubarItem>
        </MenubarGroup>
      </MenubarContent>
    </MenubarMenu>
  );
};

export default AccountControls;
