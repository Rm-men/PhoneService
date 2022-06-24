import {
  Container,
  Row,
  Col,
  Form,
  FormGroup,
  Button,
  Modal,
  Card,
  InputGroup,
} from 'react-bootstrap';
import { Label, Input } from 'reactstrap';
import { Link } from 'react-router-dom';
import { useLocation, useNavigate } from 'react-router-dom'; // берет текущий url
import React, { useState } from 'react';
import Links from '../Links';

import { AppDispatch, RootState } from '../../redux/store';
import { useDispatch, useSelector } from 'react-redux';

import FormNewOrderFull from './FormNewOrderFull';
import { NewOrderModel } from '../../models/NewOrderModel';

import ServAddOrder from '../../redux/services/ServAddOrder';
import ServGetLists from '../../redux/services/ServGetLists';
import { AddressModel } from '../../models/AddressModel';
import { PhonesModel } from '../../models/PhonesModel';

export default function BtnNewOrder() {

  const [addresses, setAdresses] = useState<AddressModel[]>([]);
  const [phones, setPhones] = useState<PhonesModel[]>([]);
  const [addres, setAddres] = useState<string>('');
  const [phone, setPhone] = useState<string>('');
  const [curphone, setCurPhone] = useState<PhonesModel>();

  const [show, setShow] = useState(false);
  const handleClose = () => setShow(false);
  const openNewOrderModal = () => {
    console.log('Поехало');
    setShow(true);
    // ServGetLists.getAddress().then((res: any) => {
    //   console.log(res);
    //   setAdresses(res);
    // });
    ServGetLists.getPhones().then((res: any) => {
      console.log(res);
      setPhones(res);
      // setPhone("Ноутилус ++");
    });
  };

  const user = useSelector((state: RootState) => state);
  const managerModal = () => {};
  const handleChange = (prop: keyof State) => (event: React.ChangeEvent<HTMLInputElement>) => {
    setValues({ ...values, [prop]: event.target.value});
  };
  interface State {
    Phonenumber: string;
    Address: string;
    IdPhone: number;
    Descriptionord: string;
    Namephone: string,
  }
  const [values, setValues] = useState<State>({
    Phonenumber: '',
    Address: 'Ул. Московская 36',
    IdPhone: 1,
    Descriptionord: ' ',
    Namephone: 'Ноутилус ++',
  });
  // const user = useSelector((state: RootState) => state);
  const [validated, setValidated] = useState(false); //тумблер подсветки валидации

  const toCreateNewOrder = (event: any) => {
    const form = event.currentTarget;
    if (form.checkValidity() === false) {
      event.preventDefault();
      event.stopPropagation();
      return;
    } else setValidated(true); // активация подсветки валидации
    if (
      values.Phonenumber === '' ||
      values.Address === '' ||
      // values.IdPhone === 1 ||
      values.Descriptionord === ''
    ) {
      console.log('' + 'не');
      return;
    }
    const data: NewOrderModel = {
      Phonenumber: values.Phonenumber,
      Address: values.Address,
      IdPhone: values.IdPhone,
      Namephone: values.Namephone,
      Descriptionord: values.Descriptionord,
      Email: user.client.client?.Email!,
    };
    console.log(data);
    ServAddOrder.order(data).then((res) => {
      // dispatch(res);
      handleClose();
      // dispatch(res);
      navigate(0);
      // window.location.reload();
    });
  };
  const navigate = useNavigate();

  const dispatch = useDispatch<AppDispatch>();

  const [key, setKey] = useState<boolean>(false); // установка значений на странице

  React.useEffect(() => {
    // при загрузке страницы, один раз
    if (key) return;
    setKey(true);
  }, [addres, key]);

  const varClick = (phone: any) => {
    // setCu(order);
    // ServGetLists.getOrderMove(order?.IdOrder).then((res: any) => {
    //   console.log('ид заказа = ' + order?.IdOrder);
    //   console.log('ид покупателя = ' + order?.IdClient);
    //   setOrderMove(res);
    //   setShow(true);
    // });
    // // console.log('тыкнули на '+curorder?.PhoneModel);
    // setShow(true);
  };

  return (
    <>
      <Button color='primary' size='lg' className=' mt-4' onClick={openNewOrderModal}>
        Оставить заявку на ремонт
      </Button>

      {user.client.isAuth ? (
        <>
          <Modal show={show} onHide={handleClose}>
            <Modal.Header closeButton>
              <Modal.Title>Оформление заявки</Modal.Title>
            </Modal.Header>
            <Modal.Body>
              <Container>
                <Card className='no-hover'>
                  <Card.Body className='p-5'>
                    <Form noValidate validated={validated}>
                      <Form.Group className='mb-3' controlId='formBasicName'>
                        <Form.Label>Название устройства </Form.Label>
                        <Form.Select
                          placeholder='Введите название устройства'
                          required
                          value={phone}
                          onChange={(e) => {
                            // console.log(e.target.value);
                            values.Namephone = e.target.value;
                            setPhone( e.target.value)
                            // setPhone(phones[e.target.id].id);
                            // setPhone(e.target.value);
                            // setValues(e.target.value);
                            // handleChange('IdPhone');
                            
                            // console.log("выбранные телефон: "+values.Namephone);
                            // console.log(" телефон: "+e.target.value);
                            // console.log(" телефонsssss: "+curphone?.IdPhoneModel);
                          }}
                        >
                          {phones?.map((phones) => (
                            <option value={phones.Namephone}>{phones.Namephone}</option>
                          ))}
                          {/* <option value='ул. Московская 36'>ул. Московская 36</option>
                          <option value='???'>???</option>
                          <option value='ул. Ивана Попова 36'>ул. Ивана Попова 36</option> */}
                        </Form.Select>
                      </Form.Group>

                      <Form.Group controlId='formBasicPhNumb'>
                        {/* <Form.Group as={Col} md='4' controlId='formBasicPhNumb'>  - фикисрованная длина*/}
                        <Form.Label>Номер телефона</Form.Label>
                        <InputGroup hasValidation>
                          <InputGroup.Text id='inputGroupPrepend'>+7</InputGroup.Text>
                          <Form.Control
                            // type='number' появляются стрелочки для изменения числа, для номера оно не надо
                            placeholder='Введите номер телефона'
                            required
                            value={values.Phonenumber}
                            onChange={handleChange('Phonenumber')}
                          />
                          <Form.Text className='text-muted'>
                            Введите номер телефона, на который придет сообщение о готовности
                          </Form.Text>
                        </InputGroup>
                      </Form.Group>
                    </Form>
                    {/* <Form>
                      <Form.Group className='mb-3'>
                        <Form.Label>Выберите пункт приема</Form.Label>
                        <Form.Select
                          value={addres}
                          onChange={(e) => {
                            values.Address = e.target.value;
                            setAddres(e.target.value);
                            handleChange('Address');
                            console.log(values.Address);
                          }}
                        >
                          {addresses?.map((addresses) => (
                            <option value={addresses.Address}>{addresses.Address}</option>
                          ))}
                        </Form.Select>
                      </Form.Group>
                    </Form> */}
                    <Form noValidate validated={validated}>
                      <Form.Group className='mb-3' controlId='exampleForm.ControlTextarea1'>
                        <Form.Label>Введите описание неисправности</Form.Label>
                        <Form.Control
                          required
                          as='textarea'
                          rows={3}
                          value={values.Descriptionord}
                          onChange={handleChange('Descriptionord')}
                        />
                      </Form.Group>
                      <div className='text-center mt-5'>
                        <Button
                          variant='secondary'
                          size='lg'
                          className='me-2'
                          onClick={handleClose}
                        >
                          Отмена
                        </Button>
                        <Button color='primary' size='lg' onClick={toCreateNewOrder}>
                          Оформить заявку
                        </Button>
                      </div>
                    </Form>
                  </Card.Body>
                </Card>
              </Container>
            </Modal.Body>
          </Modal>
        </>
      ) : (
        <>
          <Modal show={show} onHide={handleClose}>
            <Modal.Header closeButton>
              <Modal.Title>Предупреждение</Modal.Title>
            </Modal.Header>
            <Modal.Body>
              Заявки на ремонт доступны <b>только зарегистрированным</b> пользователям.
              Авторизироваться?
            </Modal.Body>
            <Modal.Footer>
              <Button variant='secondary' onClick={handleClose}>
                Отмена
              </Button>
              <Link to={Links.auth}>
                <Button variant='primary' onClick={handleClose}>
                  Авторизироваться
                </Button>
              </Link>
            </Modal.Footer>
          </Modal>
        </>
      )}
    </>
  );
}
