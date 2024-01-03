<script lang="ts" setup>
import { PropType } from 'vue';
import { SelectItem } from '../../Components/Inputs/SelectItem';
import { BudgetCategoryModel } from '../../Models/BudgetCategoryModel';
</script>

<template>
  <div class="flex flex-row items-center justify-between">
    <Title>Budget-Kategorie hinzufügen</Title>

    <div class="flex flex-row gap-2">
      <Button kind="success" type="submit" @click="submit">
        <i class="fa-solid fa-check mr-1"></i>
        Übernehmen
      </Button>

      <RouterLink to="/budget-categories" class="content">
        <Button kind="danger">
          <i class="fa-solid fa-xmark mr-1"></i>
          Abbrechen
        </Button>
      </RouterLink>
    </div>
  </div>

  <div class="flex flex-col gap-3">
    <TextBox label="Name" :required="true" name="Name" v-model="editedModel.name"></TextBox>

    <Select label="Übergeordnete Gruppe" :items="budgeCategoryItems" v-model="editedModel.parentId"></Select>
  </div>
</template>

<script lang="ts">
export default {
  props: {
    budgetCategories: Array<BudgetCategoryModel>,
    model: BudgetCategoryModel,
  },
  computed: {
    budgeCategoryItems() {
      const categories = (this.budgetCategories ?? []).map((i) => ({ text: i.name, value: i.id } satisfies SelectItem));

      categories.unshift({ text: '- keine -', value: 0 });

      return categories;
    },
    editedModel() {
      return this.model ?? new BudgetCategoryModel();
    },
  },
  methods: {
    log() {
      console.log(this.model);
    },
    submit() {
      const model = this.editedModel;

      // TODO: Wiederherstellen x2
      if (model.slug) {
        // Inertia.patch(`/budget-categories/${model.slug}`, model as any);
      } else {
        // Inertia.post('/budget-categories', model as any);
      }
    },
  },
};
</script>
