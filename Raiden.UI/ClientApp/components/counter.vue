<template>
  <b-row>
    <b-col cols="12" sm="8" md="6" xl="4">
      <b-card border-variant="secondary"
        header="Counter"
        header-bg-variant="secondary"
        header-text-variant="white">
        <p>This is a simple example of a Vue.js component.</p>
        <p>Current count: <strong>{{count}}</strong></p>
        <b-button variant="dark" @click="increment">Increment</b-button>
      </b-card>
    </b-col>
  </b-row>
</template>

<script>
import { mapState, mapMutations } from 'vuex'

export default {
  computed: {
    ...mapState('counter', [
      'count'
    ])
  },
  methods: {
    ...mapMutations('counter', [
      'increment'
    ])
  }
}
</script>
