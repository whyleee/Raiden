<template>
  <b-form-group
    :horizontal="true"
    :label="getFieldLabel(field)"
    :feedback="errors.first(field.name)"
    :state="state">
    <item-field-checkbox v-if="field.type == 'bool'" :item="item" :field="field"></item-field-checkbox>
    <item-field-date v-else-if="field.type == 'datetime'" :item="item" :field="field"></item-field-date>
    <item-field-select-many v-else-if="field.type == 'array'" :item="item" :field="field"></item-field-select-many>
    <item-field-text v-else :item="item" :field="field"></item-field-text>
  </b-form-group>
</template>

<script>
import { mapGetters } from 'vuex'
import ItemFieldCheckbox from './item-field-checkbox.vue'
import ItemFieldDate from './item-field-date.vue'
import ItemFieldSelectMany from './item-field-select-many.vue'
import ItemFieldText from './item-field-text.vue'

export default {
  components: {
    ItemFieldCheckbox,
    ItemFieldDate,
    ItemFieldSelectMany,
    ItemFieldText
  },
  inject: ['$validator'],
  props: [
    'item',
    'field'
  ],
  computed: {
    ...mapGetters('data', [
      'getFieldLabel'
    ]),
    state() {
      if (this.errors.has(this.field.name)) {
        return 'invalid'
      }
      return null
    }
  }
}
</script>
