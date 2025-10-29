import React, { useEffect, useState } from 'react';
import axios from 'axios';

const PokemonList = () => {
  const [pokemon, setPokemon] = useState([]);
  const [error, setError] = useState('');

  useEffect(() => {
    axios.get('https://pokeapi.co/api/v2/pokemon?limit=10')
      .then((res) => {
        setPokemon(res.data.results);
        setError('');
      })
      .catch(() => {
        setError('Failed to fetch Pokémon data');
        setPokemon([]);
      });
  }, []);

  return (
    <div>
      <h2>Pokemon Names</h2>
      {error && <p style={{ color: 'red' }}>{error}</p>}
      <ul>
        {pokemon.map((p, index) => (
          <li key={index}>
            <strong>{p.name}</strong>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default PokemonList;