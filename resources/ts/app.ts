import './bootstrap';
import '../scss/app.scss';

import { resolvePageComponent } from 'laravel-vite-plugin/inertia-helpers';
import { createApp, h } from 'vue';

import { InertiaProgress } from '@inertiajs/progress';
import { createInertiaApp } from '@inertiajs/vue3';

import { ZiggyVue } from '../../vendor/tightenco/ziggy/dist/vue.m';
import { Components } from './Components/Components';
import { Layouts } from './Layouts/Layouts';

function readComponents(...collections: object[]) {
  return collections.flatMap((c) => Object.entries(c).map(([k, v]) => [k.substring(0, k.length - 3), v] as const));
}

const appName = window.document.getElementsByTagName('title')[0]?.innerText || 'Laravel';

// Deklaration für die Variable (oder den Konstruktor??) `Ziggy`, wo auch immer der definiert wird.
declare const Ziggy: any;

createInertiaApp({
  title: (title) => `${title} - ${appName}`,
  resolve: (name) => resolvePageComponent(`./Pages/${name}.vue`, import.meta.glob('./Pages/**/*.vue')),
  setup: ({ App, el, plugin, props }) => {
    let app = createApp({ render: () => h(App, props) })
      .use(plugin)
      .use(ZiggyVue, Ziggy);

    for (const [name, vue] of readComponents(Components, Layouts)) {
      app = app.component(name, vue);
    }

    app.mount(el);
  },
  progress: {
    color: '#4B5563',
  },
});

InertiaProgress.init();
