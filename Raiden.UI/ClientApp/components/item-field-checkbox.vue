<template>
  <div>
    <b-form-checkbox
      :name="field.name"
      v-model="item[field.name]"
      :disabled="readonly">
    </b-form-checkbox>
  </div>
</template>

<script>
export default {
  props: [
    'item',
    'field'
  ],
  computed: {
    readonly() {
      return this.field.attributes.readonly
    }
  }
}
</script>
