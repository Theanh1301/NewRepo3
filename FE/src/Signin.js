import React, { useState } from 'react';


async function loginUser(credentials) {
  return fetch('https://localhost:7264/api/Login/login', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(credentials)
  })
    .then(data => data.json())
 }

export default function Signin() {

  const [username, setUserName] = useState();
  const [password, setPassword] = useState();

  const handleSubmit = async e => {
    e.preventDefault();
    const response = await loginUser({
      username,
      password
    });

    console.log(response);
    // if ('accessToken' in response) {
    //   swal("Success", response.message, "success", {
    //     buttons: false,
    //     timer: 2000,
    //   })
    //   .then((value) => {
    //     localStorage.setItem('accessToken', response['accessToken']);
    //     localStorage.setItem('user', JSON.stringify(response['user']));
    //     window.location.href = "/profile";
    //   });
    // } else {
    //   swal("Failed", response.message, "error");
    // }
  }

  return (
    <form  noValidate onSubmit={handleSubmit}>
    <input
      variant="outlined"
      margin="normal"
      required
      
      id="email"
      name="email"
      label="Email Address"
      onChange={e => setUserName(e.target.value)}
    />
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
    <button
      type="submit"
      
      variant="contained"
      color="primary"
    >
      Sign In
    </button>
  </form>
  );
}