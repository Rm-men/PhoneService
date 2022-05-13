import 'bootstrap/dist/css/bootstrap.min.css';
import {BrowserRouter} from 'react-router-dom';
import React from 'react';
import ReactDOM from 'react-dom';
// import configureStore from './redux/store';
import { Provider } from 'react-redux'; 

import App from './components/App';
import Landing from './components/Landing';
import Registration from './components/Registration';
import UserCabinet from './components/UserCabinet';
import Login from './components/Login';

// const store = configureStore();

ReactDOM.render(
	<React.StrictMode>
			<BrowserRouter>
				<Landing/>
    		</BrowserRouter> 
	</React.StrictMode>,
	document.getElementById('root')
);
