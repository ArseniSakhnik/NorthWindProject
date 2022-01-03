<template>
  <form
      id="form"
      method="post"
      action=""
      enctype="multipart/form-data"
  >
    <h3>Profile Settings</h3>
    <div class="dx-fieldset">
      <div class="dx-field">
        <div class="dx-field-label">First Name:</div>
        <DxTextBox
            value="John"
            name="FirstName"
            class="dx-field-value"
        />
      </div>
      <div class="dx-field">
        <div class="dx-field-label">Last Name:</div>
        <DxTextBox
            name="LastName"
            value="Smith"
            class="dx-field-value"
        />
      </div>
    </div>
    <div class="fileuploader-container">
      <DxFileUploader
          select-button-text="Select photo"
          label-text=""
          accept="image/*"
          upload-mode="useForm"
      />
    </div>
    <DxButton
        class="button"
        text="Update profile"
        type="success"
    />
  </form>
</template>

<script lang="ts">
import {Vue, Component} from 'vue-property-decorator'

import { DxFileUploader } from 'devextreme-vue/file-uploader';
import { DxTextBox } from 'devextreme-vue/text-box';
import { DxButton } from 'devextreme-vue/button';

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
  
}
</script>
<style scoped>

</style>
