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
export default {
  props: [
    'item',
    'field'
  ],
  computed: {
    options() {
      return this.field.attributes.selectOptions
    }
  }
}
</script>
