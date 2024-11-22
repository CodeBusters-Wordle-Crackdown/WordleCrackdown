import React from 'react';

const UnityGame = () => {
  return (
    <iframe
      src="/unity/index.html" // Path to the Unity WebGL build
      style={{ width: '100%', height: '100vh', border: 'none' }}
      title="Unity Game"
    />
  );
};

export default UnityGame;
