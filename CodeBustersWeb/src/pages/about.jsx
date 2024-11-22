import React from 'react';
import '../App.css';
import Header from '../components/Header';
import Footer from '../components/footer';
import Bshot from '../images/Bshot.jpg';
import Ghub from '../images/GhubLogo.png';
import LIn from '../images/LinkedInLogo.png';
import Inst from '../images/IGLogo.png';
import Cshot from '../images/Cshot.jpg';
import ConsShot from '../images/ConsShot.jpg'
import Gshot from '../images/Gshot.jpg';
import Nshot from '../images/Nshot.png';

function About() {
    return (
        <div id="AbContainer">
            <Header />
            <div className='WordleDescription'>
                <h1>About WordleCrackdown</h1>
                <br></br>
                <p>During fall 2024, students were tasked to create their own software project to develop their programming skills. That's the time were this project was born,
                    with the objective to create a version of wordle that have more objectives and challenges than the standard 5 word game.
                </p>
            </div>
            {/*Brian's Container*/}
            <div className="gridAboutContainer">
                <div className='AbFrame img'>
                    <img className="MemberImg" src={Bshot} alt="A handsome Mexican man in a blue suit" />
                </div>
                <div className='AbFrame title'>
                    <h3>Brian Cuevas Fuentes | Front End Developer </h3>
                </div>
                <div className='AbFrame description'>
                    <p> Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam ac gravida nunc,
                        et blandit ligula. Etiam turpis massa, pharetra imperdiet ultrices a, aliquam et
                        diam.
                    </p>
                </div>
                <div className='AbFrame socials'>
                    <a href="https://arthurgamer1.github.io/"><img className='Simg' src={Ghub} alt="A cat logo from Github" /></a>
                    <a href="https://www.linkedin.com/in/brian-cuevas-fuentes-0ab43620a/"><img className='Simg' src={LIn} alt="I and N letters" /></a>
                    <a href="https://www.instagram.com/arthurgameryt1/"><img className='Simg' src={Inst} alt="A image of drawn camera in a gradient of purple and yellow that represents Instagrams logo." /></a>
                </div>
            </div>
            {/*Clint's Container*/}
            <div className="gridAboutContainer2">
                <div className='AbFrameL imgL'>
                    <img className="MemberImg" src={Cshot} alt="A profile picture of a fox hugging a three" />
                </div>
                <div className='AbFrameL titleL'>
                    <h3>Clint Scholtisek | Game Developer </h3>
                </div>
                <div className='AbFrameL descriptionL'>
                    <p> Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam ac gravida nunc,
                        et blandit ligula. Etiam turpis massa, pharetra imperdiet ultrices a, aliquam et
                        diam.
                    </p>
                </div>
                <div className='AbFrameL socialsL'>
                    <a href="https://github.com/Git-baid"><img className='Simg' src={Ghub} alt="A cat logo from Github" /></a>
                    <a href="https://www.linkedin.com/in/clint-scholtisek-7a51bb265/"><img className='Simg' src={LIn} alt="I and N lettersS" /></a>
                </div>
            </div>
            {/*Constantine's Container*/}
            <div className="gridAboutContainer">
                <div className='AbFrame img'>
                    <img className="MemberImg" src={ConsShot} alt="A handsome Mexican man in a blue suit" />
                </div>
                <div className='AbFrame title'>
                    <h3>Constantine Hinds | Game Developer </h3>
                </div>
                <div className='AbFrame description'>
                    <p> Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam ac gravida nunc,
                        et blandit ligula. Etiam turpis massa, pharetra imperdiet ultrices a, aliquam et
                        diam.
                    </p>
                </div>
                <div className='AbFrame socials'>
                    <a href="https://cehinds.github.io"><img className='Simg' src={Ghub} alt="A cat logo from Github" /></a>
                    <a href="https://linkedin.com/in/constantine-hinds-1a977a2b4"><img className='Simg' src={LIn} alt="I and N letters" /></a>
                </div>
            </div>
            {/*Gwen's Container*/}
            <div className="gridAboutContainer2">
                <div className='AbFrame imgL'>
                    <img className="MemberImg" src={Gshot} alt="A handsome Mexican man in a blue suit" />
                </div>
                <div className='AbFrame titleL'>
                    <h3>Gwen | Back End Developer </h3>
                </div>
                <div className='AbFrame descriptionL'>
                    <p> Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam ac gravida nunc,
                        et blandit ligula. Etiam turpis massa, pharetra imperdiet ultrices a, aliquam et
                        diam.
                    </p>
                </div>
                <div className='AbFrame socialsL'>
                    <a href="https://github.com/girlReWired"><img className='Simg' src={Ghub} alt="A cat logo from Github" /></a>
                    <a href="https://www.linkedin.com/in/brian-cuevas-fuentes-0ab43620a/"><img className='Simg' src={LIn} alt="I and N letters" /></a>
                    <a href="https://www.instagram.com/arthurgameryt1/"><img className='Simg' src={Inst} alt="A seawolf head logo" /></a>
                </div>
            </div>
            {/*Nicassio's Container*/}
            <div className="gridAboutContainer">
                <div className='AbFrame img'>
                    <img className="MemberImg" src={Nshot} alt="A handsome Mexican man in a blue suit" />
                </div>
                <div className='AbFrame title'>
                    <h3>Nicassio Westlund | Back End Developer </h3>
                </div>
                <div className='AbFrame description'>
                    <p> Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam ac gravida nunc,
                        et blandit ligula. Etiam turpis massa, pharetra imperdiet ultrices a, aliquam et
                        diam.
                    </p>
                </div>
                <div className='AbFrame socials'>
                    <a href="https://github.com/nicasiowest"><img className='Simg' src={Ghub} alt="A cat logo from Github" /></a>
                    <a href="https://www.linkedin.com/in/brian-cuevas-fuentes-0ab43620a/"><img className='Simg' src={LIn} alt="I and N letters" /></a>
                    <a href="https://www.instagram.com/arthurgameryt1/"><img className='Simg' src={Inst} alt="A seawolf head logo" /></a>
                </div>
            </div>
            <Footer />
        </div>
    );
}

export default About;