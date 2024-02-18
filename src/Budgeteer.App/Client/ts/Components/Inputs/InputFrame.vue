<template>
  <div class="flex flex-col">
    <label v-if="label" :for="id" class="flex flex-row">
      <span class="flex-1 text-ellipsis whitespace-nowrap">
        {{ label }}
        <span v-if="required" class="pl-1">*</span>
      </span>

      <span
        v-if="description"
        class="description-popup relative"
        :class="{
          'forced-open': descriptionForcedOpen,
        }"
      >
        <i class="fa-solid fa-question-circle" @click="descriptionForcedOpen = !descriptionForcedOpen"> </i>
        <div class="absolute bg-neutral-200 border-2 border-emerald-500 rounded-md p-2 w-screen max-w-xs right-4 bottom-4">
          {{ description }}
        </div>
      </span>
    </label>

    <slot></slot>
  </div>
</template>

<style lang="scss" scoped>
.description-popup {
  i + div {
    display: none;
  }

  &.forced-open > div,
  i:hover + div {
    display: flex;
  }
}
</style>

<script lang="ts">
import { InputFrameProps } from './InputFrameProps';

export default {
  props: {
    ...InputFrameProps,
  },
  data() {
    return { descriptionForcedOpen: false };
  },
};
</script>
