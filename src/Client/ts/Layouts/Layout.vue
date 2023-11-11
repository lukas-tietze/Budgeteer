<script lang="ts" setup>
import Header from "./Header.vue";
import Footer from "./Footer.vue";
</script>

<template>
  <Header></Header>

  <main class="flex-1 mx-auto bg-neutral-50 ring-1 ring-neutral-200 w-full lg:max-w-4xl xl:max-w-6xl px-4 py-4">
    <slot></slot>
  </main>

  <Footer></Footer>
</template>

<script lang="ts">
export default {};
</script>
