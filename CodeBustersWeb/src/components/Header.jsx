import React, { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { useAuth } from "../pages/authContext";
import { auth } from "../scripts/firebase";
import wordleLogo from "../images/wordleLogo.png";
import "../App.css";

function Header() {
    const date = new Date();
    const currentTime = date.getHours();
    const [username, setUsername] = useState("wordler");
    const { userLoggedIn } = useAuth(); // Assuming this tracks if the user is logged in
    const [isAuthLoading, setIsAuthLoading] = useState(true); // To handle async loading

    useEffect(() => {
        const unsubscribe = auth.onAuthStateChanged((user) => {
            if (user) {
                if (user.displayName) {
                    setUsername(user.displayName);
                } else if (user.email) {
                    const emailPrefix = user.email.split("@")[0];
                    setUsername(emailPrefix);
                }
            } else {
                setUsername("wordler");
            }
            setIsAuthLoading(false);
        });

        return () => unsubscribe();
    }, []);

    if (isAuthLoading) {
        return <div>Loading...</div>;
    }

    const handleLogout = () => {
        auth.signOut().then(() => {
            console.log("User signed out");
        }).catch((error) => {
            console.error("Error signing out:", error);
        });
    };

    let greeting;
    const customStyle = { color: "white" };

    if (currentTime >= 6 && currentTime < 12) {
        greeting = `Welcome, morning ${username}!`;
        customStyle.color = "lightBlue";
    } else if (currentTime >= 12 && currentTime < 18) {
        greeting = `Welcome, midtime ${username}!`;
        customStyle.color = "orange";
    } else {
        greeting = `Welcome, night owl ${username}!`;
        customStyle.color = "purple";
    }

    return (
        <header>
            <div id="navBar" className="nav-container">
                <img id="WordleLogo" className="logo" src={wordleLogo} alt="Wordle Logo" />
                <ul className="nav-links">
                    <li><Link to="/">Home</Link></li>
                    <li><Link to="/about">About</Link></li>
                    <li><Link to="/News">News</Link></li>
                    <li><Link to="/game">Game</Link></li>
                </ul>
                <section id="login">
                    {userLoggedIn ? (
                        <Link to="/" onClick={handleLogout}>Logout</Link>
                    ) : (
                        <Link to="/login">Sign-in</Link>
                    )}
                    <button><Link to="/game">Play</Link></button>
                </section>
            </div>
            <section id="msgOnTime">
                <h5 style={customStyle}>{greeting}</h5>
            </section>
        </header>
    );
}

export default Header;
