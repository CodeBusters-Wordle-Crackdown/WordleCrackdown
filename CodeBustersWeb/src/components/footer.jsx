import '../App.css';
import { Link } from "react-router-dom";
import uaaLogo from '../images/UAALogo.png';

function Footer() {
    return (
        <div class="footerContainer">
            <h1 id="footerTitle">Thank you for checking us out!</h1>
            <br />
            <div class="grid-footerContainer">
                <div className='Fsubtitle'>
                    <h3> Developers</h3>
                    <br />
                    <p>Game Developer: Constantine Hinds</p>
                    <p>Game Developer: Clint Scholtisek</p>
                    <p>Backend Dev: Nicassio Westlund</p>
                    <p>Backend Dev: Gwen Beecher</p>
                    <p>Front-End Dev: Brian Cuevas Fuentes</p>
                </div>
                <div className='Fsubtitle'>
                    <h3> UAA Links</h3>
                    <br />
                    <a className="FLink" href="https://www.uaa.alaska.edu/">UAA Home Page</a> <br />
                    <a className="FLink" href="https://www.uaa.alaska.edu/academics/college-of-engineering/index.cshtml">College of Engineering</a> <br />
                    <a className="FLink" href="https://www.uaa.alaska.edu/academics/college-of-engineering/prospective-students/community-engagement.cshtml">Community Engagement</a> <br />
                    <a className="FLink" href="https://www.uaa.alaska.edu/academics/college-of-engineering/student-opportunities-and-advising/student-clubs-and-organizations/index.cshtml">UAA Engineering Clubs</a> <br />
                    <a className="FLink" href="https://www.uaa.alaska.edu/academics/college-of-engineering/student-opportunities-and-advising/student-clubs-and-organizations/comp-sci-club.cshtml">Computer Science Club</a> <br />
                </div>
                <div className='Fsubtitle'>
                    <h3> References</h3>
                    <br />
                    <a className="FLink" href="https://www.nytimes.com/games/wordle/index.html">NewYorkTimes Wordle</a> <br />
                    <a className="FLink" href="https://genshin.hoyoverse.com/en/news">Genshin News Page</a> <br />
                    <a className="FLink" href="https://www.color-hex.com/color-palette/1012607">Wordle Color Scheme</a> <br />
                    <a className="FLink" href="https://www.nytimes.com/games/wordle/index.html">NewYorkTimes Wordle</a> <br />
                    <a className="FLink" href="https://www.nytimes.com/games/wordle/index.html">NewYorkTimes Wordle</a> <br />
                </div>
                <div className='Fsubtitle'><img id="UAALogo" src={uaaLogo} alt="A seawolf head logo" /></div>
            </div>
            <br />
            <p id="footerContent">
                WordleCrackdown was developed by a group of students for learning purposes. Our intent with this website was to create a more united
                community version of wordle, but due to our inexperience and time contraints we had to make some adjustments to deliver something great
                to our class. We hope you like our small game and give thanks to the University of Alaska Anchorage and our Software Engineering professor for
                giving us this opportunity to learn on our way.

            </p>
            <br />

            <footer id='cpFooter'>Demo Created With 🧡 By&nbsp;<a id="footerCodeBusters">CodeBusters</a></footer>
        </div>
    );
}

export default Footer;