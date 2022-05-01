<script lang="ts">
import {Component, Vue} from "vue-property-decorator";

@Component
export default class BreakPointsMixin extends Vue {
  get height() {
    switch (this.$vuetify.breakpoint.name) {
      case 'xs':
        return 220
      case 'sm':
        return 400
      case 'md':
        return 500
      case 'lg':
        return 600
      case 'xl':
        return 800
    }
  }

  get heightName() {
    return this.$vuetify.breakpoint.name;
  }

  get isComputer() {
    return this.$vuetify.breakpoint.name === 'xl'
        ||
        this.$vuetify.breakpoint.name === 'lg'
        ||
        this.$vuetify.breakpoint.name === 'md'
  }

  get isMobile() {
    return this.$vuetify.breakpoint.name === 'sm'
        ||
        this.$vuetify.breakpoint.name === 'xs';
  }
}
</script>
<style lang="scss" scoped>

</style>
