import { useContext, useState } from 'react';
import { ItemContext } from './ItemContext';
import UserProfile from './UserProfile';

function App() {
  const { items, dispatch } = useContext(ItemContext);
  const [input, setInput] = useState('');

  return (
    <div>
      <h1>Add Card</h1>
      <input
        value={input}
        onChange={(e) => setInput(e.target.value)}
        placeholder="Add name"
      />
      <button onClick={() => {
        if (input.trim()) {
          dispatch({ type: 'ADD', payload: input });
          setInput('');
        }
      }}>Add</button>

      <div className="card-container">
        {/* Hardcoded cards */}
        <div className="App">
          <UserProfile
            initialName="Vishal"
            initialAvatar="https://api.dicebear.com/9.x/adventurer/svg?seed=Easton"
            initialBio="Backend engineer who loves databases and APIs"
          />
        </div>
        <div className="App">
          <UserProfile
            initialName="Akshat"
            initialAvatar="https://api.dicebear.com/9.x/adventurer/svg?seed=Liam"
            initialBio="Frontend developer with a passion for clean UI and UX."
          />
        </div>

        {/* Dynamic cards from context */}
        {items.map((name, i) => (
          <div className="App" key={i}>
            <UserProfile
              initialName={name}
              initialAvatar={`https://api.dicebear.com/9.x/adventurer/svg?seed=${name}`}
              initialBio="New user added from global list"
            />
            <button onClick={() => dispatch({ type: 'REMOVE', payload: i })}>
              Delete
            </button>
          </div>
        ))}
      </div>
    </div>
  );
}

export default App;