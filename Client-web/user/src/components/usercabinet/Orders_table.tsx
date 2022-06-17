import Modal from 'react-bootstrap/Modal';
import React, { useState } from 'react';
import { Button, Nav, Navbar, Container, NavDropdown, Table, Form } from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap-icons/font/bootstrap-icons.css';
import { Link } from 'react-router-dom';
import Links from '../Links';
import BtnNewOrder from '../newOrder/BtnNewOrder';
import ServOrders from '../../redux/services/ServOrders';
import { OrderModel } from '../../models/OrderModel';

export default function Orders_table() {
  const [show, setShow] = useState(false);

  const [orders, setOrders] = useState<OrderModel[]>([]);

  const [key, setKey] = useState<boolean>(false);// установка значений на странице

  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);

  React.useEffect(() => { // при загрузке страницы, один раз
    console.log("Начало ехать");
    if (key) return;
    console.log("Продолжило");
    ServOrders.getOrders().then((res:any) => {
      console.log(res);
      console.log("Поехало");
      setOrders(res);
      console.log(res);
    })
    setKey(true);

  }, [orders, key])

  return (
    <div className='mt-5'>
      <Container>
        <Button color='primary' size='lg' className='.text-center mt-3' onClick={handleShow}>
          Отобразить список устройтсв
        </Button>
        <h1 className='display-4'>Список устройств в ремонте</h1>
        <Container>
          <Table striped bordered hover>
            <thead>
              <tr>
                <th>Устройство</th>
                <th>Описание</th>
                <th>Статус</th>
                <th>Цена</th>
              </tr>
            </thead>
            <tbody>
            {orders?.map((order)=>(
              <tr>
                <td>{order?.IdPhone}</td>
                <td>{order?.Dateord}</td>
                {/* <td>{order?.Phonenumber}</td> без знака вопроса будет пытаться загружать нулы  */}
                <td>{order?.Phonenumber}</td> 
                <td>{order?.Address}</td>
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
          <Modal.Body>Детализация</Modal.Body>
          <Modal.Footer>
            <Link to='/'>
              <Button variant='secondary' onClick={handleClose}>
                Выйти
              </Button>
            </Link>
            <Button variant='primary' onClick={handleClose}>
              Отмена
            </Button>
          </Modal.Footer>
        </Modal>
      </>
    </div>
  );
}
