import '../App.css';
import React from "react";
import Header from '../components/Header';
import Footer from '../components/footer';
import { Unity, useUnityContext } from "react-unity-webgl";

function Game() {
    const { unityProvider, loadingProgression, isLoaded } = useUnityContext({
        loaderUrl: "../../public/buildUnity/Builds WorldeCrackdown.loader.js",
        dataUrl: "../../public/buildUnity/Builds WorldeCrackdown.data",
        frameworkUrl: "../../public/buildUnity/Builds WorldeCrackdown.framework.js",
        codeUrl: "../../public/buildUnity/Builds WorldeCrackdown.wasm",
    });

    return (

        <div>
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
            <Footer />
        </div>


    );
}

export default Game