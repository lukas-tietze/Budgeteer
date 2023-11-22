<script lang="ts" setup></script>

<style>
div > div:hover button {
  visibility: visible;
}
</style>

<template>
  <div v-for="item of items">
    <div
      class="rounded-md hover:bg-emerald-500/20 p-2 flex gap-2"
      :class="{
        'bg-emerald-500/40': item === selectedItem,
      }"
      @click="selectedItem = item === selectedItem ? undefined : item"
    >
      <span class="flex-1"> {{ item.text }} </span>

      <RouterLink class="contents" :to="`${resourceUrl}/${item.slug}/edit`">
        <Button class="invisible" kind="success">
          <i class="fa-solid fa-pen"></i>
        </Button>
      </RouterLink>

      <Button class="invisible" kind="danger" @click="deleteEntry(item)">
        <i class="fa-solid fa-trash"></i>
      </Button>
    </div>
  </div>
</template>

<script lang="ts">
import { ResourceListItem } from "./ResourceListItem";

export default {
  props: {
    items: Array<ResourceListItem>,
    resourceUrl: String,
  },
  data() {
    return {
      selectedItem: undefined as undefined | ResourceListItem,
    };
  },
  methods: {
    deleteEntry(item: ResourceListItem) {
      // TODO: Wiederherstellen
      // Inertia.delete(`${this.resourceUrl}/${item.slug}`)
    },
  },
};
</script>
