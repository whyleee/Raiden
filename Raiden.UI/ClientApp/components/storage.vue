<template>
  <b-row>
    <b-col>
      <h1>{{meta.name}}</h1>
      <b-table striped hover :items="items"></b-table>
    </b-col>
  </b-row>
</template>

<script>
import { mapState, mapActions } from 'vuex'

export default {
  async created() {
    await this.fetchMeta()
    await this.fetchItems()
  },
  computed: {
    ...mapState('data', [
      'meta',
      'items'
    ])
  },
  methods: {
    ...mapActions('data', [
      'fetchMeta',
      'fetchItems'
    ])
  }
}
</script>
