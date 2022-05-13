import 'bootstrap/dist/css/bootstrap.min.css';
import React from 'react';
import ReactDOM from 'react-dom';
import Store from './redux/store';
// import configureStore from './redux/store';
import { Provider } from 'react-redux'; 
import App from './components/App';


// const store = configureStore();

ReactDOM.render(
	<React.StrictMode>
		<Provider store={Store}> 
			<BrowserRouter>
				<App>
				
				</App>
    		</BrowserRouter> 
		</Provider>
	</React.StrictMode>,
	document.getElementById('root')
);
