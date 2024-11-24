import React, { useState, useRef } from "react";
import "./Modal.css";
import firebase from "firebase/compat/app";
import "firebase/compat/auth";

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

if (!firebase.apps.length) {
  firebase.initializeApp(firebaseConfig);
}

const FirebaseAuthModal = () => {
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [isLogin, setIsLogin] = useState(true);
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [message, setMessage] = useState({ text: "", type: "" });
  const modalRef = useRef(null);

  const resetForm = () => {
    setEmail("");
    setPassword("");
    setMessage({ text: "", type: "" });
    setIsLogin(true);
  };

  const handleFormSubmit = async (event) => {
    event.preventDefault();
    try {
      if (isLogin) {
        const userCredential = await firebase
          .auth()
          .signInWithEmailAndPassword(email, password);
        setMessage({ text: "Login successful!", type: "success" });
        console.log("User logged in:", userCredential.user.email);
        setTimeout(() => setIsModalOpen(false), 1500);
      } else {
        const userCredential = await firebase
          .auth()
          .createUserWithEmailAndPassword(email, password);
        setMessage({ text: "Registration successful!", type: "success" });
        console.log("User registered:", userCredential.user.email);
        setTimeout(() => setIsModalOpen(false), 1500);
      }
    } catch (error) {
      setMessage({ text: error.message, type: "error" });
    }
  };

  const toggleAuthMode = () => setIsLogin((prev) => !prev);

  const handleDrag = (e) => {
    if (!modalRef.current) return;
    const modal = modalRef.current;
    const boundingBox = modal.getBoundingClientRect();
    const maxLeft = window.innerWidth - boundingBox.width;
    const maxTop = window.innerHeight - boundingBox.height;
    const newLeft = Math.min(Math.max(0, e.clientX - boundingBox.width / 2), maxLeft);
    const newTop = Math.min(Math.max(0, e.clientY - boundingBox.height / 2), maxTop);
    modal.style.left = `${newLeft}px`;
    modal.style.top = `${newTop}px`;
  };

  return (
    <>
      <button onClick={() => setIsModalOpen(true)}>Login</button>
      {isModalOpen && (
        <div
          className="modal-overlay"
          onClick={(e) => e.target.className === "modal-overlay" && setIsModalOpen(false)}
        >
          <div
            className="modal-content"
            ref={modalRef}
            onMouseDown={(e) => {
              if (e.target.tagName === "H2") document.addEventListener("mousemove", handleDrag);
            }}
            onMouseUp={() => document.removeEventListener("mousemove", handleDrag)}
          >
            <button className="close-btn" onClick={() => setIsModalOpen(false)}>
              X
            </button>
            <h2>{isLogin ? "Log In" : "Sign Up"}</h2>
            <form onSubmit={handleFormSubmit}>
              <label>Email:</label>
              <input
                type="email"
                value={email}
                onChange={(e) => setEmail(e.target.value)}
                required
              />
              <label>Password:</label>
              <input
                type="password"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
                required
              />
              <button type="submit">{isLogin ? "Log In" : "Sign Up"}</button>
            </form>
            <p>
              {isLogin ? "Don't have an account?" : "Already have an account?"}
            </p>
            <button className="toggle-btn" onClick={toggleAuthMode}>
              {isLogin ? "Sign Up" : "Log In"}
            </button>
            {message.text && (
              <div className={message.type === "success" ? "success-message" : "error-message"}>
                {message.text}
              </div>
            )}
          </div>
        </div>
      )}
    </>
  );
};

export default FirebaseAuthModal;
