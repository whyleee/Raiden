<template>
  <b-form-group :horizontal="true" :label="getFieldLabel(field)">
    <item-field-checkbox v-if="field.type == 'bool'" :item="item" :field="field"></item-field-checkbox>
    <item-field-date v-else-if="field.type == 'datetime'" :item="item" :field="field"></item-field-date>
    <item-field-text v-else :item="item" :field="field"></item-field-text>
  </b-form-group>
</template>

<script>
import { mapGetters } from 'vuex'
import ItemFieldCheckbox from './item-field-checkbox.vue'
import ItemFieldDate from './item-field-date.vue'
import ItemFieldText from './item-field-text.vue'

export default {
  components: {
    ItemFieldCheckbox,
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
