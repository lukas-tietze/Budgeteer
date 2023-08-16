import './bootstrap';
import '../scss/app.scss';

import { resolvePageComponent } from 'laravel-vite-plugin/inertia-helpers';
import { createApp, h } from 'vue';

import { InertiaProgress } from '@inertiajs/progress';
import { createInertiaApp } from '@inertiajs/vue3';

import { ZiggyVue } from '../../vendor/tightenco/ziggy/dist/vue.m';
import TitleVue from './Components/Title.vue';
import LayoutVue from './Layouts/Layout.vue';

const appName = window.document.getElementsByTagName('title')[0]?.innerText || 'Laravel';

// Deklaration für die Variable (oder den Konstruktor??) `Ziggy`, wo auch immer der definiert wird.
declare const Ziggy: any;

createInertiaApp({
  title: (title) => `${title} - ${appName}`,
  resolve: (name) => resolvePageComponent(`./Pages/${name}.vue`, import.meta.glob('./Pages/**/*.vue')),
  setup: ({ App, el, plugin, props }) => {
    createApp({ render: () => h(App, props) })
      .use(plugin)
      .use(ZiggyVue, Ziggy)
      .component('Title', TitleVue)
      .component('Layout', LayoutVue)
      .mount(el);
  },
  progress: {
    color: '#4B5563',
  },
});

InertiaProgress.init();
