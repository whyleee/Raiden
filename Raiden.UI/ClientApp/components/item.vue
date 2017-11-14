<template>
  <b-row>
    <b-col cols="12" md="9" xl="6">
      <item-form :item="item"></item-form>
    </b-col>
  </b-row>
</template>

<script>
import ItemForm from './item-form'

export default {
  components: {
    ItemForm
  },
  props: [
    'item'
  ]
}
</script>
