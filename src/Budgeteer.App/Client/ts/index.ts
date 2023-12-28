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
    { path: '/budgets', component: () => import('./Pages/Budgets.vue'), beforeEnter: () => '/auth/login' },
    { path: '/transactions', component: () => import('./Pages/Transactions.vue') },
    { path: '/budget-categories', component: () => import('./Pages/BudgetCategories/Index.vue') },
    { path: '/budget-categories/edit', component: () => import('./Pages/BudgetCategories/Edit.vue') },
  ],
});

const app = createApp(AppVue);

for (const [name, component] of Object.entries(Components)) {
  app.component(name.substring(0, name.length - 3), component);
}

app.component('RouterLink', RouterLink);

app.use(router);
// app.mount('#App');
