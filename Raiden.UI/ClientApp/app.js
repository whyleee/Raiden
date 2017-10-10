import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'

import 'babel-polyfill'
import Vue from 'vue'
import VueRouter from 'vue-router'
import BootstrapVue from 'bootstrap-vue'

import store from './store'

import App from './components/app.vue'
import Home from './components/home.vue'
import Counter from './components/counter.vue'
import Storage from './components/storage.vue'

Vue.use(VueRouter)
Vue.use(BootstrapVue)

const routes = [
  { path: '/', component: Home },
  { path: '/counter', component: Counter },
  { path: '/storage', component: Storage }
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
