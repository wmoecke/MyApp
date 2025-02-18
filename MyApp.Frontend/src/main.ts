import { createApp } from 'vue'
import App from './App.vue';
import './style.css';
import router from './router';
import axios from 'axios';

axios.defaults.baseURL = 'http://localhost:5151/api'; // .NET API port

const app = createApp(App); 
app.use(router); 
app.mount('#app');
