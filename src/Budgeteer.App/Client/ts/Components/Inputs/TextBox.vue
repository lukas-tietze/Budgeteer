<template>
  <div class="flex flex-col">
    <label :for="id || uniqueId">
      <span class="text-xs text-gray-400">{{ label }}</span>
      <span v-if="required">*</span>
    </label>
    <input
      class="outline-none rounded-md border-2 px-1 py-0.5"
      :class="{
        'border-neutral-400 focus:border-emerald-500 bg-red-600/50': !!error,
        'border-neutral-400 focus:border-emerald-500 bg-neutral-50': !error,
      }"
      :id="id || uniqueId"
      :value="modelValue"
      v-bind="$attrs"
      @input="$emit('update:modelValue', ($event.target as HTMLInputElement).value ?? '')"
    />
  </div>
</template>

<script lang="ts">
import { IdService } from '../../Services/IdService';

export default {
  props: {
    required: Boolean,
    label: String,
    id: String,
    modelValue: String,
    error: String,
  },
  data() {
    return {
      uniqueId: IdService.next().toString(),
    };
  },
  emits: {
    'update:modelValue'(value: string) {
      return true;
    },
  },
};
</script>
