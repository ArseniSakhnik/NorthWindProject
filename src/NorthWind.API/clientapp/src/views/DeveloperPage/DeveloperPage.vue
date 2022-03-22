<template>
  <div>
    загрузка ассенизатора
    <div style="height: 500px"></div>
    Ассенизатор Юридическ
    <DxFileUploader
        select-button-text="Select file"
        label-text=""
        upload-mode="instantly"
        :uploadUrl="uploadUrlYur"
        upload-method="POST"
    />
    Ассенизатор Физическ
    <DxFileUploader
        select-button-text="Select file"
        label-text=""
        upload-mode="instantly"
        :uploadUrl="uploadUrlFiz"
        upload-method="POST"
    />
    КГО
    <DxFileUploader
        select-button-text="Select file"
        label-text=""
        upload-mode="instantly"
        :uploadUrl="uploadUrlKgo"
        upload-method="POST"
    />
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
  uploadUrlYur: string = 'api/service/load-template/1'
  uploadUrlFiz: string = 'api/service/load-template/2'
  uploadUrlKgo: string = 'api/service/load-template/3'

}
</script>
<style scoped>
</style>
