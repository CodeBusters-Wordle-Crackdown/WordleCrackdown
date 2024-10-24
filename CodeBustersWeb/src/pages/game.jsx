import '../App.css';
import React from "react";
import Header from '../components/Header';
import Footer from '../components/footer';
import { Unity, useUnityContext } from "react-unity-webgl";

function Game() {
    const { unityProvider, loadingProgression, isLoaded } = useUnityContext({
        loaderUrl: "../../buildUnity/Builds WorldeCrackdown.loader.js",
        dataUrl: "../../buildUnity/Builds WorldeCrackdown.data",
        frameworkUrl: "../../buildUnity/Builds WorldeCrackdown.framework.js",
        codeUrl: "../../buildUnity/Builds WorldeCrackdown.wasm",
    });

    return (

        <div id="GameSection">
            <Header />

            {!isLoaded && (
                <p>Loading Application... {Math.round(loadingProgression * 100)}%</p>
            )}
            <Unity

                unityProvider={unityProvider}
                style={{
                    visibility: isLoaded ? "visible" : "hidden",
                    width: "80%",
                    height: "100%",
                    justifySelf: "center",
                    alignSelf: "center"
                }}
            />

            <Footer />
        </div>
    );
}

export default Game