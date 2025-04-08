<template>
    <v-container fluid class="fill-height">
      <v-row justify="center" align="center">
        <v-col cols="12" sm="8" md="4">
          <v-card class="pa-6">
            <v-card-title class="text-h5 text-center">Login</v-card-title>
            <v-card-text>
            
              <v-form @submit.prevent="handleLogin">
                <v-text-field
                  v-model="username"
                  label="Username"
                  outlined
                  dense
                  required
                ></v-text-field>
                <v-text-field
                  v-model="password"
                  label="Password"
                  type="password"
                  outlined
                  dense
                  required
                ></v-text-field>
                <v-btn block color="primary" type="submit">Login</v-btn>
              </v-form>
            </v-card-text>
          </v-card>
        </v-col>
      </v-row>
    </v-container>
  </template>
  
  <script setup lang="ts">
  import { validateuser } from "@/Api/api";
import { ref } from "vue";
const props = defineProps<{ login: (username: string, password: string) => void }>();
  const username = ref("");
  const password = ref("");
  
  const handleLogin = async() => {
    await props.login(username.value, password.value);
  }
  </script>
  
  <style scoped>
  .fill-height {
    height: 100vh;
  }
  </style>
  