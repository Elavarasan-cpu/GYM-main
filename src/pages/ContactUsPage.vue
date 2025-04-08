<template>
    <v-row>
        <v-col>
            <div class="text-h3 text-center" id="head">Feel Free To<br>    Contact Us</div>
            <div>
                <iframe id="map" src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3438.383969504439!2d77.58337647442679!3d12.903186416375798!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3bae15a29
                36ae4d7%3A0x242b6e9837c4c455!2sMeridian%20Fitness!5e1!3m2!1sen!2sin!4v1744095241564!5m2!1sen!2sin"
                width="400" height="350" style="border:0;" allowfullscreen="" loading="lazy" 
                 referrerpolicy="no-referrer-when-downgrade"></iframe>
            </div>
            <div>
                <v-text class="text-h6" id="add">Meridian Fitness.294/10, 15th Cross, 
                    24th Main Rd, 5th Phase, 
                    J. P. Nagar,
                     Bengaluru, Karnataka 560078</v-text> <br>
                     <v-text class="text-h6" id="add1">Contact : +91 9789437681 ,0889 0987 543</v-text>
            </div>
        </v-col>
    </v-row>
</template>
<script setup lang="ts">
</script>
<style>
#head{
    text-align: center;
    font-family:'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif;
    color:goldenrod;
    font-variant: small-caps;
    font-weight: bolder;
    margin: 1%;
}
#map{
    margin: 1%;
    text-align: center;
    margin-left: 35%;
}
#add{
    text-align: center;
    margin-left: 15%;
    
}
#add1{
    text-align: center;
    margin-left: 35%;
    
}
    
</style>