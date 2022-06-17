import { Container, Row, Col, Form, FormGroup, Button, Modal, Card } from 'react-bootstrap';
import { Label, Input } from 'reactstrap';
import { Link } from 'react-router-dom';
import { useLocation } from 'react-router-dom'; // берет текущий url
import React, { useState } from 'react';
import Links from '../Links';

import { AppDispatch, RootState } from '../../redux/store';
import { useDispatch, useSelector } from 'react-redux';

import FormNewOrderFull from './FormNewOrderFull';
import { NewOrderModel } from '../../models/NewOrderModel';

import ServAddOrder from '../../redux/services/ServAddOrder';

export default function BtnNewOrder() {
  const [show, setShow] = useState(false);
  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);

  const user = useSelector((state: RootState) => state);
  const managerModal = () => {};

  const handleChange = (prop: keyof State) => (event: React.ChangeEvent<HTMLInputElement>) => {
    setValues({ ...values, [prop]: event.target.value.trim() });
  };


  interface State {
    Phonenumber: string;
    Address: string;
    IdPhone: number;
    Descriptionord: string;
  }
  const [values, setValues] = useState<State>({
    Phonenumber: '',
    Address: '',
    IdPhone: 1,
    Descriptionord: '',
  });
  // const user = useSelector((state: RootState) => state);

  const onClick = () => {
    const data: NewOrderModel = {
      Phonenumber: values.Phonenumber,
      Address: values.Address,
      IdPhone: values.IdPhone,
      Descriptionord: values.Descriptionord,
      Email: user.client.client?.Email!,
    };
    ServAddOrder.order(data).then((res) => {
      // dispatch(res);
      handleClose();
    });
  };

  return (
    <>
      <Button color='primary' size='lg' className=' mt-4' onClick={handleShow}>
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
                    <Form>
                      <Form.Group className='mb-3' controlId='formBasicName'>
                        <Form.Label>Название устройства </Form.Label>
                        <Form.Control
                          type='phonename'
                          placeholder='Введите название устройства'
                          value={values.IdPhone}
                          onChange={handleChange('IdPhone')}
                        />
                        {/* <Form.Text className='text-muted'>
            We'll never share your email with anyone else.
          </Form.Text> */}
                      </Form.Group>
                      <Form.Group className='mb-3' controlId='formBasicPhone'>
                        <Form.Label>Номер телефона</Form.Label>
                        <Form.Control
                          type='phone'
                          placeholder='Введите номер телефона'
                          value={values.Phonenumber}
                          onChange={handleChange('Phonenumber')}
                        />
                        <Form.Text className='text-muted'>
                          Введите номер телефона, на который придет сообщение о готовности
                        </Form.Text>
                      </Form.Group>
                      <Form.Group className='mb-3'>
                        <Form.Label>Выберите пункт приема</Form.Label>
                        <Form.Select value={values.Address} 
                          onChange={e => {
                            // console.log(e.target.value);
                            values.Address = e.target.value;
                            console.log(values.Address);
                          }}
                        >
                          <option value='ул. Московская 36'>ул. Московская 36</option>
                          <option value='???'>???</option>
                        </Form.Select>
                      </Form.Group>
                      <Form.Group className='mb-3' controlId='exampleForm.ControlTextarea1'>
                        <Form.Label>Введите описание неисправности</Form.Label>
                        <Form.Control
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
                        <Button color='primary' size='lg' onClick={onClick}>
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
