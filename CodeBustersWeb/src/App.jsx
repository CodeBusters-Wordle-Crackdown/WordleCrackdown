import './App.css';
import { HashRouter as Router, Routes, Route } from 'react-router-dom';
import Home from './pages/home.jsx';
import About from './pages/about.jsx';
import Game from './pages/game.jsx';
import Login from './pages/login.jsx';
import News from './pages/news.jsx';

function App() {

  return (
    /*React Multipages Setup*/
    < Router >
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/about" element={<About />} />
        <Route path="/news" element={<News />} />
        <Route path="/game" element={<Game />} />
        <Route path="/login" element={<Login />} />
      </Routes>
    </Router >

  );
}

export default App
