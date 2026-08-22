import { Button } from "@/components/ui/button";
import {
  Combobox,
  ComboboxContent,
  ComboboxEmpty,
  ComboboxInput,
  ComboboxItem,
  ComboboxList,
} from "@/components/ui/combobox";
import { Input } from "@/components/ui/input";
import { useForm, type FieldValues } from "react-hook-form";

export const FilterBar = () => {
  const { register, handleSubmit } = useForm();

  const onSubmit = (data: FieldValues) => {
    console.log("Search form data", data);
  };

  return (
    <form onSubmit={handleSubmit(onSubmit)}>
      <div className="flex">
        <Input {...register("name")} />
        <Button type="submit"> Search </Button>
        <Combobox items={["Tbilisi", "Batumi"]}>
          <ComboboxInput placeholder="Select a framework" />
          <ComboboxContent>
            <ComboboxEmpty>No items found.</ComboboxEmpty>
            <ComboboxList>
              {(item) => (
                <ComboboxItem key={item} value={item}>
                  {item}
                </ComboboxItem>
              )}
            </ComboboxList>
          </ComboboxContent>
        </Combobox>
      </div>
    </form>
  );
};
