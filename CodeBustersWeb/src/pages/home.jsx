import React from 'react';
import Header from '../components/Header';
import Footer from '../components/footer';
import '../App.css';
import { Parallax, ParallaxLayer } from '@react-spring/parallax';

function Home() {
    return (
        <div>
            <Header />
            <div className='animation_lp' id='artback'></div>
            <div class="bodyContainer">
                {/*Parallax Effect*/}
                <Parallax pages={1} style={{ top: '100', left: '0' }} className="animation">
                    <ParallaxLayer offset={0.2} speed={3}> {/*TODO Break Parallax, because either whole page needs to be parallax or shouldn't be done*/}
                        <div className='content' id='Layer2'>
                            <h1>Lorem ipsum</h1> <br />
                            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam ac gravida nunc,
                                et blandit ligula. Etiam turpis massa, pharetra imperdiet ultrices a, aliquam et
                                diam. Curabitur congue nibh sed metus dignissim, eu auctor erat lobortis. Nulla
                                gravida purus sed bibendum ultrices. Aliquam sed feugiat eros, nec elementum quam.
                                Donec vitae leo dignissim, efficitur mi vitae, placerat sapien. Quisque maximus,
                                est quis lacinia dapibus, sapien est consequat justo, ut faucibus lectus tellus eu
                                tortor. Suspendisse maximus justo dolor, id finibus turpis fringilla vehicula.
                                Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia
                                curae; Phasellus lorem ipsum, aliquam vitae viverra sagittis, eleifend id augue.
                            </p>
                        </div>
                    </ParallaxLayer>
                </Parallax>
            </div>
            <div>
                <Footer />
            </div>


        </div>
    );
}

export default Home;