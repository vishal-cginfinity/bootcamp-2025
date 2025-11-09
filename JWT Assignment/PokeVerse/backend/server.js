import express from 'express';
import jwt from 'jsonwebtoken';
import cors from 'cors';
import axios from 'axios';
 
const app = express();
const PORT = 3001;
const JWT_SECRET = 'your-super-secret-key-for-testing';
 
const dummyUser = {
  username: 'vishal',
  password: 'password123',
  name: 'Vishal'
};

app.use(cors());
app.use(express.json());
 

const verifyToken = (req, res, next) => {
  const authHeader = req.headers['authorization'];
  const token = authHeader && authHeader.split(' ')[1];
 
  if (token == null) {
    return res.status(401).json({ message: 'No token provided.' });
  }
 
  jwt.verify(token, JWT_SECRET, (err, user) => {
    if (err) {
      return res.status(403).json({ message: 'Token is invalid.' });
    }
    req.user = user;
    next();
  });
};
 

app.post('/login', (req, res) => {
  const { username, password } = req.body;
 
  if (!username || !password) {
    return res.status(400).json({ message: 'Username and password are required.' });
  }
 
  if (username === dummyUser.username && password === dummyUser.password) {
    const userPayload = {
      username: dummyUser.username,
      name: dummyUser.name
    };
 
    const token = jwt.sign(userPayload, JWT_SECRET, { expiresIn: '1h' });
 
    res.json({
      message: 'Login successful!',
      token: token
    });
  } else {
    res.status(401).json({ message: 'Invalid username or password.' });
  }
});
 

app.get('/api/pokemon', verifyToken, async (req, res) => {

  console.log(`User ${req.user.name} is requesting Pokémon data.`);
 
  try {
    const response = await axios.get('https://pokeapi.co/api/v2/pokemon?limit=20');
    const pokemonWithImages = response.data.results.map((pokemon, index) => {
      const id = index + 1;
      return {
        name: pokemon.name,
        imageUrl: `https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/${id}.png`
      };
    });
 
    res.json(pokemonWithImages);
  } catch (error) {
    console.error('Failed to fetch from PokeAPI:', error);
    res.status(500).json({ message: 'Failed to fetch Pokémon data.' });
  }
});
 
app.listen(PORT, () => {
  console.log(`PokéVerse auth server running on http://localhost:${PORT}`);
  console.log('Test user:');
  console.log('  Username: vishal');
  console.log('  Password: password123');
});