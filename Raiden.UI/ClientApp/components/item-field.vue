<template>
  <b-form-group :horizontal="true" :label="getFieldLabel(field)">
    <item-field-text :item="item" :field="field"></item-field-text>
  </b-form-group>
</template>

<script>
import { mapGetters } from 'vuex'
import ItemFieldText from './item-field-text.vue'

export default {
  components: {
    ItemFieldText
  },
  props: [
    'item',
    'field'
  ],
  computed: {
    ...mapGetters('data', [
      'getFieldLabel'
    ])
  }
}
</script>
