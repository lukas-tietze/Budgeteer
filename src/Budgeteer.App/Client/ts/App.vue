<script lang="ts" setup>
import Header from './Layout/Header.vue';
import Footer from './Layout/Footer.vue';
</script>

<template>
  <Header></Header>

  <main class="flex-1 mx-auto flex flex-col bg-neutral-50 ring-1 ring-neutral-200 w-full lg:max-w-4xl xl:max-w-6xl px-4 py-4">
    <router-view></router-view>
  </main>

  <Footer></Footer>
</template>

<script lang="ts">
export default {};
</script>
