<template>
  <v-sheet class="background-img">
    <v-container>
      <v-row class="d-flex">
        <v-col style="align-content: center; height:calc(100vh - 100px) ;">
          <!-- Animated Title -->
          <transition name="fade-slide">
            <div class="text-h3 mt-n16 animated-text">Meridian Fitness - The Largest Gym in Bangalore</div>
          </transition>

          <!-- Animated Description -->
          <transition name="fade-slide" appear>
            <div class="text-body-1 mt-5 animated-text">
              Meridian Fitness is the largest and best gym in JP Nagar for fitness lovers with an enthusiasm for diversity. 
              After observing that we couldn't find a studio that extended enough to reliably motivate us, 
              we decided to create one at the bosom of Bengaluru City! Established in the year 2022, 
              fabricate the essence of Meridian Fitness. Check out Meridian Fitness - the largest and best gym in Bangalore, today!
            </div>
           
          </transition>
          <div><v-btn color="yellow" class="ma-5">JOIN-US Today</v-btn></div>
        </v-col>
        <v-col></v-col>
      </v-row>
    </v-container>
  </v-sheet>
</template>

<script setup lang="ts">
// No additional script needed for animation
</script>

<style scoped>
/* Background Animation */
.background-img {
  background-image: url(../assets/bg-2.avif) !important;
  background-size: cover !important;
  background-attachment: fixed !important;
  background-repeat: no-repeat;
  min-height: calc(100vh - 64px);
  width: 100%;
  animation: fadeInBg 1.5s ease-in-out;
}

/* Fade In Animation for Background */
@keyframes fadeInBg {
  from {
    opacity: 0;
  }
  to {
    opacity: 1;
  }
}

/* Text Fade + Slide Animation */
.animated-text {
  opacity: 0;
  transform: translateX(-50px);
  animation: slideIn 1s ease-out forwards;
}

/* Slide In Animation */
@keyframes slideIn {
  from {
    opacity: 0;
    transform: translateX(-50px);
  }
  to {
    opacity: 1;
    transform: translateX(0);
  }
}

/* Vue Transition */
.fade-slide-enter-active, .fade-slide-appear-active {
  transition: opacity 1s, transform 1s;
}
.fade-slide-enter-from, .fade-slide-appear-from {
  opacity: 0;
  transform: translateY(30px);
}
.fade-slide-enter-to, .fade-slide-appear-to {
  opacity: 1;
  transform: translateY(0);
}
</style>
