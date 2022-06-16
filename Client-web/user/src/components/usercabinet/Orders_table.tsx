import Modal from 'react-bootstrap/Modal';
import React, { useState } from 'react';
import { Button, Nav, Navbar, Container, NavDropdown, Table, Form } from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap-icons/font/bootstrap-icons.css';
import { Link } from 'react-router-dom';
import Links from '../Links';

export default function Orders_table() {
  const [show, setShow] = useState(false);

  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);
  return (
    <div className = "mt-5">
      
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
              </tbody>
            </Table>
          </Container>
          <Form className='form-subscribe form-inline mb-3'>
            <div className='text-center'>
              <Button color='primary' size='lg' className='.text-center mt-3' onClick={handleShow}>
                Оформить заявку на ремонт
              </Button>
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
