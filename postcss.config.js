module.exports = {
  plugins: [
    // Remove unused styles
    // Uncomment if needed.
    // require('@fullhuman/postcss-purgecss')({
    //   content: ['./resources/views/**/*.blade.php', './resources/ts/**/*.ts'],
    //   safelist: {
    //     standard: [/@tailwind/],
    //   },
    // }),
    // Include Tailwind-classes
    require('tailwindcss')(),
    // Automatically add vendor prefixes
    require('autoprefixer')(),
    // minifiy styles
    require('cssnano')({ preset: [require('cssnano-preset-default'), { discardUnused: true }] }),
  ],
};
