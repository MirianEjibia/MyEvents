import { cn } from "@/lib/utils";
import { useState } from "react";
import { NavLink } from "react-router";
import { Button } from "../ui/button";
import {
  ChevronsLeft,
  ChevronsRight,
  LayoutDashboard,
  Sparkles,
} from "lucide-react";

export const Menu = () => {
  const [isMenuOpen, setIsMenuOpen] = useState<boolean>(true);
  return (
    <div className="border-r pb-2 pt-6">
      <nav
        className={cn(
          "flex h-full flex-col justify-between px-4 transition-[width] duration-200 ease-in",
          isMenuOpen ? "w-50" : "w-20",
        )}
      >
        <ul className="flex h-full grow flex-col gap-3 overflow-auto">
          <li>
            <NavLink
              to="/dashboard"
              className={({ isActive }) =>
                cn(
                  "flex items-center gap-2 rounded-md p-2 hover:bg-accent hover:text-accent-foreground",
                  isActive && "bg-accent text-accent-foreground",
                )
              }
            >
              <LayoutDashboard className="size-5 shrink-0" />
              {isMenuOpen && <span>Dashaboared</span>}
            </NavLink>
          </li>

          <li>
            <NavLink
              to="/ai-mode"
              className={({ isActive }) =>
                cn(
                  "flex items-center gap-2 rounded-md p-2 hover:bg-accent hover:text-accent-foreground",
                  isActive && "bg-accent text-accent-foreground",
                )
              }
            >
              <Sparkles className="size-5 shrink-0" />
              {isMenuOpen && <span>AI mode</span>}
            </NavLink>
          </li>
        </ul>
        <div
          className={cn("flex shrink-0", isMenuOpen ? "space-x-2" : "flex-col")}
        >
          <Button
            className="my-auto flex h-12 w-12 items-center justify-center border-none bg-transparent p-0 text-muted-foreground shadow-none hover:bg-transparent"
            onClick={() => setIsMenuOpen(!isMenuOpen)}
          >
            {isMenuOpen ? <ChevronsLeft /> : <ChevronsRight />}
          </Button>
        </div>
      </nav>
    </div>
  );
};
