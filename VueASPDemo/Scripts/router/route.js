import { createRouter, createWebHistory } from "../vue-router.js"
import Main from '../Views/Main.vue'
import Login from '../Views/Login.vue'
const routes = [{
    path: "",
    redirect: '/Main'
},
{
    path: "/Main",
    name: "Main",
    component: Main
}, {
    path: "/Login",
    name: "Login",
    component: Login
}]
const router = createRouter({
    history: createWebHistory(process.env.BASE_URL),
    routes,
    linkActiveClass: 'active'
})

export default router