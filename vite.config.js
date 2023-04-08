import { defineConfig } from "vite";
import laravel from "laravel-vite-plugin";
import vue from "@vitejs/plugin-vue";

/** @type {import('vite').UserConfig} */
export default defineConfig({
    plugins: [
        laravel({
            input: "resources/ts/app.ts",
            ssr: "resources/ts/ssr.ts",
            refresh: true,
        }),
        vue({
            template: {
                transformAssetUrls: {
                    base: null,
                    includeAbsolute: false,
                },
            },
        }),
    ],
    resolve: {
        alias: {
            "@": "/resources/ts",
        },
    },
});
