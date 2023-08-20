<template>
  <div class="flex flex-col">
    <label :for="id || uniqueId">
      <span>{{ label }}</span>
      <span v-if="required">*</span>
    </label>
    <div
      class="flex flex-row justify-between outline-none rounded-md border-2 border-neutral-400 bg-neutral-50 px-1 py-0.5"
      :class="{
        'border-emerald-500': dropDownOpened,
      }"
      v-bind="$attrs"
      :id="id || uniqueId"
      @click="dropDownOpened = !dropDownOpened"
    >
      <div>{{ selectedItem?.text }} &nbsp;</div>
      <div>
        <i class="fa-solid fa-chevron-down mx-2"> </i>
      </div>
    </div>

    <div class="relative">
      <div
        class="border-x-2 border-b-2 rounded-md border-neutral-400 bg-neutral-50 select-none"
        :class="{
          hidden: !dropDownOpened,
          'absolute top-0 left-0 right-0': dropDownOpened,
        }"
      >
        <div v-for="item in items" @click="selectedItem = item" class="px-1 py-0.5 hover:bg-emerald-500 hover:text-emerald-50">
          {{ item.text }}
        </div>
      </div>
    </div>
  </div>

  <select class="rounded-md">
    <option>A</option>
    <option>B</option>
    <option>C</option>
  </select>
</template>

<script lang="ts">
import { PropType } from "vue";
import { IdService } from "../../Services/IdService";
import type { SelectItem } from "./SelectItem";

export default {
  props: {
    required: Boolean,
    label: String,
    id: String,
    items: Array as PropType<Array<SelectItem>>,
    allowEmpty: Boolean,
  },
  data() {
    return {
      uniqueId: IdService.nextRandom(),
      selectedItem: undefined as SelectItem | undefined,
      dropDownOpened: false,
    };
  },
  updated() {},
};
</script>
