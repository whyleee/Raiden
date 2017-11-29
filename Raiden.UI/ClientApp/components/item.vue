<template>
  <b-row>
    <b-col cols="12" md="9" xl="6">
      <b-form @submit.prevent="submit">
        <item-field v-for="field in itemFields"
          :key="field.name"
          :item="form"
          :field="field">
        </item-field>
        <b-button type="submit" variant="dark">{{submitButtonText}}</b-button>
      </b-form>
    </b-col>
  </b-row>
</template>

<script>
import { mapState, mapMutations, mapActions } from 'vuex'
import ItemField from './item-field.vue'

export default {
  components: {
    ItemField
  },
  $validates: true,
  data() {
    return {
      form: {}
    }
  },
  async created() {
    await this.fetchMeta()
    if (this.itemId) {
      await this.fetchItem(this.itemId)
    } else {
      this.setItem(null)
    }

    if (this.item) {
      this.meta.itemType.fields.forEach((field) => {
        this.$set(this.form, field.name, this.item[field.name])
      })
    }
    this.form.locale = 'en' // TODO: temp quick set of readonly required param
  },
  computed: {
    ...mapState('data', [
      'meta',
      'item'
    ]),
    itemId() {
      return this.$route.params.id
    },
    itemFields() {
      return this.meta.itemType.fields
    },
    submitButtonText() {
      return this.itemId ? 'Save' : 'Create'
    }
  },
  methods: {
    ...mapMutations('data', [
      'setItem'
    ]),
    ...mapActions('data', [
      'fetchMeta',
      'fetchItem',
      'addItem',
      'updateItem'
    ]),
    async submit() {
      const ok = await this.$validator.validateAll()
      if (!ok) {
        return
      }
      if (this.itemId) {
        await this.updateItem(this.form)
      } else {
        await this.addItem(this.form)
      }
      this.$router.push({ name: 'storage' })
    }
  }
}
</script>
