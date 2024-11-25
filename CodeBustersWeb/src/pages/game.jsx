import '../App.css';
import React from "react";
import Header from '../components/Header';
import Footer from '../components/footer';
import M1 from '../images/WCM1.png'
import M2 from '../images/WCM2.png'
import M3 from '../images/WCM3.png'
import M4 from '../images/WCM4.png'
import Toggles from '../images/WCToggles.png'
import { Unity, useUnityContext } from "react-unity-webgl";

function Game() {
    const { unityProvider, loadingProgression, isLoaded } = useUnityContext({
        loaderUrl: "../../public/buildUnity/Builds WorldeCrackdown.loader.js",
        dataUrl: "../../public/buildUnity/Builds WorldeCrackdown.data",
        frameworkUrl: "../../public/buildUnity/Builds WorldeCrackdown.framework.js",
        codeUrl: "../../public/buildUnity/Builds WorldeCrackdown.wasm",
    });

    return (

        <div id="GameBox">
            <Header />
            <div id="GameSection">

                {!isLoaded && (
                    <p>Loading Application... {Math.round(loadingProgression * 100)}%</p>
                )}
                <Unity

                    unityProvider={unityProvider}
                    style={{
                        visibility: isLoaded ? "visible" : "hidden",
                        width: "75%",
                        height: "84vh",
                        justifySelf: "center",
                        alignSelf: "center"
                    }}
                />
            </div>
            <div className='Gamegrid'>
                <div id='GameMTitle'><h1>How to play Worlde Crackdown?</h1></div>
                <div className='GameMDesc'>
                    <p>
                        Playing the game is easy, you will only require a some electronic device that has a keyboard or a touchscreen.
                        Get your brain ready as Worlde Crackdown has 4 modes to challenge you and keep you entertain.
                    </p>
                </div>
                <div className='GameModeBox'>
                    <h2 className='ModeTitle'>Classic</h2>
                    <img className='GameCapture' src={M1}></img>
                    <p>
                        This is your typical Wordle approach where you will guess a 5 letter word.
                        If any of the squares is yellow it means that the letter is in the word but
                        not placed in the right order. Whereas if is green, it in the right spot and
                        the correct letter. However, you only have 6 attempts to win, so use them wisely.
                    </p>
                </div>
                <div className='GameModeBox'>
                    <h2 className='ModeTitle'>Easy</h2>
                    <img className='GameCapture' src={M2}></img>
                    <p>
                        Just like the classic mode, but instead of 5 letter words you have 4 letter words
                        and a simple index was used to make things easier for the player to win.
                    </p>
                </div>

                <div className='GameModeBox'>
                    <h2 className='ModeTitle'>Challenging</h2>
                    <img className='GameCapture' src={M3}></img>
                    <p>
                        Just like the classic mode, but instead of 5 letter words you have 6 letter words
                        and a simple index was used to make things easier for the player to win.
                    </p>
                </div>

                <div className='GameModeBox'>
                    <h2 className='ModeTitle'>Hard</h2>
                    <img className='GameCapture' src={M4}></img>
                    <p>
                        Just like the classic mode, but instead of 5 letter words you have 7 letter words
                        and a simple index was used to make things easier for the player to win.
                    </p>
                </div>
                <div className='GameModeBoxEnd'>
                    <h2 className='ModeTitle'>Toggles</h2>
                    <img id='smallCapture' src={Toggles}></img>
                    <p>
                        There are two toggles, the first one is for time. Where it will allow a player to guess as
                        many words as possible in 5 minutes. <br></br>

                        The second toggle will make the game run in infinite mode, where time toggle needs to be active to displau this mode.
                        Every word guessed correctly will add points and time depending on where you guess the word.
                    </p>
                </div>
            </div>
            <Footer />
        </div>


    );
}

export default Game