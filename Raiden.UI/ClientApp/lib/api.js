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
    }
  }
}
