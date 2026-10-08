import { isAxiosError } from "axios";

// ASP.NET Identity returns validation failures as
// { errors: { PasswordTooShort: ["..."], DuplicateUserName: ["..."] } }
export const getErrorMessages = (error: unknown, fallback: string) => {
  if (isAxiosError(error)) {
    const errors = error.response?.data?.errors as
      | Record<string, string[]>
      | undefined;
    if (errors) return Object.values(errors).flat();
  }
  return [fallback];
};
