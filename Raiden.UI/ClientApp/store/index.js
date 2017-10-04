import Vue from 'vue'
import Vuex from 'vuex'
import counter from './counter'

Vue.use(Vuex)

const store = new Vuex.Store({
  modules: {
    counter
  }
})

if (module.hot) {
  module.hot.accept([
    './counter'
  ], () => {
    store.hotUpdate({
      modules: {
        /* eslint-disable global-require */
        counter: require('./counter').default
        /* eslint-enable */
      }
    })
  })
}

export default store
