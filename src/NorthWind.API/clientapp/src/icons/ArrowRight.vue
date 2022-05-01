<template>
  <svg fill="none" height="62" viewBox="0 0 62 62" width="62" xmlns="http://www.w3.org/2000/svg">
    <g filter="url(#filter0_d_402_1773)">
      <g filter="url(#filter1_b_402_1773)">
        <circle cx="32" cy="32" fill="#F3F3F3" fill-opacity="0.12" r="17"/>
        <circle cx="32" cy="32" r="16.5" stroke="#FF9B52"/>
      </g>
      <path d="M25 32H39" stroke="#FF9B52" stroke-linecap="round" stroke-linejoin="round" stroke-width="2"/>
      <path d="M32 25L39 32L32 39" stroke="#FF9B52" stroke-linecap="round" stroke-linejoin="round" stroke-width="2"/>
    </g>
    <defs>
      <filter id="filter0_d_402_1773" color-interpolation-filters="sRGB" filterUnits="userSpaceOnUse" height="62" width="62" x="0"
              y="0">
        <feFlood flood-opacity="0" result="BackgroundImageFix"/>
        <feColorMatrix in="SourceAlpha" result="hardAlpha" type="matrix"
                       values="0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 127 0"/>
        <feOffset dx="-1" dy="-1"/>
        <feGaussianBlur stdDeviation="7"/>
        <feComposite in2="hardAlpha" operator="out"/>
        <feColorMatrix type="matrix" values="0 0 0 0 1 0 0 0 0 0.650771 0 0 0 0 0.395833 0 0 0 1 0"/>
        <feBlend in2="BackgroundImageFix" mode="normal" result="effect1_dropShadow_402_1773"/>
        <feBlend in="SourceGraphic" in2="effect1_dropShadow_402_1773" mode="normal" result="shape"/>
      </filter>
      <filter id="filter1_b_402_1773" color-interpolation-filters="sRGB" filterUnits="userSpaceOnUse" height="42" width="42" x="11"
              y="11">
        <feFlood flood-opacity="0" result="BackgroundImageFix"/>
        <feGaussianBlur in="BackgroundImage" stdDeviation="2"/>
        <feComposite in2="SourceAlpha" operator="in" result="effect1_backgroundBlur_402_1773"/>
        <feBlend in="SourceGraphic" in2="effect1_backgroundBlur_402_1773" mode="normal" result="shape"/>
      </filter>
    </defs>
  </svg>
</template>

<script lang="ts">
import {Component, Vue} from "vue-property-decorator";

@Component
export default class ArrowRight extends Vue {

}
</script>
<style lang="scss" scoped>

</style>
