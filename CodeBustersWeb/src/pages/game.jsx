import React from "react";
import { Unity, useUnityContext } from "react-unity-webgl";

function Game() {
  const { unityProvider, loadingProgression, isLoaded } = useUnityContext({
    loaderUrl: "/unity/Build/CodeBustersWeb.loader.js", // Correct Unity paths
    dataUrl: "/unity/Build/CodeBustersWeb.data",
    frameworkUrl: "/unity/Build/CodeBustersWeb.framework.js",
    codeUrl: "/unity/Build/CodeBustersWeb.wasm",
  });

  return (
    <div style={{ textAlign: "center", padding: "20px" }}>
      <h1>Unity Game</h1>
      {!isLoaded && <p>Loading... {Math.round(loadingProgression * 100)}%</p>}
      <Unity
        unityProvider={unityProvider}
        style={{
          visibility: isLoaded ? "visible" : "hidden",
          width: "960px",
          height: "600px",
        }}
      />
    </div>
  );
}

export default Game;
