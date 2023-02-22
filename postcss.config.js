const tailwindcss = require('tailwindcss');
const cssnano = require('cssnano');
const autoprefixer = require('autoprefixer');

module.exports = {
  plugins: [tailwindcss(), autoprefixer(), cssnano({ preset: [require('cssnano-preset-default'), { discardUnused: true }] })],
};
