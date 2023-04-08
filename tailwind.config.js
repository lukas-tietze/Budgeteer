<<<<<<< HEAD
module.exports = {
  content: [
    './resources/views/**/*.blade.php',
    './resources/ts/**/*.ts',
    './resources/js/**/*.js',
  ],
  theme: {
    extend: {},
  },
  plugins: [],
=======
const defaultTheme = require('tailwindcss/defaultTheme');

/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    './vendor/laravel/framework/src/Illuminate/Pagination/resources/views/*.blade.php',
    './vendor/laravel/jetstream/**/*.blade.php',
    './storage/framework/views/*.php',
    './resources/views/**/*.blade.php',
    './resources/ts/**/*.vue',
  ],

  theme: {
    extend: {
      fontFamily: {
        sans: ['Figtree', ...defaultTheme.fontFamily.sans],
      },
      colors: {
        luki: {
          DEFAULT: '#e90000',
        },
      },
    },
  },

  plugins: [require('@tailwindcss/forms'), require('@tailwindcss/typography')],
>>>>>>> 8ec4326 (Re-Init)
};
