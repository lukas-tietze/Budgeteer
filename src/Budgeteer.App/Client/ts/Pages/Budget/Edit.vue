<script lang="ts" setup>
import { SelectItem } from '../../Components/Inputs/SelectItem';
import { BudgetEditModel } from '../../Models/Setup/BudgetEditModel';
import { Api } from '../../Services/Api';
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
    <TextBox label="Name" :required="true" name="Name" v-model="model.name"></TextBox>

    <Select label="Übergeordnete Gruppe" :items="budgeCategoryItems" v-model="model.parentId"></Select>
  </div>
</template>

<script lang="ts">
import { inject } from '../../Services/Di';

export default {
  computed: {
    budgeCategoryItems() {
      const categories = (this.model.selectableParents).map((i) => ({ text: i.name, value: i.id } satisfies SelectItem));

      categories.unshift({ text: '- keine -', value: 0 });

      return categories;
    },
  },
  data() {
    return {
      model: new BudgetEditModel(),
    }
  },
  methods: {
    submit() {
      inject(Api).post(['/budget/edit/', this.model.id], this.model);
    },
  },
};
</script>
