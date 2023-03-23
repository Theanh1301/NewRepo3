import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import axios from 'axios';
import './Signin.css';
import { Container } from 'react-bootstrap';

function Signin() {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const navigate = useNavigate();

  function navigateToSignup(){
    navigate('/Signup');
  }

  function handleSubmit(event) {
    event.preventDefault();
    axios.post('https://localhost:7264/api/Login', { username, password })
      .then(response => {
        //localStorage.setItem('token', response.data.token);
        localStorage.setItem('user', JSON.stringify(response.data.user));
        navigate('/');
        alert("Đăng nhập thành công");
      })
      .catch(
        //alert("Đăng nhập không thành công")
      );
  }

  return (
<div className='login-container'>
  <div className='login-page'>
  <div className='form'>
    <form className='login-form'  onSubmit={handleSubmit}>
      <input type="text" placeholder="username"  value={username} onChange={event => setUsername(event.target.value)}/>
      <input type="password" placeholder="password" value={password} onChange={event => setPassword(event.target.value)}/>
      <button type='submit'>login</button>
      <p className="message">Not registered? <a href="#" onClick={() => navigateToSignup()}>Create an account</a></p>
    </form>
  </div>
</div>
</div>
    // <form onSubmit={handleSubmit}>
    //   <label>
    //     Username:
    //     <input type="text" value={username} onChange={event => setUsername(event.target.value)} />
    //   </label>
    //   <br />
    //   <label>
    //     Password:
    //     <input type="password" value={password} onChange={event => setPassword(event.target.value)} />
    //   </label>
    //   <br />
    //   <button type="submit">Login</button>
    // </form>
  );
}

export default Signin;