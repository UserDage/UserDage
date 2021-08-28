import { createApp } from 'vue.js'
import router from '../Scripts/vue-router.js'
import Main from '../Views/VueCom/Main.vue'

createApp(Main).use(router).mount('#app')