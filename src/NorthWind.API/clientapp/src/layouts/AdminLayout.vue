<template>
  <v-app>
    <navbar-admin/>
    <v-container>
      <router-view/>
    </v-container>
  </v-app>
</template>

<script lang="ts">
import {Component, Vue} from 'vue-property-decorator'
import NavbarAdmin from "@/components/Admin/NavbarAdmin.vue";

@Component({components: {NavbarAdmin}})
export default class AdminLayout extends Vue {

}
</script>
<style scoped>

</style>
