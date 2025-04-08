/**
 * router/index.ts
 *
 * Automatic routes for `./src/pages/*.vue`
 */

// Composables
import HomePage from '@/pages/HomePage.vue'
import AmenitiesPage from '@/pages/AmenitiesPage.vue'
import ContactUsPage from '@/pages/ContactUsPage.vue'
import LoginPage from '@/pages/LoginPage.vue'
import MembershipPage from '@/pages/MembershipPage.vue'
import TrainingPage from '@/pages/TrainingPage.vue'
import { createRouter, createWebHistory } from 'vue-router/auto'
import { routes } from 'vue-router/auto-routes'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes:[{
    path: '/',
    name: 'home',
    component: HomePage
  },
  {
    path: '/training',
    name: 'training',
    component: () => import('../pages/TrainingPage.vue')
  },
  {
    path: '/login',
    name: 'login',
    component: () => import('../pages/LoginPage.vue')
  },
  {
    path: '/manage',
    name: 'manage',
    component: () => import('../pages/ManageMembers.vue')
  },
  {
    path: '/membership',
    name: 'membership',
    component: () => import('../pages/MembershipPage.vue')
  },
  {
    path: '/contactus',
    name: 'contactus',
    component: () => import('../pages/ContactUsPage.vue')
  },
  {
    path: '/amenities',
    name: 'amenities',
    component: () => import('../pages/AmenitiesPage.vue')
  }],
})

// Workaround for https://github.com/vitejs/vite/issues/11804
router.onError((err, to) => {
  if (err?.message?.includes?.('Failed to fetch dynamically imported module')) {
    if (!localStorage.getItem('vuetify:dynamic-reload')) {
      console.log('Reloading page to fix dynamic import error')
      localStorage.setItem('vuetify:dynamic-reload', 'true')
      location.assign(to.fullPath)
    } else {
      console.error('Dynamic import error, reloading page did not fix it', err)
    }
  } else {
    console.error(err)
  }
})

router.isReady().then(() => {
  localStorage.removeItem('vuetify:dynamic-reload')
})

export default router
