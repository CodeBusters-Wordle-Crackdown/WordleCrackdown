import { initializeApp } from 'firebase/app';
import { getAuth } from "firebase/auth";

// Firebase configuration
const firebaseConfig = {
    apiKey: "AIzaSyDQ1ZunGDIv0IpjD7H4vch9jEdd67tHzF8",
    authDomain: "word-buster-99508.firebaseapp.com",
    databaseURL: "https://word-buster-99508-default-rtdb.firebaseio.com",
    projectId: "word-buster-99508",
    storageBucket: "word-buster-99508.firebasestorage.app",
    messagingSenderId: "970363193320",
    appId: "1:970363193320:web:5487352461cfbfb010465d",
    measurementId: "G-GPFZPFD89R",
};


const app = initializeApp(firebaseConfig);
const auth = getAuth(app)

export { app, auth }