<template>
  <form class="mx-auto w-full max-w-xl mt-10 flex flex-col gap-4" @submit="login()" method="dialog">
    <TextBox type="email" id="EMail" name="EMail" v-model="email" label="E-Mail-Adresse" :error="mailError" />
    <PasswordInput v-model="password" />

    <Button type="submit" kind="success" class="mt-5">Registrieren</Button>
  </form>
</template>

<script lang="ts">
import { inject } from '../../Services/Di';
import { Api } from '../../Services/Api';
import { RegisterResultModel } from './RegisterResultModel';

export default {
  data() {
    return {
      email: '',
      password: '',
      mailError: '',
      passwordError: '',
    };
  },
  methods: {
    login() {
      this.mailError = this.passwordError = '';

      const postModel = {
        email: this.email,
        password: this.password,
      };

      inject(Api).post(RegisterResultModel, '/auth/register', postModel);
    },
  },
};
</script>
../../Services/Api/Api