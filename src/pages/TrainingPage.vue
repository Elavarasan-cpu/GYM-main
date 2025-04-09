<template>
      <v-container>
    <v-row>
        <v-col>
            <div class="text-h3 text-center ma-3" id="h1">Training</div>
        </v-col>
    </v-row>
    <v-row>
        <v-col v-for="(facility,index) in facilities" :key="index" cols="3">
            <v-card
    class="mx-auto"
    max-width="400"
  >
    <v-img
      class="align-end text-white"
      height="200"
      :src="facility.imageURL"
      cover
    >
      <v-card-title style=" color:yellow; background-color:rgba(0, 0, 0, 0.7); font-family: Garamond;">{{ facility.title }}</v-card-title>
    </v-img>

    <v-card-text>
      <div style="font-style: italic;">{{ facility.Details }}</div>
    </v-card-text>
  </v-card>
        </v-col>
       
        
    </v-row>
</v-container>
</template>
<script setup lang="ts">
    const facilities=[
    {
        imageURL:'/src/assets/run1.jpg',
        title:' Treadmill Workout',
        Details:'Stress Reduction & Weight Reduction'
    },
    {
        imageURL:'/src/assets/thum.jpg',
        title:'Arms Bisceps Workout',
        Details:'Build Muscles'
    },
    {
        imageURL:'/src/assets/rope.jpg',
        title:'Battel Rope Workout',
        Details:'Calorie-Burning Workout'
    },
    {
        imageURL:'/src/assets/rop.jpg',
        title:' Power Hypertropy Workout',
        Details:'Build both Size and Sterngth'
    },
    {
        imageURL:'/src/assets/bis.jpg',
        title:'Maximum mass Workout',
        Details:'Build Muscles'
    },
    {
        imageURL:'/src/assets/pushup.jpg',
        title:'Press-ups workout',
        Details:' Strengthens the chest & shoulders'
    },
   {
        imageURL:'/src/assets/upper.jpg',
        title:'Big & Strong Workout',
        Details:'Increase Strength'
    },
    {
        imageURL:'/src/assets/situp.jpg',
        title:'Kettleball Ab & core workout',
        Details:'Full body strength'
    }
    ]
</script>
<style>
#h1{
    text-align: center;
    font-family:'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif;
    color:goldenrod;
    font-variant: small-caps;
    font-weight: bolder;
    margin: 1%;
}
</style>