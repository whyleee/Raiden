<template>
  <b-row>
    <b-col cols="12" md="9" xl="6">
      <b-form @submit.prevent="submit">
        <item-field v-for="field in itemFields"
          :key="field.name"
          :item="form"
          :field="field">
        </item-field>
        <b-button type="submit" variant="dark">Create</b-button>
      </b-form>
    </b-col>
  </b-row>
</template>

<script>
import { mapState, mapActions } from 'vuex'
import ItemField from './item-field.vue'

export default {
  components: {
    ItemField
  },
  $validates: true,
  props: [
    'item'
  ],
  data() {
    return {
      form: {}
    }
  },
  async created() {
    await this.fetchMeta()
    this.meta.itemType.fields.forEach((field) => {
      if (this.item) {
        this.form[field.name] = this.item[field.name]
      }
    })
    this.form.locale = 'en' // TODO: temp quick set of readonly required param
  },
  computed: {
    ...mapState('data', [
      'meta'
    ]),
    itemFields() {
      return this.meta.itemType.fields
    }
  },
  methods: {
    ...mapActions('data', [
      'fetchMeta',
      'addItem'
    ]),
    async submit() {
      const ok = await this.$validator.validateAll()
      if (!ok) {
        return
      }
      await this.addItem(this.form)
      this.$router.go(-1)
    }
  }
}
</script>
