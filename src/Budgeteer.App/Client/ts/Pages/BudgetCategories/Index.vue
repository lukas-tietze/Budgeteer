<script lang="ts" setup></script>

<template>
  <div class="flex flex-row items-center justify-between">
    <Title>Budget-Kategorien verwalten</Title>

    <div class="flex flex-row gap-2">
      <RouterLink to="/budget-categories/create" class="contents">
        <AddButton></AddButton>
      </RouterLink>
    </div>
  </div>

  <TreeView :items="treeViewItems" resourceUrl="budget-categories"> </TreeView>
</template>

<script lang="ts">
import { PropType } from 'vue';
import { BudgetCategoryModel } from '../../Models/BudgetCategoryModel';
import { TreeViewItem } from '../../Components/Complex/TreeViewItem';

export default {
  props: {
    budgetCategories: Array as PropType<BudgetCategoryModel[]>,
  },
  computed: {
    treeViewItems() {
      if (!this.budgetCategories) {
        return [];
      }

      return TreeViewItem.FromList(this.budgetCategories, (i) => ({ ...i, text: i.name }));
    },
  },
  data() {
    return {
      selectedItem: undefined as undefined | BudgetCategoryModel,
    };
  },
};
</script>
../../Components/Complex/ResourceListItem
