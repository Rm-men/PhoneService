import Modal from 'react-bootstrap/Modal';
import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import Alert_update from './alert_update';
import Orders_table from './Orders_table';
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
      <Orders_table/>
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
