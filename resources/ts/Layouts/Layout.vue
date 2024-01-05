<script lang="ts" setup>
import Header from "./Header.vue";
import Footer from "./Footer.vue";
</script>

<template>
  <Header></Header>

  <main class="flex-1">
    <slot></slot>
  </main>

  <Footer></Footer>
</template>

<script lang="ts">
export default {};
</script>
