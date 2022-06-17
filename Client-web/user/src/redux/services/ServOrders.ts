import axios from 'axios';
import { Answer, LoginModel, RegistrationModel } from '../../models/RequestModels';
import { removeCookie, setCookie } from 'typescript-cookie';
import { clientActions, State } from '../slices/clientSlice';
import { RegisterFail, LoginFail } from '../actions/authActions';
import { Client } from '../../models/ClientModel';
import User from '../../components/User';
import { useNavigate } from 'react-router-dom';

import Links from '../../components/Links';
import { OrderModel } from '../../models/OrderModel';
import authHeader from '../AuthHeader';

class ServOrders {
  getOrders() {
	console.log("Щаяс как приедет");
    return axios.get(Links.api_orders + 'getorder', { headers: authHeader() })
      .then((response) => {
        console.log(response.data);
        const data: Answer = response.data;
        if (data.status) {
          const orders: OrderModel[] = data.answer.orders;
          return orders;
        }
        return [];
      })
      .catch((error) => {
        console.log(error);
        return [];
      });
  }
}

export default new ServOrders();
