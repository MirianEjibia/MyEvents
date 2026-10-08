import { useState } from "react";
import type { FormEvent } from "react";
import { useLogIn } from "@/features/auth/queries";
import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import {
  Card,
  CardHeader,
  CardTitle,
  CardDescription,
  CardContent,
  CardFooter,
} from "@/components/ui/card";
import { Link, useNavigate } from "react-router";
import { paths } from "@/constants/paths";
import { ButtonGroup } from "@/components/ui/button-group";

export const LoginPage = () => {
  const { mutateAsync: logIn, isPending: isLoading, error } = useLogIn();
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const navigate = useNavigate();
  const handleSubmit = async (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    await logIn({ email, password });
    navigate(paths.dashboard, { replace: true });
  };

  return (
    <div className="flex min-h-screen items-center justify-center">
      <Card className="w-full max-w-sm">
        <CardHeader>
          <CardTitle>Log in</CardTitle>
          <CardDescription>
            Enter your credentials to access your account
          </CardDescription>
        </CardHeader>
        <form onSubmit={handleSubmit}>
          <CardContent className="flex flex-col gap-4 my-2.5">
            <div className="flex flex-col gap-2">
              <Label htmlFor="email">Email</Label>
              <Input
                id="email"
                type="email"
                autoComplete="email"
                value={email}
                onChange={(e) => setEmail(e.target.value)}
                required
              />
            </div>
            <div className="flex flex-col gap-2">
              <Label htmlFor="password">Password</Label>
              <Input
                id="password"
                type="password"
                autoComplete="current-password"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
                required
              />
            </div>
            {error && (
              <p className="text-sm text-destructive">
                {error.message || "Login failed"}
              </p>
            )}
          </CardContent>
          <CardFooter>
            <ButtonGroup orientation={"vertical"}>
              <Button type="submit" className="w-full " disabled={isLoading}>
                {isLoading ? "Logging in..." : "Log in"}
              </Button>
              <Link className={"w-full text-blue-400"} to={paths.register}>
                If you do not have account, click here to register
              </Link>
            </ButtonGroup>
          </CardFooter>
        </form>
      </Card>
    </div>
  );
};
