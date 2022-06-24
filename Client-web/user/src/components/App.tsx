import 'bootstrap/dist/css/bootstrap.min.css';
import './../index.css';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import React, { useState } from 'react';
import ReactDOM from 'react-dom';
// import configureStore from './redux/store';
import { Container, Button, Form } from 'react-bootstrap';

import Landing from './wiews/Landing';
import UserCabinet from './usercabinet/UserCabinet';
import Login from './wiews/Login';
import Register from './wiews/Register';
import NewOrder from './wiews/NewOrder';
import LNavbar from './landing/LNavbar';
import Links from './Links';
import Erorr from './eror';
import Layout from './Layout';

import { Provider } from 'react-redux';
import { store } from '../redux/store';

import { useDispatch, useSelector } from 'react-redux';

import { AppDispatch, RootState } from '../redux/store';

export default function App() {
  
  // const user = useSelector((state: RootState) => state);
  return (
    <>
      <Provider store={store}>
        <BrowserRouter>
          <Routes>
            <Route path={'/'} element={<Layout />}>
              <Route index element={<Landing />} />
              <Route path={Links.register} element={<Register />} />
              <Route path={Links.usercabinet} element={<UserCabinet />} />
              <Route path={Links.auth} element={<Login />} />
              <Route path='*' element={<Erorr />} />
            </Route>
          </Routes>
        </BrowserRouter>
      </Provider>
    </>
  );
}
