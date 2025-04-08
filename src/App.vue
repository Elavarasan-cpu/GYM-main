<template>
  <v-app>
  <NavHeader></NavHeader>
    <v-main :scrollable="true">
      <router-view />
    </v-main>
  </v-app>
</template>

<script lang="ts" setup>
  //
import NavHeader from './components/NavHeader.vue';
</script>
<style>

</style>
