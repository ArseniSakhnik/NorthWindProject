<template>
  <v-dialog
      ref="dialogRef"
      persistent
      width="500"
      @click:outside="toggleRegisterWindow(false)"
      scrollable
  >
    <v-card>
      <v-card-title>Информация об обратном звонке</v-card-title>
      <v-card-text>
        <string-field
            ref="1"
            label="ФИО"
            :is-readonly="true"
        />
        <string-field
            ref="2"
            label="Номер телефона"
            :is-readonly="true"
        />
        <v-text-field
            label="Комментарий"
            outlined
            dense
            readonly
            :readonly="true"
        />
      </v-card-text>
    </v-card>
  </v-dialog>
</template>

<script lang="ts">
import {Vue, Component, Mixins, Prop} from "vue-property-decorator";
import DialogWindowMixin from "@/mixins/DialogWindowMixin.vue";
import StringField from "@/components/Fields/StringField.vue";

@Component({
  components: {StringField}
})
export default class RequestCallConfirm extends Mixins(DialogWindowMixin) {
  
}
</script>
<style scoped lang="scss">

</style>
