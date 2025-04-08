import axios from "axios";

const API_URL = " http://localhost:7177/api/"; // Change this to your actual API

export const fetchUsers = async () => {
  const response = await axios.get(API_URL+"users");
  return response.data;
};

export const addUser = async (user: any) => {
  return await axios.post(API_URL+"users", user);
};

export const updateUser = async (id: number, user: any) => {
  return await axios.put(`${API_URL}users/${id}`, user);
};

export const deleteUser = async (id: number) => {
  return await axios.delete(`${API_URL}users/${id}`);
};

export const fetchUserPlan = async (userId: number) => {
    const response = await axios.get(`${API_URL}userplans/${userId}`);
    return response.data;
};

export const addUserPlan = async (user: any) => {
    return await axios.post(API_URL + "userplans", user);
};

export const updateUserPlan = async (id: number, user: any) => {
    return await axios.put(`${API_URL}userplans/${id}`, user);
};

export const deleteUserPlan = async (id: number) => {
    return await axios.delete(`${API_URL}userplans/${id}`);
};

export const validateuser = async (user: any) => {
  return await axios.post(API_URL + "validate/users", user);
};

export const fetchWeightLogs = async (userId: number) => {
  const response = await axios.get(`${API_URL}userweightlogs/${userId}`);
  return response.data;
};

export const addWeightLogs = async (user: any) => {
  return await axios.post(API_URL + "userweightlogs", user);
};
