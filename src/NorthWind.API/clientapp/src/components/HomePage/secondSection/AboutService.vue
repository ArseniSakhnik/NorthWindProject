<template>
  <div>
    <v-btn text color="#FF9B52">
      <v-icon left>
        mdi-arrow-up-left
      </v-icon>
      На главную
    </v-btn>
    <div class="flex justify-between items-center">
      <h2>Как то сюда надо через эмит передать заголовок____</h2>
      <p>ООО "Северный Ветер" предоставляет услуги специализированной техники по вывозу и ликвидировании отходов
        твердого и жидкого типа в Крыму. </p>
    </div>
  </div>
</template>

<script lang="ts">
import {Vue, Component} from 'vue-property-decorator'

@Component
export default class AboutService extends Vue {
}
</script>

<style scoped>

</style>
