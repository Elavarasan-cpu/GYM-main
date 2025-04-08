<template>
    <v-app-bar color="black" class="custom-navbar" density="default">
      <v-container class="d-flex align-center">
        <!-- Logo and Title -->
        <div class="d-flex align-center">
          <v-img src="../assets/logo3.png" alt="Logo" min-height="40" min-width="100" contain class="mr-2" />
          <span class="font-weight-bold text-h6 site-title">Meridian Fitness</span>
        </div>
  
        <v-spacer></v-spacer>
  
        <!-- Navigation Links -->
        <div class="nav-links">
          <v-btn
            v-for="item in menuItems"
            :key="item.text"
            :to="item.route"
            variant="plain"
            class="nav-btn ma-2"
            exact
          >
            {{ item.text }}
          </v-btn>
        </div>
      </v-container>
    </v-app-bar>
  </template>
  
  <script setup lang="ts">
  import { ref } from 'vue';
  
  const menuItems = ref([
    { text: 'Home', route: '/' },
    { text: 'Amenities', route: '/amenities' },
    { text: 'Training', route: '/training' },
    { text: 'Membership', route: '/membership' },
    { text: 'Contact Us', route: '/contactus' },
    { text: 'Manage', route: '/manage' }
  ]);
  </script>
  
  <style scoped>
  /* Modern Glass Navbar */
  .custom-navbar {
    background: rgba(0, 0, 0, 0.7) !important; /* Semi-transparent */
    backdrop-filter: blur(10px); /* Blur effect */
    box-shadow: 0px 4px 10px rgba(0, 0, 0, 0.2);
  }
  
  /* Site Title */
  .site-title {
    color: white;
    font-size: 18px;
  }
  
  /* Navigation Button Styles */
  .nav-links .nav-btn {
    color: white;
    text-transform: none;
    font-size: 16px;
    font-weight: 500;
    transition: color 0.3s, transform 0.2s;
  }
  
  /* Hover & Active Effects */
  .nav-links .nav-btn:hover {
    color: #ffcc00 !important; /* Golden color on hover */
    transform: scale(1.1);
  }
  .v-btn--active{
    border-bottom: 5px solid #ffcc00; /* Underline effect for active page */
    color: #ffcc00 !important; /* Golden color on hover */
    transform: scale(1.1);
  }             
  .nav-links .nav-btn.router-link-exact-active {
    border-bottom: 2px solid #ffcc00; /* Underline effect for active page */
  }
  </style>
  