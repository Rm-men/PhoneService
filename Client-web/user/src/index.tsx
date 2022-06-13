import 'bootstrap/dist/css/bootstrap.min.css';
import {BrowserRouter, Routes, Route} from 'react-router-dom';
import React from 'react';
import ReactDOM from 'react-dom';
// import configureStore from './redux/store';
import { Provider } from 'react-redux'; 

import App from './components/App';
import Landing from './components/wiews/Landing'; 
import UserCabinet from './components/wiews/UserCabinet';
import Login from './components/wiews/Login';
import Register from './components/wiews/Register';
import NewOrder from './components/wiews/NewOrder'; 

// const store = configureStore();

ReactDOM.render(
	<React.StrictMode>
			<BrowserRouter>
            	<Routes>
            		<Route path={"/"} element={<Register />} />
            		<Route path={"home"} element={<Landing />} />
            		<Route path={"usercabinet"} element={<UserCabinet />} />
            		<Route path={"neworder"} element={<NewOrder />} />
            		<Route path={"login"} element={<Login />} />
            	</Routes>
    		</BrowserRouter> 
	</React.StrictMode>,
	document.getElementById('root')
);
