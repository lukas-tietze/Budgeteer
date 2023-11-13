<template>
  <div class="flex flex-col">
    <label :for="id || uniqueId">
      <span>{{ label }}</span>
      <span v-if="required">*</span>
    </label>
    <input
      class="outline-none rounded-md border-2 border-neutral-400 px-1 py-0.5 focus:border-emerald-500 bg-neutral-50"
      :id="id || uniqueId"
      :value="modelValue"
      v-bind="$attrs"
      @input="$emit('update:modelValue', ($event.target as HTMLInputElement).value ?? '')"
    />
  </div>
</template>

<script lang="ts">
import { IdService } from "../../Services/IdService";

export default {
  props: {
    required: Boolean,
    label: String,
    id: String,
    modelValue: String,
  },
  data() {
    return {
      uniqueId: IdService.nextRandom(),
    };
  },
  emits: {
    "update:modelValue"(value: string) {
      return true;
    },
  },
};
</script>
