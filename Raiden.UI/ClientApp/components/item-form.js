import Vue from 'vue'
import { mapState, mapActions } from 'vuex'

// TODO: move form to item.vue template and make this component item-field for single field only
export default Vue.extend({
  render(createElement) {
    return createElement('b-form', {
      on: {
        submit: this.submit
      }
    }, this.meta.itemType.fields.map((field) => {
      let label = field.name[0].toUpperCase() + field.name.slice(1)
      if (field.attributes && field.attributes.displayName) {
        label = field.attributes.displayName
      }
      return createElement('b-form-group', {
        props: {
          label,
          horizontal: true
        }
      }, [
        createElement('b-form-input', {
          props: {
            type: 'text'
          },
          domProps: {
            value: this.form[field.name]
          },
          on: {
            input(event) {
              this.value = event.target.value
              this.$emit('input', event.target.value)
            }
          }
        })
      ])
    }).concat([
      createElement('b-button', {
        props: {
          type: 'submit',
          variant: 'dark'
        }
      }, [
        'Create'
      ])
    ]))
  },
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
      this.form[field.name] = this.item ? this.item[field.name] : null
    })
  },
  computed: {
    ...mapState('data', [
      'meta'
    ])
  },
  methods: {
    ...mapActions('data', [
      'fetchMeta'
    ]),
    submit() {
      this.$emit('submit', this.form)
    }
  }
})
