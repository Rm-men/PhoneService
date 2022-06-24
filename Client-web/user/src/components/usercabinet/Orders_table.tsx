import Modal from 'react-bootstrap/Modal';
import React, { useState } from 'react';
import {
  Button,
  Nav,
  Navbar,
  Container,
  NavDropdown,
  Table,
  Form,
  Placeholder,
  Card,
} from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap-icons/font/bootstrap-icons.css';
import Links from '../Links';
import { useLocation, useNavigate, Link } from 'react-router-dom';

import BtnNewOrder from '../newOrder/BtnNewOrder';
import ServOrders from '../../redux/services/ServOrders';
import ServGetLists from '../../redux/services/ServGetLists';
import { OrderModel } from '../../models/OrderModel';
import { OrderMoveModel } from '../../models/OrderMoveModel';

import { useDispatch, useSelector } from 'react-redux';

import { AppDispatch, RootState } from '../../redux/store';

export default function Orders_table() {
  const [show, setShow] = useState(false);

  const [orders, setOrders] = useState<OrderModel[]>([]);
  const [ordmoves, setOrderMove] = useState<OrderMoveModel[]>([]);
  const [curorder, setCurOrders] = useState<OrderModel>();

  const [key, setKey] = useState<boolean>(false); // установка значений на странице

  const handleClose = () => setShow(false);

  const handleShow = () => {
    console.log('тыкнули кнопку');
    // ServGetLists.getOrderMove().then((res: any) => {
    //   // console.log(res);
    //   setOrderMove(res);
    //   // setCurOrders(res[0])
    //   setShow(true);
    // });
  };
  const rowClick = (order: any) => {
    setCurOrders(order);
    console.log('Согласие ' + order.Agreement);
    ServGetLists.getOrderMove(order?.IdOrder).then((res: any) => {
      // console.log('ид заказа = ' + order?.IdOrder);
      // console.log('ид покупателя = ' + order?.IdClient);
      setOrderMove(res);
      setShow(true);
    });
    // console.log('тыкнули на '+curorder?.PhoneModel);
    setShow(true);
  };
  const clickPay = () => {
    ServOrders.setPay(curorder?.IdOrder).then((res: any) => {
      // console.log('ид заказа = ' + order?.IdOrder);
      // console.log('ид покупателя = ' + order?.IdClient);
      navigate(0);
    });
  };
  const navigate = useNavigate();

  const clickAgre = () => {
    ServOrders.setAgree(curorder?.IdOrder).then((res: any) => {
      // console.log('ид заказа = ' + order?.IdOrder);
      // console.log('ид покупателя = ' + order?.IdClient);
      navigate(Links.usercabinet);
      navigate(0);
    });
  };
  const clickDisAgre = () => {
    ServOrders.setDisAgree(curorder?.IdOrder).then((res: any) => {
      // console.log('ид заказа = ' + order?.IdOrder);
      // console.log('ид покупателя = ' + order?.IdClient);
      navigate(Links.usercabinet);
      navigate(0);
    });
  };

  React.useEffect(() => {
    // при загрузке страницы, один раз
    if (key) return;
    ServOrders.getOrders().then((res: any) => {
      // console.log(res);
      setOrders(res);
      setCurOrders(res[0]);
    });
    setKey(true);
  }, [orders, key]);

  const user = useSelector((state: RootState) => state);

  return (
    <div className='mt-5'>
      <Container>
        <h1 className='display-4'>Список устройств в ремонте</h1>
        <Container>
          <Table striped bordered hover responsive='sm'>
            <thead>
              <tr>
                <th>Устройство</th>
                <th>Описание</th>
                <th>Статус</th>
                <th>Цена</th>
              </tr>
            </thead>
            <tbody>
              {orders?.map((order) => (
                <tr
                  onClick={(e) => {
                    rowClick(order);
                  }}
                >
                  <td>{order?.PhoneModel}</td>
                  <td>{order?.Descriptionord}</td>
                  {/* <td>{order?.Phonenumber}</td> без знака вопроса будет пытаться загружать нулы  */}
                  <td>{order?.Status}</td>
                  <td>{order?.Priceord}</td>
                </tr>
              ))}
            </tbody>
          </Table>
        </Container>
        <Form className='form-subscribe form-inline mb-3'>
          <div className='text-center'>
            <BtnNewOrder />
          </div>
        </Form>
      </Container>
      <>
        <Modal show={show} onHide={handleClose}>
          <Modal.Header closeButton>
            <Modal.Title>Детализация закза</Modal.Title>
          </Modal.Header>
          <Modal.Body>
            <Card body>Устройство: {curorder?.PhoneModel}</Card>
            <Card body>Производитель: {curorder?.Manufacturer}</Card>
            <Card body>Описание: {curorder?.Descriptionord}</Card>
            <Card body>Текущий статус: {curorder?.Status}</Card>
            <Card body>Сумма ремнота: {curorder?.Priceord}</Card>
            {curorder?.Agreement ? (
              <>
                {curorder?.Payed !== null ? ( // если настало время оплаты
                  <>
                    {!curorder?.Payed ? ( // заказ не оплачен
                        <Card className=' deactive'>
                          <Card>
                            <Card.Body>
                              <Card.Title>Оплата заказа</Card.Title>
                              <Card.Text>Счет за заказ: {curorder?.Priceord}</Card.Text>
                              <Button variant='primary' onClick={clickPay}>
                                Оплатить
                              </Button>
                            </Card.Body>
                          </Card>
                        </Card>
                    ) : ( // заказ оплачен
                        <Card className=' deactive'>
                          <Card>
                            <Card.Body>
                              <Card.Title>Заказ оплачен</Card.Title>
                              <Card.Text>Счет за заказ: {curorder?.Priceord}</Card.Text>
                            </Card.Body>
                          </Card>
                        </Card>
                    )}
                  </>
                ) : (
                  <></>
                )}
              </>
            ) : (
              <>
                {curorder?.IdOrderStatus.toString() === 'waiting_0' && curorder?.Agreement === null ? ( // осуществление выбора согласия на ремонт
                  <>
                    <Card>
                      <Card.Body>
                        <Card.Title>Результат диагностики:</Card.Title>
                        <Card.Text>{curorder?.Diagnostic}</Card.Text>
                        <Button variant='light' className='me-2' onClick={clickDisAgre}>
                          Отказ от ремонта
                        </Button>
                        <Button variant='primary' onClick={clickAgre}>
                          Согласие на ремонт
                        </Button>
                      </Card.Body>
                    </Card>
                  </>
                ) : (
                  <>
                    {curorder?.Agreement !== null ? ( // Статус согласия утвержден
                      <>
                        {curorder?.Agreement ? ( //
                          <Card body>Согласие на ремонт: получено</Card>
                        ) : (
                          <>
                            <Card body>Согласие на ремонт: отказано</Card>
                          </>
                        )}
                        <Card>
                          <Card.Body>
                            <Card.Title>Результат диагностики:</Card.Title>
                            <Card.Text>{curorder?.Diagnostic}</Card.Text>
                          </Card.Body>
                        </Card>
                      </>
                    ) : (
                      <></>
                    )}
                  </>
                )}
              </>
            )}

            {ordmoves.length >= 1 ? ( // если статусы перемещения вообще есть - отобразить их
              <>
                <Card body>
                  <Card.Body>История перемещений:</Card.Body>
                  <Table>
                    <thead>
                      <tr>
                        <th>Статус</th>
                        <th>Дата</th>
                      </tr>
                    </thead>
                    <tbody>
                      {ordmoves?.map((move) => (
                        <tr>
                          <td>{move?.NewstatusDesc}</td>
                          <td>{move?.Somdate}</td>
                        </tr>
                      ))}
                    </tbody>
                  </Table>
                </Card>
              </>
            ) : (
              <></>
            )}
          </Modal.Body>
        </Modal>
      </>
    </div>
  );
}
