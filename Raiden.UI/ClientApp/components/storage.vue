<template>
  <b-row>
    <b-col>
      <h1>{{meta.name}}</h1>
      <b-button-toolbar class="storage-toolbar">
        <b-button-group>
          <b-btn to="/storage/create">Create</b-btn>
        </b-button-group>
      </b-button-toolbar>
      <b-table striped hover :fields="itemFields" :items="items">
        <template slot="actions" scope="row">
          <b-link :to="{ name: 'item', params: { id: row.item.id }}">Edit</b-link>
        </template>
      </b-table>
    </b-col>
  </b-row>
</template>

<script>
import { mapState, mapActions } from 'vuex'
import { format as formatDate } from 'date-fns/esm'

export default {
  async created() {
    await this.fetchMeta()
    await this.fetchItems()
  },
  computed: {
    ...mapState('data', [
      'meta',
      'items'
    ]),
    itemFields() {
      return this.meta.itemType.fields.map((field) => {
        return {
          key: field.name,
          label: field.attributes.displayName,
          formatter: (value) => {
            if (!value) {
              return ''
            }
            if (field.type == 'string') {
              if (field.kind == 'Url') {
                return `<a href="${value}">${value}</a>`
              } else if (field.kind == 'ImageUrl') {
                return `<img src="${value}" style="max-width: 200px; max-height: 200px">`
              }
            } else if (field.type == 'number') {
              if (field.kind == 'Currency') {
                return new Intl.NumberFormat(/* locales */undefined, {
                  style: 'currency',
                  currency: 'USD'
                }).format(value)
              }
            } else if (field.type == 'bool') {
              return value ? '✔' : '✘'
            } else if (field.type == 'datetime') {
              return formatDate(value, 'MMMM D, YYYY')
            } else if (field.type == 'array') {
              const options = field.attributes.selectOptions
              return value
                .map(val => options.find(opt => opt.value == val).text)
                .join(', ')
            }
            return value
          }
        }
      }).concat([{
        key: 'actions',
        label: 'Actions'
      }])
    }
  },
  methods: {
    ...mapActions('data', [
      'fetchMeta',
      'fetchItems'
    ])
  }
}
</script>

<style lang="stylus">
.storage-toolbar
  margin: 1rem 0
</style>
