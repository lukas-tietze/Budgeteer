<script lang="ts" setup>
import CurrencyInput from '../../Components/Inputs/CurrencyInput.vue';
</script>

<template>
  <div class="py-2 my-4">
    <CurrencyInput v-model="currencyValue" :sign="currencySign"></CurrencyInput>
  </div>

  <div class="flex flex-col">
    <h2 class="mb-2 text-lg font-bold">Ein- / Ausgabe</h2>

    <label>Betrag (in kleiner Währungseinheit)</label>
    <input type="number" v-model="currencyValue" class="border-2 border-emerald-400 outline-none rounded-md px-2 mb-2" />

    <label>Währungssymbol</label>
    <input type="text" v-model="currencySign" class="border-2 border-emerald-400 outline-none rounded-md px-2 mb-2" />
  </div>
</template>

<script lang="ts">
export default {
  data() {
    return {
      currencyValue: 0,
      currencySign: '€',
    };
  },
};
</script>
