import { getApp, getApps, initializeApp } from "firebase/app";
import { getFirestore } from "firebase/firestore";
import { getStorage } from "firebase/storage";

const firebaseConfig = {
  apiKey: "AIzaSyBekkF_IJeUYTrHuuzNkScs4LwGaLyfPi8",
  authDomain: "restaurantapp-f1abb.firebaseapp.com",
  databaseURL: "https://restaurantapp-f1abb-default-rtdb.firebaseio.com",
  projectId: "restaurantapp-f1abb",
  storageBucket: "restaurantapp-f1abb.appspot.com",
  messagingSenderId: "737717751992",
  appId: "1:737717751992:web:43aab3578188ba5517a44d"
};

const app = getApps.length > 0 ? getApp() : initializeApp(firebaseConfig);

const db = getFirestore(app);
const storage = getStorage(app);
const firestore = getFirestore(app);

export { app, db, storage, firestore };