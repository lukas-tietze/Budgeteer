<template>
  <Button :href="href" :kind="disabled ? 'disabled' : outline ? 'success-outline' : 'success'" name="Add">
    <i class="fa-solid fa-plus mr-1"></i>
    Hinzufügen
  </Button>
</template>

<script lang="ts">
export default {
  props: {
    href: String,
    disabled: Boolean,
    outline: Boolean,
  },
};
</script>
