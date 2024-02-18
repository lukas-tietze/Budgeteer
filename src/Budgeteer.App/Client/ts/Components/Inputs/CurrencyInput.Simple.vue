<script lang="ts" setup>
import InputFrame from './InputFrame.vue';
</script>

<template>
  <InputFrame v-bind="$props">
    <div class="border-2 border-neutral-400 bg-neutral-50 focus-within:border-emerald-400 rounded-md flex flex-row">
      <input type="number" v-model="model" :id="id" class="flex-1 outline-none text-right p-1" @focus="normalize()" @blur="normalize()" />
      <span class="py-1 pr-1">{{ sign }}</span>
    </div>
  </InputFrame>
</template>

<style lang="scss" scoped>
input[type='number'] {
  appearance: textfield;
  &::-webkit-outer-spin-button,
  &::-webkit-inner-spin-button {
    appearance: none;
    margin: none;
  }
}
</style>

<script lang="ts">
import { IdService } from '../../Services/IdService';
import { InputFrameProps } from './InputFrameProps';

export default {
  props: {
    ...InputFrameProps,
    modelValue: {
      type: Number,
      default: 0,
    },
    sign: {
      type: String,
      default: '€',
    },
  },
  watch: {
    modelValue: {
      handler(newValue?: number) {
        this.model = (newValue ?? 0).toFixed(2);
      },
    },
  },
  data() {
    return {
      model: '0.00',
    };
  },
  emits: {
    'update:modelValue'(value: number) {
      return true;
    },
  },
  methods: {
    normalize() {
      this.model = (Number(this.model) || 0).toFixed(2);
    },
  },
};
</script>
