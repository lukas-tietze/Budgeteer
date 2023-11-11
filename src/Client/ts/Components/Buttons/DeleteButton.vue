<template>
  <Button :kind="disabled ? 'disabled' : outline ? 'danger-outline' : 'danger'" name="Add">
    <i class="fa-solid fa-trash mr-1"></i>
    Löschen
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
