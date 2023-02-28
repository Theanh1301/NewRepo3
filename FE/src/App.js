import React from 'react';
import './App.css';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Signin from './Signin';
import Profile from './Profile';

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