<template>
  <v-dialog
      ref="dialogRef"
      persistent
      width="500"
      @click:outside="toggleRegisterWindow(false)"
      scrollable
  >
    <v-card>
      <v-card-title>
        <span class="text-h5">Сброс пароля</span>
      </v-card-title>
      <v-card-text>
        <v-row>
          <v-text-field
              outlined
              dense
              v-model="email"
              label="Email"
          />
        </v-row>
        <v-row>
          <div v-if="errorMsg.length" class="error-message">{{ errorMsg }}</div>
        </v-row>
      </v-card-text>
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn
            class="orange darken-3" style="color: white"
            text
            @click="toggleRegisterWindow(false)"
        >
          Отмена
        </v-btn>
        <v-btn
            class="orange darken-3" style="color: white"
            text
            @click="resetPassword"
        >
          Отправить новый пароль на почту
        </v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script lang="ts">
import {Vue, Component, Mixins, Prop, Ref} from "vue-property-decorator";
import HttpServiceMixin from "@/mixins/HttpServiceMixin.vue";
import DialogWindowMixin from "@/mixins/DialogWindowMixin.vue";
import ValidationMixin from "@/mixins/ValidationMixin.vue";
import StringField from "@/components/Fields/StringField.vue";
import AlertMixin from "@/mixins/AlertMixin.vue";

@Component({components: {StringField}})
export default class ResetPasswordConfirm extends Mixins(HttpServiceMixin, DialogWindowMixin, ValidationMixin, AlertMixin) {
  @Prop({required: false, default: () => ''}) initialEmail!: string;
  @Ref('dialogRef') dialogRef!: any;
  email: string = '';

  mounted() {
    this.email = this.initialEmail;
  }


  async resetPassword() {
    const hasErrors = this.hasErrors();

    if (hasErrors) return;

    await this.accountService.ResetPassword(this.email)
        .then(() => {
          this.close();
          this.callAlert({
            delay: 7000,
            message: 'Новый пароль отправлен на почту',
            isError: false
          })
        })
        .catch(error => {
          this.errorMsg = this.getErrorMessage(error);
        })
  }

  hasErrors(): boolean {
    return this.validateComponent();
  }
}
</script>
<style scoped lang="scss">
.error-message {
  color: red;
}
</style>
