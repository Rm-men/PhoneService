import React from 'react';
import ReactDOM from 'react-dom';
import Store from './redux/store';
import configureStore from './redux/store';
import { Provider } from 'react-redux';

const store = configureStore();

ReactDOM.render(
	<React.StrictMode>
		<Provider store={store}>
			<App>
				
			</App>
		</Provider>
	</React.StrictMode>,
	document.getElementById('root')
);
