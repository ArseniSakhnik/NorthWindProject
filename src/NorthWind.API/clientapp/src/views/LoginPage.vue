<template>
  <div>
    <form @submit.prevent="onSubmit">
      <input type="text" v-model="userName">
      <input type="password" v-model="password">
      <button>Войти</button>
    </form>
  </div>
</template>

<script>
import {UserService} from "@/services/UserService";
import {ref} from "vue";

export default {
  name: "LoginPage",
  setup() {
    const userName = ref('');
    const password = ref('');
    const userService = new UserService();
    
    
    const onSubmit = () => {
      userService.logIn(userName.value, password.value)
      .then();
    };
    
    return {
      userName,
      password,
      onSubmit
    }
  }
}
</script>

<style scoped>

</style>