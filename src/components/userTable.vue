<script setup lang="ts">
import { ref, onMounted, computed } from "vue";
import { fetchUsers, fetchUserPlan, addUser, updateUser, deleteUser, addUserPlan, updateUserPlan, deleteUserPlan } from "@/Api/api";

const users = ref([]);
const expanded = ref([]);
const userPlans = ref([]); // Store plans per user
const search = ref("");
const dialog = ref(false);
const planDialog = ref(false);
const editedUser = ref({});
const editedPlan = ref({});
const editedIndex = ref(-1);
const editedPlanIndex = ref(-1);

const roles = ["Admin", "Trainee"];
const branches = ["Banaswadi", "Indiranagar"];
const Memberheaders = [
    { title: 'Name', align: 'start', sortable: false, key: 'name' },
    { title: 'Age', align: 'end', key: 'age' },
    { title: 'Gender', align: 'end', key: 'gender' },
    { title: 'Mobile No', align: 'end', key: 'mobileNo' },
    { title: 'Address', align: 'end', key: 'address' },
    { title: 'height', align: 'end', key: 'height' },
    { title: 'Weight', align: 'end', key: 'weight' },
    { title: 'Actions', align: 'end', key: 'actions' }
  ]

const planHeaders = [
  { title: "Plan", key: "plan" },
  { title: "Start Date", key: "startDate" },
  { title: "End Date", key: "endDate" },
  { title: "Actions", key: "actions", sortable: false },
];

// Fetch Users Initially
const loadUsers = async () => {
  users.value = await fetchUsers();
};

onMounted(loadUsers);

// Fetch User Plans on Expand
const loadUserPlans = async (userId) => {
    fetchUserPlan(userId).then(res=>{
      console.log(res);
      userPlans.value=res;
      showplanDialog.value=true;
    }).catch(err=>{
      userPlans.value=[];
      showplanDialog.value=true;
    })
};

// Handle Row Expansion
const toggleExpand = async (user) => {
  console.log('called');
    await loadUserPlans(user.id);
};

// Open Dialog for User Add/Edit
const openDialog = (user = null) => {
  dialog.value = true;
  editedUser.value = user
    ? { ...user }
    : { name: "", age: null, gender: "", mobileNo: "", role: "", branch: "", password: "", isDefaultPassword: "true" };
  editedIndex.value = user ? users.value.findIndex((u) => u.id === user.id) : -1;
};

// Save User
const saveUser = async () => {
  if (editedIndex.value === -1) {
    await addUser(editedUser.value);
  } else {
    await updateUser(editedUser.value.id, editedUser.value);
  }
  dialog.value = false;
  loadUsers();
};

// Delete User
const removeUser = async (id) => {
  if (confirm("Are you sure you want to delete this user?")) {
    await deleteUser(id);
    userPlans.value.delete(id); // Remove associated plans
    loadUsers();
  }
};

// Open Dialog for Plan Add/Edit
const openPlanDialog = (userId, plan = null) => {
  planDialog.value = true;
  editedPlan.value = plan
    ? { ...plan }
    : { userId, plan: "", startDate: "", endDate: "" };
  editedPlanIndex.value = plan ? userPlans.value.findIndex((p) => p.id === plan.id) : -1;
};
const showplanDialog=ref(false);
const selectedUserId=ref();
// Save Plan
const savePlan = async () => {
  if (editedPlanIndex.value === -1) {
    await addUserPlan(editedPlan.value);
  } else {
    await updateUserPlan(editedPlan.value.id, editedPlan.value);
  }
  planDialog.value = false;
  await loadUserPlans(editedPlan.value.userId); // Refresh plans
};

const showplan=(userId)=>{
  selectedUserId.value=userId;
  loadUserPlans(userId)
}
// Delete Plan
const removePlan = async (userId, planId) => {
  if (confirm("Are you sure you want to delete this plan?")) {
    await deleteUserPlan(planId);
    await loadUserPlans(userId);
  }
};

// Filter Users
const filteredUsers = computed(() => {
  if (!search.value) return users.value;
  return users.value.filter((user) =>
    Object.values(user).some(
      (val) => val && val.toString().toLowerCase().includes(search.value.toLowerCase())
    )
  );
});
</script>

<template>
  <v-container>
    <v-row justify="space-between" class="mb-4">
      <v-btn color="primary" @click="openDialog()">Add User</v-btn>
      <v-text-field hide-details max-width="300px"
        v-model="search"
        label="Search"
        prepend-inner-icon="mdi-magnify"
        variant="outlined"
        density="compact"
        class="search-field"
      ></v-text-field>
    </v-row>

    <v-data-table
      :headers="Memberheaders"
      :items="filteredUsers"
      class="elevation-1"
      :items-per-page="5"
    >
      <template v-slot:item.actions="{ item }">
        <v-icon class="me-2" size="small" @click="openDialog(item)">mdi-pencil</v-icon>
        <v-icon class="me-2"size="small" color="red" @click="removeUser(item.id)">mdi-delete</v-icon>
        <v-icon class="me-2"size="small" color="red" @click="showplan(item.id)">mdi-cash-multiple</v-icon>
      </template>

    </v-data-table>

    <!-- User Dialog -->
    <v-dialog v-model="dialog" max-width="500px">
      <v-card>
        <v-card-title class="text-center text-h5">
          {{ editedIndex === -1 ? "Add User" : "Edit User" }}
        </v-card-title>
        <v-card-text>
          <v-form @submit.prevent="saveUser">
            <v-text-field v-model="editedUser.name" label="Name" required variant="outlined"></v-text-field>
            <v-text-field v-model="editedUser.age" label="Age" type="number" variant="outlined"></v-text-field>
            <v-select
              v-model="editedUser.gender"
              :items="['Male', 'Female', 'Other']"
              label="Gender"
              variant="outlined"
            ></v-select>
            <v-text-field v-model="editedUser.mobileNo" label="Mobile No" variant="outlined"></v-text-field>
            <v-text-field v-model="editedUser.address" label="Address" variant="outlined"></v-text-field>
            <v-text-field v-model="editedUser.weight" label="Weight (kg)" type="number" variant="outlined"></v-text-field>
            <v-text-field v-model="editedUser.height" label="Height (cm)" type="number" variant="outlined"></v-text-field>
            <v-select v-model="editedUser.role" :items="roles" label="Role" variant="outlined"></v-select>
            <v-select v-model="editedUser.branch" :items="branches" label="Branch" variant="outlined"></v-select>
            <v-text-field v-model="editedUser.password" label="Password" variant="outlined"></v-text-field>
            <v-checkbox
              v-model="editedUser.isDefaultPassword"
              label="Is Default Password?"
              true-value="true"
              false-value="false"
            ></v-checkbox>

            <v-card-actions class="justify-center">
              <v-btn color="red" @click="dialog = false">Cancel</v-btn>
              <v-btn color="primary" type="submit">Save</v-btn>
            </v-card-actions>
          </v-form>
        </v-card-text>
      </v-card>
    </v-dialog>

    <!-- Plan Dialog -->
    <v-dialog v-model="planDialog" max-width="500px">
      <v-card>
        <v-card-title class="text-center text-h5">Manage Plan</v-card-title>
        <v-card-text>
          <v-form @submit.prevent="savePlan">
            <v-text-field v-model="editedPlan.plan" label="Plan Name" required variant="outlined"></v-text-field>
            <v-text-field v-model="editedPlan.startDate" label="Start Date" type="date" variant="outlined"></v-text-field>
            <v-text-field v-model="editedPlan.endDate" label="End Date" type="date" variant="outlined"></v-text-field>

            <v-card-actions class="justify-center">
              <v-btn color="red" @click="planDialog = false">Cancel</v-btn>
              <v-btn color="primary" type="submit">Save</v-btn>
            </v-card-actions>
          </v-form>
        </v-card-text>
      </v-card>
    </v-dialog>
    <v-dialog v-model="showplanDialog" max-width="800px">
      <v-card>
        <v-card-title class="text-center text-h5">Manage Plan</v-card-title>
        <v-card-text>
          
          <v-data-table
          :headers="planHeaders"
          :items="userPlans"
          class="elevation-5"
          dense
          style="width:100% !important"
        >
          <template v-slot:item.actions="{ item: plan }">
            <v-icon class="me-2" size="small" @click="openPlanDialog(selectedUserId, plan)">mdi-pencil</v-icon>
            <v-icon size="small" color="red" @click="removePlan(selectedUserId, plan.id)">mdi-delete</v-icon>
          </template>
        </v-data-table>
        <div class="d-flex justify-center">
          <v-btn color="primary" max-width="100px" class="my-5" @click="openPlanDialog(selectedUserId)">Add Plan</v-btn>
          <v-btn color="primary" max-width="100px" class="my-5 ml-5" @click="()=>{showplanDialog=false}">Close</v-btn>
        </div>
        </v-card-text>
      </v-card>
    </v-dialog>
  </v-container>
</template>
