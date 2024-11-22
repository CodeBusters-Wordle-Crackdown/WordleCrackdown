import './App.css';
import { HashRouter as Router, Routes, Route } from 'react-router-dom';
import Home from './pages/home.jsx';
import About from './pages/about.jsx';
import Blog from './pages/blog.jsx';
import Game from './pages/game.jsx';
import Login from './pages/login.jsx';


function App() {

  return (
    /*React Multipages Setup*/
    < Router >
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/about" element={<About />} />
        <Route path="/blog" element={<Blog />} />
        <Route path="/game" element={<Game />} />
        <Route path="/login" element={<Login />} />
      </Routes>
    </Router >

  );
}

export default App