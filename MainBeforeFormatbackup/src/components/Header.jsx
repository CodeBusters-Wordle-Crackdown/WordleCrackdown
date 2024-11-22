import React from 'react';
import { Link } from "react-router-dom";
import wordleLogo from '../images/wordleLogo.png';
import '../App.css'

const date = new Date();
const currentTime = date.getHours();

let greeting;

var customStyle = {
    color: "white"
}

if (currentTime >= 6 && currentTime < 12) {
    greeting = "Welcome, morning wordler!"
    customStyle.color = "lightBlue";
}
else if (currentTime > 12 && currentTime < 18) {
    greeting = "Welcome, midtime wordler!"
    customStyle = "orange";
}
else {
    greeting = "Welcome, night owl wordler!"
    customStyle = "purple";
}

function Header() {
    return (
        <header>
            <div id="navBar" className="nav-container">
                <img id="WordleLogo" className="logo" src={wordleLogo} alt="Wordle Logo" />
                <ul className="nav-links">
                    <li><Link to="/">Home</Link></li>
                    <li><Link to="/about">About</Link></li>
                    <li><Link to="/blog">Blog</Link></li>
                    <li><Link to="/game">Game</Link></li>
                </ul>
                <section id="login"><Link to="/login">Sign-in</Link><button><Link to="/game">Play</Link></button></section>
            </div>
            <section id="msgOnTime"><h5>{greeting}</h5></section>
        </header>
    );
}

export default Header;