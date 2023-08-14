<script lang="ts" setup>
import Layout from "../Layouts/Layout.vue";
</script>

<template>
  <Layout>
    Budget-Kategorien verwalten

    {{ budgetCategories?.length ?? 'leer' }}

    <div v-for="item of budgetCategories">
      <div>{{ item.name }}</div>
    </div>
  </Layout>
</template>

<script lang="ts">
export default {
  props: {},
  data() {
    return {
      budgetCategories: [] as { name: string }[],
    };
  },
};
</script>
