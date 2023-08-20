<script lang="ts" setup></script>

<template>
  <Layout>
    <div class="flex flex-row items-center justify-between">
      <Title>Budget-Kategorien verwalten</Title>

      <div class="flex flex-row gap-2">
        <Link href="/budget-categories/create" class="contents">
          <AddButton></AddButton>
        </Link>

        <EditButton :disabled="selectedItem === undefined"></EditButton>
        <DeleteButton :disabled="selectedItem === undefined"></DeleteButton>
      </div>
    </div>

    <div v-for="item of budgetCategories">
      <div
        class="rounded-md hover:bg-emerald-400 p-2"
        :class="{
          'bg-emerald-500': item === selectedItem,
        }"
        @click="selectedItem = item === selectedItem ? undefined : item"
      >
        {{ item.name }}
      </div>
    </div>
  </Layout>
</template>

<script lang="ts">
import { PropType } from "vue";
import { BudgetCategoryModel } from "../../Models/BudgetCategoryModel";

export default {
  props: {
    budgetCategories: Array as PropType<BudgetCategoryModel[]>,
  },
  data() {
    return {
      selectedItem: undefined as undefined | BudgetCategoryModel,
    };
  },
};
</script>
