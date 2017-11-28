<template>
  <div>
    <b-form-checkbox-group
      :name="field.name"
      v-model="item[field.name]"
      :options="options"
      stacked>
    </b-form-checkbox-group>
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
  created() {
    this.attachValidators()
  },
  computed: {
    ...mapGetters('data', [
      'getFieldLabel'
    ]),
    options() {
      return this.field.attributes.selectOptions
    }
  },
  methods: {
    attachValidators() {
      this.$validator.attach({
        name: this.field.name,
        alias: this.getFieldLabel(this.field),
        getter: () => this.item[this.field.name],
        rules: {
          required: !!this.field.attributes.required
        }
      })
    }
  }
}
</script>
