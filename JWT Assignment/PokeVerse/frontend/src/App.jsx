import React, { useState, useEffect } from 'react';
import './App.css'; 
 
const API_URL = 'http://localhost:3001';
 

const LoginForm = ({ onLoginSuccess, onLoginError }) => {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
 
  const handleSubmit = async (e) => {
    e.preventDefault();
    onLoginError(null); 
 
    try {
      const response = await fetch(`${API_URL}/login`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({ username, password }),
      });
 
      const data = await response.json();
 
      if (!response.ok) {
        throw new Error(data.message || 'Login failed');
      }
 
      onLoginSuccess(data.token);
 
    } catch (err) {
      console.error('Login error:', err);
      onLoginError(err.message);
    }
  };
 
  return (
    <form onSubmit={handleSubmit} className="login-form">
      <h2>PokeVerse Login</h2>
      <div className="form-group">
        <label htmlFor="username">Username</label>
        <input
          type="text"
          id="username"
          value={username}
          onChange={(e) => setUsername(e.target.value)}
          placeholder="username"
          required
        />
      </div>
      <div className="form-group">
        <label htmlFor="password">Password</label>
        <input
          type="password"
          id="password"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
          placeholder="password"
          required
        />
      </div>
      <button type="submit" className="login-button">Login</button>
    </form>
  );
};
 

const PokemonGallery = ({ token, onLogout }) => {
  const [pokemon, setPokemon] = useState([]);
  const [error, setError] = useState(null);
  const [loading, setLoading] = useState(true);
 
  useEffect(() => {
    const fetchPokemon = async () => {
      try {
        const response = await fetch(`${API_URL}/api/pokemon`, {
          method: 'GET',
          headers: {
            'Authorization': `Bearer ${token}`,
          },
        });
 
        if (!response.ok) {
          const data = await response.json();
          throw new Error(data.message || 'Could not fetch data');
        }
 
        const data = await response.json();
        setPokemon(data);
      } catch (err) {
        console.error('Fetch error:', err);
        setError(err.message);
        if (err.message.includes('Token is invalid')) {
          onLogout();
        }
      } finally {
        setLoading(false);
      }
    };
 
    fetchPokemon();
  }, [token, onLogout]); 
 
  if (loading) return <div className="loading">Loading Pokémon...</div>;
  if (error) return <div className="error-message">Error: {error}</div>;
 
  return (
    <div className="gallery-container">
      <header className="gallery-header">
        <h1>Welcome to PokeVerse! </h1>
        <button onClick={onLogout} className="logout-button">Logout</button>
      </header>
      <div className="pokemon-grid">
        {pokemon.map((p) => (
          <div key={p.name} className="pokemon-card">
            <img src={p.imageUrl} alt={p.name} />
            <h3>{p.name}</h3>
          </div>
        ))}
      </div>
    </div>
  );
};
 

function App() {
  const [token, setToken] = useState(null);
  const [loginError, setLoginError] = useState(null);
 
  const handleLoginSuccess = (newToken) => {
    setToken(newToken);
    setLoginError(null);
  };
 
  const handleLogout = () => {
    setToken(null);
  };
 
  return (
    <div className="app-container">
      {loginError && (
        <div className="error-message login-error">{loginError}</div>
      )}
 
      {!token ? (
        <LoginForm
          onLoginSuccess={handleLoginSuccess}
          onLoginError={setLoginError}
        />
      ) : (
        <PokemonGallery token={token} onLogout={handleLogout} />
      )}
    </div>
  );
}
 
export default App;