<script lang="ts" setup>
import { PropType } from "vue";
import { SelectItem } from "../../Components/Inputs/SelectItem";
import { BudgetCategoryModel } from "../../Models/BudgetCategoryModel";
</script>

<template>
  <Layout>
    <div class="flex flex-row items-center justify-between">
      <Title>Budget-Kategorie hinzufügen</Title>

      <div class="flex flex-row gap-2">
        <Button kind="success" type="submit" @click="submit">
          <i class="fa-solid fa-check mr-1"></i>
          Übernehmen
        </Button>

        <Button kind="danger">
          <i class="fa-solid fa-xmark mr-1"></i>
          Abbrechen
        </Button>
      </div>
    </div>

    <div class="flex flex-col gap-3">
      <TextBox label="Name" :required="true" name="Name" v-model="model.name"></TextBox>

      <Select label="Übergeordnete Gruppe" :items="budgeCategoryItems" v-model="model.parentId"></Select>
    </div>
  </Layout>
</template>

<script lang="ts">
import { Inertia } from "@inertiajs/inertia";

export default {
  props: {
    budgetCategories: Array as PropType<BudgetCategoryModel[]>,
  },
  computed: {
    budgeCategoryItems() {
      const categories = (this.budgetCategories ?? []).map((i) => ({ text: i.name, value: i.id } satisfies SelectItem));

      categories.unshift({ text: "- keine -", value: 0 });

      return categories;
    },
  },
  data() {
    return {
      model: new BudgetCategoryModel(),
    };
  },
  methods: {
    log() {
      console.log(this.model);
    },
    submit() {
      Inertia.post("/budget-categories", this.model);
    },
  },
};
</script>
