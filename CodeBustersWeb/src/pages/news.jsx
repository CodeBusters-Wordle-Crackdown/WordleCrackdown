import React from 'react';
import '../App.css';
import Header from '../components/Header';
import Footer from '../components/footer';
import PImg from '../images/Post1Img.jpg';

function News() {
    return (

        <div>
            <Header />
            <div className="PostNavbar">
                <button className="PostButton">Updates</button>
                <button className="PostButton">Info</button>
                <button className="PostButton">Events</button>
            </div>
            <div className="PostContainer">
                <div className="NFrame Box">
                    <div className='PostCapture'><img className='PostImg' src={PImg} alt='Grid of sizes 5 times 6 squares with letters'></img></div>
                    <div className='PostTitle'>
                        <h2>Wordlecrackdown has been published!</h2>
                    </div>
                    <div className='PostDescription'>
                        <p>Wordle Crackdown has been released and is here to redefine your word-guessing game nights!
                            Dive into exciting new modes that push your skills to the limit. Race against time in
                            Time Mode, tackle tricky twists with the different modes, or test your endurance in
                            Infinite Mode—where each solved puzzle gets tougher than the last. With vibrant visuals
                            and addictive gameplay, Wordle Crackdown promises endless fun for both casual players
                            and word game enthusiasts. Are you ready to rise to the challenge?</p>
                    </div>
                    <div className="PostDate">
                        <p>Posted on: 11/25/2024</p>
                    </div>
                </div>
            </div>
            <Footer />
        </div>

    );
}

export default News;