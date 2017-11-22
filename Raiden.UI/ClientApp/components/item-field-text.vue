<template>
<div>
  <b-form-input type="text"
    :name="field.name"
    v-model="item[field.name]"
    :readonly="readonly"
    v-validate="validators"
    :data-vv-as="getFieldLabel(field)"
    :state="state">
  </b-form-input>
  <b-form-feedback>
    {{errors.first(field.name)}}
  </b-form-feedback>
</div>
</template>

<script>
import { mapGetters } from 'vuex'

export default {
  inject: ['$validator'],
  props: [
    'item',
    'field'
  ],
  computed: {
    ...mapGetters('data', [
      'getFieldLabel'
    ]),
    readonly() {
      return this.field.attributes.readonly
    },
    validators() {
      return {
        required: !!this.field.attributes.required
      }
    },
    state() {
      if (this.errors.has(this.field.name)) {
        return 'invalid'
      }
      return null
    }
  }
}
</script>
