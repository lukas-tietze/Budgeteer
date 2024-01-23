<template>
  <div class="border-2 border-neutral-400 bg-neutral-50 focus-within:border-emerald-400 rounded-md">
    <input type="text" v-model="displayMajorCurrency" class="outline-none text-right bg-red-400" name="major" />
    <span>,</span>
    <input type="text" v-model="displayMinorCurrency" class="outline-none text-left bg-orange-400" name="minor" />
    <span>{{ sign }}</span>
  </div>
</template>

<style lang="scss" scoped>
input[name='minor'] {
  width: 2.2ch;
}
</style>

<script lang="ts">
export default {
  props: {
    modelValue: {
      type: Number,
      required: true,
    },
    sign: {
      type: String,
      required: false,
      default: '€',
    },
  },
  watch: {
    modelValue: {
      handler: (...args: any[]) => {
        console.log(args);
        console.log(this);
      },
    },
  },
  data() {
    return {
      displayMajorCurrency: '',
      displayMinorCurrency: '',
    };
  },
  emits: {
    'update:modelValue'(value: number) {
      return true;
    },
  },
};
</script>
