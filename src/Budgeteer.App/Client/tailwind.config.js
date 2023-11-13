const defaultTheme = require('tailwindcss/defaultTheme');

/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        './ts/**/*.vue',
        '../Views/**/*.cshtml'
    ],

    theme: {
        extend: {
            colors: {
            },
        },
    },

    plugins: [require('@tailwindcss/forms'), require('@tailwindcss/typography')],
}
