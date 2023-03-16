import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';


async function signupUser(credentials) {
  return fetch('https://localhost:7264/api/Register', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(credentials)
  })
    .then(data => data.json())

 }
export default function Signup() {

  const [username, setUserName] = useState();
  const [password, setPassword] = useState();
  const [repassword, setRePassword] = useState();
  const [email, setEmail] = useState();
  const [phone, setPhone] = useState();
  const [name, setName] = useState();
  const navigate = useNavigate();
  const handleSubmit = async e => {
    e.preventDefault();
    const response = await signupUser({
      username,
      password,
      repassword,
      email,
      phone,
      name
    }
    );
    navigate('/');

    console.log(response);
  }

  return (
    <form  noValidate onSubmit={handleSubmit}>
    Username
    <input
      variant="outlined"
      margin="normal"
      required

      id="username"
      name="username"
      label="Username"
      onChange={e => setUserName(e.target.value)}
    />
    <br/>
    Password
    <input
      variant="outlined"
      margin="normal"
      required

      id="password"
      name="password"
      label="Password"
      type="password"
      onChange={e => setPassword(e.target.value)}
    />
    <br />
    Re Password
    <input
      variant="outlined"
      margin="normal"
      required

      id="repassword"
      name="repassword"
      label="Re Password"
      type="password"
      onChange={e => setRePassword(e.target.value)}
    />
    <br/>
    Phone Number
    <input
      variant="outlined"
      margin="normal"
      required

      id="phone"
      name="phone"
      label="Phone Number"
      onChange={e => setPhone(e.target.value)}
    />
    <br/>
    Email
    <input
      variant="outlined"
      margin="normal"
      required

      id="email"
      name="email"
      label="Email"
      onChange={e => setEmail(e.target.value)}
    />
    <br/>
    Full Name
    <input
      variant="outlined"
      margin="normal"
      required

      id="name"
      name="name"
      label="Name"
      onChange={e => setName(e.target.value)}
    />
    <br/>
    <button
      type="submit"

      variant="contained"
      color="primary"
    >

      Sign Up
    </button>
  </form>
  );
}