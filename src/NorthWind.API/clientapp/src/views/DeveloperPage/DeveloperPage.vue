<template>
  <div>
    загрузка ассенизатора
    <div style="height: 500px"></div>
    <DxFileUploader
        select-button-text="Select file"
        label-text=""
        upload-mode="instantly"
        :uploadUrl="uploadUrl"
        upload-method="POST"
    />
  </div>
</template>

<script lang="ts">
import {Vue, Component, Ref} from 'vue-property-decorator'

import {DxFileUploader} from 'devextreme-vue/file-uploader'
import {DxTextBox} from 'devextreme-vue/text-box'
import {DxButton} from 'devextreme-vue/button'

@Component(
    {
      components: {
        DxFileUploader,
        DxTextBox,
        DxButton
      }
    }
)
export default class DeveloperPage extends Vue {
  private uploadUrl: string = 'api/test/upload-assenizator-service'

}
</script>
<style scoped>

</style>
