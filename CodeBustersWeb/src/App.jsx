import './App.css';
import { HashRouter as Router, Routes, Route } from 'react-router-dom';
import Home from './pages/home.jsx';
import About from './pages/about.jsx';
import Blog from './pages/blog.jsx';
import Game from './pages/game.jsx';


function App() {

  return (
    /*React Multipages Setup*/
    < Router >
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/about" element={<About />} />
        <Route path="/blog" element={<Blog />} />
        <Route path="/game" element={<Game />} />
      </Routes>
    </Router >

  );
}

export default App