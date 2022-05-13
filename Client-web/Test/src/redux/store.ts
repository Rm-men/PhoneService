import { createStore, applyMiddleware, combineReducers, compose} from 'redux';
import thunk from 'redux-thunk';
import reduxLogger from 'redux-logger';
import rootReducers from './modules';


const configureStore = (reducers = {}, reloadedState = {}, middlewares = []) => createStore(
	combineReducers( // объединение для Reducers
		...rootReducers,
		...reducers // параметры configureStore
	),
	preloadedState, // initial состояние
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
