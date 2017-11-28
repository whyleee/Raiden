<template>
  <b-form-group :horizontal="true" :label="getFieldLabel(field)">
    <item-field-date v-if="field.type == 'datetime'" :item="item" :field="field"></item-field-date>
    <item-field-text v-else :item="item" :field="field"></item-field-text>
  </b-form-group>
</template>

<script>
import { mapGetters } from 'vuex'
import ItemFieldDate from './item-field-date.vue'
import ItemFieldText from './item-field-text.vue'

export default {
  components: {
    ItemFieldDate,
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
