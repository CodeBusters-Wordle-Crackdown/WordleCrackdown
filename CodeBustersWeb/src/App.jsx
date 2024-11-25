import './App.css';
import { HashRouter as Router, Routes, Route } from 'react-router-dom';
import Home from './pages/home.jsx';
import About from './pages/about.jsx';
import Game from './pages/game.jsx';
import Login from './pages/login.jsx';
import News from './pages/news.jsx';
import Register from './pages/register.jsx'
import { AuthProvider } from './pages/authContext.jsx';

function App() {

  return (
    /*React Multipages Setup*/
    <AuthProvider>
      < Router >
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/about" element={<About />} />
          <Route path="/news" element={<News />} />
          <Route path="/game" element={<Game />} />
          <Route path="/login" element={<Login />} />
          <Route path="/register" element={<Register />} />
        </Routes>
      </Router >
    </AuthProvider>

  );
}

export default App
