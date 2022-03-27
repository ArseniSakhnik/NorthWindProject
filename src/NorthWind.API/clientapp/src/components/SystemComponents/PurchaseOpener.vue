<template>
  <div>
    <v-dialog
        ref="dialogRef"
        persistent
        @click:outside="togglePurchaseWindow(false)"
        width="50%"
    >
      <v-card>
        <v-card-title>
        </v-card-title>
        <v-card-text>
          <v-container>
            <v-row class="dialog-buttons">
              <v-col
                  class="rectangle-button"
                  cols="12"
                  sm="6"
                  @click="pushToRoute(fizRoute)"
              >
                <span>Физическое лицо</span>
              </v-col>
              <v-col
                  class="rectangle-button"
                  cols="12"
                  sm="6"
                  @click="pushToRoute(yurRoute)"
              >
                <span>Юридическое лицо</span>
              </v-col>
            </v-row>
          </v-container>
        </v-card-text>
      </v-card>
    </v-dialog>
    <orange-button
        v-if="doNeedChoose"
        title="Заказать услугу"
        style="margin-right: 1em"
        @action="openConfirm"
    />
    <orange-button
        v-else
        title="Заказать услугу"
        style="margin-right: 1em"
        @action="pushToActiveRoute"

    />
  </div>
</template>

<script lang="ts">
import {Vue, Component, Prop, PropSync, Ref} from "vue-property-decorator";
import OrangeButton from "@/components/Buttons/OrangeButton.vue";

@Component({components: {OrangeButton}})
export default class PurchaseOpener extends Vue {
  @Ref('dialogRef') dialogRef!: any;
  @Prop({required: true}) fizRoute!: string | null;
  @Prop({required: true}) yurRoute!: string | null;
  isActiveSynced: boolean = false;
  
  updated() {
    console.log(this.fizRoute)
    console.log(this.yurRoute)
  }

  get doNeedChoose(): boolean {
    return this.fizRoute !== null && this.yurRoute !== null;
  }

  togglePurchaseWindow(isOpen: boolean) {
    this.dialogRef.isActive = isOpen;
  }

  pushToActiveRoute() {
    const currentRoute: string = (this.fizRoute ?? this.yurRoute) as string;
    this.$router.push(currentRoute);
  }

  pushToRoute(route: string) {
    this.$router.push(route);
  }

  openConfirm() {
    this.dialogRef.isActive = true;
  }
}
</script>
<style scoped lang="scss">
.dialog-buttons {
  display: flex;
  justify-content: space-between;
}

.rectangle-button {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  border-radius: 7px;
  width: 40%;
  height: 40vh;
  border: 1px solid gray;
  cursor: pointer;
  
  span {
    font-size: 2em;
  }
  
}
</style>
