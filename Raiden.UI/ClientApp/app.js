import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'

import 'babel-polyfill'
import Vue from 'vue'
import VueRouter from 'vue-router'
import BootstrapVue from 'bootstrap-vue'
import VeeValidate from 'vee-validate'

import store from './store'

import App from './components/app.vue'
import Home from './components/home.vue'
import Counter from './components/counter.vue'
import Storage from './components/storage.vue'
import Item from './components/item.vue'

Vue.use(VueRouter)
Vue.use(BootstrapVue)
Vue.use(VeeValidate, { inject: false })

const routes = [
  { path: '/', component: Home },
  { path: '/counter', component: Counter },
  { path: '/storage', name: 'storage', component: Storage },
  { path: '/storage/create', component: Item },
  { path: '/storage/:id', name: 'item', component: Item }
]

const router = new VueRouter({
  mode: 'history',
  routes
})

// eslint-disable-next-line no-new
new Vue({
  el: '#app',
  store,
  router,
  render: h => h(App)
})
