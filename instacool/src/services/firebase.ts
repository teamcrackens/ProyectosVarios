import * as firebase from 'firebase'

const firebaseConfig = {
    apiKey: "AIzaSyAqp1D6hhBxEVLkOcRNd-6nA5ERTaHXy3s",
    appId: "1:362351779719:web:a762d4d8b0eb9416e57d22",
    authDomain: "instacool-a3453.firebaseapp.com",
    databaseURL: "https://instacool-a3453.firebaseio.com",
    measurementId: "G-SNFFXH0X0D",
    messagingSenderId: "362351779719",
    projectId: "instacool-a3453",
    storageBucket: "instacool-a3453.appspot.com",
  };
  // Initialize Firebase
  firebase.initializeApp(firebaseConfig);

  export const auth = firebase.auth();
  export const db = firebase.firestore();
  export const storage = firebase.storage();