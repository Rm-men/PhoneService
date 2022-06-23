import axios from "axios";
import {Answer, LoginModel, RegistrationModel} from "../../models/RequestModels";
import {removeCookie, setCookie} from "typescript-cookie";
import {clientActions, State} from '../slices/clientSlice';
import {RegisterFail,  LoginFail,} from "../actions/authActions"
import {Client} from "../../models/ClientModel";
import { useNavigate } from 'react-router-dom';

import Links from '../../components/Links';

class AuthService {
	login(login: LoginModel) {
		return axios.post(Links.api_auth  + "signin", login).then(
			(res) => {
				const data: Answer = res.data;
				console.log (' Пошла авторизация, почта: '+login.email+', пароль: '+login.password+'. Сервер вот что сказал на это: '+data.answer);
				if (data.status) {
					setCookie("access_token", data.answer.access_token, {expires: 365, path: ''});
					const client: Client = data.answer.user;
					localStorage.setItem('user', JSON.stringify(client));
					console.log ('Авторизация успешна');
					// User.user;
					return clientActions.loginSuccess({isAuth: true, client: client});;
				}
				console.log ('Неверный логин/пароль');
				alert('Неверный логин/пароль');
				return LoginFail(data.errorText!);
			}).catch((err) => {
				console.log ('Поизошла обшибка');
			return LoginFail(err);
		})
	}
	register(reg: RegistrationModel) {
		return axios.post(Links.api_auth + "signon", reg)
			.then((res) => {
				const data: Answer = res.data;
				console.log (' Пошла авторизация, почта: '+reg.email+', пароль: '+reg.clpassword+', отчество: '+reg.patronymic+'. Сервер вот что сказал на это: '+data.answer);
				if (data.status) {
					setCookie("access_token", data.answer.access_token, {expires: 365, path: ''});
					const client: Client = data.answer.user;
					localStorage.setItem('user', JSON.stringify(client))
					console.log ('Регистрация успешна');
					return clientActions.registerSuccess({isAuth: true, client: client});;
				}
				console.log ('Кто-то пытался перерегистрироваться');
				return RegisterFail(data.errorText!);
			}).catch((err) => {
				console.log ('Поизошла обшибка');
				return RegisterFail(err);
			})
	}

	logout(){
		removeCookie("access_token", {path: ''});
		localStorage.removeItem('user');
		return clientActions.logout();
	}
}

export default new AuthService();