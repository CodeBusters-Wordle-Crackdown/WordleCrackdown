import React from 'react';
import Header from '../components/Header';
import Footer from '../components/footer';
import '../App.css';
import { Parallax, ParallaxLayer } from '@react-spring/parallax';

function Home() {
    return (
        <div>
            {/* Parallax Effect */}
            <Parallax pages={1.5} style={{ top: '0', left: '0' }} className="animation">
                {/* Background Layer */}
                <ParallaxLayer offset={0} speed={0.1}>
                    <Header />
                    <div className="animation_lp" id="artback" aria-label="Artistic background"></div>
                </ParallaxLayer>

                {/* Content Layer */}
                <ParallaxLayer offset={0.8} speed={1}>
                    <div className="Par" id="Layer2">
                        <h1 tabIndex="0">Lorem Ipsum</h1>
                        <p tabIndex="0">
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam ac
                            gravida nunc, et blandit ligula. Etiam turpis massa, pharetra imperdiet
                            ultrices a, aliquam et diam. Curabitur congue nibh sed metus dignissim,
                            eu auctor erat lobortis. Nulla gravida purus sed bibendum ultrices.
                            Aliquam sed feugiat eros, nec elementum quam...
                        </p>
                    </div>
                    <Footer />
                </ParallaxLayer>
            </Parallax>
        </div>
    );
}

export default Home;
