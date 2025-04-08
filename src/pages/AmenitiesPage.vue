<template>
    <v-container>
    <v-row>
        <v-col>
            <div class="text-h2 text-center ma-3"  id="h2">Amenities Page</div>
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
        imageURL:'/src/assets/cardio.webp',
        title:'Cardio Equipment Area',
        Details:'Treadmills, elliptical machines, and bikes in a modern gym.'
    },
    {
        imageURL:'/src/assets/weightlift.webp',
        title:'Weightlifting Section',
        Details:'Dumbbells, barbells, squat racks, and strength machines'
    },
    {
        imageURL:'/src/assets/training zone.webp',
        title:'Functional Training Zone ',
        Details:' Kettlebells, battle ropes, TRX, and HIIT space.'
    },
    {
        imageURL:'/src/assets/locker room.webp',
        title:'Rest Luxury Locker Room',
        Details:'Wooden lockers, sauna, steam room, and shower facilities.'
    },
    {
        imageURL:'/src/assets/juice bar.webp',
        title:'Juice Bar  ',
        Details:'protein shakes, smoothies, and nutritional snacks.'
    },
    {
        imageURL:'/src/assets/childrens area.webp',
        title:'Childcare Area  ',
        Details:'A designated space within the gym where children can safely play.'
    },
   {
        imageURL:'/src/assets/swmming pool.webp',
        title:'Swimming Pool & Spa ',
        Details:'Heated indoor pool, jacuzzi, and relaxation area.'
    },
    {
        imageURL:'/src/assets/yoga.webp',
        title:'Yoga & Pilates Studio ',
        Details:' Wooden floors, yoga mats, stability balls, and ambient lighting.'
    }
    ]
</script>
<style>
#h2{
    text-align: center;
    font-family:'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif;
    color:goldenrod;
    font-variant: small-caps;
    font-weight: bolder;
    margin: 1%;
}
</style>