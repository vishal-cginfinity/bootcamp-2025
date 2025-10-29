import UserProfile from './UserProfile';

function App() {
  return (
    <div className="card-container">
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
    </div>
  );
}

export default App;