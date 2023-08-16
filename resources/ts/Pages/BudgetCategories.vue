<script lang="ts" setup>
import { BudgetCategoryModel } from "../Models/budget-category-model";
</script>

<template>
  <Layout>
    <Title>Budget-Kategorien verwalten</Title>

    {{ budgetCategories?.length }}

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
