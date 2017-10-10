import Vue from 'vue'
import Vuex from 'vuex'
import counter from './counter'
import data from './data'

Vue.use(Vuex)

const store = new Vuex.Store({
  modules: {
    counter,
    data
  }
})

if (module.hot) {
  module.hot.accept([
    './counter',
    './data'
  ], () => {
    store.hotUpdate({
      modules: {
        /* eslint-disable global-require */
        counter: require('./counter').default,
        data: require('./data').default
        /* eslint-enable */
      }
    })
  })
}

export default store
