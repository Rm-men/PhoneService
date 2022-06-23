import axios from 'axios';
import { Answer, LoginModel, RegistrationModel } from '../../models/RequestModels';
import { removeCookie, setCookie } from 'typescript-cookie';
import { clientActions, State } from '../slices/clientSlice';
import { RegisterFail, LoginFail } from '../actions/authActions';
import { Client } from '../../models/ClientModel';
import { useNavigate } from 'react-router-dom';

import Links from '../../components/Links';
import { OrderModel } from '../../models/OrderModel';
import { PhonesModel } from '../../models/PhonesModel';
import { AddressModel } from '../../models/AddressModel';
import { OrderMoveModel } from '../../models/OrderMoveModel';
import authHeader from '../AuthHeader';

class ServGetLists {
  getOrderMove(id : any ) {
    return axios.get(Links.api_get_lists + 'ordmove?id='+id, { headers: authHeader() })
      .then((response) => {
        // console.log(response.data);
        const data: Answer = response.data;
        if (data.status) {
          const ordmoves: OrderMoveModel[] = data.answer.ordmoves;
          // console.log(ordmoves);
          return ordmoves;
        }
        return [];
      })
      .catch((error) => {
        console.log(error);
        return [];
      });
  }
  getPhones() {
    return axios.get(Links.api_get_lists + 'phones', { headers: authHeader() })
      .then((response) => {
        // console.log(response.data);
        const data: Answer = response.data;
        if (data.status) {
          const phonemodels: PhonesModel[] = data.answer.phonemodels;
          return phonemodels;
        }
        return [];
      })
      .catch((error) => {
        console.log(error);
        return [];
      });
  }
  getAddress() {
    return axios.get(Links.api_get_lists + 'addres', { headers: authHeader() })
      .then((response) => {
        console.log(response.data);
        const data: Answer = response.data;
        if (data.status) {
          const addresses: AddressModel[] = data.answer.addresses;
          return addresses;
        }
        return [];
      })
      .catch((error) => {
        console.log(error);
        return [];
      });
  }
  
}

export default new ServGetLists();
