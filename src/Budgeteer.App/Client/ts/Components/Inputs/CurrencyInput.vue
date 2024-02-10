<script lang="ts" setup>
import InputFrame from './InputFrame.vue';
import { ref } from 'vue';

const textSpan = ref<HTMLSpanElement | null>(null);
</script>

<template>
  <InputFrame v-bind="$props">
    <div class="border-2 border-neutral-400 bg-neutral-50 focus-within:border-emerald-400 rounded-md flex flex-row px-1">
      <span class="flex-1 text-right outline-none p-1" tabindex="0" contenteditable="true" @keydown="handleKeyDown($event)" ref="textSpan">
      </span>
      <span>{{ sign }}</span>
    </div>
  </InputFrame>
</template>

<style lang="scss" scoped></style>

<script lang="ts">
import { InputFrameProps } from './InputFrameProps';
import { Replace } from './CurrencyInput.Replacer';

const numberKeys = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9'];
const allowedNavigationKeys = ['ArrowLeft', 'ArrowRight', 'Tab'];
const allowedKeys = [...allowedNavigationKeys];

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
        newValue ??= 0;

        if (this.model !== newValue) {
          this.$refs.textSpan.innerText = this.currencyFormat.format((this.model = newValue));
        }
      },
    },
  },
  data() {
    return {
      model: 0,
      currencyFormat: new Intl.NumberFormat(undefined, { minimumFractionDigits: 2, maximumFractionDigits: 2 }),
    };
  },
  emits: {
    'update:modelValue'(value: number) {
      return true;
    },
  },
  mounted() {
    this.$refs.textSpan.innerText = this.currencyFormat.format((this.model = this.modelValue));
  },
  methods: {
    handleKeyDown(ev: KeyboardEvent) {
      if (allowedKeys.includes(ev.key)) {
        return;
      }

      ev.preventDefault();
      ev.stopPropagation();

      if (!ev.altKey && !ev.ctrlKey && !ev.shiftKey) {
        if (ev.key.length === 1 && numberKeys.includes(ev.key)) {
          let selection = window.getSelection();

          if (selection?.rangeCount === 1) {
            let range = selection.getRangeAt(0);

            if(range.collapsed)
            {
              
            }

            const { newValue, newCursorPos } = (this.$refs.textSpan.innerText, ev.key, range.StaticRange, range.end);

            this.$refs.textSpan.innerText = newValue;

            range = document.createRange();

            range.setStart(this.$refs.textSpan.firstChild, newCursorPos);
            range.setEnd(this.$refs.textSpan.firstChild, newCursorPos);

            selection.removeAllRanges();
            selection.addRange(range);

            this.$emit('update:modelValue', this.model);
          }
        }
      }
    },
  },
};
</script>
