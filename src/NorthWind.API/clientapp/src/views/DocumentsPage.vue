<template>
  <div>
    <div class="background-image">
      <h2> Документы </h2>
    </div>
    <v-container>
      <img v-for="item in documents"
           :key="item.name"
           :src="getImagePath(item.name)"
           alt="Не удалось загрузить изображение"
      >
    </v-container>
  </div>
</template>

<script lang="ts">
import {Vue, Component} from "vue-property-decorator";

@Component
export default class DocumentsPage extends Vue {
  documents = [
    {
      name: 'License1.jpg',
    },
    {
      name: 'License2.jpg'
    },
    {
      name: 'Сertificate.jpg'
    }
  ];


  getImagePath(imgName: string): string {
    return `/ServiceImage/documents/${imgName}`;
  }
}

</script>
<style scoped lang="scss">
.background-image {
  background-image: url('../assets/backgrounds/documents.jpg');
}
</style>
