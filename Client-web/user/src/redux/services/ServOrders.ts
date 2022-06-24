import axios from 'axios';
import { Answer, LoginModel, RegistrationModel } from '../../models/RequestModels';
import { removeCookie, setCookie } from 'typescript-cookie';
import { clientActions, State } from '../slices/clientSlice';
import { RegisterFail, LoginFail } from '../actions/authActions';
import { Client } from '../../models/ClientModel';
import { useNavigate } from 'react-router-dom';

import Links from '../../components/Links';
import { OrderModel } from '../../models/OrderModel';
import authHeader from '../AuthHeader';

class ServOrders {
  getOrders() {
    return axios.get(Links.api_orders + 'getorder', { headers: authHeader() })
      .then((response) => {
         // console.log(response.data);
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
  setAgree(id : any) {
    return axios.get(Links.api_orders + 'setagree?id='+id, { headers: authHeader() })
      .then((response) => {
         // console.log(response.data);
        const data: Answer = response.data;
        if (data.status) {
          // const orders: OrderModel[] = data.answer.orders;
          console.log("Заказ под номером "+id+" получил согласие");
          return;
        }
        return [];
      })
      .catch((error) => {
        console.log(error);
        return [];
      });
  }
  setDisAgree(id : any) {
    return axios.get(Links.api_orders + 'setdisagree?id='+id, { headers: authHeader() })
      .then((response) => {
         // console.log(response.data);
        const data: Answer = response.data;
        if (data.status) {
          // const orders: OrderModel[] = data.answer.orders;
          console.log("Заказ под номером "+id+" получил отказ");
          return;
        }
        return [];
      })
      .catch((error) => {
        console.log(error);
        return [];
      });
  }
  setPay(id : any) {
    return axios.get(Links.api_orders + 'setpay?id='+id, { headers: authHeader() })
      .then((response) => {
         // console.log(response.data);
        const data: Answer = response.data;
        if (data.status) {
          console.log("Заказ под номером "+id+" оплачен");
          alert("Оплачено!");
          return;
        }
        return [];
      })
      .catch((error) => {
        console.log(error);
        alert("Ошибка оплаты!");
        return [];
      });
  }
  
  
}

export default new ServOrders();
