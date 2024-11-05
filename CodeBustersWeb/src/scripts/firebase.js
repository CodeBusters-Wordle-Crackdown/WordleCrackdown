// Import the functions you need from the SDKs you need
import { initializeApp } from "firebase/app";
import { getAnalytics } from "firebase/analytics";
// TODO: Add SDKs for Firebase products that you want to use
// https://firebase.google.com/docs/web/setup#available-libraries

// Your web app's Firebase configuration
// For Firebase JS SDK v7.20.0 and later, measurementId is optional
const firebaseConfig = {
    apiKey: "AIzaSyDQ1ZunGDIv0IpjD7H4vch9jEdd67tHzF8",
    authDomain: "word-buster-99508.firebaseapp.com",
    projectId: "word-buster-99508",
    storageBucket: "word-buster-99508.appspot.com",
    messagingSenderId: "970363193320",
    appId: "1:970363193320:web:5487352461cfbfb010465d",
    measurementId: "G-GPFZPFD89R"
};

// Initialize Firebase
const app = initializeApp(firebaseConfig);
const analytics = getAnalytics(app);