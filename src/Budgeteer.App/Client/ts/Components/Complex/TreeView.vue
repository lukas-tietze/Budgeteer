<script lang="ts" setup>
import TreeViewNode from "./TreeViewNode.vue";
</script>

<template>
  <TreeViewNode v-for="item of items" :item="item" :resourceUrl="resourceUrl"></TreeViewNode>
</template>

<script lang="ts">
import { TreeViewItem } from "./TreeViewItem";

export default {
  props: {
    items: Array<TreeViewItem>,
    resourceUrl: String,
  },
  data() {
    return {
      selectedItem: undefined as undefined | TreeViewItem,
    };
  },
  methods: {
    deleteEntry(item: TreeViewItem) {
      // TODO: Wiederherstellen
      // Inertia.delete(`${this.resourceUrl}/${item.slug}`);
    },
  },
};
</script>
