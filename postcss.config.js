const tailwindcss = require('tailwindcss');
const cssnano = require('cssnano');
const autoprefixer = require('autoprefixer');
const purgecss = require('@fullhuman/postcss-purgecss');

module.exports = {
  plugins: [
    // Remove unused styles
    purgecss({
      content: ['./resources/views/**/*.blade.php', './resources/ts/**/*.ts'],
      safelist: {
        standard: [/@tailwind/],
      },
    }),
    // Include Tailwind-classes
    tailwindcss(),
    // Automatically add vendor prefixes
    autoprefixer(),
    // minifiy styles
    cssnano({ preset: [require('cssnano-preset-default'), { discardUnused: true }] }),
  ],
};
