<script lang="ts" setup>
import { SelectItem } from "../../Components/Inputs/SelectItem";
</script>

<template>
  <Layout>
    <div class="flex flex-row items-center justify-between">
      <Title>Budget-Kategorie hinzufügen</Title>

      <div class="flex flex-row gap-2">
        <Button kind="success">
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
      <TextBox label="Name" :required="true" name="Name" id=""></TextBox>

      <Select label="Übergeordnete Gruppe" :items="items"></Select>
    </div>
  </Layout>
</template>

<script lang="ts">
const v = [
  {
    text: "- keine -",
    value: 0,
  },
] satisfies SelectItem[];

export default {
  props: {},
  data() {
    return {
      items: v,
    };
  },
};
</script>
