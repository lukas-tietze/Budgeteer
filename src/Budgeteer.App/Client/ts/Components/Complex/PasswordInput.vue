<template>
  <div class="flex flex-row items-end">
    <div class="flex-1 flex flex-col">
      <label :for="passwordId">
        <span class="text-xs text-gray-400">Passwort</span>
        <span v-if="required">*</span>
      </label>
      <input
        :type="confirmMode ? 'password' : 'text'"
        class="outline-none rounded-l-md border-2 border-r-0 px-1 py-0.5"
        :class="{
          'bg-neutral-50': !error,
          'bg-red-600/50': passwordFocus && !!error,
          'border-emerald-500': passwordFocus && !error,
          'border-neutral-400': !passwordFocus && !error,
        }"
        :id="passwordId"
        :value="modelValue"
        @input="$emit('update:modelValue', ($event.target as HTMLInputElement).value ?? '')"
        @focus="passwordFocus = true"
        @blur="passwordFocus = false"
      />
    </div>
    <button
      type="button"
      class="border-2 rounded-r-md border-l-0 px-1 py-0.5"
      :class="{
        'bg-neutral-50': !error,
        'bg-red-600/50': passwordFocus && !!error,
        'border-emerald-500': passwordFocus && !error,
        'border-neutral-400': !passwordFocus && !error,
      }"
      @click="confirmMode = !confirmMode"
    >
      <i
        class="fa-solid"
        :class="{
          'fa-eye': confirmMode,
          'fa-eye-slash': !confirmMode,
        }"
      ></i>
    </button>
  </div>
  <div class="flex flex-col" v-if="confirmMode">
    <label :for="passwordRepeatId">
      <span class="text-xs text-gray-400">Passwort wiederholen</span>
      <span v-if="required">*</span>
    </label>
    <input
      type="text"
      class="outline-none rounded-md border-2 px-1 py-0.5"
      :class="{
        'border-neutral-400 focus:border-emerald-500 bg-red-600/50': !!error,
        'border-neutral-400 focus:border-emerald-500 bg-neutral-50': !error,
      }"
      :id="passwordRepeatId"
      v-model="passwordRepeat"
    />
  </div>
</template>

<script lang="ts">
import { IdService } from '../../Services/IdService';

export default {
  props: {
    modelValue: String,
    error: String,
    required: Boolean,
  },
  data() {
    return {
      passwordId: IdService.next().toString(),
      passwordRepeatId: IdService.next().toString(),
      passwordFocus: false,
      passwordRepeat: '',
      passwordRepeatError: '',
      confirmMode: true,
    };
  },
  emits: {
    'update:modelValue'(value: string) {
      return true;
    },
  },
};
</script>
