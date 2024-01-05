<template>
  <Button :kind="disabled ? 'disabled' : outline ? 'success-outline' : 'success'" name="Add">
    <i class="fa-solid fa-pen mr-1"></i>
    Bearbeiten
  </Button>
</template>

<script lang="ts">
export default {
  props: {
    disabled: Boolean,
    outline: Boolean,
  },
};
</script>
