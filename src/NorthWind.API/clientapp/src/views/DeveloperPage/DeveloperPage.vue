<template>
  <div>
    загрузка ассенизатора
    <div style="height: 500px"></div>
    Ассенизатор Юридическ
    <DxFileUploader
        :uploadUrl="uploadUrlYur"
        label-text=""
        select-button-text="Select file"
        upload-method="POST"
        upload-mode="instantly"
    />
    Ассенизатор Физическ
    <DxFileUploader
        :uploadUrl="uploadUrlFiz"
        label-text=""
        select-button-text="Select file"
        upload-method="POST"
        upload-mode="instantly"
    />
    КГО
    <DxFileUploader
        :uploadUrl="uploadUrlKgo"
        label-text=""
        select-button-text="Select file"
        upload-method="POST"
        upload-mode="instantly"
    />
    <v-btn @click="test">Ошибка в строке</v-btn>
    <v-btn>Ошибка валидации</v-btn>
    <v-btn>Успешно строка</v-btn>
    <v-btn>Успешно объект</v-btn>
  </div>
</template>

<script lang="ts">
import {Component, Vue} from 'vue-property-decorator'

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
