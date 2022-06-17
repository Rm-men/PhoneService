import 'bootstrap/dist/css/bootstrap.min.css';
import './index.css';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import React, { useState } from 'react';
import ReactDOM from 'react-dom';
// import configureStore from './redux/store';
import { Container, Button, Form } from 'react-bootstrap';

import App from './components/App';
import Landing from './components/wiews/Landing';
import UserCabinet from './components/usercabinet/UserCabinet';
import Login from './components/wiews/Login';
import Register from './components/wiews/Register';
import NewOrder from './components/wiews/NewOrder';
import LNavbar from './components/landing/LNavbar';
import Links from './components/Links';
import Erorr from './components/eror';
import Layout from './components/Layout';

// import { Provider } from 'react-redux';
// import { store } from './redux/store';

// const store = configureStore();

ReactDOM.render(
  <React.StrictMode>
    <App/>
    {/* <Provider store={store}>
      <BrowserRouter>
        {/* 
        <LNavbar />
        <Routes>
          <Route path={Links.register} element={<Register />} />
          <Route path={'/'} element={<Landing />} />
          <Route path={Links.usercabinet} element={<UserCabinet />} />
          <Route path={Links.auth} element={<Login />} />
          <Route path="*" element={<Erorr />} />
        </Routes>

        <Routes>
          <Route path={'/'} element= {<Layout/>}>
            <Route index element={<Landing />} />
            <Route path={Links.register} element={<Register />} />

            <Route path={Links.usercabinet} element={<UserCabinet />} />
            <Route path={Links.auth} element={<Login />} />
            <Route path='*' element={<Erorr />} />
          </Route>
        </Routes>
      </BrowserRouter>
    </Provider> 
  */}
  </React.StrictMode>,
  document.getElementById('root')
);
