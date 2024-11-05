import React from 'react';
import { Link } from "react-router-dom";
import '../App.css'

const date = new Date();
const currentTime = date.getHours();

let greeting;

var customStyle = {
    color: ""
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
            <div id='navBar'>
                <ul>
                    <img id="WordleLogo" src="../images/wordleLogo.png" /> {/*Placeholder, by the way this is a comment*/}
                    <li><Link to="/">Home</Link></li>
                    <li><Link to="/about">About</Link></li>
                    <li><Link to="/blog">Blog</Link></li>
                    <li><Link to="/game">Game</Link></li>
                </ul>
            </div>
            <div id="msgOnTime">
                <h3>{greeting}</h3>
            </div>
        </header>
    );
}

export default Header;