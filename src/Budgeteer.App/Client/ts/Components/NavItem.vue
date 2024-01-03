<script lang="ts" setup></script>

<template>
  <li class="hover:bg-emerald-700">
    <RouterLink :to="href ?? ''" class="hover:underline">
      <div class="p-3">
        <slot></slot>
      </div>
    </RouterLink>
  </li>
</template>

<script lang="ts">
export default {
  props: {
    href: String,
  },
};
</script>
