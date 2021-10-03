<template>
  <div>
    <form @submit.prevent="onSubmit">
      <input type="text" v-model="userName">
      <input type="password" v-model="password">
      <button>Войти</button>
    </form>
  </div>
</template>

<script lang="ts">
import {defineComponent, ref} from "vue";
import {UserService} from '@/services/UserService'

export default defineComponent({
  name: "LoginPage",
  setup() {
    const userName = ref('');
    const password = ref('');
    const userService = new UserService();


    const onSubmit = () => {
      userService.logIn(userName.value, password.value)
    };

    return {
      userName,
      password,
      onSubmit
    }
  }
})
</script>

<style scoped>

</style>