<template>
  <button
    class="px-4 h-8 max-h-8 overflow-hidden rounded-md flex flex-row items-center shadow-sm"
    :class="{
      'bg-green-500 shadow-green-700 text-green-100': kind === 'success',
      'bg-red-400 shadow-red-500 text-red-100': kind === 'danger',
    }"
  >
    <slot></slot>
  </button>
</template>

<script lang="ts">
export default {
  props: {
    kind: String,
    href: String,
  },
};
</script>
