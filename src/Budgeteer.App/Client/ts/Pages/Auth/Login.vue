<template>
  <form class="mx-auto w-full max-w-xl mt-10 flex flex-col" @submit="login()" method="dialog">
    <label for="Login" class="text-xs text-gray-400">E-Mail-Adresse</label>
    <input type="email" id="EMail" name="EMail" autocomplete="email" v-model="email" />

    <label for="Password" class="text-xs text-gray-400 mt-4">Passwort</label>
    <input type="password" id="Password" name="Password" autocomplete="current-password" v-model="password" />

    <div v-if="!!error" class="">
      {{ error }}
    </div>

    <Button type="submit" kind="success">Anmelden</Button>

    <RouterLink to="/auth/register" class="text-sm text-emerald-700">
      <i class="fa-solid fa-arrow-right mr-1"></i>
      <span>Jetzt registrieren</span>
    </RouterLink>
  </form>
</template>

<script lang="ts">
import { inject } from '../../Services/Di';
import { Api } from '../../Services/Api';
import { LoginResultModel } from './LoginResultModel';
import { LoginResultCode } from './LoginResultCode';

export default {
  data() {
    return {
      email: '',
      password: '',
      error: '',
    };
  },
  methods: {
    login() {
      this.error = '';

      const postModel = {
        email: this.email,
        password: this.password,
      };

      inject(Api)
        .post(LoginResultModel, '/auth/login', postModel)
        .catch((e) => LoginResultModel.Failure)
        .then((r) => {
          if (r.code !== LoginResultCode.success) {
            this.error = 'E-Mail-Adresse und Passwort passen nicht zusammen.';
          }
        });
    },
  },
};
</script>
