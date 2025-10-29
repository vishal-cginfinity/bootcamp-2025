import React, { useState } from 'react';
import './UserProfile.css';

const UserProfile = ({ initialName, initialAvatar, initialBio }) => {
  const [name, setName] = useState(initialName);
  const [avatar, setAvatar] = useState(initialAvatar);
  const [bio, setBio] = useState(initialBio);
  const [isEditing, setIsEditing] = useState(false);

  const handleSave = () => {
    setIsEditing(false);
  };

  return (
    <div className="profile-card">
      <img src={avatar} alt="User Avatar" className="avatar" />
      <h2>{name}</h2>
      <p>{bio}</p>

      {isEditing ? (
        <div className="edit-section">
          <input
            type="text"
            value={name}
            onChange={(e) => setName(e.target.value)}
            placeholder="Update name"
          />
          <input
            type="text"
            value={avatar}
            onChange={(e) => setAvatar(e.target.value)}
            placeholder="Update avatar URL"
          />
          <textarea
            value={bio}
            onChange={(e) => setBio(e.target.value)}
            placeholder="Update bio"
          />
          <button onClick={handleSave}>Save</button>
        </div>
      ) : (
        <button className="edit-btn" onClick={() => setIsEditing(true)}>Edit</button>
      )}
    </div>
  );
};

export default UserProfile;