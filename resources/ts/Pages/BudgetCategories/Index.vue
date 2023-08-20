<script lang="ts" setup>
import { BudgetCategoryModel } from "../../Models/BudgetCategoryModel";
</script>

<template>
  <Layout>
    <div class="flex flex-row items-center justify-between">
      <Title>Budget-Kategorien verwalten</Title>

      <div class="flex flex-row gap-2">
        <Link href="/budget-categories/add" class="contents">
          <AddButton></AddButton>
        </Link>

        <DeleteButton></DeleteButton>
      </div>
    </div>

    <div v-for="item of budgetCategories">
      <div>{{ item.name }}</div>
    </div>
  </Layout>
</template>

<script lang="ts">
export default {
  props: {
    budgetCategories: Array<BudgetCategoryModel>,
  },
};
</script>
