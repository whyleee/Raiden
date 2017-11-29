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
    items: [],
    item: null
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
    setItem(state, value) {
      state.item = value
    },
    addItem(state, value) {
      state.items.push(value)
    },
    updateItem(state, value) {
      const index = state.items.findIndex(i => i.id == value.id)
      state.items[index] = value
      if (state.item && state.item.id == value.id) {
        state.item = value
      }
    },
    deleteItem(state, id) {
      const index = state.items.findIndex(i => i.id == id)
      state.items.splice(index, 1)
      if (state.item && state.item.id == id) {
        state.item = null
      }
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
    async fetchItem({ state, commit }, id) {
      let item = state.items.find(i => i.id == id)
      if (!item) {
        const res = await api.data.getById(state.meta.url, id)
        item = res.data
        commit('addItem', item)
      }
      commit('setItem', item)
    },
    async addItem({ state, commit }, item) {
      commit('addItem', item)
      await api.data.post(state.meta.url, item)
    },
    async updateItem({ state, commit }, item) {
      commit('updateItem', item)
      await api.data.put(state.meta.url, item.id, item)
    },
    async deleteItem({ state, commit }, id) {
      commit('deleteItem', id)
      await api.data.delete(state.meta.url, id)
    }
  }
}
