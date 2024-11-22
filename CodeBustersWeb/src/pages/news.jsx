import React from 'react';
import '../App.css';
import Header from '../components/Header';
import Footer from '../components/footer';
import PImg from '../images/Post1Img.jpg'

function News() {
    return (

        <div>
            <Header />
            <div className="PostNavbar">
                <button className="PostButton">Updates</button>
                <button className="PostButton">Info</button>
                <button className="PostButton">Events</button>
            </div>
            <div className="PostContainer">
                <div className="NFrame Box">
                    <div className='PostCapture'><img className='PostImg' src={PImg} alt='Grid of sizes 5 times 6 squares with letters'></img></div>
                    <div className='PostTitle'>
                        <h2>Wordlecrackdown has been published!</h2>
                    </div>
                    <div className='PostDescription'>
                        <p>Aliquam sed feugiat eros, nec elementum quam.
                            Donec vitae leo dignissim, efficitur mi vitae, placerat sapien. Quisque maximus,
                            est quis lacinia dapibus, sapien est consequat justo, ut faucibus lectus tellus eu
                            tortor. Suspendisse maximus justo dolor, id finibus turpis fringilla vehicula.
                            Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia
                            curae; Phasellus lorem ipsum, aliquam vitae viverra sagittis, eleifend id augue.</p>
                    </div>
                    <div className="PostDate">
                        <p>Posted on: dd/mm/yyyy</p>
                    </div>


                </div>
            </div>

            <Footer />
        </div>

    );
}

export default News;