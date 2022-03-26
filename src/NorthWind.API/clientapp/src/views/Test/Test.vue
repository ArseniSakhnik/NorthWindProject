<template>
  <div>
    <DxFileUploader
        select-button-text="Select file"
        label-text=""
        upload-mode="instantly"
        :uploadUrl="uploadUrl"
        upload-method="POST"
    />
    <img src="api/image/image" alt="Картинки нэма">
  </div>
</template>

<script lang="ts">
import {Vue, Component} from "vue-property-decorator";
import {DxFileUploader} from 'devextreme-vue/file-uploader'

@Component({components: {DxFileUploader}})
export default class Test extends Vue {
  uploadUrl: string = 'api/image/'
}
</script>
<style scoped lang="scss">

</style>
