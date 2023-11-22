<script lang="ts" setup>
import TreeViewNode from './TreeViewNode.vue';
</script>

<style>
.treeview-node:hover button {
  visibility: visible;
}
</style>

<template>
  <div
    class="treeview-node rounded-md hover:bg-emerald-500/20 p-2 flex gap-2"
    :class="{
      'bg-emerald-500/40': item === selectedItem,
    }"
    @click="$emit('selected', selectedItem)"
  >
    <button @click="childrenHidden = !childrenHidden">
      <i class="fa-solid fa-fw" :class="{ 'fa-chevron-down': !childrenHidden, 'fa-chevron-right': childrenHidden }"></i>
    </button>

    <span class="flex-1"> {{ item?.text }} </span>

    <RouterLink class="contents" :to="`${resourceUrl}/${item?.slug}/edit`">
      <Button class="invisible" kind="success">
        <i class="fa-solid fa-pen"></i>
      </Button>
    </RouterLink>

    <Button class="invisible" kind="danger" @click="$emit('delete', item)">
      <i class="fa-solid fa-trash"></i>
    </Button>
  </div>

  <div v-if="item?.children.length" class="pl-4" :class="{ hidden: childrenHidden }">
    <TreeViewNode v-for="child of item?.children" :item="child" :resourceUrl="resourceUrl"></TreeViewNode>
  </div>
</template>

<script lang="ts">
import { TreeViewItem } from './TreeViewItem';
import { ResourceListItem } from './ResourceListItem';

export default {
  props: {
    item: TreeViewItem,
    selectedItem: TreeViewItem,
    resourceUrl: String,
  },
  data() {
    return {
      childrenHidden: !this.item?.children.length,
    };
  },
  emits: {
    selected(item: ResourceListItem) {
      return true;
    },
    delete(item: ResourceListItem) {
      return true;
    },
  },
};
</script>
