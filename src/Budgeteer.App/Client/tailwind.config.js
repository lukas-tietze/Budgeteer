const defaultTheme = require('tailwindcss/defaultTheme');

/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        './index.html',
        './ts/**/*.vue',
        '../Views/**/*.cshtml'
    ],

    theme: {
        extend: {
            colors: {
            },
        },
    },

    plugins: [require('@tailwindcss/typography')],
}
