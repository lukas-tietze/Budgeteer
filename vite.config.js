import { defineConfig } from 'vite';
import laravel from 'laravel-vite-plugin';

/**
 * @type {import('vite').UserConfig}
 */
export default defineConfig({
  plugins: [
    laravel({
      input: ['resources/scss/index.scss', 'resources/ts/index.ts'],
      refresh: true,
    }),
  ],
  resolve: {
    alias: {
      '@': '/resources/ts',
    },
  },
});
