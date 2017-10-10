<template>
  <b-navbar toggleable="md" type="dark" variant="dark" fixed="top">
    <b-navbar-brand to="/">Raiden UI</b-navbar-brand>
    <b-nav-toggle target="nav_collapse"></b-nav-toggle>
    <b-collapse is-nav id="nav_collapse">
      <b-nav is-nav-bar>
        <b-nav-item v-for="item in items" :key="item.to" :to="item.to">{{item.title}}</b-nav-item>
      </b-nav>
    </b-collapse>
  </b-navbar>
</template>

<script>
export default {
  data() {
    return {
      items: [
        { title: 'Counter', to: '/counter' },
        { title: 'Storage', to: '/storage' }
      ]
    }
  }
}
</script>
