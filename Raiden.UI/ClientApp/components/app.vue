<template>
  <div>
    <navbar></navbar>
    <b-container fluid>
      <router-view></router-view>
    </b-container>
  </div>
</template>

<script>
import Navbar from './navbar.vue'

export default {
  components: {
    Navbar
  }
}
</script>

<style lang="stylus">
  body
    padding-top: 5rem

  .welcome
    padding: 3rem 1.5rem
    text-align: center
</style>
