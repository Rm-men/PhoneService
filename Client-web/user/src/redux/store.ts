import { createStore, applyMiddleware, combindeReducers, compose} from 'redux';
import thunk from 'redux-thunk';
import reduxLogger from 'redux-logger';
import rootReducers from '';
const configureStore = (reducers = {}, reloadedState = {}, middlewares = []) => createStore(
	combindeReducers( // объединение для Reducers
		...rootReducers,

		...reducers
	),
	preloadedState,
	compose(  // добавление прослоек и расширений
		applyMiddleware(
			...middlewares,
			thunk,
			reduxLogger
		),
		window.__REDUX_DEVTOOLS_EXTENSION__ && window.__REDUX_DEVTOOLS_EXTENSION__()
	)
);
export default configureStore;

// devstore
