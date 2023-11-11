<script lang="ts" setup>
import NavItem from "../Components/NavItem.vue";
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
      <NavItem href="/">
        <i class="fa-solid fa-circle-user"></i>
        <span>Profil</span>
      </NavItem>

      <NavItem href="/">
        <i class="fa-solid fa-arrow-right-from-bracket"></i>
        <span>Abmelden</span>
      </NavItem>
    </ul>
  </nav>
</template>

<script lang="ts">
export default {};
</script>
