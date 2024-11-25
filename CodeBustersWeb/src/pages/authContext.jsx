import React, { useContext, useEffect, useState } from "react";
import { auth } from "../scripts/firebase.js";
import { onAuthStateChanged } from "firebase/auth";

const AuthContext = React.createContext();

export function useAuth() {
    return useContext(AuthContext);
};

export function AuthProvider({ children }) {
    const [currentUser, setCurrentUser] = useState(null);
    const [userLoggedIn, setUserLoggedIn] = useState(false);
    const [isEmailUser, setIsEmailUser] = useState(false);
    const [isGithubUser, setIsGithubUser] = useState(false);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const unsuscribe = onAuthStateChanged(auth, initializeUser);
        return unsuscribe;
    }, [])

    async function initializeUser(user) {
        if (user) {
            setCurrentUser({ ...user });
            setUserLoggedIn(true);
            const providerId = user.providerData?.[0]?.providerId || '';
            setIsEmailUser(providerId === 'password');
            setIsGithubUser(providerId === 'github.com');
        }
        else {
            setCurrentUser(null);
            setUserLoggedIn(false);
            setIsEmailUser(false);
            setIsGithubUser(false);
        }
        setLoading(false);
    }

    const value = {
        currentUser,
        isEmailUser,
        isGithubUser,
        userLoggedIn,
        loading
    }

    return (
        <AuthContext.Provider value={value}>
            {!loading && children}
        </AuthContext.Provider>
    )
}