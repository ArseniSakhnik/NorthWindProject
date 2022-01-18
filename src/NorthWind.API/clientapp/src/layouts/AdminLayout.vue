<template>
  <v-app>
    <admin-navbar/>
    <admin-sidebar/>
    <admin-actionbar/>
    <v-main>
      <router-view/>
    </v-main>
    <admin-footer/>
  </v-app>
</template>

<script lang="ts">
import {Vue, Component} from 'vue-property-decorator'
import AdminNavbar from '@/components/Admin/AdminNavbar.vue'
import AdminSidebar from '@/components/Admin/AdminSidebar.vue'
import AdminActionbar from '@/components/Admin/AdminActionbar.vue'
import AdminFooter from '@/components/Admin/AdminFooter.vue'

@Component({components: {AdminNavbar, AdminSidebar, AdminActionbar, AdminFooter}})
export default class AdminLayout extends Vue {

}
</script>
<style scoped>

</style>
