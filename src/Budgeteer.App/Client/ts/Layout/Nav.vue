<script lang="ts" setup>
import NavItem from '../Components/NavItem.vue';
import { inject } from '../Services/Di';
</script>

<template>
  <nav class="flex flex-row">
    <ul class="list-none flex flex-row flex-1 justify-start">
      <NavItem href="/">
        <i class="fa-solid fa-home"></i>

        <span>BUDGETEER</span>
      </NavItem>
    </ul>

    <ul class="list-none flex flex-row flex-1 justify-center">
      <NavItem href="/budgets">
        <span>Budgets</span>
      </NavItem>

      <NavItem href="/budget-categories">
        <span>Kategorien</span>
      </NavItem>

      <NavItem href="/transactions">
        <span>Einnahmen & Ausgaben</span>
      </NavItem>
    </ul>

    <ul class="list-none flex flex-row flex-1 justify-end">
      <NavItem href="/" v-if="authService.isLoggedIn">
        <i class="fa-solid fa-circle-user"></i>
        <span>Profil</span>
      </NavItem>

      <NavItem href="/" v-if="authService.isLoggedIn">
        <i class="fa-solid fa-arrow-right-from-bracket"></i>
        <span>Abmelden</span>
      </NavItem>

      <NavItem href="/auth/login" v-if="!authService.isLoggedIn">
        <i class="fa-solid fa-arrow-left-from-bracket"></i>
        <span>Login</span>
      </NavItem>
    </ul>
  </nav>
</template>

<script lang="ts">
import { inject } from '../Services/Di';
import { AuthService } from '../Services/AuthService';

export default {
  data() {
    return { authService: inject(AuthService) };
  },
};
</script>
