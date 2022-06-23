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
import { Link } from 'react-router-dom';
import Links from '../Links';
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
    ServGetLists.getOrderMove(order?.IdOrder).then((res: any) => {
      // console.log('ид заказа = ' + order?.IdOrder);
      // console.log('ид покупателя = ' + order?.IdClient);
      setOrderMove(res);
      setShow(true);
    });
    // console.log('тыкнули на '+curorder?.PhoneModel);
    setShow(true);
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
          <Table striped bordered hover responsive="sm">
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
            <Card body>Описание: {curorder?.Descriptionord}</Card>
            <Card body>Текущий статус: {curorder?.Status}</Card>
            <Card body>Сумма ремнота: {curorder?.Priceord}</Card>
            {curorder?.Agreement ? (
              <Card className=' deactive me-2'>
                <Card>
                  <Card.Body>
                    <Card.Title>Оплата заказа</Card.Title>
                    <Card.Text>Счет за заказ: {curorder?.Priceord}</Card.Text>
                    <Button variant='primary' onClick={handleClose}>
                      Оплатить
                    </Button>
                  </Card.Body>
                </Card>{' '}
              </Card>
            ) : (
              <>
                {curorder?.IdOrderStatus.toString() === 'waiting_0' ? ( // при статусе "ожидает подтверждения"
                // должно: выводиться описание диагностики и согласмие на длаьнейший ремонт
                  <>
                    <Card>
                      <Card.Body>
                        <Card.Title>Результат диагностики:</Card.Title>
                        <Card.Text>{curorder?.Diagnostic}</Card.Text>
                        <Button variant='light' className='me-2' onClick={handleClose}>
                          Отказ от ремонта
                        </Button>
                        <Button variant='primary' onClick={handleClose}>
                          Согласие на ремонт
                        </Button>
                      </Card.Body>
                    </Card>
                  </>
                ) : (
                  <>
                      {curorder?.Agreement ?  // при полученном согласии на ремнот
                      <>
                    <Card body>Согласие на диагностику: получено</Card>
                    <Card>
                      <Card.Body>
                        <Card.Title>Результат диагностики:</Card.Title>
                        <Card.Text>{curorder?.Diagnostic}</Card.Text>
                      </Card.Body>
                    </Card>
                      </> 
                      : 
                      <>
                    <Card body>Согласие на диагностику: отказано</Card>
                    <Card>
                      <Card.Body>
                        <Card.Title>Результат диагностики:</Card.Title>
                        <Card.Text>{curorder?.Diagnostic}</Card.Text>
                      </Card.Body>
                    </Card>
                      </>
                      }
                  </>
                )}
              </>
            )}

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
          </Modal.Body>
          {/* <Modal.Footer>
            <Link to='/'>
              <Button variant='secondary' onClick={handleClose}>
                Выйти
              </Button>
            </Link>
            <Button variant='primary' onClick={handleClose}>
              Отмена
            </Button>
          </Modal.Footer> */}
        </Modal>
      </>
    </div>
  );
}
