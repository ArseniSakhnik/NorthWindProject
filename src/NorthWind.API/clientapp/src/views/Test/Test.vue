<template>
  <div>
    <DxFileUploader
        :uploadUrl="uploadUrl"
        label-text=""
        select-button-text="Select file"
        upload-method="POST"
        upload-mode="instantly"
    />
    <img alt="Картинки нэма" src="api/ServiceView/mainimage/1">
  </div>
</template>

<script lang="ts">
import {Component, Vue} from "vue-property-decorator";
import {DxFileUploader} from 'devextreme-vue/file-uploader'

@Component({components: {DxFileUploader}})
export default class Test extends Vue {
  uploadUrl: string = 'api/image/'
}
</script>
<style lang="scss" scoped>

</style>
