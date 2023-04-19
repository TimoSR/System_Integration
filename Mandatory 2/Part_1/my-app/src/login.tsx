import React, {useState} from 'react';
import {auth} from './firebase';
import { signInWithEmailAndPassword } from 'firebase/auth';

/* 
    React.FC: This stands for "React Functional Component". It's a type alias provided by the @types/react package
*/

const LoginPage: React.FC = () => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
  
    const login = async (e: React.FormEvent) => {
      e.preventDefault();
      try {
        await signInWithEmailAndPassword(auth, email, password);
        alert('Logged in successfully!');
      } catch (error: any) {
        alert('Error logging in: ' + error.message);
      }
    };

    return (
        <form onSubmit={login}>
            <h1>Login</h1>
            <input
                type="email"
                placeholder="email"
                value={email}
                onChange={(e) => setEmail(e.target.value)}
            />
            <input
                type="password"
                placeholder="password"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
            />
            <button type="submit">Login</button>
        </form>
    );

};
  
export default LoginPage;