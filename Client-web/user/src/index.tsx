import 'bootstrap/dist/css/bootstrap.min.css';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import React from 'react';
import ReactDOM from 'react-dom';
// import configureStore from './redux/store';
import { Container, Button, Form } from 'react-bootstrap';

import App from './components/App';
import Landing from './components/wiews/Landing';
import UserCabinet from './components/usercabinet/UserCabinet';
import Login from './components/wiews/Login';
import Register from './components/wiews/Register';
import NewOrder from './components/wiews/NewOrder';
import L_Navibar from './components/usercabinet/auth_Navibar';
import LNavbar from './components/landing/LNavbar';
import L_Landing from './components/wiews/L_Landing';
import Links from './components/Links';

import { Provider } from 'react-redux';
import { store } from './redux/store';

// const store = configureStore();

ReactDOM.render(
  <React.StrictMode>
    <Provider store={store}>
      <BrowserRouter>
        <LNavbar />
        <Routes>
          <Route path={'/home/registred'} element={<L_Landing />} />
          <Route path={Links.register} element={<Register />} />
          <Route path={'/'} element={<Landing />} />
          <Route path={Links.usercabinet} element={<UserCabinet />} />
          <Route path={'neworder'} element={<NewOrder />} />
          <Route path={Links.auth} element={<Login />} />
        </Routes>
      </BrowserRouter>
    </Provider>
  </React.StrictMode>,
  document.getElementById('root')
);
