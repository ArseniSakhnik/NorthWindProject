<template>
  <v-container v-if="isDataLoaded">
    <assenizator-purchase-view
        v-if="serviceTypeId === 1"
        :local-data="localData"
    />
    <k-g-o-purchase-view
        v-else-if="serviceTypeId === 2"
        :local-data="localData"
    />
  </v-container>
</template>

<script lang="ts">
import {Vue, Component, Mixins} from "vue-property-decorator";
import {AssenizatorPurchaseDto, BasePurchaseDto} from "@/services/PurchaseService/Requests";
import HttpServiceMixin from "@/mixins/HttpServiceMixin.vue";
import {ServiceTypeEnum} from "@/enums/Enums";
import AssenizatorPurchaseView from "@/components/Purchase/AssenizatorPurchaseView.vue";
import KGOPurchaseView from "@/components/Purchase/KGOPurchaseView.vue";

@Component({components: {KGOPurchaseView, AssenizatorPurchaseView}})
export default class PurchaseInfo extends Mixins(HttpServiceMixin) {
  isDataLoaded: boolean = false;
  purchaseId: number = 0;
  serviceTypeId!: ServiceTypeEnum;

  localData: BasePurchaseDto = {
    comment: "",
    email: "",
    middleName: "",
    name: "",
    phoneNumber: "",
    place: "",
    serviceTypeId: undefined,
    surname: ""
  }

  created() {
    this.purchaseId = Number(this.$route.params.id);
  }

  async mounted() {
    this.localData = await this.purchaseService.GetPurchase(this.purchaseId)
        .then(response => response.data);

    this.isDataLoaded = true;
    this.serviceTypeId = this.localData.serviceTypeId as ServiceTypeEnum;
  }
}
</script>
<style scoped lang="scss">
.background-image {
  background-image: url('../assets/backgrounds/documents.jpg');
  height: 20vh;
}
</style>
