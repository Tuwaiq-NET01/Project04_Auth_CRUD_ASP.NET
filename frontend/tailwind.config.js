module.exports = {
  purge: ["./src/**/*.{js,jsx,ts,tsx}", "./public/index.html"],
  darkMode: false, // or 'media' or 'class'
  theme: {
    extend: {},
    fontFamily: { noto: ["'Noto Sans JP'", "sans-serif"] },
  },
  variants: {
    extend: {},
  },
  plugins: [require("@tailwindcss/forms")],
};
