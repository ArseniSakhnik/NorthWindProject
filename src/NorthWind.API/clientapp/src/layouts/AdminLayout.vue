<template>
  <v-app>
    <navbar-admin/>
    <v-container>
      <router-view/>
    </v-container>
  </v-app>
</template>

<script lang="ts">
import {Vue, Component} from 'vue-property-decorator'
import AdminSidebar from "@/components/Admin/AdminSidebar.vue";
import Navbar from "@/components/Navbar.vue";
import NavbarAdmin from "@/components/Admin/NavbarAdmin.vue";

@Component({components: {NavbarAdmin}})
export default class AdminLayout extends Vue {

}
</script>
<style scoped>

</style>
