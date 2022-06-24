import axios from "axios";
import {Answer, LoginModel, RegistrationModel} from "../../models/RequestModels";
import {removeCookie, setCookie} from "typescript-cookie";
import {clientActions, State} from '../slices/clientSlice';
import {RegisterFail,  LoginFail,} from "../actions/authActions"
import {Client} from "../../models/ClientModel";

import Links from '../../components/Links';
import { NewOrderModel } from '../../models/NewOrderModel';

class ServAddOrder {
// почемы бы через подобный класс не выдавать клиента?

	order(order: NewOrderModel) {
		return axios.post(Links.api_usercabinet  + "neworder", order).then(
			(res) => {
				const data: Answer = res.data;
				console.log (' Новый заказ инициализирован, адрес: '+order.Address+'. Сервер вот что сказал на это: '+data.answer);
				console.log (res);
				// if (data.status) {
				// 	setCookie("access_token", data.answer.access_token, {expires: 365, path: ''});
				// 	const client: Client = data.answer.user;
				// 	localStorage.setItem('user', JSON.stringify(client));
				// 	console.log ('Авторизация успешна');
				// 	// User.user;
				// 	return clientActions.loginSuccess({isAuth: true, client: client});;
				// }
				// console.log ('Кто-то попутал логин/пароль');
				return LoginFail(data.errorText!);
				// return res.;
			}).catch((err) => {
				console.log ('Поизошла обшибка');
			return LoginFail(err);
		})
	}
}

export default new ServAddOrder();