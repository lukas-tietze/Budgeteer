import { defineConfig } from 'vite';
import vue from '@vitejs/plugin-vue';

/** @type {import('vite').UserConfig} */
export default defineConfig({
  plugins: [
    vue({
      template: {
        transformAssetUrls: {
          base: null,
          includeAbsolute: false,
        },
      },
    }),
  ],
  /**
   * Konfiguration f�r dev-Server
   */
  server: {
    port: 4173,
    strictPort: true,
  },
  base: './',
  publicDir: './public',
  /**
   * Konfiguration für Produktions-Build -> Erzeugung von Bundles.
   */
  build: {
    manifest: true,
    rollupOptions: {
      input: ['./ts/index.ts', './scss/index.scss'],
    },
    outDir: '../wwwroot',
    emptyOutDir: true,
  },
});
