<template>
  <div v-if="isDataLoaded">
    <navbar-user/>
  </div>
</template>

<script lang="ts">
import {Component, Vue} from "vue-property-decorator";
import NavbarUser from "@/components/User/NavbarUser.vue";
import {namespace} from "vuex-class";

const User = namespace('CurrentUserStore');

@Component({components: {NavbarUser}})
export default class UserLayout extends Vue {
  @User.Action('GET_CURRENT_USER_INFO') getCurrentUserInfo!: () => Promise<void>;
  isDataLoaded: boolean = false;


  async created() {
    await this.getCurrentUserInfo()
        .then(() => this.isDataLoaded = true);
  }
}
</script>
<style lang="scss" scoped>

</style>
