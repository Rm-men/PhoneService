import Modal from 'react-bootstrap/Modal';
import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import Alert_update from './alert_update';

import L_Navibar from './auth_Navibar';
import {
  Button,
  Nav,
  Navbar,
  Table,
  Container,
  Row,
  Form,
  Col,
  FloatingLabel,
  Alert
} from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';

export default function UserCabinet() {
  const [show, setShow] = useState(false);

  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);
  return (
    <>
      <L_Navibar />
      <div className='header bg-white mt-5'>
        <Container>
          <h1 className='display-4'>Список устройств в ремонте</h1>
          <Container>
            <Table striped bordered hover>
              <thead>
                <tr>
                  <th>#</th>
                  <th>First Name</th>
                  <th>Last Name</th>
                  <th>Username</th>
                </tr>
              </thead>
              <tbody>
                <tr>
                  <td>1</td>
                  <td>Mark</td>
                  <td>Otto</td>
                  <td>@mdo</td>
                </tr>
                <tr>
                  <td>2</td>
                  <td>Jacob</td>
                  <td>Thornton</td>
                  <td>@fat</td>
                </tr>
                <tr>
                  <td>3</td>
                  <td colSpan={2}>Larry the Bird</td>
                  <td>@twitter</td>
                </tr>
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
      </div>
      <Alert_update></Alert_update>
      <>
        <Modal show={show} onHide={handleClose}>
          <Modal.Header closeButton>
            <Modal.Title>Оформление новой заявки</Modal.Title>
          </Modal.Header>
          <Modal.Body>
            <FloatingLabel controlId='floatingInput' label='Название устройства' className='mb-3'>
              <Form.Control type='text' placeholder='name@example.com' />
            </FloatingLabel>
            <FloatingLabel controlId='floatingTextarea2' label='Описание неисправности'>
              <Form.Control
                as='textarea'
                placeholder='Введите описание неисправности'
                style={{ height: '100px' }}
              />
            </FloatingLabel>
          </Modal.Body>
          <Modal.Footer>
            <Button variant='secondary' onClick={handleClose}>
              Отмена
            </Button>
              <Button variant='primary' onClick={handleClose}>
                Оформить заявку
              </Button>
          </Modal.Footer>
        </Modal>
      </>
    </>
  );
}
