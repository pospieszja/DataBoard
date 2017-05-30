var app = new Vue({
  el: '#app',
  data: {
    users: []
  },
  mounted() {
    axios.get('/api/users').then(response => { this.users = response.data })
  }

})