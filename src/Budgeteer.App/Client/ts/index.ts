import { createApp } from 'vue';
import { createRouter, createWebHistory, RouterLink } from 'vue-router';

import AppVue from './App.vue';
import { Components } from './Components/Components';

const router = createRouter({
  history: createWebHistory('app'),
  routes: [
    { path: '/', component: () => import('./Pages/Index.vue') },
    { path: '/auth/login', component: () => import('./Pages/Auth/Login.vue') },
    { path: '/auth/register', component: () => import('./Pages/Auth/Register.vue') },
    { path: '/transactions', component: () => import('./Pages/Transactions.vue') },
    { path: '/budget', component: () => import('./Pages/Budget/Index.vue') },
    { path: '/budget/edit', component: () => import('./Pages/Budget/Edit.vue') },
    { path: '/budget/create', component: () => import('./Pages/Budget/Edit.vue') },
    {
      path: '/playground',
      component: () => import('./Pages/Playground/Index.vue'),
      children: [{ path: 'concept', component: () => import('./Pages/Playground/Concept.vue') }],
    },
  ],
});

const app = createApp(AppVue);

for (const [name, component] of Object.entries(Components)) {
  app.component(name.substring(0, name.length - 3), component);
}

app.use(router);

app.mount('#App');
