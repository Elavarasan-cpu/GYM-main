<template>
    <div>
        <div class="mt-10 mb-3 text-center text-red" v-if="loginfailed">Incorrect username or password</div>
        <LoginPage :login="login" v-if="!IsAuthenticated && !loading"></LoginPage>
        <div v-if="IsAuthenticated && !loading">
            <v-container>
              <v-row>
                <v-col >
                  <v-btn style="float: right;" color="red" @click="logout">Logout</v-btn>
                </v-col>
              </v-row>
                <v-row>
                    <v-col cols="9">
                      <div class="pa-5 text-h4 text-center">Daily Progress</div>
                        <v-card elevation="16">
                            <v-tabs v-model="tab" align-tabs="center" color="deep-purple-accent-4">
                                <v-tab :value="1">Table</v-tab>
                                <v-tab :value="2">Chart</v-tab>
                            </v-tabs>

                            <v-tabs-window v-model="tab">
                                <v-tabs-window-item v-for="n in 2" :key="n" :value="n">
                                    <v-container fluid>
                                        <v-row v-if="tab==1">
                                            <v-col class="ma-3">
                                                <v-data-table :headers="headers" :items="weightLogs" density="compact"
                                                    item-key="name">
                                                    <template v-slot:item.date="{ item }">
                                                      {{ formatDate(item.date) }}
                                                    </template>
                                                  </v-data-table>
                                            </v-col>
                                        </v-row>
                                        <v-row v-if="tab==2">
                                            <v-col>
                                                <v-card class="pa-6">
                                                    <v-card-title class="text-h5 text-center">Outweight
                                                        Chart</v-card-title>
                                                    <v-card-text>
                                                        <LineChart :chart-data="chartData" :chart-options="chartOptions" height="150px"
                                                            />
                                                    </v-card-text>
                                                </v-card>
                                            </v-col>
                                        </v-row>
                                    </v-container>
                                </v-tabs-window-item>
                            </v-tabs-window>
                        </v-card>
                    </v-col>
                    <v-col class="ma-3 rounded-lg pa-5">
                        <div class="text-h6 text-center mb-4">Today's Entry</div>
                        <v-row>
                            <v-col><v-text-field hide-details label="In Weight" variant="outlined" density="compact" v-model="weightLogsObject.inWeight"
                                    required></v-text-field></v-col>
                        </v-row>
                        <v-row>
                            <v-col><v-text-field hide-details label="Out Weight" variant="outlined" density="compact" v-model="weightLogsObject.outWeight"
                                    required></v-text-field></v-col>
                        </v-row>
                        <v-row>
                            <v-col>
                                <v-menu v-model="menu" :close-on-content-click="false" transition="scale-transition"
                                    offset-y>
                                    <template v-slot:activator="{ props }">
                                        <v-text-field v-bind="props"  label="Select Date" readonly v-model="date"
                                            prepend-inner-icon="mdi-calendar"
                                            @click:prepend-inner="menu = true"></v-text-field>
                                    </template>

                                    <v-date-picker v-model="date" @update:model-value="menu = false"></v-date-picker>
                                </v-menu></v-col>
                        </v-row>
                        <v-row>
                            <v-col class="d-flex justify-center">
                                <v-btn color="primary" @click="CreateWeight">Save</v-btn>
                            </v-col>
                        </v-row>

                    </v-col>
                </v-row>

                <v-row class="mt-10" v-if="IsAdmin">
                  <v-col>
                    <div class="pa-2 text-center text-h4">Members List</div>
                    <userTable></userTable>
                  </v-col>
                </v-row>
            </v-container>
        </div>
    </div>
</template>
<script setup lang="ts">
import LoginPage from '../pages/LoginPage.vue';
import userTable from '@/components/userTable.vue';
import { computed, onMounted, ref } from 'vue'
import { LineChart } from "vue-chart-3";
import { Chart, registerables } from "chart.js";
import { addWeightLogs, fetchWeightLogs, validateuser } from '@/Api/api';
const loading=ref(true);
const date = ref<Date|null>(null);
const menu = ref(false);
const tab = ref(null)
const userDetails=ref({userID:-1,username:''});
const weightLogsObject=ref({Id:0,userID:-1,inWeight:0,outWeight:0,date:''});
const weightLogs=ref<Array<{Id:0,userID:-1,inWeight:0,outWeight:0,date:''}>>([]); 
// Register Chart.js modules
Chart.register(...registerables);


// Prepare chart data
const chartData = computed(() => ({
  labels: weightLogs.value.map((item) => formatDate(item.date)),
  datasets: [
    {
      label: "Outweight (kg)",
      data: weightLogs.value.map((item) => item.outWeight),
      borderColor: "#42A5F5",
      backgroundColor: "rgba(66, 165, 245, 0.2)",
      fill: true,
      tension: 0.4, // Smooth line effect
    },
  ],
}));

onMounted(()=>{
 var data= localStorage.getItem("login");
 console.log(data);
 if(data){
  var user=  JSON.parse(data) 
  console.log('data',user);
  login(user.username,user.password);
 }else{
  loading.value=false;
 }
})
// Chart options
const chartOptions = {
  responsive: true,
  maintainAspectRatio: false,
  plugins: {
    legend: {
      display: true,
      position: "top",
    },
  },
  scales: {
    x: {
      title: {
        display: true,
        text: "Date",
      },
    },
    y: {
      title: {
        display: true,
        text: "Weight (kg)",
      },
    },
  },
};

const IsAuthenticated=ref(false);
const IsAdmin=ref(false);
const headers = [
    { title: 'Date', align: 'start', sortable: false, key: 'date' },
    { title: 'In Weight', align: 'end', key: 'inWeight' },
    { title: 'Out Weight', align: 'end', key: 'outWeight' },
  ]


  const plants = [
    {
      name: 'Muniselvam',
      Date: '12/12/2025',
      InWeight: '75',
      OutWeight: '74',
    },
    {
      name: 'Muniselvam',
      Date: '12/12/2025',
      InWeight: '75',
      OutWeight: '74',
    },
    {
      name: 'Muniselvam',
      Date: '12/12/2025',
      InWeight: '75',
      OutWeight: '74',
    },
    {
      name: 'Muniselvam',
      Date: '12/12/2025',
      InWeight: '75',
      OutWeight: '74',
    }
  ]
  const loginfailed=ref(false);
  const login = (username: string, password: string) => {
    
  validateuser({userName: username,password: password }).then((res) => {
    
    if (res.data!='') {
      
      userDetails.value.userID=res.data.id;
      userDetails.value.username=res.data.name;
      GetWeightLogs();
      if(res.data.role=='Admin'){
        IsAdmin.value=true;
      }else{
        IsAdmin.value=false;
      }
      loginfailed.value=false;
      IsAuthenticated.value = true;
      console.log(IsAuthenticated.value)
      localStorage.setItem("login", JSON.stringify({ username, password }));

    } else {
      loginfailed.value=true;
      IsAuthenticated.value = false;

    }
    loading.value=false;
  });
};

const CreateWeight=()=>{
  const formatted =date.value!=null? `${String(date.value.getDate()).padStart(2, '0')}/${String(date.value.getMonth() + 1).padStart(2, '0')}/${date.value.getFullYear()}`:Date.now().toLocaleString();
  weightLogsObject.value.date=formatted;
  weightLogsObject.value.userID=userDetails.value.userID;
  addWeightLogs(weightLogsObject.value).then(res=>{
    console.log(res.data);
    weightLogs.value.push(res.data);
  })
  // const weightLogsObject=ref({Id:0,userID:-1,inWeight:0,outWeight:0,Date:String});
}

const GetWeightLogs=()=>{
  fetchWeightLogs(userDetails.value.userID).then(res=>{
    console.log('weight',res);
    if(res){
      weightLogs.value=res;
      console.log("resweight",weightLogs.value.map((item) => item.outWeight))
    }
  })
}

const formatDate = (dateString:string|null) => {
    if(dateString!=null){
        const date = new Date(dateString);
  return date.getDate() +' '+ date.toLocaleString('en-GB', { month: 'short' }) + ' ' + date.getFullYear();
    }else{
        return ''
    }
  
};

const logout=()=>{
  localStorage.removeItem("login")
  IsAuthenticated.value=false;
}

</script>