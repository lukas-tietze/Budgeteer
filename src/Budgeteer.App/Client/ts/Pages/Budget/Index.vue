<script lang="ts" setup>
import { TreeViewItem } from '../../Components/Complex/TreeViewItem';
import { Api } from '../../Services/Api';
import { inject } from '../../Services/Di';
import { ListModel } from '../../Models/Setup/ListModel';
</script>

<template>
  <div class="flex flex-row items-center justify-between">
    <Title>Budgets verwalten</Title>

    <div class="flex flex-row gap-2">
      <RouterLink to="/budget/create" class="contents">
        <AddButton></AddButton>
      </RouterLink>
    </div>
  </div>

  <TreeView v-if="treeViewItems.length" :items="treeViewItems" resourceUrl="budget-categories"> </TreeView>

  <div v-if="!treeViewItems.length">Noch keine Budgets definiert</div>
</template>

<script lang="ts">
export default {
  data() {
    return {
      selectedItem: undefined as undefined | ListModel,
      treeViewItems: [] as TreeViewItem[],
      models: [] as ListModel[],
    };
  },
  mounted() {
    inject(Api)
      .list(ListModel, '/budget/')
      .then((restArrayResult) => {
        this.models = restArrayResult.values;

        this.treeViewItems = TreeViewItem.FromTree(
          restArrayResult.values,
          (b) => b.children,
          (b) => ({ text: b.name, slug: b.id.toString() })
        );

        console.log(this.treeViewItems);
      });
  },
};
</script>
