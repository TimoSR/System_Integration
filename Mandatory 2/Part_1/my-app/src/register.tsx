import React, {useState} from 'react';
import {auth} from './firebase';
import {createUserWithEmailAndPassword} from 'firebase/auth';

const RegisterPage: React.FC = () => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

    const register = async (e: React.FormEvent) => {
        e.preventDefault();
        try {
            await createUserWithEmailAndPassword(auth, email, password);
            alert('Account created successfully!')
        } catch (error: any) {
            alert('Error creating account: ' + error.message)
        }
    };

    return (
        <form onSubmit={register}>
            <h1>Register</h1>
            <input 
                type='email'
                placeholder='email'
                value={email}
                onChange={(e) => setEmail(e.target.value)}
            />
            <input
                type='password'
                placeholder='password'
                value={password}
                onChange={(e) => setPassword(e.target.value)}
            />
            <button type='submit'>Register</button>
        </form>
    );
};

export default RegisterPage;