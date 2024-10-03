import './App.css'
import TextBlock from './textBlock.jsx';
import { Parallax, ParallaxLayer } from '@react-spring/parallax'

function App() {


  return (
    <div className='App'>
      <Parallax pages={2} style={{ top: '0', left: '0' }} class="animation">
        <ParallaxLayer offset={0} speed={0.25}>
          <div class='animation_lp' id='artback'></div>
        </ParallaxLayer>
        <ParallaxLayer offset={0} speed={0.3}>
          <div class='animation_lp' id='mountain'></div>
        </ParallaxLayer>
        <ParallaxLayer offset={0} speed={-0.1}>
          <div class='animation_lp' id='logoland'></div>
        </ParallaxLayer>
        <ParallaxLayer offset={0} speed={0.4}>
          <div class='animation_lp' id='jungle1'></div>
        </ParallaxLayer>
        <ParallaxLayer offset={0} speed={0.35}>
          <div class='animation_lp' id='jungle2'></div>
        </ParallaxLayer>
        <ParallaxLayer offset={0} speed={0.5}>
          <div class='animation_lp' id='jungle3'></div>
        </ParallaxLayer>
        <ParallaxLayer offset={0} speed={0.35}>
          <div class='animation_lp' id='jungle4'></div>
        </ParallaxLayer>
        <ParallaxLayer offset={0} speed={0.4}>
          <div class='animation_lp' id='manonmountain'></div>
        </ParallaxLayer>
        <ParallaxLayer offset={0} speed={0.5}>
          <div class='animation_lp' id='jungle5'></div>
        </ParallaxLayer>
        <ParallaxLayer offset={1} speed={2.5}>
          <TextBlock />
        </ParallaxLayer>
      </Parallax>

    </div>
  );
}

export default App
