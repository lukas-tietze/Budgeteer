<script lang="ts" setup>
import { Link } from "@inertiajs/vue3";
</script>

<template>
  <li class="hover:bg-emerald-700">
    <Link :href="href ?? ''" class="hover:underline">
      <div class="p-3">
        <slot></slot>
      </div>
    </Link>
  </li>
</template>

<script lang="ts">
export default {
  props: {
    href: String,
  },
};
</script>
