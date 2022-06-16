import { Container, Row, Col, Form, FormGroup, Button, Modal } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import React, { useState } from 'react';
import Links from '../Links';

function BtnNewOrder() {
  const [show, setShow] = useState(false);

  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);
  return (
    <>
      <Button color='primary' size='lg' className=' mt-4' onClick={handleShow}>
        Оставить заявку на ремонт
      </Button>
      <Modal show={show} onHide={handleClose}>
        <Modal.Header closeButton>
          <Modal.Title>Предупреждение</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          Заявки на ремонт доступны <b>только зарегистрированным</b> пользователям.
          Зарегистрироваться?
        </Modal.Body>
        <Modal.Footer>
          <Button variant='secondary' onClick={handleClose}>
            Отмена
          </Button>
          <Link to={Links.register}>
            <Button variant='primary' onClick={handleClose}>
              Зарегистрироваться
            </Button>
          </Link>
        </Modal.Footer>
      </Modal>
    </>
  );
}
export default BtnNewOrder();
