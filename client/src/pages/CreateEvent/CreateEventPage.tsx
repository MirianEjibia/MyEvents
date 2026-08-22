import { Button } from "@/components/ui/button";
import {
  Card,
  CardContent,
  CardDescription,
  CardFooter,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { CreateEventStateSelector } from "@/features/events/slice";
import { useAppDispatch, useAppSelector } from "@/store";
import { useForm, type FieldValues } from "react-hook-form";
import { useNavigate } from "react-router";

export const CreateEventPage = () => {
  const { isCreating, createError } = useAppSelector(CreateEventStateSelector);

  const { register, reset, handleSubmit } = useForm();
  // const handleSubmit = async (e: FormEvent<HTMLFormElement>) => {
  //   e.preventDefault();
  //   const result = await dispatch(
  //     createEvent({
  //       name,
  //       description,
  //       startDate,
  //       country,
  //       city,
  //       parallel: Number(parallel),
  //       meridian: Number(meridian),
  //     }),
  //   );
  //   if (createEvent.fulfilled.match(result)) {
  //     navigate("/events");
  //   }
  // };
  const onSubmit = (data: FieldValues) => {
    console.log("data", data);
  };

  return (
    <div className="flex min-h-screen items-center justify-center">
      <Card className="w-full max-w-sm">
        <CardHeader>
          <CardTitle>Create Event</CardTitle>
          <CardDescription>
            Fill in the details for the new event
          </CardDescription>
        </CardHeader>
        <form onSubmit={handleSubmit(onSubmit)}>
          <CardContent className="flex flex-col gap-4">
            <div className="flex flex-col gap-2">
              <Label htmlFor="name">Name</Label>
              <Input id="name" {...register("name")} required />
            </div>
            <div className="flex flex-col gap-2">
              <Label htmlFor="description">Description</Label>
              <Input id="description" {...register("description")} required />
            </div>
            <div className="flex flex-col gap-2">
              <Label htmlFor="startDate">Start Date</Label>
              <Input
                id="startDate"
                type="date"
                {...register("startDate")}
                required
              />
            </div>
            <div className="flex flex-col gap-2">
              <Label htmlFor="city">City</Label>
              <Input id="city" {...register("city")} required />
            </div>
            <div className="flex flex-col gap-2">
              <Label htmlFor="country">Country</Label>
              <Input id="country" {...register("country")} required />
            </div>
            <div className="flex flex-col gap-2">
              <Label htmlFor="parallel">Parallel</Label>
              <Input
                id="parallel"
                type="number"
                step="any"
                {...register("parallel")}
                required
              />
            </div>
            <div className="flex flex-col gap-2">
              <Label htmlFor="meridian">Meridian</Label>
              <Input
                id="meridian"
                type="number"
                step="any"
                {...register("meridian")}
                required
              />
            </div>
            {createError && (
              <p className="text-sm text-destructive">{createError}</p>
            )}
          </CardContent>
          <CardFooter>
            <Button type="submit" className="w-full" disabled={isCreating}>
              {isCreating ? "Creating..." : "Create Event"}
            </Button>
          </CardFooter>
        </form>
      </Card>
    </div>
  );
};
