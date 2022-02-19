<template>
  <svg width="62" height="62" viewBox="0 0 62 62" fill="none" xmlns="http://www.w3.org/2000/svg">
    <g filter="url(#filter0_d_402_1773)">
      <g filter="url(#filter1_b_402_1773)">
        <circle cx="32" cy="32" r="17" fill="#F3F3F3" fill-opacity="0.12"/>
        <circle cx="32" cy="32" r="16.5" stroke="#FF9B52"/>
      </g>
      <path d="M25 32H39" stroke="#FF9B52" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"/>
      <path d="M32 25L39 32L32 39" stroke="#FF9B52" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"/>
    </g>
    <defs>
      <filter id="filter0_d_402_1773" x="0" y="0" width="62" height="62" filterUnits="userSpaceOnUse" color-interpolation-filters="sRGB">
        <feFlood flood-opacity="0" result="BackgroundImageFix"/>
        <feColorMatrix in="SourceAlpha" type="matrix" values="0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 127 0" result="hardAlpha"/>
        <feOffset dx="-1" dy="-1"/>
        <feGaussianBlur stdDeviation="7"/>
        <feComposite in2="hardAlpha" operator="out"/>
        <feColorMatrix type="matrix" values="0 0 0 0 1 0 0 0 0 0.650771 0 0 0 0 0.395833 0 0 0 1 0"/>
        <feBlend mode="normal" in2="BackgroundImageFix" result="effect1_dropShadow_402_1773"/>
        <feBlend mode="normal" in="SourceGraphic" in2="effect1_dropShadow_402_1773" result="shape"/>
      </filter>
      <filter id="filter1_b_402_1773" x="11" y="11" width="42" height="42" filterUnits="userSpaceOnUse" color-interpolation-filters="sRGB">
        <feFlood flood-opacity="0" result="BackgroundImageFix"/>
        <feGaussianBlur in="BackgroundImage" stdDeviation="2"/>
        <feComposite in2="SourceAlpha" operator="in" result="effect1_backgroundBlur_402_1773"/>
        <feBlend mode="normal" in="SourceGraphic" in2="effect1_backgroundBlur_402_1773" result="shape"/>
      </filter>
    </defs>
  </svg>
</template>

<script lang="ts">
import {Vue, Component} from "vue-property-decorator";

@Component
export default class ArrowRight extends Vue {
  
}
</script>
<style scoped lang="scss">

</style>
