import React from 'react';
import Header from '../components/Header';
import Footer from '../components/footer';
import WCD from '../images/WCDemo.png';
import '../App.css';

function Home() {
    return (
        <div>
            <Header />
            <div className='animation_lp' id='artback'></div>
            <div class="bodyContainer">
                <div className='content' id='Layer2'>
                    <h1>Ready to Challenge Your Brain?</h1> <br />
                    <p>WordleCrackDown is the wordle that will challenge you a couple more additional ways!
                    </p>
                </div>
                <div className='ImgContent'> <img className='DemoImg' src={WCD} alt="Wordle Crackdown Game"></img></div>
            </div>
            <Footer />



        </div>
    );
}

export default Home;