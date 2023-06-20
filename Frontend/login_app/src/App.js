import React, { useState } from "react";
import './App.css';
import LoginForm from './LoginForm';
import LoginAttemptList from './LoginAttemptList';

const App = () => {
  const [loginAttempts, setLoginAttempts] = useState([]);
    const [loggedInUser, setLoggedInUser] = useState(null);

    const handleLogin = ({ login, password }) => {
        const authenticatedUser = { login, password }; 
        setLoggedInUser(authenticatedUser);
    };

  return (
      <div className="App">
          {loggedInUser ? ( 
              <div>
                  <h2>Hello, {loggedInUser.login}!</h2>
                  <button onClick={() => setLoggedInUser(null)}>Logout</button>
              </div>
          ) : (
              <LoginForm onSubmit={handleLogin} />
          )}
          <LoginAttemptList attempts={loginAttempts} />
      </div>
  );
};

export default App;
