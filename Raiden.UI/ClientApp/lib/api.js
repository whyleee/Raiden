import axios from 'axios'
import config from '../config'

export default {
  meta: {
    url: `${config.apiUrl}/meta`,
    get() {
      return axios.get(this.url)
    }
  },
  data: {
    baseUrl: `${config.apiUrl}`,
    get(url) {
      return axios.get(this.baseUrl + url)
    },
    getById(url, id) {
      return axios.get(`${this.baseUrl}${url}/${id}`)
    },
    post(url, item) {
      return axios.post(this.baseUrl + url, item)
    },
    put(url, id, item) {
      return axios.put(`${this.baseUrl}${url}/${id}`, item)
    }
  }
}
