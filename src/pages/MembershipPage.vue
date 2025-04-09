<template>
  <v-row>
    <v-col>
      <div id="memb" class="text-h3 text-center ma-16">Membership</div>
    </v-col>
  </v-row>

  <div id="plan">
    <v-row justify="center">
      <v-col cols="12" md="3" class="ma-4">
        <v-card class="card" id="1_month" style="background-color:silver ;">
          <v-card-title class="month">1 Month</v-card-title>
          <v-card-subtitle class="amount">&#8377;4,999/-</v-card-subtitle>
          <v-card-text id="points">
            Use of locker<br />
            24/7 GYM access <br />
            Unlimited access to yoga classes
          </v-card-text>
        </v-card>
      </v-col>

      <v-col cols="12" md="3" class="ma-4">
        <v-card class="card" id="6_month" style="background-color: gold;">
          <v-card-title class="month">6 Month</v-card-title>
          <v-card-subtitle class="amount">&#8377; 6,999/-</v-card-subtitle>
          <v-card-text id="points">
            Use of locker <br />
            24/7 GYM access <br />
            Weekday pool access <br />
            Unlimited access to yoga classes
          </v-card-text>
        </v-card>
      </v-col>

      <v-col cols="12" md="3" class="ma-4">
        <v-card class="card" id="annnual" style="background-color: palevioletred;">
          <v-card-title class="month">Annual</v-card-title>
          <v-card-subtitle class="amount">&#8377; 9,999/-</v-card-subtitle>
          <v-card-text id="points">
            Use of locker <br />
            24/7 GYM access <br />
            Free GYM T-shirt<br />
            Weekday pool access <br />
            12% off on all store products <br />
            Unlimited access to yoga classes
          </v-card-text>
        </v-card>
      </v-col>
    </v-row>
  </div>
</template>

<script setup lang="ts">
</script>

<style>
#memb {
    text-align: center;
    font-family:'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif;
    color:goldenrod;
    font-variant: small-caps;
    font-weight: bolder;
    margin: 1%;
}

#plan {
  padding: -2rem;
  text-align: center;
  margin: -4%;
}

.card {
  width: 20rem;
  height: 20rem;
  text-align: center;
  border-radius: 5%;
  border: 1px black solid;
  font-family: Cursive;
  font-size: large;
  font-variant: small-caps;
  padding: 10px;
  box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
  transition: transform 0.3s ease, box-shadow 0.3s ease;
}

.card:hover {
  transform: scale(1.10);
  box-shadow: 0 8px 20px rgba(0, 0, 0, 0.2);
}

.amount{
    color:black;
    font-weight: bolder;
    font-size: larger;
}
.month{
    font-weight:bolder;
    font-size:x-large
}

#points {
  font-family: Verdana, Geneva, Tahoma, sans-serif;
  font-size: large;
}
</style>
