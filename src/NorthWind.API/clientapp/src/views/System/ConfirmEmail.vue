<template>
  <div>
    Подтверждение аккаунта
  </div>
</template>

<script lang="ts">
import {Component, Mixins} from 'vue-property-decorator'
import HttpServiceMixin from "@/mixins/HttpServiceMixin.vue"
import {namespace} from "vuex-class";

const User = namespace('CurrentUserStore');

//TODO Протестировать регистрацию и добавить сервисы!!!!
@Component
export default class ConfirmEmail extends Mixins(HttpServiceMixin) {
  @User.Action('GET_CURRENT_USER_INFO') getCurrentUserInfo!: () => void;

  async mounted() {
    const userId = this.$route.query.userId as string
    const code = this.$route.query.code as string

    await this.accountService.ConfirmEmail({userId, code})
        .then(() => {
          this.getCurrentUserInfo();
          this.$router.push('/')
        })
  }
}
</script>
<style scoped>

</style>
