import api from '../lib/api'

export default {
  namespaced: true,
  state: {
    meta: {
      itemType: {
        fields: []
      },
      collections: []
    },
    items: []
  },
  getters: {
    getFieldLabel: () => (field) => {
      return field.attributes.displayName ||
        field.name[0].toUpperCase() + field.name.slice(1)
    }
  },
  mutations: {
    setMeta(state, value) {
      state.meta = value
    },
    setItems(state, value) {
      state.items = value
    },
    addItem(state, value) {
      state.items.push(value)
    }
  },
  actions: {
    async fetchMeta({ commit }) {
      const res = await api.meta.get()
      commit('setMeta', res.data)
    },
    async fetchItems({ state, commit }) {
      const res = await api.data.get(state.meta.url)
      commit('setItems', res.data)
    },
    async addItem({ state, commit }, item) {
      commit('addItem', item)
      await api.data.post(state.meta.url, item)
    }
  }
}
