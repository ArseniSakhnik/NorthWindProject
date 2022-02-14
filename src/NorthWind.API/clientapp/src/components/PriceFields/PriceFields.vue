<template>
  <v-container fluid>
    <h2 class="headline font-weight-bold mb-3">Данные о пользователе</h2>
    <v-row>
      <v-col
          cols="12"
          sm="6"
      >
        <v-text-field
            outlined
            dense
            label="Расстояние"
            :value="distance"
            readonly
        />
      </v-col>
      <v-col
          cols="12"
          sm="6"
      >
        <v-text-field
            outlined
            dense
            label="Приблизительная стоимость"
            :value="price"
            readonly
        />
      </v-col>
    </v-row>
  </v-container>
</template>

<script lang="ts">
import {Vue, Component, Prop} from "vue-property-decorator";

@Component
export default class PriceFields extends Vue {
  @Prop({required: true, type: Number})
  price!: number;
  
  @Prop({required: true, type: Number})
  distance!: number;
}
</script>
<style scoped lang="scss">

</style>
