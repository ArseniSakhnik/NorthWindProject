<template>
  <v-container class="flex-container">
    <v-btn>Назад</v-btn>
    <v-btn
        x-large
        color="warning"
        dark
    >Отправить
    </v-btn>
  </v-container>
</template>

<script lang="ts">
import {Vue, Component} from "vue-property-decorator";

@Component
export default class ActionBar extends Vue {

}
</script>
<style scoped lang="scss">
.flex-container {
  display: flex;
  align-items: center;
  justify-content: space-between;
}
</style>
