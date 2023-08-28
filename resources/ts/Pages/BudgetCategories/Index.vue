<script lang="ts" setup></script>

<template>
  <Layout>
    <div class="flex flex-row items-center justify-between">
      <Title>Budget-Kategorien verwalten</Title>

      <div class="flex flex-row gap-2">
        <Link href="/budget-categories/create" class="contents">
          <AddButton></AddButton>
        </Link>
      </div>
    </div>

    <ResourceList :items="dataListItems" resourceUrl="budget-categories"> </ResourceList>
  </Layout>
</template>

<script lang="ts">
import { PropType } from "vue";
import { BudgetCategoryModel } from "../../Models/BudgetCategoryModel";
import { ResourceListItem } from "../../Components/Complex/ResourceListItem";

export default {
  props: {
    budgetCategories: Array as PropType<BudgetCategoryModel[]>,
  },
  computed: {
    dataListItems() {
      return this.budgetCategories?.map((c) => ({ slug: c.slug, text: c.name } satisfies ResourceListItem)) ?? [];
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
