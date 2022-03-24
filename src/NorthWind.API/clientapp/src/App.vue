<template>
  <component :is="$route.meta.layout + '-layout'" v-if="isDataLoaded">
  </component>
</template>

<script lang="ts">
import {Component, Vue} from 'vue-property-decorator'
import MainLayout from '@/layouts/MainLayout.vue'
import AdminLayout from '@/layouts/AdminLayout.vue'
import SystemLayout from "@/layouts/SystemLayout.vue"
import ActionLayout from "@/layouts/ActionLayout.vue"
import {namespace} from "vuex-class";

const User = namespace('CurrentUserStore');

@Component({components: {MainLayout, AdminLayout, SystemLayout, ActionLayout}})
export default class App extends Vue {
  @User.Action('GET_CURRENT_USER_INFO') getCurrentUserInfo!: () => Promise<void>;
  isDataLoaded: boolean = false;

  async created() {
    await this.getCurrentUserInfo()
        .then(() => this.isDataLoaded = true);
  }
}
</script>
<style scoped>

</style>

