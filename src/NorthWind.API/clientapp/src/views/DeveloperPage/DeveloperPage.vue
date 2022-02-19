<template>
  <div>
    <!--    загрузка ассенизатора-->
    <!--    <div style="height: 500px"></div>-->
    <!--    <DxFileUploader-->
    <!--        select-button-text="Select file"-->
    <!--        label-text=""-->
    <!--        upload-mode="instantly"-->
    <!--        :uploadUrl="uploadUrl"-->
    <!--        upload-method="POST"-->
    <!--    />-->

    <map-svg/>

  </div>
</template>

<script lang="ts">
import {Vue, Component, Ref} from 'vue-property-decorator'

import {DxFileUploader} from 'devextreme-vue/file-uploader'
import {DxTextBox} from 'devextreme-vue/text-box'
import {DxButton} from 'devextreme-vue/button'
import MapSvg from "@/icons/Map.vue";

@Component(
    {
      components: {
        DxFileUploader,
        DxTextBox,
        DxButton,
        MapSvg
      }
    }
)
export default class DeveloperPage extends Vue {

}
</script>
<style scoped>
</style>
