<template>
  <v-stepper v-model="currentStep">
    <v-stepper-header>
      <v-stepper-step
          :complete="currentStep > 1"
          step="1"
      >
        Name of step 1
      </v-stepper-step>

      <v-divider></v-divider>

      <v-stepper-step
          :complete="currentStep > 2"
          step="2"
      >
        Name of step 2
      </v-stepper-step>

      <v-divider></v-divider>

      <v-stepper-step step="3">
        Name of step 3
      </v-stepper-step>
    </v-stepper-header>

    <v-stepper-items>
      <v-stepper-content step="1">
        <v-card
            class="mb-12"
            color="grey lighten-1"
            height="200px"
        ></v-card>

        <v-btn
            color="primary"
            @click="currentStep = 2"
        >
          Continue
        </v-btn>

        <v-btn text>
          Cancel
        </v-btn>
      </v-stepper-content>

      <v-stepper-content step="2">
        <v-card
            class="mb-12"
            color="grey lighten-1"
            height="200px"
        ></v-card>

        <v-btn
            color="primary"
            @click="currentStep = 3"
        >
          Continue
        </v-btn>

        <v-btn text>
          Cancel
        </v-btn>
      </v-stepper-content>

      <v-stepper-content step="3">
        <v-card
            class="mb-12"
            color="grey lighten-1"
            height="200px"
        ></v-card>

        <v-btn
            color="primary"
            @click="currentStep = 1"
        >
          Continue
        </v-btn>

        <v-btn text>
          Cancel
        </v-btn>
      </v-stepper-content>
    </v-stepper-items>
  </v-stepper>
</template>

<script lang="ts">
import {Vue, Component, ModelSync} from 'vue-property-decorator'

@Component
export default class CreateServiceStepper extends Vue {
  @ModelSync('step', 'change', {type: Number})
  private currentStep!: number;
}
</script>
<style scoped>

</style>
