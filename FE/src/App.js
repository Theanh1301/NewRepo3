import React from 'react';
import './App.css';
import Signin from './Signin';

function App() {
  // const token = localStorage.getItem('accessToken');

  // if(!token) {
  //   return <Signin />
  // }

  return (
    <div className="wrapper">
      <Signin />
    </div>
  );
}

export default App;