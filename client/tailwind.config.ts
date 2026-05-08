import type { Config } from "tailwindcss";

const GRID_ROWS = new Array(20).fill(true);

export default {
  content: [
    "./index.html",
    "./src/**/*.{js,jsx,ts,tsx}",
    "./_dev/components/**/*.{js,jsx,ts,tsx}",
  ],
  darkMode: ["selector", '[data-color-theme="dark"]'],
  theme: {
    extend: {
      width: {
        "160": "40rem",
      },
      padding: {
        "0.25": "0.0625rem",
      },
      borderRadius: {
        lg: "var(--radius)",
        md: "calc(var(--radius) - 2px)",
        sm: "calc(var(--radius) - 4px)",
      },
      listStyleType: {
        dash: '"- "',
      },
      fontFamily: {
        geist: '"Geist Variable"',
        "geist-mono": '"Geist Mono Variable"',
      },
      gridTemplateRows: GRID_ROWS.reduce<Record<number, string>>(
        (config, e, i) => {
          config[i + 1] = `repeat(${i + 1}, minmax(0, 1fr))`;
          return config;
        },
        {},
      ),
      gridTemplateColumns: GRID_ROWS.reduce<Record<number, string>>(
        (config, e, i) => {
          config[i + 1] = `repeat(${i + 1}, minmax(0, 1fr));`;
          return config;
        },
        {},
      ),
      colors: {
        background: "hsl(var(--background))",
        foreground: "hsl(var(--foreground))",
        card: {
          DEFAULT: "hsl(var(--card))",
          foreground: "hsl(var(--card-foreground))",
        },
        popover: {
          DEFAULT: "hsl(var(--popover))",
          foreground: "hsl(var(--popover-foreground))",
        },
        primary: {
          DEFAULT: "hsl(var(--primary))",
          foreground: "hsl(var(--primary-foreground))",
        },
        secondary: {
          DEFAULT: "hsl(var(--secondary))",
          foreground: "hsl(var(--secondary-foreground))",
        },
        muted: {
          DEFAULT: "hsl(var(--muted))",
          foreground: "hsl(var(--muted-foreground))",
        },
        accent: {
          DEFAULT: "hsl(var(--accent))",
          foreground: "hsl(var(--accent-foreground))",
        },
        destructive: {
          DEFAULT: "hsl(var(--destructive))",
          foreground: "hsl(var(--destructive-foreground))",
        },
        highlight: {
          DEFAULT: "hsl(var(--highlight))",
          foreground: "hsl(var(--highlight-foreground))",
        },
        border: "hsl(var(--border))",
        input: "hsl(var(--input))",
        ring: "hsl(var(--ring))",
        chart: {
          "1": "hsl(var(--chart-1))",
          "2": "hsl(var(--chart-2))",
          "3": "hsl(var(--chart-3))",
          "4": "hsl(var(--chart-4))",
          "5": "hsl(var(--chart-5))",
        },
        app: {
          einv: {
            DEFAULT: "hsl(var(--einv))",
            secondary: "hsl(var(--einv-secondary))",
          },
          admin: {
            DEFAULT: "hsl(var(--admin))",
            secondary: "hsl(var(--admin-secondary))",
          },
          eotp: {
            DEFAULT: "hsl(var(--eotp))",
            secondary: "hsl(var(--eotp-secondary))",
          },
          reports: {
            DEFAULT: "hsl(var(--reports))",
            secondary: "hsl(var(--reports-secondary))",
          },
          ppppdv: {
            DEFAULT: "hsl(var(--ppppdv))",
            secondary: "hsl(var(--ppppdv-secondary))",
          },
        },
      },
      keyframes: {
        "accordion-down": {
          from: {
            height: "0",
          },
          to: {
            height: "var(--radix-accordion-content-height)",
          },
        },
        "accordion-up": {
          from: {
            height: "var(--radix-accordion-content-height)",
          },
          to: {
            height: "0",
          },
        },
      },
      animation: {
        "accordion-down": "accordion-down 0.2s ease-out",
        "accordion-up": "accordion-up 0.2s ease-out",
      },
    },
  },
  plugins: [],
} satisfies Config;
